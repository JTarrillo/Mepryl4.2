# Tarea JIRA: Corrección de Diseño Responsivo, Desborde de Elementos y Reseteo de Scroll en Pantallas de 1360x768

## Título
[UI/UX] Corrección de diseño responsivo, desborde de elementos y reseteo de scroll en pantallas de 1360x768

## Prioridad
Alta

## Tipo de incidencia
Bug / Error

## Descripción

### Contexto
El sistema presenta fallas visuales y de interacción al ser ejecutado en pantallas con resolución de 1360x768 (u otras menores a 1920x1080), afectando la experiencia del usuario al operar la agenda y la grilla de pacientes.

### Problemas Detectados

#### 1. Desborde de Interfaz
- **Síntoma:** Los paneles y componentes fijos provocan que elementos de la derecha queden fuera del área visible
- **Resultado:** Aparece un scroll horizontal forzado
- **Impacto:** Elementos importantes quedan inaccesibles sin scroll horizontal
- **Resolución afectada:** 1360x768 y menores

#### 2. Comportamiento Errático del Scroll
- **Síntoma:** Al interactuar o intentar mover la barra de desplazamiento en pantallas pequeñas, el scroll salta, se bloquea o regresa bruscamente a su posición inicial
- **Causa probable:** Bucle en el evento de redibujo o redimensionamiento (Resize / Layout)
- **Impacto:** El usuario no puede navegar correctamente por la grilla
- **Momento:** Ocurre durante la actualización automática o interacción manual

### Formularios Afectados
- `frmAgendaMesaEntrada2.cs` (Planilla del Día)
- Posiblemente otros formularios con DataGridView

## Criterios de Aceptación (Acceptance Criteria)

- [ ] **Adaptación a resolución 1360x768:** El formulario principal debe adaptarse o escalar correctamente al ejecutarse en pantallas con resolución de 1360x768 píxeles.

- [ ] **Ajuste de grilla:** La grilla (DataGridView) inferior debe ajustarse mediante anclajes (Anchor) o contenedores fluidos para evitar el desborde horizontal de la interfaz.

- [ ] **Corrección de scroll errático:** Corregir el fallo donde el scroll se reinicia o regresa de forma imprevista al interactuar con él en resoluciones reducidas.

- [ ] **Estabilización de renderizado:** Implementar el uso de `SuspendLayout()` / `ResumeLayout()` durante la actualización de datos y controles para estabilizar el renderizado y evitar saltos visuales.

- [ ] **MinimumSize configurado:** Configurar la propiedad `MinimumSize` del formulario principal para evitar que la ventana colapse visualmente al reducirla más allá de un límite prudente.

## Análisis Técnico

### Posibles Causas

#### 1. Anclajes (Anchor) Incorrectos
- Los controles pueden tener anclajes fijos que no se adaptan al tamaño de ventana
- DataGridView puede estar configurado con anclajes que causan desborde

#### 2. Eventos de Resize
- Eventos `Resize` o `Layout` pueden estar causando bucles
- La actualización automática puede estar disparando eventos de redimensionamiento

#### 3. Scroll y Actualización Automática
- La actualización automática cada 30 segundos puede estar reseteando el scroll
- `FirstDisplayedScrollingRowIndex` puede estar siendo modificado incorrectamente

#### 4. Tamaño de Formulario
- Falta de `MinimumSize` permite que el formulario se reduzca demasiado
- Sin límite mínimo, los controles pueden colapsar

## Solución Propuesta

### 1. Revisión de Anclajes (Anchor)
```csharp
// Verificar y corregir anclajes en frmAgendaMesaEntrada2.Designer.cs
dgvGrilla.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
// Asegurar que contenedores también tengan anclajes correctos
```

### 2. Estabilización de Scroll en Actualización Automática
```csharp
private void timerActualiza_Tick(object sender, EventArgs e)
{
    try
    {
        // Guardar estado del scroll ANTES de SuspendLayout
        int currentScroll = dgvGrilla.FirstDisplayedScrollingRowIndex;
        
        dgvGrilla.SuspendLayout();
        
        // Recargar datos
        CargarDatos();
        mostrarDatos();
        PintarFilaGrilla();
        
        dgvGrilla.ResumeLayout(true);
        
        // Restaurar scroll DESPUÉS de ResumeLayout
        if (currentScroll >= 0 && currentScroll < dgvGrilla.Rows.Count)
        {
            dgvGrilla.FirstDisplayedScrollingRowIndex = currentScroll;
        }
    }
    catch (Exception ex)
    {
        System.Diagnostics.Debug.WriteLine($"[AGENDA] Error: {ex.Message}");
    }
}
```

