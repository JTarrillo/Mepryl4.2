# Diagnóstico: Bug especialidad PADRE guardada en TipoExamenDePaciente

**Fecha:** 05/05/2026  
**Bug:** Pacientes de FUERZAS ARMADAS / FÚTBOL quedan con `idEspecialidad` apuntando al tipo PADRE (ej: `FUERZAS ARMADAS Y DE SEGURIDAD`) en lugar del HIJO (ej: `SPF`, `PSA`, etc.)

---

## Diagrama de flujo (draw.io)

```xml
<mxfile host="app.diagrams.net" modified="2026-05-05" agent="GitHub Copilot" version="21.0">
  <diagram name="Bug TipoPadre" id="bug-tipo-padre">
    <mxGraphModel dx="1422" dy="762" grid="1" gridSize="10" guides="1" tooltips="1" connect="1" arrows="1" fold="1" page="1" pageScale="1" pageWidth="1169" pageHeight="827" math="0" shadow="0">
      <root>
        <mxCell id="0" />
        <mxCell id="1" parent="0" />

        <!-- TÍTULO -->
        <mxCell id="2" value="Bug: idEspecialidad guarda PADRE en vez de HIJO" style="text;html=1;strokeColor=none;fillColor=none;align=center;verticalAlign=middle;whiteSpace=wrap;rounded=0;fontSize=16;fontStyle=1;" vertex="1" parent="1">
          <mxGeometry x="200" y="20" width="769" height="40" as="geometry" />
        </mxCell>

        <!-- ============ CAMINO 1: CON TURNO ============ -->
        <mxCell id="10" value="CAMINO 1: Paciente CON turno previo" style="text;html=1;strokeColor=none;fillColor=#dae8fc;align=left;verticalAlign=middle;whiteSpace=wrap;rounded=0;fontSize=13;fontStyle=1;" vertex="1" parent="1">
          <mxGeometry x="30" y="80" width="350" height="30" as="geometry" />
        </mxCell>

        <mxCell id="11" value="Reserva de Turno&#xa;(frmTurnos)" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#dae8fc;strokeColor=#6c8ebf;" vertex="1" parent="1">
          <mxGeometry x="30" y="120" width="160" height="50" as="geometry" />
        </mxCell>

        <mxCell id="12" value="asignarTurnoPacienteLaboral&#xa;VentanillaMesaEntrada()" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#dae8fc;strokeColor=#6c8ebf;" vertex="1" parent="1">
          <mxGeometry x="220" y="120" width="180" height="50" as="geometry" />
        </mxCell>

        <mxCell id="13" value="Horario.especialidadID&#xa;= SPF (HIJO) ✅" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#d5e8d4;strokeColor=#82b366;" vertex="1" parent="1">
          <mxGeometry x="430" y="120" width="160" height="50" as="geometry" />
        </mxCell>

        <mxCell id="14" value="sp_TipoExamenDePaciente_Add&#xa;idEspecialidad = Horario.especialidadID ✅" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#d5e8d4;strokeColor=#82b366;" vertex="1" parent="1">
          <mxGeometry x="620" y="120" width="220" height="50" as="geometry" />
        </mxCell>

        <mxCell id="15" value="Mesa de Entrada&#xa;(dgvTurno)" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#dae8fc;strokeColor=#6c8ebf;" vertex="1" parent="1">
          <mxGeometry x="30" y="210" width="160" height="50" as="geometry" />
        </mxCell>

        <mxCell id="16" value="sp_Items_UpdateItemsPorPaciente&#xa;SET idConsulta = @idConsulta&#xa;(NO toca idEspecialidad) ✅" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#d5e8d4;strokeColor=#82b366;" vertex="1" parent="1">
          <mxGeometry x="220" y="210" width="220" height="50" as="geometry" />
        </mxCell>

        <mxCell id="17" value="TipoExamenDePaciente&#xa;idEspecialidad = SPF ✅&#xa;(correcto)" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#d5e8d4;strokeColor=#82b366;fontStyle=1;" vertex="1" parent="1">
          <mxGeometry x="470" y="210" width="180" height="50" as="geometry" />
        </mxCell>

        <!-- flechas camino 1 -->
        <mxCell id="18" edge="1" source="11" target="12" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
        <mxCell id="19" edge="1" source="12" target="13" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
        <mxCell id="20" edge="1" source="13" target="14" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
        <mxCell id="21" edge="1" source="15" target="16" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
        <mxCell id="22" edge="1" source="16" target="17" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>

        <!-- ============ BUG 1: frmModifTE ============ -->
        <mxCell id="30" value="BUG 1: frmModifTE — Modificar Tipo de Examen" style="text;html=1;strokeColor=none;fillColor=#ffe6cc;align=left;verticalAlign=middle;whiteSpace=wrap;rounded=0;fontSize=13;fontStyle=1;" vertex="1" parent="1">
          <mxGeometry x="30" y="300" width="400" height="30" as="geometry" />
        </mxCell>

        <mxCell id="31" value="Operador hace clic&#xa;'Modificar TE'&#xa;en Mesa de Entrada" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#ffe6cc;strokeColor=#d6b656;" vertex="1" parent="1">
          <mxGeometry x="30" y="340" width="160" height="60" as="geometry" />
        </mxCell>

        <mxCell id="32" value="frmModifTE.llenarComboBox()&#xa;&#xa;❌ ANTES (BUG):&#xa;SELECT * FROM Especialidad&#xa;(devuelve PADRES + HIJOS)" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#f8cecc;strokeColor=#b85450;" vertex="1" parent="1">
          <mxGeometry x="220" y="330" width="220" height="70" as="geometry" />
        </mxCell>

        <mxCell id="33" value="Operador ve en combo:&#xa;• FUERZAS ARMADAS Y DE SEGURIDAD ← PADRE ❌&#xa;• SPF&#xa;• PSA&#xa;Selecciona el PADRE sin saberlo" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#f8cecc;strokeColor=#b85450;" vertex="1" parent="1">
          <mxGeometry x="470" y="330" width="260" height="70" as="geometry" />
        </mxCell>

        <mxCell id="34" value="sp_TipoExamenDePaciente_UpdateTipo&#xa;SET idEspecialidad = PADRE ❌" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#f8cecc;strokeColor=#b85450;" vertex="1" parent="1">
          <mxGeometry x="760" y="340" width="220" height="60" as="geometry" />
        </mxCell>

        <mxCell id="35" value="✅ DESPUÉS (FIX):&#xa;SELECT Padre=0 + estado=1&#xa;Solo muestra HIJOS activos&#xa;El PADRE no aparece en la lista" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#d5e8d4;strokeColor=#82b366;" vertex="1" parent="1">
          <mxGeometry x="220" y="420" width="220" height="60" as="geometry" />
        </mxCell>

        <!-- flechas bug 1 -->
        <mxCell id="36" edge="1" source="31" target="32" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
        <mxCell id="37" edge="1" source="32" target="33" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
        <mxCell id="38" edge="1" source="33" target="34" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
        <mxCell id="39" edge="1" style="dashed=1;strokeColor=#82b366;" source="35" target="33" parent="1">
          <mxGeometry relative="1" as="geometry">
            <Array as="points"><mxPoint x="330" y="395"/><mxPoint x="600" y="395"/></Array>
          </mxGeometry>
        </mxCell>

        <!-- ============ BUG 2: Walk-in sin turno ============ -->
        <mxCell id="40" value="BUG 2: Walk-in sin turno — cbTipoDeExamen en Mesa de Entrada" style="text;html=1;strokeColor=none;fillColor=#e1d5e7;align=left;verticalAlign=middle;whiteSpace=wrap;rounded=0;fontSize=13;fontStyle=1;" vertex="1" parent="1">
          <mxGeometry x="30" y="510" width="500" height="30" as="geometry" />
        </mxCell>

        <mxCell id="41" value="Paciente sin turno&#xa;entra directo&#xa;a Mesa de Entrada" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#e1d5e7;strokeColor=#9673a6;" vertex="1" parent="1">
          <mxGeometry x="30" y="550" width="160" height="60" as="geometry" />
        </mxCell>

        <mxCell id="42" value="cargarTiposDeExamen()&#xa;&#xa;❌ ANTES (BUG):&#xa;WHERE Padre = 1&#xa;Solo devuelve CATEGORÍAS PADRE" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#f8cecc;strokeColor=#b85450;" vertex="1" parent="1">
          <mxGeometry x="220" y="540" width="220" height="70" as="geometry" />
        </mxCell>

        <mxCell id="43" value="cbTipoDeExamen muestra:&#xa;• FUERZAS ARMADAS Y DE SEGURIDAD ❌&#xa;• FÚTBOL ❌&#xa;(nunca los hijos SPF, PSA, etc.)" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#f8cecc;strokeColor=#b85450;" vertex="1" parent="1">
          <mxGeometry x="470" y="540" width="260" height="70" as="geometry" />
        </mxCell>

        <mxCell id="44" value="sp_TipoExamenDePaciente_Add&#xa;idEspecialidad = PADRE ❌" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#f8cecc;strokeColor=#b85450;" vertex="1" parent="1">
          <mxGeometry x="760" y="550" width="220" height="60" as="geometry" />
        </mxCell>

        <mxCell id="45" value="✅ DESPUÉS (FIX):&#xa;WHERE Padre = 0 AND estado = 1&#xa;Devuelve solo HIJOS activos&#xa;agrupados por padre" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#d5e8d4;strokeColor=#82b366;" vertex="1" parent="1">
          <mxGeometry x="220" y="630" width="220" height="60" as="geometry" />
        </mxCell>

        <!-- flechas bug 2 -->
        <mxCell id="46" edge="1" source="41" target="42" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
        <mxCell id="47" edge="1" source="42" target="43" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
        <mxCell id="48" edge="1" source="43" target="44" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
        <mxCell id="49" edge="1" style="dashed=1;strokeColor=#82b366;" source="45" target="43" parent="1">
          <mxGeometry relative="1" as="geometry">
            <Array as="points"><mxPoint x="330" y="610"/><mxPoint x="600" y="610"/></Array>
          </mxGeometry>
        </mxCell>

        <!-- ============ ARCHIVOS MODIFICADOS ============ -->
        <mxCell id="50" value="Archivos modificados" style="text;html=1;strokeColor=none;fillColor=none;align=left;verticalAlign=middle;whiteSpace=wrap;rounded=0;fontSize=13;fontStyle=1;" vertex="1" parent="1">
          <mxGeometry x="30" y="720" width="200" height="30" as="geometry" />
        </mxCell>

        <mxCell id="51" value="frmModifTE.cs&#xa;llenarComboBox()&#xa;Fix: Padre=0 + estado=1" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#d5e8d4;strokeColor=#82b366;" vertex="1" parent="1">
          <mxGeometry x="30" y="755" width="200" height="55" as="geometry" />
        </mxCell>

        <mxCell id="52" value="CapaDatosMepryl/TipoExamen.cs&#xa;cargarTiposDeExamen()&#xa;Fix: Padre=0 + estado=1" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#d5e8d4;strokeColor=#82b366;" vertex="1" parent="1">
          <mxGeometry x="250" y="755" width="220" height="55" as="geometry" />
        </mxCell>

      </root>
    </mxGraphModel>
  </diagram>
</mxfile>
```

