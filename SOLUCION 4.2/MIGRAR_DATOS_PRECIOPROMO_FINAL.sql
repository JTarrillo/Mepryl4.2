/* 
============================================================================
SCRIPT DE MIGRACIÓN DE DATOS FINAL (SIN CARACTERES ESPECIALES)
============================================================================
*/

USE [17dejunio];
GO

PRINT '--- Iniciando copia de datos limpia ---';

-- Limpiar destino
TRUNCATE TABLE [17dejunio].[dbo].[PrecioPromo];

-- Ejecutar la inserción usando alias para evitar la Ñ en el código del script
-- La base de datos 3dejunio tiene la columna con Ñ, pero la leeremos por posición o alias
-- si sqlcmd falla. Intentaremos usar las comillas dobles para la Ñ.

INSERT INTO [17dejunio].[dbo].[PrecioPromo] (
    idEspecialidad, 
    Descripcion, 
    Mes, 
    Anio, 
    PrecioPromo, 
    Sena, 
    LlevaPlanilla, 
    ObservacionesExtra, 
    CoeficienteIndividual, 
    FechaModificacion, 
    Eliminado
)
SELECT 
    idEspecialidad, 
    Descripcion, 
    Mes, 
    Anio, 
    PrecioPromo, 
    [Seña], -- Usando corchetes para la Ñ
    LlevaPlanilla, 
    ObservacionesExtra, 
    CoeficienteIndividual, 
    FechaModificacion, 
    Eliminado
FROM [3dejunio].[dbo].[PrecioPromo];

PRINT '--- Datos migrados exitosamente ---';
SELECT COUNT(*) AS Registros FROM [17dejunio].[dbo].[PrecioPromo];
GO
