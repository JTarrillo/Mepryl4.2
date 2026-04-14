# Patrones UX aplicados en Mepryl 4.2

## Resumen

Documento de referencia con los patrones de experiencia de usuario (UX) aplicados en el sistema, para mantener consistencia en futuras pantallas.

---

## 1. Master-Detail (Maestro-Detalle)

**Qué es:** Una vista general (grilla/listado) que al seleccionar un ítem muestra sus detalles en otro lugar.

**Dónde se aplicó:**
- `frmUsuariosSistema` → Tab "Gestionar Usuarios": la grilla muestra datos básicos del usuario, y al hacer clic en "Configurar" se abre un modal (`frmPermisosUsuario`) con los permisos detallados.

**Cuándo usarlo:** Cuando una entidad tiene muchos campos y mostrarlos todos en la grilla sería abrumador.

**Ejemplo de prompt:**
> "Necesito una grilla de [entidad] con las columnas principales y un botón que abra un modal con todos los detalles"

---

## 2. Progressive Disclosure (Revelación Progresiva)

**Qué es:** Mostrar solo la información esencial primero, y revelar más detalles bajo demanda del usuario.

**Dónde se aplicó:**
- La grilla de "Gestionar Usuarios" muestra: Usuario, Apellido, Nombre, Tipo, DNI, Activo. Los 12 permisos se ocultan y solo aparecen al presionar "Configurar".
- El buscador F1 en el tab "Usuario" se oculta (`tblBuscar.Visible = false`) hasta que el usuario presiona F1.

**Cuándo usarlo:** Cuando hay muchos datos que no todos los usuarios necesitan ver siempre.

---

## 3. Search-as-you-type (Filtro en Vivo)

**Qué es:** Filtrar resultados mientras el usuario escribe, sin necesidad de presionar un botón "Buscar".

**Dónde se aplicó:**
- `txtBuscarGestion` en tab "Gestionar Usuarios": filtra la grilla por DNI en tiempo real usando `DataView.RowFilter` (no re-consulta la BD en cada tecla).
- `txtBuscar` en tab "Usuario": filtra usuarios por DNI al escribir.

**Implementación técnica:**
```csharp
// Cargar datos una sola vez
dtGestion = UserSistema.ListarUsuariosConPermisos();

// Filtrar en memoria (rápido, sin consultar BD)
DataView dv = dtGestion.DefaultView;
dv.RowFilter = "DNI LIKE '%" + filtro + "%'";
dgvGestion.DataSource = dv;
```

**Cuándo usarlo:** En cualquier listado con más de ~20 registros donde el usuario necesita encontrar uno específico.

---

## 4. Cell-level Selection + Clipboard

**Qué es:** Permitir seleccionar una celda individual y copiar su contenido con Ctrl+C.

**Dónde se aplicó:**
- `dgvGestion` en "Gestionar Usuarios": `SelectionMode = CellSelect` + `ClipboardCopyMode = EnableWithoutHeaderText`.

**Configuración en Designer:**
```csharp
dgvGestion.SelectionMode = DataGridViewSelectionMode.CellSelect;
dgvGestion.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
```

**Cuándo usarlo:** Cuando el usuario necesita copiar datos individuales (DNI, nombre, email) para pegarlos en otro lugar.

---

## 5. Tab Navigation (Navegación por Pestañas)

**Qué es:** Separar funcionalidades relacionadas pero distintas en pestañas dentro de la misma ventana.

**Dónde se aplicó:**
- `frmUsuariosSistema`:
  - **Tab "Usuario"**: ABM individual (crear, modificar, ver un usuario con todos sus campos).
  - **Tab "Gestionar Usuarios"**: Vista panorámica de todos los usuarios con gestión rápida de permisos.

**Cuándo usarlo:** Cuando una pantalla tiene dos modos de uso distintos para la misma entidad (edición detallada vs. gestión masiva).

---

## 6. Role-based Access (Acceso basado en Rol)

**Qué es:** Habilitar o deshabilitar controles según el rol del usuario logueado.

**Dónde se aplicó:**
- Solo el usuario ADMINISTRADOR puede:
  - Editar permisos en el modal `frmPermisosUsuario`
  - Ver el botón "Agregar" nuevo usuario
  - Asignar el tipo "ADMINISTRADOR" a un usuario
- Los demás usuarios ven todo en modo solo lectura.

**Implementación:**
```csharp
private bool UsuarioActualEsAdministrador()
{
    return Configuracion.usuario != null &&
           Configuracion.usuario.Tipo == "ADMINISTRADOR";
}

// En el modal:
if (!blnEsAdmin)
{
    foreach (Control c in this.Controls)
        c.Enabled = false;
    btnCancelar.Enabled = true; // siempre puede cerrar
}
```

---

## 7. Keyboard Shortcuts (Atajos de Teclado)

**Qué es:** Acciones rápidas por teclado para usuarios avanzados.

**Dónde se aplicó:**
- **F1** en campo DNI → abre el buscador
- **Enter** en el buscador con 1 resultado → selecciona automáticamente
- **Escape** → cierra el buscador
- **Ctrl+C** en la grilla → copia el contenido de la celda

---

## Principios generales (Nielsen's Heuristics)

| # | Heurística | Aplicación en Mepryl |
|---|-----------|---------------------|
| 1 | Visibilidad del estado | Checkboxes en rojo cuando el permiso difiere del defecto del tipo |
| 2 | Coincidencia con el mundo real | Labels claros: "Buscar por DNI", "Permisos", "Acceso a Pantallas" |
| 3 | Control y libertad | Botón "Cancelar" siempre disponible, Escape cierra buscador |
| 4 | Consistencia | Misma estructura de botones laterales en todas las pantallas |
| 5 | Prevención de errores | Admin no puede autoeliminarse, validación de usuario existente |
| 6 | Reconocimiento antes que recuerdo | [F1] visible junto al campo, botón "Configurar" explícito |
| 7 | Flexibilidad y eficiencia | Atajos de teclado para avanzados, mouse para novatos |
| 8 | Diseño minimalista | Solo columnas esenciales en la grilla, permisos en modal |

---

## Referencia rápida para nuevas pantallas

Al crear una nueva pantalla, considerar:

1. **¿Tiene muchos campos?** → Usar Progressive Disclosure (modal o expandible)
2. **¿Tiene un listado largo?** → Agregar Search-as-you-type con DataView
3. **¿El usuario necesita copiar datos?** → CellSelect + ClipboardCopyMode
4. **¿Tiene dos modos de uso?** → TabControl
5. **¿Hay acciones restringidas?** → Verificar `UsuarioActualEsAdministrador()`
6. **¿Hay acciones frecuentes?** → Asignar atajo de teclado (F1, Enter, Escape)
