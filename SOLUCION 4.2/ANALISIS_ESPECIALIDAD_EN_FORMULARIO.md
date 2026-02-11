# Análisis: frmLocalidadNacionalidad.cs - Interacción con Tabla ESPECIALIDAD

## 📌 Resumen Ejecutivo

El formulario `frmLocalidadNacionalidad.cs` **NO es principalmente** un gestor de Especialidades, pero **SÍ tiene una sección completa (TabPage 7)** dedicada a **configurar y gestionar Tipos de Examen** (que usa la tabla `Especialidad`).

---

## 🔍 Ubicación en el Código

### TabPage 6 (Examen Aptitud - Tipo 2)
- **Línea 547**: `dgv6.DataSource = localidPrest.cargarEspecialidad(txtBusquedaPrestacion6.Text);`
- **Línea 1264**: `CapaNegocioMepryl.TipoExamen TipoExamen = new CapaNegocioMepryl.TipoExamen();`

### TabPage 7 (Configuración de Exámenes) - **PRINCIPAL**
- **Línea 1379+**: `inicializar7()` - Inicializa la gestión de tipos de examen
- **Línea 1382**: `tipoExamen = new CapaNegocioMepryl.TipoExamen();`
- **Línea 1396**: `cargarComboTipoExamen()` - Carga tipos de examen del combo

---

## 🗂️ Estructura de TabPage 7: Configuración de Exámenes

### Variables de Control

```csharp
private CapaNegocioMepryl.TipoExamen tipoExamen;
private bool blnEstadoGuardo = false;
private string strIdEspecialidadViejo = "";
private string strDescripcionViejo = "";
private string strEstadoEdicion = "";  // "EDITAR" o ""
```

### Métodos Principales

| Método | Línea | Descripción |
|--------|-------|-------------|
| `inicializar7()` | 1379 | Inicializa TabPage 7 |
| `cargarComboMotivoConsulta()` | 1387 | Carga combo de Motivos de Consulta (FK) |
| `cargarComboTipoExamen()` | 1396 | Carga combo de Tipos de Examen según Motivo |
| `cargarComboSubTipo()` | 1410 | Carga Tipos Padre (Especialidades padre) |
| `llenarFormulario()` | 1420 | Carga datos de Especialidad en formulario |
| `llenarFormularioPadre()` | 1451 | Carga datos del Padre de Especialidad |
| `llenarDataGrids()` | ??? | Rellena DataGrids con Items del examen |
| `actualizarResumen()` | 1467 | Actualiza resumen de exámenes |

---

## 🔄 Flujo de Carga de Datos - ESPECIALIDAD

### 1️⃣ PASO 1: Cargar Motivos de Consulta

```csharp
private void cargarComboMotivoConsulta()
{
    cboMotivoConsulta.DataSource = tipoExamen.cargarMotivosDeConsultaTipoExamen();
    // ↓ Resultado: DataTable con columnas (id, nombre)
    cboMotivoConsulta.ValueMember = "id";
    cboMotivoConsulta.DisplayMember = "nombre";
    cboMotivoConsulta.SelectedIndex = -1;
}
```

**Tabla en BD**: `MotivoDeConsulta`  
**Conexión con Especialidad**: `Especialidad.idMotivoConsulta` (FK)

---

### 2️⃣ PASO 2: Seleccionar Motivo → Cargar Tipos Examen PADRE

```csharp
private void cargarComboSubTipo()
{
    if (cboMotivoConsulta.SelectedIndex != -1)
    {
        // Carga PADRES (Especialidades que tienen Padre=1)
        cboSubTipo.DataSource = tipoExamen.cargarTiposDeExamenPadre(
            cboMotivoConsulta.SelectedValue.ToString()
        );
        cboSubTipo.ValueMember = "id";
        cboSubTipo.DisplayMember = "descripcion";
        cboSubTipo.SelectedIndex = -1;
    }
}
```

**SQL Implícito**:
```sql
SELECT * FROM Especialidad 
WHERE idMotivoConsulta = @idMotivo 
AND Padre = 1  -- Solo padres
```

---

### 3️⃣ PASO 3: Seleccionar SubTipo (Padre) → Cargar Tipos Examen HIJO

```csharp
private void cargarComboTipoExamen()
{
    if (cboMotivoConsulta.SelectedIndex != -1)
    {
        // Carga HIJOS del Padre seleccionado
        cboTipoExamen.DataSource = tipoExamen.cargarTiposDeExamenHijo(
            cboMotivoConsulta.SelectedValue.ToString(),
            cboSubTipo.SelectedValue.ToString()  // IdPadre
        );
        cboTipoExamen.ValueMember = "id";
        cboTipoExamen.DisplayMember = "descripcion";
        cboTipoExamen.SelectedIndex = -1;
    }
}
```

