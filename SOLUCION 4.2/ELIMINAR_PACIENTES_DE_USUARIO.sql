/* 
============================================================================
ELIMINACIÓN DE PACIENTES DE TABLA Usuario
============================================================================
Propósito: Eliminar pacientes de tabla Usuario (ya migrados a UsuarioTipoPaciente)
Fecha: 28/07/2026
============================================================================
*/

USE [MEPRYLv2.1];
GO

PRINT '=== Verificando pacientes a eliminar ===';
SELECT 
    Tipo,
    COUNT(*) as Cantidad
FROM dbo.Usuario
WHERE Tipo IN ('PACIENTE LABORAL', 'PACIENTE PREVENTIVA')
GROUP BY Tipo;
GO

PRINT '';
PRINT '=== Eliminando pacientes de tabla Usuario ===';
DELETE FROM dbo.Usuario
WHERE Tipo IN ('PACIENTE LABORAL', 'PACIENTE PREVENTIVA');

DECLARE @eliminados INT = @@ROWCOUNT;
PRINT 'Pacientes eliminados: ' + CAST(@eliminados AS VARCHAR);
GO

PRINT '';
PRINT '=== Verificando tabla Usuario después de eliminación ===';
SELECT 
    Tipo,
    COUNT(*) as Cantidad
FROM dbo.Usuario
GROUP BY Tipo
ORDER BY Cantidad DESC;
GO

PRINT '';
PRINT '=== Eliminación completada ===';
PRINT 'Para restaurar, ejecutar: INSERT INTO Usuario SELECT * FROM Usuario_Pacientes_Backup';
GO
