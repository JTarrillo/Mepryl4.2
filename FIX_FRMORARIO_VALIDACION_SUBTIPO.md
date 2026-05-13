# Fix: frmHorario — Validación de Subtipo Obligatorio

**Fecha:** 13/05/2026  
**Archivo:** `CapaPresentacion/frmHorario.cs`  
**Estado:** ✅ Aplicado y compilado sin errores

---

## Problema que resuelve

Al crear o modificar un Horario, el sistema permitía guardar con el **Tipo padre** (Padre=1) como `especialidadID` en lugar del **Subtipo** (Padre=0).

Esto ocurría cuando el operador seleccionaba el combo **Tipo de Examen** (`cboEspecialidad`) pero **no seleccionaba** el combo **Subtipo** (`cboSubtipo`).

**Consecuencia en cascada:**
```
Horario con Padre=1 → Turno → TurnoFactory → TipoExamenDePaciente con Padre=1
→ Mesa de Entrada muestra "PRE-OCUPACIONAL" / "FUERZAS ARMADAS..." en vez del subtipo correcto
```

---

## Cambios aplicados

### 1. `validarDatosIngresados()` — Antes
```csharp
public override string validarDatosIngresados()
{
    return "";  // ← No validaba nada
}
```

### 1. `validarDatosIngresados()` — Después
```csharp
public override string validarDatosIngresados()
{
    if (cboSubtipo.SelectedIndex == -1 || cboSubtipo.SelectedValue == null)
        return "Debe seleccionar un Subtipo de Examen.";
    return "";
}
```
**Efecto:** El sistema muestra el mensaje y bloquea el guardado si no hay subtipo seleccionado.

---

### 2. `cargarObjetoReglas()` — Antes
```csharp
// Usar subtipo si está seleccionado, si no el tipo  ← FALLBACK INCORRECTO
if (cboSubtipo.SelectedValue != null && cboSubtipo.SelectedIndex != -1)
{
    rglEntidad.especialidadID = new Guid(cboSubtipo.SelectedValue.ToString());
    rglEntidad.especialidadTexto = cboSubtipo.Text;
}
else
{
    // ← Guardaba el Padre=1 si no había subtipo seleccionado
    rglEntidad.especialidadID = new Guid(cboEspecialidad.SelectedValue.ToString());
    rglEntidad.especialidadTexto = cboEspecialidad.Text;
}
```

### 2. `cargarObjetoReglas()` — Después
```csharp
// Solo guardar si se seleccionó un subtipo (Padre=0)
rglEntidad.especialidadID = new Guid(cboSubtipo.SelectedValue.ToString());
rglEntidad.especialidadTexto = cboSubtipo.Text;
```
**Efecto:** Siempre usa el subtipo. La validación del paso 1 garantiza que no llega aquí sin uno seleccionado.

---

### 3. `agregarRegistroGrilla()` — Antes
```csharp
string especialidadTexto;
if (cboSubtipo.SelectedValue != null && cboSubtipo.SelectedIndex != -1)
    especialidadTexto = cboSubtipo.Text;
else
    especialidadTexto = cboEspecialidad.Text;  // ← Mostraba el Padre=1 en grilla
```

### 3. `agregarRegistroGrilla()` — Después
```csharp
// Siempre usa el subtipo (validarDatosIngresados garantiza que está seleccionado)
string especialidadTexto = cboSubtipo.Text;
```

---

## Impacto

| Escenario | Antes del fix | Después del fix |
|---|---|---|
| Guardar Horario sin subtipo | ✅ Permitido (guardaba Padre=1) | ❌ Bloqueado con mensaje |
| Guardar Horario con subtipo | ✅ Correcto | ✅ Correcto |
| Nuevos TipoExamenDePaciente | Podían tener Padre=1 | Siempre Padre=0 |
| Registros históricos en BD | — | No se modifican (ver diagnóstico) |

---

## Registros históricos mal guardados

Este fix **NO corrige** los 17.803 registros ya existentes en `TipoExamenDePaciente` con `idEspecialidad` apuntando a Padre=1.

Para diagnosticar un paciente con ese problema usar la consulta del archivo:  
→ [DIAGNOSTICO_TEP_PADRE1_HISTORICO.md](DIAGNOSTICO_TEP_PADRE1_HISTORICO.md)

---

## Pendiente

- `TurnoFactory.cs` — El SELECT que crea `TipoExamenDePaciente` no filtra `Padre=0`.  
  No urgente porque los Horarios con Padre=1 tienen `TurnosFuturos=0`, pero debería corregirse para mayor robustez.