**SQL Implícito**:
```sql
SELECT * FROM Especialidad 
WHERE idMotivoConsulta = @idMotivo 
AND IdPadre = @idPadre  -- Solo hijos del padre
AND Padre = 0           -- No son padres
```

---

### 4️⃣ PASO 4: Seleccionar Tipo Examen → Cargar Entidad Completa

```csharp
private void llenarFormulario()
{
    if (cboSubTipo.SelectedIndex != -1)
    {
        // Carga toda la Especialidad con Items
        Entidades.TipoExamen entidad = tipoExamen.cargarEntidad(
            cboTipoExamen.SelectedValue.ToString()  // ID de Especialidad
        );
        
        tbId7.Text = entidad.Id.ToString();                  // GUID
        tbCodigo7.Text = entidad.Codigo.ToString();          // Código INT
        tbDescripcion7.Text = entidad.Descripcion;           // Nombre
        tbDescripcionInformes.Text = entidad.DescripcionInformes;  // Para reportes
        tbPrecioBase.Text = entidad.PrecioBase.ToString();   // Precio base
        
        llenarDataGrids(entidad);  // Carga Items (97 estudios)
        actualizarResumen();       // Actualiza resumen
    }
}
```

**Datos Cargados de Especialidad**:

| Campo | Tipo | Origen |
|-------|------|--------|
| `Id` | GUID | `Especialidad.id` |
| `Codigo` | INT | `Especialidad.codigo` |
| `Descripcion` | VARCHAR | `Especialidad.descripcion` |
| `DescripcionInformes` | VARCHAR | `Especialidad.descripcionInformes` |
| `PrecioBase` | DECIMAL | `Especialidad.precioBase` |
| `IdMotivoConsulta` | INT | `Especialidad.idMotivoConsulta` |
| `Padre` | BIT | `Especialidad.Padre` |
| `IdPadre` | VARCHAR | `Especialidad.IdPadre` |

---

## 📊 Relación de Datos: ESPECIALIDAD → ITEMS

### 5️⃣ PASO 5: Llenar DataGrids con Items

```csharp
private void llenarDataGrids(Entidades.TipoExamen entidad)
{
    // Carga 12 DataGridViews diferentes, cada uno con una categoría:
    
    dgvClinico.DataSource = entidad.Clinico;              // Item 1
    dgvHematologia.DataSource = entidad.Hematologia;      // Item 2
    dgvQuimicaHematica.DataSource = entidad.QuimicaHematica;  // Item 3
    dgvSerologia.DataSource = entidad.Serologia;          // Item 4
    dgvPerfilLipidico.DataSource = entidad.PerfilLipidico;    // Item 5
    dgvBacteriologia.DataSource = entidad.Bacteriologia;      // Item 6
    dgvOrina.DataSource = entidad.Orina;                  // Item 7
    dgvLaboralesBasicas.DataSource = entidad.LaboralesBasicas;  // Item 8
    dgvCraneoYMSuperior.DataSource = entidad.CraneoYMSuperior;  // Item 9
    dgvTroncoYPelvis.DataSource = entidad.TroncoYPelvis;       // Item 10
    dgvMiembroInferior.DataSource = entidad.MiembroInferior;   // Item 11
    dgvEstComplementarios.DataSource = entidad.EstComplementarios;  // Item 12
}
```

**Estructura de cada DataTable** (por ejemplo, Clinico):

```
DataTable: Clinico
├── Column 0: Id (GUID del Item)
├── Column 1: Codigo (INT - índice item)
├── Column 2: Estado (BOOL - si está incluido)
└── Column 3: Item (VARCHAR - nombre)
```

---

## 🔗 Jerarquía de Datos Especialidad

```
MotivoDeConsulta
    ↓
Especialidad (Padre=1)  ← Nivel 1: Categorías
    ├── Especialidad (Padre=0, IdPadre=xxx) ← Nivel 2: Subtipos
    ├── Especialidad (Padre=0, IdPadre=xxx)
    └── Especialidad (Padre=0, IdPadre=xxx)
            ↓
    EstudiosPorTipoExamen ← 97 Items (Clinico, Hematologia, etc.)
            ↓
    Items ← Catálogo master
```

---

## 📥 TabPage 6: Cargar Especialidades

