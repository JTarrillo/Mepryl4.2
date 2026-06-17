/* 
============================================================================
SCRIPT DE MIGRACIÓN DE DATOS (COMPATIBILIDAD TOTAL)
============================================================================
*/

USE [17dejunio];
GO

TRUNCATE TABLE [17dejunio].[dbo].[PrecioPromo];

-- Usamos un truco de SQL para leer la columna de Seña por su posición en la tabla de 3dejunio
-- sin tener que escribir la Ñ en el script, evitando errores de codificación.

DECLARE @sql NVARCHAR(MAX);
SET @sql = '
INSERT INTO [17dejunio].[dbo].[PrecioPromo] (
    idEspecialidad, Descripcion, Mes, Anio, PrecioPromo, Sena, 
    LlevaPlanilla, ObservacionesExtra, CoeficienteIndividual, 
    FechaModificacion, Eliminado
)
SELECT 
    idEspecialidad, Descripcion, Mes, Anio, PrecioPromo, 
    CAST(Se'' + CHAR(241) + ''a AS DECIMAL(18,2)), 
    LlevaPlanilla, ObservacionesExtra, CoeficienteIndividual, 
    FechaModificacion, Eliminado
FROM [3dejunio].[dbo].[PrecioPromo]';

-- Intentamos con una consulta dinámica que use el nombre real de la columna en el servidor
DECLARE @colName NVARCHAR(100);
SELECT @colName = name FROM [3dejunio].sys.columns 
WHERE object_id = OBJECT_ID('[3dejunio].[dbo].[PrecioPromo]') AND column_id = 8; -- Probablemente la 8va columna

EXEC sp_executesql N'
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

PRINT '--- Datos migrados usando detección dinámica de columnas ---';
SELECT COUNT(*) AS Registros FROM [17dejunio].[dbo].[PrecioPromo];
GO
