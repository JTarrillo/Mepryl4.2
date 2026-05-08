-- ========================================
-- ACTUALIZAR NÚMERO DE EXAMEN DE VARELA A 208
-- Para que coincida con el PDF del estudio clínico
-- ========================================

-- 1. VERIFICAR ESTADO ACTUAL DE VARELA
SELECT 
    'ESTADO ACTUAL ANTES DE ACTUALIZAR' as Tipo,
    c.id as ConsultaID,
    c.identificador as NroExamenActual,
    c.fecha as FechaExamen,
    p.dni,
    p.apellido + ' ' + p.nombres as Paciente
    'El PDF dice examen 208' as Referencia
FROM dbo.Consulta c
INNER JOIN dbo.Paciente p ON c.pacienteID = p.id
WHERE p.dni = '55676837'
  AND c.tipo = 'P'

-- 2. ACTUALIZAR NÚMERO DE EXAMEN A 208
UPDATE dbo.Consulta 
SET identificador = '208'
WHERE id = '38F89CB1-3BB6-45A9-B5CB-CAC5E915A553'

-- 3. VERIFICACIÓN FINAL
SELECT 
    'ESTADO FINAL DESPUÉS DE ACTUALIZAR' as Tipo,
    c.id as ConsultaID,
    c.identificador as NroExamenNuevo,
    c.fecha as FechaExamen,
    p.dni,
    p.apellido + ' ' + p.nombres as Paciente,
    CASE 
        WHEN c.identificador = '208' THEN '✅ ACTUALIZADO A 208'
        ELSE '❌ ERROR EN ACTUALIZACIÓN'
    END as Resultado,
    'Ahora debería coincidir con el PDF del estudio' as ReferenciaFinal
FROM dbo.Consulta c
INNER JOIN dbo.Paciente p ON c.pacienteID = p.id
WHERE p.dni = '55676837'
  AND c.tipo = 'P'

-- ========================================
// turbo
// EXPLICACIÓN:
// 1. El PDF del estudio clínico indica examen N°208
// 2. Actualizamos el número en la base de datos
// 3. Verificamos que el cambio fue exitoso
// 
// CON ESTE CAMBIO, VARELA DEBERÍA APARECER CORRECTAMENTE
// CUANDO BUSQUEN POR EXAMEN N°208 EN LA INTERFAZ
// ========================================
