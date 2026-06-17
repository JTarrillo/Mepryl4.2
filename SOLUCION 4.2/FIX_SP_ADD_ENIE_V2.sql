-- ========================================
-- Crear sp_TipoExamenDePaciente_Add en 17dejunio
-- SIN caracteres especiales en el archivo para evitar errores de CMD
-- ========================================
USE [17dejunio];
GO

IF OBJECT_ID('dbo.sp_TipoExamenDePaciente_Add', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_TipoExamenDePaciente_Add;
GO

DECLARE @sql NVARCHAR(MAX);
-- Usamos CHAR(241) para representar la Ñ de "seña"
SET @sql = N'
CREATE PROCEDURE dbo.sp_TipoExamenDePaciente_Add
    @idConsulta uniqueidentifier,
    @idTurno uniqueidentifier,
    @modificado varchar(3),
    @idEspecialidad uniqueidentifier,
    @importe decimal(18,2),
    @factClub varchar(1),
    @precioLista decimal(18,2),
    @se' + CHAR(241) + 'a decimal(18,2) = 0,
    @retorno uniqueidentifier OUTPUT
AS
BEGIN
    DECLARE @id uniqueidentifier;
    SET @id = NEWID();
    INSERT INTO dbo.TipoExamenDePaciente(
        id, idConsulta, idTurno, modificado, idEspecialidad,
        precioExamen, factClub, precioLista, se' + CHAR(241) + 'a
    ) VALUES (
        @id, @idConsulta, @idTurno, @modificado, @idEspecialidad,
        @importe, @factClub, @precioLista, @se' + CHAR(241) + 'a
    );
    SET @retorno = @id;
END';

EXEC sp_executesql @sql;
GO

PRINT 'Procedimiento sp_TipoExamenDePaciente_Add creado con éxito usando CHAR(241) para la Ñ.';
GO
