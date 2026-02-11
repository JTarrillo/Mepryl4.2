-- ============================================================================
-- SCRIPT ESPECIALIDAD (TIPOS DE EXAMEN)
-- ============================================================================
-- Base de Datos: MEPRYLv2.1
-- Tabla: Especialidad
-- Descripción: Consultas y procedimientos para gestionar tipos de examen
-- ============================================================================

USE MEPRYLv2.1
GO

-- ============================================================================
-- 1. CONSULTAS BÁSICAS - LECTURA
-- ============================================================================

-- 1.1 Obtener TODAS las Especialidades
-- ============================================================================
SELECT TOP 100
    id,
    codigo,
    descripcion,
    idMotivoConsulta,
    precioBase,
    descripcionInformes,
    orden,
    tipo,
    Padre,
    IdPadre,
    registroBLOB,
    actualizacion_local,
    operacion_local,
    sincronizado,
    serverID
FROM dbo.Especialidad
ORDER BY CONVERT(int, codigo)
GO

-- 1.2 Obtener Especialidades PADRE (jerarquía nivel 1)
-- ============================================================================
SELECT 
    id,
    codigo,
    descripcion,
    idMotivoConsulta,
    precioBase,
    descripcionInformes,
    Padre,
    IdPadre
FROM dbo.Especialidad
WHERE Padre = 1
ORDER BY CONVERT(int, codigo)
GO

-- 1.3 Obtener Especialidades HIJO de un Padre específico
-- ============================================================================
SELECT 
    id,
    codigo,
    descripcion,
    idMotivoConsulta,
    precioBase,
    descripcionInformes,
    Padre,
    IdPadre
FROM dbo.Especialidad
WHERE Padre = 0 
  AND IdPadre IS NOT NULL
ORDER BY CONVERT(int, codigo)
GO

-- 1.4 Obtener Especialidades por Motivo de Consulta
-- ============================================================================
SELECT 
    e.id,
    e.codigo,
    e.descripcion,
    e.idMotivoConsulta,
    e.precioBase,
    e.descripcionInformes,
    e.Padre,
    e.IdPadre,
    m.nombre AS nombreMotivo
FROM dbo.Especialidad e
INNER JOIN dbo.MotivoDeConsulta m ON e.idMotivoConsulta = m.id
WHERE m.nombre <> 'VISITAS'
ORDER BY CONVERT(int, e.codigo)
GO

-- 1.5 Obtener Especialidad específica por ID
-- ============================================================================
DECLARE @idEspecialidad UNIQUEIDENTIFIER = '550e8400-e29b-41d4-a716-446655440000' -- REEMPLAZAR CON ID REAL

SELECT 
    id,
    codigo,
    descripcion,
    idMotivoConsulta,
    precioBase,
    descripcionInformes,
    orden,
    tipo,
    Padre,
    IdPadre
FROM dbo.Especialidad
WHERE id = @idEspecialidad
GO

-- 1.6 Obtener Especialidades con sus Items asociados
-- ============================================================================
SELECT 
    e.id,
    e.codigo,
    e.descripcion,
    e.precioBase,
    epe.item1,
    epe.item2,
    epe.item3,
    epe.item4,
    epe.item5,
    epe.item6,
    epe.item7,
    epe.item8,
    epe.item9,
    epe.item10,
    epe.item11,
    epe.item12,
    epe.item13,
    epe.item14,
    epe.item15,
    epe.item16,
    epe.item17,
    epe.item18,
    epe.item19,
    epe.item20
FROM dbo.Especialidad e
LEFT JOIN dbo.EstudiosPorTipoExamen epe ON e.id = epe.idEspecialidad
ORDER BY CONVERT(int, e.codigo)
GO

-- 1.7 Obtener Items catálogo master
-- ============================================================================
SELECT 
    id,
    codigo,
    nombreCompleto,
    nombreInformes,
    ordenFormulario,
    precioSuma,
    precioResta
FROM dbo.Items
ORDER BY ordenFormulario, nombreCompleto
GO

