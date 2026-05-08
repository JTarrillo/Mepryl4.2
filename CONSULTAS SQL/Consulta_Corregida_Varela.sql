-- ========================================
-- CONSULTA CORREGIDA QUE ENCUENTRA A VARELA
-- El problema era el formato de fecha: 05/09/2025 se interpreta como 9 de mayo
-- ========================================

-- CONSULTA CORREGIDA CON FORMATO DE FECHA AÑO-MES-DIA
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
  AND Convert(date,c.fecha) >= convert(date,'2025-05-09',105) 
  AND Convert(date,c.fecha) <= convert(date,'2025-05-09',105)
  AND CONVERT(varchar,p.dni) LIKE '%55676837%'
ORDER BY convert(int,c.identificador) asc, c.fecha asc

-- ========================================
// turbo
// EXPLICACIÓN:
// 05/09/2025 en formato 105 (dd/mm/yyyy) = 9 de mayo de 2025
// Pero el examen está guardado como 2025-05-09 = 9 de mayo de 2025
// 
// La consulta correcta debe usar 2025-05-09 (año-mes-dia)
// ========================================