---

## Resumen de bugs y fixes

### Bug 1 — `frmModifTE.cs` → `llenarComboBox()`

| | Código |
|---|---|
| ❌ Antes | `SELECT * FROM Especialidad` → incluye padres |
| ✅ Fix | `WHERE Padre = 0 AND estado = 1 AND id NOT IN EspecialidadesEliminadas` |

### Bug 2 — `CapaDatosMepryl/TipoExamen.cs` → `cargarTiposDeExamen()`

| | Código |
|---|---|
| ❌ Antes | `WHERE Padre = 1` → solo devuelve categorías padre |
| ✅ Fix | `WHERE Padre = 0 AND estado = 1` → solo devuelve hijos activos |

---

## Impacto — registros afectados existentes

| Especialidad PADRE (mal asignada) | ID | Registros afectados |
|---|---|---|
| FUTBOL | `D6A02B46-FB57-44E1-9469-6315FC8236EF` | **556** |
| FUERZAS ARMADAS Y DE SEGURIDAD | `71522E88-B387-4C46-9A60-CD608F75262C` | **10** |

### Distribución temporal de FUTBOL padre (bug activo desde feb 2026)

| Año | Mes | Cantidad |
|---|---|---|
| 2026 | Mayo | 7 |
| 2026 | Abril | 174 |
| 2026 | Marzo | 267 |
| 2026 | Febrero | 4 |

