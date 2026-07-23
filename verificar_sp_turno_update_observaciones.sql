-- Verificar si el stored procedure sp_Turno_UpdateObservaciones existe
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Turno_UpdateObservaciones]') AND type in (N'P', N'PC'))
BEGIN
    PRINT 'Stored procedure sp_Turno_UpdateObservaciones existe.'
    
    -- Mostrar el código del stored procedure
    EXEC sp_helptext 'sp_Turno_UpdateObservaciones'
END
ELSE
BEGIN
    PRINT 'Stored procedure sp_Turno_UpdateObservaciones NO existe.'
END
