-- ========================================
-- ANÁLISIS DE LA ESTRUCTURA DE LA TABLA PACIENTE
-- ========================================

-- 1. VERIFICAR ESTRUCTURA COMPLETA DE LA TABLA PACIENTE
SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    IS_NULLABLE,
    CHARACTER_MAXIMUM_LENGTH,
    COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Paciente' 
  AND TABLE_SCHEMA = 'dbo'
ORDER BY ORDINAL_POSITION

-- 2. VERIFICAR EL CAMPO HABILITADO ESPECÍFICAMENTE
SELECT 
    COLUMN_NAME,
    DATA_TYPE,
    IS_NULLABLE,
    CHARACTER_MAXIMUM_LENGTH,
    COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Paciente' 
  AND TABLE_SCHEMA = 'dbo'
  AND COLUMN_NAME = 'habilitado'

-- 3. VERIFICAR VALORES POSIBLES DEL CAMPO HABILITADO
SELECT DISTINCT 
    habilitado,
    COUNT(*) as Cantidad,
    CASE 
        WHEN habilitado = 1 THEN 'Activo'
        WHEN habilitado = 0 THEN 'Inactivo'
        WHEN habilitado = 'true' THEN 'Activo (texto)'
        WHEN habilitado = 'false' THEN 'Inactivo (texto)'
        ELSE 'Otro valor: ' + CAST(habilitado AS VARCHAR)
    END as Descripcion
FROM dbo.Paciente 
GROUP BY habilitado
ORDER BY habilitado

-- 4. VERIFICAR REGISTRO ESPECÍFICO DEL DNI 55676837
SELECT 
    id,
    dni,
    apellido,
    nombres,
    habilitado,
    CASE 
        WHEN habilitado = 1 THEN 'Activo'
        WHEN habilitado = 0 THEN 'Inactivo'
        WHEN habilitado = 'true' THEN 'Activo (texto)'
        WHEN habilitado = 'false' THEN 'Inactivo (texto)'
        ELSE 'Otro valor: ' + CAST(habilitado AS VARCHAR)
    END as EstadoActual
FROM dbo.Paciente 
WHERE dni = '55676837'

-- 5. VERIFICAR TIPO DE DATO CON CAST
SELECT 
    'Tipo de dato del campo habilitado' as Informacion,
    SQL_VARIANT_PROPERTY(habilitado, 'BaseType') as TipoDato,
    SQL_VARIANT_PROPERTY(habilitado, 'Precision') as Precision,
    SQL_VARIANT_PROPERTY(habilitado, 'Scale') as Scale
FROM dbo.Paciente 
WHERE dni = '55676837'

-- 6. PRUEBA DE UPDATE CORRECTO SEGÚN TIPO DE DATO
-- Descomenta la línea apropiada según el tipo de dato

-- Si es bit (0/1):
-- UPDATE dbo.Paciente SET habilitado = 1 WHERE dni = '55676837'

-- Si es varchar/texto ('true'/'false'):
-- UPDATE dbo.Paciente SET habilitado = 'true' WHERE dni = '55676837'

-- Si es int (0/1):
-- UPDATE dbo.Paciente SET habilitado = 1 WHERE dni = '55676837'

-- ========================================
-- EJECUTA ESTA CONSULTA PARA DETERMINAR:
-- 1. El tipo de dato exacto del campo habilitado
-- 2. Los valores posibles que puede tomar
-- 3. El UPDATE correcto para activar al usuario
-- ========================================
