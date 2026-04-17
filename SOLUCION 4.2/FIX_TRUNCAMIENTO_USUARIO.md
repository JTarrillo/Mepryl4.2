# Fix: Error "Los datos de cadena o binarios se truncarían"
## frmPacienteLaboral.cs → dbo.Usuario
**Fecha:** Abril 2026

---

## Síntoma
Al guardar un paciente laboral en `frmPacienteLaboral.cs`, aparecía el error SQL:
> "Los datos de cadena o binarios se truncarían"

## Flujo de guardado
```
frmPacienteLaboral.cs
  └─ guardarFicha()
       ├─ nuevoPaciente()          (nuevo paciente)
       └─ guardarPacienteEditado() (edición)
            └─ GuardaActualizaPaciente()
                 └─ cargarDatosUsuarios()  → Carga entidad UsuarioSistema
                      └─ ¿Usuario existe en dbo.Usuario?
                           ├─ NO → GuardarUsuario(entidad)   → INSERT INTO dbo.Usuario
                           └─ SÍ → ActualizarUsuario(entidad) → UPDATE dbo.Usuario
```

---

## Causa raíz
En `CapaDatosMepryl/UsuarioSistema.cs`, los métodos `GuardarUsuario(entidad)` y `ActualizarUsuario(entidad)` tenían 3 problemas:

### Fix 1: Booleanos 'True'/'False' → 1/0 (causa principal)
Las columnas BIT de la tabla `dbo.Usuario` recibían `'True'`/`'False'` (texto) en vez de `1`/`0`.
SQL Server intentaba meter el string "True"/"False" en columnas BIT, generando el error de truncamiento.

```csharp
// ANTES (rompía) ❌
VentConfiguracion = '" + entidad.VentConfiguracion + @"'

// DESPUÉS (correcto) ✅
VentConfiguracion = " + (entidad.VentConfiguracion ? "1" : "0")
```

**12 columnas BIT afectadas:**
VentConfiguracion, VentExamenes, VentMesa, VentPacientes, VentVentanilla, VentResumen,
PermisoVer, PermisoModificar, PermisoEliminar, VentTurnos, Activo, VentAudiometria

### Fix 2: Guid.Empty → NULL
Cuando no hay profesional asignado, se enviaba `'00000000-0000-0000-0000-000000000000'` en vez de `NULL`.

```csharp
// ANTES ❌
ProfesionalAsignado = '" + entidad.ProfesionalAsignado + @"'

// DESPUÉS ✅
string strProfAsig = entidad.ProfesionalAsignado == Guid.Empty
    ? "NULL"
    : "'" + entidad.ProfesionalAsignado.ToString() + "'";
```

### Fix 3: Null check + protección Tipo
En `frmPacienteLaboral.cs`, `cargarDatosUsuarios()` hacía `dt.Rows.Count > 0` sin verificar `dt != null`.

```csharp
// ANTES ❌
if (dt.Rows.Count > 0)

// DESPUÉS ✅
if (dt != null && dt.Rows.Count > 0)
```
Además se agregó protección de largo: `Tipo.Length <= 20` chars (varchar(20) en BD).

---

## Archivos modificados
| Archivo | Cambios |
|---------|---------|
| `CapaDatosMepryl/UsuarioSistema.cs` | GuardarUsuario(entidad) y ActualizarUsuario(entidad): booleans 1/0, GUID null, escape de comillas simples |
| `CapaPresentacion/frmPacienteLaboral.cs` | cargarDatosUsuarios(): null check en dt, protección de largo en Tipo |
| `LibreriasBase/Comunes/SQLConnector.cs` | Diagnósticos [DIAG] en catch blocks |

## Nota
Los overloads `GuardarUsuario(List<object>)` y `ActualizarUsuario(string, List<object>)` en UsuarioSistema.cs
todavía usan `'True'`/`'False'` para booleans. No se tocaron porque no son llamados desde frmPacienteLaboral,
pero podrían fallar si se usan desde otro formulario.

