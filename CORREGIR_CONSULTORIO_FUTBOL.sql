-- ========================================
-- CORRECCIÓN ARQUITECTÓNICA
-- Actualizar turnos de FUTBOL que tienen CONSULTORIO asignado incorrectamente
-- ========================================
-- Problema: El sistema forzaba CONSULTORIO en lugar de respetar la especialidad del horario
-- Solución: Actualizar TipoExamenDePaciente para usar la especialidad correcta del horario
-- ========================================

USE [MEPRYLv2.1];
GO

-- Primero verificar cuántos registros están afectados
SELECT 
    COUNT(*) as Registros_Afectados,
    'FUTBOL con CONSULTORIO incorrecto' as Descripcion
FROM dbo.TipoExamenDePaciente tep
INNER JOIN dbo.Turno t ON tep.idTurno = t.id
INNER JOIN dbo.Horario h ON t.horarioID = h.id
INNER JOIN dbo.Especialidad eHorario ON h.especialidadID = eHorario.id
INNER JOIN dbo.Especialidad eTEP ON tep.idEspecialidad = eTEP.id
WHERE eTEP.descripcion = 'CONSULTORIO'
  AND eHorario.descripcion LIKE '%FUTBOL%';
GO

-- Mostrar ejemplos de registros afectados antes de la corrección
SELECT 
    t.codigo as Codigo_Turno,
    t.fecha as Fecha,
    t.horaReferencia as Hora,
    eHorario.descripcion as Especialidad_Horario_Correcta,
    eTEP.descripcion as Especialidad_Asignada_Incorrecta,
    tep.id as IdTipoExamenDePaciente
FROM dbo.TipoExamenDePaciente tep
INNER JOIN dbo.Turno t ON tep.idTurno = t.id
INNER JOIN dbo.Horario h ON t.horarioID = h.id
INNER JOIN dbo.Especialidad eHorario ON h.especialidadID = eHorario.id
INNER JOIN dbo.Especialidad eTEP ON tep.idEspecialidad = eTEP.id
WHERE eTEP.descripcion = 'CONSULTORIO'
  AND eHorario.descripcion LIKE '%FUTBOL%'
ORDER BY t.fecha DESC;
GO

-- ========================================
-- CORRECCIÓN: Actualizar TipoExamenDePaciente con la especialidad correcta del horario
-- ========================================
UPDATE dbo.TipoExamenDePaciente 
SET idEspecialidad = (
    SELECT h.especialidadID 
    FROM dbo.Turno t 
    INNER JOIN dbo.Horario h ON t.horarioID = h.id 
    WHERE t.id = TipoExamenDePaciente.idTurno
)
WHERE idEspecialidad = '254110EB-0A50-47D8-89EF-118D163FCE8B' -- CONSULTORIO
AND idTurno IN (
    SELECT t.id 
    FROM dbo.Turno t 
    INNER JOIN dbo.Horario h ON t.horarioID = h.id 
    INNER JOIN dbo.Especialidad e ON h.especialidadID = e.id
    WHERE e.descripcion LIKE '%FUTBOL%'
);
GO

-- Verificar resultados después de la corrección
SELECT 
    t.codigo as Codigo_Turno,
    t.fecha as Fecha,
    t.horaReferencia as Hora,
    eHorario.descripcion as Especialidad_Horario,
    eTEP.descripcion as Especialidad_Corregida,
    'CORREGIDO' as Estado
FROM dbo.TipoExamenDePaciente tep
INNER JOIN dbo.Turno t ON tep.idTurno = t.id
INNER JOIN dbo.Horario h ON t.horarioID = h.id
INNER JOIN dbo.Especialidad eHorario ON h.especialidadID = eHorario.id
INNER JOIN dbo.Especialidad eTEP ON tep.idEspecialidad = eTEP.id
WHERE eHorario.descripcion LIKE '%FUTBOL%'
  AND t.fecha >= '2026-01-01' -- Solo registros recientes
ORDER BY t.fecha DESC;
GO

PRINT 'Corrección arquitectónica completada: Turnos de FUTBOL ahora usan la especialidad correcta del horario';
GO