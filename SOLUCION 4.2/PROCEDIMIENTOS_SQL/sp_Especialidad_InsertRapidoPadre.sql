-- ============================================================
-- PROCEDIMIENTO ALMACENADO: sp_Especialidad_InsertRapidoPadre
-- DESCRIPCIÓN: Inserta rápidamente una nueva Especialidad PADRE
-- PARÁMETROS:
--   @descripcion: Descripción de la especialidad
--   @idMotivoConsulta: ID del motivo de consulta
--   @precioBase: Precio base de la especialidad
--   @descripcionInformes: Descripción para informes
--   @codigo: Código de la especialidad
--   @Padre: Indicador si es padre (1 = es padre)
--   @IdPadre: NULL para especialidades padre
-- RETORNA: ID de la especialidad creada (GUID)
-- ============================================================

-- Eliminar el procedimiento si existe
IF OBJECT_ID('sp_Especialidad_InsertRapidoPadre', 'P') IS NOT NULL
    DROP PROCEDURE sp_Especialidad_InsertRapidoPadre
GO

CREATE PROCEDURE sp_Especialidad_InsertRapidoPadre
    @descripcion NVARCHAR(255),
    @idMotivoConsulta INT,
    @precioBase DECIMAL(18,2),
    @descripcionInformes NVARCHAR(MAX),
    @codigo NVARCHAR(50),
    @Padre INT,
    @IdPadre NVARCHAR(MAX)
AS
BEGIN
    DECLARE @id UNIQUEIDENTIFIER = NEWID()
    
    INSERT INTO dbo.Especialidad 
        (id, descripcion, idMotivoConsulta, precioBase, descripcionInformes, codigo, Padre, IdPadre)
    VALUES 
        (@id, @descripcion, @idMotivoConsulta, @precioBase, @descripcionInformes, @codigo, @Padre, @IdPadre)
    
    SELECT @id
END
GO

