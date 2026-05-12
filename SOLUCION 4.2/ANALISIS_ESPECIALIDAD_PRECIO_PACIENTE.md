# Investigación: Especialidad → PrecioPublico → Paciente

## Tabla `Especialidad` — 18 columnas

| Campo | Tipo | Nulo | Default | Descripción |
|-------|------|------|---------|-------------|
| `id` | uniqueidentifier | NO | `newid()` | PK — GUID autogenerado |
| `codigo` | varchar(50) | YES | NULL | Código de la especialidad |
| `descripcion` | varchar(256) | NO | `''` | Nombre visible |
| `registroBLOB` | varchar(256) | YES | NULL | Datos de sincronización |
| `actualizacion_local` | datetime | YES | `getdate()` | Timestamp de última modificación |
| `operacion_local` | varchar(10) | YES | `''` | Operación de sync (I/U/D) |
| `sincronizado` | datetime | YES | NULL | Fecha de última sincronización servidor |
| `serverID` | uniqueidentifier | YES | NULL | ID en servidor de sync |
| `idMotivoConsulta` | int | NO | NULL | FK a `MotivoDeConsulta.id` |
| `precioBase` | decimal | YES | NULL | Precio promo del último período guardado |
| `orden` | int | YES | NULL | Orden de visualización |
| `tipo` | int | YES | NULL | Tipo interno |
| `descripcionInformes` | varchar(150) | YES | NULL | Descripción para informes/reportes |
| `Padre` | bit | YES | `0` | `0` = hijo (prestación), `1` = padre (categoría) |
| `IdPadre` | varchar(50) | YES | NULL | GUID del padre (categoría contenedora) |
| `estado` | int | NO | `1` | `1` = activo, `0` = inactivo |
| `precioLista` | decimal | NO | `0` | Precio lista del último período guardado |
| `IPCBase` | decimal | YES | **`1.0`** | **Coeficiente IPC individual por especialidad** |

### Observaciones clave de `Especialidad`
- **Jerarquía:** `Padre = 1` son categorías (PSICOTECNICO, LEY + AUDIO, etc.); `Padre = 0 AND IdPadre IS NOT NULL` son las prestaciones individuales (las que se muestran en la grilla)
- **`precioBase` y `precioLista`** se actualizan automáticamente cuando se guarda `PrecioPublico` (sincronización desde el último período guardado)
- **`IPCBase`** (default `1.0`) es el coeficiente particular de esa especialidad para la vista anual; todos los registros actuales tienen `1.0`
- Los registros eliminados se filtran con `id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)`

---

## Tabla `PrecioPublico` — 26 columnas

| Campo | Tipo | Nulo | Descripción |
|-------|------|------|-------------|
| `id` | int | NO | PK autoincremental |
| `idEspecialidad` | uniqueidentifier | NO | FK → `Especialidad.id` |
| `Descripcion` | varchar(256) | NO | Copia desnormalizada de la descripción |
| `Mes` | int | NO | Mes del período (1-12) |
| `Anio` | int | NO | Año del período |
| `FechaModificacion` | datetime | YES | Timestamp del último guardado |
| `Eliminado` | bit | YES | Soft delete (`1` = eliminado) |
| `PrecioLista` | decimal | NO | Precio de lista para este período |
| `PrecioPromo` | decimal | NO | Precio promocional para este período |
| `SeñaPromo` | decimal | NO | Seña para precio promo |
| `SeñaLista` | decimal | NO | Seña para precio lista |
| `LlevaPlanilla` | bit | NO | Indica si requiere planilla |
| `ObservacionesExtra` | varchar(200) | YES | Notas adicionales |
| `Coeficiente` | decimal | YES | Coeficiente global heredado (histórico) |
| `CoeficienteIndividual` | decimal | YES | **Coeficiente individual por fila/mes** (usado en vista anual como `Coef01..12`) |
| `CoeficienteIndividual01`..`11` | decimal | YES | 11 columnas adicionales (no usadas aún) |

