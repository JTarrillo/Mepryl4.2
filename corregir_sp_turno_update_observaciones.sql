-- Crear o corregir el stored procedure sp_Turno_UpdateObservaciones
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Turno_UpdateObservaciones]') AND type in (N'P', N'PC'))
BEGIN
    DROP PROCEDURE [dbo].[sp_Turno_UpdateObservaciones]
    PRINT 'Stored procedure sp_Turno_UpdateObservaciones eliminado.'
END
GO

CREATE PROCEDURE [dbo].[sp_Turno_UpdateObservaciones]
    @idTurno UNIQUEIDENTIFIER,
    @observaciones VARCHAR(MAX),
    @consulta VARCHAR(50)
AS
BEGIN
    UPDATE dbo.Turno
    SET observaciones = @observaciones,
        consulta = @consulta
    WHERE id = @idTurno
END
GO

PRINT 'Stored procedure sp_Turno_UpdateObservaciones creado correctamente.'
