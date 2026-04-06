# Diagnóstico: frmUsuariosSistema

## Contexto
Módulo de gestión de usuarios del sistema. Tiene dos grillas:
- `dgv` — grilla del buscador (activa, la que usa el usuario)
- `dgwDatos` — grilla legacy (oculta, sin sincronización activa)

---

## Bug corregido: CargarPermisos usaba la grilla incorrecta

**Archivo:** `MEPRYL/CapaPresentacion/frmUsuariosSistema.cs`  
**Método:** `CargarPermisos()`  
**Commit:** posterior al feat de VentFacturacion

### Síntoma
Al seleccionar un usuario desde el buscador (`dgv`), el checkbox `chkverfacturacion` (y potencialmente otros permisos) no reflejaba el valor real de la BD — quedaba en el valor por defecto del tipo de usuario.

### Causa
`CargarPermisos` llamaba a `ListaPermisoUsuarios` usando el ID de `dgwDatos.CurrentCell`, que no estaba sincronizado con la selección del buscador. Esto generaba una `NullReferenceException` silenciosa (capturada por el `catch` vacío), dejando los checkboxes en los valores que había dejado `CargarPermisosDefecto`.

### Fix aplicado
```csharp
// ANTES (incorrecto):
dt = UserSistema.ListaPermisoUsuarios(dgwDatos.Rows[dgwDatos.CurrentCell.RowIndex].Cells[0].Value.ToString());

// DESPUÉS (correcto):
dt = UserSistema.ListaPermisoUsuarios(dgv.Rows[intFilaSelecc].Cells[0].Value.ToString());
```

---

## Feature: visibilidad ícono Facturación por permiso de usuario

**Commit:** `e741e85` — `feat: control de visibilidad icono Facturacion por perfil de usuario`

### Archivos modificados
| Archivo | Cambio |
|---|---|
| `Entidades/UsuarioSistema.cs` | Propiedad `VentFacturacion` |
| `CapaDatosMepryl/UsuarioSistema.cs` | INSERT/UPDATE incluyen `VentFacturacion` |
| `LibreriasBase/Comunes/UsuarioDatos.cs` | `blnLista[11]` = `dt.Rows[0][27]` (VentFacturacion) |
| `LibreriasBase/CapaPresentacionBase/frmBasePrincipal.cs` | `MostrarVentanas()` oculta/muestra `facturacionToolStripMenuItem` y `toolStripMenuItem23` |
| `CapaPresentacion/frmUsuariosSistema.cs` | `chkverfacturacion` cableado en todos los métodos |
| `PROCEDIMIENTOS_SQL/Add_VentFacturacion_Usuario.sql` | Migración idempotente para `dbo.Usuario` y `dbo.UsuarioTipo` |

### Índice blnLista
| blnLista[n] | Columna DB | Índice ordinal |
|---|---|---|
| [0] | VentConfiguracion | 13 |
| [1] | VentExamenes | 14 |
| [2] | VentMesa | 15 |
| [3] | VentPacientes | 16 |
| [4] | VentVentanilla | 17 |
| [5] | VentResumen | 18 |
| [6] | PermisoVer | 19 |
| [7] | PermisoModificar | 20 |
| [8] | PermisoEliminar | 21 |
| [9] | VentTurnos | 22 |
| [10] | VentAudiometria | 24 |
| [11] | VentFacturacion | 27 |

### Actualización en tiempo real
En `botAceptar_Click`, si el usuario editado es el usuario logueado actualmente, se llama `frmPadre.PermisosUsuario()` para refrescar la visibilidad sin necesidad de cerrar sesión.

---

## Problemas conocidos pendientes

### 1. `AccesoAdministrador`, `AccesoOperador`, `AccesoTecnico` — métodos muertos
Existen pero nunca se invocan. Los permisos por defecto se cargan desde `CargarPermisosDefecto()` que lee `dbo.UsuarioTipo`. Estos métodos pueden eliminarse.

### 2. `chkActivo` dispara en carga
El evento `chkActivo_CheckedChanged` ejecuta un UPDATE en la BD cuando se carga el formulario (antes de que el usuario interactúe). Puede causar escrituras innecesarias.

### 3. `dgwDatos` — grilla duplicada sin uso real
`dgwDatos` existe desde la versión original pero el flujo real usa `dgv` (buscador). `dgwDatos` solo se usa en `dgwDatos_CellDoubleClick` para asignar profesional. Candidata a eliminar en una refactorización futura.

### 4. `catch (NullReferenceException)` vacíos
Hay varios catch silenciosos que ocultan errores. El bug de `CargarPermisos` fue uno de ellos. Revisar y al menos loguear.
