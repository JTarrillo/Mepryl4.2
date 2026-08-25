# Problema: Observaciones duplicadas en frmRecepcion

## Fecha
13/07/2026 (actualizado 25/08/2026)

## Descripción del Problema

### Problema Original (13/07/2026)
Las observaciones de los turnos que se mostraban correctamente en `frmTurnos` no estaban llegando a `frmRecepcion`. Específicamente, las observaciones automáticas con información de precios (ej: `$ 190.000 - $ 5.000 (SEÑA) | LISTA: $ 256.500 - SEÑA = $ 251.500`) no se visualizaban en la grilla de recepción.

### Problema Nuevo (25/08/2026)
En la columna Observaciones de la sección Ventanilla del sistema Mepryl, se está duplicando el texto del monto e importe. Por ejemplo: `$ 74.000 | LISTA: $ 84.000 | $ 74.000 | LISTA: $ 84.000` para varios registros (Rey Martin, Torrejon Eithan, Robles Francisco, etc.).

## Causa Raíz

### Problema Original (13/07/2026)
El problema tenía dos componentes:

#### 1. Prioridad de Observaciones Manuales
El método `ObtenerObservacionVigente()` en `CapaDatosMepryl\Ventanilla.cs` y `CapaPresentacion\frmTurnos.cs` tenía una lógica que podía sobrescribir observaciones manuales con información automática de precios cuando el sistema detectaba que se requería observación automática (planilla, seña, observacionesExtra).

#### 2. Uso de Precios Incorrectos
En `CapaDatosMepryl\Ventanilla.cs`, el método `generarTablaRetornoVentanillaBatch()` estaba usando precios vigentes (PrecioPromo, PrecioListaVigente, SenaVigente) para regenerar observaciones automáticas, en lugar de usar los precios guardados en `TipoExamenDePaciente` (precioExamen, seña, precioLista).

### Problema Nuevo (25/08/2026) - Duplicación de Observaciones
El método `ObtenerObservacionVigente()` estaba pasando observaciones que ya contenían información de precios (observaciones automáticas) como parámetro `observacionesExtra` al método `GenerarObservaciones()`. Como `GenerarObservaciones()` concatenaba `observacionesExtra` con los nuevos precios sin verificar si ya contenía una observación automática completa, esto causaba la duplicación del texto de precios.

Específicamente:
- En `Ventanilla.cs` línea 293: `observacionesParaVigente` se establecía a `teData.observacionesManual` o `teData.observacionesExtra`
- Si `observacionesParaVigente` ya era una observación automática (ej: `$ 74.000 | LISTA: $ 84.000`), se pasaba como `observacionesExtra` a `GenerarObservaciones()`
- `GenerarObservaciones()` concatenaba esto con los nuevos precios, resultando en: `$ 74.000 | LISTA: $ 84.000 | $ 74.000 | LISTA: $ 84.000`

## Datos del Caso de Prueba

**Turno ID:** 80554F7C-3211-4EF5-8E6A-021F69F146E8
**Observación en BD:** `$ 190.000 - $ 5.000 (SEÑA) | LISTA: $ 256.500 - SEÑA = $ 251.500`

**TipoExamenDePaciente:**
- precioExamen: 190000
- seña: 5000
- precioLista: 256500

**Precios Vigentes (PrecioPromo/PrecioPublico):**
- PrecioPromo: 180000
- PrecioListaPublico: 243000
- SenaConfig: 0

## Soluciones Aplicadas

### Solución al Problema Original (13/07/2026)

### 1. Modificación de ObtenerObservacionVigente en Ventanilla.cs

**Archivo:** `CapaDatosMepryl\Ventanilla.cs` (líneas 99-118)

```csharp
private string ObtenerObservacionVigente(string observacionActual, decimal promo, decimal lista, decimal sena, bool llevaPlanilla, string observacionesExtra)
{
    // PRIORIDAD: Siempre preservar la observación manual del turno
    if (!string.IsNullOrWhiteSpace(observacionActual))
    {
        // Si es observación automática, regenerarla con datos actualizados
        if (EsObservacionAutomatica(observacionActual))
            return GenerarObservaciones(promo, lista, sena, llevaPlanilla, observacionesExtra);
        
        // Si es observación manual, devolverla tal cual (prioridad absoluta)
        return observacionActual;
    }

    // Si está vacía, generar observación automática si se requiere
    bool requiereObservacionAutomatica = llevaPlanilla || sena > 0 || !string.IsNullOrWhiteSpace(observacionesExtra);
    if (requiereObservacionAutomatica)
        return GenerarObservaciones(promo, lista, sena, llevaPlanilla, observacionesExtra);

    return string.Empty;
}
```

