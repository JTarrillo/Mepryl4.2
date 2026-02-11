# Análisis: Los 3 ComboBox Principales - TabPage 7 (Especialidad/TipoExamen)

## 📊 Los 3 ComboBox Jerárquicos

### 1️⃣ ComboBox 1: cboMotivoConsulta
**Línea**: 1387-1393

```csharp
private void cargarComboMotivoConsulta()
{
    cboMotivoConsulta.DataSource = tipoExamen.cargarMotivosDeConsultaTipoExamen();
    cboMotivoConsulta.ValueMember = "id";
    cboMotivoConsulta.DisplayMember = "nombre";
    cboMotivoConsulta.SelectedIndex = -1;
}
```

| Propiedad | Valor |
|-----------|-------|
| **Método de carga** | `tipoExamen.cargarMotivosDeConsultaTipoExamen()` |
| **ValueMember** | `id` (INT) |
| **DisplayMember** | `nombre` (VARCHAR) |
| **Tabla BD** | `MotivoDeConsulta` |
| **Propósito** | Seleccionar el Motivo de Consulta (primer nivel) |
| **Evento asociado** | SeleccionChangeCommitted → Carga cboSubTipo |

**Resultado esperado**:
```
Combo 1: [Seleccione...]
         [Examen Preventivo]
         [Examen Laboral]
         [Examen Aptitud]
```

---

### 2️⃣ ComboBox 2: cboSubTipo
**Línea**: 1410-1418

```csharp
private void cargarComboSubTipo()
{
    if (cboMotivoConsulta.SelectedIndex != -1)
    {
        cboSubTipo.DataSource = tipoExamen.cargarTiposDeExamenPadre(cboMotivoConsulta.SelectedValue.ToString());
        cboSubTipo.ValueMember = "id";
        cboSubTipo.DisplayMember = "descripcion";
        cboSubTipo.SelectedIndex = -1;
    }
}
```

| Propiedad | Valor |
|-----------|-------|
| **Método de carga** | `tipoExamen.cargarTiposDeExamenPadre(idMotivo)` |
| **Parámetro requerido** | `cboMotivoConsulta.SelectedValue` (id del motivo) |
| **ValueMember** | `id` (UNIQUEIDENTIFIER) |
| **DisplayMember** | `descripcion` (VARCHAR) |
| **Tabla BD** | `Especialidad` WHERE `Padre = 1` |
| **Propósito** | Cargar Especialidades PADRE del Motivo seleccionado |
| **Dependencia** | ✅ cboMotivoConsulta |
| **Evento asociado** | SelectionChangeCommitted → Carga cboTipoExamen |

**Resultado esperado**:
```
Combo 2: (vacío hasta seleccionar Combo 1)
         [Examen Preventivo Básico]      ← Padre
         [Examen Preventivo Completo]    ← Padre
         [Examen Preventivo Plus]        ← Padre
```

---

### 3️⃣ ComboBox 3: cboTipoExamen
**Línea**: 1396-1407

```csharp
private void cargarComboTipoExamen()
{
    if (cboMotivoConsulta.SelectedIndex != -1)
    {
        if (strEstadoEdicion != "EDITAR")
        {
            cboTipoExamen.DataSource = tipoExamen.cargarTiposDeExamenHijo(
                cboMotivoConsulta.SelectedValue.ToString(), 
                cboSubTipo.SelectedValue.ToString()  // ← IdPadre
            );
        }
        else
        {
            cboTipoExamen.DataSource = tipoExamen.cargarTiposDeExamenHijo(
                cboMotivoConsulta.SelectedValue.ToString()
            );
        }
        cboTipoExamen.ValueMember = "id";
        cboTipoExamen.DisplayMember = "descripcion";
        cboTipoExamen.SelectedIndex = -1;
    }
}
```

| Propiedad | Valor |
|-----------|-------|
| **Método de carga** | `tipoExamen.cargarTiposDeExamenHijo(idMotivo, idPadre?)` |
| **Parámetros requeridos** | `cboMotivoConsulta.SelectedValue` (id motivo) + `cboSubTipo.SelectedValue` (id padre) |
| **ValueMember** | `id` (UNIQUEIDENTIFIER) |
| **DisplayMember** | `descripcion` (VARCHAR) |
| **Tabla BD** | `Especialidad` WHERE `Padre = 0` AND `IdPadre = @idPadre` |
| **Propósito** | Cargar Especialidades HIJO del Padre seleccionado |
| **Dependencia** | ✅ cboMotivoConsulta + ✅ cboSubTipo |
| **Modo edición** | Si `strEstadoEdicion == "EDITAR"`: Solo pasa idMotivo |

**Resultado esperado**:
```
Combo 3: (vacío hasta seleccionar Combo 2)
         [Examen General]           ← Hijo del Padre seleccionado
         [Examen Cardiovascular]    ← Hijo del Padre seleccionado
         [Examen Respiratorio]      ← Hijo del Padre seleccionado
```

---

## 🔗 Flujo de Cascada

