# Análisis de Base de Datos — Ventanilla y Mesa de Entrada
**Fecha:** 20 de mayo de 2026  
**Base de datos:** MEPRYLv2.1 — Servidor: 192.168.1.254

---

## 1. Flujo: Ventanilla → Mesa de Entrada (verificado contra código fuente)

### 1.1 Estados de la tabla `Turno`

| Campo           | Valor | Significado                                       |
|-----------------|-------|---------------------------------------------------|
| `recepcion`     | `NULL`  | Turno creado, sin tocar aún — visible en Ventanilla |
| `recepcion`     | `'0'`   | Turno activo pendiente — visible en Ventanilla    |
| `recepcion`     | `'1'`   | Turno recibido — visible en Mesa de Entrada       |
| `mesaDeEntrada` | `'0'`   | Todavía no procesado en Mesa de Entrada           |
| `mesaDeEntrada` | `'1'`   | Ya procesado — tiene Consulta creada              |
| `asistio`       | `'1'`   | Paciente marcó asistencia en Ventanilla           |
| `habilitado`    | `'1'`   | Turno activo y visible                            |
| `ocultar`       | `'1'`   | Turno ocultado de la vista normal                 |

> **Nota clave:** Los turnos nuevos se crean con todos los campos en `NULL`. El filtro de Ventanilla los captura con `(recepcion = '0' OR recepcion IS NULL)`.

---

### 1.2 Flujo paso a paso (verificado en código)

```
[Turno creado]
   recepcion=NULL, mesaDeEntrada=NULL, habilitado='1'
         │
         ▼
[Ventanilla — frmRecepcion.cs]
   Filtro: (recepcion='0' OR recepcion IS NULL) AND habilitado='1' AND ocultar <> 1
   Columnas dgv: [0]=Asistio  [1]=Abono  [2]=IdTurno(oculta)  [14]=IdPaciente(oculta)
                 [15]=Reservado(oculta)  [16]=IdEmpresa(oculta)  [17]=Ocultar
         │
         │  Col 0 click → sp_Turno_UpdatePresente
         │  Col 1 click → sp_Turno_UpdateAbono
         │  Col 17 click → UPDATE dbo.Turno SET ocultar='1' WHERE id=@id  (directo, sin SP)
         │
         │  botonRegistrar_Click → registrar()
         │     ├─ Si NO reservado → abre frmAvisoExamenModificado → callback registrarIngreso()
         │     └─ Si ES reservado → pregunta cargar paciente
         │           └─ Si No + asistio=true → registrarIngreso()
         │
         │  registrarIngreso() — REQUIERE asistio=true en Cell[0], sino muestra error
         │     └─ ventanilla.registrarIngreso(idTurno)
         │           └─ sp_Turno_CambiarEstadoRecepcion(@id, '1')
         │                 → Turno.recepcion = '1'
         │
         ▼
[Mesa de Entrada — frmMesaDeEntrada.cs — panel dgvTurno]
   Filtro: recepcion='1' AND (mesaDeEntrada='0' OR mesaDeEntrada='')
           AND mc.id = @idMotivo
   (JOIN con TipoExamenDePaciente — el turno ya debe tener un TEP vinculado)
         │
         │  ingresarPaciente()
         │     1. estaHabilitado(idPaciente)  ← guard previo
         │     2. sp_Consulta_Insert           ← crea registro en tabla Consulta
         │     3. sp_TipoExamenDePaciente_Add  ← vincula tipo de examen
         │     4. sp_Turno_UpdateMesaDeEntrada(@id, '1')
         │     5. sp_Items_UpdateItemsPorPaciente(@idTurno, @idConsulta)
         │     6a. Si Preventiva → exPreventiva.crearExamen(idTipoExamen)
         │     6b. Si Laboral    → generarLaboral(idConsulta)
         │
         ▼
[Mesa de Entrada — panel dgvGrilla]
   Carga desde tabla Consulta:
   WHERE CONVERT(date,c.fecha) = HOY
     AND c.valido = '1'
     AND c.nroOrden != '0'
     AND c.tipo != 'V'
   ORDER BY c.nroOrden

         ◄── btnRecepcion_Click → sp_Turno_CambiarEstadoRecepcion(@id, '0')  (revierte)
```

---

### 1.3 Stored Procedures involucrados (completo)