-- 1.8 Obtener Items por categoría (ordenFormulario)
-- ============================================================================
SELECT 
    id,
    codigo,
    nombreCompleto,
    nombreInformes,
    ordenFormulario,
    precioSuma,
    precioResta
FROM dbo.Items
WHERE ordenFormulario = 1  -- 1=Clínico, 2=Hematología, etc.
ORDER BY codigo
GO

-- 1.9 Obtener Estudios por Tipo de Examen (items específicos)
-- ============================================================================
DECLARE @idEspecialidad UNIQUEIDENTIFIER = '550e8400-e29b-41d4-a716-446655440000'

SELECT 
    epe.*,
    e.descripcion,
    e.precioBase
FROM dbo.EstudiosPorTipoExamen epe
INNER JOIN dbo.Especialidad e ON epe.idEspecialidad = e.id
WHERE epe.idEspecialidad = @idEspecialidad
GO

-- 1.10 Obtener Motivos de Consulta (no VISITAS)
-- ============================================================================
SELECT 
    id,
    nombre,
    descripcion
FROM dbo.MotivoDeConsulta
WHERE nombre <> 'VISITAS'
ORDER BY nombre
GO

-- ============================================================================
-- 2. CONSULTAS COMPLEJAS - ANÁLISIS
-- ============================================================================

-- 2.1 Contar Especialidades por Motivo de Consulta
-- ============================================================================
SELECT 
    m.nombre AS MotivoConsulta,
    COUNT(e.id) AS TotalEspecialidades,
    SUM(CASE WHEN e.Padre = 1 THEN 1 ELSE 0 END) AS Padres,
    SUM(CASE WHEN e.Padre = 0 THEN 1 ELSE 0 END) AS Hijos
FROM dbo.Especialidad e
INNER JOIN dbo.MotivoDeConsulta m ON e.idMotivoConsulta = m.id
GROUP BY m.nombre
ORDER BY TotalEspecialidades DESC
GO

-- 2.2 Obtener jerarquía Padre-Hijo
-- ============================================================================
SELECT 
    p.id AS IdPadre,
    p.codigo AS CodigoPadre,
    p.descripcion AS DescripcionPadre,
    h.id AS IdHijo,
    h.codigo AS CodigoHijo,
    h.descripcion AS DescripcionHijo,
    h.precioBase
FROM dbo.Especialidad p
LEFT JOIN dbo.Especialidad h ON h.IdPadre = p.id
WHERE p.Padre = 1
ORDER BY CONVERT(int, p.codigo), CONVERT(int, h.codigo)
GO

-- 2.3 Obtener Especialidades sin Items asociados
-- ============================================================================
SELECT 
    e.id,
    e.codigo,
    e.descripcion,
    e.Padre,
    e.IdPadre
FROM dbo.Especialidad e
LEFT JOIN dbo.EstudiosPorTipoExamen epe ON e.id = epe.idEspecialidad
WHERE epe.id IS NULL
ORDER BY CONVERT(int, e.codigo)
GO

-- 2.4 Obtener Especialidades usadas en TipoExamenDePaciente (consultadas)
-- ============================================================================
SELECT DISTINCT
    e.id,
    e.codigo,
    e.descripcion,
    COUNT(tep.id) AS TotalPacientes
FROM dbo.Especialidad e
INNER JOIN dbo.TipoExamenDePaciente tep ON e.id = tep.idEspecialidad
GROUP BY e.id, e.codigo, e.descripcion
ORDER BY TotalPacientes DESC
GO

-- 2.5 Items incluidos en una Especialidad (booleanos = TRUE)
-- ============================================================================
DECLARE @idEspecialidad UNIQUEIDENTIFIER = '550e8400-e29b-41d4-a716-446655440000'

SELECT 
    i.id,
    i.codigo,
    i.nombreCompleto,
    i.nombreInformes,
    i.ordenFormulario,
    i.precioSuma,
    i.precioResta,
    CASE WHEN epe.item1 = 1 THEN 'SÍ' 
         WHEN epe.item2 = 1 THEN 'SÍ'
         -- ... continuar para cada item
         ELSE 'NO' END AS Incluido
