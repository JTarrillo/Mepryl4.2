/* 
============================================================================
SCRIPT DE MIGRACIÓN DE DATOS DEFINITIVO (COMPATIBILIDAD ASCII)
============================================================================
*/

USE [17dejunio];
GO

TRUNCATE TABLE [17dejunio].[dbo].[PrecioPromo];

-- Ejecutamos la migración usando SQL dinámico para evitar caracteres especiales en el archivo .sql
DECLARE @sql NVARCHAR(MAX);
DECLARE @colName NVARCHAR(100);

-- Buscamos el nombre exacto de la columna que contiene la seña en la base 3dejunio
-- Filtramos por el nombre que contenga 'se' y 'a' (para encontrar 'seña')
SELECT @colName = name 
FROM [3dejunio].sys.columns 
WHERE object_id = OBJECT_ID('[3dejunio].[dbo].[PrecioPromo]') 
AND (name LIKE 'se%a' OR name = 'sena');

SET @sql = '
INSERT INTO [17dejunio].[dbo].[PrecioPromo] (
    idEspecialidad, Descripcion, Mes, Anio, PrecioPromo, Sena, 
    LlevaPlanilla, ObservacionesExtra, CoeficienteIndividual, 
    FechaModificacion, Eliminado
)
SELECT 
    idEspecialidad, Descripcion, Mes, Anio, PrecioPromo, 
    [' + @colName + '], 
    LlevaPlanilla, ObservacionesExtra, CoeficienteIndividual, 
    FechaModificacion, Eliminado
FROM [3dejunio].[dbo].[PrecioPromo]';

EXEC sp_executesql @sql;

PRINT '--- Datos migrados correctamente desde 3dejunio ---';
SELECT COUNT(*) AS Registros FROM [17dejunio].[dbo].[PrecioPromo];
GO
