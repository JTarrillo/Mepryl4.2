-- ============================================================
-- INVESTIGACION: Turno desaparecido del paciente BADELL FACUNDO
-- DNI: 32063808
-- Fecha: 23/06/2026
-- ============================================================

-- PASO 1: Buscar turnos del paciente para el día 23/06/2026
SELECT 
    t.id AS idTurno,
    t.fecha AS fechaTurno,
    t.hora AS horaTurno,
    t.mesaDeEntrada,
    t.recepcion,
    t.asistio,
    t.abono,
    t.observaciones,
    e.descripcion AS especialidad,
    pl.dni,
    pl.apellido + ' ' + pl.nombres AS paciente
FROM dbo.Turno t
INNER JOIN dbo.Especialidad e ON t.idEspecialidad = e.id
INNER JOIN dbo.PacienteLaboral pl ON t.idPaciente = pl.id
WHERE pl.dni = '32063808'
  AND CAST(t.fecha AS DATE) = '20260623'
ORDER BY t.hora

-- PASO 2: Verificar si existe consulta asociada al turno (por Consulta)
SELECT 
    c.id AS idConsulta,
    c.fecha AS fechaConsulta,
    CONVERT(varchar(5), c.fecha, 108) AS [Hora],
    c.identificador,
    c.nroOrden,
    c.tipo,
    c.valido,
    te.id AS idTipoExamenDePaciente,
    te.idTurno,
    e.descripcion AS especialidad
FROM dbo.Consulta c
INNER JOIN dbo.TipoExamenDePaciente te ON c.id = te.idConsulta
INNER JOIN dbo.Turno t ON te.idTurno = t.id
INNER JOIN dbo.PacienteLaboral pl ON c.pacienteID = pl.id
INNER JOIN dbo.Especialidad e ON te.idEspecialidad = e.id
WHERE pl.dni = '32063808'
  AND CAST(c.fecha AS DATE) = '20260623'

-- PASO 3: Verificar si existe consulta SIN turno asociado (caso raro)
SELECT 
    c.id AS idConsulta,
    c.fecha AS fechaConsulta,
    c.identificador,
    c.nroOrden,
    c.tipo,
    c.valido,
    te.id AS idTipoExamenDePaciente,
    te.idTurno,
    pl.dni,
    pl.apellido + ' ' + pl.nombres AS paciente
FROM dbo.Consulta c
INNER JOIN dbo.TipoExamenDePaciente te ON c.id = te.idConsulta
INNER JOIN dbo.PacienteLaboral pl ON c.pacienteID = pl.id
LEFT JOIN dbo.Turno t ON te.idTurno = t.id
WHERE pl.dni = '32063808'
  AND CAST(c.fecha AS DATE) = '20260623'
  AND t.id IS NULL  -- Consulta sin turno asociado

-- PASO 4: Si el turno tiene mesaDeEntrada=1 pero no tiene consulta,
-- el turno está "perdido". Ejecutar este UPDATE para recuperarlo:
-- UPDATE dbo.Turno 
-- SET mesaDeEntrada = 0 
-- WHERE id = 'ID_DEL_TURNO'  -- Reemplazar con el id del PASO 1

-- PASO 5: Verificar estado del turno después del fix
SELECT 
    t.id AS idTurno,
    t.fecha AS fechaTurno,
    t.hora AS horaTurno,
    t.mesaDeEntrada,
    t.recepcion,
    e.descripcion AS especialidad,
    pl.dni,
    pl.apellido + ' ' + pl.nombres AS paciente
FROM dbo.Turno t
INNER JOIN dbo.Especialidad e ON t.idEspecialidad = e.id
INNER JOIN dbo.PacienteLaboral pl ON t.idPaciente = pl.id
WHERE pl.dni = '32063808'
  AND CAST(t.fecha AS DATE) = '20260623'
