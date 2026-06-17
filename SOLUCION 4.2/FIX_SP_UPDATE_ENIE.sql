-- ============================================================================
-- SCRIPT DE RESTAURACIÓN: sp_TipoExamenDePaciente_Update
-- Propósito: Crear el procedimiento en 17dejunio exactamente igual a 3dejunio
-- ============================================================================
USE [17dejunio];
GO

IF OBJECT_ID('dbo.sp_TipoExamenDePaciente_Update', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_TipoExamenDePaciente_Update;
GO

DECLARE @sql NVARCHAR(MAX);
-- Usamos CHAR(241) para representar la Ñ de "seña" y evitar errores de CMD/SSMS
SET @sql = N'
CREATE PROCEDURE dbo.sp_TipoExamenDePaciente_Update
    @idTurno uniqueidentifier,
    @valor varchar(3),
    @importe decimal(18,2),
    @factClub varchar(1),
    @precioLista decimal(18,2),
    @se' + CHAR(241) + 'a decimal(18,2) = 0
AS
BEGIN
    UPDATE dbo.TipoExamenDePaciente
    SET
        modificado = @valor,
        precioExamen = @importe,
        factClub = @factClub,
        precioLista = @precioLista,
        se' + CHAR(241) + 'a = @se' + CHAR(241) + 'a
    WHERE idTurno = @idTurno;
END';

EXEC sp_executesql @sql;
GO

PRINT 'Procedimiento sp_TipoExamenDePaciente_Update creado con éxito en 17dejunio.';
GO
