# Investigacion del caso 13-07-2026

## Objetivo

Documentar que se reviso en base de datos para entender por que:

- desaparecio el paciente con `Nro de Orden 12`
- en Mesa de Entradas se veia el salto del `12` al `15`

Caso reportado:

- Motivo: `PREVENTIVA`
- Tipo / subtipo: `BOXEO`
- DNI: `95365920`
- Paciente: `FERNANDEZ TORRES ROBERTO ANTONIO`
- Fecha: `13/07/2026`

## Conexion usada

Se uso `sqlcmd` por linea de comandos, tomando como referencia el archivo:

- `c:\Mepryl4.2\SOLUCION 4.2\Instrucciones_Conexion_y_Tabla_PrecioPublico.md`

Observacion:

- el usuario pudo conectarse al servidor
- la base accesible con ese login fue `MEPRYLv2.1`
- la base `3dejunio` no estaba disponible para ese login

## Consultas realizadas

## 1. Verificacion del paciente

Consulta ejecutada:

```sql
SELECT id, dni, apellido, nombres, fechaNacimiento
FROM dbo.Paciente
WHERE dni = '95365920';
```

Resultado:

- el paciente existe en `dbo.Paciente`
- `idPaciente = FAF6B0D3-919F-45D0-98B3-D39E371A7840`

## 2. Verificacion de la consulta del paciente el 13-07-2026

Consulta ejecutada:

```sql
SELECT
    c.id,
    CONVERT(varchar(19), c.fecha, 120) AS fecha,
    c.nroOrden,
    c.identificador,
    c.tipo,
    c.valido,
    c.pacienteID,
    tep.id AS idTipoExamen,
    tep.idTurno,
    tep.idEspecialidad,
    e.descripcion AS especialidad,
    mc.nombre AS motivo,
    tep.modificado
FROM dbo.Consulta c
LEFT JOIN dbo.TipoExamenDePaciente tep ON tep.idConsulta = c.id
LEFT JOIN dbo.Especialidad e ON tep.idEspecialidad = e.id
LEFT JOIN dbo.MotivoDeConsulta mc ON e.idMotivoConsulta = mc.id
WHERE CONVERT(varchar(8), c.fecha, 112) = '20260713'
  AND c.pacienteID = 'FAF6B0D3-919F-45D0-98B3-D39E371A7840';
```

Resultado:

- la `Consulta` del paciente si existia
- `idConsulta = FA7CC28A-175D-4C06-9A22-D103F65E8C05`
- `nroOrden = 12`
- `identificador = 200`
- `tipo = P`
- `valido = 1`
- pero no aparecia un `TipoExamenDePaciente` unido por `idConsulta`

## 3. Revision de la secuencia de ordenes del dia

Consulta ejecutada:

```sql
SELECT
    c.id,
    CONVERT(varchar(19), c.fecha, 120) AS fecha,
    c.nroOrden,
    c.identificador,
    c.tipo,
    c.valido,
    COALESCE(p.dni, pl.dni) AS dni,
    COALESCE(p.apellido, pl.apellido) AS apellido,
    COALESCE(p.nombres, pl.nombres) AS nombres,
    e.descripcion AS especialidad,
    mc.nombre AS motivo
FROM dbo.Consulta c
LEFT JOIN dbo.TipoExamenDePaciente tep ON tep.idConsulta = c.id
LEFT JOIN dbo.Especialidad e ON tep.idEspecialidad = e.id
LEFT JOIN dbo.MotivoDeConsulta mc ON e.idMotivoConsulta = mc.id
LEFT JOIN dbo.Paciente p ON p.id = c.pacienteID
LEFT JOIN dbo.PacienteLaboral pl ON pl.id = c.pacienteID
WHERE CONVERT(varchar(8), c.fecha, 112) = '20260713'
  AND ISNUMERIC(c.nroOrden) = 1
  AND CONVERT(int, c.nroOrden) BETWEEN 10 AND 15
ORDER BY CONVERT(int, c.nroOrden), c.fecha;
```

Resultado relevante:

- `10` correcto
- `11` correcto
- `12` existia pero salia con `especialidad = NULL` y `motivo = NULL`
- `13` correcto
- `14` existia pero tambien sin examen asociado
- `15` existia con examen asociado

Conclusión:

- los `Nro de Orden 12` y `14` existian en `Consulta`
- el problema era de vinculacion con `TipoExamenDePaciente`
- por eso las pantallas que hacen `INNER JOIN` con `TipoExamenDePaciente` no los mostraban

## 4. Deteccion de consultas huerfanas

Consulta ejecutada:

