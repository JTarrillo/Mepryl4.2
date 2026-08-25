-- ========================================
-- SISTEMA DE SEGUIMIENTO - PROBLEMA CONSULTORIO/FUTBOL
-- Detecta cuando un turno se crea con especialidad diferente a la del horario
-- ========================================

USE [MEPRYLv2.1];
GO

-- ========================================
-- 1. CREAR TABLA DE LOG PARA SEGUIMIENTO
-- ========================================
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'LogInconsistenciaEspecialidad')
BEGIN
    CREATE TABLE dbo.LogInconsistenciaEspecialidad (
        id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
        fechaRegistro DATETIME DEFAULT GETDATE(),
        idTurno UNIQUEIDENTIFIER,
        codigoTurno VARCHAR(50),
        fechaTurno DATETIME,
        horaTurno VARCHAR(10),
        pacienteDNI VARCHAR(20),
        pacienteNombre VARCHAR(200),
        especialidadHorario VARCHAR(200),
        especialidadAsignada VARCHAR(200),
        idEspecialidadHorario UNIQUEIDENTIFIER,
        idEspecialidadAsignada UNIQUEIDENTIFIER,
        origenProceso VARCHAR(100),
        usuario VARCHAR(100),
        observaciones VARCHAR(500)
    );
    
    PRINT 'Tabla LogInconsistenciaEspecialidad creada exitosamente';
END
ELSE
BEGIN
    PRINT 'Tabla LogInconsistenciaEspecialidad ya existe';
END
GO

