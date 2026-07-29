/* 
============================================================================
CREACIÓN DE TABLA UsuarioTipoPaciente
============================================================================
Propósito: Separar credenciales de pacientes de usuarios del sistema
Fecha: 28/07/2026
============================================================================
*/

USE [MEPRYLv2.1];
GO

-- Crear tabla UsuarioTipoPaciente
IF OBJECT_ID('dbo.UsuarioTipoPaciente', 'U') IS NOT NULL
BEGIN
    PRINT 'La tabla UsuarioTipoPaciente ya existe. Eliminándola...'
    DROP TABLE dbo.UsuarioTipoPaciente;
END
GO

CREATE TABLE dbo.UsuarioTipoPaciente
(
    id UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL,
    username VARCHAR(50) NOT NULL,
    password VARCHAR(255) NOT NULL,
    dni VARCHAR(20) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    Tipo VARCHAR(20) NOT NULL, -- 'LABORAL' o 'PREVENTIVA'
    Activo BIT DEFAULT 1 NOT NULL,
    fechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
    CONSTRAINT PK_UsuarioTipoPaciente PRIMARY KEY (id)
);
GO

-- Crear índices para mejorar rendimiento
CREATE INDEX IX_UsuarioTipoPaciente_dni ON dbo.UsuarioTipoPaciente(dni);
CREATE INDEX IX_UsuarioTipoPaciente_Tipo ON dbo.UsuarioTipoPaciente(Tipo);
CREATE INDEX IX_UsuarioTipoPaciente_Activo ON dbo.UsuarioTipoPaciente(Activo);
GO

PRINT 'Tabla UsuarioTipoPaciente creada exitosamente.';
GO
