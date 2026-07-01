# Documentación de Migración - Tabla PrecioPromo

## Información de Conexión

### Servidor SQL Server
- **IP**: 192.168.1.254
- **Usuario**: user
- **Password**: Mepryl22
- **Versión SQL Server**: 2014 Express Edition (12.0.2269.0)

### Bases de Datos
- **Origen**: 17dejunio
- **Destino**: MEPRYLv2.1

## Estado de Tabla `PrecioPromo`

### En 17dejunio
- **Estado**: ✅ EXISTE
- **Registros**: 1812
- **Columnas**: 12

### En MEPRYLv2.1
- **Estado**: ❌ NO EXISTE
- **Error**: El nombre de objeto 'PrecioPromo' no es válido

## Estructura de Tabla en 17dejunio

| Columna | Tipo | Nullable | Longitud |
|---------|------|----------|----------|
| id | int | NO | NULL |
| idEspecialidad | uniqueidentifier | NO | NULL |
| Descripcion | varchar | NO | 256 |
| Mes | int | NO | NULL |
| Anio | int | NO | NULL |
| PrecioPromo | decimal | NO | NULL |
| Seña | decimal | YES | NULL |
| LlevaPlanilla | bit | NO | NULL |
| ObservacionesExtra | varchar | YES | 200 |
| CoeficienteIndividual | decimal | YES | NULL |
| FechaModificacion | datetime | YES | NULL |
| Eliminado | bit | YES | NULL |

## Consideraciones para la Migración

1. **Crear tabla** `PrecioPromo` en MEPRYLv2.1
2. **Migrar datos** desde 17dejunio (1812 registros)
3. **Definir primary key** en columna `id`
4. **Validar integridad** de datos después de la migración

## Script de Creación de Tabla

```sql
USE MEPRYLv2.1
GO

-- Crear tabla PrecioPromo
CREATE TABLE PrecioPromo (
    id int NOT NULL,
    idEspecialidad uniqueidentifier NOT NULL,
    Descripcion varchar(256) NOT NULL,
    Mes int NOT NULL,
    Anio int NOT NULL,
    PrecioPromo decimal NOT NULL,
    Seña decimal NULL,
    LlevaPlanilla bit NOT NULL,
    ObservacionesExtra varchar(200) NULL,
    CoeficienteIndividual decimal NULL,
    FechaModificacion datetime NULL,
    Eliminado bit NULL,
    CONSTRAINT PK_PrecioPromo PRIMARY KEY (id)
);
GO
```

## Script de Migración de Datos

### Opción 1: Usar BCP (Bulk Copy Program) - Recomendado para grandes volúmenes

#### Paso 1: Exportar datos desde 17dejunio
```bash
bcp "SELECT id, idEspecialidad, Descripcion, Mes, Anio, PrecioPromo, Seña, LlevaPlanilla, ObservacionesExtra, CoeficienteIndividual, FechaModificacion, Eliminado FROM 17dejunio.dbo.PrecioPromo" queryout C:\Mepryl4.2\PrecioPromo_data.txt -c -t "," -S "192.168.1.254" -U "user" -P "Mepryl22"
```

#### Paso 2: Importar datos a MEPRYLv2.1
```bash
bcp MEPRYLv2.1.dbo.PrecioPromo in C:\Mepryl4.2\PrecioPromo_data.txt -c -t "," -S "192.168.1.254" -U "user" -P "Mepryl22"
```

### Opción 2: Generar Script de INSERT desde 17dejunio

```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "17dejunio" -Q "SELECT 'INSERT INTO PrecioPromo (id, idEspecialidad, Descripcion, Mes, Anio, PrecioPromo, Seña, LlevaPlanilla, ObservacionesExtra, CoeficienteIndividual, FechaModificacion, Eliminado) VALUES (' + CAST(id AS varchar) + ', ''' + CAST(idEspecialidad AS varchar) + ''', ''' + REPLACE(Descripcion, '''', '''''') + ''', ' + CAST(Mes AS varchar) + ', ' + CAST(Anio AS varchar) + ', ' + CAST(PrecioPromo AS varchar) + ', ' + ISNULL(CAST(Seña AS varchar), 'NULL') + ', ' + CAST(LlevaPlanilla AS varchar) + ', ''' + ISNULL(REPLACE(ObservacionesExtra, '''', ''''''), '') + ''', ' + ISNULL(CAST(CoeficienteIndividual AS varchar), 'NULL') + ', ' + ISNULL(CONVERT(varchar, FechaModificacion, 120), 'NULL') + ', ' + ISNULL(CAST(Eliminado AS varchar), 'NULL') + ');' FROM PrecioPromo" -o C:\Mepryl4.2\insert_precio_promo.sql
```

Luego ejecutar el script generado:
```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "MEPRYLv2.1" -i C:\Mepryl4.2\insert_precio_promo.sql
```

## Comandos Útiles

### Ver estructura en 17dejunio
```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "17dejunio" -Q "SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PrecioPromo' ORDER BY ORDINAL_POSITION"
```

### Ver datos en 17dejunio
```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "17dejunio" -Q "SELECT * FROM PrecioPromo"
```

### Verificar si existe en MEPRYLv2.1
```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "MEPRYLv2.1" -Q "SELECT * FROM PrecioPromo"
```

### Contar registros en 17dejunio
```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "17dejunio" -Q "SELECT COUNT(*) FROM PrecioPromo"
```

## Comando para Crear Tabla desde CMD

```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "MEPRYLv2.1" -Q "CREATE TABLE PrecioPromo (id int NOT NULL, idEspecialidad uniqueidentifier NOT NULL, Descripcion varchar(256) NOT NULL, Mes int NOT NULL, Anio int NOT NULL, PrecioPromo decimal NOT NULL, Seña decimal NULL, LlevaPlanilla bit NOT NULL, ObservacionesExtra varchar(200) NULL, CoeficienteIndividual decimal NULL, FechaModificacion datetime NULL, Eliminado bit NULL, CONSTRAINT PK_PrecioPromo PRIMARY KEY (id))"
```

## Notas Importantes
- La tabla tiene 1812 registros en 17dejunio
- Es una tabla de precios promocionales por especialidad, mes y año
- Incluye información de seña, planillas y coeficientes individuales
- Tiene campo de eliminado lógico (bit)

## Estado de Documentación
- **Fecha**: 01/07/2026
- **Estado**: Pendiente de migración
- **Acciones requeridas**: Crear tabla y migrar 1812 registros