-- ========================================
-- 2. STORED PROCEDURE PARA DETECTAR INCONSISTENCIAS
-- ========================================
IF OBJECT_ID('sp_DetectarInconsistenciaEspecialidad', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_DetectarInconsistenciaEspecialidad;
GO

CREATE PROCEDURE dbo.sp_DetectarInconsistenciaEspecialidad
    @idTurno UNIQUEIDENTIFIER,
    @origenProceso VARCHAR(100) = 'DESCONOCIDO'
AS
BEGIN
    DECLARE @especialidadHorario VARCHAR(200);
    DECLARE @especialidadAsignada VARCHAR(200);
    DECLARE @idEspecialidadHorario UNIQUEIDENTIFIER;
    DECLARE @idEspecialidadAsignada UNIQUEIDENTIFIER;
    DECLARE @codigoTurno VARCHAR(50);
    DECLARE @fechaTurno DATETIME;
    DECLARE @horaTurno VARCHAR(10);
    DECLARE @pacienteDNI VARCHAR(20);
    DECLARE @pacienteNombre VARCHAR(200);
    
    -- Obtener datos del turno
    SELECT 
        @codigoTurno = t.codigo,
        @fechaTurno = t.fecha,
        @horaTurno = t.horaReferencia,
        @especialidadHorario = eH.descripcion,
        @idEspecialidadHorario = eH.id,
        @especialidadAsignada = eT.descripcion,
        @idEspecialidadAsignada = eT.id
    FROM dbo.Turno t
    INNER JOIN dbo.Horario h ON t.horarioID = h.id
    INNER JOIN dbo.Especialidad eH ON h.especialidadID = eH.id
    LEFT JOIN dbo.TipoExamenDePaciente tep ON tep.idTurno = t.id
    LEFT JOIN dbo.Especialidad eT ON tep.idEspecialidad = eT.id
    WHERE t.id = @idTurno;
    
    -- Obtener datos del paciente
    SELECT 
        @pacienteDNI = p.dni,
        @pacienteNombre = p.apellido + ' ' + p.nombres
    FROM dbo.PacienteLaboral p
    WHERE p.id = (SELECT pacienteID FROM dbo.Turno WHERE id = @idTurno);
    
    -- Si hay inconsistencia, registrar en log
    IF @especialidadHorario <> @especialidadAsignada AND @especialidadAsignada IS NOT NULL
    BEGIN
        INSERT INTO dbo.LogInconsistenciaEspecialidad (
            idTurno, codigoTurno, fechaTurno, horaTurno, 
            pacienteDNI, pacienteNombre, 
            especialidadHorario, especialidadAsignada,
            idEspecialidadHorario, idEspecialidadAsignada,
            origenProceso, usuario, observaciones
        ) VALUES (
            @idTurno, @codigoTurno, @fechaTurno, @horaTurno,
            @pacienteDNI, @pacienteNombre,
            @especialidadHorario, @especialidadAsignada,
            @idEspecialidadHorario, @idEspecialidadAsignada,
            @origenProceso, SUSER_NAME(), 
            'Inconsistencia detectada automáticamente'
        );
        
        PRINT 'Inconsistencia registrada: Turno ' + @codigoTurno + ' - Horario: ' + @especialidadHorario + ' vs Asignado: ' + @especialidadAsignada;
    END
END
GO

-- ========================================
-- 3. VISTA PARA MONITOREO EN TIEMPO REAL
-- ========================================
IF OBJECT_ID('vw_InconsistenciasEspecialidad', 'V') IS NOT NULL
    DROP VIEW dbo.vw_InconsistenciasEspecialidad;
GO

CREATE VIEW dbo.vw_InconsistenciasEspecialidad AS
SELECT 
    t.id as idTurno,
    t.codigo as codigoTurno,
    t.fecha as fechaTurno,
    t.horaReferencia as horaTurno,
    p.dni as pacienteDNI,
    p.apellido + ' ' + p.nombres as pacienteNombre,
    eHorario.descripcion as especialidadHorario,
    eHorario.IdPadre as horarioIdPadre,
    eAsignada.descripcion as especialidadAsignada,
    eAsignada.IdPadre as asignadoIdPadre,
    CASE 
        WHEN eHorario.IdPadre = eAsignada.IdPadre THEN 'JERARQUIA_CORRECTA'
        WHEN eHorario.IdPadre IS NULL AND eAsignada.IdPadre IS NULL THEN 'AMBOS_SIN_PADRE'
        ELSE 'JERARQUIA_INCORRECTA'
    END as estadoJerarquia,
    CASE 
        WHEN eHorario.descripcion <> eAsignada.descripcion THEN 'INCONSISTENCIA'
        ELSE 'OK'
    END as estadoDescripcion,
    t.observaciones,
    t.consulta
FROM dbo.Turno t
INNER JOIN dbo.Horario h ON t.horarioID = h.id
INNER JOIN dbo.Especialidad eHorario ON h.especialidadID = eHorario.id
LEFT JOIN dbo.TipoExamenDePaciente tep ON tep.idTurno = t.id
LEFT JOIN dbo.Especialidad eAsignada ON tep.idEspecialidad = eAsignada.id
LEFT JOIN dbo.PacienteLaboral p ON t.pacienteID = p.id
WHERE eAsignada.descripcion IS NOT NULL
  AND (eHorario.IdPadre <> eAsignada.IdPadre OR (eHorario.IdPadre IS NULL AND eAsignada.IdPadre IS NOT NULL))
  AND t.fecha >= DATEADD(day, -7, GETDATE()); -- Últimos 7 días
GO

-- ========================================
-- 4. CONSULTA DE VERIFICACIÓN ACTUAL
-- ========================================
PRINT '=== VERIFICACIÓN ACTUAL DE INCONSISTENCIAS ===';
SELECT 
    'Inconsistencias detectadas (últimos 7 días)' as Descripcion,
    COUNT(*) as Cantidad
FROM dbo.vw_InconsistenciasEspecialidad;
GO

-- Mostrar detalles de inconsistencias actuales
SELECT 
    codigoTurno,
    fechaTurno,
    horaTurno,
    pacienteDNI,
    pacienteNombre,
    especialidadHorario as 'Especialidad_Horario',
    especialidadAsignada as 'Especialidad_Asignada',
    estado,
    consulta as 'Tipo_Consulta'
FROM dbo.vw_InconsistenciasEspecialidad
ORDER BY fechaTurno DESC;
GO

-- ========================================
-- 5. CORRECCIÓN DEL REGRESO ESPECÍFICO
-- ========================================
PRINT '=== CORRIGIENDO REGISTRO ESPECÍFICO: GOMEZ FIDEL ALBERTO ===';

-- Verificar estado actual
SELECT 
    'Estado ANTES de corrección' as Info,
    t.codigo,
    eHorario.descripcion as especialidadHorario,
    eAsignada.descripcion as especialidadAsignada
FROM dbo.Turno t
INNER JOIN dbo.Horario h ON t.horarioID = h.id
INNER JOIN dbo.Especialidad eHorario ON h.especialidadID = eHorario.id
LEFT JOIN dbo.TipoExamenDePaciente tep ON tep.idTurno = t.id
LEFT JOIN dbo.Especialidad eAsignada ON tep.idEspecialidad = eAsignada.id
WHERE t.codigo = '645295';
GO

-- Corregir el registro específico (GOMEZ FIDEL ALBERTO debía ser CONSULTORIO)
UPDATE dbo.TipoExamenDePaciente 
SET idEspecialidad = '254110EB-0A50-47D8-89EF-118D163FCE8B' -- CONSULTORIO
WHERE idTurno = 'AE38DCE9-6474-4648-A9DF-2954451F7C51';
GO

-- Verificar estado después de corrección
SELECT 
    'Estado DESPUÉS de corrección' as Info,
    t.codigo,
    eHorario.descripcion as especialidadHorario,
    eAsignada.descripcion as especialidadAsignada
FROM dbo.Turno t
INNER JOIN dbo.Horario h ON t.horarioID = h.id
INNER JOIN dbo.Especialidad eHorario ON h.especialidadID = eHorario.id
LEFT JOIN dbo.TipoExamenDePaciente tep ON tep.idTurno = t.id
LEFT JOIN dbo.Especialidad eAsignada ON tep.idEspecialidad = eAsignada.id
WHERE t.codigo = '645295';
GO

PRINT '=== SISTEMA DE SEGUIMIENTO IMPLEMENTADO ===';
PRINT 'Para monitorear, ejecutar: SELECT * FROM dbo.vw_InconsistenciasEspecialidad';
PRINT 'Para registrar inconsistencias manualmente: EXEC sp_DetectarInconsistenciaEspecialidad @idTurno';
GO