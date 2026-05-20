# Flujo: Ventanilla (frmRecepcion) → Mesa de Entrada (frmMesaDeEntrada)

## Resumen

La **Recepción (Ventanilla)** es la primera pantalla que ve el paciente al llegar a la clínica.  
Su función es **confirmar la presencia** del paciente y **enviarlo** a Mesa de Entrada.  
Mesa de Entrada lo procesa, le asigna número de orden y crea el expediente médico (Consulta).

---

## Campos clave en la tabla `Turno`

| Campo            | Valor | Significado                                      |
|------------------|-------|--------------------------------------------------|
| `recepcion`      | `0`   | Turno pendiente — visible en Ventanilla          |
| `recepcion`      | `1`   | Turno recibido — visible en Mesa de Entrada      |
| `mesaDeEntrada`  | `0`   | Todavía no procesado en Mesa de Entrada          |
| `mesaDeEntrada`  | `1`   | Ya procesado — tiene Consulta creada             |
| `asistio`        | `1`   | El paciente marcó asistencia en Ventanilla       |
| `reservado`      | `1`   | Turno reservado (sin paciente asignado aún)      |
| `ocultar`        | `1`   | Turno oculto de la vista normal                  |

---

## Paso a paso del flujo

### 1. El paciente llega — `frmRecepcion` (Ventanilla)

**Archivo:** `CapaPresentacion/frmRecepcion.cs`  
**Capa de datos:** `CapaDatosMepryl/Ventanilla.cs`

La grilla `dgv` carga todos los turnos del día con:
```sql
WHERE (t.recepcion = '0' OR t.recepcion IS NULL)
  AND t.habilitado = '1'
```

El operador puede:
- **Marcar asistencia** (columna 0 — checkbox `asistio`) → `actualizarPresente()`
- **Marcar abono** (columna 1 — checkbox `abono`) → `actualizarAbono()`
- **Ocultar turno** (columna 17) → `actualizarOcultar()`
- **Editar paciente** → `botEditarPaciente` (abre `frmPaciente` o `frmPacienteLaboral`)
- **Editar examen** → `botEditarExamen` (abre `frmTipoExamen`)

---

### 2. El operador hace clic en "Registrar" — `registrar()`

```
botonRegistrar_Click()
    └── registrar()
         ├── Si NO es reservado → abre frmAvisoExamenModificado
         │       └── (callback) registrarIngreso()
         │               └── ventanilla.registrarIngreso(idTurno)
         │                       └── sp_Turno_CambiarEstadoRecepcion(@id, '1')
         │                               → Turno.recepcion = 1
         │
         └── Si ES reservado → pregunta si cargar datos del paciente
                 └── Si No + tiene asistencia → registrarIngreso() directamente
```

**Resultado en BD:**
```sql
-- sp_Turno_CambiarEstadoRecepcion
UPDATE Turno SET recepcion = '1' WHERE id = @id
```

El turno **desaparece de Ventanilla** y **aparece en Mesa de Entrada**.

---

### 3. El turno aparece en Mesa de Entrada — `frmMesaDeEntrada` (dgvTurno)

**Archivo:** `CapaPresentacion/frmMesaDeEntrada.cs`  
**Capa de datos:** `CapaDatosMepryl/MesaEntrada.cs`

El panel `dgvTurno` (lista de espera) carga con:
```sql
WHERE t.recepcion = '1'
  AND (t.mesaDeEntrada = '0' OR t.mesaDeEntrada = '')
  AND mc.id = @idMotivo
```

---

### 4. Mesa de Entrada procesa al paciente — `ingresarPaciente()`

Cuando el operador hace clic en **"Ingresar"**:

1. Se crea un registro en la tabla `Consulta` (el expediente médico)
2. Se ejecuta:
```sql
-- sp_Turno_UpdateMesaDeEntrada
UPDATE Turno SET mesaDeEntrada = '1' WHERE id = @id
```
3. Se vinculan los ítems del turno a la consulta:
```sql
-- sp_Items_UpdateItemsPorPaciente
UPDATE Items SET idConsulta = @idConsulta WHERE idTurno = @idTurno
```

El turno **desaparece del panel de espera** y **aparece en la grilla principal** (`dgvGrilla`).

---

### 5. La grilla principal muestra los pacientes en Mesa — `dgvGrilla`

Carga desde la tabla `Consulta` (no desde `Turno`):
```sql
SELECT c.id, c.pacienteID, te.id, te.idTurno, c.fecha, c.nroOrden, ...
FROM Consulta c
INNER JOIN TipoExamenDePaciente te ON te.idConsulta = c.id
WHERE CONVERT(Date, c.fecha) = HOY
  AND c.valido = '1'
  AND c.nroOrden != '0'
  AND c.tipo != 'V'
ORDER BY c.nroOrden
```

---

### 6. Regresar a Ventanilla — `btnRecepcion_Click()`

Si hubo un error, Mesa de Entrada puede devolver el turno a Ventanilla:
```sql
-- sp_Turno_CambiarEstadoRecepcion
UPDATE Turno SET recepcion = '0' WHERE id = @id
```

---

## Diagrama de estados

```
[Turno creado]
      │  recepcion=0, mesaDeEntrada=0
      │
      ▼
[Ventanilla - frmRecepcion]
   dgv muestra turnos (recepcion=0)
      │
      │  botonRegistrar → sp_Turno_CambiarEstadoRecepcion(id, '1')
      │  → recepcion = 1
      │
      ▼
[Mesa de Entrada - dgvTurno]
   muestra turnos (recepcion=1, mesaDeEntrada=0)
      │
      │  ingresarPaciente() → crea Consulta
      │  → sp_Turno_UpdateMesaDeEntrada(id, '1')
      │  → mesaDeEntrada = 1
      │
      ▼
[Mesa de Entrada - dgvGrilla]
   muestra consultas creadas hoy

      ◄── btnRecepcion_Click() → recepcion = 0 (revierte a Ventanilla)
```

---

## Resumen de stored procedures involucrados

| Stored Procedure                        | Acción                                          |
|-----------------------------------------|-------------------------------------------------|
| `sp_Turno_CambiarEstadoRecepcion`       | Cambia `recepcion` (0=pendiente, 1=recibido)    |
| `sp_Turno_UpdateMesaDeEntrada`          | Marca `mesaDeEntrada = 1` al ingresar           |
| `sp_Items_UpdateItemsPorPaciente`       | Vincula ítems del turno a la consulta creada    |
| `sp_Turno_UpdateIdPaciente`             | Asigna paciente a un turno reservado            |
| `sp_Turno_UpdateEstadoAsignado`         | Marca el turno como asignado                    |

---

## Archivos clave

| Capa               | Archivo                                          | Responsabilidad                        |
|--------------------|--------------------------------------------------|----------------------------------------|
| Presentación       | `CapaPresentacion/frmRecepcion.cs`               | UI de Ventanilla                       |
| Presentación       | `CapaPresentacion/frmMesaDeEntrada.cs`           | UI de Mesa de Entrada                  |
| Negocio            | `CapaNegocioMepryl/Ventanilla.cs`                | Lógica de negocio de Ventanilla        |
| Negocio            | `CapaNegocioMepryl/MesaEntrada.cs`               | Lógica de negocio de Mesa de Entrada   |
| Datos              | `CapaDatosMepryl/Ventanilla.cs`                  | Queries SQL de Ventanilla              |
| Datos              | `CapaDatosMepryl/MesaEntrada.cs`                 | Queries SQL de Mesa de Entrada         |