## Diagnósticos activos (Debug.WriteLine)
- `cargarDatosUsuarios()` en frmPacienteLaboral.cs (Tipo INICIAL, ENTRO AL IF, Tipo FINAL)
- `GuardarUsuario(entidad)` y `ActualizarUsuario(entidad)` en UsuarioSistema.cs (todos los campos)
- `SQLConnector.cs` — [DIAG] en los catch blocks mostrando SQL/SP que falló

---

## Diagrama draw.io
Para importar en [app.diagrams.net](https://app.diagrams.net): **Extras** > **Editar diagrama** > pegar el XML:

```xml
<mxGraphModel>
  <root>
    <mxCell id="0"/>
    <mxCell id="1" parent="0"/>
    <mxCell id="2" value="&lt;b&gt;FIX: Error &quot;Los datos de cadena o binarios se truncarían&quot;&lt;/b&gt;&lt;br&gt;frmPacienteLaboral.cs → dbo.Usuario" style="text;html=1;align=center;fontSize=16;fillColor=#ff6b6b;fontColor=#ffffff;rounded=1;whiteSpace=wrap;strokeColor=#c92a2a;" vertex="1" parent="1">
      <mxGeometry x="160" y="10" width="480" height="50" as="geometry"/>
    </mxCell>
    <mxCell id="10" value="frmPacienteLaboral.cs&lt;br&gt;&lt;b&gt;guardarFicha()&lt;/b&gt;" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#dae8fc;strokeColor=#6c8ebf;" vertex="1" parent="1">
      <mxGeometry x="300" y="80" width="200" height="40" as="geometry"/>
    </mxCell>
    <mxCell id="11" value="nuevoPaciente() / guardarPacienteEditado()" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#dae8fc;strokeColor=#6c8ebf;" vertex="1" parent="1">
      <mxGeometry x="280" y="140" width="240" height="40" as="geometry"/>
    </mxCell>
    <mxCell id="12" value="&lt;b&gt;GuardaActualizaPaciente()&lt;/b&gt;" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#dae8fc;strokeColor=#6c8ebf;" vertex="1" parent="1">
      <mxGeometry x="300" y="200" width="200" height="40" as="geometry"/>
    </mxCell>
    <mxCell id="13" value="&lt;b&gt;cargarDatosUsuarios()&lt;/b&gt;&lt;br&gt;Carga entidad UsuarioSistema" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#fff2cc;strokeColor=#d6b656;" vertex="1" parent="1">
      <mxGeometry x="280" y="260" width="240" height="45" as="geometry"/>
    </mxCell>
    <mxCell id="14" value="¿Usuario existe&lt;br&gt;en dbo.Usuario?" style="rhombus;whiteSpace=wrap;html=1;fillColor=#fff2cc;strokeColor=#d6b656;" vertex="1" parent="1">
      <mxGeometry x="330" y="330" width="140" height="70" as="geometry"/>
    </mxCell>
    <mxCell id="15" value="&lt;b&gt;GuardarUsuario(entidad)&lt;/b&gt;&lt;br&gt;INSERT INTO dbo.Usuario" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#e1d5e7;strokeColor=#9673a6;" vertex="1" parent="1">
      <mxGeometry x="130" y="430" width="220" height="45" as="geometry"/>
    </mxCell>
    <mxCell id="16" value="&lt;b&gt;ActualizarUsuario(entidad)&lt;/b&gt;&lt;br&gt;UPDATE dbo.Usuario" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#e1d5e7;strokeColor=#9673a6;" vertex="1" parent="1">
      <mxGeometry x="450" y="430" width="220" height="45" as="geometry"/>
    </mxCell>
    <mxCell id="17" value="&lt;b&gt;SQL Server&lt;/b&gt;&lt;br&gt;dbo.Usuario" style="shape=cylinder3;whiteSpace=wrap;html=1;boundedLbl=1;backgroundOutline=1;size=4;fillColor=#f8cecc;strokeColor=#b85450;" vertex="1" parent="1">
      <mxGeometry x="345" y="510" width="110" height="50" as="geometry"/>
    </mxCell>
    <mxCell id="20" edge="1" source="10" target="11" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
    <mxCell id="21" edge="1" source="11" target="12" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
    <mxCell id="22" edge="1" source="12" target="13" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
    <mxCell id="23" edge="1" source="13" target="14" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
    <mxCell id="24" value="No" edge="1" source="14" target="15" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
    <mxCell id="25" value="Sí" edge="1" source="14" target="16" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
    <mxCell id="26" edge="1" source="15" target="17" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
    <mxCell id="27" edge="1" source="16" target="17" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
    <mxCell id="30" value="&lt;b&gt;🔧 Fix 1: Booleanos 'True'/'False' → 1/0&lt;/b&gt;&lt;br&gt;&lt;br&gt;ANTES: VentConfiguracion = 'True' ❌&lt;br&gt;DESPUÉS: VentConfiguracion = 1 ✅&lt;br&gt;&lt;br&gt;&lt;i&gt;12 columnas BIT afectadas:&lt;/i&gt;&lt;br&gt;VentConfiguracion, VentExamenes, VentMesa,&lt;br&gt;VentPacientes, VentVentanilla, VentResumen,&lt;br&gt;PermisoVer, PermisoModificar, PermisoEliminar,&lt;br&gt;VentTurnos, Activo, VentAudiometria" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#d5e8d4;strokeColor=#82b366;align=left;spacingLeft=10;" vertex="1" parent="1">
      <mxGeometry x="10" y="590" width="310" height="170" as="geometry"/>
    </mxCell>
    <mxCell id="31" value="&lt;b&gt;🔧 Fix 2: Guid.Empty → NULL&lt;/b&gt;&lt;br&gt;&lt;br&gt;ANTES:&lt;br&gt;ProfesionalAsignado = '0000...0000' ❌&lt;br&gt;&lt;br&gt;DESPUÉS:&lt;br&gt;ProfesionalAsignado = NULL ✅&lt;br&gt;(cuando no hay profesional)" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#d5e8d4;strokeColor=#82b366;align=left;spacingLeft=10;" vertex="1" parent="1">
      <mxGeometry x="340" y="590" width="280" height="130" as="geometry"/>
    </mxCell>
    <mxCell id="32" value="&lt;b&gt;🔧 Fix 3: Null check + protección Tipo&lt;/b&gt;&lt;br&gt;&lt;br&gt;ANTES: if (dt.Rows.Count &gt; 0) ❌&lt;br&gt;DESPUÉS: if (dt != null &amp;&amp; ...) ✅&lt;br&gt;+ Tipo.Length &lt;= 20 chars" style="rounded=1;whiteSpace=wrap;html=1;fillColor=#d5e8d4;strokeColor=#82b366;align=left;spacingLeft=10;" vertex="1" parent="1">
      <mxGeometry x="340" y="730" width="280" height="100" as="geometry"/>
    </mxCell>
    <mxCell id="35" style="dashed=1;strokeColor=#b85450;" edge="1" source="17" target="30" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
    <mxCell id="36" style="dashed=1;strokeColor=#b85450;" edge="1" source="17" target="31" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
    <mxCell id="37" style="dashed=1;strokeColor=#d6b656;" edge="1" source="13" target="32" parent="1"><mxGeometry relative="1" as="geometry"/></mxCell>
    <mxCell id="40" value="&lt;b&gt;Archivos modificados:&lt;/b&gt;&lt;br&gt;• CapaDatosMepryl/UsuarioSistema.cs&lt;br&gt;• CapaPresentacion/frmPacienteLaboral.cs&lt;br&gt;• LibreriasBase/Comunes/SQLConnector.cs" style="text;html=1;align=left;fillColor=#f5f5f5;strokeColor=#666666;fontColor=#333333;rounded=1;spacingLeft=10;" vertex="1" parent="1">
      <mxGeometry x="10" y="780" width="300" height="70" as="geometry"/>
    </mxCell>
  </root>
</mxGraphModel>
```
