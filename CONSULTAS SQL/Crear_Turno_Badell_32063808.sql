-- ============================================================
-- CREAR TURNO: Paciente BADELL FACUNDO (DNI 32063808)
-- Fecha: 23/06/2026
-- Número de examen: 11
-- Subtipo: Estudios Complementarios (EC)
-- ============================================================

-- PASO 1: Obtener id del paciente
SELECT id AS idPaciente, dni, apellido, nombres
FROM dbo.PacienteLaboral
WHERE dni = '32063808'

-- PASO 2: Obtener id de la especialidad "Estudios Complementarios" con código 11
SELECT id, codigo, descripcion, idMotivoConsulta
FROM dbo.Especialidad
WHERE codigo = '11'
  AND estado = 1

-- PASO 3: Obtener id del horario para la fecha 23/06/2026
-- (Ajustar según el horario disponible)
SELECT id, fecha, hora
FROM dbo.Horario
WHERE CAST(fecha AS DATE) = '20260623'
ORDER BY hora

-- PASO 4: Insertar el turno (REEMPLAZAR LOS GUIDS con los valores obtenidos)
-- Ejemplo de INSERT directo en tabla Turno:
INSERT INTO dbo.Turno (
    id,
    fecha,
    hora,
    horaReferencia,
    idEspecialidad,
    idPaciente,
    codigo,
    nroOrden,
    recepcion,
    mesaDeEntrada,
    asistio,
    abono,
    reserva,
    reservado,
    bloqueado,
    habilitado,
    estadoID,
    observaciones,
    consulta
)
VALUES (
    NEWID(),  -- id del turno (se genera automáticamente)
    '2026-06-23 00:00:00',  -- fecha
    '09:00',  -- hora (AJUSTAR según horario disponible)
    '09:00',  -- horaReferencia
    'ID_ESPECIALIDAD_DEL_PASO_2',  -- idEspecialidad (reemplazar)
    'ID_PACIENTE_DEL_PASO_1',  -- idPaciente (reemplazar)
    '11',  -- código del examen
    11,  -- nroOrden
    '0',  -- recepcion (0 = pendiente)
    '0',  -- mesaDeEntrada (0 = pendiente)
    '0',  -- asistio
    '0',  -- abono
    '0',  -- reserva
    '0',  -- reservado
    '0',  -- bloqueado
    '1',  -- habilitado
    'ID_ESTADO_PENDIENTE',  -- estadoID (reemplazar con el id del estado pendiente)
    '',  -- observaciones
    ''   -- consulta
)

-- PASO 5: Verificar que el turno se creó correctamente
SELECT 
    t.id AS idTurno,
    t.fecha,
    t.hora,
    t.codigo,
    t.nroOrden,
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
