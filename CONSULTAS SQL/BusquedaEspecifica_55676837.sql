-- ========================================
-- BÚSQUEDA ESPECÍFICA DEL CLIENTE 55676837
-- Varela Benicio William Eliel
-- ========================================

-- 1. BÚSQUEDA EXACTA POR DNI 55676837
SELECT 
    'Búsqueda Exacta DNI' as Tipo,
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    habilitado
FROM dbo.Paciente 
WHERE dni = '55676837'

UNION ALL

SELECT 
    'Búsqueda Exacta DNI Laboral' as Tipo,
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    habilitado
FROM dbo.PacienteLaboral 
WHERE dni = '55676837'

-- 2. BÚSQUEDA POR NOMBRE COMPLETO
SELECT 
    'Búsqueda Nombre Completo' as Tipo,
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    habilitado
FROM dbo.Paciente 
WHERE apellido = 'VARELA' 
  AND nombres LIKE '%BENICIO%WILLIAM%ELIEL%'

UNION ALL

SELECT 
    'Búsqueda Nombre Completo Laboral' as Tipo,
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    habilitado
FROM dbo.PacienteLaboral 
WHERE apellido = 'VARELA' 
  AND nombres LIKE '%BENICIO%WILLIAM%ELIEL%'

-- 3. BÚSQUEDA POR PARTES DEL NOMBRE
SELECT 
    'Búsqueda por Partes' as Tipo,
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    habilitado
FROM dbo.Paciente 
WHERE apellido = 'VARELA' 
  AND (nombres LIKE '%BENICIO%' 
       OR nombres LIKE '%WILLIAM%'
       OR nombres LIKE '%ELIEL%')

UNION ALL

SELECT 
    'Búsqueda por Partes Laboral' as Tipo,
    id,
    dni,
    apellido,
    nombres,
    apellido + ' ' + nombres as NombreCompleto,
    habilitado
FROM dbo.PacienteLaboral 
WHERE apellido = 'VARELA' 
  AND (nombres LIKE '%BENICIO%' 
       OR nombres LIKE '%WILLIAM%'
       OR nombres LIKE '%ELIEL%')

-- 4. VERIFICAR SI EXISTE TURNO ASIGNADO A ESE DNI
SELECT 
    'Verificación Turno' as Tipo,
    t.id as IdTurno,
    t.fecha,
    t.pacienteID,
    'DNI no encontrado en paciente' as Observacion
FROM dbo.Turno t
WHERE CONVERT(date, t.fecha) = CONVERT(date, '05/09/2025', 105)
  AND t.pacienteID IS NOT NULL
  AND NOT EXISTS (
      SELECT 1 FROM dbo.Paciente p WHERE p.id = t.pacienteID
  )
  AND NOT EXISTS (
      SELECT 1 FROM dbo.PacienteLaboral pl WHERE pl.id = t.pacienteID
  )

-- 5. BÚSQUEDA EN TODAS LAS TABLAS POSIBLES
SELECT 
    'Posible Coincidencia' as Tipo,
    id,
    dni,
    apellido,
    nombres,
    'Revisar manualmente' as Observacion
FROM dbo.Paciente 
WHERE dni LIKE '%5567%'  -- Búsqueda por similitud
   OR (apellido = 'VARELA' AND nombres LIKE '%B%')

UNION ALL

SELECT 
    'Posible Coincidencia Laboral' as Tipo,
    id,
    dni,
    apellido,
    nombres,
    'Revisar manualmente' as Observacion
FROM dbo.PacienteLaboral 
WHERE dni LIKE '%5567%'  -- Búsqueda por similitud
   OR (apellido = 'VARELA' AND nombres LIKE '%B%')
