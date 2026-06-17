/* 
============================================================================
RESTAURACIÓN DE Ñ: SINCRONIZACIÓN EXACTA CON 3DEJUNIO
============================================================================
Propósito: Asegurar que 17dejunio use "@seña" y columna "seña" con Ñ.
============================================================================
*/

USE [17dejunio];
GO

-- 1. Restaurar columna en TipoExamenDePaciente
IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.TipoExamenDePaciente') AND name = 'sena')
BEGIN
    EXEC sp_rename 'dbo.TipoExamenDePaciente.sena', 'seña', 'COLUMN';
END
GO

-- 2. Restaurar columna en PrecioPromo
IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.PrecioPromo') AND name = 'Sena')
BEGIN
    EXEC sp_rename 'dbo.PrecioPromo.Sena', 'Seña', 'COLUMN';
END
GO

-- 3. Restaurar columna en ConfigPrecioEspecialidad
IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.ConfigPrecioEspecialidad') AND name = 'Sena')
BEGIN
    EXEC sp_rename 'dbo.ConfigPrecioEspecialidad.Sena', 'Seña', 'COLUMN';
END
GO

-- 4. Actualizar Procedimientos con la Ñ
PRINT 'Actualizando Procedimientos con @seña (con Ñ)...';
GO

IF OBJECT_ID('dbo.sp_TipoExamenDePaciente_Add', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_TipoExamenDePaciente_Add;
GO
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
END
GO

IF OBJECT_ID('dbo.sp_TipoExamenDePaciente_Update', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_TipoExamenDePaciente_Update;
GO
CREATE PROCEDURE dbo.sp_TipoExamenDePaciente_Update
    @idTurno uniqueidentifier,
    @valor varchar(3),
    @importe decimal(18,2),
    @factClub varchar(1),
    @precioLista decimal(18,2),
    @seña decimal(18,2) = 0
AS
BEGIN
    UPDATE dbo.TipoExamenDePaciente
    SET
        modificado = @valor,
        precioExamen = @importe,
        factClub = @factClub,
        precioLista = @precioLista,
        seña = @seña
    WHERE idTurno = @idTurno;
END
GO

PRINT '--- Restauración de Ñ completada para coincidir con 3dejunio ---';
GO
