# Documentación: Funcionalidad "Buscar Turno"

## Índice
1. [Descripción General](#descripción-general)
2. [Estructura del Código](#estructura-del-código)
3. [Logging Agregado](#logging-agregado)
4. [Bug Encontrado y Solución](#bug-encontrado-y-solución)
5. [Cómo Usar el Logging](#cómo-usar-el-logging)

---

## Descripción General
La funcionalidad "Buscar Turno" permite buscar turnos de pacientes por **DNI** o **Nombre** en el formulario `frmTurnos`.

---

## Estructura del Código

### 1. Capa de Presentación (`CapaPresentacion/frmTurnos.cs`)
| Método | Descripción |
|--------|-------------|
| `botBuscar_Click` | Maneja el evento del botón "Buscar" |
| `cargarGrillaTurnoConFiltro` | Decide si buscar por DNI o Nombre |
| `EsDNI` | Valida si el filtro es un DNI válido (7-8 dígitos) |
| `botLimpiar_Click` | Limpia el filtro y restaura la grilla |

### 2. Capa de Negocio (`CapaNegocioMepryl/Turno.cs`)
| Método | Descripción |
|--------|-------------|
| `buscarTurnosPorDNI` | Llama a la capa de datos para buscar por DNI |
| `buscarTurnosPorNombre` | Llama a la capa de datos para buscar por Nombre |

### 3. Capa de Datos (`CapaDatosMepryl/Turno.cs`)
| Método | Descripción |
|--------|-------------|
| `buscarTurnosPorDNI` | Ejecuta la consulta SQL para buscar por DNI |
| `buscarTurnosPorNombre` | Ejecuta la consulta SQL para buscar por Nombre |
| `generarTablaRetornoTurno` | Convierte los resultados de la BD a la estructura esperada |

---

## Logging Agregado
Se agregó logging con `System.Diagnostics.Debug.WriteLine` para monitorear el flujo:

### Capa de Presentación
- **Inicio/Fin de búsqueda**: `[BUSCAR_TURNO] === INICIO DE BÚSQUEDA ===`
- **Filtro ingresado**: `[BUSCAR_TURNO] Filtro ingresado: 'xxx'`
- **Tipo de búsqueda**: `[BUSCAR_TURNO] 🔍 Buscando por DNI: 'xxx'`
- **Resultados**: `[BUSCAR_TURNO] ✅ Resultados encontrados: 5`

### Capa de Datos
- **Inicio de consulta**: `[BUSCAR_TURNO][DATOS] buscarTurnosPorDNI() - DNI: 'xxx'`
- **Consulta ejecutada**: `[BUSCAR_TURNO][DATOS] Ejecutando consulta SQL para DNI`
- **Filas encontradas**: `[BUSCAR_TURNO][DATOS] Consulta completada - Filas encontradas: 2`
- **Errores**: `[BUSCAR_TURNO][DATOS] ❌ Error en buscarTurnosPorDNI: xxx`

---

## Bug Encontrado y Solución

### Problema
Error `System.IndexOutOfRangeException` en `generarTablaRetornoTurno` al buscar turnos.

### Causa
Las consultas SQL en `buscarTurnosPorDNI` y `buscarTurnosPorNombre` **faltaban columnas** y tenían un JOIN incorrecto:
1. Faltaba la columna `IdConsulta`
2. `IdSubtipo` usaba solo `te.id` en lugar de `COALESCE(tep.idEspecialidad, h.especialidadID)`
3. El JOIN de `Especialidad` usaba solo `h.especialidadID` en lugar de `COALESCE(tep.idEspecialidad, h.especialidadID)`

### Solución
Actualizar las consultas SQL para que coincidan con la consulta de `cargarTurnos`:
```sql
SELECT 
    t.id as Id,
    ISNULL(tePadre.descripcion, te.descripcion) as TipoPadre,
    te.descripcion as SubTipo,
    p.apellido + ' ' + p.nombres as Profesional,
    t.fecha as Fecha,
    t.horaReferencia as Hora,
    CONVERT(numeric, t.nroOrden) as Nro,
    t.pacienteID as idPaciente,
    t.codigo as Codigo,
    t.reserva as Reserva,
    t.usuarioID as Usuario,
    t.bloqueado as Bloqueado,
    t.asistio as Asistio,
    t.reservado as Reservado,
    tep.id as IdTipoExamen,
    t.habilitado as Habilitado,
    t.estadoID as IdEstado,
    COALESCE(tep.idEspecialidad, h.especialidadID) as IdSubtipo,  -- ✅ Corregido
    ISNULL(tePadre.id, te.id) as IdPadre,
    tep.idConsulta as IdConsulta  -- ✅ Agregado
FROM dbo.Turno t
INNER JOIN dbo.TurnoEstado e ON t.estadoID = e.id
INNER JOIN dbo.Horario h ON t.horarioID = h.id
INNER JOIN dbo.Profesional p ON h.profesionalID = p.id
LEFT JOIN dbo.TipoExamenDePaciente tep ON tep.idTurno = t.id
LEFT JOIN dbo.Especialidad te ON COALESCE(tep.idEspecialidad, h.especialidadID) = te.id  -- ✅ Corregido
LEFT JOIN dbo.Especialidad tePadre ON te.IdPadre = tePadre.id AND te.Padre = 0
```

---

## Cómo Usar el Logging
1. Abre Visual Studio
2. Ve a la ventana **Salida (Output)** (Menú: Depurar > Ventanas > Salida)
3. Ejecuta la aplicación y usa la funcionalidad "Buscar Turno"
4. Verás los logs en la ventana Salida con el prefijo `[BUSCAR_TURNO]`

### Ejemplo de Logs
```
[BUSCAR_TURNO] === INICIO DE BÚSQUEDA ===
[BUSCAR_TURNO] Filtro ingresado: '12345678'
[BUSCAR_TURNO] Ejecutando cargarGrillaTurnoConFiltro()
[BUSCAR_TURNO] cargarGrillaTurnoConFiltro() - Filtro: '12345678'
[BUSCAR_TURNO] EsDNI() - Valor limpio: '12345678', Longitud: 8
[BUSCAR_TURNO] EsDNI() - Resultado: True
[BUSCAR_TURNO] ¿Es DNI? True
[BUSCAR_TURNO] 🔍 Buscando por DNI: '12345678'
[BUSCAR_TURNO][DATOS] buscarTurnosPorDNI() - DNI: '12345678'
[BUSCAR_TURNO][DATOS] Ejecutando consulta SQL para DNI
[BUSCAR_TURNO][DATOS] Consulta completada - Filas encontradas: 5
[BUSCAR_TURNO] ✅ Resultados encontrados: 5
[BUSCAR_TURNO] Resultados cargados en el DataGridView
[BUSCAR_TURNO] === FIN DE BÚSQUEDA ===
```
