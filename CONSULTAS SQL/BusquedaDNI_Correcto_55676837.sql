-- ========================================
-- BÚSQUEDA CORRECTA DEL DNI 55676837 EN REGISTROS ACTIVOS
-- Varela Benicio William Eliel
-- ========================================

-- 1. BÚSQUEDA EXACTA EN PACIENTE (REGISTROS ACTIVOS)
SELECT 
    'Paciente Preventiva - Activos' as TipoTabla,
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
  AND habilitado = 1

-- 2. BÚSQUEDA EXACTA EN PACIENTELABORAL (REGISTROS ACTIVOS)
SELECT 
    'Paciente Laboral - Activos' as TipoTabla,
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    fechaNacimiento,
    telefonos,
    celular,
    cuil,
    mail as Email,
    habilitado
FROM dbo.PacienteLaboral 
WHERE dni = '55676837'
  AND habilitado = 1

-- 3. BÚSQUEDA POR NOMBRE COMPLETO EN AMBAS TABLAS (ACTIVOS)
SELECT 
    'Paciente Preventiva - Por Nombre' as TipoTabla,
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    habilitado
FROM dbo.Paciente 
WHERE apellido = 'VARELA' 
  AND nombres LIKE '%BENICIO%WILLIAM%ELIEL%'
  AND habilitado = 1

UNION ALL

SELECT 
    'Paciente Laboral - Por Nombre' as TipoTabla,
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    habilitado
FROM dbo.PacienteLaboral 
WHERE apellido = 'VARELA' 
  AND nombres LIKE '%BENICIO%WILLIAM%ELIEL%'
  AND habilitado = 1

-- 4. BÚSQUEDA COMBINADA (TODOS LOS REGISTROS ACTIVOS)
SELECT 
    'Búsqueda Combinada - Activos' as TipoTabla,
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    habilitado
FROM dbo.Paciente 
WHERE (dni = '55676837' 
   OR (apellido = 'VARELA' AND nombres LIKE '%BENICIO%WILLIAM%ELIEL%'))
  AND habilitado = 1

UNION ALL

SELECT 
    'Búsqueda Combinada Laboral - Activos' as TipoTabla,
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    habilitado
FROM dbo.PacienteLaboral 
WHERE (dni = '55676837' 
   OR (apellido = 'VARELA' AND nombres LIKE '%BENICIO%WILLIAM%ELIEL%'))
  AND habilitado = 1

-- 5. VERIFICAR SI TIENE TURNO EL 05/09/2025
SELECT 
    'Verificación Turno 05/09/2025' as Tipo,
    t.id as IdTurno,
    t.fecha,
    t.horaReferencia as Hora,
    t.nroOrden as NroOrden,
    p.apellido + ' ' + p.nombres as Paciente,
    p.dni,
    te.descripcion as TipoExamen,
    prof.apellido + ' ' + prof.nombres as Profesional,
    e.descripcion as Estado
FROM dbo.Turno t
LEFT JOIN dbo.Paciente p ON t.pacienteID = p.id
LEFT JOIN dbo.PacienteLaboral pl ON t.pacienteID = pl.id
INNER JOIN dbo.Horario h ON t.horarioID = h.id
INNER JOIN dbo.Especialidad te ON h.especialidadID = te.id
INNER JOIN dbo.Profesional prof ON h.profesionalID = prof.id
INNER JOIN dbo.TurnoEstado e ON t.estadoID = e.id
WHERE CONVERT(date, t.fecha) = CONVERT(date, '05/09/2025', 105)
  AND (p.dni = '55676837' OR pl.dni = '55676837')
  AND (p.habilitado = 1 OR pl.habilitado = 1)

-- ========================================
-- ESTA CONSULTA BUSCARÁ EL DNI CORRECTO 55676837
-- SOLO EN REGISTROS ACTIVOS (habilitado = 1)
-- ========================================
