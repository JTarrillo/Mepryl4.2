# Investigación pipi - DNI 50781125

## Objetivo
Documentar las consultas SQL ejecutadas en la base de datos `pipi` y determinar la especialidad/subtipo asignada al examen de paciente `50781125`.

---

## 1) Inspección de columnas relevantes

```sql
USE pipi;
SELECT COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME IN ('Especialidad','TipoExamenDePaciente','EstudiosPorTipoExamen','EstudiosPorTipoEspecialidad')
ORDER BY TABLE_NAME, ORDINAL_POSITION;
```

Resultado relevante:
- `Especialidad` tiene columnas: `id`, `codigo`, `descripcion`, `Padre`, `IdPadre`, `precioBase`, `precioLista`, entre otras.
- `TipoExamenDePaciente` tiene columnas: `id`, `idConsulta`, `idTurno`, `idEspecialidad`, `precioExamen`, `precioLista`, `rm`, `imp`, `inf`, `factClub`, `mail`, `dictAut`, `impLab`, `cons`.

---

## 2) Inspección de columnas de tablas clave en pipi

```sql
USE pipi;
SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME IN ('Paciente','Consulta','TipoExamenDePaciente')
ORDER BY TABLE_NAME, ORDINAL_POSITION;
```

Resultado relevante:
- `Paciente` usa `dni`, `apellido`, `nombres`, `apellido2`.
- `Consulta` usa `pacienteID`, `nroOrden`, `tipo`, `fecha`, `idTurno`.
- `TipoExamenDePaciente` usa `idConsulta`, `idTurno`, `idEspecialidad`.

---

## 3) Paciente encontrado

```sql
USE pipi;
SELECT TOP 1 id, codigo, apellido, nombres, apellido2, dni, telefonos, celular
FROM dbo.Paciente
WHERE dni = '50781125';
```

Resultado:
- id: `DAA05175-B1DA-4537-9410-70983B97B1E2`
- codigo: `50781125`
- apellido: `PONCE`
- nombres: `PEDRO`
- apellido2: `NICOLAS`
- dni: `50781125`
- celular: `1160491726`

---

## 4) Consulta asociada al paciente

```sql
USE pipi;
SELECT TOP 10 id, codigo, tipo, fecha, nroOrden, identificador, pacienteID, observaciones, idTurno, eliminado, Revisado
FROM dbo.Consulta
WHERE pacienteID = (SELECT id FROM dbo.Paciente WHERE dni='50781125');
```

Resultado:
- id: `3ED2EE95-DDE3-4DA8-8872-A7F41DF3C8BE`
- codigo: `` (vacío)
- tipo: `P`
- fecha: `2025-06-13 08:54:34.587`
- nroOrden: `10`
- identificador: `207`
- pacienteID: `DAA05175-B1DA-4537-9410-70983B97B1E2`
- idTurno: `86F38AC2-9F09-49A2-BC25-27F69812B09E`
- Revisado: `1`

---

## 5) Registro de TipoExamenDePaciente

```sql
USE pipi;
SELECT TOP 10 id, idConsulta, idTurno, idEspecialidad, precioExamen, precioLista, rm, imp, inf, cons
FROM dbo.TipoExamenDePaciente
WHERE idConsulta IN (SELECT id FROM dbo.Consulta WHERE pacienteID=(SELECT id FROM dbo.Paciente WHERE dni='50781125'));
```

Resultado:
- id: `7DDD6DAB-499F-4E9E-B083-A8395BD5A372`
- idConsulta: `3ED2EE95-DDE3-4DA8-8872-A7F41DF3C8BE`
- idTurno: `86F38AC2-9F09-49A2-BC25-27F69812B09E`
- idEspecialidad: `60E94892-6F59-4202-A966-884FD71A5D8B`
- precioExamen: `40000.00`
- precioLista: `NULL`
- rm: `NULL`
- imp: `NU`
- inf: `1`
- cons: `NUL`

---

## 6) Especialidad / Subtipo investigada

```sql
USE pipi;
SELECT e.id, e.codigo, e.descripcion, e.Padre, e.IdPadre,
       parent.codigo AS PadreCodigo, parent.descripcion AS PadreDescripcion
FROM dbo.Especialidad e
LEFT JOIN dbo.Especialidad parent ON e.IdPadre = parent.id
WHERE e.id = '60E94892-6F59-4202-A966-884FD71A5D8B';
```

Resultado:
- id: `60E94892-6F59-4202-A966-884FD71A5D8B`
- codigo: `38`
- descripcion: `FUTBOL METRO`
- Padre: `0`
- IdPadre: `D6A02B46-FB57-44E1-9469-6315FC8236EF`
- PadreCodigo: `1001`
- PadreDescripcion: `FUTBOL`

---

## Conclusión
- El paciente `50781125` es `PONCE PEDRO NICOLAS`.
- Su consulta `3ED2EE95-DDE3-4DA8-8872-A7F41DF3C8BE` corresponde a `tipo = P` y `identificador = 207`.
- El registro de examen (`TipoExamenDePaciente`) vinculado usa `idEspecialidad = 60E94892-6F59-4202-A966-884FD71A5D8B`.
- Esa especialidad es `FUTBOL METRO`.
- `FUTBOL METRO` tiene padre `FUTBOL`, por lo que en la jerarquía de especialidades sería un subtipo de `FUTBOL`.

## Observaciones
- En `pipi`, la tabla de especialidades almacena el árbol de especialidad/subtipo usando `IdPadre` y la bandera `Padre`.
- Para este registro, el `subtipo` real es `FUTBOL METRO` dentro de la rama `FUTBOL`.
