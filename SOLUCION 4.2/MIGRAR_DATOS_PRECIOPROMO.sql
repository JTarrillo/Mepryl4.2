/* 
============================================================================
SCRIPT DE MIGRACIÓN DE DATOS: PRECIOPROMO (3DEJUNIO -> 17DEJUNIO)
============================================================================
Propósito: Copiar los datos de precios promocionales entre bases de datos.
Fecha: 17/06/2026
============================================================================
*/

USE [17dejunio];
GO

PRINT '--- Iniciando migración de datos de PrecioPromo ---';

-- Habilitar inserción en columnas IDENTITY si fuera necesario (aunque usaremos el default del destino para evitar colisiones)
-- Pero como queremos una copia fiel, lo ideal es limpiar y copiar.

-- 1. Limpiar datos existentes en el destino para evitar duplicados
TRUNCATE TABLE [17dejunio].[dbo].[PrecioPromo];

-- 2. Insertar datos desde 3dejunio
-- Nota: Usamos nombres de columnas explícitos para asegurar compatibilidad
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
    Sena, 
    LlevaPlanilla, 
    ObservacionesExtra, 
    CoeficienteIndividual, 
    FechaModificacion, 
    Eliminado
FROM [3dejunio].[dbo].[PrecioPromo];

PRINT '--- Migración de datos completada ---';
SELECT COUNT(*) AS RegistrosMigrados FROM [17dejunio].[dbo].[PrecioPromo];
GO
