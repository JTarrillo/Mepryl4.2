-- Eliminar tabla intermedia ObservacionEspecialidad
IF EXISTS (SELECT * FROM sys.tables WHERE name = 'ObservacionEspecialidad')
BEGIN
    DROP TABLE dbo.ObservacionEspecialidad;
    PRINT 'Tabla ObservacionEspecialidad eliminada correctamente.';
END
ELSE
BEGIN
    PRINT 'La tabla ObservacionEspecialidad no existe.';
END
