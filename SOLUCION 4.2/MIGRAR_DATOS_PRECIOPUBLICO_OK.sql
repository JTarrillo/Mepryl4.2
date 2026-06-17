/* 
============================================================================
SCRIPT DE MIGRACIÓN DE DATOS DEFINITIVO: PRECIOPUBLICO (3DEJUNIO -> 17DEJUNIO)
============================================================================
*/

USE [17dejunio];
GO

TRUNCATE TABLE [17dejunio].[dbo].[PrecioPublico];

-- Ejecutamos la migración usando SQL dinámico para evitar caracteres especiales en el archivo .sql
DECLARE @sql NVARCHAR(MAX);
DECLARE @colName NVARCHAR(100);

-- Buscamos el nombre exacto de la columna que contiene la seña en la base 3dejunio
SELECT @colName = name 
FROM [3dejunio].sys.columns 
WHERE object_id = OBJECT_ID('[3dejunio].[dbo].[PrecioPublico]') 
AND (name LIKE 'se%a' OR name = 'sena');

SET @sql = '
INSERT INTO [17dejunio].[dbo].[PrecioPublico] (
    idEspecialidad, Descripcion, Mes, Anio, PrecioLista, PrecioPromo, 
    Seña, Coeficiente, CoeficienteIndividual, LlevaPlanilla, 
    ObservacionesExtra, FechaModificacion, Eliminado
)
SELECT 
    idEspecialidad, Descripcion, Mes, Anio, PrecioLista, PrecioPromo, 
    [' + @colName + '], 
    Coeficiente, CoeficienteIndividual, LlevaPlanilla, 
    ObservacionesExtra, FechaModificacion, Eliminado
FROM [3dejunio].[dbo].[PrecioPublico]';

EXEC sp_executesql @sql;

PRINT '--- Datos migrados correctamente desde 3dejunio ---';
SELECT COUNT(*) AS Registros FROM [17dejunio].[dbo].[PrecioPublico];
GO