### 2. Modificación de ObtenerObservacionVigente en frmTurnos.cs

**Archivo:** `CapaPresentacion\frmTurnos.cs` (líneas 1451-1473)

```csharp
private string ObtenerObservacionVigente(string observacionActual, Entidades.TipoExamen te)
{
    if (te == null)
        return observacionActual ?? string.Empty;

    // PRIORIDAD: Siempre preservar la observación manual del turno
    if (!string.IsNullOrWhiteSpace(observacionActual))
    {
        // Si es observación automática, regenerarla con datos actualizados
        if (EsObservacionAutomatica(observacionActual))
            return generarObservaciones(te);
        
        // Si es observación manual, devolverla tal cual (prioridad absoluta)
        return observacionActual;
    }

    // Si está vacía, generar observación automática si se requiere
    bool requiereObservacionAutomatica = te.LlevaPlanilla || te.Seña > 0 || !string.IsNullOrWhiteSpace(te.ObservacionesExtra);
    if (requiereObservacionAutomatica)
        return generarObservaciones(te);

    return string.Empty;
}
```

### 3. Modificación de generarTablaRetornoVentanillaBatch en Ventanilla.cs

**Archivo:** `CapaDatosMepryl\Ventanilla.cs` (líneas 279-293)

```csharp
if (tieneTipoExamenPaciente)
{
    // PRIORIDAD: Usar precios del TipoExamenDePaciente si existen, sino usar precios vigentes
    decimal promoObservacion = teData.precio > 0 ? teData.precio : (teData.precioPromoVigente > 0 ? teData.precioPromoVigente : importeBruto);
    decimal listaObservacion = teData.precio > 0 ? (teData.precioListaVigente > 0 ? teData.precioListaVigente : 0) : teData.precioListaVigente;
    decimal senaObservacion = teData.precio > 0 ? teData.sena : teData.senaVigente;
    
    observaciones = ObtenerObservacionVigente(
        observaciones,
        promoObservacion,
        listaObservacion,
        senaObservacion,
        teData.llevaPlanilla,
        teData.observacionesExtra);
}
```

### Solución al Problema de Duplicación (25/08/2026 - Segundo intento)

#### Modificación de generarTablaRetornoVentanillaBatch en Ventanilla.cs

**Archivo:** `CapaDatosMepryl\Ventanilla.cs` (líneas 287-317)

**Problema identificado:**
- La consulta principal trae `t.observaciones` como `Observaciones`
- La consulta `tipoExamenBatch` también trae `t.observaciones` como `ObservacionesManual`
- Si `t.observaciones` ya contenía una observación automática, se estaba pasando como `observacionesExtra` a `GenerarObservaciones`, causando duplicación

**Solución aplicada:**
Verificar si la observación del turno (de la consulta principal) ya es una observación automática antes de procesarla. Si lo es, usarla directamente sin pasar por `ObtenerObservacionVigente`.

```csharp
string observaciones = r["Observaciones"].ToString();

if (tieneTipoExamenPaciente)
{
    // PRIORIDAD: Si la observación del turno ya es automática, usarla directamente para evitar duplicación
    if (!string.IsNullOrWhiteSpace(observaciones) && EsObservacionAutomatica(observaciones))
    {
        // Ya es una observación automática válida, no procesarla más
    }
    else
    {
        // PRIORIDAD: Usar precios del TipoExamenDePaciente si existen, sino usar precios vigentes
        decimal promoObservacion = teData.precio > 0 ? teData.precio : (teData.precioPromoVigente > 0 ? teData.precioPromoVigente : importeBruto);
        decimal listaObservacion = teData.precio > 0 ? (teData.precioListaVigente > 0 ? teData.precioListaVigente : 0) : teData.precioListaVigente;
        decimal senaObservacion = teData.precio > 0 ? teData.sena : teData.senaVigente;

        System.Diagnostics.Debug.WriteLine($"[VENTANILLA] IdTurno={idTurno}, IdEspecialidad={teData.idEspecialidad}, ObservacionesManual='{teData.observacionesManual}', ObservacionesExtra='{teData.observacionesExtra}', LlevaPlanilla={teData.llevaPlanilla}");

        // PRIORIDAD: Si hay observación manual en la tabla Turno, usar esa. Si no, usar observaciones automáticas
        string observacionesParaVigente = !string.IsNullOrWhiteSpace(teData.observacionesManual) ? teData.observacionesManual : teData.observacionesExtra;

        observaciones = ObtenerObservacionVigente(
            observaciones,
            promoObservacion,
            listaObservacion,
            senaObservacion,
            teData.llevaPlanilla,
            observacionesParaVigente);
    }
}
```