### Estadísticas actuales (2026)
- **156 especialidades** activas con precios
- **311 registros** activos (`Eliminado = 0`)

---

## Tabla `CoeficientePrecio` — Coeficientes globales por mes/año

Usada para los coeficientes globales (`_coefs[]` en la UI). Columnas relevantes:

| Campo | Tipo | Descripción |
|-------|------|-------------|
| `Mes` | int | Mes (1-12) |
| `Anio` | int | Año |
| `Coeficiente` | decimal | Factor de incremento global para ese mes/año |
| `FechaModificacion` | datetime | Timestamp |

---

## Tabla `TipoExamenDePaciente` — Nexo Paciente ↔ Precio

| Campo | Tipo | Descripción |
|-------|------|-------------|
| `id` | uniqueidentifier | PK |
| `idConsulta` | uniqueidentifier | FK → consulta (opcional) |
| `idTurno` | uniqueidentifier | FK → `Turno.id` |
| `modificado` | varchar(3) | Flag de modificación |
| `idEspecialidad` | uniqueidentifier | FK → `Especialidad.id` |
| `precioExamen` | decimal | **Precio promo en el momento del examen (snapshot)** |
| `precioLista` | decimal | **Precio lista en el momento del examen (snapshot)** |
| `rm` / `imp` / `inf` / `factClub` | varchar(1) | Flags de procesamiento |
| `mail` / `dictAut` / `impLab` / `cons` | varchar(1) | Flags adicionales |

---

## Cadena completa: Paciente → Especialidad → Precio

```
Paciente
  └─ Turno  (Turno.pacienteID = Paciente.id)
       └─ TipoExamenDePaciente  (idTurno, idEspecialidad)
              ├─ precioExamen   ← snapshot del PrecioPromo al momento del examen
              ├─ precioLista    ← snapshot del PrecioLista al momento del examen
              └─ idEspecialidad → Especialidad
                                     ├─ precioBase  ← sincronizado desde PrecioPromo del último período
                                     ├─ precioLista ← sincronizado desde PrecioLista del último período
                                     └─ IPCBase     ← coeficiente individual de la especialidad
                                          └─ PrecioPublico  (Mes, Anio)
                                                   ├─ PrecioPromo    → Especialidad.precioBase
                                                   ├─ PrecioLista    → Especialidad.precioLista
                                                   └─ CoeficienteIndividual  (Coef01..12 en vista anual)
```

### Flujo de sincronización inversa (al guardar en frmPreciosPublico)
1. `GuardarPreciosPublicoAnio()` → actualiza `PrecioPublico.PrecioPromo` y `CoeficienteIndividual` por mes
2. Simultáneamente → `UPDATE Especialidad SET IPCBase = ... WHERE id = '...'`
3. `GuardarPreciosPublico()` (vista mensual) → `UPDATE Especialidad SET precioBase = PrecioPromo, precioLista = PrecioLista`

---

## Tablas relacionadas con Paciente

| Tabla | Descripción |
|-------|-------------|
| `Paciente` | Paciente base |
| `PacienteLaboral` | Datos laborales del paciente |
| `PacienteTipo` | Tipos de paciente |
| `Turno` | Turnos agendados (tiene `pacienteID`) |
| `TurnoEstado` | Estados posibles de turno |
| `TurnoSolicitud` / `TurnoOpcionesHorarias` | Solicitudes y opciones de horario |
| `EmpresasPorPaciente` | Empresa asociada al paciente (`idPaciente`, `idEmpresa`, `tarea`, `ingreso`) |
| `TipoExamenDePaciente` | Exámenes con precios por turno |
| `ExamenLaboral` | Datos clínicos del examen laboral (GUID-based, sin FK directa a Paciente visible) |
| `ExamenPreventiva` | Datos clínicos del examen preventiva (`idTipoExamen` como FK) |
| `clubesPorPaciente` | Clubs/convenios asociados al paciente |
| `ItemsPorPaciente` | Ítems adicionales por paciente |

