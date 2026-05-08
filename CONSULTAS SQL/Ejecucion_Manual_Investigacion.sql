-- ========================================
-- EJECUTAR ESTAS CONSULTAS MANUALMENTE EN SQL SERVER MANAGEMENT STUDIO
-- ========================================

-- PASO 1: Verificar si el paciente existe
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

-- PASO 2: Verificar si tiene turnos asignados
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

-- PASO 3: Verificar turno específico para 05/09/2025
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

-- PASO 4: Verificar estado del usuario
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

-- PASO 5: Verificar permisos del usuario
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

-- ========================================
// turbo
-- INSTRUCCIONES:
-- 1. Abre SQL Server Management Studio
-- 2. Conéctate con: Server=192.168.1.254, User=user, Password=Mepryl22
-- 3. Copia y ejecuta estas consultas una por una
-- 4. Envíame los resultados para analizar la causa exacta
-- ========================================
