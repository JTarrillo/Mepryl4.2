-- ========================================
-- SOLUCIÓN: CREAR PACIENTE FALTANTE
-- El usuario existe pero el paciente no
-- ========================================

-- 1. VERIFICAR DATOS DEL USUARIO EXISTENTE
SELECT 
    'USUARIO EXISTENTE' as Tipo,
    u.id as UsuarioID,
    u.username,
    u.apellido,
    u.nombre,
    u.dni,
    u.Activo,
    u.fechaCreacion
FROM dbo.Usuario u
WHERE u.dni = '55676837'

-- 2. CREAR EL PACIENTE FALTANTE
-- Descomenta y ejecuta esta línea para crear el paciente
-- INSERT INTO dbo.Paciente (
--     id,
--     codigo,
--     apellido,
--     nombres,
--     dni,
--     fechaNacimiento,
--     telefonos,
--     celular,
--     Email,
--     fechaCreacion,
--     actualizacion_local,
--     sincronizado
-- )
-- VALUES (
--     NEWID(),                    -- id
--     '',                         -- codigo (vacío por defecto)
--     'VARELA',                   -- apellido (del usuario)
--     'BENICIO WILLIAM ELIEL',    -- nombres (del usuario)
--     '55676837',                 -- dni
--     GETDATE(),                  -- fechaNacimiento (temporal)
--     '',                         -- telefonos
--     '',                         -- celular
--     NULL,                       -- Email
--     GETDATE(),                  -- fechaCreacion
--     GETDATE(),                  -- actualizacion_local
--     NULL                        -- sincronizado
-- )

-- 3. VERIFICAR QUE EL PACIENTE FUE CREADO
SELECT 
    'PACIENTE CREADO' as Tipo,
    p.id,
    p.apellido,
    p.nombres,
    p.dni,
    'Paciente creado exitosamente' as Resultado
FROM dbo.Paciente p
WHERE p.dni = '55676837'

-- 4. VERIFICAR SI AHORA APARECE EN BÚSQUEDAS
SELECT 
    'BÚSQUEDA FINAL' as Tipo,
    p.id,
    p.dni,
    p.apellido + ' ' + p.nombres as NombreCompleto,
    'Ahora debería aparecer en Exámenes Preventiva' as Estado
FROM dbo.Paciente p
WHERE p.dni = '55676837'

-- ========================================
// turbo
-- INSTRUCCIONES:
-- 1. Ejecuta la consulta 1 para ver los datos del usuario
-- 2. Descomenta y ejecuta la consulta 2 para crear el paciente
-- 3. Ejecuta las consultas 3 y 4 para verificar
-- 4. Vuelve a buscar en "Exámenes Preventiva" por DNI 55676837
-- 
-- PROBLEMA RESUELTO: El usuario existía pero el paciente no
-- ========================================
