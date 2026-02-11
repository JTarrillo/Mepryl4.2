# 🧪 PRUEBAS: Flujo de Creación de Subtipos Temporales

## ✅ Objetivo
Verificar que los subtipos temporales funcionen correctamente: creación, carga de items, selección y guardado.

---

## 📋 Escenario 1: Crear Subtipo y Ver Items

### Pasos:
1. **Seleccionar Motivo de Consulta**
   - [ ] Abre la aplicación
   - [ ] Selecciona un "Motivo de Consulta" del combo

2. **Crear Tipo Examen**
   - [ ] Click en "Agregar" (botón de Tipo)
   - [ ] Ingresa: Descripción = "Tipo Test"
   - [ ] Ingresa: Precio = "100"
   - [ ] Marca checkbox "Activo"
   - [ ] Click "Aceptar"
   - [ ] ✅ Verifica que aparezca en combo de tipos

3. **Crear Subtipo**
   - [ ] Selecciona el Tipo creado
   - [ ] Click en "Agregar Subtipo"
   - [ ] Ingresa: Descripción = "Subtipo Test"
   - [ ] Ingresa: Precio = "50"
   - [ ] Marca checkbox "Activo"
   - [ ] Click "Aceptar"
   
### Resultados Esperados:
- ✅ Mensaje: "Subtipo agregado correctamente. Selecciona items para incluirlos."
- ✅ El subtipo aparece automáticamente seleccionado en combo
- ✅ **Las grillas (Clínico, Laboratorio, etc.) se LLENAN con items disponibles**
- ✅ Puedes VER items en la grilla dgvItems
- ✅ Puedes ver items en dgvClinico, dgvLaboratorio, etc.

### Debug:
```
Buscar en Output: 
► Cargando items para subtipo temporal: [ID]
✓ [N] items cargados desde BD
✓ [N] items distribuidos en DataTables
✅ Items cargados correctamente en subtipo temporal
```

---

## 📋 Escenario 2: Marcar Items y Cambiar de Subtipo

### Pasos:
1. **Marcar items en grilla Clínico**
   - [ ] Estás en el Subtipo creado
   - [ ] Marca (checkbox ✓) 2-3 items en dgvClinico
   - [ ] Verifica que aparezcan en dgvItems con Estado = True

2. **Marcar items en Laboratorio**
   - [ ] Marca 1-2 items en dgvLaboratorio
   - [ ] Verifica que aparezcan en dgvItems

3. **Crear segundo Subtipo**
   - [ ] Click "Agregar Subtipo"
   - [ ] Nombre: "Subtipo 2"
   - [ ] Click "Aceptar"
   
### Resultados Esperados:
- ✅ Items del Subtipo 1 se GUARDAN automáticamente cuando cambias
- ✅ Grillas se limpian y cargan items de Subtipo 2
- ✅ **Subtipo 2 también muestra sus items disponibles**
- ✅ Los items del Subtipo 1 están guardados en memoria

### Debug:
```
Buscar en Output al cambiar de subtipo:
✓ Items del subtipo anterior [ID] guardados automáticamente
```

---

## 📋 Escenario 3: Volver al Subtipo Anterior

### Pasos:
1. **Marcar items en Subtipo 2**
   - [ ] Marca algunos items en las grillas
   
2. **Volver al Subtipo 1**
   - [ ] En combo cmbSubtipo, selecciona "Subtipo Test" (el primero)

### Resultados Esperados:
- ✅ Items de Subtipo 2 se guardan automáticamente
- ✅ Grillas muestran los items que habías marcado en Subtipo 1
- ✅ **Los estados (marcado/no marcado) se conservan**
- ✅ Los items están en las grillas correctas (Clínico, Laboratorio, etc.)

---

## 📋 Escenario 4: Guardar Todo en Base de Datos

### Pasos:
1. **Marcar items en ambos subtipos**
   - [ ] Subtipo 1: marca items
   - [ ] Subtipo 2: marca items
   
2. **Click GUARDAR**
   - [ ] Valida: "Debe seleccionar al menos un item"
   - [ ] Click "Sí" para guardar
   - [ ] Espera confirmación

### Resultados Esperados:
- ✅ Mensaje: "Guardado exitoso: X de X elementos"
- ✅ Se cierra la ventana
- ✅ **En BD se guardan:**
  - Los 2 Tipos
  - Los 2 Subtipos
  - Todos los items marcados con sus estados

### Verificar en BD:
```sql
-- Verificar tipos
SELECT id, descripcion, Padre FROM TipoExamen WHERE descripcion LIKE '%Test%'

-- Verificar subtipos
SELECT id, descripcion, IdPadre FROM TipoExamen WHERE descripcion LIKE '%Subtipo%'

-- Verificar items guardados
SELECT * FROM EstudiosPorTipoExamen 
WHERE idTipoExamen IN (SELECT id FROM TipoExamen WHERE descripcion LIKE '%Test%')
```

---

## 🐛 Si Algo Falla

### Síntoma: Grillas vacías al crear subtipo
- [ ] Verifica Output console para mensajes de error
- [ ] Busca: "ERROR en CargarYAsignarItemsAlSubtipo"
- [ ] Verifica que tabla EstudiosPorTipoExamen tenga datos

### Síntoma: Items no se guardan al cambiar subtipo
- [ ] Busca Output: "❌ Items del subtipo anterior"
- [ ] Verifica que `GuardarEstadoItemsParaSubtipo()` se esté llamando
- [ ] Revisa que DataTables no sean NULL

### Síntoma: Items se pierden al volver a subtipo anterior
- [ ] El problema es que DataTables se vaciaron
- [ ] Necesita revisar `CmbSubtipo_SelectedIndexChanged()`
- [ ] Verificar que `GuardarEstadoItemsParaSubtipo()` se ejecute ANTES de cambiar

---

## ✅ Checklist Final

- [ ] Crear subtipo automáticamente carga items
- [ ] Ver items en grillas al crear subtipo
- [ ] Marcar items se refleja en dgvItems
- [ ] Cambiar de subtipo auto-guarda items anteriores
- [ ] Volver al subtipo anterior recupera sus items
- [ ] Estados (marcado/no marcado) se conservan
- [ ] Guardar persiste TODO en BD
- [ ] Sin errores en Output console

---

## 📊 Resumen de Estado

| Feature | Status | Notas |
|---------|--------|-------|
| Crear tipo temporal | ✅ LISTO | Aparece en combo |
| Crear subtipo temporal | ✅ LISTO | Auto-carga items |
| Ver items al crear | ✅ LISTO | Grillas se llenan |
| Marcar/desmarcar items | ✅ LISTO | Sincroniza en todas grillas |
| Auto-guardar al cambiar | ✅ LISTO | Preserva estado anterior |
| Recuperar items al volver | ✅ LISTO | Vuelve a cargar desde DataTables |
| Guardar en BD | ✅ LISTO | Con validación de items |
| Estado (Activo/Inactivo) | ✅ LISTO | Se guarda en diálogo |

---

**Fecha de generación**: 11 Dic 2025
**Versión testeo**: Flujo completo de subtipos temporales