---

---

## Tablas adicionales investigadas

### `NombreListaPrecios` — 16 listas de precios nombradas

| id | NombreLista |
|----|-------------|
| 1 | EMPRESAS SIN ABONO |
| 2 | BONIFACIO |
| 3 | OSCAR MILLONES |
| 4 | CASINO BUENOS AIRES |
| 5 | EMPRESAS CON ABONO |
| 6 | LABORATORIOS BETA |
| 7 | CONTACTO GARANTIDO |
| 8 | PORFIRI |
| 9 | EMPRESAS IVA EXENTO |
| 13-19 | Variantes 2021 de las anteriores |

### `ListaPreciosBase` — Precios legacy por lista nombrada

| Campo | Tipo | Descripción |
|-------|------|-------------|
| `id` | int | PK |
| `idNombreLista` | int | FK → `NombreListaPrecios.id` |
| `NombrePrestacion` | varchar(80) | Nombre del ítem |
| `TipoPrestacion` | varchar(80) | Tipo (ej: "Examen Aptitud") |
| `Codigo` | varchar(10) | Código alfanumérico |
| `Descripcion` | varchar(80) | Descripción |
| `Costo` | varchar(20) | Precio como texto (**sistema viejo**) |
| `Factura` | varchar(20) | Precio factura como texto |
| `Eliminado` | bit | Soft delete |

> Sistema **legacy/viejo**: precios como texto, sin FK a `Especialidad`, sin período mensual/anual. La mayoría con `Eliminado=1`.

### `ListaPrecios` — Tabla nueva (solo 3 registros)
Solo tiene `id (GUID)`, `descripcion`, campos de sync. Parece un reemplazo no completado del sistema viejo.

### `ElementosListaPrecioPorConsultaLaboral`
Vincula consultas laborales con ítems de `ListaPreciosBase` (id, idConsultaLaboral, idElementoLista, fecha).

### `Horario` — Agenda de profesionales/especialidades
| Campo | Tipo | Relevancia |
|-------|------|------------|
| `id` | uniqueidentifier | PK |
| `profesionalID` | uniqueidentifier | FK a profesional |
| `especialidadID` | uniqueidentifier | FK → `Especialidad.id` |
| `horaDesde`/`horaHasta` | varchar(5) | Franja horaria |
| `diasSimplificado` | varchar(50) | L,M,X,J,V,S,D |
| `fechaDesde`/`fechaHasta` | datetime | Vigencia |
| `cantidadTurnos`, `citarCada` | int | Cupos y frecuencia |

→ Define qué especialidad atiende cada profesional y cuándo. **No impacta precios**.

### `Liga` y `Club` — Clasificación de pacientes deportivos
Ambas: `id (GUID)`, `codigo`, `descripcion`. Paciente pertenece a Club → Liga → `Liga.idEspecialidad`.  
Permiten asignar una especialidad "por defecto" a la liga deportiva.

### `Empresa`
`id (GUID)`, `razonSocial`, `nombreFantasia`, `cuit`, `tipoDeDocumento`, etc.  
Un paciente tiene `empresaID` y puede tener múltiples empresas en `EmpresasPorPaciente`.

---

## Diseño: nueva tabla + múltiples tabs en frmPreciosPublico

### Por qué una tabla nueva (no columnas en `Especialidad`)

- `Especialidad` tiene sistema de sincronización (`registroBLOB`, `sincronizado`, `serverID`). Agregar columnas rompe la sincronización existente.
- La tabla `Especialidad` no tiene esquema de "config de precio" — mezclar conceptos.
- Una tabla dedicada permite extender sin tocar entidades core.

### Diagnóstico del problema actual

La tabla `PrecioPublico` mezcla dos categorías de datos:

| Categoría | Campos | Debería estar en |
|-----------|--------|-----------------|
| Precio periódico | `PrecioLista`, `PrecioPromo`, `CoeficienteIndividual` | `PrecioPublico` (✓ correcto) |
| Config de especialidad | `SeñaPromo`, `SeñaLista`, `LlevaPlanilla`, `ObservacionesExtra` | **Nueva tabla** |

**Evidencia:** solo 3 de 311 registros tienen SeñaPromo ≠ 0, y esos 3 tienen el **mismo valor en todos sus meses** → no es dato del período.

---

### Estructura propuesta del formulario

```
frmPreciosPublico
├── lblTitulo         (barra verde superior — sin cambios)
├── pnlSuperior       (Año, Buscar, Cargar — sin cambios)
├── pnlMenu           (Guardar, CopiarAño, Aplicar% — sin cambios)
└── tabControl        (NUEVO — reemplaza pnlCentro)
     ├── tabPrecios       "💲 Precios Públicos"   → dgvPrecios   (grilla anual actual)
     └── tabConfigEsp     "⚙ Señas / Planilla"   → dgvConfig    (nueva grilla simple)
```

Tab adicionales futuros posibles:  
`tabEmpresaSinAbono`, `tabBolifacio`, etc. — uno por lista de empresa.

---

### Paso 1 — Nueva tabla SQL: `ConfigPrecioEspecialidad`

```sql
CREATE TABLE ConfigPrecioEspecialidad (
    id                int             IDENTITY(1,1) NOT NULL,
    idEspecialidad    uniqueidentifier NOT NULL,
    SeñaPromo         decimal(18,2)   NOT NULL DEFAULT 0,
    SeñaLista         decimal(18,2)   NOT NULL DEFAULT 0,
    LlevaPlanilla     bit             NOT NULL DEFAULT 0,
    Observaciones     varchar(200)        NULL,
    FechaModificacion datetime            NULL DEFAULT GETDATE(),

    CONSTRAINT PK_ConfigPrecioEspecialidad  PRIMARY KEY (id),
    CONSTRAINT UQ_Config_Especialidad       UNIQUE (idEspecialidad)
    -- No FK formal a Especialidad para no romper sincronización
);

-- Migrar los 3 registros con datos reales desde PrecioPublico
INSERT INTO ConfigPrecioEspecialidad (idEspecialidad, SeñaPromo, SeñaLista, LlevaPlanilla)
SELECT
    idEspecialidad,
    MAX(SeñaPromo)                  AS SeñaPromo,
    MAX(SeñaLista)                  AS SeñaLista,
    MAX(CAST(LlevaPlanilla AS int)) AS LlevaPlanilla
FROM PrecioPublico
WHERE Eliminado = 0
  AND (SeñaPromo <> 0 OR SeñaLista <> 0 OR LlevaPlanilla = 1)
GROUP BY idEspecialidad;
```

**Diseño:** una fila por especialidad (UNIQUE), independiente del período mensual/anual.

---

### Paso 2 — Columnas de `dgvConfig` (Tab "Señas / Planilla")

| Columna | Nombre Header | Editable | Tipo celda | Ancho |
|---------|--------------|----------|------------|-------|
| `colCfgIdEsp` | — | No (oculta) | Text | 0 |
| `colCfgMotivo` | Motivo | No | Text | 120 |
| `colCfgTipo` | Tipo | No | Text | 100 |
| `colCfgDescripcion` | Descripción | No | Text | 220 |
| `colCfgSeñaPromo` | Seña Promo | **Sí** | Text (decimal) | 100 |
| `colCfgSeñaLista` | Seña Lista | **Sí** | Text (decimal) | 100 |
| `colCfgPlanilla` | Planilla | **Sí** | CheckBox | 70 |
| `colCfgObservaciones` | Observaciones | **Sí** | Text | 250 |

Colores: cabecera azul oscuro, celdas editables fondo `#EFF5FF`, readonly fondo blanco.

