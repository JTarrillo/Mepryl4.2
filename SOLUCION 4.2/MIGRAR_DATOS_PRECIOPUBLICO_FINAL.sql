/* 
============================================================================
SCRIPT DE MIGRACIÓN DE DATOS (SIN Ñ EN EL ARCHIVO)
============================================================================
*/

USE [17dejunio];
GO

TRUNCATE TABLE [17dejunio].[dbo].[PrecioPublico];

DECLARE @sql NVARCHAR(MAX);
DECLARE @colNameDest NVARCHAR(100);
DECLARE @colNameOrig NVARCHAR(100);

-- Buscar nombre de columna en destino (17dejunio)
SELECT @colNameDest = name 
FROM [17dejunio].sys.columns 
WHERE object_id = OBJECT_ID('[17dejunio].[dbo].[PrecioPublico]') 
AND (name LIKE 'se%a' OR name = 'sena');

-- Buscar nombre de columna en origen (3dejunio)
SELECT @colNameOrig = name 
FROM [3dejunio].sys.columns 
WHERE object_id = OBJECT_ID('[3dejunio].[dbo].[PrecioPublico]') 
AND (name LIKE 'se%a' OR name = 'sena');

SET @sql = '
INSERT INTO [17dejunio].[dbo].[PrecioPublico] (
    idEspecialidad, Descripcion, Mes, Anio, PrecioLista, PrecioPromo, 
    [' + @colNameDest + '], 
    Coeficiente, CoeficienteIndividual, LlevaPlanilla, 
    ObservacionesExtra, FechaModificacion, Eliminado
)
SELECT 
    idEspecialidad, Descripcion, Mes, Anio, PrecioLista, PrecioPromo, 
    [' + @colNameOrig + '], 
    Coeficiente, CoeficienteIndividual, LlevaPlanilla, 
    ObservacionesExtra, FechaModificacion, Eliminado
FROM [3dejunio].[dbo].[PrecioPublico]';

EXEC sp_executesql @sql;

PRINT '--- Datos migrados correctamente ---';
SELECT COUNT(*) AS Registros FROM [17dejunio].[dbo].[PrecioPublico];
GO