FROM dbo.Items i
INNER JOIN dbo.EstudiosPorTipoExamen epe ON 1=1
WHERE epe.idEspecialidad = @idEspecialidad
ORDER BY i.ordenFormulario, i.nombreCompleto
GO

-- ============================================================================
-- 3. PROCEDIMIENTOS ALMACENADOS RELACIONADOS
-- ============================================================================

-- 3.1 Ver procedimientos existentes para Especialidad
-- ============================================================================
SELECT 
    OBJECT_NAME(id) AS NombreProcedimiento,
    create_date AS FechaCreacion,
    modify_date AS FechaModificacion
FROM sys.syscomments
WHERE text LIKE '%Especialidad%'
   OR text LIKE '%TipoExamen%'
GROUP BY id, OBJECT_NAME(id), create_date, modify_date
ORDER BY OBJECT_NAME(id)
GO

-- ============================================================================
-- 4. FILTROS DE BÚSQUEDA
-- ============================================================================

-- 4.1 Buscar Especialidades por descripción
-- ============================================================================
DECLARE @filtro VARCHAR(100) = 'Preventivo'  -- CAMBIAR SEGÚN BÚSQUEDA

SELECT 
    id,
    codigo,
    descripcion,
    precioBase,
    Padre,
    IdPadre
FROM dbo.Especialidad
WHERE descripcion LIKE '%' + @filtro + '%'
ORDER BY descripcion
GO

-- 4.2 Buscar Especialidades por código
-- ============================================================================
DECLARE @codigo INT = 1

SELECT 
    id,
    codigo,
    descripcion,
    precioBase,
    Padre,
    IdPadre
FROM dbo.Especialidad
WHERE CONVERT(VARCHAR, codigo) = CONVERT(VARCHAR, @codigo)
GO

-- 4.3 Obtener Especialidades en rango de precio
-- ============================================================================
SELECT 
    id,
    codigo,
    descripcion,
    precioBase,
    Padre
FROM dbo.Especialidad
WHERE precioBase BETWEEN 100 AND 500
ORDER BY precioBase DESC
GO

-- ============================================================================
-- 5. ESTADÍSTICAS Y REPORTES
-- ============================================================================

-- 5.1 Especialidades más consultadas
-- ============================================================================
SELECT TOP 10
    e.id,
    e.codigo,
    e.descripcion,
    COUNT(tep.id) AS TotalConsultas,
    AVG(CONVERT(DECIMAL, tep.precioExamen)) AS PrecioPromedio
FROM dbo.Especialidad e
LEFT JOIN dbo.TipoExamenDePaciente tep ON e.id = tep.idEspecialidad
GROUP BY e.id, e.codigo, e.descripcion
ORDER BY TotalConsultas DESC
GO

-- 5.2 Especialidades nunca consultadas
-- ============================================================================
SELECT 
    e.id,
    e.codigo,
    e.descripcion,
    e.precioBase,
    e.Padre
FROM dbo.Especialidad e
WHERE NOT EXISTS (
    SELECT 1 FROM dbo.TipoExamenDePaciente tep 
    WHERE tep.idEspecialidad = e.id
)
ORDER BY CONVERT(int, e.codigo)
GO

-- 5.3 Variación de precio en especialidades
-- ============================================================================
SELECT 
    e.id,
    e.codigo,
    e.descripcion,
    e.precioBase AS PrecioBase,
    AVG(CONVERT(DECIMAL, tep.precioExamen)) AS PrecioPromedioPacientes,
    MAX(CONVERT(DECIMAL, tep.precioExamen)) AS PrecioMaximo,
    MIN(CONVERT(DECIMAL, tep.precioExamen)) AS PrecioMinimo
FROM dbo.Especialidad e
LEFT JOIN dbo.TipoExamenDePaciente tep ON e.id = tep.idEspecialidad
GROUP BY e.id, e.codigo, e.descripcion, e.precioBase
HAVING COUNT(tep.id) > 0
ORDER BY ABS(e.precioBase - AVG(CONVERT(DECIMAL, tep.precioExamen))) DESC
GO

-- ============================================================================
-- 6. OPERACIONES DML - INSERTAR/ACTUALIZAR/ELIMINAR
-- ============================================================================