### 3. Configuración de MinimumSize
```csharp
public frmAgendaMesaEntrada2(frmBasePrincipal parentForm)
{
    InitializeComponent();
    
    // Configurar tamaño mínimo para evitar colapso
    this.MinimumSize = new Size(1024, 768); // Mínimo razonable
    
    // ... resto del constructor
}
```

### 4. Manejo de Eventos Resize
```csharp
private void frmAgendaMesaEntrada2_Resize(object sender, EventArgs e)
{
    // Evitar bucles de redimensionamiento
    if (this.WindowState == FormWindowState.Minimized)
        return;
        
    // Suspender layout durante redimensionamiento
    dgvGrilla.SuspendLayout();
    
    // Ajustar controles si es necesario
    // ...
    
    dgvGrilla.ResumeLayout(true);
}
```

### 5. Ajuste de DataGridView para Pantallas Pequeñas
```csharp
// Configurar DataGridView para adaptarse
dgvGrilla.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
dgvGrilla.AllowUserToResizeColumns = true;
dgvGrilla.AllowUserToOrderColumns = false; // Evitar reordenamiento que cause problemas
```

## Archivos a Modificar

### Principal
- `c:\Mepryl4.2\SOLUCION 4.2\MEPRYL\CapaPresentacion\frmAgendaMesaEntrada2.cs`
- `c:\Mepryl4.2\SOLUCION 4.2\MEPRYL\CapaPresentacion\frmAgendaMesaEntrada2.Designer.cs`

### Secundarios (si aplica)
- Otros formularios con DataGridView que presenten el mismo problema

## Pruebas Requeridas

### 1. Pruebas de Resolución
- [ ] Probar en 1360x768
- [ ] Probar en 1920x1080
- [ ] Probar en resoluciones menores (1280x720)
- [ ] Probar en resoluciones mayores (2560x1440)

### 2. Pruebas de Scroll
- [ ] Verificar que el scroll no se resetea durante actualización automática
- [ ] Verificar que el scroll funciona correctamente al interactuar manualmente
- [ ] Verificar que no hay saltos bruscos al navegar

### 3. Pruebas de Redimensionamiento
- [ ] Verificar que el formulario no colapse por debajo del tamaño mínimo
- [ ] Verificar que los controles se ajustan correctamente al redimensionar
- [ ] Verificar que no hay bucles de redimensionamiento

### 4. Pruebas de Funcionalidad
- [ ] Verificar que la actualización automática sigue funcionando
- [ ] Verificar que la lógica de colores se aplica correctamente
- [ ] Verificar que la selección de filas se mantiene

## Impacto

### Usuarios Afectados
- Todos los usuarios que utilizan pantallas con resolución 1360x768 o menor
- Usuarios de laptops con pantallas estándar
- Usuarios que ejecutan el sistema en monitores secundarios

### Módulos Afectados
- `frmAgendaMesaEntrada2` (Planilla del Día)
- Posiblemente otros formularios con grillas

### Riesgos
- Medio: Modificaciones en anclajes pueden afectar el diseño en otras resoluciones
- Bajo: La configuración de MinimumSize puede limitar la flexibilidad del usuario

## Recomendaciones

### Inmediatas
1. **Implementar MinimumSize:** Configurar tamaño mínimo para evitar colapso
2. **Revisar anclajes:** Verificar Anchor de todos los controles críticos
3. **Optimizar actualización automática:** Asegurar que no afecte el scroll

### Futuras
1. **Diseño responsivo:** Implementar un sistema de diseño que se adapte a múltiples resoluciones
2. **Pruebas automatizadas:** Crear pruebas UI para diferentes resoluciones
3. **Configuración de usuario:** Permitir al usuario configurar el tamaño mínimo preferido

## Estado
🔄 Pendiente de Implementación

## Fecha de Reporte
30/07/2026

## Notas Adicionales
- El problema es más crítico en laptops y monitores estándar de oficina
- La actualización automática implementada recientemente puede estar exacerbando el problema
- Es importante probar exhaustivamente en diferentes resoluciones antes de desplegar
- Considerar implementar un modo "compacto" para pantallas pequeñas
