-- Agregar columna HoraSalida a la tabla EstadosCheckboxesMesaEntrada
-- Esta columna registrará el momento exacto en que se marca la columna Salida

USE [MEPRYL]
GO

IF NOT EXISTS (
    SELECT * FROM sys.columns 
    WHERE object_id = OBJECT_ID(N'[dbo].[EstadosCheckboxesMesaEntrada]') 
    AND name = 'HoraSalida'
)
BEGIN
    ALTER TABLE [dbo].[EstadosCheckboxesMesaEntrada]
    ADD HoraSalida datetime NULL;
    
    PRINT 'Columna HoraSalida agregada exitosamente a la tabla EstadosCheckboxesMesaEntrada';
END
ELSE
BEGIN
    PRINT 'La columna HoraSalida ya existe en la tabla EstadosCheckboxesMesaEntrada';
END
GO