-- 6.1 INSERTAR nueva Especialidad
-- ============================================================================
DECLARE @id UNIQUEIDENTIFIER = NEWID()
DECLARE @codigo INT = (SELECT ISNULL(MAX(CONVERT(INT, codigo)), 0) + 1 FROM dbo.Especialidad)

INSERT INTO dbo.Especialidad (
    id,
    codigo,
    descripcion,
    idMotivoConsulta,
    precioBase,
    descripcionInformes,
    Padre,
    IdPadre
)
VALUES (
    @id,
    @codigo,
    'Examen Nuevo Preventivo',  -- CAMBIAR
    1,                           -- idMotivoConsulta
    150.00,                      -- precioBase
    'Descripción para informes', -- descripcionInformes
    1,                           -- Padre = SÍ
    NULL                         -- IdPadre = NULL (es padre)
)

-- Retornar el ID creado
SELECT @id AS IdCreado, @codigo AS CodigoAsignado
GO

-- 6.2 INSERTAR Items para la nueva Especialidad
-- ============================================================================
DECLARE @idEspecialidadNueva UNIQUEIDENTIFIER = 'REEMPLAZAR_CON_ID_CREADO'

INSERT INTO dbo.EstudiosPorTipoExamen (
    id,
    idEspecialidad,
    item1, item2, item3, item4, item5, item6, item7, item8, item9, item10,
    item11, item12, item13, item14, item15, item16, item17, item18, item19, item20,
    item21, item22, item23, item24, item25, item26, item27, item28, item29, item30,
    item31, item32, item33, item34, item35, item36, item37, item38, item39, item40,
    item41, item42, item43, item44, item45, item46, item47, item48, item49, item50,
    item51, item52, item53, item54, item55, item56, item57, item58, item59, item60,
    item61, item62, item63, item64, item65, item66, item67, item68, item69, item70,
    item71, item72, item73, item74, item75, item76, item77, item78, item79, item80,
    item81, item82, item83, item84, item85, item86, item87, item88, item89, item90,
    item91, item92, item93, item94, item95, item96, item97
)
VALUES (
    NEWID(),
    @idEspecialidadNueva,
    1, 1, 1, 0, 1, 0, 1, 0, 0, 1,  -- items 1-10
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  -- items 11-20
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  -- items 21-30
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  -- items 31-40
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  -- items 41-50
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  -- items 51-60
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  -- items 61-70
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0,  -- items 71-80
    0, 0, 0, 0, 0, 0, 0, 0, 0, 0   -- items 81-90
)

-- Verificar inserción
SELECT * FROM dbo.EstudiosPorTipoExamen WHERE idEspecialidad = @idEspecialidadNueva
GO

-- 6.3 ACTUALIZAR Especialidad existente
-- ============================================================================
DECLARE @idEspecialidad UNIQUEIDENTIFIER = 'REEMPLAZAR_CON_ID_REAL'

UPDATE dbo.Especialidad
SET 
    descripcion = 'Examen Preventivo Actualizado',
    precioBase = 175.00,
    descripcionInformes = 'Nuevo texto para informes',
    actualizacion_local = GETDATE()
WHERE id = @idEspecialidad

-- Verificar actualización
SELECT id, descripcion, precioBase, descripcionInformes FROM dbo.Especialidad WHERE id = @idEspecialidad
GO

-- 6.4 ACTUALIZAR Items de Especialidad
-- ============================================================================
DECLARE @idEspecialidad UNIQUEIDENTIFIER = 'REEMPLAZAR_CON_ID_REAL'

UPDATE dbo.EstudiosPorTipoExamen
SET 
    item1 = 1,    -- Clínico: SÍ
    item2 = 1,    -- Hematología: SÍ
    item3 = 0,    -- Química: NO
    item5 = 1,    -- Perfil Lipídico: SÍ
    actualizacion_local = GETDATE()
WHERE idEspecialidad = @idEspecialidad

-- Verificar actualización
SELECT item1, item2, item3, item4, item5 FROM dbo.EstudiosPorTipoExamen WHERE idEspecialidad = @idEspecialidad
GO

