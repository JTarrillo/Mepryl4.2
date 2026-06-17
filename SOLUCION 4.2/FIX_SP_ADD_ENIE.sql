-- ========================================
-- Crear sp_TipoExamenDePaciente_Add en 17dejunio
-- Copia fiel de la base 3dejunio (con Ñ)
-- ========================================
USE [17dejunio];
GO

IF OBJECT_ID('dbo.sp_TipoExamenDePaciente_Add', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_TipoExamenDePaciente_Add;
GO

-- Usamos un bloque dinámico para asegurar que la Ñ se procese correctamente en el servidor
DECLARE @sql NVARCHAR(MAX);
SET @sql = N'
CREATE PROCEDURE dbo.sp_TipoExamenDePaciente_Add
    @idConsulta uniqueidentifier,
    @idTurno uniqueidentifier,
    @modificado varchar(3),
    @idEspecialidad uniqueidentifier,
    @importe decimal(18,2),
    @factClub varchar(1),
    @precioLista decimal(18,2),
    @seña decimal(18,2) = 0,
    @retorno uniqueidentifier OUTPUT
AS
BEGIN
    DECLARE @id uniqueidentifier;
    SET @id = NEWID();
    INSERT INTO dbo.TipoExamenDePaciente(
        id, idConsulta, idTurno, modificado, idEspecialidad,
        precioExamen, factClub, precioLista, seña
    ) VALUES (
        @id, @idConsulta, @idTurno, @modificado, @idEspecialidad,
        @importe, @factClub, @precioLista, @seña
    );
    SET @retorno = @id;
END';

EXEC sp_executesql @sql;
GO

PRINT 'Procedimiento sp_TipoExamenDePaciente_Add creado con éxito en 17dejunio (Igual a 3dejunio)';
GO
