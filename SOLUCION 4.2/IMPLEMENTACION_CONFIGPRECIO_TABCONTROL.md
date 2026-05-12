# Implementación: ConfigPrecioEspecialidad + TabControl en frmPreciosPublico

**Fecha:** Mayo 2026  
**Módulo afectado:** Precios al Público (`frmPreciosPublico`)

---

## Problema detectado

`SeñaPromo`, `SeñaLista`, `LlevaPlanilla` y `ObservacionesExtra` estaban almacenadas en la tabla `PrecioPublico` (una fila por especialidad × mes × año). Esto generaba:

- **Redundancia masiva:** los mismos valores se repetían en los 12 meses × cada año sin variar nunca.
- **Evidencia:** de 311 registros activos en 2026, solo 3 tenían `SeñaPromo ≠ 0`, y esos 3 mostraban el mismo valor en todos sus meses.
- **Error conceptual:** son datos de la especialidad, no del período.

> No se podía agregar columnas a `Especialidad` porque tiene un sistema de sincronización activo (`registroBLOB`, `serverID`, `sincronizado`) que se rompería con cualquier `ALTER TABLE`.

---

## Solución implementada

### 1. Nueva tabla SQL: `ConfigPrecioEspecialidad`

```sql
CREATE TABLE ConfigPrecioEspecialidad (
    id                int              IDENTITY(1,1) NOT NULL,
    idEspecialidad    uniqueidentifier NOT NULL,
    SeñaPromo         decimal(18,2)    NOT NULL DEFAULT 0,
    SeñaLista         decimal(18,2)    NOT NULL DEFAULT 0,
    LlevaPlanilla     bit              NOT NULL DEFAULT 0,
    Observaciones     varchar(200)         NULL,
    FechaModificacion datetime             NULL DEFAULT GETDATE(),
    CONSTRAINT PK_ConfigPrecioEspecialidad PRIMARY KEY (id),
    CONSTRAINT UQ_Config_Especialidad      UNIQUE (idEspecialidad)
);
```

- **UNIQUE en `idEspecialidad`:** una sola fila de config por especialidad.
- **No se migran registros vacíos:** solo se inserta si al menos un campo tiene valor distinto de cero/vacío.
- **Migración inicial:** 2 especialidades migradas desde `PrecioPublico` (FUTBOL METRO y VOLEY, ambas con `SeñaPromo=5000`, `SeñaLista=5000`, `LlevaPlanilla=1`).

---

### 2. Capa de datos — `CapaDatosMepryl/PrecioPublico.cs`

Dos métodos nuevos añadidos al final de la clase:

#### `ListarConfigEspecialidades()` → `DataTable`
```sql
SELECT e.id AS idEspecialidad,
       ISNULL(m.nombre,'')          AS Motivo,
       ISNULL(padre.descripcion,'') AS Tipo,
       e.descripcion                AS Descripcion,
       ISNULL(c.SeñaPromo, 0)       AS SeñaPromo,
       ISNULL(c.SeñaLista, 0)       AS SeñaLista,
       ISNULL(c.LlevaPlanilla, 0)   AS LlevaPlanilla,
       ISNULL(c.Observaciones, '')  AS Observaciones
FROM   Especialidad e
LEFT JOIN ConfigPrecioEspecialidad c ON c.idEspecialidad = e.id
LEFT JOIN MotivoDeConsulta m         ON e.idMotivoConsulta = m.id
LEFT JOIN Especialidad padre         ON e.IdPadre = padre.id
WHERE  e.Padre = 0 AND e.estado = 1 AND e.IdPadre IS NOT NULL
AND    e.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
ORDER BY m.nombre, padre.descripcion, e.descripcion
```
- LEFT JOIN a `ConfigPrecioEspecialidad` → si la especialidad no tiene fila, aparece con ceros (comportamiento por defecto).
- Filtra solo prestaciones activas (hijos no eliminados).

#### `GuardarConfigEspecialidades(DataTable)` → `void`
- Para cada fila del `DataTable`:
  - Si ya existe fila en `ConfigPrecioEspecialidad`: hace `UPDATE`.
  - Si no existe **y** al menos un campo tiene valor: hace `INSERT`.
  - Si no existe y todos están en cero/vacío: no hace nada (no genera ruido).
- Genera un `StringBuilder` con sentencias `IF EXISTS ... UPDATE ... ELSE IF ... INSERT` y las ejecuta en un solo llamado a `SQLConnector`.

---

### 3. Capa de negocio — `CapaNegocioMepryl/PrecioPublico.cs`

