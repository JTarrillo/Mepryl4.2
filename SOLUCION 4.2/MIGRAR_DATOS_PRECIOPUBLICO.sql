/* 
============================================================================
SCRIPT DE MIGRACIÓN DE DATOS: PRECIOPUBLICO (3DEJUNIO -> 17DEJUNIO)
============================================================================
*/

USE [17dejunio];
GO

TRUNCATE TABLE [17dejunio].[dbo].[PrecioPublico];

-- Usamos SQL dinámico para manejar la columna Seña/Sena con Ñ en PrecioPublico
DECLARE @sql NVARCHAR(MAX);
DECLARE @colName NVARCHAR(100);

SELECT @colName = name 
FROM [3dejunio].sys.columns 
WHERE object_id = OBJECT_ID('[3dejunio].[dbo].[PrecioPublico]') 
AND (name LIKE 'se%a' OR name = 'sena');

SET @sql = '
INSERT INTO [17dejunio].[dbo].[PrecioPublico] (
    idEspecialidad, 
    Descripcion, 
    Mes, 
    Anio, 
    PrecioLista, 
    PrecioPromo, 
    Seña, 
    Coeficiente, 
    CoeficienteIndividual, 
    LlevaPlanilla, 
    ObservacionesExtra, 
    FechaModificacion, 
    Eliminado
)
SELECT 
    idEspecialidad, 
    Descripcion, 
    Mes, 
    Anio, 
    PrecioLista, 
    PrecioPromo, 
    [' + @colName + '], 
    Coeficiente, 
    CoeficienteIndividual, 
    LlevaPlanilla, 
    ObservacionesExtra, 
    FechaModificacion, 
    Eliminado
FROM [3dejunio].[dbo].[PrecioPublico]';

EXEC sp_executesql @sql;

PRINT '--- Datos migrados correctamente en PrecioPublico ---';
SELECT COUNT(*) AS Registros FROM [17dejunio].[dbo].[PrecioPublico];
GO
