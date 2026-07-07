# [OPEN] Debug Session: copiar-info-turno-movido

## Contexto
- Sintoma: `Copiar Info` muestra `Sin plantilla` despues de mover un turno.
- Alcance observado: ocurre especialmente luego de mover turno y luego buscar por DNI/nombre.
- Ejemplo reportado: DNI `53612547`.

## Hipotesis
1. `Copiar Info` toma un `IdSubtipo` distinto al subtipo mostrado en el panel.
2. La grilla filtrada por DNI/nombre reconstruye el subtipo desde `Horario` y no desde `TipoExamenDePaciente`.
3. El `IdSubtipo` es correcto, pero no existe plantilla configurada para ese subtipo exacto.
4. Despues del movimiento la fila actual o la columna oculta `IdSubtipo` no corresponden a la fila visible.
5. El bug solo aparece en la ruta de turnos movidos porque ahi divergen `Horario.Especialidad` y `TipoExamenDePaciente.idEspecialidad`.

## Plan
1. Instrumentar `btnCopiarInfo_Click` / `reemplazarTexto()` para registrar fila, subtipo visible e `IdSubtipo`.
2. Instrumentar la carga de la grilla de busqueda por DNI/nombre para registrar `SubTipo` e `IdSubtipo`.
3. Reproducir con un turno movido y comparar panel vs grilla vs `IdSubtipo`.
4. Confirmar o descartar hipotesis antes de tocar la logica.

## Evidencia
- Consulta BD en `MEPRYLv2.1`, `1julio` y `2julio`:
  - Existe plantilla configurada para `FUTBOL METRO` con `IdSubtipo = 60e94892-6f59-4202-a966-884fd71a5d8b`.
  - El turno del paciente `57182161` (`codigo 637456`, `21/07/2026 09:00`) en `MEPRYLv2.1` quedo con `TipoExamenDePaciente.idEspecialidad = d6a02b46-fb57-44e1-9469-6315fc8236ef`, descripcion `FUTBOL`.
  - Para ese mismo turno, `Horario.especialidadID = 60e94892-6f59-4202-a966-884fd71a5d8b`, descripcion `FUTBOL METRO`.
  - Conclusion preliminar: al mover/asignar ese turno se desincronizo `TipoExamenDePaciente.idEspecialidad` respecto del subtipo real del horario; por eso `Copiar Info` puede terminar buscando plantilla con el id padre `FUTBOL`, no con `FUTBOL METRO`.
  - Verificacion post-fix reportada por usuario:
    - Ya no aparece `Sin plantilla`.
    - Se genero el mensaje completo para `TALAMONA PEDRO MARTIN` con plantilla de `FUTBOL METRO`.
    - Persisten `WebException/SocketException` del POST de instrumentacion y excepciones de `Clipboard`, pero no bloquean la generacion del texto.

## Fix aplicado
- En `CapaDatosMepryl/Turno.cs`, `MoverTurno(...)` ahora resuelve `idEspecialidadDestino` directamente desde `Horario.especialidadID` del turno destino.
- El `UPDATE dbo.TipoExamenDePaciente` usa ese `idEspecialidadDestino` final, no el valor entrante de UI como fuente de verdad.
- Esto asegura sincronizacion entre turno destino y subtipo persistido, evitando que `Copiar Info` busque la plantilla del padre.

## Estado de hipotesis
- H1 `Copiar Info` toma un `IdSubtipo` distinto al subtipo mostrado en el panel`: RECHAZADA como causa principal.
- H2 `La grilla filtrada reconstruye el subtipo desde Horario y no desde TipoExamenDePaciente`: CONTRIBUYENTE, pero no explicaba el caso puntual de `FUTBOL METRO`.
- H3 `No existe plantilla para el subtipo exacto`: RECHAZADA. La plantilla de `FUTBOL METRO` existe en BD.
- H4 `La fila/celda actual cambia tras mover`: INCONCLUSIVA.
- H5 `Al mover, TipoExamenDePaciente.idEspecialidad queda desincronizado respecto del horario destino`: CONFIRMADA.
