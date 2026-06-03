USE [3dejunio];
GO

-- Paso 1: Agregar columna "seña" a TipoExamenDePaciente
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.TipoExamenDePaciente') AND name = 'seña')
BEGIN
    ALTER TABLE dbo.TipoExamenDePaciente ADD seña DECIMAL(18, 2) NULL;
    PRINT 'Columna "seña" agregada a TipoExamenDePaciente';
END
ELSE
BEGIN
    PRINT 'Columna "seña" ya existe';
END
GO

-- Paso 2: Asegurar "precioLista" en TipoExamenDePaciente
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.TipoExamenDePaciente') AND name = 'precioLista')
BEGIN
    ALTER TABLE dbo.TipoExamenDePaciente ADD precioLista DECIMAL(18, 2) NULL;
    PRINT 'Columna "precioLista" agregada a TipoExamenDePaciente';
END
ELSE
BEGIN
    PRINT 'Columna "precioLista" ya existe';
END
GO

-- Paso 3: Eliminar y crear sp_TipoExamenDePaciente_Add
DROP PROCEDURE IF EXISTS dbo.sp_TipoExamenDePaciente_Add;
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
PRINT 'sp_TipoExamenDePaciente_Add creado correctamente';

-- Paso 4: Eliminar y crear sp_TipoExamenDePaciente_Update
DROP PROCEDURE IF EXISTS dbo.sp_TipoExamenDePaciente_Update;
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
PRINT 'sp_TipoExamenDePaciente_Update creado correctamente';
