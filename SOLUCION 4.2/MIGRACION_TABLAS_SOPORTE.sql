/* 
============================================================================
SCRIPT DE MIGRACIÓN: TABLAS DE ELIMINACIÓN Y SOPORTE
============================================================================
*/

USE [17dejunio];
GO

PRINT '--- Asegurando tablas de soporte ---';

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EspecialidadesEliminadas]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[EspecialidadesEliminadas](
        [id] [uniqueidentifier] NOT NULL,
        [fecha] [datetime] NULL DEFAULT GETDATE(),
        CONSTRAINT [PK_EspecialidadesEliminadas] PRIMARY KEY CLUSTERED ([id] ASC)
    );
END
GO

PRINT '--- Tablas de soporte listas ---';
GO
