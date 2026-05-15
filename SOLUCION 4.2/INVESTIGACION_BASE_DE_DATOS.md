# Investigación de Base de Datos - Problema Tipo/Subtipo de Examen

## 📋 Resumen del Problema
- Algunos registros antiguos tienen `idEspecialidad` apuntando a **padres** (`Padre=1`)
- Registros nuevos tienen `idEspecialidad` apuntando a **hijos** (`Padre=0`)
- El procedimiento `sp_TipoExamenDePaciente_UpdateTipoExamenPaciente` verificaba que solo se acepten subtipos, lo que causaba errores con registros antiguos

---

## 🗄️ Estructura de Tablas

### Tabla: `Especialidad`
| Campo          | Tipo           | Descripción                          |
|----------------|----------------|--------------------------------------|
| `id`           | uniqueidentifier | ID de la especialidad                |
| `descripcion`  | varchar        | Nombre de la especialidad            |
| `Padre`        | bit            | 1 = es padre, 0 = es hijo           |
| `IdPadre`      | uniqueidentifier | ID del padre (solo para hijos)      |
| `idMotivoConsulta` | int        | ID del motivo de consulta            |

### Tabla: `Horario`
| Campo             | Tipo           | Descripción                          |
|-------------------|----------------|--------------------------------------|
| `id`              | uniqueidentifier | ID del horario                       |
| `especialidadID`  | uniqueidentifier | ID de la especialidad asociada       |
| `profesionalID`   | uniqueidentifier | ID del profesional                   |

### Tabla: `Turno`
| Campo             | Tipo           | Descripción                          |
|-------------------|----------------|--------------------------------------|
| `id`              | uniqueidentifier | ID del turno                         |
| `horarioID`       | uniqueidentifier | ID del horario asociado              |
| `pacienteID`      | uniqueidentifier | ID del paciente                      |
| `fecha`           | datetime       | Fecha del turno                      |

### Tabla: `TipoExamenDePaciente`
| Campo             | Tipo           | Descripción                          |
|-------------------|----------------|--------------------------------------|
| `id`              | uniqueidentifier | ID del registro                      |
| `idConsulta`      | uniqueidentifier | ID de la consulta                    |
| `idTurno`         | uniqueidentifier | ID del turno asociado                |
| `idEspecialidad`  | uniqueidentifier | ID de la especialidad (padre o hijo)|

---

## 🔧 Procedimientos Almacenados

### `sp_TipoExamenDePaciente_UpdateTipoExamenPaciente`
**Antes (con restricción):**
```sql
CREATE PROCEDURE sp_TipoExamenDePaciente_UpdateTipoExamenPaciente
@idConsulta uniqueidentifier,
@idEspecialidad uniqueidentifier
AS
IF EXISTS (SELECT 1 FROM dbo.Especialidad WHERE id = @idEspecialidad AND Padre = 0)
BEGIN
    UPDATE dbo.TipoExamenDePaciente
    SET idEspecialidad = @idEspecialidad
    WHERE idConsulta = @idConsulta
END
ELSE
BEGIN
    RAISERROR('El idEspecialidad no corresponde a un subtipo (Padre=0)', 16, 1) 
END
```

**Después (sin restricción):**
```sql
ALTER PROCEDURE sp_TipoExamenDePaciente_UpdateTipoExamenPaciente
@idConsulta uniqueidentifier,
@idEspecialidad uniqueidentifier
AS
UPDATE dbo.TipoExamenDePaciente
SET idEspecialidad = @idEspecialidad
WHERE idConsulta = @idConsulta
```

---

## 📊 Ejemplos de Registros

### Registros en `TipoExamenDePaciente`
| idEspecialidad | Especialidad       | Padre | IdPadre | Tipo de Registro |
|-----------------|--------------------|-------|---------|------------------|
| [GUID]          | CAMIONEROS SENIOR  | 1     | NULL    | Padre (antiguo)  |
| [GUID]          | FUTBOL METRO       | 0     | [GUID]  | Hijo (nuevo)     |
| [GUID]          | LEY + LUMBAR (P)   | 0     | [GUID]  | Hijo (nuevo)     |

---

## ✅ Solución Implementada

1. **Modificación del procedimiento almacenado**: Se quitó la restricción que requería `Padre=0`
2. **Ahora acepta**: Tanto padres (`Padre=1`) como hijos (`Padre=0`)
3. **Compatibilidad**: Funciona con registros antiguos y nuevos
