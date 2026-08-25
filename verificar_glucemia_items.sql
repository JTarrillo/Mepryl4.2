-- Verificar el ID de glucemia en la tabla Items
SELECT * FROM dbo.Items WHERE nombre LIKE '%GLUC%' OR nombre LIKE '%gluc%';

-- Verificar qué estudios están configurados para un tipo de examen específico
-- Primero necesitamos obtener un idTipoExamen de ejemplo
SELECT TOP 5 * FROM dbo.TipoExamenDePaciente;

-- Verificar la estructura de EstudiosPorExamen
SELECT TOP 5 * FROM dbo.EstudiosPorExamen;
