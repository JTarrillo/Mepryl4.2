-- ========================================
-- DIAGNÓSTICO: POR QUÉ VARELA NO APARECE EN INTERFAZ
-- A pesar de existir correctamente en la base de datos
-- ========================================

-- 1. VERIFICAR SI EXAMENPREVENTIVA TIENE REGISTRO CORRECTO
SELECT 
    'VERIFICACIÓN EXAMENPREVENTIVA' as Tipo,
    ep.idTipoExamen,
    ep.dictClinico,
    ep.dictLab,
    ep.dictRx,
    ep.dictCar,
    ep.dictFinal,
    CASE 
        WHEN ep.idTipoExamen IS NOT NULL THEN 'OK'
        ELSE 'FALTA REGISTRO'
    END as Estado
FROM dbo.ExamenPreventiva ep
WHERE ep.idTipoExamen = '60C755F4-AFDF-4183-9935-C239DA30941F'

-- 2. VERIFICAR SI LA CONSULTA TIENE FORMATO CORRECTO
SELECT 
    'VERIFICACIÓN FORMATO FECHA' as Tipo,
    c.id as ConsultaID,
    c.fecha as FechaGuardada,
    CONVERT(date,c.fecha) as FechaConvertida,
    CASE 
        WHEN CONVERT(date,c.fecha) = '2025-09-05' THEN 'CORRECTO'
        ELSE 'INCORRECTO'
    END as FormatoFecha,
    c.identificador as NroExamen,
    'Formato esperado: 2025-09-05' as Esperado
FROM dbo.Consulta c
WHERE c.id = '38F89CB1-3BB6-45A9-B5CB-CAC5E915A553'

-- 3. SIMULACIÓN COMPLETA DEL PROCESO DE LA INTERFAZ
-- Paso 1: Ejecutar consulta principal (líneas 330-336 de frmBusquedaExamen.cs)
SELECT 
    'PASO 1 - CONSULTA PRINCIPAL' as Tipo,
    tep.id as IdTE,
    c.id as IdC, 
    CONVERT(date, c.fecha) as Fecha, 
    c.identificador as 'Nº Examen', 
    p.dni as DNI,
    (p.apellido + ' ' + p.nombres) as Paciente, 
    tep.rm as RM, 
    tep.imp as IMP, 
    tep.inf as INF,
    tep.mail as Mail, 
    tep.dictAut, 
    tep.ImpLab, 
    p.fechaNacimiento, 
    tep.cons 
FROM dbo.Consulta c 
INNER JOIN dbo.TipoExamenDePaciente tep ON c.id = tep.idConsulta 
INNER JOIN dbo.Paciente p ON c.pacienteID = p.id
WHERE c.tipo = 'P' 
  AND CONVERT(date,c.fecha) >= CONVERT(date,'2025-09-05',105) 
  AND CONVERT(date,c.fecha) <= CONVERT(date,'2025-09-05',105) 
  AND CONVERT(varchar,p.dni) LIKE '%55676837%'
ORDER BY CONVERT(int,c.identificador) ASC, c.fecha ASC

-- Paso 2: Verificar si ExamenPreventiva existe (líneas 344-345)
SELECT 
    'PASO 2 - VERIFICACIÓN EXAMENPREVENTIVA' as Tipo,
    ep.idTipoExamen,
    CASE 
        WHEN ep.idTipoExamen IS NOT NULL THEN 'EXISTE'
        ELSE 'NO EXISTE'
    END as EstadoExamenPreventiva
FROM dbo.TipoExamenDePaciente tep
LEFT JOIN dbo.ExamenPreventiva ep ON tep.id = ep.idTipoExamen
WHERE tep.idConsulta = '38F89CB1-3BB6-45A9-B5CB-CAC5E915A553'

-- Paso 3: Verificar filtro adicional (línea 349 - obtenerFiltroString)
SELECT 
    'PASO 3 - FILTROS ADICIONALES' as Tipo,
    'Liga' as Filtro,
    CASE 
        WHEN 'QUILMES DECANO' LIKE '%QUILMES%' THEN 'FILTRA'
        ELSE 'NO FILTRA'
    END as ResultadoLiga
UNION ALL
SELECT 
    'Club' as Filtro,
    CASE 
        WHEN 'QUILMES DECANO' LIKE '%QUILMES%' THEN 'FILTRA'
        ELSE 'NO FILTRA'
    END as ResultadoClub
UNION ALL
SELECT 
    'Validación' as Filtro,
    CASE 
        WHEN '1' = '1' THEN 'FILTRA'
        ELSE 'NO FILTRA'
    END as ResultadoValidacion

-- ========================================
// turbo
// ANÁLISIS DEL PROBLEMA:
// 1. La consulta principal debe devolver a Varela
// 2. ExamenPreventiva debe existir para cada resultado
// 3. Los filtros adicionales (Liga, Club, Validación) pueden estar filtrando
// 
// POSIBLES CAUSAS:
// - El ExamenPreventiva no existe o está corrupto
// - Los filtros de Liga/Club/Validación están eliminando el resultado
// - Hay un filtro oculto en el código que no vemos
// ========================================
