# ANÁLISIS COMPLETO: ¿Cómo se Abre un Turno? (Tipo Examen + Horario)

## 📋 RESUMEN EJECUTIVO

Un turno se abre mediante la **siguiente cascada**:
1. **Usuario selecciona "Tipo de Examen"** en combo (Especialidad)
2. **Sistema carga Horarios** asociados a ese tipo de examen
3. **Usuario selecciona Horario** y hace **doble clic** en la grilla de turnos
4. **Se abre ventana para asignar paciente** al turno

---

## 🏗️ ARQUITECTURA: 3 CAPAS

```
┌─────────────────────────────────────────────┐
│     CAPA PRESENTACIÓN (frmTurnos.cs)       │  ← Usuario interactúa aquí
├─────────────────────────────────────────────┤
│     CAPA NEGOCIO (CapaNegocioMepryl)       │  ← Lógica de negocio
├─────────────────────────────────────────────┤
│  CAPA DATOS (CapaDatosMepryl + BD)         │  ← Consulta SQL a Base Datos
└─────────────────────────────────────────────┘
```

---

## 1️⃣ CAPA PRESENTACIÓN - frmTurnos.cs

### **Flujo Visual:**

```
┌─────────────────────────────────┐
│  COMBO MOTIVO CONSULTA          │  (Ej: "Clínica")
└────────────┬────────────────────┘
             │ Selección → Dispara evento
             ▼
┌─────────────────────────────────┐
│  COMBO TIPO EXAMEN              │  (Ej: "Cardiología", "RX")
│  (Especialidades PADRE)         │
└────────────┬────────────────────┘
             │ Selección → Dispara evento
             ▼
┌─────────────────────────────────┐
│  COMBO SUBTIPO EXAMEN           │  (Ej: "RX Tórax")
│  (Especialidades HIJO)          │  [OPCIONAL, si existen]
└────────────┬────────────────────┘
             │ Selección → Dispara evento
             ▼
┌─────────────────────────────────┐
│  GRILLA DE TURNOS               │  (Muestra turnos disponibles)
│  Fecha / Hora / Profesional     │
└────────────┬────────────────────┘
             │ DOBLE CLIC → Abre turno
             ▼
┌─────────────────────────────────┐
│  VENTANA DE ASIGNACIÓN          │  (Selecciona paciente)
│  (frmPaciente o frmPacienteLab) │
└─────────────────────────────────┘
```

### **EVENTO 1: cboMotivoConsulta_SelectionChangeCommitted()**

