# Documentación: Cascada de Filtros en Turnos

## Descripción General
Se ha implementado una cascada de filtros para Turnos que funciona de la siguiente manera:

1. **Nivel 1**: Cargar Motivos de Consulta (PREVENTIVA, LABORAL, etc.)
2. **Nivel 2**: Cargar Especialidades Padre (CARDIOLOGÍA, NEUMOLOGÍA, etc.) según el Motivo
3. **Nivel 3**: Cargar Especialidades Hijo (subcategorías) según la Especialidad Padre

## Métodos Implementados

### En CapaDatosMepryl.Turno

```csharp
/// Carga los Motivos de Consulta disponibles
public DataTable cargarMotivosConsultaTurno()

/// Carga las Especialidades padre (Padre=1) para un MotivoDeConsulta
public DataTable cargarNivel1EspecialidadTurno(string idMotivoConsulta)

/// Carga las Especialidades hijo (Padre=0) para un IdPadre
public DataTable cargarNivel2EspecialidadTurno(string idPadre)

/// Verifica si una especialidad tiene subcategorías
public DataTable verificarEspecialidadTieneSub(string idEspecialidad)
```

### En CapaNegocioMepryl.Turno

Los mismos métodos están disponibles en la capa de negocio:

```csharp
public DataTable cargarMotivosConsultaTurno()
public DataTable cargarNivel1EspecialidadTurno(string idMotivoConsulta)
public DataTable cargarNivel2EspecialidadTurno(string idPadre)
public DataTable verificarEspecialidadTieneSub(string idEspecialidad)
```

## Ejemplo de Uso en frmTurnos

### Paso 1: Cargar Motivos de Consulta
```csharp
DataTable motivosConsulta = turno.cargarMotivosConsultaTurno();
// Usar para llenar combo de Motivos
cmbMotivo.DataSource = motivosConsulta;
cmbMotivo.DisplayMember = "nombre";
cmbMotivo.ValueMember = "id";
```

### Paso 2: Cuando se selecciona un Motivo
```csharp
private void cmbMotivo_SelectedIndexChanged(object sender, EventArgs e)
{
    string idMotivo = cmbMotivo.SelectedValue.ToString();
    
    // Cargar especialidades padre (Nivel 1)
    DataTable nivel1 = turno.cargarNivel1EspecialidadTurno(idMotivo);
    cmbEspecialidad.DataSource = nivel1;
    cmbEspecialidad.DisplayMember = "descripcion";
    cmbEspecialidad.ValueMember = "id";
    
    cmbSubTipo.DataSource = null; // Limpiar combo de Nivel 3
}
```

### Paso 3: Cuando se selecciona una Especialidad Padre
```csharp
private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
{
    string idEspecialidad = cmbEspecialidad.SelectedValue.ToString();
    
    // Verificar si tiene subcategorías
    DataTable tieneHijos = turno.verificarEspecialidadTieneSub(idEspecialidad);
    
    if (tieneHijos.Rows.Count > 0)
    {
        // Cargar especialidades hijo (Nivel 2)
        DataTable nivel2 = turno.cargarNivel2EspecialidadTurno(idEspecialidad);
        cmbSubTipo.DataSource = nivel2;
        cmbSubTipo.DisplayMember = "descripcion";
        cmbSubTipo.ValueMember = "id";
    }
    else
    {
        // No tiene subcategorías, usar la especialidad directamente
        cmbSubTipo.DataSource = null;
    }
}
```

## Estructura de Datos

### MotivoDeConsulta
- id (int)
- nombre (string) - Ej: PREVENTIVA, LABORAL

### Especialidad (Nivel 1 - Padre)
- id (guid)
- codigo (int)
- descripcion (string) - Ej: CARDIOLOGÍA
- Padre = 1
- IdPadre = null

### Especialidad (Nivel 2 - Hijo)
- id (guid)
- codigo (int)
- descripcion (string) - Ej: Ecocardiograma
- Padre = 0
- IdPadre = (referencia al Padre)

## Características Importantes

1. **Filtrado por Estado**: Las especialidades eliminadas en `EspecialidadesEliminadas` se excluyen automáticamente.
2. **Ordenamiento**: Se ordena por código numérico (convertido a int) si es posible, sino por código alfabético.
3. **No incluye "VISITAS"**: Se excluyen automáticamente los motivos llamados "VISITAS".
4. **Mantiene la funcionalidad de Turnos**: Los métodos existentes de asignación y gestión de turnos siguen funcionando normalmente.

## Flujo Completo

```
Usuario selecciona Motivo de Consulta
    ↓
Se cargan Especialidades Padre (Nivel 1)
    ↓
Usuario selecciona Especialidad Padre
    ↓
Se verifica si tiene hijos (Nivel 2)
    ↓
Si tiene hijos: mostrar combo con SubTipos
Si NO tiene hijos: usar la especialidad directamente
    ↓
Asignar Turno con la especialidad final seleccionada
```

## Métodos Auxiliares

### verificarEspecialidadTieneSub
Retorna un DataTable vacío si la especialidad es final (no tiene subcategorías).
Retorna un DataTable con filas si tiene subcategorías.

Uso:
```csharp
DataTable tieneHijos = turno.verificarEspecialidadTieneSub(idEspecialidad);
if (tieneHijos.Rows.Count > 0)
{
    // Tiene subcategorías
}
```

## Notas de Implementación

- Todos los métodos utilizan `SQLConnector.obtenerTablaSegunConsultaString()` para consultas a BD
- Se maneja validación de entrada para IDs numéricos
- Se retornan DataTables vacíos para casos de error o entrada inválida
- Los métodos son reutilizables y independientes de la UI