### Método: `llenarDgv6()`

```csharp
private void llenarDgv6()
{
    // Carga TODAS las Especialidades en grilla
    dgv6.DataSource = localidPrest.cargarEspecialidad(txtBusquedaPrestacion6.Text);
    
    // Oculta columnas innecesarias
    dgv6.Columns[0].Visible = false;  // ID
    dgv6.Columns[2].Visible = false;  // Campo auxiliar
    dgv6.Columns[4].Visible = false;  // IdZona
    dgv6.Columns[5].Visible = false;  // Campo extra
    
    // Visible solo si es tipo "V" (Visitas)
    if (cboTipoPrestacion6.SelectedIndex == 1)
        dgv6.Columns[5].Visible = true;
}
```

### Método: `eliminar6()` - Eliminar Especialidad

```csharp
private void eliminar6()
{
    CapaNegocioMepryl.TipoExamen TipoExamen = new CapaNegocioMepryl.TipoExamen();
    
    if (dgv6.SelectedRows.Count > 0)
    {
        DialogResult result = MessageBox.Show(
            "¿Realmente desea eliminar el Exámen de Aptitud?",
            "Eliminar Prestación/Localidad", 
            MessageBoxButtons.YesNo, 
            MessageBoxIcon.Question
        );
        
        if (result == DialogResult.Yes)
        {
            try
            {
                int nroFila = dgv6.CurrentCell.RowIndex;
                string strIdEspecialidad = dgv6.Rows[nroFila].Cells[0].Value.ToString();
                
                // ⚠️ ELIMINA LA ESPECIALIDAD
                TipoExamen.EliminarEspecialidad(strIdEspecialidad);
                
                llenarDgv6();  // Recarga grilla
            }
            catch (NullReferenceException ex)
            {
                // Manejo de error simplista
                string strIdEspecialidad = dgv6.Rows[0].Cells[0].Value.ToString();
                TipoExamen.EliminarEspecialidad(strIdEspecialidad);
            }
        }
    }
}
```

### Método: `EditarExamenActitud06()` - Editar Especialidad

```csharp
private void EditarExamenActitud06()
{
    string strIdPadre = "";
    string strIdEspecialidad = "";
    
    try
    {
        int nroFila = dgv6.CurrentCell.RowIndex;
        strIdPadre = dgv6.Rows[nroFila].Cells[5].Value.ToString();      // IdPadre
        strIdEspecialidad = dgv6.Rows[nroFila].Cells[0].Value.ToString();  // Id
    }
    catch (NullReferenceException ex)
    {
        strIdPadre = dgv6.Rows[0].Cells[5].Value.ToString();
        strIdEspecialidad = dgv6.Rows[0].Cells[0].Value.ToString();
    }

    // Abre formulario de edición especializado
    frmConfigTipoExamenExApt frm = new frmConfigTipoExamenExApt();
    frm.CargarDatosEditar(strIdPadre, strIdEspecialidad, "EDITAR");
    frm.ShowDialog();
}
```

---

## 🎯 Métodos de Negocio Invocados

### CapaNegocioMepryl.TipoExamen

```csharp
// LECTURA
• cargarMotivosDeConsultaTipoExamen() 
  ↓ SQL: SELECT * FROM MotivoDeConsulta

• cargarTiposDeExamenPadre(idMotivoConsulta)
  ↓ SQL: SELECT * FROM Especialidad 
         WHERE idMotivoConsulta = @id AND Padre = 1

• cargarTiposDeExamenHijo(idMotivoConsulta, idPadre)
  ↓ SQL: SELECT * FROM Especialidad 
         WHERE idMotivoConsulta = @idMotivo AND IdPadre = @idPadre

• cargarEntidad(id)
  ↓ SQL: SELECT * FROM Especialidad WHERE id = @id
         + SELECT * FROM EstudiosPorTipoExamen WHERE idEspecialidad = @id

// ESCRITURA
• EliminarEspecialidad(id)
  ↓ SQL: DELETE FROM Especialidad WHERE id = @id

// Adicionales usados en TabPage 7
• cargarItems()  → Obtiene todos los Items disponibles
• editarTipoExamen(entidad) → UPDATE
• crearTipoExamen(entidad) → INSERT
```

---

## 📊 Tabla de Correspondencia: Especialidad ↔ UI

