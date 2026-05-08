-- ========================================
-- ANÁLISIS DE FILTROS DE INTERFAZ - POR QUÉ VARELA NO APARECE
-- ========================================

-- 1. VERIFICAR ESTADO DE LOS COMBOS EN INTERFAZ
-- Simulación: ¿Qué valores tienen los combos cuando buscas a Varela?

-- Simular con Liga = "TODAS" (índice 0)
SELECT 
    'FILTRO LIGA - TODAS' as Tipo,
    'QUILMES DECANO' as ClubVarela,
    CASE 
        WHEN 'QUILMES DECANO' LIKE '%QUILMES%' THEN 'FILTRARÍA'
        ELSE 'NO FILTRA'
    END as Resultado

-- Simular con Club = "TODOS" (índice 0)  
SELECT 
    'FILTRO CLUB - TODOS' as Tipo,
    'QUILMES DECANO' as ClubVarela,
    CASE 
        WHEN 'QUILMES DECANO' LIKE '%QUILMES%' THEN 'FILTRARÍA'
        ELSE 'NO FILTRA'
    END as Resultado

-- Simular con Validación = "TODOS" (índice 0)
SELECT 
    'FILTRO VALIDACIÓN - TODOS' as Tipo,
    'QUILMES DECANO' as ClubVarela,
    CASE 
        WHEN 'QUILMES DECANO' LIKE '%QUILMES%' THEN 'FILTRARÍA'
        ELSE 'NO FILTRA'
    END as Resultado

-- 2. VERIFICAR SI QUILMES DECANO EXISTE EN TABLA CLUB
SELECT 
    'VERIFICACIÓN CLUB EXISTENTE' as Tipo,
    id,
    descripcion,
    CASE 
        WHEN descripcion = 'QUILMES DECANO' THEN 'EXISTE EXACTO'
        WHEN descripcion LIKE '%QUILMES%' THEN 'EXISTE SIMILAR'
        ELSE 'NO EXISTE'
    END as Estado
FROM dbo.Club 
WHERE descripcion LIKE '%QUILMES%'
ORDER BY descripcion

-- 3. VERIFICAR SI HAY ALGÚN FILTRO ACTIVO
-- Revisar el código fuente: línea 406-408 de obtenerFiltroString()
-- El problema puede estar en que el combo de Club está filtrando

-- 4. SIMULACIÓN COMPLETA DEL FILTRO
-- Si cboC.SelectedIndex != 0 (Club no está en "TODOS")
-- Entonces aplica: "Club like '%" + cboC.SelectedValue.ToString() + "%'"

SELECT 
    'SIMULACIÓN FILTRO CLUB' as Tipo,
    p.dni,
    p.apellido + ' ' + p.nombres as Paciente,
    cl.descripcion as Club,
    CASE 
        WHEN cl.descripcion LIKE '%QUILMES%' THEN 'PASARÍA FILTRO'
        ELSE 'NO PASARÍA FILTRO'
    END as ResultadoFiltro
FROM dbo.Paciente p
LEFT JOIN dbo.Club cl ON p.clubID = cl.id
WHERE p.dni = '55676837'

-- ========================================
// turbo
// ANÁLISIS DEL PROBLEMA:
// 1. obtenerFiltroString() aplica filtros adicionales después de la consulta SQL
// 2. Si el combo de Club no está en "TODOS", filtra por Club
// 3. Varela tiene Club = "QUILMES DECANO"
// 4. Si el combo de Club está filtrando por otro valor, Varela no aparecerá
// 
// SOLUCIÓN: Verificar que los combos estén en "TODAS" al buscar
// ========================================
