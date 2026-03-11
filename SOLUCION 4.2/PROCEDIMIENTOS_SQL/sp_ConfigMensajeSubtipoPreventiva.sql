-- Tabla para configurar la plantilla de mensaje WhatsApp por cada subtipo de preventiva
-- Reemplaza el sistema anterior de 3 columnas fijas (MensajeTurno / MensajeTurno2 / MensajeTurno3)

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ConfigMensajeSubtipoPreventiva')
BEGIN
    CREATE TABLE dbo.ConfigMensajeSubtipoPreventiva
    (
        IdSubtipo   UNIQUEIDENTIFIER NOT NULL,
        PathArchivo NVARCHAR(500)    NOT NULL DEFAULT '',
        CONSTRAINT PK_ConfigMensajeSubtipoPreventiva PRIMARY KEY (IdSubtipo)
    );
END
GO