Dos wrappers simples añadidos (patrón facade):

```csharp
public DataTable ListarConfigEspecialidades()
    => precioPublico.ListarConfigEspecialidades();

public void GuardarConfigEspecialidades(DataTable dtDatos)
    => precioPublico.GuardarConfigEspecialidades(dtDatos);
```

---

### 4. Presentación — `frmPreciosPublico.Designer.cs`

Se reemplazó el `Panel pnlCentro` (contenedor directo de `dgvPrecios`) por un `TabControl` con **2 tabs en la parte inferior**:

| Tab | Título | Contenido |
|-----|--------|-----------|
| 0 | `  Precios Públicos` | `dgvPrecios` (grilla existente sin cambios) |
| 1 | `  Señas / Planilla` | `dgvConfig` (nueva grilla editable) |

Propiedades del `TabControl`:
- `Alignment = Bottom` → pestañas en la parte inferior
- `Dock = Fill`
- `Font = Segoe UI 10pt Bold`

Columnas de `dgvConfig`:

| Nombre columna | Header | Tipo | Editable | FillWeight |
|---------------|--------|------|----------|-----------|
| `colCfgIdEsp` | Id | TextBox | No (oculta) | — |
| `colCfgMotivo` | Motivo | TextBox | No (ReadOnly) | 80 |
| `colCfgTipo` | Tipo | TextBox | No (ReadOnly) | 100 |
| `colCfgDescripcion` | Descripción | TextBox | No (ReadOnly) | 200 |
| `colCfgSeñaPromo` | Seña Promo | TextBox | **Sí** | 80 |
| `colCfgSeñaLista` | Seña Lista | TextBox | **Sí** | 80 |
| `colCfgPlanilla` | Planilla | CheckBox | **Sí** | 60 |
| `colCfgObservaciones` | Observaciones | TextBox | **Sí** | 250 |

---

### 5. Presentación — `frmPreciosPublico.cs`

Métodos nuevos y cambios en métodos existentes:

#### Nuevo: `ConfigurarGrillaConfig()`
- Llama en `frmPreciosPublico_Load`.
- Aplica estilos al encabezado de `dgvConfig`: fondo azul oscuro (`#00468C`), texto blanco, fuente Segoe UI 9pt Bold.
- Desactiva sort en todas las columnas.

#### Nuevo: `CargarGrillaConfig()`
- Llama a `precioPublico.ListarConfigEspecialidades()`.
- Llena `dgvConfig` fila a fila (mismo patrón que `CargarGrilla`).

#### Nuevo: `GuardarConfig()`
- Construye un `DataTable` con los datos actuales de `dgvConfig` (todas las filas, incluso las ocultas por filtro).
- Llama a `precioPublico.GuardarConfigEspecialidades(dtConfig)`.

#### Modificado: `CargarGrilla()`
- Al final (antes del `txtBuscar_TextChanged`) llama a `CargarGrillaConfig()`.
- Así ambas grillas siempre se recargan juntas.

#### Modificado: `btnGuardar_Click()`
- Después de `GuardarPreciosPublicoAnio()` llama a `GuardarConfig()`.
- Un solo botón Guardar guarda ambas tabs.

#### Modificado: `txtBuscar_TextChanged()`
- El filtro de texto ya aplicaba sobre `dgvPrecios`.
- Ahora también aplica sobre `dgvConfig` (filtra por `colCfgDescripcion`, `colCfgMotivo`, `colCfgTipo`).

---

## Archivos modificados

| Archivo | Tipo de cambio |
|---------|---------------|
| `CapaDatosMepryl/PrecioPublico.cs` | +2 métodos nuevos |
| `CapaNegocioMepryl/PrecioPublico.cs` | +2 wrappers |
| `CapaPresentacion/frmPreciosPublico.Designer.cs` | Panel → TabControl + dgvConfig + columnas |
| `CapaPresentacion/frmPreciosPublico.cs` | +3 métodos, 3 existentes modificados |
| **SQL Server (periodo)** | Tabla `ConfigPrecioEspecialidad` creada, 2 registros migrados |

---

## Notas de diseño

- `PrecioPublico.SeñaPromo`, `SeñaLista`, `LlevaPlanilla`, `ObservacionesExtra` **NO se eliminaron** de la tabla por compatibilidad con código existente. Quedan como campos históricos.
- El guardado es **idempotente**: ejecutar varias veces no genera duplicados.
- El filtro del buscador actúa sobre **ambas tabs** en simultáneo.
