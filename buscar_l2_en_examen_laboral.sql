-- Buscar registros relacionados con L-2 en ExamenLaboral
-- Buscamos por el patrón que podría estar en alguna columna
SELECT TOP 5 id, na, k, observaciones
FROM dbo.ExamenLaboral
WHERE na LIKE '%L-2%' OR k LIKE '%L-2%' OR observaciones LIKE '%L-2%'
