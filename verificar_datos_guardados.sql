-- Verificar datos guardados en el registro específico
SELECT gRojos, gBlancos, hemoglobina, hematocrito, glucemia, uremia, vdrl, grupo, factor, colTotal, hdl, ldl, trig, densidad, ph, observacionesLab
FROM dbo.ExamenLaboral 
WHERE id = '5AFE8EE8-11CC-4177-87E4-777DF7F0C0FA';
