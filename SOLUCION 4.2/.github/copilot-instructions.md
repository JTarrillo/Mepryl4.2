# AI Coding Agent Instructions

## Project Overview
This project is a Windows-based application written in C# using WinForms. It is structured into multiple layers, including `CapaDatos`, `CapaNegocio`, and `CapaPresentacion`, following a layered architecture. The primary focus is on managing and interacting with `TipoExamen` and `Especialidad` entities.

### Key Components:
- **CapaPresentacion**: Handles the user interface, including forms like `FrmAñadirEspecialidad`.
- **CapaNegocio**: Contains business logic, such as methods for updating the state of `TipoExamen` and `Especialidad`.
- **CapaDatos**: Manages data access, including database interactions.

## Developer Workflows

### Building the Project
1. Open the solution file `Mepryl 3.8.sln` in Visual Studio.
2. Build the solution using `Ctrl+Shift+B`.

### Running the Application
1. Set the startup project to the desired form (e.g., `FrmAñadirEspecialidad`).
2. Press `F5` to start debugging.

### Testing Changes
- Ensure that any changes to the `DataGridView` event handlers (e.g., `DgvTiposExamenes_CellValueChanged`) are tested thoroughly, as they involve complex interactions with the UI and database.

## Project-Specific Conventions

### Event Handling
- Use flags like `actualizandoEstadoMotivo` to prevent recursive or duplicate event handling.
- Always reset flags in `finally` blocks to ensure consistent behavior.

### DataGridView Patterns
- Use `DataRowView` to access underlying data rows.
- Update related rows in the grid to maintain consistency (e.g., updating all rows with the same `idMotivoConsulta`).

### ComboBox Updates
- Reload ComboBox data after making changes to the database to reflect the latest state.
- Use `BeginInvoke` to update UI elements asynchronously.

### Messaging
- Use `MessageBox.Show` to provide clear feedback to the user about the success or failure of operations.

## Integration Points

### Database
- The `CapaNegocioMepryl.TipoExamen` class interacts with the database to update the state of `TipoExamen` and `Especialidad` entities.
- Ensure that database methods like `ActualizarEstadoMotivoConsulta` and `ActualizarEstadoEspecialidad` are called with the correct parameters.

### Cross-Component Communication
- Use events like `CombosChanged` to notify other components of changes.
- Ensure that event handlers are properly subscribed and unsubscribed to avoid memory leaks.

## Examples

### Updating a `DataGridView` Cell
```csharp
if (columnName == "EstadoMotivo")
{
    bool estadoMotivo = Convert.ToBoolean(row.Cells["EstadoMotivo"]?.Value ?? false);
    var resultado = negocioTipoExamen.ActualizarEstadoMotivoConsulta(idMotivoFila, estadoMotivo ? 1 : 0);
    if (resultado.Modo > 0)
    {
        MessageBox.Show("Update successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
```

### Reloading ComboBox Data
```csharp
this.BeginInvoke(new Action(() =>
{
    CargarTiposExamen();
    CargarSubtipos();
}));
```

## Notes
- Follow the existing patterns in `FrmAñadirEspecialidad` for consistency.
- Avoid making changes to the database schema without prior approval.

---
This document is a living guide. Update it as the project evolves.