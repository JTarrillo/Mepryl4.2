/* 
============================================================================
SCRIPT DE MIGRACIÓN DE DATOS: CONFIGPRECIOESPECIALIDAD (3DEJUNIO -> 17DEJUNIO)
============================================================================
*/

USE [17dejunio];
GO

TRUNCATE TABLE [17dejunio].[dbo].[ConfigPrecioEspecialidad];

-- Usamos SQL dinámico para manejar la columna Seña/Sena con Ñ
DECLARE @sql NVARCHAR(MAX);
DECLARE @colName NVARCHAR(100);

SELECT @colName = name 
FROM [3dejunio].sys.columns 
WHERE object_id = OBJECT_ID('[3dejunio].[dbo].[ConfigPrecioEspecialidad]') 
AND (name LIKE 'se%a' OR name = 'sena');

SET @sql = '
INSERT INTO [17dejunio].[dbo].[ConfigPrecioEspecialidad] (
    idEspecialidad, Sena, LlevaPlanilla, Observaciones, FechaModificacion
)
SELECT 
    idEspecialidad, 
    [' + @colName + '], 
    LlevaPlanilla, 
    Observaciones, 
    FechaModificacion
FROM [3dejunio].[dbo].[ConfigPrecioEspecialidad]';

EXEC sp_executesql @sql;

PRINT '--- Datos migrados correctamente en ConfigPrecioEspecialidad ---';
SELECT COUNT(*) AS Registros FROM [17dejunio].[dbo].[ConfigPrecioEspecialidad];
GO
