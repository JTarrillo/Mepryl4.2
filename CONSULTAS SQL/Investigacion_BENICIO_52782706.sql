-- ========================================
-- INVESTIGACIÓN DEL REGISTRO BENICIO DNI 52782706
-- Posible coincidencia con Varela Benicio William Eliel
-- ========================================

-- 1. INFORMACIÓN COMPLETA DEL REGISTRO BENICIO
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
    habilitado,
    'Paciente Preventiva' as TipoRegistro
FROM dbo.Paciente 
WHERE dni = '52782706'

-- 2. VERIFICAR SI TIENE TURNOS ASIGNADOS
SELECT 
    t.id as IdTurno,
    t.fecha,
    t.horaReferencia as Hora,
    t.nroOrden as NroOrden,
    t.observaciones,
    te.descripcion as TipoExamen,
    prof.apellido + ' ' + prof.nombres as Profesional,
    e.descripcion as EstadoTurno
FROM dbo.Turno t
INNER JOIN dbo.Horario h ON t.horarioID = h.id
INNER JOIN dbo.Especialidad te ON h.especialidadID = te.id
INNER JOIN dbo.Profesional prof ON h.profesionalID = prof.id
INNER JOIN dbo.TurnoEstado e ON t.estadoID = e.id
WHERE t.pacienteID = (SELECT id FROM dbo.Paciente WHERE dni = '52782706')
ORDER BY t.fecha DESC

-- 3. VERIFICAR SI TIENE TURNO ESPECÍFICO EL 05/09/2025
SELECT 
    t.id as IdTurno,
    t.fecha,
    t.horaReferencia as Hora,
    t.nroOrden as NroOrden,
    t.observaciones,
    te.descripcion as TipoExamen,
    prof.apellido + ' ' + prof.nombres as Profesional,
    e.descripcion as EstadoTurno,
    'POSIIBLE COINCIDENCIA' as Alerta
FROM dbo.Turno t
INNER JOIN dbo.Horario h ON t.horarioID = h.id
INNER JOIN dbo.Especialidad te ON h.especialidadID = te.id
INNER JOIN dbo.Profesional prof ON h.profesionalID = prof.id
INNER JOIN dbo.TurnoEstado e ON t.estadoID = e.id
WHERE t.pacienteID = (SELECT id FROM dbo.Paciente WHERE dni = '52782706')
  AND CONVERT(date, t.fecha) = CONVERT(date, '05/09/2025', 105)

-- 4. BUSCAR OTROS REGISTROS CON NOMBRES SIMILARES
SELECT 
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    habilitado,
    'Nombre Similar' as TipoCoincidencia
FROM dbo.Paciente 
WHERE nombres LIKE '%BENICIO%'
   OR nombres LIKE '%WILLIAM%'
   OR nombres LIKE '%ELIEL%'
ORDER BY nombres

-- 5. BUSCAR REGISTROS CON APELLIDO VARELA Y NOMBRES SIMILARES
SELECT 
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    habilitado,
    'Apellido Varela + Nombre Similar' as TipoCoincidencia
FROM dbo.Paciente 
WHERE apellido = 'VARELA'
  AND (nombres LIKE '%B%' 
       OR nombres LIKE '%W%'
       OR nombres LIKE '%E%')
ORDER BY nombres

-- 6. VERIFICAR SI EXISTE EN PACIENTELABORAL
SELECT 
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    fechaNacimiento,
    cuil,
    mail,
    habilitado,
    'Paciente Laboral' as TipoRegistro
FROM dbo.PacienteLaboral 
WHERE dni = '52782706'
   OR nombres LIKE '%BENICIO%'
   OR nombres LIKE '%WILLIAM%'
   OR nombres LIKE '%ELIEL%'

-- 7. COMPARACIÓN DE DNIS POSIBLES
SELECT 
    'DNI Reportado' as Tipo,
    '55676837' as DNI,
    'Varela Benicio William Eliel' as NombreCompleto,
    'Cliente buscado' as Observacion

UNION ALL

SELECT 
    'DNI Encontrado' as Tipo,
    dni as DNI,
    apellido + ' ' + nombres as NombreCompleto,
    'Posible mismo cliente con DNI incorrecto' as Observacion
FROM dbo.Paciente 
WHERE dni = '52782706'

-- ========================================
-- RECOMENDACIONES:
-- 1. Verificar si el cliente con DNI 52782706 tiene turno el 05/09/2025
-- 2. Confirmar si es la misma persona preguntando por datos adicionales
-- 3. Si es la misma persona, corregir el DNI en el sistema
-- ========================================
