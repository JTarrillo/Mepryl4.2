-- ========================================
-- CONSULTA SIMPLE QUE FUNCIONA SIN ERRORES DE FECHA
-- DNI: 55676837 - VARELA BENICIO WILLIAM ELIEL
-- ========================================

-- CONSULTA SIMPLE SIN CONVERSIÓN DE FECHA
SELECT 
    tep.id as IdTE,
    c.id as IdC, 
    c.fecha as Fecha, 
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
  AND c.fecha = '2025-05-09'
  AND p.dni = '55676837'
ORDER BY convert(int,c.identificador) asc, c.fecha asc

-- ========================================
// turbo
// ESTA CONSULTA FUNCIONA SIN ERRORES DE CONVERSIÓN
// Usa comparación directa de fecha sin CONVERT
// ========================================
