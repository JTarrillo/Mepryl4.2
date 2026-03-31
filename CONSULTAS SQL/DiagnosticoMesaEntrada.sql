-- ============================================================
-- DIAGNOSTICO MESA DE ENTRADA - Paciente bloqueado / no aparece
-- ============================================================

-- 1. VERIFICAR ESTADO DE UN PACIENTE EN CONSULTA HOY
--    Usar cuando sale "El paciente ya se encuentra ingresado"
--    o cuando el paciente no aparece en la grilla de Mesa de Entradas.
SELECT 
    c.id,
    c.nroOrden,
    c.identificador,
    c.tipo,
    c.valido,
    c.fecha,
    COALESCE(p.dni, pl.dni) AS dni,
    COALESCE(p.apellido, pl.apellido) AS apellido,
    COALESCE(p.nombres, pl.nombres) AS nombres
FROM dbo.Consulta c
LEFT JOIN dbo.Paciente p ON p.id = c.pacienteID
LEFT JOIN dbo.PacienteLaboral pl ON pl.id = c.pacienteID
WHERE CONVERT(DATE, c.fecha) = CONVERT(DATE, GETDATE())
  AND COALESCE(p.dni, pl.dni) = '27061058'  -- <-- cambiar por el DNI del paciente


-- 2. VERIFICAR SI LA CONSULTA TIENE TipoExamenDePaciente ASOCIADO
--    Si idTE sale NULL, el paciente no va a aparecer en la grilla
--    (la query de cargarMesaEntrada usa INNER JOIN con TipoExamenDePaciente)
SELECT 
    c.id AS idConsulta,
    c.nroOrden,
    c.identificador,
    c.valido,
    te.id AS idTE,
    te.idConsulta,
    te.idTurno
FROM dbo.Consulta c
LEFT JOIN dbo.TipoExamenDePaciente te ON te.idConsulta = c.id
WHERE c.id = '00000000-0000-0000-0000-000000000000'  -- <-- reemplazar con el id de la Consulta


-- 3. VERIFICAR TURNOS DEL PACIENTE HOY
--    Muestra todos los turnos del paciente en el dia, con estado mesaDeEntrada
SELECT 
    t.id,
    CONVERT(DATE, t.fecha) AS fecha,
    t.hora,
    t.mesaDeEntrada,
    t.recepcion,
    e.descripcion AS tipoExamen
FROM dbo.Turno t
INNER JOIN dbo.TipoExamenDePaciente tep ON tep.idTurno = t.id
INNER JOIN dbo.Especialidad e ON tep.idEspecialidad = e.id
INNER JOIN dbo.Paciente p ON p.id = t.pacienteID
WHERE p.dni = '27061058'  -- <-- cambiar por el DNI del paciente
  AND CONVERT(DATE, t.fecha) = CONVERT(DATE, GETDATE())


-- 4. VERIFICAR SI EL NUMERO DE ORDEN YA EXISTE HOY
--    Antes de hacer un UPDATE de nroOrden, verificar que no este ocupado
SELECT id, nroOrden, identificador, pacienteID
FROM dbo.Consulta
WHERE CONVERT(DATE, fecha) = CONVERT(DATE, GETDATE())
  AND nroOrden = 97  -- <-- cambiar por el numero a verificar


-- ============================================================
-- CORRECCIONES
-- ============================================================

-- 5. CORREGIR nroOrden e identificador (numero de examen)
--    Usar cuando el paciente tiene nroOrden o identificador incorrecto
--    SIEMPRE verificar primero con la query 4 que el nroOrden destino no exista
UPDATE dbo.Consulta
SET nroOrden      = 97,   -- <-- nuevo numero de orden
    identificador = '287' -- <-- nuevo numero de examen
WHERE id = '00000000-0000-0000-0000-000000000000'  -- <-- id exacto de la Consulta


-- 6. RECUPERAR TURNO BLOQUEADO SIN CONSULTA ASOCIADA
--    Usar cuando el turno quedo con mesaDeEntrada=1 pero sin consulta generada
--    (el paciente recibio el mensaje de error y el turno desaparecio de la lista)
UPDATE dbo.Turno
SET mesaDeEntrada = 0
WHERE id = '00000000-0000-0000-0000-000000000000'  -- <-- id del turno afectado


-- 7. VINCULAR TipoExamenDePaciente CON LA CONSULTA
--    Usar cuando la query 2 devuelve idTE = NULL
UPDATE dbo.TipoExamenDePaciente
SET idConsulta = '00000000-0000-0000-0000-000000000000'  -- <-- id de la Consulta
WHERE idTurno  = '00000000-0000-0000-0000-000000000000'  -- <-- id del Turno correspondiente
