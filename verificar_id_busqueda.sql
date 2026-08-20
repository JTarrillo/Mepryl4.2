-- Verificar qué ID busca el método IDExamenLaboral para L2
DECLARE @Fecha varchar(50) = '20/08/2026 0:00:00';
DECLARE @Identificador varchar(50) = 'L2';

SELECT TOP 1 EL.id 
FROM dbo.Consulta C 
INNER JOIN dbo.TipoExamenDePaciente TEP ON TEP.idConsulta = C.id AND tipo = 'L' 
INNER JOIN dbo.ConsultaLaboral CL ON CL.idTipoExamen = TEP.id 
INNER JOIN dbo.ExamenLaboral EL ON CL.idExamenLaboral = EL.id 
WHERE C.identificador = @Identificador 
  AND Convert(date, C.fecha) = Convert(date, Convert(datetime, @Fecha));
