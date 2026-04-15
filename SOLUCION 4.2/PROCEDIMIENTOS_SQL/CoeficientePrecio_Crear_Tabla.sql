-- Tabla para almacenar el coeficiente/incremento de precio por mes/año
-- Usado para calcular PrecioLista = CEILING(PrecioPromo * Coeficiente / 1000) * 1000
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'CoeficientePrecio')
BEGIN
    CREATE TABLE CoeficientePrecio (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        Mes INT NOT NULL,
        Anio INT NOT NULL,
        Coeficiente DECIMAL(10,4) NOT NULL DEFAULT 1,
        FechaModificacion DATETIME DEFAULT GETDATE(),
        CONSTRAINT UQ_CoeficientePrecio_MesAnio UNIQUE (Mes, Anio)
    );
END
