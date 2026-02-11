# Ejemplo de Integración: Cascada de Filtros en frmTurnos.cs

## Código de Ejemplo Completo

### 1. Variables en el formulario (agregar después de las variables existentes)

```csharp
// Variables para la cascada
private string strIdMotivoConsultaActual = "";
private string strIdEspecialidadPadreActual = "";
private string strIdEspecialidadHijoActual = "";
```

### 2. Método para cargar la cascada en inicializar()

```csharp
private void inicializarCascada()
{
    // Cargar Motivos de Consulta (Nivel 1)
    DataTable motivosConsulta = turno.cargarMotivosConsultaTurno();
    
    // Aquí vincularías a un ComboBox
    // cmbMotivoConsulta.DataSource = motivosConsulta;
    // cmbMotivoConsulta.DisplayMember = "nombre";
    // cmbMotivoConsulta.ValueMember = "id";
}
```

### 3. Evento de selección del Motivo de Consulta

```csharp
private void cmbMotivoConsulta_SelectedIndexChanged(object sender, EventArgs e)
{
    try
    {
        if (cmbMotivoConsulta.SelectedValue == null)
            return;

        strIdMotivoConsultaActual = cmbMotivoConsulta.SelectedValue.ToString();
        
        // Cargar especialidades padre (Nivel 2)
        DataTable especialidadesPadre = turno.cargarNivel1EspecialidadTurno(strIdMotivoConsultaActual);
        
        cmbEspecialidad.DataSource = especialidadesPadre;
        cmbEspecialidad.DisplayMember = "descripcion";
        cmbEspecialidad.ValueMember = "id";
        
        // Limpiar especialidad hijo
        cmbSubTipo.DataSource = null;
        strIdEspecialidadPadreActual = "";
        strIdEspecialidadHijoActual = "";
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error al cargar especialidades: " + ex.Message, "Error");
    }
}
```

### 4. Evento de selección de Especialidad Padre

```csharp
private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
{
    try
    {
        if (cmbEspecialidad.SelectedValue == null)
            return;

        strIdEspecialidadPadreActual = cmbEspecialidad.SelectedValue.ToString();
        
        // Verificar si tiene subcategorías
        DataTable tieneHijos = turno.verificarEspecialidadTieneSub(strIdEspecialidadPadreActual);
        
        if (tieneHijos.Rows.Count > 0)
        {
            // Cargar especialidades hijo (Nivel 3)
            DataTable especialidadesHijo = turno.cargarNivel2EspecialidadTurno(strIdEspecialidadPadreActual);
            
            cmbSubTipo.DataSource = especialidadesHijo;
            cmbSubTipo.DisplayMember = "descripcion";
            cmbSubTipo.ValueMember = "id";
            cmbSubTipo.Enabled = true;
            
            strIdEspecialidadHijoActual = "";
        }
        else
        {
            // No tiene subcategorías, usar esta especialidad directamente
            cmbSubTipo.DataSource = null;
            cmbSubTipo.Enabled = false;
            strIdEspecialidadHijoActual = strIdEspecialidadPadreActual;
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error al cargar subtipos: " + ex.Message, "Error");
    }
}
```

### 5. Evento de selección de Especialidad Hijo

```csharp
private void cmbSubTipo_SelectedIndexChanged(object sender, EventArgs e)
{
    try
    {
        if (cmbSubTipo.SelectedValue == null)
            return;

        strIdEspecialidadHijoActual = cmbSubTipo.SelectedValue.ToString();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error al seleccionar subtipo: " + ex.Message, "Error");
    }
}
```

### 6. Método para obtener la especialidad final seleccionada

```csharp
private string ObtenerEspecialidadFinal()
{
    // Si hay especialidad hijo seleccionada, usar esa
    if (!string.IsNullOrEmpty(strIdEspecialidadHijoActual))
        return strIdEspecialidadHijoActual;
    
    // Si no, usar la especialidad padre
    if (!string.IsNullOrEmpty(strIdEspecialidadPadreActual))
        return strIdEspecialidadPadreActual;
    
    return "";
}
```

### 7. Usarlo al asignar turno

```csharp
private void botAsignarTurno_Click(object sender, EventArgs e)
{
    try
    {
        string idEspecialidadFinal = ObtenerEspecialidadFinal();
        
        if (string.IsNullOrEmpty(idEspecialidadFinal))
        {
            MessageBox.Show("Debe seleccionar una especialidad", "Validación");
            return;
        }
        
        // Continuar con la lógica de asignación de turno
        // usando idEspecialidadFinal como el ID de especialidad a asignar
        
        Guid guidEspecialidad = new Guid(idEspecialidadFinal);
        
        // Llamar al método de negocio para asignar el turno
        // ...tu lógica aquí...
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error al asignar turno: " + ex.Message, "Error");
    }
}
```

## Configuración en el Diseñador del Formulario

Necesitarías agregar los siguientes controles en el formulario (si no existen):

```csharp
// En Designer.cs, agregar:

private System.Windows.Forms.ComboBox cmbMotivoConsulta;
private System.Windows.Forms.ComboBox cmbEspecialidad;
private System.Windows.Forms.ComboBox cmbSubTipo;

// Y sus labels correspondientes:
private System.Windows.Forms.Label lblMotivoConsulta;
private System.Windows.Forms.Label lblEspecialidad;
private System.Windows.Forms.Label lblSubTipo;
```

## Diagrama de Flujo

```
┌─────────────────────────────────────────┐
│ Inicializar Formulario                  │
│ inicializarCascada()                    │
└────────────────┬────────────────────────┘
                 │
                 ▼
┌─────────────────────────────────────────┐
│ cmbMotivoConsulta_SelectedIndexChanged  │
│ Cargar Especialidades Padre (Nivel 1)   │
└────────────────┬────────────────────────┘
                 │
                 ▼
┌─────────────────────────────────────────┐
│ cmbEspecialidad_SelectedIndexChanged    │
│ Verificar si tiene hijos                │
└────────────────┬────────────────────────┘
                 │
         ┌───────┴───────┐
         │               │
    SI (tiene hijos)   NO (es final)
         │               │
         ▼               ▼
    ┌────────┐      ┌─────────────┐
    │ Cargar │      │ Usar como   │
    │ Nivel2 │      │ especialidad│
    │        │      │ final       │
    └────┬───┘      └─────┬───────┘
         │                │
         ▼                ▼
    ┌─────────────────────────────────────┐
    │ cmbSubTipo_SelectedIndexChanged      │
    │ Guardar selección final             │
    └────────────────┬────────────────────┘
                     │
                     ▼
            ┌─────────────────┐
            │ Asignar Turno   │
            │ con especialidad│
            │ final           │
            └─────────────────┘
```

## Ventajas de esta Implementación

1. **Flexibilidad**: Soporta especialidades con múltiples niveles
2. **Mantiene funcionalidad**: No afecta la asignación de turnos existente
3. **Reutilizable**: Los métodos se pueden usar en otros formularios
4. **Seguridad**: Valida entrada y maneja excepciones
5. **Escalable**: Fácil agregar más niveles si es necesario

## Testing

Para verificar que funcione correctamente:

1. Seleccionar un Motivo de Consulta
2. Verificar que el combo de Especialidad se carga
3. Seleccionar una Especialidad
4. Verificar que:
   - Si tiene hijos, se cargue el combo de SubTipo
   - Si no tiene hijos, el combo de SubTipo se deshabilite
5. Asignar un turno y verificar que se asigne correctamente
