# Comparativa de Bases de Datos: 3dejunio (Actualizada) vs 17dejunio (Desactualizada)

Este documento detalla las diferencias críticas encontradas entre la base de datos maestra **3dejunio** y la versión obsoleta **17dejunio**. El objetivo es justificar por qué el sistema DEBE estar conectado a **3dejunio** para su correcto funcionamiento.

## 1. Estructura de la Tabla `especialidad`
La tabla que define los tipos de examen ha sufrido una transformación arquitectónica.

| Característica | Base 3dejunio (Actual) | Base 17dejunio (Obsoleta) |
| :--- | :--- | :--- |
| **Jerarquía** | Soporta **Padres e Hijos** mediante las columnas `Padre` (bit) e `IdPadre` (GUID). | Estructura plana. No permite agrupar subtipos bajo una especialidad madre. |
| **Estado Lógico** | Columna `estado` para activar/desactivar sin borrar registros históricos. | Ausente. Probablemente depende de borrado físico o incompleto. |
| **Compatibilidad** | Permite que registros antiguos (Tipo) y nuevos (Subtipo) convivan. | Inconsistente. Rompe la visualización de turnos históricos. |

## 2. Tablas Nuevas y Críticas
La base **3dejunio** incluye tablas fundamentales que no existen en la versión del 17 de junio:

- **`PrecioPublico`**: Permite la gestión de la lista de precios independiente (Precio Lista). Es la base para la lógica de "Precio Público = Promo * Factor".
- **`ObservacionPredefinida`**: Almacena los textos rápidos para la agenda. Sin ella, el selector de observaciones en la pantalla de turnos aparece vacío.

## 3. Lógica de Precios y Señas
La gestión financiera ha sido rediseñada para ser más robusta.

| Funcionalidad | Base 3dejunio | Base 17dejunio |
| :--- | :--- | :--- |
| **Campo Seña** | Integrado en `PrecioPromo`, `PrecioPublico` y `TipoExamenDePaciente`. | Ausente. No hay forma de registrar pagos parciales de forma estructurada. |
| **Precio Lista** | Columna dedicada para diferenciar el precio de calle del promocional. | Solo existe un campo de importe genérico. |
| **Fuerza de Precio** | Columnas de `CoeficienteIndividual` preparadas para importes fijos (ej. los $600 manuales). | No soporta importes fijos manuales por mes. |

## 4. Procedimientos Almacenados (SPs)
Los procedimientos son los que ejecutan la lógica del código en el servidor SQL.

### `sp_TipoExamenDePaciente_Add` / `Update`
- **3dejunio**: Acepta parámetros `@precioLista` y `@seña`. Guarda el estado financiero real del paciente.
- **17dejunio**: No reconoce estos parámetros. El sistema daría error al intentar guardar un turno.

### `sp_TipoExamenDePaciente_UpdateTipoExamenPaciente`
- **3dejunio**: **Flexible**. Se eliminó la restricción que obligaba a que todo fuera Subtipo (`Padre=0`).
- **17dejunio**: **Restrictiva**. Tiene un `RAISERROR` que bloquea la edición de cualquier paciente antiguo que tenga asignado un "Tipo" (Padre).

## 5. Conclusión Técnica
La base de datos **17dejunio**, a pesar de su nombre cronológicamente posterior, carece de la evolución estructural necesaria para el software actual. 

**Impacto de usar 17dejunio:**
1. Errores fatales al guardar turnos (parámetros no encontrados).
2. Imposibilidad de usar la pestaña de Precios Públicos.
3. Desaparición de las observaciones predefinidas.
4. Bloqueo al intentar editar registros de pacientes históricos.

---
*Documento generado para la auditoría de sincronización de MEPRYL 4.2 - 17/06/2026*