---

### Paso 3 — Nuevos métodos en `CapaDatosMepryl.PrecioPublico`

```csharp
public DataTable ListarConfigEspecialidades()
{
    string strSQL =
        "SELECT e.id AS idEspecialidad, " +
        "ISNULL(m.nombre,'') AS Motivo, " +
        "ISNULL(padre.descripcion,'') AS Tipo, " +
        "e.descripcion AS Descripcion, " +
        "ISNULL(c.SeñaPromo, 0) AS SeñaPromo, " +
        "ISNULL(c.SeñaLista, 0) AS SeñaLista, " +
        "ISNULL(c.LlevaPlanilla, 0) AS LlevaPlanilla, " +
        "ISNULL(c.Observaciones, '') AS Observaciones " +
        "FROM Especialidad e " +
        "LEFT JOIN ConfigPrecioEspecialidad c ON c.idEspecialidad = e.id " +
        "LEFT JOIN MotivoDeConsulta m ON e.idMotivoConsulta = m.id " +
        "LEFT JOIN Especialidad padre ON e.IdPadre = padre.id " +
        "WHERE e.Padre = 0 AND e.estado = 1 AND e.IdPadre IS NOT NULL " +
        "AND e.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas) " +
        "ORDER BY m.nombre, padre.descripcion, e.descripcion";
    return SQLConnector.obtenerTablaSegunConsultaString(strSQL);
}

public void GuardarConfigEspecialidades(DataTable dtDatos)
{
    if (dtDatos == null || dtDatos.Rows.Count == 0) return;
    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < dtDatos.Rows.Count; i++)
    {
        string id       = dtDatos.Rows[i]["idEspecialidad"].ToString();
        string sPromo   = dtDatos.Rows[i]["SeñaPromo"].ToString().Replace(",", ".");
        string sLista   = dtDatos.Rows[i]["SeñaLista"].ToString().Replace(",", ".");
        string planilla = (Convert.ToBoolean(dtDatos.Rows[i]["LlevaPlanilla"]) ? "1" : "0");
        string obs      = dtDatos.Rows[i]["Observaciones"].ToString().Replace("'", "''");

        sb.AppendLine(
            "IF EXISTS (SELECT 1 FROM ConfigPrecioEspecialidad WHERE idEspecialidad='" + id + "') " +
            "UPDATE ConfigPrecioEspecialidad SET SeñaPromo=" + sPromo +
            ", SeñaLista=" + sLista +
            ", LlevaPlanilla=" + planilla +
            ", Observaciones='" + obs + "'" +
            ", FechaModificacion=GETDATE() WHERE idEspecialidad='" + id + "' " +
            "ELSE IF " + sPromo + "<>0 OR " + sLista + "<>0 OR " + planilla + "=1 OR LEN('" + obs + "')>0 " +
            "INSERT INTO ConfigPrecioEspecialidad(idEspecialidad,SeñaPromo,SeñaLista,LlevaPlanilla,Observaciones) " +
            "VALUES('" + id + "'," + sPromo + "," + sLista + "," + planilla + ",'" + obs + "');");
    }
    SQLConnector.obtenerTablaSegunConsultaString(sb.ToString());
}
```

> **Optimización:** el INSERT solo ocurre si hay algún valor distinto de cero/vacío, para no llenar la tabla con filas "vacías".

---

### Paso 4 — Cambios en `frmPreciosPublico.cs`

