# SISTEMA DE SEGUIMIENTO - PROBLEMA CONSULTORIO/FUTBOL

## 🎯 OBJETIVO

Detectar y monitorear cuando los turnos se crean con especialidades diferentes a las configuradas en el horario, para dar seguimiento a inconsistencias como el caso FUTBOL vs CONSULTORIO.

## 📋 COMPONENTES DEL SISTEMA

### 1. Tabla de Log: `LogInconsistenciaEspecialidad`
Registra automáticamente cuando se detecta una inconsistencia entre la especialidad del horario y la asignada al paciente.

**Campos principales:**
- `idTurno`: Identificador del turno
- `codigoTurno`: Código visible del turno
- `especialidadHorario`: Especialidad configurada en el horario
- `especialidadAsignada`: Especialidad asignada al paciente
- `origenProceso`: Origen de la detección
- `fechaRegistro`: Cuándo se detectó la inconsistencia

### 2. Stored Procedure: `sp_DetectarInconsistenciaEspecialidad`
Procedimiento para detectar y registrar inconsistencias manual o automáticamente.

**Uso:**
```sql
EXEC sp_DetectarInconsistenciaEspecialidad 
    @idTurno = 'AE38DCE9-6474-4648-A9DF-2954451F7C51',
    @origenProceso = 'VERIFICACION_MANUAL';
```

### 3. Vista: `vw_InconsistenciasEspecialidad`
Vista para monitoreo en tiempo real de inconsistencias (últimos 7 días).

**Consulta:**
```sql
SELECT * FROM dbo.vw_InconsistenciasEspecialidad;
```

## 🔍 CÓMO DAR SEGUIMIENTO

### 1. Monitoreo Diario
Ejecutar esta consulta para ver inconsistencias recientes:
```sql
SELECT 
    codigoTurno,
    fechaTurno,
    horaTurno,
    pacienteDNI,
    pacienteNombre,
    especialidadHorario as 'Especialidad_Horario',
    especialidadAsignada as 'Especialidad_Asignada',
    estado,
    consulta as 'Tipo_Consulta'
FROM dbo.vw_InconsistenciasEspecialidad
ORDER BY fechaTurno DESC;
```

### 2. Análisis de Casos Específicos
Para analizar un turno específico:
```sql
EXEC sp_DetectarInconsistenciaEspecialidad 
    @idTurno = 'ID_DEL_TURNO',
    @origenProceso = 'ANALISIS_MANUAL';
```

### 3. Historial de Inconsistencias
Para ver el historial completo:
```sql
SELECT * FROM dbo.LogInconsistenciaEspecialidad
ORDER BY fechaRegistro DESC;
```

## 📊 INTERPRETACIÓN DE RESULTADOS

### Caso 1: INCONSISTENCIA LEGÍTIMA
**Ejemplo:** Turno 645295 (GOMEZ FIDEL ALBERTO)
- **Horario:** FUTBOL METRO SIN LABORATORIO NI RX
- **Asignado:** CONSULTORIO
- **Estado:** INCONSISTENCIA
- **Origen:** Vino del módulo de Consultorio (`ProcesoConsultorio`)
- **Acción:** **NO CORREGIR** - Esta inconsistencia es intencional y correcta

### Caso 2: INCONSISTENCIA ERRÓNEA
**Ejemplo:** Turno creado desde pantalla de turnos normal
- **Horario:** FUTBOL METRO
- **Asignado:** CONSULTORIO
- **Estado:** INCONSISTENCIA
- **Origen:** Creación normal desde frmTurnos
- **Acción:** **CORREGIR** - Esta inconsistencia es un error

## 🛠️ ACCIONES CORRECTIVAS

### Para corregir inconsistencias erróneas:
```sql
UPDATE dbo.TipoExamenDePaciente 
SET idEspecialidad = (
    SELECT h.especialidadID 
    FROM dbo.Turno t 
    INNER JOIN dbo.Horario h ON t.horarioID = h.id 
    WHERE t.id = TipoExamenDePaciente.idTurno
)
WHERE idTurno = 'ID_DEL_TURNO_A_CORREGIR';
```

### Para registrar inconsistencias legítimas:
```sql
-- Marcar como revisada en el log
UPDATE dbo.LogInconsistenciaEspecialidad
SET observaciones = 'INCONSISTENCIA LEGÍTIMA - Vino de módulo Consultorio'
WHERE idTurno = 'ID_DEL_TURNO';
```

## 🔄 INTEGRACIÓN CON CÓDIGO

### Opcional: Integrar en frmTurnos.cs
Para detección automática al crear turnos:

```csharp
// Después de crear un turno, verificar consistencia
private void verificarConsistenciaEspecialidad(Guid idTurno, string origen)
{
    string sql = $"EXEC sp_DetectarInconsistenciaEspecialidad @idTurno = '{idTurno}', @origenProceso = '{origen}'";
    SQLConnector.obtenerTablaSegunConsultaString(sql);
}

// Llamar después de guardar turno
private void guardar()
{
    // ... código existente de guardar ...
    
    // Verificar consistencia
    if (guidTurnoActual != Guid.Empty)
    {
        verificarConsistenciaEspecialidad(guidTurnoActual, "FRMTURNOS_GUARDAR");
    }
}
```

## 📈 REPORTES

### Reporte Diario (Puede automatizarse como Job SQL)
```sql
-- Inconsistencias del día
SELECT 
    COUNT(*) as Total_Inconsistencias,
    CAST(GETDATE() AS DATE) as Fecha
FROM dbo.vw_InconsistenciasEspecialidad
WHERE CAST(fechaTurno AS DATE) = CAST(GETDATE() AS DATE);
```

### Reporte Semanal
```sql
-- Resumen semanal
SELECT 
    especialidadHorario,
    especialidadAsignada,
    COUNT(*) as Cantidad,
    MIN(fechaTurno) as Primera_Ocurrencia,
    MAX(fechaTurno) as Ultima_Ocurrencia
FROM dbo.vw_InconsistenciasEspecialidad
GROUP BY especialidadHorario, especialidadAsignada
ORDER BY Cantidad DESC;
```

## ⚠️ IMPORTANTE

### Diferenciar entre:
1. **Inconsistencias Legítimas**: Cuando vienen de módulos específicos (Consultorio, Ventanilla, etc.)
2. **Inconsistencias Erróneas**: Cuando son errores del sistema

### El sistema de seguimiento NO corrige automáticamente:
- Solo detecta y registra
- La decisión de corregir o no es manual según el contexto

## 📞 SOPORTE

Ante dudas sobre si una inconsistencia debe corregirse:
1. Verificar el origen del proceso
2. Revisar el contexto del paciente (empresa, tipo de examen)
3. Consultar el log de observaciones
4. Si es legítima, documentar en el log

---

**Sistema implementado:** 2026-08-25
**Estado:** Activo y monitoreando
**Próxima revisión:** Diaria recomendada