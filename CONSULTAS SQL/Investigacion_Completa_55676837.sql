-- ========================================
-- INVESTIGACIÓN COMPLETA - POR QUÉ NO APARECE EN EXÁMENES PREVENTIVA
-- DNI: 55676837 - Varela Benicio William Eliel
-- ========================================

-- 1. VERIFICAR SI EL PACIENTE EXISTE Y TIENE EXÁMENES
SELECT 
    'PACIENTE EXISTE' as Tipo,
    p.id,
    p.dni,
    p.apellido + ' ' + p.nombres as NombreCompleto,
    CASE 
        WHEN p.id IS NOT NULL THEN 'Paciente existe'
        ELSE 'Paciente NO existe'
    END as EstadoPaciente
FROM dbo.Paciente p
WHERE p.dni = '55676837'

-- 2. VERIFICAR SI TIENE TURNOS ASIGNADOS
SELECT 
    'TURNOS ASIGNADOS' as Tipo,
    COUNT(*) as CantidadTurnos,
    CASE 
        WHEN COUNT(*) > 0 THEN 'Tiene turnos asignados'
        ELSE 'NO tiene turnos asignados'
    END as EstadoTurnos
FROM dbo.Turno t
INNER JOIN dbo.Paciente p ON t.pacienteID = p.id
WHERE p.dni = '55676837'

-- 3. VERIFICAR TURNOS ESPECÍFICAMENTE PARA 05/09/2025
SELECT 
    'TURNO FECHA ESPECÍFICA' as Tipo,
    t.id as IdTurno,
    t.fecha,
    t.horaReferencia as Hora,
    te.descripcion as TipoExamen,
    prof.apellido + ' ' + prof.nombres as Profesional,
    e.descripcion as EstadoTurno,
    CASE 
        WHEN t.id IS NOT NULL THEN 'Tiene turno para 05/09/2025'
        ELSE 'NO tiene turno para 05/09/2025'
    END as EstadoFecha
FROM dbo.Turno t
INNER JOIN dbo.Paciente p ON t.pacienteID = p.id
INNER JOIN dbo.Horario h ON t.horarioID = h.id
INNER JOIN dbo.Especialidad te ON h.especialidadID = te.id
INNER JOIN dbo.Profesional prof ON h.profesionalID = prof.id
INNER JOIN dbo.TurnoEstado e ON t.estadoID = e.id
WHERE p.dni = '55676837'
  AND CONVERT(date, t.fecha) = CONVERT(date, '05/09/2025', 105)

-- 4. VERIFICAR ESTADO DEL USUARIO EN TABLA USUARIO
SELECT 
    'USUARIO ESTADO' as Tipo,
    u.id,
    u.username,
    u.dni,
    u.Activo,
    u.Tipo,
    CASE 
        WHEN u.Activo = 1 THEN 'Usuario ACTIVO'
        WHEN u.Activo = 0 THEN 'Usuario INACTIVO'
        ELSE 'Estado desconocido'
    END as EstadoUsuario
FROM dbo.Usuario u
WHERE u.dni = '55676837'

-- 5. VERIFICAR PERMISOS DEL USUARIO
SELECT 
    'PERMISOS USUARIO' as Tipo,
    u.username,
    u.VentPacientes as VerPacientes,
    u.VentTurnos as VerTurnos,
    u.VentMesa as VerMesa,
    u.PermisoVer as PermisoVer,
    u.PermisoModificar as PermisoModificar,
    CASE 
        WHEN u.VentPacientes = 1 THEN 'Puede ver pacientes'
        ELSE 'NO puede ver pacientes'
    END as PermisoPacientes
FROM dbo.Usuario u
WHERE u.dni = '55676837'

-- 6. VERIFICAR SI EL PACIENTE TIENE TIPO EXAMEN ASIGNADO
SELECT 
    'TIPO EXAMEN PACIENTE' as Tipo,
    tep.id as IdTipoExamenPaciente,
    tep.idEspecialidad,
    e.descripcion as Especialidad,
    tep.modificado,
    tep.precioExamen,
    CASE 
        WHEN tep.id IS NOT NULL THEN 'Tiene tipo de examen asignado'
        ELSE 'NO tiene tipo de examen asignado'
    END as EstadoTipoExamen
FROM dbo.TipoExamenDePaciente tep
INNER JOIN dbo.Turno t ON tep.idTurno = t.id
INNER JOIN dbo.Paciente p ON t.pacienteID = p.id
LEFT JOIN dbo.Especialidad e ON tep.idEspecialidad = e.id
WHERE p.dni = '55676837'

-- 7. VERIFICAR RELACIÓN COMPLETA USUARIO-PACIENTE-TURNO
SELECT 
    'RELACIÓN COMPLETA' as Tipo,
    u.username as Usuario,
    u.Activo as UsuarioActivo,
    p.dni as PacienteDNI,
    p.apellido + ' ' + p.nombres as PacienteNombre,
    COUNT(t.id) as CantidadTurnos,
    CASE 
        WHEN u.Activo = 1 AND p.id IS NOT NULL AND COUNT(t.id) > 0 
        THEN 'Todo correcto - debería aparecer'
        WHEN u.Activo = 0 
        THEN 'Usuario inactivo - podría ser el problema'
        WHEN p.id IS NULL 
        THEN 'Paciente no existe'
        WHEN COUNT(t.id) = 0 
        THEN 'No tiene turnos - no hay nada que mostrar'
        ELSE 'Revisar otros factores'
    END as Diagnostico
FROM dbo.Usuario u
LEFT JOIN dbo.Paciente p ON u.dni = p.dni
LEFT JOIN dbo.Turno t ON p.id = t.pacienteID
WHERE u.dni = '55676837'
GROUP BY u.username, u.Activo, p.dni, p.apellido, p.nombres

-- ========================================
-- ANÁLISIS:
-- Ejecuta esta consulta completa para determinar la causa exacta
-- de por qué el usuario no aparece en Exámenes Preventiva
-- ========================================