---

## Casos manuales corregidos

| Fecha | Paciente | DNI | Empresa | idTEP | Corregido a |
|---|---|---|---|---|---|
| 29/04/2026 | HOBERT, DANAE ABRIL | 41470186 | SPF | `E363ECE2-...` | SPF (`1B1A8F45-...`) |
| 29/04/2026 | LUCA, SASHA SELENE | 43252188 | PSA | `AA4434DC-...` | PSA (`D0589609-...`) |
| 04/05/2026 | AYALA, DEMIAN URIEL | 47834379 | PSA | `C015976C-...` | PSA (`D0589609-...`) |

---

## Estructura de Especialidad relevante

```
FUTBOL                           (Padre=1, id=D6A02B46-...)  ← 556 mal asignados
├── FUTBOL AFA                   (Padre=0, id=48AD474E-...)
├── FUTBOL METRO                 (Padre=0, id=60E94892-...)  ← el correcto para metros
├── FUTBOL METRO SIN LAB NI RX   (Padre=0, id=C260173E-...)
├── FUTBOL PARTICULAR            (Padre=0, id=EEBE9644-...)
├── FUTBOL PRUEBA                (Padre=0, id=A10C304E-...)
└── FUTBOL SENIOR                (Padre=0, id=167BAC87-...)

FUERZAS ARMADAS Y DE SEGURIDAD  (Padre=1, id=71522E88-...)  ← 10 mal asignados
├── SPF                          (Padre=0, id=1B1A8F45-...)
├── PSA                          (Padre=0, id=D0589609-...)
├── PFA                          (Padre=0, id=0273036F-...)
├── GNA                          (Padre=0, id=A00D5F36-...)
├── EJERCITO ARGENTINO           (Padre=0, id=12F7A952-...)
└── ...
```

---

## ⚠️ Pendiente: corrección masiva de datos históricos

Los 556 registros de FUTBOL padre existentes **no se pueden corregir automáticamente** porque no hay forma de saber si el subtipo correcto era METRO, AFA o PARTICULAR para cada uno. Requiere revisión caso por caso o criterio de negocio (ej: "si tenía liga/club X → METRO").

Script de diagnóstico para identificarlos:
```sql
SELECT tep.id, tep.idEspecialidad, c.fecha,
       pl.apellido, pl.nombres, pl.dni,
       cte.idClub, cl.descripcion as Club, l.descripcion as Liga
FROM TipoExamenDePaciente tep
JOIN Consulta c ON tep.idConsulta = c.id
LEFT JOIN PacienteLaboral pl ON c.pacienteID = pl.id
LEFT JOIN Paciente p ON c.pacienteID = p.id
LEFT JOIN clubesPorTipoExamen cte ON cte.idTipoExamen = tep.id
LEFT JOIN Club cl ON cl.id = cte.idClub
LEFT JOIN Liga l ON l.id = cl.ligaID
WHERE tep.idEspecialidad = 'D6A02B46-FB57-44E1-9469-6315FC8236EF'
ORDER BY c.fecha DESC
```
