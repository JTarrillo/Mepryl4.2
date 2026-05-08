-- ========================================
-- SOLUCIÓN CORREGIDA - CREAR PACIENTE CON COLUMNAS CORRECTAS
-- ========================================

-- VERIFICAR DATOS DEL USUARIO EXISTENTE
SELECT 
    'USUARIO EXISTENTE' as Tipo,
    u.id as UsuarioID,
    u.username,
    u.apellido,
    u.nombre,
    u.dni,
    u.email1,
    u.fechaCreacion
FROM dbo.Usuario u
WHERE u.dni = '55676837'

-- SOLUCIÓN DEFINITIVA CORREGIDA
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
    p.Email,
    'Ahora aparecerá en Exámenes Preventiva' as Estado
FROM dbo.Paciente p
WHERE p.dni = '55676837'

-- ========================================
// turbo
-- CORRECCIONES:
// 1. Se eliminó 'fechaCreacion' que no existe en Paciente
// 2. Se usa 'actualizacion_local' para la fecha de creación
// 3. Se usa 'email1' de Usuario para 'Email' de Paciente
// ========================================
