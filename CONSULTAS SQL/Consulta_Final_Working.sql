-- ========================================
-- CONSULTA FINAL QUE FUNCIONA - VARELA ENCONTRADO
-- DNI: 55676837 - VARELA BENICIO WILLIAM ELIEL
-- ========================================

-- ESTA ES LA CONSULTA QUE DEMUESTRA QUE VARELA EXISTE EN LA BASE DE DATOS
SELECT 
    'VARELA ENCONTRADO' as Estado,
    c.id as ConsultaID,
    c.fecha as FechaExamen,
    c.identificador as NroExamen,
    p.dni as DNI,
    p.apellido + ' ' + p.nombres as PacienteCompleto,
    e.descripcion as Deporte,
    cl.descripcion as Club,
    'Examen del 05/09/2025' as Detalle
FROM dbo.Consulta c
INNER JOIN dbo.Paciente p ON c.pacienteID = p.id
INNER JOIN dbo.TipoExamenDePaciente tep ON c.id = tep.idConsulta
INNER JOIN dbo.Especialidad e ON tep.idEspecialidad = e.id
LEFT JOIN dbo.Club cl ON p.clubID = cl.id
WHERE p.dni = '55676837'
  AND c.tipo = 'P'

-- ========================================
// turbo
// RESULTADO:
// VARELA BENICIO WILLIAM ELIEL está en la base de datos
// Fecha: 2025-05-09
// Examen N°: 1
// Deporte: FUTBOL METRO
// Club: QUILMES DECANO
// 
// EL PROBLEMA ESTÁ EN LA APLICACIÓN, NO EN LOS DATOS
// ========================================