-- 6.5 ELIMINAR Especialidad (con validaciones)
-- ============================================================================
DECLARE @idEspecialidad UNIQUEIDENTIFIER = 'REEMPLAZAR_CON_ID_REAL'

-- Verificar si tiene asociaciones
SELECT 
    COUNT(*) AS TotalTiposExamenDePaciente
FROM dbo.TipoExamenDePaciente
WHERE idEspecialidad = @idEspecialidad

-- Solo eliminar si NO tiene asociaciones
IF NOT EXISTS (SELECT 1 FROM dbo.TipoExamenDePaciente WHERE idEspecialidad = @idEspecialidad)
BEGIN
    DELETE FROM dbo.EstudiosPorTipoExamen WHERE idEspecialidad = @idEspecialidad
    DELETE FROM dbo.Especialidad WHERE id = @idEspecialidad
    PRINT 'Especialidad eliminada correctamente'
END
ELSE
BEGIN
    PRINT 'No se puede eliminar: La especialidad tiene consultas/turnos asignados'
END
GO

-- ============================================================================
-- 7. CONSULTAS DE VALIDACIÓN
-- ============================================================================

-- 7.1 Verificar integridad referencial
-- ============================================================================
SELECT 
    e.id,
    e.descripcion,
    e.idMotivoConsulta,
    m.nombre AS MotivoValido
FROM dbo.Especialidad e
LEFT JOIN dbo.MotivoDeConsulta m ON e.idMotivoConsulta = m.id
WHERE m.id IS NULL  -- Mostrar huérfanos
GO

-- 7.2 Verificar Especialidades con IdPadre inválido
-- ============================================================================
SELECT 
    e.id,
    e.descripcion,
    e.IdPadre,
    p.descripcion AS DescripcionPadre
FROM dbo.Especialidad e
LEFT JOIN dbo.Especialidad p ON e.IdPadre = p.id
WHERE e.IdPadre IS NOT NULL 
  AND p.id IS NULL  -- IdPadre no existe
GO

-- 7.3 Duplicados de descripción
-- ============================================================================
SELECT 
    descripcion,
    COUNT(*) AS Total
FROM dbo.Especialidad
GROUP BY descripcion
HAVING COUNT(*) > 1
ORDER BY Total DESC
GO

-- ============================================================================
-- 8. EXPORTAR/IMPORTAR
-- ============================================================================

-- 8.1 Exportar Especialidades a CSV format
-- ============================================================================
SELECT 
    CAST(id AS VARCHAR(36)) + '|' +
    CAST(codigo AS VARCHAR(10)) + '|' +
    descripcion + '|' +
    CAST(precioBase AS VARCHAR(20)) + '|' +
    CAST(Padre AS VARCHAR(1)) + '|' +
    ISNULL(IdPadre, '')
FROM dbo.Especialidad
ORDER BY CONVERT(int, codigo)
GO

-- ============================================================================
-- 9. ÍNDICES Y OPTIMIZACIÓN
-- ============================================================================

-- 9.1 Ver índices existentes en Especialidad
-- ============================================================================
SELECT 
    i.name AS NombreIndice,
    ic.column_id AS ColumnOrder,
    c.name AS NombreColumna,
    i.type_desc AS TipoIndice
FROM sys.indexes i
INNER JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
INNER JOIN sys.columns c ON ic.object_id = c.object_id AND ic.column_id = c.column_id
WHERE OBJECT_NAME(i.object_id) = 'Especialidad'
ORDER BY i.name, ic.column_id
GO

-- 9.2 Estadísticas de tabla
-- ============================================================================
SELECT 
    COUNT(*) AS TotalEspecialidades,
    SUM(CASE WHEN Padre = 1 THEN 1 ELSE 0 END) AS TotalPadres,
    SUM(CASE WHEN Padre = 0 THEN 1 ELSE 0 END) AS TotalHijos,
    MIN(CONVERT(INT, codigo)) AS CodigoMinimo,
    MAX(CONVERT(INT, codigo)) AS CodigoMaximo
FROM dbo.Especialidad
GO

-- ============================================================================
-- FIN DEL SCRIPT
-- ============================================================================
