-- ========================================
-- CONSULTA EXACTA QUE ENCUENTRA A VARELA EN LA BASE DE DATOS
-- DNI: 55676837 - VARELA BENICIO WILLIAM ELIEL
-- ========================================

-- CONSULTA EXACTA SEGÚN EL CÓDIGO DE LA APLICACIÓN (frmBusquedaExamen.cs líneas 330-336)
SELECT 
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
  AND Convert(date,c.fecha) >= convert(date,'05/09/2025',105) 
  AND Convert(date,c.fecha) <= convert(date,'05/09/2025',105)
  AND CONVERT(varchar,p.dni) LIKE '%55676837%'
ORDER BY convert(int,c.identificador) asc, c.fecha asc

-- ========================================
// turbo
// ESTA ES LA CONSULTA EXACTA QUE USA LA APLICACIÓN
// Si esta consulta devuelve resultados, el problema está en la aplicación
// Si no devuelve resultados, el problema está en los datos
// ========================================
