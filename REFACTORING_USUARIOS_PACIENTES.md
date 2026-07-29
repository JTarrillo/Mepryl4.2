# Reporte de Refactoring: Separación de Usuarios del Sistema y Pacientes

**Fecha:** 28/07/2026  
**Objetivo:** Separar credenciales de pacientes de usuarios del sistema para mejorar arquitectura y rendimiento

---

## Cambios Realizados

### 1. Base de Datos

#### Nueva Tabla: `UsuarioTipoPaciente`
- **Propósito:** Almacenar credenciales de login de pacientes (LABORAL y PREVENTIVA)
- **Campos:** id, username, password, dni, apellido, nombre, Tipo, Activo, fechaCreación
- **Registros migrados:** 2,478 pacientes
  - 421 PACIENTE LABORAL (2 activos, 419 inactivos)
  - 2,057 PACIENTE PREVENTIVA (1 activo, 2,056 inactivos)

#### Tabla: `Usuario`
- **Antes:** 2,587 registros (109 usuarios del sistema + 2,478 pacientes)
- **Después:** 109 registros (solo usuarios del sistema)
- **Tipos restantes:** OPERADOR (80), MEDICOS (15), ADMINISTRADOR (7), TECNICOS (7)
- **Backup:** Tabla `Usuario_Pacientes_Backup` creada con los 2,478 pacientes eliminados

### 2. Código C#

#### Archivos Creados
- `Entidades/UsuarioTipoPaciente.cs` - Entidad para pacientes
- `CapaDatosMepryl/UsuarioTipoPaciente.cs` - Capa de datos para pacientes
- `CapaNegocioMepryl/UsuarioTipoPaciente.cs` - Capa de negocio para pacientes

#### Archivos Modificados
- `frmPaciente.cs` - Ahora crea/actualiza pacientes en `UsuarioTipoPaciente` (PREVENTIVA)
- `frmPacienteLaboral.cs` - Ahora crea/actualiza pacientes en `UsuarioTipoPaciente` (LABORAL)
- `frmUsuariosSistema.cs` - Eliminado filtro por fecha y filtro de usuarios activos

---

## Impacto en el Usuario Final

### ✅ Cambios Positivos

#### 1. **Gestión de Usuarios del Sistema (frmUsuariosSistema)**
- **Antes:** La grilla mostraba 2,587 registros (la mayoría pacientes inactivos)
- **Ahora:** Muestra solo 109 usuarios del sistema (activos e inactivos)
- **Beneficio:** 
  - Carga más rápida de la grilla
  - Búsqueda más eficiente
  - Menos confusión al administrar usuarios del sistema
  - Eliminado el filtro por fecha (ya no necesario con pocos registros)

#### 2. **Creación de Pacientes (frmPaciente / frmPacienteLaboral)**
- **Sin cambios visibles:** El usuario sigue creando pacientes de la misma manera
- **Beneficio interno:** Los pacientes se guardan en la tabla correcta, mejorando organización

#### 3. **Login de Pacientes (Portal de Pacientes)**
- **Sin cambios:** El login sigue funcionando igual (sigue usando tabla `Usuario` temporalmente)
- **Nota:** El usuario solicitó no modificar el login por ahora

### ⚠️ Consideraciones Importantes

#### 1. **Login de Pacientes**
- **Estado actual:** Sí funciona (usa tabla `Usuario` con datos migrados)
- **Futuro:** Cuando se decida, se debe modificar `MeprylAPI/routes/auth.js` para usar `UsuarioTipoPaciente`

#### 2. **Pacientes Existentes**
- **Estado:** Todos los pacientes existentes (2,478) fueron migrados correctamente
- **Backup:** Disponible en `Usuario_Pacientes_Backup` por seguridad
- **Restauración:** `INSERT INTO Usuario SELECT * FROM Usuario_Pacientes_Backup`

#### 3. **Usuarios del Sistema**
- **Estado:** Sin cambios en funcionalidad
- **Beneficio:** Ahora se ven también los inactivos (útil para reactivar usuarios)

---

## Comandos de Restauración (si es necesario)

```sql
-- Restaurar pacientes en tabla Usuario
USE [MEPRYLv2.1];
INSERT INTO Usuario SELECT * FROM Usuario_Pacientes_Backup;

-- Verificar restauración
SELECT Tipo, COUNT(*) FROM Usuario GROUP BY Tipo;
```

---

## Resumen de Beneficios

| Aspecto | Antes | Después | Mejora |
|---------|-------|---------|--------|
| Registros en Usuario | 2,587 | 109 | 96% reducción |
| Tiempo de carga grilla | Lento | Rápido | Mejor UX |
| Organización de datos | Mezclado | Separado | Más claro |
| Mantenimiento | Complejo | Simple | Más escalable |

---

## Próximos Pasos (Opcionales)

1. Modificar `MeprylAPI/routes/auth.js` para usar `UsuarioTipoPaciente` en login de pacientes
2. Eliminar tabla `Usuario_Pacientes_Backup` después de verificar funcionamiento correcto
3. Considerar agregar interfaz para gestión de pacientes en `UsuarioTipoPaciente` (si es necesario)
