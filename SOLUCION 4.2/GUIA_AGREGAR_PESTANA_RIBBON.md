# Guía: Cómo agregar una nueva pestaña al Ribbon (DevExpress)

## Ejemplo de referencia: pestaña "Configuración de Mensajes"

---

## Nombres de los controles del Ribbon (DevExpress)

| Control | Clase | Descripción |
|---------|-------|-------------|
| **RibbonControl** | `DevExpress.XtraBars.Ribbon.RibbonControl` | El contenedor principal del ribbon (la barra superior completa). En el proyecto se llama `rbcControlMenu`. |
| **RibbonPage** | `DevExpress.XtraBars.Ribbon.RibbonPage` | Cada pestaña/solapa del ribbon (ej: "Configuración Básica", "Configuración Preventiva"). |
| **RibbonPageGroup** | `DevExpress.XtraBars.Ribbon.RibbonPageGroup` | El grupo dentro de una pestaña que contiene los botones. Es el recuadro con título que agrupa botones. |
| **BarButtonItem** | `DevExpress.XtraBars.BarButtonItem` | Cada botón individual dentro de un grupo del ribbon. |
| **ToolStripMenuItem** | `System.Windows.Forms.ToolStripMenuItem` | Los ítems del menú lateral izquierdo (NavBar colapsado). |

### Diagrama visual:
```
┌─────────────────────────────────────────────────────────────────────┐
│  RibbonControl (rbcControlMenu)                                     │
│ ┌──────────────┐ ┌──────────────────┐ ┌───────────────────────────┐ │
│ │ RibbonPage 1 │ │  RibbonPage 2    │ │ RibbonPage 3              │ │
│ │ (pestaña)    │ │  (pestaña)       │ │ (pestaña)                 │ │
│ └──────────────┘ └──────────────────┘ └───────────────────────────┘ │
│ ┌─────────────────────────────────────────────────────────────────┐ │
│ │ Contenido de la pestaña seleccionada                            │ │
│ │  ┌─────────────────────┐  ┌─────────────────────┐              │ │
│ │  │ RibbonPageGroup 1   │  │ RibbonPageGroup 2   │              │ │
│ │  │  [BarButtonItem A]  │  │  [BarButtonItem C]  │              │ │
│ │  │  [BarButtonItem B]  │  │  [BarButtonItem D]  │              │ │
│ │  │  ── Grupo 1 ──      │  │  ── Grupo 2 ──      │              │ │
│ │  └─────────────────────┘  └─────────────────────┘              │ │
│ └─────────────────────────────────────────────────────────────────┘ │
└─────────────────────────────────────────────────────────────────────┘
```

---

## Nomenclatura usada en el proyecto

| Prefijo | Tipo | Ejemplo |
|---------|------|---------|
| `rbp` | RibbonPage (pestaña) | `rbpConfiguracionMensajes`, `rbpConfiguracionGeneral` |
| `rpg` | RibbonPageGroup (grupo) | `rpgConfigMensajesGrp`, `rpgConfiguracion` |
| `bbi` | BarButtonItem (botón) | `bbiConfigMensajePre`, `bbiConfigMensajeLab` |
| `config...ToolStripMenuItem` | ToolStripMenuItem (menú lateral) | `configMensajesToolStripMenuItem` |

---

## Archivos que se modifican

1. **`frmBasePrincipal.Designer.cs`** — Declaración y configuración visual de los controles
2. **`frmBasePrincipal.cs`** — Lógica de visibilidad y métodos virtuales
3. **`frmPrincipal.cs`** — Override de los métodos y lógica específica de la app

---

## Paso a paso: Agregar una nueva pestaña al Ribbon

### PASO 1: Declarar los controles (frmBasePrincipal.Designer.cs)

Ir al final del archivo, en la sección de declaraciones de campos, y agregar:

```csharp
// Después de las otras declaraciones de RibbonPage/RibbonPageGroup
public DevExpress.XtraBars.Ribbon.RibbonPage rbpNuevaSeccion;
public DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgNuevaSeccionGrp;
private System.Windows.Forms.ToolStripMenuItem nuevaSeccionToolStripMenuItem;
```

### PASO 2: Instanciar los controles (frmBasePrincipal.Designer.cs)

Buscar la zona donde se crean los `new` (cerca de la línea 183), y agregar:

```csharp
this.rbpNuevaSeccion = new DevExpress.XtraBars.Ribbon.RibbonPage();
this.rpgNuevaSeccionGrp = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
this.nuevaSeccionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
```

### PASO 3: Registrar la RibbonPage en el RibbonControl (frmBasePrincipal.Designer.cs)

Buscar `rbcControlMenu.Pages.AddRange` y agregar la nueva página al array:

```csharp
this.rbcControlMenu.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
    // ... páginas existentes ...,
    this.rbpNuevaSeccion,    // <-- AGREGAR ACÁ
    this.rbpFacturacionElectronica});  // Facturación siempre al final
```

### PASO 4: Configurar la RibbonPage (frmBasePrincipal.Designer.cs)

Agregar el bloque de configuración de la página (buscar una sección similar y copiar el patrón):

```csharp
// 
// rbpNuevaSeccion
// 
this.rbpNuevaSeccion.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
    this.rpgNuevaSeccionGrp});
this.rbpNuevaSeccion.Image = ((System.Drawing.Image)(resources.GetObject("rbpConfiguracionGeneral.Image")));
this.rbpNuevaSeccion.Name = "rbpNuevaSeccion";
this.rbpNuevaSeccion.Text = "Mi Nueva Sección";
this.rbpNuevaSeccion.Visible = false;
```

### PASO 5: Configurar el RibbonPageGroup (frmBasePrincipal.Designer.cs)

