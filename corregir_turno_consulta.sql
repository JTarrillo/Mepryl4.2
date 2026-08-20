-- Corregir el campo consulta del Turno para que coincida con la especialidad del Horario
UPDATE dbo.Turno
SET consulta = 'FUTBOL METRO'
WHERE id = '7BA14B39-0FD8-4560-8115-B4506D91251A';

-- Corregir la especialidad del Horario de CONSULTORIO a FUTBOL METRO SIN LABORATORIO NI RX
UPDATE dbo.Horario
SET especialidadID = 'C260173E-3C3C-4AB0-8FAB-822DD540A3AA'
WHERE id = 'CF5A0AE0-2693-4298-8968-315E0F6AAB5F';

-- Verificar el cambio
SELECT 
    t.id,
    t.consulta AS CampoConsulta_Turno,
    h.especialidadID AS EspecialidadID_Horario,
    e.descripcion AS Especialidad_Horario
FROM dbo.Turno t
INNER JOIN dbo.Horario h ON t.horarioID = h.id
INNER JOIN dbo.Especialidad e ON h.especialidadID = e.id
WHERE t.id = '7BA14B39-0FD8-4560-8115-B4506D91251A';