#### 1. Modificación de ObtenerObservacionVigente en Ventanilla.cs (intento anterior - mantenido como respaldo)

**Archivo:** `CapaDatosMepryl\Ventanilla.cs` (líneas 99-125)

```csharp
private string ObtenerObservacionVigente(string observacionActual, decimal promo, decimal lista, decimal sena, bool llevaPlanilla, string observacionesExtra)
{
    // PRIORIDAD: Siempre preservar la observación manual del turno
    if (!string.IsNullOrWhiteSpace(observacionActual))
    {
        // Si es observación automática, regenerarla con datos actualizados
        if (EsObservacionAutomatica(observacionActual))
            return GenerarObservaciones(promo, lista, sena, llevaPlanilla, observacionesExtra);

        // Si es observación manual, devolverla tal cual (prioridad absoluta)
        return observacionActual;
    }

    // Si está vacía, generar observación automática si se requiere
    bool requiereObservacionAutomatica = llevaPlanilla || sena > 0 || !string.IsNullOrWhiteSpace(observacionesExtra) || promo > 0 || lista > 0;
    if (requiereObservacionAutomatica)
    {
        // Si observacionesExtra ya es una observación automática completa, usarla directamente para evitar duplicación
        if (!string.IsNullOrWhiteSpace(observacionesExtra) && EsObservacionAutomatica(observacionesExtra))
            return observacionesExtra;

        return GenerarObservaciones(promo, lista, sena, llevaPlanilla, observacionesExtra);
    }

    return string.Empty;
}
```

#### 2. Modificación de ObtenerObservacionVigente en frmTurnos.cs (intento anterior - mantenido como respaldo)

**Archivo:** `CapaPresentacion\frmTurnos.cs` (líneas 1538-1566)

```csharp
private string ObtenerObservacionVigente(string observacionActual, Entidades.TipoExamen te)
{
    if (te == null)
        return observacionActual ?? string.Empty;

    // PRIORIDAD: Siempre preservar la observación manual del turno
    if (!string.IsNullOrWhiteSpace(observacionActual))
    {
        // Si es observación automática, regenerarla con datos actualizados
        if (EsObservacionAutomatica(observacionActual))
            return generarObservaciones(te);

        // Si es observación manual, devolverla tal cual (prioridad absoluta)
        return observacionActual;
    }

    // Si está vacía, generar observación automática si se requiere
    bool requiereObservacionAutomatica = te.LlevaPlanilla || te.Seña > 0 || !string.IsNullOrWhiteSpace(te.ObservacionesExtra) || te.PrecioBase > 0 || te.PrecioLista > 0;
    if (requiereObservacionAutomatica)
    {
        // Si te.ObservacionesExtra ya es una observación automática completa, usarla directamente para evitar duplicación
        if (!string.IsNullOrWhiteSpace(te.ObservacionesExtra) && EsObservacionAutomatica(te.ObservacionesExtra))
            return te.ObservacionesExtra;

        return generarObservaciones(te);
    }

    return string.Empty;
}
```

## Comportamiento Resultante

### Observaciones Manuales
- Se preservan siempre (prioridad absoluta)
- No son sobrescritas por información automática

### Observaciones Automáticas
- Se regeneran con los precios correctos de TipoExamenDePaciente
- Mantienen consistencia entre frmTurnos y frmRecepcion

### Sin Observación
- Se genera observación automática solo si se requiere (planilla, seña, observacionesExtra)

## Archivos Modificados

### Modificaciones del 13/07/2026
1. `CapaDatosMepryl\Ventanilla.cs`
   - Método `ObtenerObservacionVigente()` (líneas 99-118)
   - Método `generarTablaRetornoVentanillaBatch()` (líneas 279-293)

2. `CapaPresentacion\frmTurnos.cs`
   - Método `ObtenerObservacionVigente()` (líneas 1451-1473)

### Modificaciones del 25/08/2026
1. `CapaDatosMepryl\Ventanilla.cs`
   - Método `ObtenerObservacionVigente()` (líneas 99-125) - Agregada verificación para evitar duplicación cuando observacionesExtra ya es una observación automática

2. `CapaPresentacion\frmTurnos.cs`
   - Método `ObtenerObservacionVigente()` (líneas 1538-1566) - Agregada verificación para evitar duplicación cuando te.ObservacionesExtra ya es una observación automática

## Validación

Las observaciones de los turnos ahora llegan correctamente a frmRecepcion, manteniendo la misma información que se muestra en frmTurnos, tanto para observaciones manuales como automáticas.
