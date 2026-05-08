-- ========================================
-- ACTIVACIÓN DEL USUARIO EN TABLA USUARIO
-- DNI: 55676837 - Varela Benicio William Eliel
-- ========================================

-- 1. VERIFICAR USUARIO EXISTENTE EN TABLA USUARIO
SELECT 
    id,
    username,
    apellido,
    nombre,
    dni,
    Activo,
    CASE 
        WHEN Activo = 1 THEN 'Activo'
        WHEN Activo = 0 THEN 'Inactivo'
        ELSE 'Desconocido'
    END as EstadoActual,
    fechaCreacion
FROM dbo.Usuario 
WHERE dni = '55676837'

-- 2. VERIFICAR SI EXISTE RELACIÓN CON TABLA PACIENTE
SELECT 
    u.id as UsuarioID,
    u.username,
    u.dni as UsuarioDNI,
    p.id as PacienteID,
    p.dni as PacienteDNI,
    u.Activo as UsuarioActivo,
    'Relación Usuario-Paciente' as Tipo
FROM dbo.Usuario u
LEFT JOIN dbo.Paciente p ON u.dni = p.dni
WHERE u.dni = '55676837'

-- 3. ACTUALIZACIÓN PARA ACTIVAR EL USUARIO
-- Descomenta la siguiente línea para ejecutar la activación
-- UPDATE dbo.Usuario 
-- SET Activo = 1
-- WHERE dni = '55676837'

-- 4. VERIFICACIÓN DESPUÉS DE ACTIVAR
SELECT 
    id,
    username,
    apellido,
    nombre,
    dni,
    Activo,
    CASE 
        WHEN Activo = 1 THEN 'Activo'
        WHEN Activo = 0 THEN 'Inactivo'
        ELSE 'Desconocido'
    END as EstadoDespuesActivar,
    fechaCreacion
FROM dbo.Usuario 
WHERE dni = '55676837'

-- 5. VERIFICAR SI TIENE PERMISOS DE PACIENTES
SELECT 
    id,
    username,
    VentPacientes,
    VentTurnos,
    VentMesa,
    VentVentanilla,
    PermisoVer,
    PermisoModificar,
    PermisoEliminar,
    Activo
FROM dbo.Usuario 
WHERE dni = '55676837'

-- ========================================
-- INSTRUCCIONES:
-- 1. Ejecuta la consulta 1 para ver el estado actual del usuario
-- 2. Ejecuta la consulta 2 para verificar la relación con Paciente
-- 3. Descomenta y ejecuta la consulta 3 para activar el usuario
-- 4. Ejecuta la consulta 4 para verificar que quedó activo
-- 5. Ejecuta la consulta 5 para verificar sus permisos
-- 
-- NOTA: El campo es de tipo BIT, por lo que se usa 1 (activo) o 0 (inactivo)
-- ========================================
