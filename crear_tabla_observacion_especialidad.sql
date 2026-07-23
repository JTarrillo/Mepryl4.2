-- Verificar si la tabla existe, si no, crearla
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'ObservacionEspecialidad')
BEGIN
    -- Crear tabla intermedia para vincular observaciones predefinidas con especialidades
    CREATE TABLE ObservacionEspecialidad (
        id INT IDENTITY PRIMARY KEY,
        idObservacionPredefinida INT NOT NULL,
        idEspecialidad UNIQUEIDENTIFIER NOT NULL,
        FechaCreacion DATETIME DEFAULT GETDATE(),
        FechaModificacion DATETIME DEFAULT GETDATE(),
        CONSTRAINT FK_ObservacionEspecialidad_ObservacionPredefinida FOREIGN KEY (idObservacionPredefinida) REFERENCES ObservacionPredefinida(id),
        CONSTRAINT FK_ObservacionEspecialidad_Especialidad FOREIGN KEY (idEspecialidad) REFERENCES Especialidad(id),
        CONSTRAINT UQ_ObservacionEspecialidad UNIQUE (idObservacionPredefinida, idEspecialidad)
    );

    -- Crear índice para mejorar rendimiento
    CREATE INDEX IX_ObservacionEspecialidad_IdEspecialidad ON ObservacionEspecialidad(idEspecialidad);
    CREATE INDEX IX_ObservacionEspecialidad_IdObservacionPredefinida ON ObservacionEspecialidad(idObservacionPredefinida);
END

-- Vincular EXPRESS (id=1) con las especialidades hijas de FUERZAS ARMADAS Y DE SEGURIDAD (si no existen ya)
INSERT INTO ObservacionEspecialidad (idObservacionPredefinida, idEspecialidad)
SELECT 1, '2E9186AB-53AA-4D6E-A848-AFF3D1309AEB'
WHERE NOT EXISTS (SELECT 1 FROM ObservacionEspecialidad WHERE idObservacionPredefinida = 1 AND idEspecialidad = '2E9186AB-53AA-4D6E-A848-AFF3D1309AEB')

INSERT INTO ObservacionEspecialidad (idObservacionPredefinida, idEspecialidad)
SELECT 1, '1B1A8F45-C254-4052-A6C5-40FF7D0588B3'
WHERE NOT EXISTS (SELECT 1 FROM ObservacionEspecialidad WHERE idObservacionPredefinida = 1 AND idEspecialidad = '1B1A8F45-C254-4052-A6C5-40FF7D0588B3')

INSERT INTO ObservacionEspecialidad (idObservacionPredefinida, idEspecialidad)
SELECT 1, 'A73903D4-1109-412E-B98E-9856529A9154'
WHERE NOT EXISTS (SELECT 1 FROM ObservacionEspecialidad WHERE idObservacionPredefinida = 1 AND idEspecialidad = 'A73903D4-1109-412E-B98E-9856529A9154')

INSERT INTO ObservacionEspecialidad (idObservacionPredefinida, idEspecialidad)
SELECT 1, '106675A9-362F-46C9-8527-74B84D57BD5A'
WHERE NOT EXISTS (SELECT 1 FROM ObservacionEspecialidad WHERE idObservacionPredefinida = 1 AND idEspecialidad = '106675A9-362F-46C9-8527-74B84D57BD5A')

INSERT INTO ObservacionEspecialidad (idObservacionPredefinida, idEspecialidad)
SELECT 1, '3E1456D1-E333-4A3C-9F7F-D1676C17FE04'
WHERE NOT EXISTS (SELECT 1 FROM ObservacionEspecialidad WHERE idObservacionPredefinida = 1 AND idEspecialidad = '3E1456D1-E333-4A3C-9F7F-D1676C17FE04')

INSERT INTO ObservacionEspecialidad (idObservacionPredefinida, idEspecialidad)
SELECT 1, '5AA0D89A-FD0B-48B4-9DDE-8281F98F5030'
WHERE NOT EXISTS (SELECT 1 FROM ObservacionEspecialidad WHERE idObservacionPredefinida = 1 AND idEspecialidad = '5AA0D89A-FD0B-48B4-9DDE-8281F98F5030')
