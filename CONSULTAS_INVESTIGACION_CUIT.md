# Consultas SQL - Investigación para Agregar CUIT en Consolidación Laboral

## Contexto
Se investigó la estructura de la base de datos para agregar el CUIT de la empresa en el nombre de los archivos consolidados laborales.

## Consultas Realizadas

### 1. Estructura de tabla PacienteLaboral
**Objetivo:** Verificar la estructura de la tabla de pacientes laborales

```sql
sp_columns PacienteLaboral
```

**Resultado:** Tabla con 16 columnas incluyendo id, apellido, nombres, dni, cuil, etc.

### 2. Estructura de tabla empresaPorTipoDeExamen
**Objetivo:** Verificar la tabla que relaciona tipos de examen con empresas

```sql
sp_columns empresaPorTipoDeExamen
```

**Resultado:** Tabla con 4 columnas:
- id (bigint, PK)
- idTipoExamen (uniqueidentifier, FK)
- idEmpresa (uniqueidentifier, FK)
- tarea (varchar(50))

### 3. Estructura de tabla Empresa
**Objetivo:** Verificar la estructura de la tabla de empresas

```sql
sp_columns Empresa
```

**Resultado:** Tabla con 50 columnas, incluyendo el campo cuit en la posición 4.

### 4. Orden de columnas en tabla Empresa
**Objetivo:** Identificar exactamente la posición del campo CUIT

```sql
SELECT COLUMN_NAME, ORDINAL_POSITION 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Empresa' 
ORDER BY ORDINAL_POSITION
```

**Resultado:** Confirmó que cuit está en la posición 4 (ordinal_position=4)

### 5. Consulta de prueba - Relación Paciente-Empresa
**Objetivo:** Verificar que un paciente laboral tenga una empresa asociada y obtener su CUIT

```sql
SELECT TOP 5 
    p.dni, 
    p.apellido, 
    p.nombres, 
    c.identificador, 
    emp.razonSocial, 
    emp.cuit 
FROM dbo.PacienteLaboral p 
INNER JOIN dbo.Consulta c ON p.id = c.pacienteID 
INNER JOIN dbo.TipoExamenDePaciente tep ON c.id = tep.idConsulta 
INNER JOIN dbo.empresaPorTipoDeExamen ete ON tep.id = ete.idTipoExamen 
INNER JOIN dbo.Empresa emp ON ete.idEmpresa = emp.id 
WHERE c.tipo != 'P' AND c.identificador = 'L1' AND p.dni = '13160854'
```

**Resultado:**
```
dni: 13160854
apellido: GARCIA CHAURERO
nombres: CARLOS EDUARDO
identificador: L1
razonSocial: KALPAKIAN HNOS S.A.
cuit: 30519547143
```

## Relación de Tablas Confirmada

```
Consulta → TipoExamenDePaciente → empresaPorTipoDeExamen → Empresa
   ↓              ↓                       ↓                      ↓
 pacienteID      idConsulta             idTipoExamen           idEmpresa
                                          ↓                       ↓
                                      idTipoExamen             cuit (posición 4)
```

## Cambios Implementados

### Modificación en Consulta SQL ConsolidarReportes.cs
Se agregaron los JOINs necesarios y el campo CUIT:

```sql
SELECT 
    CONVERT(date, c.fecha) as Fecha, 
    c.identificador AS 'Nº Examen', 
    p.dni,
    (p.apellido + ' ' + p.nombres) as 'Paciente', 
    '368' as 'Infantil Inicial', 
    item1 AS Clinico, 
    item37 AS Orina, 
    item38 AS RX, 
    item77 AS ECG, 
    item75 AS EEG, 
    Item72 AS Psico,
    item68 as Audio, 
    item70 AS Ergo, 
    item71 AS Eco, 
    item2 AS Oto, 
    item74 as Espiro, 
    item99 AS DorsalF, 
    REPLACE(REPLACE(REPLACE(emp.cuit, '-', ''), '.', ''), ',', '') AS CUIT,
    'IdTep' AS IdTep 
FROM dbo.Consulta c 
INNER JOIN dbo.PacienteLaboral p ON c.pacienteID = p.id
INNER JOIN dbo.TipoExamenDePaciente tep ON c.id = tep.idConsulta
INNER JOIN dbo.Especialidad e ON tep.idEspecialidad = e.id
INNER JOIN dbo.ConsultaLaboral cl ON tep.id = cl.idTipoExamen
INNER JOIN dbo.EstudiosPorExamen EE ON EE.idTipoExamen = tep.id
INNER JOIN dbo.empresaPorTipoDeExamen ete ON tep.id = ete.idTipoExamen
INNER JOIN dbo.Empresa emp ON ete.idEmpresa = emp.id
WHERE c.tipo != 'P' 
AND convert(date, c.fecha) >= convert(date, @FechaInicio, 105) 
AND convert(date, c.fecha) <= convert(date, @FechaFin, 105) 
AND c.identificador = @NroOrden 
AND p.dni = @DNI 
ORDER BY CONVERT(VARCHAR(10), c.fecha, 101), 
         convert(int, REPLACE(REPLACE(REPLACE(c.identificador, 'L', ''), 'CO', ''), 'EC', ''))
```

## Formato Final de Archivo Consolidado

**Formato Original:**
`L1 - 20365077 - 12082026 - VARELA MARIA LAURA.pdf`

**Formato con CUIT:**
`L1 - 20365077 - 12082026 - 30519547143 - VARELA MARIA LAURA.pdf`

Donde:
- L1: Número de orden del examen
- 20365077: DNI del paciente
- 12082026: Fecha (día-mes-año: 26-08-2026)
- 30519547143: CUIT de la empresa
- VARELA MARIA LAURA: Nombre del paciente

## Resolución de Problemas

### Problema 1: Índices de columnas desplazados
**Solución:** Al agregar la columna CUIT en el índice 6 del DataTable dtArchivosPDF, se actualizaron todos los índices de posición en las llamadas a métodos CargarArchivo (sumando 1 a cada índice).

### Problema 2: Caracteres inválidos en nombres de archivo
**Solución:** Se agregó limpieza de caracteres inválidos para nombres de archivo en el método PathArchivoConsolidado.

## Fecha de Implementación
26/08/2026

## Archivos Modificados
- `CapaDatosMepryl/ConsolidarReportes.cs`
- `CapaPresentacion/frmBusquedaLaboral.cs`
- `CapaNegocioMepryl/UtilidadesMepryl.cs`
