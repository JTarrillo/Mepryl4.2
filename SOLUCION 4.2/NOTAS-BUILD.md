## Resumen (qué pasó)

El problema fue una mezcla de dos cosas:

1) Había referencias a DLLs “por ruta absoluta / de otra solución” (por ejemplo `SOLUCION 3.10` y/o `Program Files\DevExpress ...`). En Debug a veces “zafa” porque Visual Studio resuelve DLLs desde binarios ya generados o desde el mismo output de otros proyectos, pero en Release queda más estricto y termina fallando con errores de tipos no encontrados.

2) Algunas DLLs/paquetes no estaban realmente dentro del repositorio (o estaban referenciadas con `HintPath` que apuntaba a una carpeta que no existe en esta máquina). Resultado: en Release no se podían resolver namespaces como `DevExpress...`, `Microsoft.Reporting...` o `WindowsInput`.

Además, apareció un error de “archivo bloqueado” en `obj\\Release\\*.resources`, que normalmente ocurre cuando hay un proceso (VS/MSBuild/antivirus) usando el archivo.

## Qué se hizo para arreglarlo

### 1) Error de código: `Turno.importeLista`

- Se agregó el campo faltante `importeLista` en la entidad de datos.
- Archivo: [Turno.cs](file:///c:/Mepryl4.2/SOLUCION%204.2/MEPRYL/CapaDatos/Turno.cs)

### 2) “No se encontró el archivo de metadatos …\\bin\\Debug\\*.dll”

- Se detectaron referencias incorrectas a DLLs de otra solución (por ejemplo `SOLUCION 3.10`) dentro de proyectos.
- Se eliminaron auto-referencias / referencias rotas para que los proyectos compilen y generen sus DLLs.
- Archivos (ejemplos): proyectos de CapaDatos, CapaNegocio, UserControls.

### 3) Release fallaba por referencias (DevExpress / ReportViewer / WindowsInput)

Para estabilizar el build (sobre todo Release), se hizo esto:

- Se centralizaron DLLs en una carpeta del repo: `MEPRYL\\Lib`.
- Se ajustó la resolución de referencias agregando `ReferencePath` y `HintPath` hacia `..\\Lib\\...` cuando correspondía.
- Se corrigieron referencias que apuntaban a `SOLUCION 3.10` y a rutas de `Program Files` que no existían en esta máquina.
- Se quitó `using WindowsInput;` donde no se usaba, porque la DLL no estaba presente y rompía el build.
- Se agregaron `HintPath` para `Microsoft.ReportViewer.*` para asegurar que el `using Microsoft.Reporting.WinForms;` compile en Release.

Archivos tocados (principales):

- [CapaPresentacion.csproj](file:///c:/Mepryl4.2/SOLUCION%204.2/MEPRYL/CapaPresentacion/CapaPresentacion.csproj)
- [Administracion.csproj](file:///c:/Mepryl4.2/SOLUCION%204.2/MEPRYL/Administracion/Administracion.csproj)
- [CapaNegocioMepryl.csproj](file:///c:/Mepryl4.2/SOLUCION%204.2/MEPRYL/CapaNegocioMepryl/CapaNegocioMepryl.csproj)
- [CapaPresentacionBase.csproj](file:///c:/Mepryl4.2/SOLUCION%204.2/LibreriasBase/CapaPresentacionBase/CapaPresentacionBase.csproj)
- [frmPaciente.cs](file:///c:/Mepryl4.2/SOLUCION%204.2/MEPRYL/CapaPresentacion/frmPaciente.cs)

## Si vuelve a pasar (checklist rápido)

1) Si el error es “No se encontró el archivo de metadatos …\\*.dll”:
- Es porque el proyecto referenciado NO compiló. Arrancá por el primer error real en la lista.

2) Si Release falla y Debug no:
- Revisar `HintPath` y `ReferencePath` (Release suele exponer rutas rotas).
- Buscar referencias a rutas viejas (`SOLUCION 3.10`, `Downloads`, `Program Files` que no existan).

3) Si sale “El proceso no puede obtener acceso al archivo …\\obj\\Release\\*.resources”:
- Cerrar formularios/diseñadores abiertos.
- `Clean` + `Rebuild`.
- Si persiste: cerrar VS y borrar `bin\\` y `obj\\` del proyecto afectado.

