/* 
============================================================================
SCRIPT DE MIGRACIÓN: ACTUALIZACIÓN DE BASE DE DATOS 17DEJUNIO A VERSIÓN 3DEJUNIO
============================================================================
Propósito: Sincronizar la estructura de tablas y procedimientos almacenados.
Fecha: 17/06/2026
============================================================================
*/

USE [17dejunio];
GO

PRINT '--- Iniciando actualización de estructura ---';

-- 1. Tabla ESPECIALIDAD
PRINT 'Actualizando tabla Especialidad...';
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Especialidad') AND name = 'Padre')
    ALTER TABLE dbo.Especialidad ADD Padre BIT DEFAULT 0;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Especialidad') AND name = 'IdPadre')
    ALTER TABLE dbo.Especialidad ADD IdPadre UNIQUEIDENTIFIER NULL;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Especialidad') AND name = 'estado')
    ALTER TABLE dbo.Especialidad ADD estado BIT DEFAULT 1;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Especialidad') AND name = 'precioLista')
    ALTER TABLE dbo.Especialidad ADD precioLista DECIMAL(18, 2) DEFAULT 0;
GO

-- 2. Tabla TIPOEXAMENDEPACIENTE
PRINT 'Actualizando tabla TipoExamenDePaciente...';
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.TipoExamenDePaciente') AND name = 'sena')
    ALTER TABLE dbo.TipoExamenDePaciente ADD sena DECIMAL(18, 2) DEFAULT 0;

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.TipoExamenDePaciente') AND name = 'precioLista')
    ALTER TABLE dbo.TipoExamenDePaciente ADD precioLista DECIMAL(18, 2) DEFAULT 0;
GO

-- 3. Tabla PRECIOPUBLICO
PRINT 'Creando tabla PrecioPublico si no existe...';
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrecioPublico]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[PrecioPublico](
        [id] [int] IDENTITY(1,1) NOT NULL,
        [idEspecialidad] [uniqueidentifier] NOT NULL,
        [Descripcion] [varchar](256) NOT NULL,
        [Mes] [int] NOT NULL,
        [Anio] [int] NOT NULL,
        [PrecioLista] [decimal](18, 2) NOT NULL,
        [PrecioPromo] [decimal](18, 2) NOT NULL,
        [Sena] [decimal](18, 2) NULL,
        [Coeficiente] [decimal](18, 4) NULL,
        [CoeficienteIndividual] [decimal](18, 4) NULL,
        [LlevaPlanilla] [bit] NOT NULL DEFAULT 0,
        [ObservacionesExtra] [varchar](200) NULL,
        [FechaModificacion] [datetime] NULL DEFAULT GETDATE(),
        [Eliminado] [bit] NULL DEFAULT 0,
        CONSTRAINT [PK_PrecioPublico] PRIMARY KEY CLUSTERED ([id] ASC)
    );
END
GO

-- 4. Tabla OBSERVACIONPREDEFINIDA
PRINT 'Creando tabla ObservacionPredefinida si no existe...';
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ObservacionPredefinida]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[ObservacionPredefinida](
        [id] [int] IDENTITY(1,1) NOT NULL,
        [texto] [varchar](200) NOT NULL,
        [descripcion] [varchar](200) NULL,
        [activo] [bit] NOT NULL DEFAULT 1,
        CONSTRAINT [PK_ObservacionPredefinida] PRIMARY KEY CLUSTERED ([id] ASC)
    );
    
    -- Insertar valores iniciales sugeridos
    INSERT INTO [dbo].[ObservacionPredefinida] (texto, descripcion, activo)
    VALUES ('APTO PARA COMPETENCIA', 'APTO COMPETENCIA', 1),
           ('APTO FISICO BASICO', 'APTO BASICO', 1),
           ('REQUIERE ESTUDIOS COMPLEMENTARIOS', 'REQ ESTUDIOS', 1);
END
GO

-- 5. PROCEDIMIENTOS ALMACENADOS
PRINT 'Actualizando Procedimientos Almacenados...';
GO

-- 5.1 sp_TipoExamenDePaciente_Add
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
    @sena decimal(18,2) = 0,
    @retorno uniqueidentifier OUTPUT