```
┌─────────────────────────────────────────────────────────────┐
│ PASO 1: Usuario abre TabPage 7                              │
│ → inicializar7()                                            │
│ → cargarComboMotivoConsulta()                               │
│ → cboMotivoConsulta = DataTable(id, nombre)                │
└────────────────────┬────────────────────────────────────────┘
                     │
┌────────────────────▼────────────────────────────────────────┐
│ PASO 2: Usuario selecciona Motivo en Combo 1               │
│ → cboMotivoConsulta_SelectionChangeCommitted()             │
│ → cargarComboSubTipo()                                      │
│ → cboSubTipo = SQL: SELECT * FROM Especialidad             │
│   WHERE Padre=1 AND idMotivoConsulta=@id                   │
└────────────────────┬────────────────────────────────────────┘
                     │
┌────────────────────▼────────────────────────────────────────┐
│ PASO 3: Usuario selecciona Padre en Combo 2                │
│ → cboSubTipo_SelectionChangeCommitted()                    │
│ → cargarComboTipoExamen()                                   │
│ → cboTipoExamen = SQL: SELECT * FROM Especialidad          │
│   WHERE Padre=0 AND IdPadre=@idPadre                       │
└────────────────────┬────────────────────────────────────────┘
                     │
┌────────────────────▼────────────────────────────────────────┐
│ PASO 4: Usuario selecciona Hijo en Combo 3                 │
│ → cboTipoExamen_SelectionChangeCommitted()                 │
│ → llenarFormulario()                                        │
│ → Carga TODOS los datos del Examen (97 items + info)      │
│ → Rellena 12 DataGridViews con categorías                  │
└─────────────────────────────────────────────────────────────┘
```

---

## 📥 Datos que se cargan en cada ComboBox

### Combo 1: MotivoDeConsulta
```sql
SELECT id, nombre FROM dbo.MotivoDeConsulta
-- Resultado: (3-5 registros típicos)
-- 1 | Examen Preventivo
-- 2 | Examen Laboral  
-- 3 | Examen Aptitud
```

### Combo 2: Especialidad PADRE
```sql
SELECT id, descripcion FROM dbo.Especialidad
WHERE Padre = 1 
  AND idMotivoConsulta = @idMotivo
-- Resultado: (si motivo=1, Examen Preventivo)
-- UUID-1 | Preventivo Básico
-- UUID-2 | Preventivo Completo
-- UUID-3 | Preventivo Plus
```

### Combo 3: Especialidad HIJO
```sql
SELECT id, descripcion FROM dbo.Especialidad
WHERE Padre = 0 
  AND IdPadre = @idPadre
  AND idMotivoConsulta = @idMotivo
-- Resultado: (si padre=Preventivo Completo)
-- UUID-A | Examen General
-- UUID-B | Examen Laboral
-- UUID-C | Laboratorio
```

---

## ⚙️ Métodos de Negocio Asociados

| ComboBox | Método BD | Descripción |
|----------|-----------|-------------|
| Combo 1 | `cargarMotivosDeConsultaTipoExamen()` | Obtiene motivos activos para Tipos de Examen |
| Combo 2 | `cargarTiposDeExamenPadre(idMotivo)` | Obtiene padres del motivo seleccionado |
| Combo 3 | `cargarTiposDeExamenHijo(idMotivo, idPadre)` | Obtiene hijos del padre seleccionado |

---

## 🎯 Flujo de Edición/Creación

### Cuando `strEstadoEdicion != "EDITAR"` (Crear nuevo):
```
Combo 1 → Combo 2 → Combo 3 (FLUJO NORMAL CASCADA)
```

### Cuando `strEstadoEdicion == "EDITAR"` (Editar existente):
```
Combo 1 → Combo 3 (DIRECTO, SIN Combo 2)
El Combo 2 NO se usa, va directo a cargarTiposDeExamenHijo(idMotivo)
```

---

## 📋 Información Cargada después de Seleccionar Combo 3

Una vez que el usuario selecciona un tipo de examen en **Combo 3**, se invoca:

```csharp
private void llenarFormulario()
{
    Entidades.TipoExamen entidad = tipoExamen.cargarEntidad(
        cboTipoExamen.SelectedValue.ToString()  // ID de la Especialidad
    );
    
    // Se cargan TODOS los datos:
    tbId7.Text = entidad.Id;                      // GUID
    tbCodigo7.Text = entidad.Codigo;              // INT
    tbDescripcion7.Text = entidad.Descripcion;    // VARCHAR
    tbDescripcionInformes.Text = entidad.DescripcionInformes;  // VARCHAR
    tbPrecioBase.Text = entidad.PrecioBase;       // DECIMAL
    
    // Se cargan 12 DataGridViews con los 97 items:
    llenarDataGrids(entidad);  // Distribuye items en categorías
}
```

---

## 🔍 Resumen Visual

```
ÁRBOL JERÁRQUICO:

MotivoDeConsulta (Combo 1)
    └── Especialidad.Padre=1 (Combo 2)
            └── Especialidad.Padre=0, IdPadre=xxx (Combo 3)
                    ├── EstudiosPorTipoExamen (97 booleanos)
                    │   ├── item1 (Clínico)
                    │   ├── item2 (Hematología)
                    │   ├── item3 (Química)
                    │   ...
                    │   └── item97 (Último)
                    │
                    └── Items (97 estudios catálogo)
                        ├── nombreCompleto
                        ├── nombreInformes
                        ├── ordenFormulario (1-12)
                        └── precioSuma/precioResta
```

---

## ⚠️ Casos Especiales

### Caso 1: Usuario selecciona Combo 1 → Combo 2 vacío
- Si no hay Especialidades PADRE para ese Motivo
- Combo 2 queda deshabilitado
- Combo 3 no se carga

### Caso 2: Usuario selecciona Combo 1 + Combo 2 → Combo 3 vacío
- Si no hay Especialidades HIJO para ese Padre
- Combo 3 queda deshabilitado
- Formulario no se rellena

### Caso 3: Estado Edición
- Combo 2 se ignora
- Combo 3 se carga directamente con todos los hijos del Motivo
- Usuario debe seleccionar el hijo a editar
