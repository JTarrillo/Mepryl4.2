# Guía de Conexión SQL Server y Análisis del Paciente Varela

## Conexión a SQL Server desde Línea de Comandos

### Comandos Básicos de Conexión

#### 1. Conexión Simple (Base de datos Master por defecto)
```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -Q "SELECT 'TEST CONNECTION' as Status"
```

#### 2. Conexión a Base de Datos Específica (MEPRYLv2.1)
```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "MEPRYLv2.1" -Q "TU_CONSULTA_AQUI"
```

#### 3. Listar Bases de Datos Disponibles
```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -Q "SELECT name FROM sys.databases WHERE name NOT IN ('master','tempdb','model','msdb') ORDER BY name"
```

#### 4. Listar Tablas de una Base de Datos
```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "MEPRYLv2.1" -Q "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME"
```

### Parámetros de Conexión

| Parámetro | Descripción | Valor |
|-----------|-------------|-------|
| `-S` | Servidor SQL | 192.168.1.254 |
| `-U` | Usuario | user |
| `-P` | Contraseña | Mepryl22 |
| `-d` | Base de datos | MEPRYLv2.1 |
| `-Q` | Ejecutar consulta | "SQL_QUERY" |

### Errores Comunes y Soluciones

#### Error: "El nombre de objeto no es válido"
**Causa:** Conectado a la base de datos incorrecta (master en lugar de MEPRYLv2.1)
**Solución:** Especificar la base de datos correcta con `-d "MEPRYLv2.1"`

#### Error: "Login failed for user"
**Causa:** Credenciales incorrectas o base de datos no accesible
**Solución:** Verificar credenciales y nombre de base de datos

---

## Análisis del Paciente: VARELA BENICIO WILLIAM ELIEL

### Datos del Paciente

| Campo | Valor PDF | Valor Base de Datos | Estado |
|-------|-----------|---------------------|--------|
| **DNI** | 55676837 | 55676837 | ✅ Coincide |
| **Nombre Completo** | VARELA BENICIO WILLIAM ELIEL | VARELA BENICIO WILLIAM ELIEL | ✅ Coincide |
| **Fecha Nacimiento** | 9/7/2016 | (No visible en consulta) | ⚠️ Por verificar |
| **N° Examen** | 208 | 208 | ✅ Coincide |
| **Fecha Examen** | 5/9/2025 | 2025-05-09 | ✅ Coincide |
| **Club** | A. METROPOLITANA QUILMES DECANO | NULL | ❌ Diferencia |
| **Deporte** | No especificado | FUTBOL METRO | ⚠️ Diferencia |

### Consulta SQL Utilizada

```sql
SELECT 
    'VARELA CORREGIDO' as Estado,
    c.id as ConsultaID,
    c.fecha as FechaExamen,
    c.identificador as NroExamen,
    p.dni as DNI,
    p.apellido + ' ' + p.nombres as PacienteCompleto,
    e.descripcion as Deporte,
    cl.descripcion as Club
FROM dbo.Consulta c 
INNER JOIN dbo.Paciente p ON c.pacienteID = p.id
INNER JOIN dbo.TipoExamenDePaciente tep ON c.id = tep.idConsulta
INNER JOIN dbo.Especialidad e ON tep.idEspecialidad = e.id
LEFT JOIN dbo.Club cl ON p.clubID = cl.id
WHERE p.dni = '55676837'
  AND c.tipo = 'P'
```

### Resultados Obtenidos

```
Estado           ConsultaID                           FechaExamen            NroExamen                                          DNI                                                PacienteCompleto                                      Deporte                         Club
---------------- ------------------------------------ ----------------------- -------------------------------------------------- -------------------------------------------------- ------------------------------------------------------ ----------------------------- ---------------
VARELA CORREGIDO 38F89CB1-3BB6-45A9-B5CB-CAC5E915A553 2025-05-09 00:00:00.000 208                                                55676837                                           VARELA BENICIO WILLIAM ELIEL                           FUTBOL METRO                    NULL
```

### Análisis de Diferencias

#### 1. Club No Asignado (NULL)
- **PDF indica:** "A. METROPOLITANA QUILMES DECANO"
- **Base de datos:** NULL
- **Impacto:** Puede causar que el paciente no aparezca en búsquedas filtradas por club

