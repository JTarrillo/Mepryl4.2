-- ========================================
-- SOLUCIÓN: CREAR REGISTRO DE EXAMEN PARA EL PACIENTE
-- Para que aparezca en "Exámenes Preventiva"
-- ========================================

-- 1. VERIFICAR PACIENTE CREADO
SELECT 
    'PACIENTE VERIFICADO' as Tipo,
    p.id,
    p.dni,
    p.apellido + ' ' + p.nombres as NombreCompleto
FROM dbo.Paciente p
WHERE p.dni = '55676837'

-- 2. CREAR REGISTRO EN TABLA CONSULTA
-- Descomenta y ejecuta esta línea
-- INSERT INTO dbo.Consulta (
--     id,
--     pacienteID,
--     fecha,
--     identificador,
--     tipo
-- )
-- VALUES (
--     NEWID(),                    -- id
--     (SELECT id FROM dbo.Paciente WHERE dni = '55676837'), -- pacienteID
--     '2026-05-07',               -- fecha (hoy)
--     '1',                       -- identificador (número de examen)
--     'P'                        -- tipo = 'P' de Preventiva
-- )

-- 3. CREAR REGISTRO EN TABLA TipoExamenDePaciente
-- Descomenta y ejecuta esta línea
-- INSERT INTO dbo.TipoExamenDePaciente (
--     id,
--     idConsulta,
--     idTurno,
--     modificado,
--     idEspecialidad,
--     precioExamen
-- )
-- VALUES (
--     NEWID(),                    -- id
--     (SELECT TOP 1 id FROM dbo.Consulta WHERE pacienteID = (SELECT id FROM dbo.Paciente WHERE dni = '55676837') ORDER BY fecha DESC), -- idConsulta
--     NULL,                       -- idTurno (sin turno asignado)
--     0,                         -- modificado
--     (SELECT TOP 1 id FROM dbo.Especialidad WHERE descripcion LIKE '%PREVENTIVA%' ORDER BY codigo), -- idEspecialidad
--     0.0                        -- precioExamen
-- )

-- 4. VERIFICAR QUE APARECERÁ EN BÚSQUEDA
SELECT 
    'VERIFICACIÓN FINAL' as Tipo,
    c.id as ConsultaID,
    c.fecha,
    c.identificador as NroExamen,
    p.dni,
    p.apellido + ' ' + p.nombres as Paciente,
    'Ahora aparecerá en Exámenes Preventiva' as Resultado
FROM dbo.Consulta c
INNER JOIN dbo.Paciente p ON c.pacienteID = p.id
WHERE p.dni = '55676837'
  AND c.tipo = 'P'

-- ========================================
// turbo
-- EXPLICACIÓN:
// 1. La pantalla "Exámenes Preventiva" busca en tabla Consulta
// 2. Necesita un registro en Consulta con tipo='P'
// 3. Necesita un registro en TipoExamenDePaciente vinculado
// 4. Después de crear estos registros, aparecerá en la búsqueda
-- ========================================
