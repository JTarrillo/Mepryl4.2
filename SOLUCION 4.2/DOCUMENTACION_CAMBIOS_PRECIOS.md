# Documentación Técnica: Reestructuración de Precios y Lógica de Importes Netos

Este documento detalla los cambios realizados en la base de datos y en la aplicación MEPRYL para independizar los precios de lista y promocionales, además de implementar la visualización de importes netos (descontando la seña).

## 1. Reestructuración de la Base de Datos

Se realizó una limpieza y especialización de las tablas de precios mensuales para el año 2026.

- **Tabla `PrecioPromo`**:
    - Se eliminó la columna `PrecioLista` (ahora se gestiona en la tabla pública).
    - Fuente de verdad exclusiva para **Precios Promocionales**.
- **Tabla `PrecioPublico`**:
    - Se eliminó la columna `PrecioPromo`.
    - Fuente de verdad exclusiva para **Precios de Lista**.
- **Sincronización Inicial**:
    - Se poblaron ambas tablas para los 12 meses de 2026 usando como base el `precioBase` de la tabla maestra `Especialidad`.

## 2. Cambios en la Capa de Datos (CapaDatosMepryl)

Se actualizaron las clases para reflejar la nueva estructura de tablas y permitir consultas independientes.

- **[PrecioPublico.cs](file:///c:/Mepryl4.2/SOLUCION%204.2/MEPRYL/CapaDatosMepryl/PrecioPublico.cs)**:
    - Métodos `ListarPreciosPublicoAnio` y `GuardarPreciosPublicoAnio` modificados para operar únicamente sobre la columna `PrecioLista`.
- **[PrecioPromo.cs](file:///c:/Mepryl4.2/SOLUCION%204.2/MEPRYL/CapaDatosMepryl/PrecioPromo.cs)**:
    - Métodos actualizados para ignorar la columna `PrecioLista` y centrarse en `PrecioPromo`.
- **[Ventanilla.cs](file:///c:/Mepryl4.2/SOLUCION%204.2/MEPRYL/CapaDatosMepryl/Ventanilla.cs)**:
    - Se incluyó la columna `seña` en la recuperación de la grilla.
    - Se implementó el cálculo: `ImporteNeto = precioExamen - seña`.

## 3. Cambios en la Capa de Presentación (Interfaz)

### Gestión de Precios ([frmPrecioPromo.cs](file:///c:/Mepryl4.2/SOLUCION%204.2/MEPRYL/CapaPresentacion/frmPrecioPromo.cs))
- Se corrigió el evento `tabControl_SelectedIndexChanged` para forzar la recarga de datos y el refresco visual (`Invalidate/Update/Refresh`) al cambiar entre las pestañas de Promo y Público.
- La pestaña "Público" ahora muestra los valores de la columna `PrecioLista`.

### Formulario de Turnos ([frmTurnos.cs](file:///c:/Mepryl4.2/SOLUCION%204.2/MEPRYL/CapaPresentacion/frmTurnos.cs))
- **Visualización**: Los cuadros de texto `Importe` e `Imp. Lista` ahora muestran el valor neto (Total - Seña).
- **Interactividad**: Al modificar el cuadro de **Seña**, los importes superiores se recalculan automáticamente en tiempo real.
- **Persistencia**: Al guardar, el sistema suma la seña al valor de la pantalla para almacenar el **Total Bruto** correcto en la base de datos.

### Ventanas Auxiliares
- **[frmAvisoExamenModificado.cs](file:///c:/Mepryl4.2/SOLUCION%204.2/MEPRYL/CapaPresentacion/frmAvisoExamenModificado.cs)**: Se actualizó `tbImporte` para mostrar el neto.
- **[frmTipoExamen.cs](file:///c:/Mepryl4.2/SOLUCION%204.2/MEPRYL/CapaPresentacion/frmTipoExamen.cs)**: Se aplicó el descuento de seña en la visualización de Estudios Asociados y la suma de seña al momento de confirmar cambios.

## 4. Resumen de Lógica de Negocio Aplicada

| Escenario | Lógica Visual (UI) | Lógica de Base de Datos (SQL) |
| :--- | :--- | :--- |
| **Precio Promo** | `PrecioBase - Seña` | Se guarda en `PrecioPromo.PrecioPromo` |
| **Precio Lista** | `PrecioLista - Seña` | Se guarda en `PrecioPublico.PrecioLista` |
| **Recepción** | Muestra Saldo Neto | Lee `precioExamen - seña` |

---
*Documentación generada el 09/06/2026*
