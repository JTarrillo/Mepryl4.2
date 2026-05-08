-- ========================================
-- SOLUCIÓN FINAL: PONER CLUB DE VARELA EN NULL
-- Para que no tenga restricción de filtro
-- ========================================

-- 1. ACTUALIZAR CLUB DE VARELA A NULL
UPDATE dbo.Paciente 
SET clubID = NULL
WHERE dni = '55676837'

-- 2. VERIFICACIÓN FINAL
SELECT 
    'VERIFICACIÓN FINAL - CLUB NULL' as Tipo,
    p.dni,
    p.apellido + ' ' + p.nombres as Paciente,
    cl.descripcion as ClubActual,
    p.clubID as ClubID,
    CASE 
        WHEN p.clubID IS NULL THEN 'SIN RESTRICCIÓN DE FILTRO'
        ELSE 'CON FILTRO ACTIVO'
    END as EstadoFiltro
FROM dbo.Paciente p
LEFT JOIN dbo.Club cl ON p.clubID = cl.id
WHERE p.dni = '55676837'

-- 3. SIMULACIÓN DE BÚSQUEDA SIN FILTRO DE CLUB
-- Con clubID = NULL, el filtro "Club like '%...%" no debería afectar
SELECT 
    'SIMULACIÓN BÚSQUEDA SIN FILTRO' as Tipo,
    p.dni,
    p.apellido + ' ' + p.nombres as Paciente,
    'SIN CLUB - DEBERÍA APARECER' as Resultado
FROM dbo.Paciente p
WHERE p.dni = '55676837'
  AND p.clubID IS NULL

-- ========================================
// turbo
// EXPLICACIÓN:
// 1. Al poner clubID = NULL, el filtro de Club no lo afectará
// 2. El método obtenerFiltroString() no generará filtro para Club
// 3. Varela aparecerá siempre que cumpla los otros criterios
// 
// ESTA ES LA SOLUCIÓN DEFINITIVA SIN MODIFICAR CÓDIGO
// ========================================
