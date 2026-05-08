-- ========================================
-- SOLUCIÓN FINAL: CREAR REGISTRO EN EXAMENPREVENTIVA
-- El examen existe pero falta el registro en ExamenPreventiva
-- ========================================

/*
PROBLEMA IDENTIFICADO:
==================
1. ✅ Paciente existe: VARELA BENICIO (DNI: 55676837)
2. ✅ Consulta existe: ID 38F89CB1-3BB6-45A9-B5CB-CAC5E915A553
3. ✅ TipoExamenDePaciente existe: ID 60C755F4-AFDF-4183-9935-C239DA30941F
4. ❌ ExamenPreventiva NO existe: 0 registros

La aplicación busca en ExamenPreventiva (línea 344-345 del código)
*/

-- 1. CREAR REGISTRO EN EXAMENPREVENTIVA
INSERT INTO dbo.ExamenPreventiva (
    idTipoExamen,
    dictClinico,
    dictLab,
    dictRx,
    dictCar,
    dictFinal
)
VALUES (
    '60C755F4-AFDF-4183-9935-C239DA30941F', -- idTipoExamen
    0,                                        -- dictClinico
    0,                                        -- dictLab
    0,                                        -- dictRx
    0,                                        -- dictCar
    0                                         -- dictFinal
)

-- 2. VERIFICACIÓN FINAL
SELECT 
    'VERIFICACIÓN EXAMENPREVENTIVA' as Tipo,
    ep.idTipoExamen,
    ep.dictClinico,
    ep.dictLab,
    ep.dictRx,
    ep.dictCar,
    ep.dictFinal,
    'Registro creado correctamente' as Resultado
FROM dbo.ExamenPreventiva ep
WHERE ep.idTipoExamen = '60C755F4-AFDF-4183-9935-C239DA30941F'

-- 3. PRUEBA FINAL DE BÚSQUEDA COMPLETA
SELECT 
    'PRUEBA BÚSQUEDA COMPLETA' as Tipo,
    tep.id as IdTE,
    c.id as IdC,
    CONVERT(date,c.fecha) as Fecha,
    c.identificador as 'Nº Examen',
    p.dni as DNI,
    (p.apellido + ' ' + p.nombres) as Paciente,
    ep.dictClinico,
    ep.dictLab,
    ep.dictRx,
    ep.dictCar,
    ep.dictFinal
FROM dbo.Consulta c
INNER JOIN dbo.TipoExamenDePaciente tep ON c.id = tep.idConsulta
INNER JOIN dbo.Paciente p ON c.pacienteID = p.id
INNER JOIN dbo.ExamenPreventiva ep ON tep.id = ep.idTipoExamen
WHERE c.tipo = 'P' 
  AND CONVERT(date,c.fecha) >= CONVERT(date,'2025-09-05',105) 
  AND CONVERT(date,c.fecha) <= CONVERT(date,'2025-09-05',105) 
  AND p.dni = '55676837'
ORDER BY CONVERT(int,c.identificador) ASC, c.fecha ASC

-- ========================================
// turbo
-- DIAGNÓSTICO FINAL:
// El problema era que faltaba el registro en la tabla ExamenPreventiva
// La aplicación necesita este registro para mostrar el examen en el DataGridView
// 
-- SOLUCIÓN: Crear el registro faltante en ExamenPreventiva
-- ========================================
