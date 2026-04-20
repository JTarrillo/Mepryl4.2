# Documentación de Cambios - Abril 2026

**Rama:** `facturacion-electronica`  
**Commit:** `1b98e91`  
**Fecha:** 20 de Abril de 2026  
**Archivos modificados:** 11 (442 inserciones, 61 eliminaciones)

---

## 1. Precios Público (`frmPreciosPublico`)

### 1.1 Fix parsing decimal (punto vs coma)
- **Problema:** Al ingresar "1.15" como factor, el cálculo daba resultados incorrectos. Solo funcionaba con "1,15".
- **Causa:** El locale es-AR usa coma como separador decimal. `Decimal.TryParse` no reconocía el punto.
- **Solución:** En `ObtenerFactor()` y `chkFactor_CheckedChanged` se normaliza el texto reemplazando `"."` por `","` antes de parsear.
- **Archivos:** `CapaPresentacion/frmPreciosPublico.cs`

### 1.2 Guardado batch (performance)
- **Problema:** Al guardar, se ejecutaba una query SQL por cada fila de la grilla, causando lentitud.
- **Solución:** Se usa `StringBuilder` para armar una consulta batch única con todos los INSERT/UPDATE. Una sola llamada a la base de datos.
- **Archivos:** `CapaDatosMepryl/PrecioPublico.cs` → método `GuardarPreciosPublico`

### 1.3 Grilla no se resetea tras guardar
- **Problema:** Después de guardar, la grilla se recargaba desde la BD, perdiendo el scroll y la posición.
- **Solución:** Se eliminó la llamada a `CargarGrilla()` después del guardado.
- **Archivos:** `CapaPresentacion/frmPreciosPublico.cs`

### 1.4 Botón unificado "Aplicar ▼" con menú desplegable
- **Problema:** Existían dos botones separados ("Aplicar variación" y "Calcular Lista desde Promo") que causaban confusión.
- **Solución:** Se reemplazaron por un único botón "Aplicar ▼" con un `ContextMenuStrip` que ofrece 4 opciones:
  | Opción | Acción |
  |--------|--------|
  | Variación a ambos | Aplica factor a PrecioLista y PrecioPromo |
  | Variación solo a Promo | Aplica factor solo a PrecioPromo |
  | Variación solo a Lista | Aplica factor solo a PrecioLista |
  | Calcular Lista desde Promo | Calcula PrecioLista = PrecioPromo × coeficiente mensual |
- **Archivos:** `CapaPresentacion/frmPreciosPublico.cs`, `frmPreciosPublico.Designer.cs`

### 1.5 Redondeo al millar
- **Problema:** La variación no redondeaba los precios.
- **Solución:** Se usa `Math.Ceiling(valor / 1000m) * 1000m` para redondear hacia arriba al millar más cercano.
- **Archivos:** `CapaPresentacion/frmPreciosPublico.cs` → método `AplicarVariacionGrilla`

### 1.6 Fix ObjectDisposedException
- **Problema:** Al cerrar el formulario a veces una excepción aparecía al intentar liberar el Icon del ContextMenuStrip.
- **Solución:** Dispose envuelto en `try/catch` para `ObjectDisposedException`.
- **Archivos:** `CapaPresentacion/frmPreciosPublico.Designer.cs`

### 1.7 Recarga al volver al formulario
- **Problema:** Si se editaban precios en otro formulario, al volver a frmPreciosPublico los datos no se actualizaban.
- **Solución:** Override de `OnActivated` que recarga la grilla cuando el formulario recupera el foco (con flag `yaInicializado` para evitar doble carga inicial).
- **Archivos:** `CapaPresentacion/frmPreciosPublico.cs`

---

## 2. Sincronización PrecioPublico → Especialidad

