# Investigación de DNIs en Base de Datos

## DNIs Investigados
- 55264343
- 55964501
- 53047439
- 53993912

---

## Consultas SQL Ejecutadas

### 1. Obtener datos básicos de los pacientes
```sql
SELECT p.id, p.dni, p.apellido, p.nombres 
FROM Paciente p 
WHERE p.dni IN ('55264343','55964501','53047439','53993912')
```

### 2. Obtener registros de TipoExamenDePaciente con estructura padre-hijo
```sql
SELECT tep.id, p.dni, e.descripcion as Especialidad, e.Padre, e.IdPadre, ePadre.descripcion as PadreDescripcion 
FROM TipoExamenDePaciente tep 
JOIN Consulta c ON tep.idConsulta = c.id 
JOIN Paciente p ON c.pacienteID = p.id 
JOIN Especialidad e ON tep.idEspecialidad = e.id 
LEFT JOIN Especialidad ePadre ON e.IdPadre = ePadre.id 
WHERE p.dni IN ('55264343','55964501','53047439','53993912') 
ORDER BY p.dni, tep.id DESC
```

---

## Resultados de la Investigación

### Resumen de Registros
| DNI        | Apellido       | Nombre            |
|------------|----------------|-------------------|
| 53047439   | SALERNO        | BASTIAN LUCIANO   |
| 53993912   | ONISHCHENKO    | BENJAMIN FEDERICO |
| 55264343   | LEZCANO        | NICOLAS           |
| 55964501   | FERNANDEZ      | ROMAN             |

### Estructura de los Registros
Se encontraron **registros mixtos**:
- **Padres**: `Padre = 1` (ej: "FUTBOL")
- **Hijos**: `Padre = 0` (ej: "FUTBOL METRO")

### Ejemplos de Registros
| DNI        | Especialidad   | Padre | IdPadre | PadreDescripcion |
|------------|----------------|-------|---------|------------------|
| 53047439   | FUTBOL         | 1     | NULL    | NULL             |
| 53993912   | FUTBOL         | 1     | NULL    | NULL             |
| 53993912   | FUTBOL METRO   | 0     | [GUID]  | FUTBOL           |
| 55264343   | FUTBOL         | 1     | NULL    | NULL             |
| 55964501   | FUTBOL         | 1     | NULL    | NULL             |
| 55964501   | FUTBOL METRO   | 0     | [GUID]  | FUTBOL           |

---

## Conclusión
Los registros antiguos guardan directamente el padre (Padre=1), mientras que los registros nuevos guardan el hijo (Padre=0) con referencia al padre a través de IdPadre.
