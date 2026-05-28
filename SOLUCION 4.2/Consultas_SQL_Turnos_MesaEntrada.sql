-- CONSULTAS SQL SERVER: TURNOS Y MESA DE ENTRADA
-- =================================================

USE periodo
GO

-- =================================================
-- 1. VER ESTRUCTURA DE LAS TABLAS PRINCIPALES
-- =================================================

-- 1.1 Tabla Turno (ver todos los campos y tipos
SELECT 
    COLUMN_NAME AS 'Campo',
    DATA_TYPE AS 'Tipo',
    IS_NULLABLE AS 'Acepta NULL',
    CHARACTER_MAXIMUM_LENGTH AS 'Longitud'
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Turno'
ORDER BY ORDINAL_POSITION;
GO

-- 1.2 Tabla TipoExamenDePaciente
SELECT 
    COLUMN_NAME AS 'Campo',
    DATA_TYPE AS 'Tipo',
    IS_NULLABLE AS 'Acepta NULL',
    CHARACTER_MAXIMUM_LENGTH AS 'Longitud'
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'TipoExamenDePaciente'
ORDER BY ORDINAL_POSITION;
GO

-- 1.3 Tabla PrecioPublico (precios y seña por periodo)
SELECT 
    COLUMN_NAME AS 'Campo',
    DATA_TYPE AS 'Tipo',
    IS_NULLABLE AS 'Acepta NULL',
    CHARACTER_MAXIMUM_LENGTH AS 'Longitud'
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'PrecioPublico'
ORDER BY ORDINAL_POSITION;
GO

-- =================================================
-- 2. BUSCAR TURNO POR CÓDIGO (ej: 49881948)
-- =================================================

-- 2.1 Buscar turno por código exacto
SELECT * FROM dbo.Turno WHERE codigo = '49881948';
GO

-- 2.2 Buscar turno por código LIKE
SELECT * FROM dbo.Turno WHERE codigo LIKE '%49881948%';
GO

-- 2.3 Buscar turnos por DNI del paciente
DECLARE @dniBuscar VARCHAR(20) = '49881948';
SELECT t.*
FROM dbo.Turno t
WHERE t.pacienteID IN (
    SELECT id FROM dbo.Paciente WHERE dni = @dniBuscar 
    UNION 
    SELECT id FROM dbo.PacienteLaboral WHERE dni = @dniBuscar
);
GO

-- =================================================
-- 3. MESA DE ENTRADA: VER TURNOS DEL DÍA ACTUAL
-- =================================================

-- 3.1 Obtener turnos del día (usando vista desnormalizada
SELECT * FROM dbo.v_Turno_desnormalizada 
WHERE fecha = CONVERT(DATE, GETDATE())
ORDER BY horaReferencia;
GO

-- 3.2 Obtener turnos del día (con JOIN manual
SELECT 
    t.id, t.codigo, t.fecha, t.horaReferencia,
    e.descripcion AS 'TipoExamen',
    p.apellido, p.nombre,
    mc.nombre AS 'MotivoConsulta',
    ts.descripcion AS 'Estado'
FROM dbo.Turno t
INNER JOIN dbo.Horario h ON t.horarioID = h.id
INNER JOIN dbo.Especialidad e ON h.especialidadID = e.id
LEFT JOIN dbo.Paciente p ON t.pacienteID = p.id
LEFT JOIN dbo.MotivoDeConsulta mc ON e.idMotivoConsulta = mc.id
LEFT JOIN dbo.TurnoEstado ts ON t.estadoID = ts.id
WHERE t.fecha = CONVERT(DATE, GETDATE())
ORDER BY t.horaReferencia;
GO

-- =================================================
-- 4. OBTENER DETALLE COMPLETO DE UN TURNO
-- =================================================

-- 4.1 Obtener turno + tipo de examen, precio y seña
SELECT 
    t.id AS 'IdTurno',
    t.codigo AS 'CodigoTurno',
    t.fecha AS 'Fecha',
    t.horaReferencia AS 'Hora',
    e.descripcion AS 'TipoExamen',
    p.apellido + ' ' + p.nombre AS 'Paciente',
    te.precioExamen AS 'PrecioExamen',
    te.Seña AS 'Seña',
    te.LlevaPlanilla AS 'LlevaPlanilla',
    te.Observaciones AS 'Observaciones',
    CASE WHEN te.UsarPrecioLista = 1 THEN 'LISTA' ELSE 'PROMO' END AS 'PrecioAplicado'
FROM dbo.Turno t
INNER JOIN dbo.TipoExamenDePaciente te ON te.idTurno = t.id
INNER JOIN dbo.Especialidad e ON te.idEspecialidad = e.id
LEFT JOIN dbo.Paciente p ON t.pacienteID = p.id
WHERE t.codigo = '49881948'; -- Reemplaza por tu código
GO

-- =================================================
-- 5. PRECIOS PÚBLICOS DEL PERIODO ACTUAL
-- =================================================

-- 5.1 Precios y señas del mes/año actual
SELECT 
    e.descripcion AS 'Especialidad',
    pp.Mes, pp.Anio,
    pp.PrecioPromo, pp.PrecioLista,
    pp.Seña, pp.LlevaPlanilla,
    pp.ObservacionesExtra
FROM dbo.PrecioPublico pp
INNER JOIN dbo.Especialidad e ON pp.idEspecialidad = e.id
WHERE pp.Mes = MONTH(GETDATE()) 
  AND pp.Anio = YEAR(GETDATE())
  AND pp.Eliminado = 0
ORDER BY e.descripcion;
GO

-- =================================================
-- 6. CONFIGURACIÓN DE SEÑAS POR ESPECIALIDAD
-- =================================================

SELECT 
    e.descripcion AS 'Especialidad',
    cfg.Seña, cfg.LlevaPlanilla, cfg.Observaciones
FROM dbo.ConfigPrecioEspecialidad cfg
INNER JOIN dbo.Especialidad e ON cfg.idEspecialidad = e.id
ORDER BY e.descripcion;
GO

-- =================================================
-- 7. ACTUALIZAR/INSERTAR SEÑA EN UN TURNO
-- =================================================

-- 7.1 Actualizar seña y observaciones
UPDATE dbo.TipoExamenDePaciente
SET Seña = 3000, -- Valor de seña
WHERE idTurno = (SELECT TOP 1 id FROM dbo.Turno WHERE codigo = '49881948')
GO

-- 7.2 Actualizar precio y seña en PrecioPublico para un periodo
MERGE INTO dbo.PrecioPublico AS Target
USING (VALUES
    SELECT 
        'GUID_especialidad' as idEspecialidad,
        'Descripcion' as Descripcion,
        5 as Mes,
        2026 as Anio,
        15000 as PrecioLista,
        12000 as PrecioPromo,
        3000 as Seña, -- Nueva seña única
        0 as LlevaPlanilla,
        '' as ObservacionesExtra,
        0 as CoeficienteIndividual
) AS Source
ON Target.idEspecialidad = Source.idEspecialidad
    AND Target.Mes = Source.Mes
    AND Target.Anio = Source.Anio
WHEN MATCHED THEN
    UPDATE SET PrecioLista = Source.PrecioLista,
             PrecioPromo = Source.PrecioPromo,
             Seña = Source.Seña, -- Se actualiza la seña única
             LlevaPlanilla = Source.LlevaPlanilla,
             ObservacionesExtra = Source.ObservacionesExtra,
             FechaModificacion = GETDATE()
WHEN NOT MATCHED THEN
    INSERT (idEspecialidad, Descripcion, Mes, Anio, PrecioLista, PrecioPromo,
            Seña, LlevaPlanilla, ObservacionesExtra, CoeficienteIndividual)
    VALUES (Source.idEspecialidad, Source.Descripcion, Source.Mes, Source.Anio,
            Source.PrecioLista, Source.PrecioPromo, Source.Seña, Source.LlevaPlanilla,
            Source.ObservacionesExtra, Source.CoeficienteIndividual);
GO

-- =================================================
-- 8. VERIFICAR ESTADOS DE LOS TURNOS
-- =================================================
SELECT * FROM dbo.TurnoEstado;
GO

-- =================================================
-- 9. CONTAR TURNOS POR TIPO EN EL DÍA
-- =================================================

SELECT 
    mc.nombre AS 'MotivoConsulta',
    COUNT(t.id) AS 'CantidadTurnos'
FROM dbo.Turno t
INNER JOIN dbo.Horario h ON t.horarioID = h.id
INNER JOIN dbo.Especialidad e ON h.especialidadID = e.id
LEFT JOIN dbo.MotivoDeConsulta mc ON e.idMotivoConsulta = mc.id
WHERE t.fecha = CONVERT(DATE, GETDATE())
GROUP BY mc.nombre
ORDER BY mc.nombre;
GO

-- =================================================
-- 10. ÚLTIMOS 20 TURNOS CREADOS
-- =================================================

SELECT TOP 20 *
FROM dbo.Turno
ORDER BY fecha DESC, horaReferencia DESC;
GO
