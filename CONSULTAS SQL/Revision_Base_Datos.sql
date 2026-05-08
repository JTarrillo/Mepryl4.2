-- ========================================
-- REVISIÓN COMPLETA DE BASE DE DATOS MEPRYLv2.1
-- Fecha: 07/05/2026
-- ========================================

-- 1. VERIFICAR ESTRUCTURA GENERAL
SELECT 
    'TABLAS PRINCIPALES' as Tipo,
    TABLE_NAME as NombreTabla,
    TABLE_TYPE as TipoTabla
FROM INFORMATION_SCHEMA.TABLES 
WHERE TABLE_TYPE = 'BASE TABLE'
  AND TABLE_NAME IN ('Usuario', 'Paciente', 'Consulta', 'TipoExamenDePaciente', 'ExamenPreventiva', 'TipoExamen', 'Club', 'Especialidad')
ORDER BY TABLE_NAME

-- 2. VERIFICAR REGISTROS POR TABLA
SELECT 
    'CONTADOR DE REGISTROS' as Tipo,
    'Usuario' as Tabla,
    COUNT(*) as CantidadRegistros
FROM dbo.Usuario
UNION ALL
SELECT 
    'Paciente' as Tabla,
    COUNT(*) as CantidadRegistros
FROM dbo.Paciente
UNION ALL
SELECT 
    'Consulta' as Tabla,
    COUNT(*) as CantidadRegistros
FROM dbo.Consulta
UNION ALL
SELECT 
    'TipoExamenDePaciente' as Tabla,
    COUNT(*) as CantidadRegistros
FROM dbo.TipoExamenDePaciente
UNION ALL
SELECT 
    'ExamenPreventiva' as Tabla,
    COUNT(*) as CantidadRegistros
FROM dbo.ExamenPreventiva
UNION ALL
SELECT 
    'TipoExamen' as Tabla,
    COUNT(*) as CantidadRegistros
FROM dbo.TipoExamen
UNION ALL
SELECT 
    'Club' as Tabla,
    COUNT(*) as CantidadRegistros
FROM dbo.Club
UNION ALL
SELECT 
    'Especialidad' as Tabla,
    COUNT(*) as CantidadRegistros
FROM dbo.Especialidad

-- 3. VERIFICAR INTEGRIDAD DE REFERENCIAS
SELECT 
    'INTEGRIDAD REFERENCIAL' as Tipo,
    'Paciente sin Usuario' as Problema,
    COUNT(*) as Cantidad
FROM dbo.Paciente p
WHERE NOT EXISTS (SELECT 1 FROM dbo.Usuario u WHERE u.dni = p.dni)
UNION ALL
SELECT 
    'Consulta sin Paciente' as Problema,
    COUNT(*) as Cantidad
FROM dbo.Consulta c
WHERE NOT EXISTS (SELECT 1 FROM dbo.Paciente p WHERE p.id = c.pacienteID)
UNION ALL
SELECT 
    'TipoExamenDePaciente sin Consulta' as Problema,
    COUNT(*) as Cantidad
FROM dbo.TipoExamenDePaciente tep
WHERE NOT EXISTS (SELECT 1 FROM dbo.Consulta c WHERE c.id = tep.idConsulta)
UNION ALL
SELECT 
    'ExamenPreventiva sin TipoExamenDePaciente' as Problema,
    COUNT(*) as Cantidad
FROM dbo.ExamenPreventiva ep
WHERE NOT EXISTS (SELECT 1 FROM dbo.TipoExamenDePaciente tep WHERE tep.id = ep.idTipoExamen)

-- 4. VERIFICAR DUPLICADOS CRÍTICOS
SELECT 
    'DUPLICADOS USUARIOS' as Tipo,
    dni,
    COUNT(*) as CantidadDuplicados
FROM dbo.Usuario
GROUP BY dni
HAVING COUNT(*) > 1
UNION ALL
SELECT 
    'DUPLICADOS PACIENTES' as Tipo,
    dni,
    COUNT(*) as CantidadDuplicados
FROM dbo.Paciente
GROUP BY dni
HAVING COUNT(*) > 1

-- 5. VERIFICAR ESTADO DE VARELA (CASO ACTUAL)
SELECT 
    'VERIFICACIÓN VARELA' as Tipo,
    'Usuario' as Tabla,
    u.id,
    u.dni,
    u.apellido + ' ' + u.nombre as NombreCompleto,
    u.Activo as Estado
FROM dbo.Usuario u
WHERE u.dni = '55676837'
UNION ALL
SELECT 
    'Paciente' as Tabla,
    p.id,
    p.dni,
    p.apellido + ' ' + p.nombres as NombreCompleto,
    'OK' as Estado
FROM dbo.Paciente p
WHERE p.dni = '55676837'
UNION ALL
SELECT 
    'Consulta' as Tabla,
    c.id,
    p.dni,
    p.apellido + ' ' + p.nombres as NombreCompleto,
    c.identificador as ExamenNro
FROM dbo.Consulta c
INNER JOIN dbo.Paciente p ON c.pacienteID = p.id
WHERE p.dni = '55676837'
  AND c.tipo = 'P'

-- ========================================
// turbo
// ESTA REVISIÓN CUBRE:
// 1. Estructura general de tablas
// 2. Conteo de registros por tabla
// 3. Integridad referencial
// 4. Duplicados críticos
// 5. Estado del caso Varela
// ========================================
