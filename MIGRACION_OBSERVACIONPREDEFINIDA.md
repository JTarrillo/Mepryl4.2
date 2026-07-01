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

```sql
USE MEPRYLv2.1
GO

-- Insertar datos desde 17dejunio
INSERT INTO ObservacionPredefinida (id, texto, descripcion, activo)
VALUES 
    (2, 'PERDIÓ LA PROMO', 'APTO BASICO', 1),
    (3, 'SE FACT. A LA EMPRESA', 'REQ ESTUDIOS', 1);
GO
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

## Comando Completo para Ejecutar desde CMD

```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "MEPRYLv2.1" -Q "CREATE TABLE ObservacionPredefinida (id int NOT NULL, texto varchar(200) NOT NULL, descripcion varchar(200) NULL, activo bit NOT NULL, CONSTRAINT PK_ObservacionPredefinida PRIMARY KEY (id))"
```

```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "MEPRYLv2.1" -Q "INSERT INTO ObservacionPredefinida (id, texto, descripcion, activo) VALUES (2, 'PERDIÓ LA PROMO', 'APTO BASICO', 1), (3, 'SE FACT. A LA EMPRESA', 'REQ ESTUDIOS', 1)"
```

## Estado de Documentación
- **Fecha**: 01/07/2026
- **Estado**: Pendiente de migración
- **Acciones requeridas**: Crear tabla y migrar datos
