-- ============================================================================
-- ELIMINAR Y RECREAR sp_Especialidad_InsertRapidoPadre
-- ============================================================================

-- 1. ELIMINAR el procedimiento existente
DROP PROCEDURE IF EXISTS dbo.sp_Especialidad_InsertRapidoPadre
GO

-- 2. CREAR el nuevo procedimiento
CREATE PROCEDURE dbo.sp_Especialidad_InsertRapidoPadre
    @id UNIQUEIDENTIFIER,
    @descripcion NVARCHAR(255),
    @idMotivoConsulta INT,
    @precioBase DECIMAL(9,2),
    @descripcionInformes NVARCHAR(MAX),
    @codigo NVARCHAR(100),
    @Padre INT,
    @IdPadre NVARCHAR(MAX)
AS
BEGIN
    SET NOCOUNT ON
    
    BEGIN TRY
        -- Insertar el registro en Especialidad
        INSERT INTO dbo.Especialidad 
        (
            id, 
            codigo, 
            descripcion, 
            idMotivoConsulta, 
            precioBase, 
            descripcionInformes, 
            Padre, 
            IdPadre,
            operacion_local,
            sincronizado
        )
        VALUES 
        (
            @id,
            @codigo,
            @descripcion,
            @idMotivoConsulta,
            @precioBase,
            @descripcionInformes,
            @Padre,
            CASE WHEN @IdPadre IS NULL THEN NULL ELSE CAST(@IdPadre AS UNIQUEIDENTIFIER) END,
            'I',  -- operacion_local = Insert
            0     -- sincronizado = false
        )
        
        -- Retornar el ID insertado
        SELECT @id AS id
        
    END TRY
    BEGIN CATCH
        -- Retornar error
        RAISERROR('Error al insertar especialidad padre', 16, 1)
    END CATCH
END
GO

PRINT 'Procedimiento sp_Especialidad_InsertRapidoPadre creado correctamente'
GO
