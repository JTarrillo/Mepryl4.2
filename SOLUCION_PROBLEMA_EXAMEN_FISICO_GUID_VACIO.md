# Solución: Problema frmExamenFisico - Guid Vacío al Guardar

## Fecha
14/07/2026

## Problema Reportado
El formulario `frmExamenFisico` no guardaba correctamente el examen físico del paciente BOXEO (DNI: 95365920, FERNANDEZ TORRES ROBERTO ANTONIO) del 13/07/2026.

## Síntomas
- Al intentar guardar el examen físico, el `IdTipoExamen` quedaba como `00000000-0000-0000-0000-000000000000`
- El stored procedure `sp_ExamenPreventiva_UpdateClinico` no podía actualizar el registro porque el GUID era nulo

## Investigación

### 1. Logs de Debug Agregados
Se agregaron logs en `frmExamenFisico.cs` para rastrear el flujo:

**En `cargarDatos()`:**
```csharp
System.Diagnostics.Debug.WriteLine("examen.Cells[0].Value: [" + examen.Cells[0].Value + "]");
System.Diagnostics.Debug.WriteLine("entidad.IdTipoExamen despues de cargar: " + entidad.IdTipoExamen);
```

**En `guardar()`:**
```csharp
System.Diagnostics.Debug.WriteLine("tbId.Text: [" + tbId.Text + "]");
System.Diagnostics.Debug.WriteLine("Guid parseado: " + examen.IdTipoExamen);
```

### 2. Resultado de los Logs
```
examen.Cells[0].Value: [21044751-76f5-4a55-bd8a-4a3a1b490b60]
entidad.IdTipoExamen despues de cargar: 00000000-0000-0000-0000-000000000000
```

**Análisis:**
- El formulario recibía correctamente el ID de `TipoExamenDePaciente`: `21044751-76f5-4a55-bd8a-4a3a1b490b60`
- Pero el método `preventiva.cargarExamen()` devolvía una entidad con `IdTipoExamen` vacío

### 3. Verificación en Base de Datos

#### Consulta 1: Verificar TipoExamenDePaciente
```sql
SELECT id, idConsulta, idTurno, idEspecialidad 
FROM dbo.TipoExamenDePaciente 
WHERE idTurno = '2F1CFB11-6986-4E9E-85C8-70B32D073D97'
```

**Resultado:**
- `idTipoExamen = 21044751-76F5-4A55-BD8A-4A3A1B490B60`
- `idConsulta = FA7CC28A-175D-4C06-9A22-D103F65E8C05` (ya reparado previamente)
- `idTurno = 2F1CFB11-6986-4E9E-85C8-70B32D073D97`

#### Consulta 2: Verificar ExamenPreventiva
```sql
SELECT id, idTipoExamen 
FROM dbo.ExamenPreventiva 
WHERE idTipoExamen = '21044751-76F5-4A55-BD8A-4A3A1B490B60'
```

**Resultado:**
- `0 rows affected` - **No existía el registro**

## Causa Raíz
El método `cargarExamen()` en `Preventiva.cs` busca en la tabla `ExamenPreventiva`:
```csharp
DataTable examen = SQLConnector.obtenerTablaSegunConsultaString(
    "select * from dbo.ExamenPreventiva where idTipoExamen = '" + idTipoExamen + "'");
```

Como no existía el registro en `ExamenPreventiva`, devolvía una entidad vacía con `IdTipoExamen = Guid.Empty`.

## Solución Aplicada

### Consulta de Reparación
Se ejecutó el stored procedure `sp_ExamenPreventiva_InsertRapido` para crear el registro faltante:

```sql
EXEC sp_ExamenPreventiva_InsertRapido @idTipoExamen = '21044751-76F5-4A55-BD8A-4A3A1B490B60'
```

**Resultado:**
- `1 rows affected`
- Se creó el registro con `id = 101364`

### Verificación Post-Reparación
```sql
SELECT id, idTipoExamen 
FROM dbo.ExamenPreventiva 
WHERE idTipoExamen = '21044751-76F5-4A55-BD8A-4A3A1B490B60'
```

**Resultado:**
```
id,idTipoExamen
101364,21044751-76F5-4A55-BD8A-4A3A1B490B60
```

## Archivos Modificados

### frmExamenFisico.cs
- Agregados logs de debug en `cargarDatos()` (líneas 97-102)
- Agregados logs de debug en `guardarExamen()` (líneas 490-514)
- Agregados logs de debug en `guardar()` (líneas 643-686)
- Agregados logs de debug en `cargarEntidad()` (líneas 715-719)

**Nota:** Los logs de debug pueden mantenerse para futuras investigaciones o removerse si no son necesarios.

## Conclusión
El problema se resolvió creando el registro faltante en la tabla `ExamenPreventiva` mediante el stored procedure `sp_ExamenPreventiva_InsertRapido`. Ahora el formulario `frmExamenFisico` puede cargar y guardar correctamente el examen físico del paciente.

## Datos del Caso
- **Fecha:** 13/07/2026
- **Nro Orden:** 12
- **Identificador:** 200
- **DNI:** 95365920
- **Paciente:** FERNANDEZ TORRES ROBERTO ANTONIO
- **Motivo:** PREVENTIVA
- **Especialidad:** BOXEO
- **idTipoExamen:** 21044751-76F5-4A55-BD8A-4A3A1B490B60
- **idConsulta:** FA7CC28A-175D-4C06-9A22-D103F65E8C05
- **idTurno:** 2F1CFB11-6986-4E9E-85C8-70B32D073D97
