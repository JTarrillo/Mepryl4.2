/* 
============================================================================
BACKUP DE PACIENTES DE TABLA Usuario
============================================================================
Propósito: Crear backup de pacientes antes de eliminarlos de Usuario
Fecha: 28/07/2026
============================================================================
*/

USE [MEPRYLv2.1];
GO

-- Crear tabla de backup
IF OBJECT_ID('dbo.Usuario_Pacientes_Backup', 'U') IS NOT NULL
BEGIN
    PRINT 'La tabla de backup ya existe. Eliminándola...'
    DROP TABLE dbo.Usuario_Pacientes_Backup;
END
GO

SELECT * INTO dbo.Usuario_Pacientes_Backup
FROM dbo.Usuario
WHERE Tipo IN ('PACIENTE LABORAL', 'PACIENTE PREVENTIVA');

DECLARE @backupCount INT;
SELECT @backupCount = COUNT(*) FROM dbo.Usuario_Pacientes_Backup;
PRINT 'Backup creado con ' + CAST(@backupCount AS VARCHAR) + ' registros.';
GO

-- Verificar backup
SELECT 
    Tipo,
    COUNT(*) as Cantidad,
    SUM(CASE WHEN Activo = 1 THEN 1 ELSE 0 END) as Activos,
    SUM(CASE WHEN Activo = 0 THEN 1 ELSE 0 END) as Inactivos
FROM dbo.Usuario_Pacientes_Backup
GROUP BY Tipo;
GO

PRINT '=== Backup completado exitosamente ===';
GO