```sql
SELECT
    c.id,
    CONVERT(varchar(19), c.fecha, 120) AS fecha,
    c.nroOrden,
    c.identificador,
    c.tipo,
    c.valido,
    c.pacienteID,
    COALESCE(p.dni, pl.dni) AS dni,
    COALESCE(p.apellido, pl.apellido) AS apellido,
    COALESCE(p.nombres, pl.nombres) AS nombres
FROM dbo.Consulta c
LEFT JOIN dbo.TipoExamenDePaciente tep ON tep.idConsulta = c.id
LEFT JOIN dbo.Paciente p ON p.id = c.pacienteID
LEFT JOIN dbo.PacienteLaboral pl ON pl.id = c.pacienteID
WHERE CONVERT(varchar(8), c.fecha, 112) = '20260713'
  AND tep.id IS NULL
  AND c.valido = 1
  AND c.tipo <> 'V'
ORDER BY
    CASE WHEN ISNUMERIC(c.nroOrden) = 1 THEN CONVERT(int, c.nroOrden) ELSE 999999 END,
    c.fecha;
```

Resultado:

- `Nro 12`: consulta huerfana para el paciente de BOXEO
- `Nro 14`: consulta huerfana para un estudio complementario (`EC1`)

## 5. Verificacion del turno del paciente BOXEO

Consulta ejecutada:

```sql
SELECT
    t.id,
    CONVERT(varchar(19), t.fecha, 120) AS fecha,
    t.hora,
    t.horaReferencia,
    t.nroOrden,
    t.pacienteID,
    t.recepcion,
    t.habilitado,
    h.especialidadID,
    e.descripcion AS especialidad,
    mc.nombre AS motivo
FROM dbo.Turno t
LEFT JOIN dbo.Horario h ON t.horarioID = h.id
LEFT JOIN dbo.Especialidad e ON h.especialidadID = e.id
LEFT JOIN dbo.MotivoDeConsulta mc ON e.idMotivoConsulta = mc.id
WHERE CONVERT(varchar(8), t.fecha, 112) = '20260713'
  AND t.pacienteID = 'FAF6B0D3-919F-45D0-98B3-D39E371A7840';
```

Resultado:

- `idTurno = 2F1CFB11-6986-4E9E-85C8-70B32D073D97`
- especialidad `BOXEO`
- motivo `PREVENTIVA`
- recepcion `1`

## 6. Verificacion del TipoExamenDePaciente del BOXEO

Consulta ejecutada:

```sql
SELECT
    tep.id,
    tep.idConsulta,
    tep.idTurno,
    tep.idEspecialidad,
    tep.precioExamen,
    tep.precioLista,
    tep.seña,
    tep.modificado
FROM dbo.TipoExamenDePaciente tep
WHERE tep.idTurno = '2F1CFB11-6986-4E9E-85C8-70B32D073D97'
   OR tep.idConsulta = 'FA7CC28A-175D-4C06-9A22-D103F65E8C05';
```

Resultado:

- existia el `TipoExamenDePaciente`
- `idTipoExamen = 21044751-76F5-4A55-BD8A-4A3A1B490B60`
- estaba unido al `idTurno`
- pero tenia `idConsulta = 00000000-0000-0000-0000-000000000000`

Esta fue la causa puntual de que el paciente no apareciera en:

- Historico de Mesa de Entradas
- Examenes Preventiva

porque ambas pantallas trabajan por `tep.idConsulta = c.id`

## Reparacion aplicada

Se ejecuto una unica actualizacion correctiva sobre el caso BOXEO:

```sql
UPDATE dbo.TipoExamenDePaciente
SET idConsulta = 'FA7CC28A-175D-4C06-9A22-D103F65E8C05'
WHERE id = '21044751-76F5-4A55-BD8A-4A3A1B490B60'
  AND idTurno = '2F1CFB11-6986-4E9E-85C8-70B32D073D97'
  AND (idConsulta IS NULL OR idConsulta = '00000000-0000-0000-0000-000000000000');
```

Verificacion posterior:

- se actualizo `1` fila
- el `TipoExamenDePaciente` quedo vinculado correctamente al `idConsulta` del `Nro 12`

## Hallazgo tecnico en codigo

Ademas de la reparacion en base, se corrigio el flujo de ingreso en `frmMesaDeEntrada.cs` para evitar nuevos casos:

- ahora se vincula explicitamente el `TipoExamenDePaciente` del turno con la nueva `Consulta`
- si el alta falla, se revierte el ingreso en vez de dejar una `Consulta` huerfana

## Pendiente

Todavia queda pendiente revisar o reparar el otro caso detectado del mismo dia:

- `Nro de Orden 14`
- `identificador = EC1`
- paciente `49757377`

Ese caso explica por que el ultimo visible aparecia como `15`.