| Stored Procedure                    | Dónde se usa                            | Acción                                    |
|-------------------------------------|-----------------------------------------|-------------------------------------------|
| `sp_Turno_CambiarEstadoRecepcion`   | Ventanilla — registrarIngreso()         | Cambia `recepcion` (0↔1)                 |
| `sp_Turno_UpdatePresente`           | Ventanilla — Col 0 checkbox             | Actualiza campo `asistio`                 |
| `sp_Turno_UpdateAbono`              | Ventanilla — Col 1 checkbox             | Actualiza campo `abono`                   |
| `sp_Turno_UpdateMesaDeEntrada`      | Mesa de Entrada — ingresarPaciente()    | Marca `mesaDeEntrada = '1'`               |
| `sp_Consulta_Insert`                | Mesa de Entrada — ingresarPaciente()    | Crea el registro de Consulta              |
| `sp_TipoExamenDePaciente_Add`       | Mesa de Entrada — ingresarPaciente()    | Vincula tipo de examen a la consulta      |
| `sp_Items_UpdateItemsPorPaciente`   | Mesa de Entrada — ingresarPaciente()    | Vincula ítems del turno a la consulta     |
| `sp_Turno_UpdateIdPaciente`         | Ventanilla — asignación reservado       | Asigna paciente a turno reservado         |
| `sp_Turno_UpdateEstadoAsignado`     | Ventanilla — asignación reservado       | Marca turno como asignado                 |
| `sp_retiraEnMepryl_update`          | Mesa de Entrada — Col 16 (RM)           | Actualiza campo `rm` en TipoExamenDePaciente |

> **Nota:** `actualizarOcultar()` en Ventanilla ejecuta un UPDATE directo (no usa SP):  
> `UPDATE dbo.Turno SET ocultar = '1' WHERE id = '{idTurno}'`

---

## 2. Estado de la BD al día de hoy — 20/05/2026

### 2.1 Composición de los turnos del día

| Tipo de registro                    | Cantidad | Descripción                              |
|-------------------------------------|----------|------------------------------------------|
| **Huecos libres** (sin paciente)    | **455**  | Slots de agenda generados sin reserva    |
| **Turnos con paciente asignado**    | **44**   | Pacientes reales agendados hoy           |
| **Total habilitados**               | **499**  | Total de filas en `Turno` para hoy       |

> Los 455 huecos libres tienen `pacienteID = NULL`, `recepcion = NULL`, `asistio = NULL`.  
> Son slots vacíos pre-generados por la agenda. Aparecen en Ventanilla pero no tienen paciente.

---

### 2.2 Estado de flujo de los 44 pacientes reales

| Estado                                        | Cantidad |
|-----------------------------------------------|----------|
| `recepcion='1'`, `mesaDeEntrada='1'` (procesados) | **17** |
| `recepcion='0'`, `asistio='1'` (listos para registrar) | **4** |
| `recepcion='0'`, `asistio='0'` (aún no asistieron) | **23** |
| En cola Mesa de Entrada (`recepcion='1'`, `mesaDeEntrada='0'`) | **0** |

---

### 2.3 Consultas creadas hoy (17 pacientes procesados)

| Orden | Tipo | Especialidad | Paciente | DNI |
|-------|------|--------------|----------|-----|
| 1 | L | LEY + LUMBAR (F-P) | SALVETTI MORENA | 47069985 |
| 2 | P | BOXEO | FIGUEROA BRANDON NAHUEL | 48564835 |
| 3 | L | PERIODICO LEY | CARDOZO ELBIO ALCIDES | 26309707 |
| 4 | L | GNA CON ECOGRAFIA ABDOMINAL | LOPEZ ENZO IVAN | 46278011 |
| 5 | L | PERIODICO LEY | GOMEZ LUCAS YOEL | 44756290 |
| 6 | L | PERIODICO LEY + LUMBAR + EQUIL + HEPATO + ... + EEG | RETAMAR CARLOS GUSTAVO | 29647341 |
| 7 | L | LEY + LUMBAR + HEPATO + ... + EEG | BUSTAMANTE LUCAS NICOLAS | 37304420 |
| 8 | L | PSA CON ECOGRAFIA ABDOMINAL | VALLE SAN MARTIN ZAHIRA ABIGAIL | 47790002 |
| 9 | L | BUZO RENOVACION | ROLERI JUAN MANUEL | 33895047 |
| 10 | L | PERIODICO LEY | CARBALLO RAUL ALBERTO | 28547265 |
| 11 | L | SPF | PERDOMO FIAMMA | 46001983 |
| 12 | EC | ERGOMETRIA | VILLADA OCAMPO JUAN DAVID | 96174940 |
| 13 | L | BUZO RENOVACION | MORALES DANIEL DARIO | 23348693 |
| 14 | L | PSA CON ECOGRAFIA ABDOMINAL | VARGAS CARLA SOFIA | 44431131 |
| 15 | L | PERIODICO LEY + LUMBAR + EQUIL + ... + ESPIRO + EEG | TORREZ GERMAN RAUL | 33368463 |
| 16 | P | FUTBOL METRO | BOLLE DAVID BENJAMIN | 50426332 |
| 17 | L | PSA | FLORES DAMARIS AYLEN | 45498595 |

