# Corrección de Estructura de Carpetas RX para Consolidación

## Fecha
30/07/2026

## Problema Identificado

Al realizar el proceso de consolidación de estudios laborales, los archivos de RX (radiografías) no estaban siendo incluidos en el PDF consolidado. El sistema reportaba el siguiente error:

```
Fecha	NroOrden	DNI	Mensaje
28/07/2026	L1	32765193	RX
```

## Causa Raíz

La estructura de carpetas de RX en el servidor cambió, pero el código de búsqueda de archivos no se actualizó para adaptarse a la nueva organización.

### Estructura Antigua
```
S:\PUBLICO\ESTUDIOS DIGITALIZADOS\LABORAL\RX\2026\07-JULIO\28\archivo.jpg
```
- Los archivos JPG estaban directamente en la carpeta del día (28)

### Estructura Nueva
```
S:\PUBLICO\ESTUDIOS DIGITALIZADOS\LABORAL\RX\2026\07-JULIO\28\
├── 20260728_082140_L1 DNI 3276519_289496\
│   ├── 20260728_082140_L1 DNI 32765193_289496.jpg
│   ├── 20260728_082217_L1 DNI 32765193_289496.jpg
│   └── 20260728_082244_L1 DNI 32765193_289496.jpg
├── dcm\
│   └── L1 DNI 32765193_CHAO LUIS ARNALDO_20260728\
│       ├── 20260728_082140_L1-DNI-32765193_289_496_792.dcm
│       ├── 20260728_082217_L1-DNI-32765193_289_497_794.dcm
│       └── 20260728_082244_L1-DNI-32765193_289_497_795.dcm
└── PortView\
    └── (archivos del sistema PortView)
```
- Los archivos ahora están en subcarpetas con timestamp (ej: `20260728_082140_L1 DNI 3276519_289496`)
- Cada subcarpeta contiene los archivos JPG correspondientes a ese estudio

## Archivo Modificado

**Archivo:** `c:\Mepryl4.2\SOLUCION 4.2\MEPRYL\CapaPresentacion\frmBusquedaLaboral.cs`

**Método:** `CargarArchivoRX` (líneas 1999-2048)

## Solución Aplicada

### Filtro Anterior
```csharp
strFiltro = strFecha + "*_" + NroOrden + " *_?????_*.jpg";
```
- **Problema:** El filtro era demasiado específico y esperaba un formato exacto de nombre de archivo
- **Formato esperado:** `20260728_*_L1 *_?????_*.jpg`
- **Resultado:** No encontraba archivos en la nueva estructura de subcarpetas

### Filtro Nuevo
```csharp
// Nuevo filtro para estructura cambiada de RX
// Busca archivos JPG que contengan el número de orden en cualquier subcarpeta
strFiltro = "*" + NroOrden + "*.jpg";
```
- **Ventaja:** Más flexible, busca cualquier JPG que contenga el número de orden
- **Formato aceptado:** `*L1*.jpg`
- **Resultado:** Encuentra archivos en cualquier subcarpeta

### Búsqueda Recursiva
El código ya utilizaba `SearchOption.AllDirectories`, lo que permite buscar en todas las subcarpetas recursivamente:

```csharp
foreach (var fi in di.GetFiles(strFiltro, System.IO.SearchOption.AllDirectories))
```

## Resultado Esperado

Con el nuevo filtro:
- ✅ Los archivos RX en subcarpetas con timestamp serán encontrados
- ✅ Los 3 archivos JPG del paciente CHAO LUIS ARNALDO se incluirán en el consolidado
- ✅ El proceso de consolidación funcionará correctamente con la nueva estructura de carpetas

## Archivos Afectados

Para el caso específico del paciente CHAO LUIS ARNALDO (DNI: 32765193, Orden: L1):

**Archivos encontrados:**
- `20260728_082140_L1 DNI 32765193_289496.jpg`
- `20260728_082217_L1 DNI 32765193_289496.jpg`
- `20260728_082244_L1 DNI 32765193_289496.jpg`

**Ubicación:**
```
S:\PUBLICO\ESTUDIOS DIGITALIZADOS\LABORAL\RX\2026\07-JULIO\28\20260728_082140_L1 DNI 3276519_289496\
```

## Impacto

- **Usuarios afectados:** Todos los usuarios que realizan consolidación de estudios laborales
- **Estudios afectados:** Radiografías (RX) de pacientes laborales
- **Beneficio:** Los archivos RX se incluirán correctamente en los PDFs consolidados

## Recomendaciones

1. **Monitoreo:** Verificar que el proceso de consolidación funcione correctamente con otros pacientes
2. **Documentación:** Actualizar la documentación técnica para reflejar la nueva estructura de carpetas RX
3. **Capacitación:** Informar al personal técnico sobre el cambio en la estructura de carpetas
4. **Pruebas:** Realizar pruebas de consolidación con diferentes pacientes y fechas para asegurar la robustez de la solución

## Logs de Depuración

Se agregaron logs detallados en `UtilidadesMepryl.cs` para rastrear el proceso de consolidación:

**En `ConcatenarPDFs`:**
- Directorio base
- Cantidad de filas a procesar
- Datos de cada fila (Fecha, NroOrden, DNI, Nombre, Apellido, Mensaje)
- Archivos a procesar
- Path de salida del consolidado

**En `ProcesoConcatenar`:**
- Path de salida
- Cantidad de archivos en la lista
- Proceso de eliminación de archivo existente
- Por cada archivo: nombre, tipo (PDF/JPG), cantidad de páginas
- Errores de lectura

Estos logs permiten diagnosticar problemas futuros de manera más eficiente.