```csharp
// 
// rpgNuevaSeccionGrp
// 
this.rpgNuevaSeccionGrp.ItemLinks.Add(this.bbiAlgunBotonExistente);  // botón que querés mostrar
this.rpgNuevaSeccionGrp.Name = "rpgNuevaSeccionGrp";
this.rpgNuevaSeccionGrp.ShowCaptionButton = false;
this.rpgNuevaSeccionGrp.Text = "";  // dejar vacío para que no muestre texto debajo del grupo
```

> **NOTA:** Si ponés texto en `rpgNuevaSeccionGrp.Text`, ese texto aparece como etiqueta debajo del grupo de botones.
> Dejarlo vacío `""` para que no aparezca nada extra.

### PASO 6: Agregar al menú lateral (frmBasePrincipal.Designer.cs)

Buscar `configuracionToolStripMenuItem.DropDownItems.AddRange` y agregar:

```csharp
this.configuracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
    this.configBasicaDelSistemaToolStripMenuItem,
    this.configPreventivaToolStripMenuItem,
    this.configLaboralToolStripMenuItem,
    this.nuevaSeccionToolStripMenuItem});   // <-- AGREGAR ACÁ
```

Configurar el ítem del menú:

```csharp
// 
// nuevaSeccionToolStripMenuItem
// 
this.nuevaSeccionToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("configLaboralToolStripMenuItem.Image")));
this.nuevaSeccionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
this.nuevaSeccionToolStripMenuItem.Name = "nuevaSeccionToolStripMenuItem";
this.nuevaSeccionToolStripMenuItem.Size = new System.Drawing.Size(231, 42);
this.nuevaSeccionToolStripMenuItem.Text = "Mi Nueva Sección";
this.nuevaSeccionToolStripMenuItem.Click += new System.EventHandler(this.nuevaSeccionToolStripMenuItem_Click);
```

### PASO 7: Crear método virtual en frmBasePrincipal.cs

```csharp
protected virtual void nuevaSeccionToolStripMenuItem_Click(object sender, EventArgs e)
{
}
```

### PASO 8: Agregar visibilidad en frmBasePrincipal.cs

En `OcultarPestanasRibbon()`:
```csharp
rbpNuevaSeccion.Visible = false;
```

Crear método para mostrar la pestaña:
```csharp
public void MostrarPestanaNuevaSeccion()
{
    rbpConfiguracionGeneral.Visible = true;
    rbpConfiguracionPreventiva.Visible = true;
    rbpConfiguracionLaboral.Visible = true;
    rbpConfiguracionMensajes.Visible = true;
    rbpNuevaSeccion.Visible = true;   // <-- LA NUEVA
    minimizarRibbon(false);
}
```

Y agregar `rbpNuevaSeccion.Visible = true;` en los otros métodos `MostrarPestanaConfig*` si querés que se vean todas las pestañas de configuración juntas.

### PASO 9: Override en frmPrincipal.cs

```csharp
protected override void nuevaSeccionToolStripMenuItem_Click(object sender, EventArgs e)
{
    MostrarPestanaNuevaSeccion();
}
```

En `rbcControlMenu_SelectedPageChanged`, agregar:
```csharp
if (strPage == "rbpNuevaSeccion")
{
    cerrarFormulariosMainPanel();
    // Abrir el formulario correspondiente
}
```

---

## Pestañas existentes en el proyecto

| Variable | Texto visible | Uso |
|----------|--------------|-----|
| `rbpConfiguracionGeneral` | "Configuración Básica del Sistema" | Config general: usuarios, horarios, médicos, etc. |
| `rbpConfiguracionPreventiva` | "Configuración Preventiva" | Config preventiva: plantillas, ubicación fotos, etc. |
| `rbpConfiguracionLaboral` | "Configuración Laboral" | Config laboral: plantillas, condiciones, etc. |
| `rbpConfiguracionMensajes` | "Configuración de Mensajes" | Config mensajes: plantillas de mensajes turnos/WhatsApp |
| `rbpFacturacionElectronica` | "Facturación Electrónica" | Facturación |
| `rbpTurnos` | "Turnos" | Pantalla de turnos |
| `rbpPacientePre` | Paciente Preventiva | Pantalla paciente preventiva |
| `rbpPacienteLab` | Paciente Laboral | Pantalla paciente laboral |
| `rbpExamenesPre` | Exámenes Preventiva | Pantalla exámenes preventiva |
| `rbpExamenesLab` | Exámenes Laboral | Pantalla exámenes laboral |
| `rbpMesaEntradas` | Mesa de Entradas | Pantalla mesa de entradas |

---

## Botones existentes reutilizables (BarButtonItem)

| Variable | Texto | Formulario que abre |
|----------|-------|---------------------|
| `bbiConfigMensajePre` | "Configuración Mensaje" | `frmConfigMensajesPreventiva` |
| `bbiConfigMensajeLab` | "Configuración Mensajes" | `frmConfigMensajesLaboral` |
| `bbiPlantillaReportes` | "Plantilla Reportes" | Config plantillas preventiva |
| `bbiPlantillaReporteLab` | "Plantilla Reportes" | Config plantillas laboral |
| `bbiConfigUsuarios` | "Usuarios" | `frmUsuariosSistema` |
| `bbiConfigHorarios` | "Horarios" | Config horarios |
| `bbiConfigMedico` | "Médicos" | Config médicos |

---

## Tip: El texto "Mensajes" que aparecía debajo del botón

Eso era el `rpgConfigMensajesGrp.Text = "Mensajes"`. El `Text` del **RibbonPageGroup** se muestra como etiqueta debajo del grupo de botones. Para que no aparezca, dejarlo vacío: `Text = ""`.
