# Documentación de Modificación: Editar Seña de Turno

## 📋 Resumen
Se implementó la funcionalidad para editar la **seña** de un turno de forma independiente para cada paciente/turno, y que se guarde en la base de datos y se muestre correctamente en el formulario.

---

## 🗂️ Cambios Realizados

### 1. Base de Datos (SQL Server)

#### 1.1 Agregar Columna `seña` en `dbo.TipoExamenDePaciente`
```sql
ALTER TABLE dbo.TipoExamenDePaciente ADD seña DECIMAL(18, 10) NULL DEFAULT 0;
```

#### 1.2 Modificar Procedimiento `sp_TipoExamenDePaciente_Add`
```sql
ALTER PROCEDURE [dbo].[sp_TipoExamenDePaciente_Add]
    @idConsulta uniqueidentifier,
    @idTurno uniqueidentifier,
    @modificado varchar(3),
    @idEspecialidad uniqueidentifier,
    @importe decimal(18, 2),
    @factClub varchar(1),
    @precioLista decimal(18, 2),
    @seña decimal(18, 2) = 0,
    @retorno uniqueidentifier output
AS
BEGIN
    DECLARE @id uniqueidentifier;
    SET @id = NEWID();
    INSERT INTO dbo.TipoExamenDePaciente(
        id, idConsulta, idTurno, modificado, idEspecialidad, 
        precioExamen, factClub, precioLista, seña
    ) VALUES (
        @id, @idConsulta, @idTurno, @modificado, @idEspecialidad,
        @importe, @factClub, @precioLista, @seña
    );
    SET @retorno = @id
END
GO
```

#### 1.3 Modificar Procedimiento `sp_TipoExamenDePaciente_Update`
```sql
ALTER PROCEDURE [dbo].[sp_TipoExamenDePaciente_Update]
    @idTurno uniqueidentifier,
    @valor varchar(3),
    @importe decimal(18, 2),
    @factClub varchar(1),
    @precioLista decimal(18, 2),
    @seña decimal(18, 2) = 0
AS
BEGIN
    UPDATE dbo.TipoExamenDePaciente 
    SET 
        modificado = @valor,
        precioExamen = @importe,
        factClub = @factClub,
        precioLista = @precioLista,
        seña = @seña
    WHERE idTurno = @idTurno;
END
GO
```

---

### 2. Archivo: `Entidades/TipoExamen.cs`
- Agregados campos privados:
  - `seña`
  - `llevaPlanilla`
  - `observacionesExtra`
  - `usarPrecioLista`
  - `señaPromo`
  - `señaLista`
- Inicializadas variables en el constructor
- Agregados Getters & Setters para todas las nuevas propiedades

---

### 3. Archivo: `CapaDatosMepryl/Turno.cs`
- **Modificado `cargarTablaInformacionTurno`**:
  - Agregada columna `tep.seña` en el SELECT
- **Modificado `cargarTurnoPacientePreventiva`**:
  - Cargada la Seña desde `infoTurno.Rows[0][8]`
  - Asegurado que se cargue **después** de `tipoExamen.cargarEstudiosPorExamen`
- **Modificado `cargarTurnoPacienteLaboral`**:
  - Cargada la Seña desde `infoTurno.Rows[0][8]`
  - Asegurado que se cargue **después** de `tipoExamen.cargarEstudiosPorExamen`
- **Modificado `actualizarPrecioTipoExamenPorPeriodo`**:
  - Agregada carga de `Seña`, `LlevaPlanilla` y `ObservacionesExtra`
- **Modificado `generarNuevoTurnoPacientePreventiva`**:
  - Agregado parámetro `entidad.TipoExamen.Seña` al procedimiento
- **Modificado `generarNuevoTurnoPacienteLaboral`**:
  - Agregado parámetro `entidad.TipoExamen.Seña` al procedimiento
- **Modificado `modificarTurnoPreventiva`**:
  - Agregado parámetro `entidad.TipoExamen.Seña` al procedimiento
- **Modificado `modificarTurnoLaboral`**:
  - Agregado parámetro `entidad.TipoExamen.Seña` al procedimiento

---

### 4. Archivo: `CapaDatosMepryl/TipoExamen.cs`
- **Modificado `cargarEstudiosPorExamen`**:
  - Agregada columna `tep.seña` en el SELECT
  - Agregado código para cargar la Seña en la entidad desde `row["seña"]`

---

### 5. Archivos: `CapaPresentacion/frmTurnos.cs` y `frmTurnos.Designer.cs`
- **Agregados controles en el Designer**:
  - Label: `lblSeñaPreventiva`, `lblSeñaLaboral`
  - TextBox: `tbSeñaPreventiva`, `tbSeñaLaboral`
- **Modificado `pintarControlesPanelDeshabilitar`**:
  - Establece `ReadOnly = true` para los TextBox de Seña
- **Modificado `pintarControlesPanelHabilitar`**:
  - Establece `ReadOnly = false` para los TextBox de Seña
- **Modificado `cargarPanelPreventiva`**:
  - Carga la Seña en `tbSeñaPreventiva`
  - Si la Seña ya está guardada (personalizada), **NO** la sobreescribe con la configuración inicial
- **Modificado `cargarPanelLaboral`**:
  - Carga la Seña en `tbSeñaLaboral`
  - Si la Seña ya está guardada (personalizada), **NO** la sobreescribe con la configuración inicial