---

### 2.4 Pacientes pendientes en Ventanilla (con asistencia marcada — listos para ingresar)

| Hora | Especialidad | MotivoConsulta | Paciente | DNI |
|------|--------------|----------------|----------|-----|
| 08:30 | BUZO RENOVACION | LABORAL | KAUFFER JEREZ LUIS HERNAN | 36626144 |
| 08:30 | PSA | LABORAL | DUARTE ORIANA CAMILA | 47476165 |
| 09:00 | SPF | LABORAL | BEHRNS GOMEZ VANESA ANA LAURA | 37259354 |
| 08:45 | GNA CON ECOGRAFIA ABDOMINAL | LABORAL | ALVAREZ ROMAN CESAR ALBERTO | 48830587 |

---

### 2.5 Especialidades más activas hoy

| Especialidad | Motivo | Total Turnos | Procesados | En Ventanilla |
|---|---|---|---|---|
| FUTBOL METRO | PREVENTIVA | 94 | 1 | 93 |
| PSA CON ECOGRAFIA ABDOMINAL | LABORAL | 36 | 2 | 34 |
| FUTBOL METRO SIN LAB NI RX | PREVENTIVA | 30 | 0 | 30 |
| GNA CON ECOGRAFIA ABDOMINAL | LABORAL | 28 | 1 | 27 |
| PSA | LABORAL | 26 | 1 | 25 |
| SPF | LABORAL | 21 | 1 | 20 |
| LEY + LUMBAR (P) | LABORAL | 20 | 0 | 20 |
| PREOCUPACIONAL LEY | LABORAL | 18 | 0 | 18 |
| BASQUET FEBAMBA U13-U17 | PREVENTIVA | 12 | 0 | 12 |
| BOXEO | PREVENTIVA | 12 | 1 | 11 |

> Estos totales incluyen huecos libres y pacientes asignados.  
> FUTBOL METRO domina con 94 slots (mayoría preventivos, típico de jornada deportiva).

---

## 3. Próximos pacientes agendados para hoy (pendientes, sin asistencia)

| Hora | Especialidad | Paciente | DNI |
|------|--------------|----------|-----|
| 09:00 | EJERCITO ARGENTINO ESESC | MATASSA GONZALO LIONEL | 48846269 |
| 09:30 | GNA CON ECOGRAFIA | GOMEZ TIZIANO IVAN | 46775175 |
| 09:30 | FUTBOL METRO | PONZO CIRO | 53044165 |
| 09:45 | FUTBOL METRO | PAZOS NESTA | 57921952 |
| 09:45 | FUTBOL METRO | LEDEZMA BENJAMIN FERNANDO | 52129159 |
| 10:00 | FUTBOL METRO | RODRIGUEZ ALEXANDER | 50112307 |
| 10:00 | FUTBOL METRO | PARRA EYTHAN MARIANO | 57684743 |
| 10:00 | FUTBOL METRO | NOGUERA BAÑOLAS BENJAMIN | 5266266 |
| 10:00 | FUTBOL METRO | NOGUERA BAÑOLAS SANTINO | 52662662 |
| 10:15 | FUTBOL METRO | CORREA GUERRERO KILLIAN | 50368421 |
| 10:15 | FUTBOL METRO SIN LAB/RX | QUIROGA LUCIO | 58199252 |
| 10:15 | FUTBOL METRO SIN LAB/RX | QUIROGA LEON | 58199253 |
| 10:15 | FUTBOL METRO | IBAÑEZ BAYRON VICTOR HUGO | 56029240 |
| 10:15 | FUTBOL METRO | DE JESUS THIAGO VALENTIN | 50737278 |
| 10:30 | FUTBOL METRO | MUSI TOMAS BENICIO | 57317867 |
| 10:30 | FUTBOL METRO | BEN AMOR JANO LAUTARO | 53742385 |
| 10:30 | FUTBOL METRO | MUSI GIOVANNI ATILIO | 54889173 |
| 10:45 | FUTBOL METRO | VILLALBA CASTILLO MIQUEAS | 53334664 |
| 10:45 | FUTBOL METRO | PAZ LOPEZ BAUTISTA FRANCESCO | 53723163 |
| 10:45 | FUTBOL METRO | BENITEZ ACHAR AUGUSTO CESAR | 52594090 |
| 11:00 | FUTBOL METRO | FARIÑA THEO YAO | 57683297 |

---

## 4. Parámetros de conexión

| Parámetro | Valor |
|-----------|-------|
| Servidor | 192.168.1.254 |
| Base de datos | MEPRYLv2.1 |
| Usuario | user |

---

*Generado: 20 de mayo de 2026*
