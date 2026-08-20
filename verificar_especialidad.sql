-- Verificar la especialidad asociada al Horario
SELECT 
    e.id AS EspecialidadID,
    e.descripcion AS EspecialidadDesc,
    e.Padre AS EspecialidadPadre,
    mc.nombre AS MotivoConsulta
FROM dbo.Especialidad e
LEFT JOIN dbo.MotivoDeConsulta mc ON e.idMotivoConsulta = mc.id
WHERE e.id = '254110EB-0A50-47D8-89EF-118D163FCE8B';

-- Verificar todas las especialidades relacionadas con FUTBOL
SELECT 
    id,
    descripcion,
    Padre
FROM dbo.Especialidad
WHERE descripcion LIKE '%FUTBOL%'
ORDER BY descripcion;
