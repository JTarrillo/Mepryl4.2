# Script para Actualizar Registros de FUTBOL a FUTBOL METRO

## 📋 IDs
- **FUTBOL (Padre)**: `D6A02B46-FB57-44E1-9469-6315FC8236EF`
- **FUTBOL METRO (Hijo)**: `60E94892-6F59-4202-A966-884FD71A5D8B`

---

## 🔧 Script de Actualización (SAFE - con SELECT primero)

### Paso 1: Verificar cuáles registros se van a actualizar
```sql
SELECT 
    tep.id as IdTipoExamenDePaciente,
    p.dni,
    p.apellido,
    p.nombres,
    e.descripcion as EspecialidadActual,
    ePadre.descripcion as EspecialidadNueva
FROM TipoExamenDePaciente tep
JOIN Consulta c ON tep.idConsulta = c.id
JOIN Paciente p ON c.pacienteID = p.id
JOIN Especialidad e ON tep.idEspecialidad = e.id
CROSS JOIN Especialidad ePadre
WHERE e.id = 'D6A02B46-FB57-44E1-9469-6315FC8236EF'
  AND ePadre.id = '60E94892-6F59-4202-A966-884FD71A5D8B'
ORDER BY tep.id DESC
```

---

### Paso 2: Actualizar los registros
```sql
BEGIN TRANSACTION

UPDATE TipoExamenDePaciente
SET idEspecialidad = '60E94892-6F59-4202-A966-884FD71A5D8B'
WHERE idEspecialidad = 'D6A02B46-FB57-44E1-9469-6315FC8236EF'

-- Verificar la cantidad de registros actualizados
SELECT @@ROWCOUNT as RegistrosActualizados

-- Si todo está bien, hacer COMMIT
-- COMMIT TRANSACTION

-- Si hay algún error, hacer ROLLBACK
-- ROLLBACK TRANSACTION
```

---

### Paso 3: Verificar que la actualización se realizó correctamente
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
