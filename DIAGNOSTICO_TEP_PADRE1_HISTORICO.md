# Diagnóstico: TipoExamenDePaciente con EspecialidadPadre=1

**Fecha análisis:** 13/05/2026  
**Estado:** Registros históricos en BD — NO afecta nuevos ingresos desde fix del 13/05/2026

---

## El Problema Visible

En Mesa de Entrada, al buscar ciertos pacientes, la columna **Subtipo de Examen** muestra el **tipo genérico** en lugar del subtipo correcto:

- "FUERZAS ARMADAS Y DE SEGURIDAD" en vez de "SPB", "SPF", etc.
- "PRE-OCUPACIONAL" en vez de "PREOCUPACIONAL LEY", "LEY + LUMBAR", etc.
- "PERIODICOS" en vez de "PERIODICO LEY + AUDIO", etc.

---

## Cantidad de Registros Afectados

| Métrica | Valor |
|---|---|
| Total `TipoExamenDePaciente` mal guardados | **17.803** |
| Consultas/exámenes distintos afectados | **16.045** |

### Desglose por EspecialidadPadre incorrecta:

| EspecialidadPadre (mal) | Registros | Subtipos posibles |
|---|---|---|
| PRE-OCUPACIONAL | 13.485 | 27 |
| PERIODICOS | 1.473 | 13 |
| CASINO | 1.187 | 0 |
| PARTICULARES | 1.177 | 10 |
| CAMIONEROS SENIOR | 360 | 0 |
| POST COVID 19 | 55 | 0 |
| FUTBOL | 40 | 6 |
| BASQUET | 8 | 7 |
| LICENCIAS PNA | 4 | 9 |
| FUERZAS ARMADAS Y DE SEGURIDAD | 4 | 27 |
| Otros | ~10 | varios |

---

## Cómo Se Generó

### Cadena completa del bug:

```
1. frmHorario (en el pasado, sin validación)
   └─ Operador seleccionó Tipo (cboEspecialidad) pero NO seleccionó Subtipo (cboSubtipo)
   └─ cargarObjetoReglas() guardaba cboEspecialidad.SelectedValue como especialidadID
   └─ Horario.especialidadID = GUID de "PRE-OCUPACIONAL" (Padre=1)  ← BUG ORIGEN

2. frmTurnos
   └─ Se agendaron turnos desde ese Horario malo
   └─ Turno.horarioID → Horario con especialidadID=Padre=1

3. Mesa de Entrada (TurnoFactory.cs)
   └─ Al ingresar el paciente, TurnoFactory ejecuta:
      SELECT e.id FROM Turno t 
        JOIN Horario h ON t.horarioID = h.id
        JOIN Especialidad e ON h.especialidadID = e.id  ← sin filtrar Padre=0
   └─ INSERT TipoExamenDePaciente(idEspecialidad = GUID_PADRE=1)  ← REGISTRO MALO

4. Mesa de Entrada grilla
   └─ JOIN TipoExamenDePaciente → Especialidad
   └─ Muestra "PRE-OCUPACIONAL" / "FUERZAS ARMADAS..." en columna Subtipo
```

---

## Cómo Verificar si un Paciente Tiene Este Problema

Cuando vuelva a aparecer el problema, ejecutar esta consulta con el DNI del paciente:

```sql
-- Verificar si paciente X tiene TipoExamenDePaciente mal guardado
-- Reemplazar '12345678' con el DNI real
SELECT 
    tep.id              AS TEP_id,
    e.descripcion       AS EspecialidadGuardada,
    e.Padre             AS EsPadre,        -- 1 = MAL GUARDADO, 0 = CORRECTO
    c.identificador     AS NroExamen,
    CONVERT(DATE,c.fecha) AS FechaExamen,
    p.dni               AS DNI,
    p.apellido + ' ' + p.nombres AS Paciente,
    -- Subtipo correcto via Turno (si existe)
    eCorr.descripcion   AS SubtipoCorrectoViaTurno
FROM dbo.TipoExamenDePaciente tep
INNER JOIN dbo.Especialidad e   ON tep.idEspecialidad = e.id
INNER JOIN dbo.Consulta c       ON tep.idConsulta = c.id
INNER JOIN dbo.Paciente p       ON c.pacienteID = p.id
LEFT  JOIN dbo.Turno t          ON tep.idTurno = t.id
LEFT  JOIN dbo.Horario h        ON t.horarioID = h.id
LEFT  JOIN dbo.Especialidad eCorr ON h.especialidadID = eCorr.id AND eCorr.Padre = 0
WHERE p.dni = '12345678'
ORDER BY c.fecha DESC
```

### Interpretación del resultado:

| `EsPadre` | Significado | Solución |
|---|---|---|
| `0` | ✅ Correcto — subtipo válido | Ninguna |
| `1` y `SubtipoCorrectoViaTurno` tiene valor | ❌ Mal guardado pero **corregible** automáticamente | UPDATE puntual |
| `1` y `SubtipoCorrectoViaTurno` es NULL | ❌ Mal guardado, Horario también tenía Padre=1 | Corrección manual |

---

## Consulta Global de Diagnóstico

Para ver todos los mal guardados con el subtipo correcto disponible via Turno:

```sql
SELECT 
    eMal.descripcion        AS PadreMal,
    eCorr.descripcion       AS SubtipoCorrectoViaTurno,
    COUNT(*)                AS Cantidad
FROM dbo.TipoExamenDePaciente tep
INNER JOIN dbo.Especialidad eMal  ON tep.idEspecialidad = eMal.id AND eMal.Padre = 1
INNER JOIN dbo.Turno t            ON tep.idTurno = t.id
INNER JOIN dbo.Horario h          ON t.horarioID = h.id
INNER JOIN dbo.Especialidad eCorr ON h.especialidadID = eCorr.id AND eCorr.Padre = 0
GROUP BY eMal.descripcion, eCorr.descripcion
ORDER BY Cantidad DESC
```

---

## Fixes Aplicados (13/05/2026)

### `frmHorario.cs` — CORREGIDO ✅

**`validarDatosIngresados()`**: Ahora bloquea el guardado si no se seleccionó subtipo:
```csharp
if (cboSubtipo.SelectedIndex == -1 || cboSubtipo.SelectedValue == null)
    return "Debe seleccionar un Subtipo de Examen.";
```

**`cargarObjetoReglas()`**: Eliminado el fallback a `cboEspecialidad` (Padre=1). Solo acepta `cboSubtipo`.

**`agregarRegistroGrilla()`**: Simplificado para usar siempre `cboSubtipo.Text`.

### `TurnoFactory.cs` — PENDIENTE ⏳

El SELECT interno no filtra `Padre=0`. No es urgente porque los 169 Horarios con Padre=1 tienen `TurnosFuturos=0` — no generan nuevos problemas.

---

## Impacto Real

- **Nuevos pacientes desde 13/05/2026**: ✅ Sin problema — fix aplicado
- **Pacientes históricos (pre-13/05/2026)**: ❌ 17.803 registros con dato malo — visible cuando se buscan esos pacientes en Mesa de Entrada
- **Operativa actual**: No se bloquea ningún flujo — es solo un dato de clasificación incorrecto en la visualización

---

## Decisión Pendiente

Para corregir los 17.803 registros históricos se necesita:
1. **Backup previo** de la base de datos
2. **UPDATE masivo** via script SQL (preparar con DBA)
3. **Validación post-UPDATE** comparando antes/después

**No ejecutar sin backup confirmado.**
