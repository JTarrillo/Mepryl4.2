-- ============================================
-- SCRIPT DE REPARACIÓN: ConsultaLaboral.idExamenLaboral = idTipoExamen
-- ============================================

-- PASO 1: Identificar registros afectados
SELECT 
    cl.id as ConsultaLaboralID,
    cl.idTipoExamen,
    cl.idExamenLaboral,
    c.identificador,
    CAST(c.fecha AS DATE) as Fecha,
    pl.dni,
    pl.apellido + ', ' + pl.nombres as Paciente
FROM dbo.ConsultaLaboral cl
INNER JOIN dbo.TipoExamenDePaciente tep ON cl.idTipoExamen = tep.id
INNER JOIN dbo.Consulta c ON tep.idConsulta = c.id
INNER JOIN dbo.PacienteLaboral pl ON c.pacienteID = pl.id
WHERE cl.idExamenLaboral = cl.idTipoExamen
ORDER BY c.fecha DESC, c.identificador

-- PASO 2: Contar total de registros afectados
SELECT COUNT(*) as TotalRegistrosAfectados
FROM dbo.ConsultaLaboral cl
WHERE cl.idExamenLaboral = cl.idTipoExamen

-- PASO 3: Verificar registros del 12/08/2026 específicamente
SELECT 
    cl.id as ConsultaLaboralID,
    cl.idTipoExamen,
    cl.idExamenLaboral,
    c.identificador,
    pl.dni,
    pl.apellido + ', ' + pl.nombres as Paciente
FROM dbo.ConsultaLaboral cl
INNER JOIN dbo.TipoExamenDePaciente tep ON cl.idTipoExamen = tep.id
INNER JOIN dbo.Consulta c ON tep.idConsulta = c.id
INNER JOIN dbo.PacienteLaboral pl ON c.pacienteID = pl.id
WHERE cl.idExamenLaboral = cl.idTipoExamen
AND CAST(c.fecha AS DATE) = '2026-08-12'
ORDER BY c.identificador

-- ============================================
-- SCRIPT DE REPARACIÓN (EJECUTAR CON PRECAUCIÓN)
-- ============================================

-- NOTA: Este script crea nuevos registros en ExamenLaboral para cada ConsultaLaboral afectada
-- y actualiza la relación para que idExamenLaboral sea diferente de idTipoExamen

-- PARA CADA REGISTRO AFECTADO (ejemplo para un registro específico):
-- Descomentar y ejecutar para cada registro afectado después de verificar

-- Ejemplo para L2 del 12/08/2026:
-- DELETE FROM dbo.ExamenLaboral WHERE id = '9A1052D9-CB61-4C95-A0D5-45DC40E63C04'
-- INSERT INTO dbo.ExamenLaboral (id, antCli, peso, talla)
-- VALUES (NEWID(), 'NO REFIERE', NULL, NULL)
-- UPDATE dbo.ConsultaLaboral 
-- SET idExamenLaboral = (SELECT TOP 1 id FROM dbo.ExamenLaboral WHERE antCli = 'NO REFIERE' AND peso IS NULL ORDER BY id DESC)
-- WHERE idTipoExamen = '9A1052D9-CB61-4C95-A0D5-45DC40E63C04'

-- Mejor: Crear procedimiento almacenado para reparación masiva
/*
CREATE PROCEDURE sp_RepararConsultaLaboral
AS
BEGIN
    DECLARE @ConsultaLaboralID uniqueidentifier
    DECLARE @TipoExamenID uniqueidentifier
    DECLARE @NuevoExamenID uniqueidentifier
    
    DECLARE cursor_reparacion CURSOR FOR
    SELECT cl.id, cl.idTipoExamen
    FROM dbo.ConsultaLaboral cl
    WHERE cl.idExamenLaboral = cl.idTipoExamen
    
    OPEN cursor_reparacion
    FETCH NEXT FROM cursor_reparacion INTO @ConsultaLaboralID, @TipoExamenID
    
    WHILE @@FETCH_STATUS = 0
    BEGIN
        -- Crear nuevo registro en ExamenLaboral
        SET @NuevoExamenID = NEWID()
        INSERT INTO dbo.ExamenLaboral (id, antCli, peso, talla)
        VALUES (@NuevoExamenID, 'NO REFIERE', NULL, NULL)
        
        -- Actualizar ConsultaLaboral con el nuevo ID
        UPDATE dbo.ConsultaLaboral
        SET idExamenLaboral = @NuevoExamenID
        WHERE id = @ConsultaLaboralID
        
        FETCH NEXT FROM cursor_reparacion INTO @ConsultaLaboralID, @TipoExamenID
    END
    
    CLOSE cursor_reparacion
    DEALLOCATE cursor_reparacion
END
*/

-- Para ejecutar el procedimiento (descomentar después de crear):
-- EXEC sp_RepararConsultaLaboral
