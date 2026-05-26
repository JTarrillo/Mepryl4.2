# Documentación: Corrección de placeholder `<<Fecha>>` en reportes Word

Resumen
- Objetivo: Resolver el problema de que el placeholder `<<Fecha>>` no se reemplazaba en algunos protocolos de laboratorio (aparecía como `<<Fecha>>` en PDF final).
- Resultado: Se añadió búsqueda y reemplazo en encabezados/pies y un fallback que colapsa runs por párrafo para garantizar reemplazo incluso si el marcador estaba dividido en múltiples runs. Se agregó logging temporal para diagnóstico.

Archivos modificados
- `CapaNegocioMepryl/ReporteWord.cs`
  - Función modificada: `ReemplazarTexto(Document doc, string textoOriginal, string textoReemplazo)`
  - Cambios principales:
    - Si el reemplazo normal no encuentra la etiqueta, ahora también intenta reemplazar en `Headers` y `Footers` de todas las `Section`.
    - Añadido un fallback "agresivo": combina el texto de todos los `runs` de cada `Paragraph`, realiza el reemplazo y vuelve a insertar el párrafo reemplazado (esto cubre casos donde el marcador está partido entre varios `TextRange`).
    - Logging temporal: escribe eventos en `%TEMP%\\mepryl_reemplazo.log` para registrar reemplazos realizados por el fallback.

- `CapaNegocioMepryl/ReporteWordSpire.cs`
  - Función modificada: `ReemplazarTexto(string textoOriginal, string textoReemplazo)`
  - Cambios principales:
    - Igual que en `ReporteWord.cs`: búsqueda en headers/footers y fallback que colapsa runs por párrafo.
    - Logging temporal en `%TEMP%\\mepryl_reemplazo_spire.log`.

Qué hacía el código antes
- Se usaba `doc.FindAllString(...).GetAsOneRange().Text = textoReemplazo` y `doc.Replace(...)`.
- Estos mecanismos fallaban cuando Word dividía el marcador (por ejemplo `<<Fe` `cha>>`) en varios runs, o cuando el marcador estaba en el encabezado.

Posible causa del fallo
- El reporte funcionaba antes porque el texto del marcador estaba en un solo bloque de texto.
- Después de editar la plantilla, Word pudo haber partido `<<Fecha>>` en varios `TextRange` internos o colocado el marcador dentro del encabezado.
- En ese caso, el código anterior no encontraba la etiqueta completa y la dejaba sin reemplazar.
- No es necesariamente un error de los datos ni del valor de la fecha; es una falla de la lógica de reemplazo de plantillas dentro de Word.

Por qué funciona ahora
- Al buscar también en headers/footers y al reconstruir el texto de párrafos (colapsando runs) garantizamos que el texto lógico contenga la etiqueta y pueda ser reemplazado aun si Word la fragmentó en varios objetos internos.

Archivos de log
- `%TEMP%\mepryl_reemplazo.log` — reemplazos realizados por `ReporteWord.cs` (Word).
- `%TEMP%\mepryl_reemplazo_spire.log` — reemplazos realizados por `ReporteWordSpire.cs` (Spire).

Cómo probar (pasos)
1. Abrir la aplicación y generar/exportar el protocolo problemático desde la UI (la misma acción que mostraba `<<Fecha>>`).
2. Verificar el PDF resultante: el placeholder `<<Fecha>>` debe aparecer con la fecha (p. ej. `20-05-2026`).
3. Si querés confirmar internamente, abrir los logs temporales en `%TEMP%`.

Comandos útiles (PowerShell)
- Abrir log Word:

```powershell
notepad $env:TEMP\\mepryl_reemplazo.log
```

- Abrir log Spire:

```powershell
notepad $env:TEMP\\mepryl_reemplazo_spire.log
```

Cómo revertir o limpiar (opcional)
- Para eliminar los logs temporales manualmente:

```powershell
Remove-Item $env:TEMP\\mepryl_reemplazo.log -ErrorAction SilentlyContinue
Remove-Item $env:TEMP\\mepryl_reemplazo_spire.log -ErrorAction SilentlyContinue
```

- Si querés deshacer el fallback agresivo y dejar solo la corrección en headers/footers, puedo aplicar un parche que elimine la sección que colapsa runs y solo deje la búsqueda en headers/footers.

Próximos pasos recomendados
- Si confirmás que ya está solucionado, puedo:
  - eliminar los logs y el fallback agresivo (limpieza), o
  - mantener los logs activos por un periodo corto para monitorizar (recomendado 1-2 días), o
  - extender la misma corrección a otras plantillas/reportes si existe riesgo de comportamiento similar.

Notas técnicas y riesgos
- El fallback que colapsa runs reemplaza el contenido del párrafo completo. En textos con formatos complejos o campos embebidos en el mismo párrafo, puede alterar formateos muy finos (por ejemplo diferentes estilos dentro del mismo párrafo). Hasta ahora no se detectaron efectos adversos en la plantilla de laboratorio que probaste, pero es algo a tener en cuenta.
- Si necesitás una solución "100% segura" que preserve formato run-por-run, se puede implementar una función que reensamble runs conservando formato y reemplazando únicamente los runs necesarios; eso es más complejo y puedo implementarlo si lo preferís.

Registro de cambios (resumen de commits aplicados)
- Cambios aplicados manualmente con `apply_patch` en:
  - `CapaNegocioMepryl/ReporteWord.cs`
  - `CapaNegocioMepryl/ReporteWordSpire.cs`

Contacto
- Si querés que haga la limpieza o implemente una versión que preserve run-styling, decime cuál prefieres y lo implemento.

---
Documento generado automáticamente con resumen de la intervención para la corrección del placeholder `<<Fecha>>`.
