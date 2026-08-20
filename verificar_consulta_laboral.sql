-- Verificar si existe el registro en ConsultaLaboral para L2
SELECT TOP 1 
    C.identificador, 
    C.fecha, 
    C.tipo,
    TEP.id as idTipoExamenDePaciente,
    CL.id as idConsultaLaboral,
    CL.idExamenLaboral,
    EL.id as idExamenLaboralReal
FROM dbo.Consulta C
INNER JOIN dbo.TipoExamenDePaciente TEP ON TEP.idConsulta = C.id
LEFT JOIN dbo.ConsultaLaboral CL ON CL.idTipoExamen = TEP.id
LEFT JOIN dbo.ExamenLaboral EL ON CL.idExamenLaboral = EL.id
WHERE C.identificador = 'L2'
ORDER BY C.fecha DESC;