| Campo BD | Columna DGV | TextBox/Control | Descripción |
|----------|-------------|-----------------|-------------|
| `id` | 0 (oculto) | `tbId7` | Identificador único |
| `codigo` | 1 | `tbCodigo7` | Código numérico |
| `descripcion` | 3 | `tbDescripcion7` | Nombre del examen |
| `precioBase` | - | `tbPrecioBase` | Precio base |
| `descripcionInformes` | - | `tbDescripcionInformes` | Texto para reportes |
| `idMotivoConsulta` | - | `cboMotivoConsulta` | FK a MotivoDeConsulta |
| `Padre` | - | N/A | Indicador de jerarquía |
| `IdPadre` | 5 | `cboSubTipo` | FK a Especialidad padre |

---

## 🚀 Flujo Completo: CREATE/UPDATE Especialidad

### En TabPage 7 (Configuración):

1. **Usuario selecciona Motivo** → Carga Padres disponibles
2. **Usuario selecciona Padre** → Carga Hijos disponibles
3. **Usuario selecciona Hijo** → Carga Entidad en formulario
4. **Usuario modifica campos**:
   - tbDescripcion7.Text → Especialidad.descripcion
   - tbCodigo7.Text → Especialidad.codigo
   - tbPrecioBase.Text → Especialidad.precioBase
   - tbDescripcionInformes.Text → Especialidad.descripcionInformes
   - dgvClinico...dgvEstComplementarios → EstudiosPorTipoExamen (items 1-97)
5. **Usuario hace clic "Guardar"** → Invoca `tipoExamen.editarTipoExamen(entidad)`
6. **Entidad se persiste** en BD

---

## ⚠️ Problemas Identificados

### 1. ❌ Manejo de Excepciones Deficiente

```csharp
try
{
    int nroFila = dgv6.CurrentCell.RowIndex;
    strIdEspecialidad = dgv6.Rows[nroFila].Cells[0].Value.ToString();
}
catch (System.NullReferenceException ex)  // ← Atrapa genérica
{
    // Simplemente toma fila 0 sin verificar si existe
    strIdEspecialidad = dgv6.Rows[0].Cells[0].Value.ToString();
}
```

**Problema**: Si la grilla está vacía, falla igualmente.

---

### 2. ❌ Duplicación de Lógica TabPage 6 y TabPage 7

Ambas cargan datos de `Especialidad` pero con:
- Métodos diferentes (llenarDgv6 vs llenarFormulario)
- Controles diferentes (dgv6 vs TextBox)
- Workflows distintos

---

### 3. ❌ Nombres sin Contexto

- `cboTipoPrestacion6` vs `cboTipoExamen` → ¿Cuál es cuál?
- `inicializar6()` vs `inicializar7()` → Sin claridad de propósito

---

### 4. ⚠️ Dependencia Acoplada con frmConfigTipoExamenExApt

```csharp
frmConfigTipoExamenExApt frm = new frmConfigTipoExamenExApt();
frm.CargarDatosEditar(strIdPadre, strIdEspecialidad, "EDITAR");
```

Si cambia `frmConfigTipoExamenExApt`, puede romper `frmLocalidadNacionalidad`.

---

## ✅ Recomendaciones de Mejora

### 1. Crear clase base genérica para CRUD
```csharp
public abstract class FormCRUDEspecialidad : DevExpress.XtraEditors.XtraForm
{
    protected virtual void CargarEspecialidades() { }
    protected virtual void CargarEspecialidadPadre() { }
    protected virtual void EditarEspecialidad(string id) { }
}
```

### 2. Usar Enum para estados
```csharp
public enum EstadoEspecialidad
{
    Padre = 1,
    Hijo = 0
}
```

### 3. Consolidar carga de datos
```csharp
private DataTable ObtenerEspecialidades(
    string idMotivo = null, 
    string idPadre = null,
    EstadoEspecialidad estado = null)
{
    // Lógica centralizada
}
```

---

## 📋 Resumen Final

| Aspecto | Detalles |
|--------|----------|
| **Tabla Principal** | `Especialidad` |
| **Tabla Relacionada 1** | `Items` (97 estudios) |
| **Tabla Relacionada 2** | `EstudiosPorTipoExamen` (plantilla) |
| **Tabla Relacionada 3** | `MotivoDeConsulta` (FK) |
| **TabPages que usan Especialidad** | 6, 7 |
| **Métodos principales** | cargarEntidad, editarTipoExamen, EliminarEspecialidad |
| **Patrón de dato** | Jerarquía Padre-Hijo con 97 Items asociados |
| **Operaciones CRUD** | ✅ READ, ✅ UPDATE, ✅ DELETE, ⚠️ CREATE (parcial) |
