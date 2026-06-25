# Cómo Corregir el Tipo de Examen de un Paciente

## Problema
Cuando un paciente tiene un **TIPO PADRE** (Padre=1) en lugar de un **SUBTIPO** (Padre=0), la funcionalidad "Copiar Info" no funciona porque no encuentra la plantilla de mensaje correspondiente.

## Estructura de Tablas

### Tablas Principales
- **`dbo.Turno`**: Almacena los turnos con el código de identificación
- **`dbo.TipoExamenDePaciente`**: Relaciona el turno con el tipo de examen del paciente
- **`dbo.Especialidad`**: Almacena los tipos y subtipos de examen

### Relación entre Tipos y Subtipos
- **Tipo Padre (Padre=1)**: Categoría general (ej: FUTBOL, FUERZAS ARMADAS Y DE SEGURIDAD)
- **Subtipo (Padre=0)**: Especialidad específica (ej: FUTBOL METRO, ARMADA ARGENTINA)
- **IdPadre**: Referencia al tipo padre (solo en subtipos)

## Consultas SQL para Diagnóstico y Corrección

### Paso 1: Buscar el turno por código
```sql
SELECT 
    t.id as IdTurno,
    t.codigo as Codigo,
    t.fecha as FechaTurno,
    t.nroOrden as NroOrden,
    tep.id as IdTipoExamenDePaciente,
    tep.idEspecialidad,
    e.descripcion as TipoExamenActual,
    e.Padre as EsPadre,
    e.IdPadre
FROM dbo.Turno t
LEFT JOIN dbo.TipoExamenDePaciente tep ON tep.idTurno = t.id
LEFT JOIN dbo.Especialidad e ON tep.idEspecialidad = e.id
WHERE t.codigo = '635587'
```

**Resultado esperado:**
- `EsPadre = 1`: Indica que es un TIPO PADRE (incorrecto para el paciente)
- `EsPadre = 0`: Indica que es un SUBTIPO (correcto)

### Paso 2: Verificar los subtipos disponibles de un tipo padre
```sql
SELECT 
    p.id as IdPadre, 
    p.descripcion as TipoPadre, 
    s.id as IdSubtipo, 
    s.descripcion as Subtipo,
    s.estado as EstadoSubtipo
FROM dbo.Especialidad p
LEFT JOIN dbo.Especialidad s ON s.IdPadre = p.id AND s.Padre = 0
WHERE p.Padre = 1
  AND p.descripcion = 'FUTBOL'
ORDER BY s.descripcion
```

**Esto mostrará todos los subtipos disponibles bajo FUTBOL:**
- FUTBOL METRO
- FUTBOL METRO SIN LABORATORIO NI RX
- FUTBOL AFA
- FUTBOL PARTICULAR
- FUTBOL PRUEBA
- FUTBOL SENIOR

### Paso 3: Corregir el tipo de examen del paciente
```sql
UPDATE dbo.TipoExamenDePaciente
SET idEspecialidad = '60E94892-6F59-4202-A966-884FD71A5D8B'
WHERE id = '448843D9-C836-4919-9CFF-55E54B7612C1'
```

**Parámetros:**
- `idEspecialidad`: ID del subtipo correcto (ej: FUTBOL METRO)
- `id`: ID del registro en TipoExamenDePaciente (obtenido en el Paso 1)

### Paso 4: Verificar la corrección
```sql
SELECT 
    tep.id as IdTipoExamenDePaciente,
    tep.idEspecialidad,
    e.descripcion as TipoExamenActual,
    e.Padre as EsPadre,
    e.IdPadre
FROM dbo.TipoExamenDePaciente tep
INNER JOIN dbo.Especialidad e ON tep.idEspecialidad = e.id
WHERE tep.id = '448843D9-C836-4919-9CFF-55E54B7612C1'
```

**Resultado esperado:**
- `TipoExamenActual`: FUTBOL METRO
- `EsPadre`: 0

## IDs Comunes de Tipos de Examen

### FUTBOL (Tipo Padre)
- **ID**: D6A02B46-FB57-44E1-9469-6315FC8236EF

### Subtipos de FUTBOL
- **FUTBOL METRO**: 60E94892-6F59-4202-A966-884FD71A5D8B
- **FUTBOL METRO SIN LABORATORIO NI RX**: C260173E-3C3C-4AB0-8FAB-822DD540A3AA
- **FUTBOL AFA**: 48AD474E-FF97-4345-8BED-93219CD06D68
- **FUTBOL PARTICULAR**: EEBE9644-9FE3-4951-AA41-AC979482F3B5
- **FUTBOL PRUEBA**: A10C304E-2659-4116-9208-0FC4664BBF9A
- **FUTBOL SENIOR**: 167BAC87-DB6A-4C74-9880-EC1C2A98A555

## Resumen del Proceso

1. **Identificar el código del turno** (ej: 635587)
2. **Ejecutar la consulta del Paso 1** para obtener el IdTipoExamenDePaciente y el tipo actual
3. **Verificar si EsPadre = 1** (indica error)
4. **Ejecutar la consulta del Paso 2** para ver los subtipos disponibles
5. **Seleccionar el ID del subtipo correcto**
6. **Ejecutar el UPDATE del Paso 3** con el ID correcto
7. **Verificar con la consulta del Paso 4** que la corrección fue exitosa

## Precauciones

- **Siempre verificar la fecha del turno** antes de modificar
- **Hacer backup de los IDs originales** por si necesita revertir
- **Verificar que el subtipo esté activo (estado = 1)** antes de asignarlo