```csharp
// Campo nuevo
private DataTable _dtConfig = null;

// En CargarGrilla() — agregar al final:
CargarGrillaConfig();

// Nuevo método:
private void CargarGrillaConfig()
{
    dgvConfig.Rows.Clear();
    _dtConfig = precioPublico.ListarConfigEspecialidades();
    foreach (DataRow row in _dtConfig.Rows)
    {
        int idx = dgvConfig.Rows.Add();
        dgvConfig.Rows[idx].Cells["colCfgIdEsp"].Value        = row["idEspecialidad"].ToString();
        dgvConfig.Rows[idx].Cells["colCfgMotivo"].Value       = row["Motivo"].ToString();
        dgvConfig.Rows[idx].Cells["colCfgTipo"].Value         = row["Tipo"].ToString();
        dgvConfig.Rows[idx].Cells["colCfgDescripcion"].Value  = row["Descripcion"].ToString();
        dgvConfig.Rows[idx].Cells["colCfgSeñaPromo"].Value    = ParseDecimal(row["SeñaPromo"]);
        dgvConfig.Rows[idx].Cells["colCfgSeñaLista"].Value    = ParseDecimal(row["SeñaLista"]);
        dgvConfig.Rows[idx].Cells["colCfgPlanilla"].Value     = Convert.ToBoolean(row["LlevaPlanilla"]);
        dgvConfig.Rows[idx].Cells["colCfgObservaciones"].Value = row["Observaciones"].ToString();
    }
    // Aplicar mismo filtro de búsqueda
    AplicarFiltroConfig(txtBuscar.Text.Trim().ToLower());
}

// En btnGuardar_Click — agregar:
GuardarConfig();

// Nuevo método:
private void GuardarConfig()
{
    DataTable dt = new DataTable();
    dt.Columns.Add("idEspecialidad", typeof(string));
    dt.Columns.Add("SeñaPromo",     typeof(decimal));
    dt.Columns.Add("SeñaLista",     typeof(decimal));
    dt.Columns.Add("LlevaPlanilla", typeof(bool));
    dt.Columns.Add("Observaciones", typeof(string));

    foreach (DataGridViewRow row in dgvConfig.Rows)
    {
        DataRow dr = dt.NewRow();
        dr["idEspecialidad"] = row.Cells["colCfgIdEsp"].Value?.ToString() ?? "";
        dr["SeñaPromo"]      = ParseDecimal(row.Cells["colCfgSeñaPromo"].Value);
        dr["SeñaLista"]      = ParseDecimal(row.Cells["colCfgSeñaLista"].Value);
        dr["LlevaPlanilla"]  = row.Cells["colCfgPlanilla"].Value is bool b && b;
        dr["Observaciones"]  = row.Cells["colCfgObservaciones"].Value?.ToString() ?? "";
        dt.Rows.Add(dr);
    }
    precioPublico.GuardarConfigEspecialidades(dt);
}
```

---

### Paso 5 — `txtBuscar` filtra AMBAS grillas

```csharp
private void txtBuscar_TextChanged(object sender, EventArgs e)
{
    string filtro = txtBuscar.Text.Trim().ToLower();
    int visibles = 0;
    foreach (DataGridViewRow row in dgvPrecios.Rows)
    {
        string desc   = row.Cells["colDescripcion"].Value?.ToString().ToLower() ?? "";
        string motivo = row.Cells["colMotivo"].Value?.ToString().ToLower()      ?? "";
        string tipo   = row.Cells["colTipo"].Value?.ToString().ToLower()        ?? "";
        bool visible = string.IsNullOrEmpty(filtro) || desc.Contains(filtro) || motivo.Contains(filtro) || tipo.Contains(filtro);
        row.Visible = visible;
        if (visible) visibles++;
    }
    lblTotal.Text = "Prestaciones: " + visibles;
    AplicarFiltroConfig(filtro);
}

private void AplicarFiltroConfig(string filtro)
{
    foreach (DataGridViewRow row in dgvConfig.Rows)
    {
        string desc   = row.Cells["colCfgDescripcion"].Value?.ToString().ToLower() ?? "";
        string motivo = row.Cells["colCfgMotivo"].Value?.ToString().ToLower()      ?? "";
        string tipo   = row.Cells["colCfgTipo"].Value?.ToString().ToLower()        ?? "";
        row.Visible = string.IsNullOrEmpty(filtro) || desc.Contains(filtro) || motivo.Contains(filtro) || tipo.Contains(filtro);
    }
}
```

