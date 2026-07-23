-- Obtener el idTipoExamen del paciente con identificador L-2
-- Primero veremos la estructura de ConsultaLaboral
SELECT TOP 1 
    cl.idTipoExamen,
    tep.id as IdTipoExamenPaciente,
    tep.idEspecialidad,
    e.descripcion as Especialidad
FROM dbo.TipoExamenDePaciente tep
INNER JOIN dbo.Especialidad e ON tep.idEspecialidad = e.id
INNER JOIN dbo.ConsultaLaboral cl ON cl.idTipoExamen = tep.id
WHERE cl.identificador = 'L-2'
