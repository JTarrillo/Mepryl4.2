-- Agrega columna VentFacturacion a la tabla Usuario
-- Ejecutar UNA SOLA VEZ en la base de datos

IF NOT EXISTS (
    SELECT 1 FROM sys.columns 
    WHERE object_id = OBJECT_ID('dbo.Usuario') AND name = 'VentFacturacion'
)
BEGIN
    ALTER TABLE dbo.Usuario
    ADD VentFacturacion BIT NOT NULL DEFAULT 0;
    PRINT 'Columna VentFacturacion agregada a dbo.Usuario';
END
ELSE
BEGIN
    PRINT 'La columna VentFacturacion ya existe en dbo.Usuario';
END
GO

-- Agrega columna VentFacturacion al tipo de usuario (permisos por defecto)
IF NOT EXISTS (
    SELECT 1 FROM sys.columns 
    WHERE object_id = OBJECT_ID('dbo.UsuarioTipo') AND name = 'VentFacturacion'
)
BEGIN
    ALTER TABLE dbo.UsuarioTipo
    ADD VentFacturacion BIT NOT NULL DEFAULT 0;
    PRINT 'Columna VentFacturacion agregada a dbo.UsuarioTipo';
END
ELSE
BEGIN
    PRINT 'La columna VentFacturacion ya existe en dbo.UsuarioTipo';
END
GO