#### 2. Deporte Diferente
- **PDF:** No especifica claramente
- **Base de datos:** "FUTBOL METRO"
- **Impacto:** Menor, pero podría afectar filtros por deporte

### Posibles Causas del Problema de Visualización

Basado en el análisis de los archivos de diagnóstico existentes:

#### 1. Filtros en la Interfaz
El código en `frmBusquedaExamen.cs` aplica filtros adicionales después de la consulta SQL:
- **Filtro de Liga:** `obtenerFiltroString()` línea 406-408
- **Filtro de Club:** Si `cboC.SelectedIndex != 0` aplica filtro por club
- **Filtro de Validación:** Similar al anterior

#### 2. Club NULL y Filtros
Si el combo de club no está en "TODOS", el filtro:
```sql
Club like '%" + cboC.SelectedValue.ToString() + "%'
```
No encontrará registros con club NULL.

#### 3. ExamenPreventiva
El paciente necesita tener un registro en la tabla `ExamenPreventiva` para aparecer en la interfaz.

### Consultas de Diagnóstico Adicionales

#### Verificar Club del Paciente
```sql
SELECT 
    p.dni,
    p.apellido + ' ' + p.nombres as Paciente,
    cl.descripcion as Club
FROM dbo.Paciente p
LEFT JOIN dbo.Club cl ON p.clubID = cl.id
WHERE p.dni = '55676837'
```

#### Verificar ExamenPreventiva
```sql
SELECT 
    tep.id,
    ep.idTipoExamen,
    CASE 
        WHEN ep.idTipoExamen IS NOT NULL THEN 'EXISTE'
        ELSE 'NO EXISTE'
    END as EstadoExamenPreventiva
FROM dbo.TipoExamenDePaciente tep
LEFT JOIN dbo.ExamenPreventiva ep ON tep.id = ep.idTipoExamen
WHERE tep.idConsulta = '38F89CB1-3BB6-45A9-B5CB-CAC5E915A553'
```

#### Simular Búsqueda Completa
```sql
SELECT 
    tep.id as IdTE,
    c.id as IdC, 
    CONVERT(date, c.fecha) as Fecha, 
    c.identificador as 'Nº Examen', 
    p.dni as DNI,
    (p.apellido + ' ' + p.nombres) as Paciente, 
    tep.rm as RM, 
    tep.imp as IMP, 
    tep.inf as INF,
    tep.mail as Mail, 
    tep.dictAut, 
    tep.ImpLab, 
    p.fechaNacimiento, 
    tep.cons 
FROM dbo.Consulta c 
INNER JOIN dbo.TipoExamenDePaciente tep ON c.id = tep.idConsulta 
INNER JOIN dbo.Paciente p ON c.pacienteID = p.id
WHERE c.tipo = 'P' 
  AND CONVERT(date,c.fecha) >= CONVERT(date,'2025-09-05',105) 
  AND CONVERT(date,c.fecha) <= CONVERT(date,'2025-09-05',105) 
  AND CONVERT(varchar,p.dni) LIKE '%55676837%'
ORDER BY CONVERT(int,c.identificador) ASC, c.fecha ASC
```

### Recomendaciones

1. **Actualizar Club del Paciente:** Asignar el club correcto en la base de datos
2. **Verificar Filtros:** Asegurar que los combos estén en "TODAS" al buscar
3. **Revisar ExamenPreventiva:** Confirmar que exista el registro correspondiente
4. **Depurar Código:** Revisar el método `obtenerFiltroString()` en `frmBusquedaExamen.cs`

---

## Resumen Ejecutivo

**✅ Paciente encontrado en base de datos**
- DNI: 55676837
- Nombre: VARELA BENICIO WILLIAM ELIEL
- Examen: 208 del 05/09/2025

**❌ Problemas identificados**
- Club no asignado (NULL en BD)
- Posibles filtros interfaz excluyendo el registro

**🔧 Próximos pasos**
1. Corregir asignación de club
2. Verificar ExamenPreventiva
3. Probar búsqueda con filtros desactivados

---

*Documento generado: 7 de mayo de 2026*
*Base de datos: MEPRYLv2.1 en 192.168.1.254*
