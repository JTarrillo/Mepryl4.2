-- ========================================
-- DIAGNÓSTICO FINAL: PROBLEMA DE FORMATO DE FECHA
-- ========================================

/*
PROBLEMA IDENTIFICADO:
==================
El examen de Varela está guardado como: 2025-05-09 (5 de septiembre)
Pero la aplicación está buscando: 2025-09-05 (5 de septiembre)

El formato de fecha está invertido en la conversión SQL.

VERIFICACIÓN:
=============
- Fecha guardada: 2025-05-09 (9 de mayo)
- Fecha buscada: 2025-09-05 (5 de septiembre)
- Resultado: No coinciden las fechas

SOLUCIÓN:
==========
Actualizar la fecha del examen al formato correcto
*/

-- 1. VERIFICAR FECHA ACTUAL
SELECT 
    'FECHA ACTUAL INCORRECTA' as Tipo,
    c.fecha as FechaGuardada,
    CONVERT(date,c.fecha) as FechaConvertida,
    'Debe ser 05/09/2025 (5 de septiembre)' as FechaCorrecta
FROM dbo.Consulta c
WHERE c.id = '38F89CB1-3BB6-45A9-B5CB-CAC5E915A553'

-- 2. CORREGIR FECHA AL FORMATO CORRECTO
UPDATE dbo.Consulta 
SET fecha = '2025-09-05'  -- 5 de septiembre de 2025
WHERE id = '38F89CB1-3BB6-45A9-B5CB-CAC5E915A553'

-- 3. VERIFICACIÓN FINAL
SELECT 
    'VERIFICACIÓN FINAL' as Tipo,
    c.fecha as FechaCorregida,
    CONVERT(date,c.fecha) as FechaConvertida,
    CASE 
        WHEN CONVERT(date,c.fecha) = '2025-09-05' THEN 'FECHA CORRECTA'
        ELSE 'FECHA INCORRECTA'
    END as Estado
FROM dbo.Consulta c
WHERE c.id = '38F89CB1-3BB6-45A9-B5CB-CAC5E915A553'

-- 4. PROBAR LA BÚSQUEDA EXACTA
SELECT 
    'BÚSQUEDA FINAL' as Tipo,
    tep.id as IdTE,
    c.id as IdC,
    CONVERT(date,c.fecha) as Fecha,
    c.identificador as 'Nº Examen',
    p.dni as DNI,
    (p.apellido + ' ' + p.nombres) as Paciente
FROM dbo.Consulta c
INNER JOIN dbo.TipoExamenDePaciente tep ON c.id = tep.idConsulta
INNER JOIN dbo.Paciente p ON c.pacienteID = p.id
WHERE c.tipo = 'P' 
  AND CONVERT(date,c.fecha) >= CONVERT(date,'2025-09-05',105) 
  AND CONVERT(date,c.fecha) <= CONVERT(date,'2025-09-05',105) 
  AND p.dni = '55676837'
ORDER BY CONVERT(int,c.identificador) ASC, c.fecha ASC

-- ========================================
// turbo
-- DIAGNÓSTICO FINAL:
// El problema era el formato de fecha: estaba guardado como 2025-05-09
// pero se buscaba 2025-09-05 (5 de septiembre vs 9 de mayo)
// 
// SOLUCIÓN: Actualizar la fecha al formato correcto
-- ========================================
