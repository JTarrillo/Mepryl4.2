/* 
============================================================================
SCRIPT DE MIGRACIÓN FINAL: ACTUALIZACIÓN TOTAL DE ESTRUCTURA 17DEJUNIO
============================================================================
Propósito: Agregar tablas faltantes (PrecioPromo, ConfigPrecioEspecialidad, 
           CoeficientePrecio) y sincronizar columnas de Especialidad.
Fecha: 17/06/2026
============================================================================
*/

USE [17dejunio];
GO

PRINT '--- Iniciando actualización de estructura faltante ---';

-- 1. Tabla ESPECIALIDAD (Columnas adicionales)
PRINT 'Asegurando columnas en Especialidad...';
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.Especialidad') AND name = 'IPCBase')
    ALTER TABLE dbo.Especialidad ADD IPCBase DECIMAL(18, 2) DEFAULT 0;
GO

-- 2. Tabla PRECIOPROMO
PRINT 'Creando tabla PrecioPromo...';
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PrecioPromo]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[PrecioPromo](
        [id] [int] IDENTITY(1,1) NOT NULL,
        [idEspecialidad] [uniqueidentifier] NOT NULL,
        [Descripcion] [varchar](256) NOT NULL,
        [Mes] [int] NOT NULL,
        [Anio] [int] NOT NULL,
        [PrecioPromo] [decimal](18, 2) NOT NULL,
        [Sena] [decimal](18, 2) NULL DEFAULT 0,
        [LlevaPlanilla] [bit] NOT NULL DEFAULT 0,
        [ObservacionesExtra] [varchar](200) NULL,
        [CoeficienteIndividual] [decimal](18, 4) NULL DEFAULT 0,
        [FechaModificacion] [datetime] NULL DEFAULT GETDATE(),
        [Eliminado] [bit] NULL DEFAULT 0,
        CONSTRAINT [PK_PrecioPromo] PRIMARY KEY CLUSTERED ([id] ASC)
    );
END
GO

-- 3. Tabla CONFIGPRECIOESPECIALIDAD
PRINT 'Creando tabla ConfigPrecioEspecialidad...';
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ConfigPrecioEspecialidad]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[ConfigPrecioEspecialidad](
        [idEspecialidad] [uniqueidentifier] NOT NULL,
        [Sena] [decimal](18, 2) NULL DEFAULT 0,
        [LlevaPlanilla] [bit] NOT NULL DEFAULT 0,
        [Observaciones] [varchar](200) NULL,
        [FechaModificacion] [datetime] NULL DEFAULT GETDATE(),
        CONSTRAINT [PK_ConfigPrecioEspecialidad] PRIMARY KEY CLUSTERED ([idEspecialidad] ASC)
    );
END
GO

-- 4. Tabla COEFICIENTEPRECIO
PRINT 'Creando tabla CoeficientePrecio...';
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CoeficientePrecio]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[CoeficientePrecio](
        [id] [int] IDENTITY(1,1) NOT NULL,
        [Mes] [int] NOT NULL,
        [Anio] [int] NOT NULL,
        [Coeficiente] [decimal](18, 4) NOT NULL,
        [Tipo] [varchar](20) NOT NULL, -- 'PROMO' o 'PUBLICO'
        [FechaModificacion] [datetime] NULL DEFAULT GETDATE(),
        CONSTRAINT [PK_CoeficientePrecio] PRIMARY KEY CLUSTERED ([id] ASC)
    );
END
GO

PRINT '--- Estructura de Precios Sincronizada ---';
GO
