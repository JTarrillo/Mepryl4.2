-- ============================================================
-- VER ESTRUCTURA DE TABLAS
-- ============================================================

-- Estructura de tabla Consulta
SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    CHARACTER_MAXIMUM_LENGTH,
    IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Consulta'
ORDER BY ORDINAL_POSITION

-- Estructura de tabla PacienteLaboral
SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    CHARACTER_MAXIMUM_LENGTH,
    IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'PacienteLaboral'
ORDER BY ORDINAL_POSITION

-- Estructura de tabla Turno
SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    CHARACTER_MAXIMUM_LENGTH,
    IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Turno'
ORDER BY ORDINAL_POSITION
