-- ============================================================
-- CREAR TipoExamenDePaciente FALTANTE
-- DNI: 32063808
-- Consulta ID: 1123E53F-6C9F-4BA9-BFCB-96C6B5D90CD9
-- ============================================================

-- PASO 1: Obtener id de la especialidad "Estudios Complementarios" (código 11)
SELECT id, codigo, descripcion
FROM dbo.Especialidad
WHERE codigo = '11'

-- PASO 2: Crear TipoExamenDePaciente
-- REEMPLAZAR 'ID_ESPECIALIDAD_AQUI' con el id del PASO 1
INSERT INTO dbo.TipoExamenDePaciente (id, idConsulta, idTurno, idEspecialidad, importe, factClub)
VALUES (
    NEWID(),
    '1123E53F-6C9F-4BA9-BFCB-96Ca6B5D90CD9',
    '9A582C92-A6EF-4A94-9A6E-C6B3DBD15AD0',
    'ID_ESPECIALIDAD_AQUI',  -- REEMPLAZAR ESTO
    0,
    '0'
)

-- PASO 3: Verificar que se creó correctamente
SELECT
    te.id AS idTipoExamenDePaciente,
    te.idConsulta,
    te.idTurno,
    te.idEspecialidad,
    e.descripcion AS especialidad,
    e.codigo
FROM dbo.TipoExamenDePaciente te
INNER JOIN dbo.Especialidad e ON te.idEspecialidad = e.id
WHERE te.idConsulta = '1123E53F-6C9F-4BA9-BFCB-96C6B5D90CD9'
