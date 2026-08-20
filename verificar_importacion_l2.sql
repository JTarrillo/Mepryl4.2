-- Verificar datos importados para L2
SELECT TOP 1 gRojos, gBlancos, hemoglobina, hematocrito, glucemia, uremia, vdrl, grupo, factor, colTotal, hdl, ldl, trig, densidad, ph, observacionesLab
FROM dbo.ExamenLaboral el
WHERE el.id IN (
    SELECT TOP 1 tep.idExamenLaboral
    FROM dbo.TipoExamenDePaciente tep
    INNER JOIN dbo.Consulta c ON tep.idConsulta = c.id
    WHERE c.identificador = 'L2'
    ORDER BY c.fecha DESC
);
