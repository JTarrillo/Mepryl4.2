-- ========================================
-- ACTIVACIÓN INMEDIATA DEL USUARIO 55676837
-- Para que aparezca en Exámenes Preventiva
-- ========================================

-- 1. VER ESTADO ACTUAL
SELECT 
    username,
    apellido + ' ' + nombre as NombreCompleto,
    dni,
    Activo,
    CASE 
        WHEN Activo = 1 THEN 'ACTIVO - Debería aparecer en Exámenes Preventiva'
        WHEN Activo = 0 THEN 'INACTIVO - No aparece en Exámenes Preventiva'
    END as EstadoActual
FROM dbo.Usuario 
WHERE dni = '55676837'

-- 2. EJECUTAR ACTIVACIÓN (DESMARCAR LA LÍNEA DE ABAJO)
UPDATE dbo.Usuario 
SET Activo = 1
WHERE dni = '55676837'

-- 3. VERIFICAR QUE QUEDÓ ACTIVO
SELECT 
    username,
    apellido + ' ' + nombre as NombreCompleto,
    dni,
    Activo,
    CASE 
        WHEN Activo = 1 THEN 'ACTIVO - Ahora debería aparecer en Exámenes Preventiva'
        WHEN Activo = 0 THEN 'Sigue INACTIVO - Revisa el UPDATE'
    END as EstadoFinal
FROM dbo.Usuario 
WHERE dni = '55676837'

-- 4. VERIFICAR SI TIENE EXÁMENES ASIGNADOS
SELECT 
    'Exámenes del usuario' as Info,
    COUNT(*) as CantidadExamenes
FROM dbo.Turno t
INNER JOIN dbo.Paciente p ON t.pacienteID = p.id
WHERE p.dni = '55676837'

-- ========================================
// turbo
-- INSTRUCCIONES:
-- 1. Ejecuta esta consulta completa
-- 2. El UPDATE se ejecutará automáticamente para activar al usuario
-- 3. Verifica el resultado en las consultas 1 y 3
-- 4. Vuelve a buscar en "Exámenes Preventiva" por DNI 55676837
-- ========================================
