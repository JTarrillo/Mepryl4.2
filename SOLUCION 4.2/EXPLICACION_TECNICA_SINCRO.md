# Documentación Técnica: Sincronización y Rescate de Subtipos - MEPRYL 4.2

Este documento explica la lógica implementada para resolver el problema de visualización de especialidades ("Tipos" vs "Subtipos") y la sincronización entre los módulos de Agenda, Ventanilla y Mesa de Entrada.

## 1. El Problema: Inconsistencia en Datos Históricos
El sistema presentaba discrepancias donde pacientes antiguos mostraban el tipo general (ej. **FUTBOL**) en lugar del subtipo específico (ej. **FUTBOL METRO**). Esto ocurría porque:
- Los turnos antiguos estaban vinculados directamente a una especialidad "Padre".
- La lógica de carga priorizaba la descripción del Horario sobre la ficha real del paciente.
- Las grillas de Ventanilla y Mesa de Entrada no compartían el mismo criterio de búsqueda.

## 2. La Solución: Lógica de "Rescate de Subtipos" (SQL Senior)
Se implementó una lógica de **triple rescate** utilizando `COALESCE` y `LEFT JOIN` en las consultas fundamentales del sistema.

### Ejemplo de Lógica SQL aplicada:
```sql
COALESCE(
    -- 1. Prioridad: ¿Tiene el ingreso del paciente un subtipo específico?
    CASE WHEN teReal.Padre = 0 THEN teReal.descripcion ELSE NULL END,
    
    -- 2. Fallback: Si el ingreso es un "Padre", ¿el Horario original tiene el subtipo?
    CASE WHEN e.Padre = 0 THEN e.descripcion ELSE NULL END,
    
    -- 3. Último recurso: Mostrar lo que haya disponible
    e.descripcion
) as SubtipoExamen
```

### Archivos Modificados:
- **[Turno.cs](file:///c:/Mepryl4.2/SOLUCION%204.2/MEPRYL/CapaDatosMepryl/Turno.cs)**: Sincronización de la grilla de la Agenda.
- **[Ventanilla.cs](file:///c:/Mepryl4.2/SOLUCION%204.2/MEPRYL/CapaDatosMepryl/Ventanilla.cs)**: Rescate de nombres específicos para la pantalla de Recepción.
- **[MesaEntrada.cs](file:///c:/Mepryl4.2/SOLUCION%204.2/MEPRYL/CapaDatosMepryl/MesaEntrada.cs)**: Normalización de datos para el ingreso final a consultorio.
- **[TipoExamen.cs](file:///c:/Mepryl4.2/SOLUCION%204.2/MEPRYL/CapaDatosMepryl/TipoExamen.cs)**: Actualización de la función `cargarEstudiosPorExamen` para que el panel de detalles (TextBox) también muestre el subtipo rescatado.

## 3. Sincronización de Interfaz (ComboBoxes y Detalle)
Para evitar que los selectores aparecieran vacíos o con nombres genéricos:
- **Detección de Tipos**: El sistema ahora detecta automáticamente si el ID es un `Guid` o un `string`.
- **Orden de Carga**: Se configuraron los `ValueMember` y `DisplayMember` antes de asignar el `DataSource`, garantizando que el control sepa qué valor seleccionar desde el primer momento.
- **Panel de Detalles**: Al unificar la lógica en `TipoExamen.cs`, logramos que el cuadro de texto superior en la Agenda muestre consistentemente el nombre completo (ej. **FUTBOL METRO MODIF.**).

## 4. Flujo de "Regresar a Ventanilla"
Se optimizó el proceso de corrección de errores mediante la función "Regresar Paciente":
- Se resetean los estados `recepcion` y `mesaDeEntrada`.
- Se mantiene `asistio = '1'` para que el paciente no desaparezca de la vista del recepcionista y sea fácil volver a ingresarlo tras la corrección.

---
**Resultado Final:** Un sistema consistente que "deduce" la información faltante basándose en el historial del turno, garantizando que el personal médico y administrativo siempre vea el estudio específico que corresponde al paciente.
