/* 
============================================================================
DEBUG MIGRACIÓN PRECIOPUBLICO
============================================================================
*/

USE [17dejunio];
GO

DECLARE @sql NVARCHAR(MAX);
DECLARE @colNameDest NVARCHAR(100);
DECLARE @colNameOrig NVARCHAR(100);

SELECT @colNameDest = name 
FROM [17dejunio].sys.columns 
WHERE object_id = OBJECT_ID('[17dejunio].[dbo].[PrecioPublico]') 
AND (name LIKE 'se%a' OR name = 'sena');

SELECT @colNameOrig = name 
FROM [3dejunio].sys.columns 
WHERE object_id = OBJECT_ID('[3dejunio].[dbo].[PrecioPublico]') 
AND (name LIKE 'se%a' OR name = 'sena');

PRINT 'Columna Destino: ' + ISNULL(@colNameDest, 'NULL');
PRINT 'Columna Origen: ' + ISNULL(@colNameOrig, 'NULL');

IF @colNameDest IS NOT NULL AND @colNameOrig IS NOT NULL
BEGIN
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
    
    PRINT 'Ejecutando SQL...';
    EXEC sp_executesql @sql;
    PRINT 'Registros insertados: ' + CAST(@@ROWCOUNT AS VARCHAR);
END
ELSE
BEGIN
    PRINT 'ERROR: No se encontraron las columnas de seña.';
END
GO
