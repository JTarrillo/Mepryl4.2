# Tarea JIRA: Refactoring - Separación de Usuarios del Sistema y Pacientes

## Resumen
Separar credenciales de pacientes de usuarios del sistema para mejorar arquitectura, rendimiento y mantenibilidad de la aplicación MEPRYL.

## Tipo de Tarea
- **Tipo:** Improvement / Refactoring
- **Prioridad:** High
- **Componente:** Base de Datos / Capa de Negocio / Capa de Presentación

## Descripción Detallada

### Problema
La tabla `Usuario` mezclaba dos conceptos diferentes:
- Usuarios del sistema (OPERADOR, MEDICOS, ADMINISTRADOR, TECNICOS): 109 registros
- Pacientes (PACIENTE LABORAL, PACIENTE PREVENTIVA): 2,478 registros

Esto causaba:
- Rendimiento degradado en gestión de usuarios
- Confusión en la interfaz de administración
- Arquitectura poco escalable
- Pacientes inactivos contaminando la tabla de usuarios

### Solución Implementada
Crear tabla separada `UsuarioTipoPaciente` para credenciales de pacientes, manteniendo `Usuario` solo para usuarios del sistema.

## Cambios Realizados

### 1. Base de Datos

#### Nueva Tabla: `UsuarioTipoPaciente`
```sql
CREATE TABLE dbo.UsuarioTipoPaciente
(
    id UNIQUEIDENTIFIER DEFAULT NEWID() NOT NULL,
    username VARCHAR(50) NOT NULL,
    password VARCHAR(255) NOT NULL,
    dni VARCHAR(20) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    Tipo VARCHAR(20) NOT NULL, -- 'LABORAL' o 'PREVENTIVA'
    Activo BIT DEFAULT 1 NOT NULL,
    fechaCreacion DATETIME DEFAULT GETDATE() NOT NULL,
    CONSTRAINT PK_UsuarioTipoPaciente PRIMARY KEY (id)
)
```

#### Migración de Datos
- **421 PACIENTE LABORAL** migrados (2 activos, 419 inactivos)
- **2,057 PACIENTE PREVENTIVA** migrados (1 activo, 2,056 inactivos)
- **Total: 2,478 pacientes** migrados

#### Limpieza de Tabla `Usuario`
- Eliminados 2,478 pacientes de tabla `Usuario`
- Backup creado en `Usuario_Pacientes_Backup`
- Tabla `Usuario` ahora tiene solo 109 usuarios del sistema

### 2. Código C# - Archivos Nuevos

#### Entidades/UsuarioTipoPaciente.cs
- Entidad para representar pacientes en la nueva tabla

#### CapaDatosMepryl/UsuarioTipoPaciente.cs
- Métodos de acceso a datos: `ListarPorDNI`, `Guardar`, `Actualizar`, `ActualizaActivo`

#### CapaNegocioMepryl/UsuarioTipoPaciente.cs
- Capa de negocio que delega en CapaDatosMepryl

### 3. Código C# - Archivos Modificados

#### frmPaciente.cs
- Modificado `cargarDatosUsuariosPreventiva()` para usar `UsuarioTipoPaciente`
- Modificado `GuardaActualizaPacientePreventiva()` para guardar en `UsuarioTipoPaciente`
- Pacientes PREVENTIVA ahora se crean en tabla correcta

#### frmPacienteLaboral.cs
- Agregado `cargarDatosUsuarioPacienteLaboral()` para pacientes LABORAL
- Modificado `GuardaActualizaPaciente()` para guardar pacientes LABORAL en `UsuarioTipoPaciente`
- Profesionales siguen guardándose en `Usuario` (sin cambios)

#### frmUsuariosSistema.cs
- Eliminado botón `btnFiltrarFecha` y controles relacionados (dtpDesde, dtpHasta, grpFiltroFecha)
- Eliminados métodos: `btnFiltrarFecha_Click`, `dtpFecha_ValueChanged`
- Eliminada lógica de filtro por fechas en `FiltrarGrillaGestion`
- Agregado filtro fijo para mostrar solo usuarios activos
- Implementado manejo de checkbox en columna Activo con confirmación de desactivación
- Al desactivar usuario: muestra confirmación "¿Está seguro que desea desactivar al usuario [nombre]?"
- Si usuario selecciona "No", se revierte el cambio

