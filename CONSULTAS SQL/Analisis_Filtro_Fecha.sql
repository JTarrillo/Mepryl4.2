-- ========================================
-- ANÁLISIS DEL PROBLEMA DE FILTRO POR FECHA
-- Varela tiene examen 2025-05-09 pero el sistema filtra por fecha actual
-- ========================================

-- 1. COMPARAR AMBOS REGISTROS
SELECT 
    'ANÁLISIS COMPARATIVO' as Tipo,
    p.dni,
    p.apellido + ' ' + p.nombres as Paciente,
    c.fecha as FechaExamen,
    CONVERT(date,c.fecha) as FechaSoloDia,
    GETDATE() as FechaActualHoy,
    DATEDIFF(day, c.fecha, GETDATE()) as DiasDiferencia,
    CASE 
        WHEN CONVERT(date,c.fecha) >= CONVERT(date,GETDATE()) THEN 'Dentro del rango'
        ELSE 'Fuera del rango (muy antiguo)'
    END as EstadoFiltro
FROM dbo.Consulta c
INNER JOIN dbo.Paciente p ON c.pacienteID = p.id
WHERE p.dni IN ('55676837', '55868980') 
  AND c.tipo = 'P'

-- 2. VERIFICAR QUÉ FILTRO USA LA APLICACIÓN
-- Según el código de frmBusquedaExamen.cs línea 335:
-- Convert(date,c.fecha) >= convert(date,'" + desde.ToShortDateString() + @"',105)
-- Esto significa que solo muestra exámenes desde la fecha "desde" hacia adelante

-- 3. SIMULACIÓN DEL FILTRO CON FECHA DE HOY
SELECT 
    'SIMULACIÓN FILTRO HOY' as Tipo,
    p.dni,
    p.apellido + ' ' + p.nombres as Paciente,
    c.fecha as FechaExamen,
    CASE 
        WHEN CONVERT(date,c.fecha) >= CONVERT(date,GETDATE()) THEN 'APARECE'
        ELSE 'NO APARECE'
    END as ResultadoFiltro
FROM dbo.Consulta c
INNER JOIN dbo.Paciente p ON c.pacienteID = p.id
WHERE p.dni IN ('55676837', '55868980') 
  AND c.tipo = 'P'
  AND CONVERT(date,c.fecha) >= CONVERT(date,GETDATE())

-- ========================================
// turbo
-- DIAGNÓSTICO DEL PROBLEMA:
// 1. Varela tiene examen el 2025-05-09 (hace 363 días)
// 2. Galarza tiene examen el 2026-05-07 (hoy)
// 3. La aplicación filtra por fecha >= fecha actual
// 4. Por eso Varela no aparece (fecha muy antigua)
-- 
-- SOLUCIÓN: Cambiar el filtro de fecha en la aplicación
-- o crear un examen con fecha más reciente
-- ========================================