- **Modificado `sincronizarImportesDesdePantalla`**:
  - Lee la Seña desde los TextBox y la guarda en la entidad
- **Modificado `generarObservaciones`**:
  - Usa la Seña personalizada de la entidad
- **Agregados Eventos `TextChanged`**:
  - `tbSeñaPreventiva_TextChanged`: Actualiza las observaciones al cambiar la Seña
  - `tbSeñaLaboral_TextChanged`: Actualiza las observaciones al cambiar la Seña

---

## 🚀 Como Probar la Funcionalidad

### Paso 1: Verificar Base de Datos
Antes de probar, asegúrate de:
1. Ejecutar las consultas SQL anteriores para agregar la columna y modificar los procedimientos.

### Paso 2: Compilar y Ejecutar la Aplicación
1. Abre el proyecto en Visual Studio.
2. Compila la aplicación (debería compilar sin errores).
3. Ejecuta la aplicación.

### Paso 3: Pruebas
#### Prueba 1: Cargar un Turno con Seña Guardada
1. Busca y abre un turno que ya tenga una seña guardada en la BD.
2. Verifica que el valor se muestre correctamente en el TextBox "Seña".

#### Prueba 2: Editar la Seña
1. Haz clic en el botón "Modificar".
2. El TextBox "Seña" se habilita.
3. Cambia el valor de la Seña.
4. Haz clic en "Aceptar".
5. Vuelve a abrir el mismo turno y verifica que el valor se haya actualizado.

#### Prueba 3: Verificar Observaciones
1. Verifica que las observaciones se actualicen automáticamente al cambiar la Seña.
2. Verifica que las observaciones muestren la información completa según la configuración (`PLANILLA`, `SEÑA`, etc.).

---

## 📊 Consultas Útiles

### Verificar Valor de Seña en la BD
```sql
SELECT 
    t.codigo AS CodigoTurno,
    t.fecha AS FechaTurno,
    tep.seña AS Seña,
    tep.precioExamen AS Importe,
    tep.precioLista AS ImporteLista
FROM dbo.Turno t
LEFT JOIN dbo.TipoExamenDePaciente tep ON tep.idTurno = t.id
WHERE t.codigo = 'TU_CODIGO_AQUI';
```

### Verificar Configuración de Precios (`dbo.PrecioPublico`)
```sql
SELECT * FROM dbo.PrecioPublico
WHERE idEspecialidad = 'GUID_ESPECIALIDAD_AQUI'
AND Mes = 5 AND Anio = 2026;
```

### Verificar Turnos de un Paciente por DNI
```sql
SELECT 
    t.id AS TurnoGuid,
    t.codigo AS TurnoCodigo,
    t.nroOrden AS NumeroOrden,
    t.fecha AS FechaTurno,
    t.horaReferencia AS HoraTurno,
    t.pacienteID AS PacienteGuid,
    t.estadoID AS EstadoId,
    e.descripcion AS EstadoTurno,
    p.apellido + ' ' + p.nombres AS Profesional,
    h.especialidadID AS EspecialidadId,
    es.descripcion AS Especialidad,
    COALESCE(pac.dni, plac.dni) AS PacienteDNI,
    COALESCE(pac.apellido + ' ' + pac.nombres, plac.apellido + ' ' + plac.nombres) AS PacienteNombre,
    COALESCE(pac.fechaNacimiento, plac.fechaNacimiento) AS PacienteFechaNac,
    COALESCE(pac.telefonos, plac.telefonos) AS PacienteTelefonos,
    COALESCE(pac.celular, plac.celular) AS PacienteCelular,
    COALESCE(pac.Email, plac.mail) AS PacienteEmail
FROM dbo.Turno t
INNER JOIN dbo.TurnoEstado e ON t.estadoID = e.id
INNER JOIN dbo.Horario h ON t.horarioID = h.id
INNER JOIN dbo.Profesional p ON h.profesionalID = p.id
LEFT JOIN dbo.Especialidad es ON h.especialidadID = es.id
LEFT JOIN dbo.Paciente pac ON t.pacienteID = pac.id
LEFT JOIN dbo.PacienteLaboral plac ON t.pacienteID = plac.id
WHERE COALESCE(pac.dni, plac.dni) = 'DNI_AQUI'
ORDER BY t.fecha DESC, t.horaReferencia DESC;
```

---

## ⚠️ Notas Importantes
- El valor de la seña se guarda **específicamente** para cada turno-paciente.
- Si la seña no está guardada (es 0 o NULL), se usa la configuración por defecto de `dbo.PrecioPublico`.
- Las observaciones se actualizan automáticamente al cambiar el valor en el TextBox "Seña".
- Se eliminaron los checkbox que no se usaban (`cbFactClubPreventiva`, `cbExamenModifPreventiva`, `cbFactEmpresaLaboral`, `cbExamenModificadoLaboral`).

---

## ✅ Funcionalidades Confirmadas
1. ✅ Carga de seña desde la base de datos al abrir un turno.
2. ✅ Edición de la seña en modo "Modificar".
3. ✅ Guardado de la seña en la base de datos.
4. ✅ Actualización automática de observaciones al cambiar la seña.
5. ✅ No sobreescritura de la seña personalizada al recargar un turno.
6. ✅ Observaciones completas con PLANILLA, SEÑA y valor final.
