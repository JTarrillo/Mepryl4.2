# Dos formas de actualizar precios en frmPreciosPublico

Ambas herramientas terminan modificando los valores de `colPromo01..12` en `dgvPrecios`
y, al presionar **Guardar**, esos valores se persisten en `PrecioPublico.PrecioPromo` por mes.
La diferencia está en **cómo** llegan al nuevo valor.

---

## Camino 1 — Coeficientes (encabezado + celda individual)

### ¿Qué hace?
Calcula el nuevo precio **multiplicando en cascada** desde el mes anterior.

```
PrecioPromo[mes N] = PrecioPromo[mes N-1] × Coeficiente[N-1]
```

### Dos formas de activarlo

| Acción | Alcance | Guarda coef en BD |
|--------|---------|-------------------|
| **Doble clic en encabezado** de `colCoef01..12` | Recalcula **todas las filas** de ese mes en adelante | ✅ Sí, en `CoeficientePrecio` (global) |
| **Editar celda** `colCoef` en una fila | Recalcula **solo esa fila** en adelante | ❌ No, solo queda en la grilla hasta Guardar |

### Flujo interno
```
[Usuario edita coef] 
    → dgvPrecios_CellEndEdit / ColumnHeaderMouseDoubleClick
    → AplicarCalculoCoeficientesSucesivos[Fila](mes)
    → por cada mes siguiente: colPromo[mes] = colPromo[mes-1] × coef[mes-1]
    → (si fue encabezado) GuardarCoeficientesAnio() → tabla CoeficientePrecio
```

### Características
- El redondeo depende de los valores previos: es **exacto** (sin redondeo forzado).
- Detiene la cascada si un mes intermedio tenía precio `0` (no llena ceros).
- Si se edita una celda de precio directo (`colPromo`): solo actualiza los meses que **ya tenían valor** (no propaga a ceros).

---

## Camino 2 — Aplicar Variación (panel derecho)

### ¿Qué hace?
Toma el precio actual y lo multiplica por un factor, luego **redondea al millar superior**.

```
PrecioPromo[mes] = CEILING( PrecioPromo[mes] × factor / 1000 ) × 1000
```

### Cómo se configura el factor

| Modo | Cálculo interno |
|------|----------------|
| **Incremento %** (chkFactor = false) | `factor = 1 + valor / 100` → ej: 15% → factor = 1.15 |
| **Usar factor** (chkFactor = true) | `factor = valor` directamente → ej: 1.15 |

### Alcance
- **Mes a aplicar:** `Todos` (1-12) o un mes específico.
- **Filas:** Si hay filas seleccionadas en la grilla → solo esas. Si no → todas.

### Flujo interno
```
[Usuario → Aplicar ▼ → Aplicar variación al mes seleccionado]
    → AplicarVariacionGrilla()
    → por cada fila × por cada mes en rango:
        colPromo[mes] = CEILING(colPromo[mes] × factor / 1000) × 1000
    → txtVariacion.Text = "0"  (resetea el campo)
    → NO guarda en BD → queda pendiente hasta presionar Guardar
```

### Características
- **Siempre redondea al millar superior** (`Math.Ceiling(x / 1000) * 1000`).
- No modifica los coeficientes (`colCoef`, `CoeficientePrecio`). Son independientes.
- Actúa sobre los precios **ya cargados en la grilla**, no recalcula a partir del mes anterior.

---

## Comparación directa

| Aspecto | Coeficientes | Aplicar Variación |
|---------|-------------|-------------------|
| **Fórmula** | precio[N] = precio[N-1] × coef | precio = precio × factor |
| **Base del cálculo** | Mes anterior en cascada | Precio actual del mes directamente |
| **Redondeo** | Ninguno (valor exacto) | Al millar superior (CEILING/1000) |
| **Alcance de meses** | Desde el mes editado en adelante | Mes específico o todos |
| **Alcance de filas** | Fila editada (celda) o todas (encabezado) | Filas seleccionadas o todas |
| **Guarda coef en BD** | Sí (doble clic en encabezado) | No |
| **Trigger** | Edición en grilla / doble clic encabezado | Botón Aplicar ▼ |
| **Caso de uso típico** | Actualización progresiva mes a mes con coeficiente IPC | Aumento masivo puntual con redondeo comercial |

---

## Cuándo usar cada uno

- **Coeficientes:** cuando se quiere que cada mes derive del anterior con un factor acumulado (ej: inflación mensual encadenada).
- **Variación:** cuando se quiere subir un porcentaje fijo sobre los precios ya definidos, dejando valores redondeados "comercialmente" (ej: subir 15% y que quede en múltiplos de $1.000).

Ambos caminos **no se excluyen**: se puede aplicar primero la variación masiva y luego ajustar coeficientes individuales fila a fila, o viceversa. El resultado final es siempre lo que está visible en `dgvPrecios` al momento de presionar **Guardar**.
