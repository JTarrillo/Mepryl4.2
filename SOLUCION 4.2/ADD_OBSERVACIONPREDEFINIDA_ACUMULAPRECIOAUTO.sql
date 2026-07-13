USE [MEPRYLv2.1];
GO

IF COL_LENGTH('dbo.ObservacionPredefinida', 'AcumulaPrecioAuto') IS NULL
BEGIN
    ALTER TABLE dbo.ObservacionPredefinida
    ADD AcumulaPrecioAuto bit NOT NULL
        CONSTRAINT DF_ObservacionPredefinida_AcumulaPrecioAuto DEFAULT (0);
END
GO

UPDATE dbo.ObservacionPredefinida
SET AcumulaPrecioAuto = 1
WHERE texto = 'EXPRESS';
GO