### 2.1 Eliminación de condición de período máximo
- **Problema:** Al guardar precios de Abril 2026, los valores no se reflejaban en la tabla `Especialidad` (y por ende en `frmLocalidadNacionalidad`).
- **Causa:** Existía una condición `periodoGuardado >= periodoMax` que comparaba el período guardado contra el máximo en la tabla `PrecioPublico`. Como existía un registro de Mayo 2026 (202605) con precios en 0, guardar Abril 2026 (202604) no sincronizaba porque `202604 < 202605`.
- **Solución:** Se eliminó la condición. Ahora **siempre** se sincronizan `precioBase` (=PrecioPromo) y `precioLista` (=PrecioLista) a la tabla `Especialidad` al guardar.
- **Archivos:** `CapaDatosMepryl/PrecioPublico.cs` → método `GuardarPreciosPublico`

---

## 3. PrecioLista en Tipo de Examen

### 3.1 Campo PrecioLista en entidad y persistencia
- **Problema:** El campo `precioLista` de la tabla `Especialidad` no se guardaba desde el formulario de Tipo de Examen (`frmLocalidadNacionalidad`).
- **Solución (multicapa):**

| Capa | Archivo | Cambio |
|------|---------|--------|
| Entidad | `Entidades/TipoExamen.cs` | Agregado campo `precioLista` con property `PrecioLista` |
| Datos | `CapaDatosMepryl/TipoExamen.cs` | `editarTipoExamen` pasa `@precioLista` al SP |
| BD | SP `sp_Especialidad_Update` | Nuevo parámetro `@precioLista decimal(18,2) = NULL` |
| Presentación | `frmLocalidadNacionalidad.cs` | `llenarDatosEntidad` y `llenarDatosEntidadPadre` parsean `tbPrecioLista.Text` |

---

## 4. Usuarios del Sistema (`frmUsuariosSistema`)

### 4.1 Fix truncamiento de campos
- **Problema:** Al guardar un usuario, algunos campos se truncaban.
- **Solución:** Correcciones en la capa de datos y presentación.
- **Archivos:** `CapaDatosMepryl/UsuarioSistema.cs`, `CapaPresentacion/frmUsuariosSistema.cs`, `frmUsuariosSistema.Designer.cs`

---

## Resumen de archivos modificados

| Archivo | Tipo de cambio |
|---------|---------------|
| `LibreriasBase/Comunes/VersionApp.cs` | Versión de la app |
| `CapaDatosMepryl/PrecioPublico.cs` | Guardado batch + sync sin condición |
| `CapaDatosMepryl/TipoExamen.cs` | Pasar precioLista al SP |
| `CapaDatosMepryl/UsuarioSistema.cs` | Fix truncamiento |
| `CapaPresentacion/frmLocalidadNacionalidad.cs` | Cargar PrecioLista en entidad |
| `CapaPresentacion/frmPreciosPublico.Designer.cs` | Botón Aplicar + ContextMenuStrip |
| `CapaPresentacion/frmPreciosPublico.cs` | Variación, factor, redondeo, OnActivated |
| `CapaPresentacion/frmUsuariosSistema.Designer.cs` | Mejoras UI |
| `CapaPresentacion/frmUsuariosSistema.cs` | Fix truncamiento |
| `CapaPresentacion/frmUsuariosSistema.resx` | Recursos |
| `Entidades/TipoExamen.cs` | Propiedad PrecioLista |

---

## Cambio en Base de Datos (manual)

El siguiente SP fue alterado directamente en la BD `MEPRYLv2.1`:

```sql
ALTER PROCEDURE sp_Especialidad_Update
    @id uniqueidentifier,
    @descripcion nvarchar(200),
    @idMotivoConsulta uniqueidentifier,
    @precioBase decimal(18,2),
    @descripcionInformes nvarchar(200),
    @precioLista decimal(18,2) = NULL   -- NUEVO
AS
    UPDATE Especialidad SET
        descripcion = @descripcion,
        idMotivoConsulta = @idMotivoConsulta,
        precioBase = @precioBase,
        descripcionInformes = @descripcionInformes,
        precioLista = ISNULL(@precioLista, precioLista)  -- NUEVO
    WHERE id = @id
```

> **Nota:** Este cambio de SP debe aplicarse en cada instancia de BD donde se despliegue.
