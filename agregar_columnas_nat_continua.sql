-- Agregar columnas Nat y Continua a la tabla EstadosCheckboxesMesaEntrada
ALTER TABLE dbo.EstadosCheckboxesMesaEntrada ADD Nat bit NULL DEFAULT 0;
ALTER TABLE dbo.EstadosCheckboxesMesaEntrada ADD Continua bit NULL DEFAULT 0;
