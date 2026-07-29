/* 
============================================================================
MIGRACIÓN DE PACIENTES DE Usuario A UsuarioTipoPaciente
============================================================================
Propósito: Migrar pacientes de tabla Usuario a UsuarioTipoPaciente
Fecha: 28/07/2026
============================================================================
*/

USE [MEPRYLv2.1];
GO

PRINT '=== Iniciando migración de pacientes ===';
PRINT '';

-- Paso 1: Migrar PACIENTE LABORAL
PRINT 'Paso 1: Migrando PACIENTE LABORAL...';
INSERT INTO dbo.UsuarioTipoPaciente
    (id, username, password, dni, apellido, nombre, Tipo, Activo, fechaCreacion)
SELECT 
    id,
    username + CASE 
        WHEN ROW_NUMBER() OVER (PARTITION BY username ORDER BY id) > 1 
        THEN '_' + CAST(ROW_NUMBER() OVER (PARTITION BY username ORDER BY id) AS VARCHAR)
        ELSE '' 
    END as username,
    password,
    dni,
    apellido,
    nombre,
    'LABORAL' as Tipo,
    Activo,
    fechaCreacion
FROM dbo.Usuario
WHERE Tipo = 'PACIENTE LABORAL';

DECLARE @laboralMigrados INT = @@ROWCOUNT;
PRINT 'PACIENTE LABORAL migrados: ' + CAST(@laboralMigrados AS VARCHAR);
GO

-- Paso 2: Migrar PACIENTE PREVENTIVA
PRINT 'Paso 2: Migrando PACIENTE PREVENTIVA...';
INSERT INTO dbo.UsuarioTipoPaciente
    (id, username, password, dni, apellido, nombre, Tipo, Activo, fechaCreacion)
SELECT 
    id,
    username + CASE 
        WHEN ROW_NUMBER() OVER (PARTITION BY username ORDER BY id) > 1 
        THEN '_' + CAST(ROW_NUMBER() OVER (PARTITION BY username ORDER BY id) AS VARCHAR)
        ELSE '' 
    END as username,
    password,
    dni,
    apellido,
    nombre,
    'PREVENTIVA' as Tipo,
    Activo,
    fechaCreacion
FROM dbo.Usuario
WHERE Tipo = 'PACIENTE PREVENTIVA';

DECLARE @preventivaMigrados INT = @@ROWCOUNT;
PRINT 'PACIENTE PREVENTIVA migrados: ' + CAST(@preventivaMigrados AS VARCHAR);
GO

-- Paso 3: Verificar migración
PRINT '';
PRINT '=== Verificación de migración ===';
SELECT 
    Tipo,
    COUNT(*) as Cantidad,
    SUM(CASE WHEN Activo = 1 THEN 1 ELSE 0 END) as Activos,
    SUM(CASE WHEN Activo = 0 THEN 1 ELSE 0 END) as Inactivos
FROM dbo.UsuarioTipoPaciente
GROUP BY Tipo;
GO

PRINT '';
PRINT '=== Migración completada ===';
DECLARE @totalMigrados INT;
SELECT @totalMigrados = COUNT(*) FROM dbo.UsuarioTipoPaciente;
PRINT 'Total pacientes migrados: ' + CAST(@totalMigrados AS VARCHAR);
GO

-- Paso 4: Opcional - Eliminar pacientes de tabla Usuario (COMENTADO POR SEGURIDAD)
-- PRINT '';
-- PRINT 'ADVERTENCIA: A continuación se eliminarán los pacientes de la tabla Usuario';
-- PRINT 'Presione Ctrl+C para cancelar si no está seguro';
-- WAITFOR DELAY '00:00:05'; -- 5 segundos para cancelar
-- 
-- DELETE FROM dbo.Usuario WHERE Tipo IN ('PACIENTE LABORAL', 'PACIENTE PREVENTIVA');
-- PRINT 'Pacientes eliminados de tabla Usuario';
-- GO
