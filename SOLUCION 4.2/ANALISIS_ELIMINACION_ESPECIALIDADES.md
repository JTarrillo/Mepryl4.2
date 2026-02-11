# Análisis: Problema de Eliminación de Especialidades (TipoExamen/Subtipos)

## Problema Identificado

El usuario reporta que **no puede eliminar elementos Padre=1 (TipoExamen) ni Padre=0 (Subtipo)** desde el formulario `FrmAñadirEspecialidad`.

## Causa Raíz

### 1. Método `eliminarTipoExamen` sin validaciones (CapaDatos - Línea 632)
```csharp
// ANTES: Método antiguo SIN validaciones correctas
public Entidades.Resultado eliminarTipoExamen(string idTipoExamen)
{
    // ❌ NO valida que sea Padre=1
    // ❌ NO verifica subtipos asociados
    // ❌ Solo verifica TipoExamenDePaciente
    // Solo elimina de forma general
}
```

### 2. Método correcto `eliminarTipoExamenPadre` (CapaDatos - Línea 1257)
```csharp
// CORRECTO: Método nuevo CON validaciones completas
public Entidades.Resultado eliminarTipoExamenPadre(string idTipoExamen)
{
    // ✅ Valida que sea Padre=1
    // ✅ Verifica que NO tenga subtipos asociados
    // ✅ Verifica consultas/turnos
    // ✅ Limpia EstudiosPorTipoExamen, Clubes, Empresas
    // ✅ Luego elimina de forma segura
}
```

## Duplicación de Métodos

Había **dos métodos diferentes** con propósitos similares:

| Método | Línea | Validaciones | Estado |
|--------|-------|--------------|--------|
| `eliminarTipoExamen` | 632 | ❌ Incompletas | VIEJO (sin mantener) |
| `eliminarTipoExamenPadre` | 1257 | ✅ Completas | NUEVO (correcto) |
| `eliminarSubtipo` | 1364 | ✅ Completas | CORRECTO |

## Solución Implementada

### Cambio en CapaDatosMepryl/TipoExamen.cs (Línea 632)

**ANTES:**
```csharp
public Entidades.Resultado eliminarTipoExamen(string idTipoExamen)
{
    // Código incompleto sin validaciones
    try { /* eliminación simple */ }
    catch { /* manejo de errores genérico */ }
}
```

**DESPUÉS:**
```csharp
public Entidades.Resultado eliminarTipoExamen(string idTipoExamen)
{
    // DELEGADO a eliminarTipoExamenPadre para mantener validaciones consistentes
    // Este método es mantenido por compatibilidad hacia atrás
    return eliminarTipoExamenPadre(idTipoExamen);
}
```

## Flujo Correcto de Eliminación

### Eliminación de TipoExamen (Padre=1):
1. Validar que existe (SELECT COUNT)
2. **Validar que sea Padre=1** ← ✅ Ahora funciona
3. Validar que NO tenga subtipos (WHERE IdPadre = @id AND Padre=0)
4. Validar que NO tenga consultas/turnos (TipoExamenDePaciente)
5. Limpiar EstudiosPorTipoExamen (sp_EstudiosPorTipoExamen_Delete)
6. Limpiar Clubes y Empresas
7. Eliminar (sp_Especialidad_DeleteRapido)

### Eliminación de Subtipo (Padre=0):
1. Validar que existe
2. **Validar que sea Padre=0** ← ✅ Correcto
3. Limpiar TipoExamenDePaciente
4. Limpiar EstudiosPorTipoExamen
5. Limpiar Clubes y Empresas
6. Eliminar (sp_Especialidad_DeleteRapido)

## Métodos Disponibles en CapaNegocioMepryl

```csharp
// Eliminación con GUID (recomendado en UI)
public Entidades.Resultado EliminarTipoExamen(Guid idTipoExamen)
{
    return tipoExamen.eliminarTipoExamenPadre(idTipoExamen.ToString());
}

// Eliminación de Subtipo con GUID (recomendado en UI)
public Entidades.Resultado EliminarSubtipoExamen(Guid idSubtipo)
{
    return tipoExamen.eliminarSubtipo(idSubtipo.ToString());
}
```

Estos métodos son los que se llaman desde `FrmAñadirEspecialidad` y ahora funcionarán correctamente.

## Pruebas Recomendadas

1. **Eliminar un TipoExamen SIN subtipos:**
   - Debe mostrar mensaje de éxito
   - Debe eliminar EstudiosPorTipoExamen asociados

2. **Intentar eliminar un TipoExamen CON subtipos:**
   - Debe mostrar error: "No se puede eliminar... tiene Subtipos asociados"
   - NO debe eliminar nada

3. **Intentar eliminar un TipoExamen con consultas/turnos:**
   - Debe mostrar error: "...tiene consultas y/o turnos asignados"
   - NO debe eliminar nada

4. **Eliminar un Subtipo (Padre=0):**
   - Debe mostrar mensaje de éxito
   - Debe eliminar también si tiene TipoExamenDePaciente

5. **Intentar eliminar un elemento Padre=1 como si fuera Subtipo:**
   - Debe mostrar error claramente indicando que es un PADRE
   - NO debe eliminarse

## Archivos Modificados

- ✅ `CapaDatosMepryl/TipoExamen.cs` - Línea 632: Método `eliminarTipoExamen` actualizado

## Nota Importante

Los métodos `eliminarTipoExamenPadre` y `eliminarSubtipo` en la capa de datos YA tenían la lógica correcta desde hace tiempo. El problema era que el método viejo `eliminarTipoExamen` seguía siendo usado y NO tenía las validaciones apropiadas.

Ahora `eliminarTipoExamen` simplemente delegado a `eliminarTipoExamenPadre`, asegurando que siempre se use la lógica correcta y completa.
