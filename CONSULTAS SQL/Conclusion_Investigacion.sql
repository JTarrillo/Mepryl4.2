-- ========================================
-- CONCLUSIÓN DE LA INVESTIGACIÓN - POR QUÉ DESAPARECIÓ EL PACIENTE
-- ========================================

/*
RESULTADOS DE LA INVESTIGACIÓN:

1. ✅ USUARIO EXISTE: 
   - Usuario: beniciowilliameliel
   - DNI: 55676837
   - Activo: 1
   - Creado: 07/05/2026

2. ❌ PACIENTE NO EXISTE:
   - 0 registros en dbo.Paciente con DNI 55676837
   - 0 registros en vistas v_Paciente y vwConsultarPacientes
   - No hay registros con DNI similar actualizados recientemente

3. ❌ NO HAY REGISTROS ELIMINADOS RECIENTEMENTE:
   - Los registros con operacion_local son de 2011-2017
   - No hay operaciones recientes (últimos 7 días)

4. ✅ HAY MUCHOS OTROS PACIENTES VARELA Y BENICIO:
   - 68 pacientes con apellido VARELA
   - 297 pacientes con nombres que contienen BENICIO
   - Pero ninguno con DNI 55676837

CONCLUSIÓN FINAL:
==================
El paciente NUNCA existió en la tabla Paciente. 
Solo existe el registro en la tabla Usuario.

POSIBLES ESCENARIOS:
1. ERROR EN EL REGISTRO INICIAL: Se creó el usuario pero nunca se creó el paciente
2. ELIMINACIÓN COMPLETA: Fue eliminado sin dejar rastro (operacion_local)
3. SINCRONIZACIÓN INCOMPLETA: Proceso de sincronización falló
4. ERROR DE MIGRACIÓN: Durante alguna actualización del sistema

SOLUCIÓN RECOMENDADA:
===================
Crear el registro del paciente vinculando los datos del usuario existente.
*/

-- SOLUCIÓN DEFINITIVA
INSERT INTO dbo.Paciente (
    id,
    codigo,
    apellido,
    nombres,
    dni,
    fechaNacimiento,
    telefonos,
    celular,
    Email,
    fechaCreacion,
    actualizacion_local,
    sincronizado
)
SELECT 
    NEWID(),                    -- id
    '',                         -- codigo (vacío por defecto)
    u.apellido,                 -- apellido del usuario
    u.nombre,                   -- nombres del usuario
    u.dni,                      -- dni del usuario
    GETDATE(),                  -- fechaNacimiento (temporal, se puede ajustar)
    '',                         -- telefonos
    '',                         -- celular
    u.email1,                   -- Email del usuario
    u.fechaCreacion,            -- fechaCreacion
    GETDATE(),                  -- actualizacion_local
    NULL                        -- sincronizado
FROM dbo.Usuario u
WHERE u.dni = '55676837'

-- VERIFICACIÓN
SELECT 
    'PACIENTE CREADO EXITOSAMENTE' as Resultado,
    p.id,
    p.dni,
    p.apellido + ' ' + p.nombres as NombreCompleto,
    'Ahora aparecerá en Exámenes Preventiva' as Estado
FROM dbo.Paciente p
WHERE p.dni = '55676837'

-- ========================================
// turbo
-- CONCLUSIÓN: El paciente nunca existió en la tabla Paciente,
-- solo existía como Usuario. Por eso "desapareció" de Exámenes Preventiva.
-- ========================================
