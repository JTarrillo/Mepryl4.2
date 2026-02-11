-- =============================================
-- Eliminar registros de EstudiosPorTipoExamen por idEspecialidad
-- =============================================
IF OBJECT_ID('sp_EstudiosPorTipoExamen_Delete', 'P') IS NOT NULL
    DROP PROCEDURE sp_EstudiosPorTipoExamen_Delete
GO

CREATE PROCEDURE sp_EstudiosPorTipoExamen_Delete
    @idEspecialidad UNIQUEIDENTIFIER
AS
BEGIN
    DELETE FROM dbo.EstudiosPorTipoExamen
    WHERE idEspecialidad = @idEspecialidad
END
GO
