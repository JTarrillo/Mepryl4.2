-- ============================================================
-- CONSULTAS UTILES - TURNOS FUTBOL METRO
-- Base de datos: MEPRYLv2.1
-- Servidor: 192.168.1.254
-- Fecha creacion: 30/03/2026
-- ============================================================

-- GUIDS de referencia:
--   FUTBOL (padre)      : D6A02B46-FB57-44E1-9469-6315FC8236EF
--   FUTBOL METRO (hijo) : 60E94892-6F59-4202-A966-884FD71A5D8B

-- ============================================================
-- 1. VER SUBTIPOS DE UNA ESPECIALIDAD PADRE
-- ============================================================
SELECT id, descripcion, Padre, IdPadre
FROM dbo.Especialidad
WHERE IdPadre = 'D6A02B46-FB57-44E1-9469-6315FC8236EF'  -- FUTBOL padre
ORDER BY descripcion


-- ============================================================
-- 2. TODOS LOS TURNOS DEL DIA (con y sin paciente)
-- ============================================================
SELECT 
    t.id,
    ISNULL(tePadre.descripcion, te.descripcion) as TipoPadre,
    te.descripcion                               as SubTipo,
    p.apellido + ' ' + p.nombres                as Profesional,
    t.fecha,
    t.horaReferencia                             as Hora,
    CONVERT(numeric, t.nroOrden)                 as Nro,
    t.pacienteID,
    t.codigo,
    t.reserva,
    t.bloqueado,
    t.asistio,
    t.reservado,
    t.habilitado,
    t.estadoID,
    tep.id                                       as IdTipoExamen,
    eExamen.descripcion                          as Examen,
    tep.precioExamen                             as Importe
FROM dbo.Turno t
INNER JOIN dbo.TurnoEstado e              ON t.estadoID         = e.id
INNER JOIN dbo.Horario h                  ON t.horarioID        = h.id
INNER JOIN dbo.Profesional p              ON h.profesionalID    = p.id
LEFT  JOIN dbo.TipoExamenDePaciente tep   ON tep.idTurno        = t.id
LEFT  JOIN dbo.Especialidad eExamen       ON tep.idEspecialidad = eExamen.id
LEFT  JOIN dbo.Especialidad te            ON h.especialidadID   = te.id
LEFT  JOIN dbo.Especialidad tePadre       ON te.IdPadre = tePadre.id AND te.Padre = 0
WHERE convert(date, t.fecha) = convert(date, '30/03/2026', 105)   -- <-- cambiar fecha
  AND (
        te.id      = '60E94892-6F59-4202-A966-884FD71A5D8B'        -- FUTBOL METRO
     OR tePadre.id = '60E94892-6F59-4202-A966-884FD71A5D8B'
  )
ORDER BY t.fecha, t.hora


-- ============================================================
-- 3. SOLO LOS TURNOS ASIGNADOS (con paciente)
-- ============================================================
SELECT 
    t.id,
    ISNULL(tePadre.descripcion, te.descripcion) as TipoPadre,
    te.descripcion                               as SubTipo,
    p.apellido + ' ' + p.nombres                as Profesional,
    t.fecha,
    t.horaReferencia                             as Hora,
    CONVERT(numeric, t.nroOrden)                 as Nro,
    t.pacienteID,
    t.codigo,
    eExamen.descripcion                          as Examen,
    tep.precioExamen                             as Importe
FROM dbo.Turno t
INNER JOIN dbo.TurnoEstado e              ON t.estadoID         = e.id
INNER JOIN dbo.Horario h                  ON t.horarioID        = h.id
INNER JOIN dbo.Profesional p              ON h.profesionalID    = p.id
INNER JOIN dbo.TipoExamenDePaciente tep   ON tep.idTurno        = t.id
LEFT  JOIN dbo.Especialidad eExamen       ON tep.idEspecialidad = eExamen.id
LEFT  JOIN dbo.Especialidad te            ON h.especialidadID   = te.id
LEFT  JOIN dbo.Especialidad tePadre       ON te.IdPadre = tePadre.id AND te.Padre = 0
WHERE convert(date, t.fecha) = convert(date, '30/03/2026', 105)   -- <-- cambiar fecha
  AND (
        te.id      = '60E94892-6F59-4202-A966-884FD71A5D8B'
     OR tePadre.id = '60E94892-6F59-4202-A966-884FD71A5D8B'
  )
  AND t.pacienteID != '00000000-0000-0000-0000-000000000000'
ORDER BY t.fecha, t.hora


-- ============================================================
-- 4. VERIFICAR TURNOS CON EXAMEN MAL ASIGNADO (padre en vez de subtipo)
--    Turnos cuyo horario es FUTBOL METRO pero el examen registrado es FUTBOL padre
-- ============================================================
SELECT COUNT(*) as AffectedRows
FROM dbo.TipoExamenDePaciente tep
INNER JOIN dbo.Turno t   ON tep.idTurno          = t.id
INNER JOIN dbo.Horario h ON t.horarioID           = h.id
LEFT  JOIN dbo.Especialidad te ON h.especialidadID = te.id
LEFT  JOIN dbo.Especialidad tePadre ON te.IdPadre = tePadre.id AND te.Padre = 0
WHERE tep.idEspecialidad = 'D6A02B46-FB57-44E1-9469-6315FC8236EF'  -- tienen FUTBOL padre
  AND convert(date, t.fecha) = convert(date, '30/03/2026', 105)    -- <-- cambiar fecha
  AND (
        te.id      = '60E94892-6F59-4202-A966-884FD71A5D8B'
     OR tePadre.id = '60E94892-6F59-4202-A966-884FD71A5D8B'
  )


-- ============================================================
-- 5. CORREGIR EXAMEN MAL ASIGNADO: FUTBOL -> FUTBOL METRO
--    EJECUTAR SOLO DESPUES DE VERIFICAR CON LA CONSULTA 4
-- ============================================================
UPDATE tep
SET tep.idEspecialidad = '60E94892-6F59-4202-A966-884FD71A5D8B'   -- FUTBOL METRO
FROM dbo.TipoExamenDePaciente tep
INNER JOIN dbo.Turno t   ON tep.idTurno          = t.id
INNER JOIN dbo.Horario h ON t.horarioID           = h.id
LEFT  JOIN dbo.Especialidad te ON h.especialidadID = te.id
LEFT  JOIN dbo.Especialidad tePadre ON te.IdPadre = tePadre.id AND te.Padre = 0
WHERE tep.idEspecialidad = 'D6A02B46-FB57-44E1-9469-6315FC8236EF'  -- tenian FUTBOL padre
  AND convert(date, t.fecha) = convert(date, '30/03/2026', 105)    -- <-- cambiar fecha
  AND (
        te.id      = '60E94892-6F59-4202-A966-884FD71A5D8B'
     OR tePadre.id = '60E94892-6F59-4202-A966-884FD71A5D8B'
  )
