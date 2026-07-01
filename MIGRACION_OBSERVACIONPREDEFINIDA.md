# Documentación de Migración - Tabla ObservacionPredefinida

## Información de Conexión

### Servidor SQL Server
- **IP**: 192.168.1.254
- **Usuario**: user
- **Password**: Mepryl22
- **Versión SQL Server**: 2014 Express Edition (12.0.2269.0)

### Bases de Datos
- **Origen**: 17dejunio
- **Destino**: MEPRYLv2.1

## Estado de Tabla `ObservacionPredefinida`

### En 17dejunio
- **Estado**: ✅ EXISTE
- **Registros**: 2
- **Columnas**: 4

### En MEPRYLv2.1
- **Estado**: ❌ NO EXISTE
- **Error**: El nombre de objeto 'ObservacionPredefinida' no es válido

## Estructura de Tabla en 17dejunio

| Columna | Tipo | Nullable | Longitud |
|---------|------|----------|----------|
| id | int | NO | NULL |
| texto | varchar | NO | 200 |
| descripcion | varchar | YES | 200 |
| activo | bit | NO | NULL |

## Datos Existentes en 17dejunio

| id | texto | descripcion | activo |
|----|-------|-------------|--------|
| 2 | PERDIÓ LA PROMO | APTO BASICO | 1 |
| 3 | SE FACT. A LA EMPRESA | REQ ESTUDIOS | 1 |

## Consideraciones para la Migración

1. **Crear tabla** `ObservacionPredefinida` en MEPRYLv2.1
2. **Migrar datos** desde 17dejunio (2 registros)
3. **Definir primary key** en columna `id`
4. **Validar integridad** de datos después de la migración

## Script de Creación de Tabla

```sql
USE MEPRYLv2.1
GO

-- Crear tabla ObservacionPredefinida
CREATE TABLE ObservacionPredefinida (
    id int NOT NULL,
    texto varchar(200) NOT NULL,
    descripcion varchar(200) NULL,
    activo bit NOT NULL,
    CONSTRAINT PK_ObservacionPredefinida PRIMARY KEY (id)
);
GO
```

## Script de Migración de Datos

### Opción 1: Usar BCP (Bulk Copy Program) - Recomendado para grandes volúmenes

#### Paso 1: Exportar datos desde 17dejunio
```bash
bcp "SELECT id, texto, descripcion, activo FROM 17dejunio.dbo.ObservacionPredefinida" queryout C:\Mepryl4.2\ObservacionPredefinida_data.txt -c -t "," -S "192.168.1.254" -U "user" -P "Mepryl22"
```

#### Paso 2: Importar datos a MEPRYLv2.1
```bash
bcp MEPRYLv2.1.dbo.ObservacionPredefinida in C:\Mepryl4.2\ObservacionPredefinida_data.txt -c -t "," -S "192.168.1.254" -U "user" -P "Mepryl22"
```

### Opción 2: Generar Script de INSERT desde 17dejunio

```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "17dejunio" -Q "SELECT 'INSERT INTO ObservacionPredefinida (id, texto, descripcion, activo) VALUES (' + CAST(id AS varchar) + ', ''' + REPLACE(texto, '''', '''''') + ''', ''' + ISNULL(REPLACE(descripcion, '''', ''''''), '') + ''', ' + CAST(activo AS varchar) + ');' FROM ObservacionPredefinida" -o C:\Mepryl4.2\insert_observacion_predefinida.sql
```

Luego ejecutar el script generado:
```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "MEPRYLv2.1" -i C:\Mepryl4.2\insert_observacion_predefinida.sql
```

## Comandos Útiles

### Ver estructura en 17dejunio
```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "17dejunio" -Q "SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'ObservacionPredefinida' ORDER BY ORDINAL_POSITION"
```

### Ver datos en 17dejunio
```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "17dejunio" -Q "SELECT * FROM ObservacionPredefinida"
```

### Verificar si existe en MEPRYLv2.1
```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "MEPRYLv2.1" -Q "SELECT * FROM ObservacionPredefinida"
```

### Verificar tablas en MEPRYLv2.1
```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "MEPRYLv2.1" -Q "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME"
```

## Comando para Crear Tabla desde CMD

```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "MEPRYLv2.1" -Q "CREATE TABLE ObservacionPredefinida (id int NOT NULL, texto varchar(200) NOT NULL, descripcion varchar(200) NULL, activo bit NOT NULL, CONSTRAINT PK_ObservacionPredefinida PRIMARY KEY (id))"
```

## Estado de Documentación
- **Fecha**: 01/07/2026
- **Estado**: Pendiente de migración
- **Acciones requeridas**: Crear tabla y migrar datos