---

### Esquema final de responsabilidades

```
ConfigPrecioEspecialidad     ← NUEVA TABLA
  └─ idEspecialidad (UNIQUE)
  └─ SeñaPromo, SeñaLista    ← editados en Tab "Señas/Planilla"
  └─ LlevaPlanilla
  └─ Observaciones

Especialidad (sin cambios)
  └─ precioBase, precioLista ← sync desde PrecioPublico al guardar
  └─ IPCBase                 ← coef. individual (Tab "Precios Públicos")

PrecioPublico (por Mes/Año)
  └─ PrecioLista, PrecioPromo
  └─ CoeficienteIndividual   ← Coef01..12 en Tab "Precios Públicos"
  └─ SeñaPromo, SeñaLista    ← columnas legacy, YA NO se editan desde UI
  └─ LlevaPlanilla           ← ídem

Listas de precios por empresa/club (futuro Tab 3+)
  └─ Usar NombreListaPrecios + nueva tabla PrecioListaEmpresa
     (idNombreLista, idEspecialidad, Anio, Precio)
```

---

## Orden de implementación recomendado

1. **SQL:** `CREATE TABLE ConfigPrecioEspecialidad` + migración de 3 registros
2. **CapaDatos:** agregar `ListarConfigEspecialidades()` y `GuardarConfigEspecialidades()`
3. **CapaNegocio:** agregar wrappers
4. **Designer:** reemplazar `pnlCentro` por `TabControl` con `tabPrecios` + `tabConfigEsp`, agregar `dgvConfig`
5. **frmPreciosPublico.cs:** agregar `CargarGrillaConfig()`, `GuardarConfig()`, actualizar `txtBuscar_TextChanged`
6. **Verificar build** y probar



## Rol de `IPCBase` en `frmPreciosPublico`

- Columna `colIPCBase` en la grilla anual (color fondo gris azulado)
- Se edita directamente en la celda por fila
- Al editar → `dgvPrecios_CellEndEdit` → `AplicarCalculoCoeficientesSucesivosFila(1, rowIndex)` → recalcula los 12 meses usando ese IPC como base inicial
- Se persiste en `GuardarPreciosPublicoAnio()` → `UPDATE Especialidad SET IPCBase = ...`
- Si es `0` → la fila no usa coeficiente individual, respeta el flujo estándar de coeficientes globales

---

## Query SQL completa para vista anual (ListarPreciosPublicoAnio)

```sql
SELECT e.id AS idEspecialidad,
       ISNULL(m.nombre, '')            AS Motivo,
       ISNULL(padre.descripcion, '')   AS Tipo,
       e.descripcion                   AS Descripcion,
       e.IPCBase                       AS IPCBase,
       -- Coeficientes individuales por mes
       ISNULL(MAX(CASE WHEN p.Mes = 1  THEN p.CoeficienteIndividual END), 0) AS Coef01,
       -- ... Coef02..Coef12 ...
       -- Precios promo por mes
       ISNULL(MAX(CASE WHEN p.Mes = 1  THEN p.PrecioPromo END), 0) AS Promo01
       -- ... Promo02..Promo12 ...
FROM Especialidad e
LEFT JOIN PrecioPublico p  ON e.id = p.idEspecialidad AND p.Anio = {anio} AND p.Eliminado = 0
LEFT JOIN MotivoDeConsulta m ON e.idMotivoConsulta = m.id
LEFT JOIN Especialidad padre ON e.IdPadre = padre.id
WHERE e.Padre = 0 AND e.estado = 1 AND e.IdPadre IS NOT NULL
  AND e.id NOT IN (SELECT id FROM dbo.EspecialidadesEliminadas)
GROUP BY e.id, m.nombre, padre.descripcion, e.descripcion, e.IPCBase
ORDER BY m.nombre, padre.descripcion, e.descripcion
```
