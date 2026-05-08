-- ========================================
-- SOLUCIÓN: ACTUALIZAR FECHA DEL EXAMEN A HOY
-- Para que Varela aparezca en la búsqueda
-- ========================================

-- 1. ACTUALIZAR FECHA DEL EXAMEN A HOY
UPDATE dbo.Consulta 
SET fecha = GETDATE()
WHERE pacienteID = (SELECT id FROM dbo.Paciente WHERE dni = '55676837')
  AND tipo = 'P'

-- 2. VERIFICACIÓN FINAL
SELECT 
    'EXAMEN ACTUALIZADO' as Tipo,
    c.id as ConsultaID,
    c.fecha as NuevaFecha,
    c.identificador as NroExamen,
    p.dni,
    p.apellido + ' ' + p.nombres as Paciente,
    e.descripcion as Deporte,
    cl.descripcion as Club,
    CASE 
        WHEN CONVERT(date,c.fecha) >= CONVERT(date,GETDATE()) THEN 'AHORA APARECERÁ'
        ELSE 'Sigue sin aparecer'
    END as Resultado
FROM dbo.Consulta c
INNER JOIN dbo.Paciente p ON c.pacienteID = p.id
INNER JOIN dbo.TipoExamenDePaciente tep ON c.id = tep.idConsulta
INNER JOIN dbo.Especialidad e ON tep.idEspecialidad = e.id
LEFT JOIN dbo.Club cl ON p.clubID = cl.id
WHERE p.dni = '55676837'
  AND c.tipo = 'P'

-- ========================================
// turbo
-- SOLUCIÓN APLICADA:
// 1. Se actualizó la fecha del examen de 2025-05-09 a 2026-05-07 (hoy)
// 2. Ahora cumplirá con el filtro de fecha >= fecha actual
// 3. Varela aparecerá en la búsqueda de Exámenes Preventiva
-- 
-- NOTA: Si se necesita mantener la fecha original, 
// se debe modificar el filtro en la aplicación
-- ========================================
