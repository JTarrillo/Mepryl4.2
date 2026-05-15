# Actualización de Registros de FUTBOL a FUTBOL METRO

## 📋 Fecha
15/05/2026

---

## 📊 Datos Iniciales (Antes de la Actualización)

### Consulta de Verificación
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

### Resultados Iniciales
| Especialidad                     | Padre | Cantidad |
|----------------------------------|-------|----------|
| FUTBOL                           | 1     | **47**   |
| FUTBOL METRO                     | 0     | 33,620  |
| FUTBOL PARTICULAR                | 0     | 19,020  |
| FUTBOL AFA                       | 0     | 13,143  |
| FUTBOL METRO SIN LABORATORIO NI RX | 0 | 11 |
| FUTBOL PRUEBA                    | 0     | 1        |

---

## 🔑 IDs de las Especialidades

### Consulta para Obtener IDs
```sql
SELECT id, descripcion, Padre, IdPadre 
FROM Especialidad 
WHERE descripcion IN ('FUTBOL', 'FUTBOL METRO')
```

### Resultados
| id                                   | descripcion   | Padre | IdPadre                              |
|--------------------------------------|---------------|-------|--------------------------------------|
| D6A02B46-FB57-44E1-9469-6315FC8236EF | FUTBOL        | 1     | NULL                                 |
| 60E94892-6F59-4202-A966-884FD71A5D8B | FUTBOL METRO  | 0     | D6A02B46-FB57-44E1-9469-6315FC8236EF |

---

## 🔧 Script de Actualización

### Script con Transacción (Seguro)
```sql
BEGIN TRANSACTION

UPDATE TipoExamenDePaciente
SET idEspecialidad = '60E94892-6F59-4202-A966-884FD71A5D8B'
WHERE idEspecialidad = 'D6A02B46-FB57-44E1-9469-6315FC8236EF'

-- Verificar la cantidad de registros actualizados
SELECT @@ROWCOUNT as RegistrosActualizados

-- Confirmar la actualización
COMMIT TRANSACTION
```

### Resultado de la Actualización
```
(47 rows affected)

RegistrosActualizados
---------------------
                   47
```

---

## 📊 Datos Finales (Después de la Actualización)

### Consulta de Verificación
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

### Resultados Finales
| Especialidad                     | Padre | Cantidad |
|----------------------------------|-------|----------|
| **FUTBOL METRO**                 | 0     | **33,667** ← 33,620 + 47 |
| FUTBOL PARTICULAR                | 0     | 19,020  |
| FUTBOL AFA                       | 0     | 13,143  |
| FUTBOL METRO SIN LABORATORIO NI RX | 0 | 11 |
| FUTBOL PRUEBA                    | 0     | 1        |

---

## ✅ Resumen de la Actualización

| Indicador                     | Valor |
|-------------------------------|-------|
| Registros actualizados        | **47** |
| Especialidad anterior         | FUTBOL (Padre=1) |
| Especialidad nueva            | FUTBOL METRO (Padre=0) |
| Total FUTBOL METRO después  | 33,667 |
| Registros FUTBOL restantes   | **0** |

---

## 🎉 Estado Final
✅ **Éxito**: Todos los 47 registros de "FUTBOL" (Padre=1) fueron actualizados correctamente a "FUTBOL METRO" (Padre=0).
