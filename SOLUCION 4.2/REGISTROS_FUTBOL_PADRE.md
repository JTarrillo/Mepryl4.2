# Registros de FUTBOL con Padre=1 (47 registros)

## 📋 Consulta para ver los registros
```sql
SELECT 
    tep.id as IdTipoExamenDePaciente,
    tep.idConsulta,
    tep.idTurno,
    p.dni,
    p.apellido,
    p.nombres,
    e.descripcion as Especialidad,
    e.Padre,
    e.IdPadre
FROM TipoExamenDePaciente tep
JOIN Consulta c ON tep.idConsulta = c.id
JOIN Paciente p ON c.pacienteID = p.id
JOIN Especialidad e ON tep.idEspecialidad = e.id
WHERE e.descripcion = 'FUTBOL' AND e.Padre = 1
ORDER BY tep.id DESC
```

---

## 📋 Consulta para contar registros por especialidad
```sql
SELECT 
    e.descripcion as Especialidad,
    e.Padre,
    COUNT(*) as Cantidad
FROM TipoExamenDePaciente tep
JOIN Especialidad e ON tep.idEspecialidad = e.id
WHERE e.descripcion LIKE '%FUTBOL%'
GROUP BY e.descripcion, e.Padre
ORDER BY e.Padre DESC, Cantidad DESC
```

---

## 🔧 Procedimiento Almacenado Modificado

### ALTER PROCEDURE
```sql
ALTER PROCEDURE sp_TipoExamenDePaciente_UpdateTipoExamenPaciente
@idConsulta uniqueidentifier,
@idEspecialidad uniqueidentifier
AS
UPDATE dbo.TipoExamenDePaciente
SET idEspecialidad = @idEspecialidad
WHERE idConsulta = @idConsulta
```

### Versión Original (con restricción)
```sql
CREATE PROCEDURE sp_TipoExamenDePaciente_UpdateTipoExamenPaciente
@idConsulta uniqueidentifier,
@idEspecialidad uniqueidentifier
AS
IF EXISTS (SELECT 1 FROM dbo.Especialidad WHERE id = @idEspecialidad AND Padre = 0)
BEGIN
    UPDATE dbo.TipoExamenDePaciente
    SET idEspecialidad = @idEspecialidad
    WHERE idConsulta = @idConsulta
END
ELSE
BEGIN
    RAISERROR('El idEspecialidad no corresponde a un subtipo (Padre=0)', 16, 1) 
END
```

---

## 📊 Resumen
- **Total registros FUTBOL (Padre=1)**: 47
- **Subtipos disponibles**:
  - FUTBOL AFA
  - FUTBOL METRO
  - FUTBOL METRO SIN LABORATORIO NI RX
  - FUTBOL PARTICULAR
  - FUTBOL PRUEBA
  - FUTBOL SENIOR
