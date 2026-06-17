/* 
============================================================================
RESTAURACIÓN ESTRUCTURA PRECIOPUBLICO 17DEJUNIO
============================================================================
*/

USE [17dejunio];
GO

PRINT 'Actualizando columnas de PrecioPublico...';

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.PrecioPublico') AND (name LIKE 'se%a' OR name = 'sena'))
BEGIN
    ALTER TABLE dbo.PrecioPublico ADD [Seña] DECIMAL(18, 2) NULL DEFAULT 0;
END

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.PrecioPublico') AND name = 'Coeficiente')
BEGIN
    ALTER TABLE dbo.PrecioPublico ADD Coeficiente DECIMAL(18, 4) NULL DEFAULT 0;
END

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.PrecioPublico') AND name = 'CoeficienteIndividual')
BEGIN
    ALTER TABLE dbo.PrecioPublico ADD CoeficienteIndividual DECIMAL(18, 4) NULL DEFAULT 0;
END

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.PrecioPublico') AND name = 'LlevaPlanilla')
BEGIN
    ALTER TABLE dbo.PrecioPublico ADD LlevaPlanilla BIT NOT NULL DEFAULT 0;
END

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.PrecioPublico') AND name = 'ObservacionesExtra')
BEGIN
    ALTER TABLE dbo.PrecioPublico ADD ObservacionesExtra VARCHAR(200) NULL;
END
GO

PRINT 'Estructura PrecioPublico actualizada.';
GO
