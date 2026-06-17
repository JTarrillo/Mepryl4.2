/* 
============================================================================
MIGRACIÓN DE DATOS PRECIOPUBLICO (CORREGIDA)
============================================================================
*/

USE [17dejunio];
GO

TRUNCATE TABLE [17dejunio].[dbo].[PrecioPublico];

DECLARE @sql NVARCHAR(MAX);
DECLARE @colNameDest NVARCHAR(100);
DECLARE @colNameOrig NVARCHAR(100);

-- Buscar nombre de columna de seña
SELECT @colNameDest = name FROM [17dejunio].sys.columns 
WHERE object_id = OBJECT_ID('[17dejunio].[dbo].[PrecioPublico]') AND (name LIKE 'se%a' OR name = 'sena');

SELECT @colNameOrig = name FROM [3dejunio].sys.columns 
WHERE object_id = OBJECT_ID('[3dejunio].[dbo].[PrecioPublico]') AND (name LIKE 'se%a' OR name = 'sena');

SET @sql = '
INSERT INTO [17dejunio].[dbo].[PrecioPublico] (
    idEspecialidad, Descripcion, Mes, Anio, PrecioLista, 
    [' + @colNameDest + '], 
    Coeficiente, CoeficienteIndividual, LlevaPlanilla, 
    ObservacionesExtra, FechaModificacion, Eliminado
)
SELECT 
    idEspecialidad, Descripcion, Mes, Anio, PrecioLista, 
    [' + @colNameOrig + '], 
    Coeficiente, CoeficienteIndividual, LlevaPlanilla, 
    ObservacionesExtra, FechaModificacion, Eliminado
FROM [3dejunio].[dbo].[PrecioPublico]';

PRINT 'Migrando datos...';
EXEC sp_executesql @sql;

PRINT 'Registros migrados: ' + CAST(@@ROWCOUNT AS VARCHAR);
GO
