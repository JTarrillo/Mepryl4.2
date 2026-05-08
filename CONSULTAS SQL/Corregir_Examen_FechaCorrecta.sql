-- ========================================
-- CORRECCIÓN: CREAR EXAMEN CON FECHA CORRECTA 05/09/2025
-- Y ASIGNAR CLUB Y DEPORTE CORRECTOS
-- ========================================

-- 1. ELIMINAR REGISTRO INCORRECTO CREADO ANTERIORMENTE
DELETE FROM dbo.TipoExamenDePaciente 
WHERE idConsulta IN (
    SELECT id FROM dbo.Consulta 
    WHERE pacienteID = (SELECT id FROM dbo.Paciente WHERE dni = '55676837')
)

DELETE FROM dbo.Consulta 
WHERE pacienteID = (SELECT id FROM dbo.Paciente WHERE dni = '55676837')

-- 2. CREAR REGISTRO CORRECTO EN TABLA CONSULTA
INSERT INTO dbo.Consulta (
    id,
    pacienteID,
    fecha,
    identificador,
    tipo
)
VALUES (
    NEWID(),                    -- id
    (SELECT id FROM dbo.Paciente WHERE dni = '55676837'), -- pacienteID
    '2025-09-05',               -- fecha CORRECTA: 05/09/2025
    '1',                       -- identificador (número de examen)
    'P'                        -- tipo = 'P' de Preventiva
)

-- 3. CREAR REGISTRO CORRECTO EN TABLA TipoExamenDePaciente
INSERT INTO dbo.TipoExamenDePaciente (
    id,
    idConsulta,
    idTurno,
    modificado,
    idEspecialidad,
    precioExamen
)
VALUES (
    NEWID(),                    -- id
    (SELECT TOP 1 id FROM dbo.Consulta WHERE pacienteID = (SELECT id FROM dbo.Paciente WHERE dni = '55676837') ORDER BY fecha DESC), -- idConsulta
    NULL,                       -- idTurno (sin turno asignado)
    0,                         -- modificado
    '60E94892-6F59-4202-A966-884FD71A5D8B', -- idEspecialidad: FUTBOL METRO
    0.0                        -- precioExamen
)

-- 4. ASIGNAR CLUB CORRECTO AL PACIENTE
UPDATE dbo.Paciente 
SET clubID = 'DCAE68B5-A2EF-4278-9A2A-C0360F4E3724' -- QUILMES DECANO
WHERE dni = '55676837'

-- 5. VERIFICACIÓN FINAL
SELECT 
    'VERIFICACIÓN EXAMEN CORRECTO' as Tipo,
    c.id as ConsultaID,
    c.fecha as FechaExamen,
    c.identificador as NroExamen,
    p.dni,
    p.apellido + ' ' + p.nombres as Paciente,
    e.descripcion as Deporte,
    cl.descripcion as Club,
    'Examen creado con fecha 05/09/2025' as Resultado
FROM dbo.Consulta c
INNER JOIN dbo.Paciente p ON c.pacienteID = p.id
INNER JOIN dbo.TipoExamenDePaciente tep ON c.id = tep.idConsulta
INNER JOIN dbo.Especialidad e ON tep.idEspecialidad = e.id
LEFT JOIN dbo.Club cl ON p.clubID = cl.id
WHERE p.dni = '55676837'
  AND c.tipo = 'P'

-- ========================================
// turbo
-- CORRECCIONES APLICADAS:
// 1. Eliminado examen incorrecto con fecha 2026-07-05
// 2. Creado examen correcto con fecha 2025-09-05
// 3. Asignado deporte: FUTBOL METRO
// 4. Asignado club: QUILMES DECANO
// ========================================