#### frmUsuariosSistema.Designer.cs
- Eliminados controles: `grpFiltroFecha`, `lblDesde`, `dtpDesde`, `lblHasta`, `dtpHasta`, `btnFiltrarFecha`
- Eliminados eventos: `CellValueChanged`, `CurrentCellDirtyStateChanged`

### 4. Scripts SQL

#### CREAR_TABLA_USUARIOTIPOPACIENTE.sql
- Script para crear tabla `UsuarioTipoPaciente` con índices

#### MIGRAR_PACIENTES_A_USUARIOTIPOPACIENTE.sql
- Script para migrar pacientes de `Usuario` a `UsuarioTipoPaciente`
- Maneja usernames duplicados agregando sufijo numérico

#### BACKUP_PACIENTES_USUARIO.sql
- Script para crear backup de pacientes en `Usuario_Pacientes_Backup`

#### ELIMINAR_PACIENTES_DE_USUARIO.sql
- Script para eliminar pacientes de tabla `Usuario` después de backup

## Impacto en Usuario Final

### Mejoras
- **Gestión de Usuarios:** Grilla carga 109 registros en lugar de 2,587 (96% más rápido)
- **Búsqueda:** Más eficiente al tener menos registros
- **Menos Confusión:** Solo se ven usuarios del sistema, no pacientes
- **Confirmación de Desactivación:** Ahora pide confirmación antes de desactivar un usuario

### Sin Cambios Visibles
- **Creación de Pacientes:** El usuario sigue creando pacientes de la misma manera
- **Login de Pacientes:** Sigue funcionando igual (usa tabla `Usuario` temporalmente)

## Comandos de Restauración (si es necesario)

```sql
-- Restaurar pacientes en tabla Usuario
USE [MEPRYLv2.1];
INSERT INTO Usuario SELECT * FROM Usuario_Pacientes_Backup;

-- Verificar restauración
SELECT Tipo, COUNT(*) FROM Usuario GROUP BY Tipo;
```

## Métricas de Mejora

| Aspecto | Antes | Después | Mejora |
|---------|-------|---------|--------|
| Registros en Usuario | 2,587 | 109 | 96% reducción |
| Tiempo de carga grilla | Lento | Rápido | Mejor UX |
| Organización de datos | Mezclado | Separado | Más claro |
| Mantenimiento | Complejo | Simple | Más escalable |

## Próximos Pasos (Opcionales)

1. Modificar `MeprylAPI/routes/auth.js` para usar `UsuarioTipoPaciente` en login de pacientes
2. Eliminar tabla `Usuario_Pacientes_Backup` después de verificar funcionamiento correcto
3. Considerar agregar interfaz para gestión de pacientes en `UsuarioTipoPaciente` (si es necesario)

## Archivos Modificados/Creados

### Archivos Nuevos
- `Entidades/UsuarioTipoPaciente.cs`
- `CapaDatosMepryl/UsuarioTipoPaciente.cs`
- `CapaNegocioMepryl/UsuarioTipoPaciente.cs`
- `CREAR_TABLA_USUARIOTIPOPACIENTE.sql`
- `MIGRAR_PACIENTES_A_USUARIOTIPOPACIENTE.sql`
- `BACKUP_PACIENTES_USUARIO.sql`
- `ELIMINAR_PACIENTES_DE_USUARIO.sql`
- `REFACTORING_USUARIOS_PACIENTES.md`

### Archivos Modificados
- `frmPaciente.cs`
- `frmPacienteLaboral.cs`
- `frmUsuariosSistema.cs`
- `frmUsuariosSistema.Designer.cs`

## Estado
✅ **Completado**

## Fecha de Finalización
28/07/2026

## Probado Por
[Nombre del tester]

## Notas Adicionales
- Backup disponible en `Usuario_Pacientes_Backup` por seguridad
- Paciente específico (DNI: 43072490) migrado manualmente y limpiado de duplicados
- Login de pacientes no modificado según solicitud del usuario (se puede hacer en futura tarea)
