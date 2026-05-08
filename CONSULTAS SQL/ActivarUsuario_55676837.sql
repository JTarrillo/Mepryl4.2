-- ========================================
-- ACTIVACIÓN DEL USUARIO DNI 55676837
-- Varela Benicio William Eliel
-- Usuario: beniciowilliameliel
-- ========================================

-- 1. VERIFICACIÓN ANTES DE ACTIVAR
SELECT 
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    habilitado,
    'Estado Actual' as Estado
FROM dbo.Paciente 
WHERE dni = '55676837'

-- 2. ACTUALIZACIÓN PARA ACTIVAR EL USUARIO
-- Descomenta la siguiente línea para ejecutar la activación
-- UPDATE dbo.Paciente 
-- SET habilitado = 1
-- WHERE dni = '55676837'

-- 3. VERIFICACIÓN DESPUÉS DE ACTIVAR
SELECT 
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    habilitado,
    'Estado Después de Activar' as Estado
FROM dbo.Paciente 
WHERE dni = '55676837'

-- 4. VERIFICAR SI TIENE TURNOS PENDIENTES
SELECT 
    t.id as IdTurno,
    t.fecha,
    t.horaReferencia as Hora,
    t.nroOrden as NroOrden,
    te.descripcion as TipoExamen,
    prof.apellido + ' ' + prof.nombres as Profesional,
    e.descripcion as EstadoTurno,
    t.observaciones
FROM dbo.Turno t
INNER JOIN dbo.Horario h ON t.horarioID = h.id
INNER JOIN dbo.Especialidad te ON h.especialidadID = te.id
INNER JOIN dbo.Profesional prof ON h.profesionalID = prof.id
INNER JOIN dbo.TurnoEstado e ON t.estadoID = e.id
WHERE t.pacienteID = (SELECT id FROM dbo.Paciente WHERE dni = '55676837')
  AND t.fecha >= GETDATE()
ORDER BY t.fecha

-- 5. VERIFICAR ESPECÍFICAMENTE EL TURNO DEL 05/09/2025
SELECT 
    t.id as IdTurno,
    t.fecha,
    t.horaReferencia as Hora,
    t.nroOrden as NroOrden,
    te.descripcion as TipoExamen,
    prof.apellido + ' ' + prof.nombres as Profesional,
    e.descripcion as EstadoTurno,
    t.observaciones,
    'TURNO BUSCADO' as Alerta
FROM dbo.Turno t
INNER JOIN dbo.Horario h ON t.horarioID = h.id
INNER JOIN dbo.Especialidad te ON h.especialidadID = te.id
INNER JOIN dbo.Profesional prof ON h.profesionalID = prof.id
INNER JOIN dbo.TurnoEstado e ON t.estadoID = e.id
WHERE t.pacienteID = (SELECT id FROM dbo.Paciente WHERE dni = '55676837')
  AND CONVERT(date, t.fecha) = CONVERT(date, '05/09/2025', 105)

-- ========================================
-- INSTRUCCIONES:
-- 1. Ejecuta primero la consulta 1 para verificar el estado actual
-- 2. Descomenta y ejecuta la consulta 2 para activar al usuario
-- 3. Ejecuta la consulta 3 para verificar que quedó activado
-- 4. Ejecuta las consultas 4 y 5 para verificar sus turnos
-- ========================================

-- NOTA: El usuario fue creado el 07/05/2026 y está inactivo
-- Al activarlo, podrá usar el sistema normalmente