AS
BEGIN
    DECLARE @id uniqueidentifier;
    SET @id = NEWID();
    INSERT INTO dbo.TipoExamenDePaciente(
        id, idConsulta, idTurno, modificado, idEspecialidad,
        precioExamen, factClub, precioLista, sena
    ) VALUES (
        @id, @idConsulta, @idTurno, @modificado, @idEspecialidad,
        @importe, @factClub, @precioLista, @sena
    );
    SET @retorno = @id;
END
GO

-- 5.2 sp_TipoExamenDePaciente_Update
IF OBJECT_ID('dbo.sp_TipoExamenDePaciente_Update', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_TipoExamenDePaciente_Update;
GO
CREATE PROCEDURE dbo.sp_TipoExamenDePaciente_Update
    @idTurno uniqueidentifier,
    @valor varchar(3),
    @importe decimal(18,2),
    @factClub varchar(1),
    @precioLista decimal(18,2),
    @sena decimal(18,2) = 0
AS
BEGIN
    UPDATE dbo.TipoExamenDePaciente
    SET
        modificado = @valor,
        precioExamen = @importe,
        factClub = @factClub,
        precioLista = @precioLista,
        sena = @sena
    WHERE idTurno = @idTurno;
END
GO

-- 5.3 sp_TipoExamenDePaciente_UpdateTipoExamenPaciente (RELAJAR RESTRICCION)
IF OBJECT_ID('dbo.sp_TipoExamenDePaciente_UpdateTipoExamenPaciente', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_TipoExamenDePaciente_UpdateTipoExamenPaciente;
GO
CREATE PROCEDURE dbo.sp_TipoExamenDePaciente_UpdateTipoExamenPaciente
    @idConsulta uniqueidentifier,
    @idEspecialidad uniqueidentifier
AS
BEGIN
    -- ✅ Ahora permite tanto Padres como Subtipos para compatibilidad con historia
    UPDATE dbo.TipoExamenDePaciente
    SET idEspecialidad = @idEspecialidad
    WHERE idConsulta = @idConsulta
END
GO

-- 5.4 sp_Especialidad_InsertRapidoPadre
IF OBJECT_ID('dbo.sp_Especialidad_InsertRapidoPadre', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_Especialidad_InsertRapidoPadre;
GO
CREATE PROCEDURE dbo.sp_Especialidad_InsertRapidoPadre
    @id UNIQUEIDENTIFIER,
    @descripcion NVARCHAR(255),
    @idMotivoConsulta INT,
    @precioBase DECIMAL(18,2),
    @descripcionInformes NVARCHAR(MAX),
    @codigo NVARCHAR(50),
    @Padre INT,
    @IdPadre UNIQUEIDENTIFIER,
    @estado BIT = 1
AS
BEGIN
    IF @id IS NULL SET @id = NEWID();
    
    INSERT INTO dbo.Especialidad 
        (id, descripcion, idMotivoConsulta, precioBase, descripcionInformes, codigo, Padre, IdPadre, estado)
    VALUES 
        (@id, @descripcion, @idMotivoConsulta, @precioBase, @descripcionInformes, @codigo, @Padre, @IdPadre, @estado)
END
GO

-- 5.5 sp_Especialidad_InsertRapidoHijo
IF OBJECT_ID('dbo.sp_Especialidad_InsertRapidoHijo', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_Especialidad_InsertRapidoHijo;
GO
CREATE PROCEDURE dbo.sp_Especialidad_InsertRapidoHijo
    @id UNIQUEIDENTIFIER,
    @descripcion NVARCHAR(255),
    @idMotivoConsulta INT,
    @precioBase DECIMAL(18,2),
    @descripcionInformes NVARCHAR(MAX),
    @codigo NVARCHAR(50),
    @Padre INT,
    @IdPadre UNIQUEIDENTIFIER,
    @tipo INT = NULL
AS
BEGIN
    IF @id IS NULL SET @id = NEWID();
    
    INSERT INTO dbo.Especialidad 
        (id, descripcion, idMotivoConsulta, precioBase, descripcionInformes, codigo, Padre, IdPadre, tipo)
    VALUES 
        (@id, @descripcion, @idMotivoConsulta, @precioBase, @descripcionInformes, @codigo, @Padre, @IdPadre, @tipo)
END
GO

PRINT '--- Actualización Completada Exitosamente ---';
GO