**Ubicación:** [frmTurnos.cs](frmTurnos.cs#L136)

**Acción:** Carga los **Tipos de Examen PADRE** (Padre=1) para ese motivo

```csharp
private void cboMotivoConsulta_SelectionChangeCommitted(object sender, EventArgs e)
{
    // Obtiene ID del motivo seleccionado
    string idMotivoConsulta = cboMotivoConsulta.SelectedValue.ToString();
    
    // Llamada a capa negocio: Carga especialidades PADRE
    DataTable dtPadres = tipoEx.cargarNivel1Especialidad(idMotivoConsulta);
    
    // Filtra solo registro donde Padre=1
    DataView dv = new DataView(dtPadres);
    dv.RowFilter = "Padre = 1";
    DataTable dtFiltrados = dv.ToTable();
    
    // Carga combo con opciones PADRE
    cboTipoExamen.DataSource = dtFiltrados;
    cboTipoExamen.ValueMember = "id";
    cboTipoExamen.DisplayMember = "descripcion";
}
```

### **EVENTO 2: cboTipoExamen_SelectionChangeCommitted()**

**Ubicación:** [frmTurnos.cs](frmTurnos.cs#L189)

**Acción:** Carga los **Tipos de Examen HIJO** (SubTipos) y luego **carga la grilla de turnos**

```csharp
private void cboTipoExamen_SelectionChangeCommitted(object sender, EventArgs e)
{
    string idTipoExamen = cboTipoExamen.SelectedValue.ToString();
    
    // Carga Nivel 2 (especialidades HIJO)
    DataTable dtNivel2 = tipoEx.cargarNivel2Especialidad(idTipoExamen);
    
    // Carga combo SubTipo
    cboSubTipoExamen.DataSource = dtNivel2;
    
    // ★ AQUÍ SE CARGA LA GRILLA ★
    cargarGrillaTurnosSinFiltro();
}
```

### **MÉTODO: cargarGrillaTurnosSinFiltro()**

**Ubicación:** [frmTurnos.cs](frmTurnos.cs#L256)

**Acción:** Obtiene parámetros y **consulta turnos a la BD**

```csharp
private void cargarGrillaTurnosSinFiltro()
{
    llenarDgv(turno.cargarTurnos(
        obtenerTipoExamen(),     // ID del tipo examen seleccionado
        obtenerFecha(),          // Fecha del DatePicker
        obtenerHora(),           // Hora seleccionada (por rango)
        obtenerEstado()          // Estado (Libre, Asignado, etc)
    ));
}
```

### **EVENTO 3: dgv_CellDoubleClick()**

**Ubicación:** [frmTurnos.cs](frmTurnos.cs#L745)

**Acción:** Detecta **doble clic** en turno → Abre ventana de asignación

```csharp
private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
{
    if (!VerificaIDTurnoLibre())
        asignar();  // ← LLAMA A ASIGNAR
    else
        cargarGrillaTurnosSinFiltro();
}

public void asignar()
{
    // Verifica tipo de turno
    if (turnoLibre(dgv.CurrentCell.RowIndex))
    {
        turnoNoAsignado();  // ← DETERMINA SI ES PREVENTIVO O LABORAL
    }
}

private void turnoNoAsignado()
{
    char tipoTurno = turno.verificarTipoTurno(
        new Guid(dgv.Rows[dgv.CurrentCell.RowIndex].Cells[0].Value.ToString())
    );
    
    if (tipoTurno == 'P')
    {
        abrirVentanaPacientePreventiva();  // ← ABRE FRMACIENTE
    }
    else if (tipoTurno == 'L')
    {
        abrirVentanaPacienteLaboral();     // ← ABRE FRMPACIENTELABORAL
    }
}
```

---

## 2️⃣ ENTIDADES Y MODELOS DE DATOS

### **Entidad TipoExamen**

**Ubicación:** [Entidades\TipoExamen.cs](SOLUCION%203.10/MEPRYL/Entidades/TipoExamen.cs#L1)

**Propiedades clave:**
- `id` (Guid)
- `codigo` (int)
- `descripcion` (string) - Nombre visible en combos
- `padre` (bool) - ¿Es especialidad padre o hija?
- `idPadre` (string) - ID de la especialidad padre (si es hijo)

```csharp
public class TipoExamen
{
    private Guid id;
    private int codigo;
    private string descripcion;
    private bool padre;        // ← TRUE si es PADRE
    private string idPadre;    // ← ID padre si es HIJO
    // ... más propiedades
}
```

### **Entidad Horario**

**Ubicación:** [CapaDatos\Horario.cs](SOLUCION%203.10/MEPRYL/CapaDatos/Horario.cs#L1)

```csharp
public class Horario : EntidadBase
{
    public Guid profesionalID;      // ← Profesional del horario
    public Guid especialidadID;     // ← Tipo examen/Especialidad
    public bool domingo, lunes, martes, miercoles, jueves, viernes, sabado;
    public string horaDesde = "09:00";
    public string horaHasta = "17:00";
    public int citarCada = 0;       // ← Minutos entre turnos
    public int pacientesGrupo = 0;  // ← Turnos por grupo
}
```

### **Entidad Turno**

**Ubicación:** [CapaDatos\Turno.cs](SOLUCION%203.10/MEPRYL/CapaDatos/Turno.cs#L1)

```csharp
public class Turno : EntidadBase
{
    public DateTime fecha;
    public string hora = "00:00";
    public Guid horarioID;          // ← Referencia al horario
    public Guid pacienteID;
    public DataTable tipoDeExamen;
}
```

---

## 3️⃣ CAPA NEGOCIO - CapaNegocioMepryl

### **Clase Turno**

**Ubicación:** [CapaNegocioMepryl\Turno.cs](SOLUCION%203.10/MEPRYL/CapaNegocioMepryl/Turno.cs#L1)

**Método principal:**
```csharp
public DataTable cargarTurnos(Guid tipoExamen, DateTime fecha, string hora, string estado)
{
    // Delega a la capa de datos
    return turno.cargarTurnos(tipoExamen, fecha, hora, estado);
}
```

### **Clase TipoExamen**

**Ubicación:** [CapaNegocioMepryl\TipoExamen.cs](SOLUCION%203.10/MEPRYL/CapaNegocioMepryl/TipoExamen.cs)

**Métodos clave:**
```csharp
public DataTable cargarNivel1Especialidad(string idMotivoConsulta)
{
    // Carga especialidades PADRE para un motivo
    return tipoExamen.cargarNivel1Especialidad(idMotivoConsulta);
}

public DataTable cargarNivel2Especialidad(string idEspecialidad)
{
    // Carga especialidades HIJO de un padre
    return tipoExamen.cargarNivel2Especialidad(idEspecialidad);
}
```

---

## 4️⃣ CAPA DATOS - CapaDatosMepryl

### **Método: cargarTurnos()**

**Ubicación:** [CapaDatosMepryl\Turno.cs](SOLUCION%203.10/MEPRYL/CapaDatosMepryl/Turno.cs#L54)

**SQL Query:**

```sql
SELECT 
    t.id as Id,
    te.descripcion as TipoExamen,
    p.apellido + ' ' + p.nombres as Profesional,
    t.fecha as Fecha,
    t.horaReferencia as Hora,
    CONVERT(numeric, t.nroOrden) as Nro,
    t.pacienteID as idPaciente,
    t.codigo as Codigo,
    t.reserva as Reserva,
    t.usuarioID as Usuario,
    t.bloqueado as Bloqueado,
    t.asistio as Asistio,
    t.reservado as Reservado,
    tep.id as IdTipoExamen,
    t.habilitado as Habilitado,
    t.estadoID as IdEstado
FROM dbo.Turno t
    INNER JOIN dbo.TurnoEstado e ON t.estadoID = e.id
    INNER JOIN dbo.Horario h ON t.horarioID = h.id          ← ★ RELACIÓN CON HORARIO
    INNER JOIN dbo.Profesional p ON h.profesionalID = p.id
    LEFT JOIN dbo.TipoExamenDePaciente tep ON tep.idTurno = t.id
    LEFT JOIN dbo.Especialidad te ON h.especialidadID = te.id  ← ★ OBTIENE TIPO EXAMEN
WHERE convert(date, t.fecha) = convert(date, ?, 105) 
  AND te.id = ?  (si filtro tipo examen)
  AND (t.horaReferencia >= ? AND t.horaReferencia < ?)  (si filtro hora)
  AND e.descripcion = ?  (si filtro estado)
ORDER BY t.fecha, t.hora
```

**Parámetros dinámicos:**
- `tipoExamen`: Filtra por `h.especialidadID` (Tipo Examen)
- `fecha`: Filtra por `t.fecha`
- `hora`: Filtra por rango `t.horaReferencia`
- `estado`: Filtra por `e.descripcion`

---

## 🔗 RELACIONES ENTRE TABLAS

```sql
┌──────────────────┐
│   MOTIVO CONSULTA │  (Ej: "Clínica")
└────────┬─────────┘
         │
         │ 1:N
         ▼
┌──────────────────┐
│   ESPECIALIDAD   │  (Ej: "Cardiología", "RX", "Laboratorio")
│  (TipoExamen)    │  - Algunos son PADRE
│                  │  - Algunos son HIJO (tienen padre)
└────────┬─────────┘
         │
         │ 1:N (por especialidadID)
         ▼
┌──────────────────┐
│    HORARIO       │  (Ej: Cardiología - Lunes 09:00-17:00)
│                  │  - Vinculado a Profesional
│  - profesionalID │  - Vinculado a Especialidad
│  - especialidadID│
│  - horaDesde     │
│  - horaHasta     │
│  - citarCada     │
└────────┬─────────┘
         │
         │ 1:N (por horarioID)
         ▼
┌──────────────────┐
│      TURNO       │  (Ej: Cardiología - 15/12/2024 - 09:00)
│                  │
│  - horarioID     │  ← Referencia al HORARIO
│  - fecha         │
│  - hora          │
│  - pacienteID    │
│  - estadoID      │
└──────────────────┘
```

---

## 📊 FLUJO RESUMIDO: PASO A PASO

### **Paso 1: Usuario selecciona Motivo de Consulta**
```
Usuario elige: "Clínica"
     ↓
Evento: cboMotivoConsulta_SelectionChangeCommitted()
     ↓
SQL: SELECT * FROM Especialidad WHERE idMotivoConsulta = ?
     ↓
Carga combo TipoExamen con opciones PADRE
```

### **Paso 2: Usuario selecciona Tipo de Examen**
```
Usuario elige: "Cardiología"
     ↓
Evento: cboTipoExamen_SelectionChangeCommitted()
     ↓
SQL: SELECT * FROM Horario WHERE especialidadID = ?
SQL: SELECT * FROM Turno WHERE fecha = ? AND especialidadID = ?
     ↓
Carga combo SubTipo (si existen hijos)
Carga GRILLA con turnos disponibles
```

### **Paso 3: Usuario hace DOBLE CLIC en turno**
```
Usuario hace DOBLE CLIC en fila de grilla
     ↓
Evento: dgv_CellDoubleClick()
     ↓
Método: asignar()
     ↓
Consulta: ¿Es turno Preventivo o Laboral?
     ↓
Si Preventivo → Abre frmPaciente
Si Laboral → Abre frmPacienteLaboral
```

### **Paso 4: Usuario asigna paciente**
```
Usuario selecciona paciente en ventana
     ↓
Evento: Callback/Delegate
     ↓
SQL: UPDATE Turno SET pacienteID = ?, estadoID = ? WHERE id = ?
     ↓
Turno asignado ✓
Grilla se recarga
```

---

## 🎯 PUNTOS CLAVE

| Componente | Ubicación | Responsabilidad |
|------------|-----------|-----------------|
| **frmTurnos** | CapaPresentacion | Interfaz, cascadas de combos, carga grilla |
| **frmHorario** | CapaPresentacion | CRUD de horarios (profesional + especialidad) |
| **Turno (Negocio)** | CapaNegocioMepryl | Validaciones, lógica de asignación |
| **Turno (Datos)** | CapaDatosMepryl | Consultas SQL, CRUD |
| **TipoExamen (Negocio)** | CapaNegocioMepryl | Carga de especialidades padre/hijo |
| **TipoExamen (Datos)** | CapaDatosMepryl | Consultas de especialidades |
| **Horario** | CapaDatos | Definición de franjas horarias |

---

## 🔍 CONEXIÓN: TIPO EXAMEN ↔ HORARIO ↔ TURNO

1. **TipoExamen es la ESPECIALIDAD**
   - Se ve en los combos como "Cardiología", "RX", etc.
   - En BD es tabla `Especialidad`

2. **Horario vincula PROFESIONAL + ESPECIALIDAD**
   - Un horario dice: "Dr. López atiende Cardiología de L-V 09:00-17:00"
   - Campo `especialidadID` en Horario = ID del TipoExamen

3. **Turno es INSTANCIA del Horario**
   - Cada turno heredita del horario:
     - El tipo de examen (vía horario.especialidadID)
     - El profesional (vía horario.profesionalID)
     - La hora (limitada por horario.horaDesde/Hasta)
   - Campo `horarioID` en Turno = ID del Horario

**Conclusión:** La jerarquía es:
```
TipoExamen → Horario → Turnos
(¿Qué?)     (¿Cuándo?) (Instancias disponibles)
```

---

## 📝 EJEMPLO REAL

```
USUARIO SELECCIONA:
├─ Motivo Consulta: "Clínica"
├─ Tipo Examen: "Cardiología"  ← ID: 550e8400-e29b-41d4-a716-446655440001
├─ Sub Tipo: "TODOS"
├─ Fecha: 15/12/2024
└─ Hora: 09:00-10:00

SISTEMA EJECUTA:
┌─ cargarTurnos(
│    tipoExamen: 550e8400-e29b-41d4-a716-446655440001,
│    fecha: 15/12/2024,
│    hora: 09:00,
│    estado: Libre
│  )
└─

GRILLA MUESTRA:
┌─────────┬──────────────┬───────────────┬──────────┬──────────┐
│ Tipo    │ Médico       │ Fecha         │ Hora     │ Nro      │
├─────────┼──────────────┼───────────────┼──────────┼──────────┤
│ Cardio  │ Dr. López    │ 15/12/2024    │ 09:00    │ 1        │  ← TURNO 1
│ Cardio  │ Dr. López    │ 15/12/2024    │ 09:15    │ 2        │  ← TURNO 2
│ Cardio  │ Dra. García  │ 15/12/2024    │ 10:00    │ 3        │  ← TURNO 3
└─────────┴──────────────┴───────────────┴──────────┴──────────┘

USUARIO HACE DOBLE CLIC EN TURNO 1
     ↓
SISTEMA ABRE: frmPaciente
     ↓
USUARIO SELECCIONA: Juan Pérez (DNI: 12345678)
     ↓
SISTEMA EJECUTA:
  UPDATE Turno SET pacienteID = xxx, estadoID = 'Asignado'
  WHERE id = xxx AND fecha = 15/12/2024 AND hora = 09:00
     ↓
TURNO ASIGNADO ✓
GRILLA SE RECARGA
```

---

## 🚀 RESUMEN FINAL

**¿Cómo se abre un turno mediante Tipo de Examen o Horario?**

1. **Mediante Tipo de Examen:**
   - Usuario selecciona en combo → Sistema filtra Horarios → Carga Turnos
   - La cascada: Motivo → TipoExamen Padre → TipoExamen Hijo → Grilla de Turnos

2. **Mediante Horario:**
   - El horario vincula Profesional + Especialidad (TipoExamen)
   - Los turnos se crean a partir del horario (citarCada minutos)
   - Usuario ve turnos disponibles en la grilla

3. **Apertura del Turno:**
   - Doble clic en grilla → Abre frmPaciente o frmPacienteLaboral
   - Usuario asigna paciente → Turno se actualiza en BD

