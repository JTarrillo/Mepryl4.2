-- =====================================================
-- ÍNDICES FALTANTES PARA OPTIMIZAR cargarTurnos()
-- =====================================================
-- Consulta actual demora: ~761 ms
-- Objetivo: Reducir a < 300 ms
--
-- ANÁLISIS: Turno ya tiene índices (fecha, fecha_hora, estadoID, horarioID)
-- PROBLEMA: Horario y Especialidad son HEAP sin índices en columnas de JOIN
-- =====================================================

-- ÍNDICE 1: Horario.profesionalID (ALTA PRIORIDAD)
-- Usado en: INNER JOIN dbo.Profesional p ON h.profesionalID = p.id
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Horario_ProfesionalID' AND object_id = OBJECT_ID('dbo.Horario'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_Horario_ProfesionalID
    ON dbo.Horario(profesionalID)
    INCLUDE (especialidadID, id)
    WITH (ONLINE = ON, MAXDOP = 4);
    PRINT '✓ Índice IX_Horario_ProfesionalID creado';
END
ELSE
    PRINT '✗ Índice IX_Horario_ProfesionalID ya existe';

-- ÍNDICE 2: Horario.especialidadID (ALTA PRIORIDAD)
-- Usado en: LEFT JOIN dbo.Especialidad te ON h.especialidadID = te.id
/*
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Horario_EspecialidadID' AND object_id = OBJECT_ID('dbo.Horario'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_Horario_EspecialidadID
    ON dbo.Horario(especialidadID)
    INCLUDE (profesionalID, id)
    WITH (ONLINE = ON, MAXDOP = 4);
    PRINT '✓ Índice IX_Horario_EspecialidadID creado';
END
ELSE
    PRINT '✗ Índice IX_Horario_EspecialidadID ya existe';
*/

-- ÍNDICE 3: Especialidad.IdPadre (MEDIA PRIORIDAD)
-- Usado en: LEFT JOIN dbo.Especialidad tePadre ON te.IdPadre = tePadre.id AND te.Padre = 0
/*
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE name = 'IX_Especialidad_IdPadre' AND object_id = OBJECT_ID('dbo.Especialidad'))
BEGIN
    CREATE NONCLUSTERED INDEX IX_Especialidad_IdPadre
    ON dbo.Especialidad(IdPadre)
    INCLUDE (id, descripcion, Padre)
    WHERE Padre = 0;
    PRINT '✓ Índice IX_Especialidad_IdPadre creado';
END
ELSE
    PRINT '✗ Índice IX_Especialidad_IdPadre ya existe';
*/

PRINT '';
PRINT '=====================================================';
PRINT 'INSTRUCCIONES:';
PRINT '=====================================================';
PRINT '1. Descomentar y ejecutar el ÍNDICE 1 primero';
PRINT '2. Esperar a que termine antes de pasar al siguiente';
PRINT '3. Luego ejecutar el ÍNDICE 2';
PRINT '4. El ÍNDICE 3 es opcional (menos impacto)';
PRINT '';
