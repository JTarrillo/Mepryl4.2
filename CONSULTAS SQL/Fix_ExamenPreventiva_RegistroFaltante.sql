-- ============================================================
-- PROBLEMA: frmExamenFisico no guarda al hacer clic en Aceptar
--           (cierra sin error, sin mensaje, sin persistir datos)
-- FECHA DETECTADA: 30/03/2026
-- PACIENTE AFECTADO: DNI 27061058 - BENITEZ HECTOR CESAR
--                    Consulta N° 287
-- ============================================================
--
-- CAUSA RAIZ
-- ----------
-- El flujo normal de Mesa de Entradas (ingresarPaciente) hace:
--   1. sp_Consulta_Insert              → crea fila en Consulta
--   2. sp_Items_UpdateItemsPorPaciente → crea filas en TipoExamenDePaciente
--   3. exPreventiva.crearExamen()      → crea fila en ExamenPreventiva
--      (via sp_ExamenPreventiva_InsertRapido)
--
-- Si el ingreso se interrumpe a mitad (ej: PacienteRepetido bloquea
-- al paciente pero sp_Turno_UpdateMesaDeEntrada igualmente ejecutó),
-- los pasos 1 y 2 pueden haberse completado pero el paso 3 NO.
--
-- Resultado: TipoExamenDePaciente existe, pero ExamenPreventiva NO.
--
-- En frmExamenFisico.cargarDatos():
--   preventiva.cargarExamen(idTipoExamen)
--     → SELECT * FROM ExamenPreventiva WHERE idTipoExamen = '...'
--     → 0 filas → retorna objeto con IdTipoExamen = Guid.Empty
--   tbId.Text = "00000000-0000-0000-0000-000000000000"
--
-- En guardar() → sp_ExamenPreventiva_UpdateClinico con Guid.Empty
--   → UPDATE afecta 0 filas → Modo = 1 (éxito falso) → cierra sin guardar
--
-- ============================================================
-- PASO 1: DIAGNOSTICO - Verificar si existe el registro
-- ============================================================

-- 1a. Obtener idTipoExamen del turno/consulta afectada
SELECT 
    te.id           AS idTipoExamen,
    te.idConsulta,
    te.idTurno,
    c.identificador AS nroExamen,
    c.nroOrden,
    p.dni,
    p.apellido + ' ' + p.nombres AS paciente
FROM dbo.TipoExamenDePaciente te
INNER JOIN dbo.Consulta c ON te.idConsulta = c.id
INNER JOIN dbo.Paciente p ON c.pacienteID = p.id
WHERE p.dni = '27061058'  -- <-- reemplazar con el DNI del paciente afectado
  AND CONVERT(date, c.fecha) = CONVERT(date, GETDATE())

-- 1b. Verificar si ExamenPreventiva tiene fila para ese idTipoExamen
SELECT ep.*
FROM dbo.ExamenPreventiva ep
WHERE ep.idTipoExamen = '7D59B4D4-0E54-4C5C-9A50-D28B2565553D'  -- <-- reemplazar con id del paso 1a

-- Si la query 1b devuelve 0 filas → confirma el problema

-- ============================================================
-- PASO 2: SOLUCION - Crear el registro faltante
-- ============================================================

-- Ejecutar el mismo procedimiento que usa crearExamen() internamente:
EXEC sp_ExamenPreventiva_InsertRapido 
    @idTipoExamen = '7D59B4D4-0E54-4C5C-9A50-D28B2565553D'  -- <-- reemplazar con id del paso 1a

-- Verificar que se creó:
SELECT * FROM dbo.ExamenPreventiva 
WHERE idTipoExamen = '7D59B4D4-0E54-4C5C-9A50-D28B2565553D'  -- <-- reemplazar

-- ============================================================
-- PASO 3: VERIFICACION POST-FIX
-- ============================================================
-- Después de ejecutar el EXEC, volver a abrir frmExamenFisico
-- para ese paciente desde la grilla de Mesa de Entradas.
-- Ahora cargarDatos() encontrará la fila → tbId.Text se cargará
-- con el Guid correcto → Aceptar guardará correctamente.

-- ============================================================
-- CONTEXTO ADICIONAL: Como se llegó a este estado (caso 30/03/2026)
-- ============================================================
-- El paciente tenía DOS turnos el mismo día:
--   Turno B80070AB → 09:00 PARTICULAR+ERGO  → ingresado OK → Consulta 3652E6FE
--   Turno 33CEBE38 → 10:00 APTO BASICO+ERGO → bloqueado por PacienteRepetido
--
-- Bug en PacienteRepetido() (frmMesaDeEntrada.cs ~línea 2147):
--   La query no filtra "and c.valido = '1'", y tampoco diferencia
--   si el paciente tiene turno distinto el mismo día.
--   → Bloquea al paciente aunque sea un turno diferente.
--
-- Bug en ingresarPaciente() (frmMesaDeEntrada.cs):
--   sp_Turno_UpdateMesaDeEntrada ejecuta SIEMPRE, incluso cuando
--   idConsulta = "" (ingreso bloqueado) → turno 33CEBE38 quedó
--   con mesaDeEntrada=1 sin consulta asociada.
--
-- Correcciones manuales SQL aplicadas ese día:
--
--   -- Ajustar nroOrden e identificador de la consulta
--   UPDATE dbo.Consulta 
--   SET nroOrden = 97, identificador = '287'
--   WHERE id = '3652E6FE-E470-4753-B84F-93215DD8CAD7'
--
--   -- Vincular TipoExamenDePaciente a la Consulta (estaba NULL → excluía de grilla)
--   UPDATE dbo.TipoExamenDePaciente 
--   SET idConsulta = '3652E6FE-E470-4753-B84F-93215DD8CAD7'
--   WHERE idTurno = 'B80070AB-DE4C-4FCE-B878-FFBB6485C87F'
--
--   -- Crear ExamenPreventiva faltante (fix del guardado en frmExamenFisico)
--   EXEC sp_ExamenPreventiva_InsertRapido 
--       @idTipoExamen = '7D59B4D4-0E54-4C5C-9A50-D28B2565553D'
--
--   -- (Pendiente) Liberar turno 33CEBE38 para poder reingresarlo:
--   -- UPDATE dbo.Turno SET mesaDeEntrada = 0 
--   -- WHERE id = '33CEBE38-ECB3-416E-9D5F-34ACF2EB10E2'

-- ============================================================
-- FIXES DE CODIGO PENDIENTES EN RAMA merpyl4.5
-- ============================================================
-- 1. frmMesaDeEntrada.cs ~línea 2147 - PacienteRepetido():
--    Agregar "and c.valido = '1'" a la query
--    + Lógica para permitir mismo paciente con turnos distintos el mismo día
--
-- 2. frmMesaDeEntrada.cs - ingresarPaciente():
--    Envolver sp_Turno_UpdateMesaDeEntrada y sp_Items_UpdateItemsPorPaciente
--    dentro de: if (idConsulta != "") { ... }
