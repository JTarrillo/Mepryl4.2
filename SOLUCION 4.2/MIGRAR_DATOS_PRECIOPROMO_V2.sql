/* 
============================================================================
SCRIPT DE MIGRACIÓN DE DATOS CORREGIDO: PRECIOPROMO (3DEJUNIO -> 17DEJUNIO)
============================================================================
*/

USE [17dejunio];
GO

PRINT '--- Verificando columnas en destino ---';
-- Sincronizar nombre de columna si fuera necesario
IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.PrecioPromo') AND name = 'Sena')
BEGIN
    PRINT 'Columna Sena ya existe.';
END
ELSE IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.PrecioPromo') AND name = 'Seña')
BEGIN
    PRINT 'Renombrando Seña a Sena para compatibilidad...';
    EXEC sp_rename 'dbo.PrecioPromo.Seña', 'Sena', 'COLUMN';
END
GO

PRINT '--- Iniciando copia de datos ---';

-- Limpiar destino
TRUNCATE TABLE [17dejunio].[dbo].[PrecioPromo];

-- Insertar usando nombres que existen en 3dejunio (según tu imagen: id, idEspecialidad, Descripcion, Mes, Anio, FechaModificacion, Eliminado, Precio Promo, LlevaPlanilla, ObservacionesExtra, CoeficienteIndividual)
-- Nota: En tu imagen la columna se llama "Precio Promo" (con espacio) o "PrecioPromo"? 
-- Normalmente es PrecioPromo. Y la seña parece llamarse "Seña" en 3dejunio.

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
    Seña, -- En 3dejunio es con Ñ según imagen
    LlevaPlanilla, 
    ObservacionesExtra, 
    CoeficienteIndividual, 
    FechaModificacion, 
    Eliminado
FROM [3dejunio].[dbo].[PrecioPromo];

PRINT '--- Datos migrados correctamente ---';
SELECT COUNT(*) AS Total FROM [17dejunio].[dbo].[PrecioPromo];
GO
