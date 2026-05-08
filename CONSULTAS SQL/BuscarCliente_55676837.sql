-- ========================================
-- BÚSQUEDA COMPLETA DEL CLIENTE 55676837
-- Varela Benicio William Eliel
-- Fecha de examen: 05/09/2025
-- ========================================

-- 1. BUSCAR EN TABLA PACIENTE (PREVENTIVA)
SELECT 
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    fechaNacimiento,
    telefonos,
    celular,
    Email,
    habilitado
FROM dbo.Paciente 
WHERE dni = '55676837'
   OR apellido LIKE '%Varela%' 
   AND nombres LIKE '%Benicio%William%Eliel%'

-- 2. BUSCAR EN TABLA PACIENTELABORAL (LABORAL)
SELECT 
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    fechaNacimiento,
    telefonos,
    celular,
    cuil,
    mail,
    habilitado
FROM dbo.PacienteLaboral 
WHERE dni = '55676837'
   OR apellido LIKE '%Varela%' 
   AND nombres LIKE '%Benicio%William%Eliel%'

-- 3. BUSCAR TURNOS POR DNI Y FECHA DE EXAMEN
SELECT 
    t.id as IdTurno,
    t.fecha,
    t.horaReferencia as Hora,
    t.nroOrden as NroOrden,
    t.pacienteID,
    p.apellido + ' ' + p.nombres as Paciente,
    p.dni,
    te.descripcion as TipoExamen,
    prof.apellido + ' ' + prof.nombres as Profesional,
    e.descripcion as Estado,
    t.observaciones
FROM dbo.Turno t
LEFT JOIN dbo.Paciente p ON t.pacienteID = p.id
LEFT JOIN dbo.PacienteLaboral pl ON t.pacienteID = pl.id
INNER JOIN dbo.Horario h ON t.horarioID = h.id
INNER JOIN dbo.Especialidad te ON h.especialidadID = te.id
INNER JOIN dbo.Profesional prof ON h.profesionalID = prof.id
INNER JOIN dbo.TurnoEstado e ON t.estadoID = e.id
WHERE CONVERT(date, t.fecha) = CONVERT(date, '05/09/2025', 105)
  AND (p.dni = '55676837' OR pl.dni = '55676837')

-- 4. BÚSQUEDA COMBINADA POR DNI Y NOMBRE
SELECT 
    'Paciente Preventiva' as TipoTabla,
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    fechaNacimiento,
    telefonos,
    celular,
    Email
FROM dbo.Paciente 
WHERE dni = '55676837'

UNION ALL

SELECT 
    'Paciente Laboral' as TipoTabla,
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    fechaNacimiento,
    telefonos,
    celular,
    mail as Email
FROM dbo.PacienteLaboral 
WHERE dni = '55676837'

-- 5. VERIFICAR SI EXISTEN REGISTROS ELIMINADOS O INACTIVOS
SELECT 
    'Paciente Preventiva - Inactivos' as TipoTabla,
    id,
    dni,
    apellido,
    nombres,
    habilitado
FROM dbo.Paciente 
WHERE (dni = '55676837' OR apellido LIKE '%Varela%')
  AND habilitado = 0

UNION ALL

SELECT 
    'Paciente Laboral - Inactivos' as TipoTabla,
    id,
    dni,
    apellido,
    nombres,
    habilitado
FROM dbo.PacienteLaboral 
WHERE (dni = '55676837' OR apellido LIKE '%Varela%')
  AND habilitado = 0

-- 6. BÚSQUEDA EN HISTÓRICO DE TURNOS (SI EXISTE TABLA DE AUDITORÍA)
SELECT 
    t.id,
    t.fecha,
    p.apellido + ' ' + p.nombres as Paciente,
    p.dni,
    te.descripcion as TipoExamen,
    'Turno encontrado' as Status
FROM dbo.Turno t
LEFT JOIN dbo.Paciente p ON t.pacienteID = p.id
LEFT JOIN dbo.PacienteLaboral pl ON t.pacienteID = pl.id
INNER JOIN dbo.Horario h ON t.horarioID = h.id
INNER JOIN dbo.Especialidad te ON h.especialidadID = te.id
WHERE (p.dni = '55676837' OR pl.dni = '55676837')
  AND t.fecha BETWEEN '2025-09-01' AND '2025-09-30'
ORDER BY t.fecha DESC

-- ========================================
-- CONEXIÓN A LA BASE DE DATOS:
-- Data Source=192.168.1.254;Persist Security Info=False;
-- User ID=user;Password=Mepryl22;Pooling=False;
-- MultipleActiveResultSets=False;Encrypt=True;
-- TrustServerCertificate=True;Application Name="SQL Server Management Studio";
-- Command Timeout=30
-- ========================================
