# Documentación de Migración - Tabla Especialidad

## Información de Conexión

### Servidor SQL Server
- **IP**: 192.168.1.254
- **Usuario**: user
- **Password**: Mepryl22
- **Versión SQL Server**: 2014 Express Edition (12.0.2269.0)

### Bases de Datos
- **Origen**: MEPRYLv2.1
- **Destino**: 17dejunio

## Diferencias en Estructura de Tabla `especialidad`

### Columnas en MEPRYLv2.1 (17 columnas)
| Columna | Tipo | Nullable |
|---------|------|----------|
| id | uniqueidentifier | NO |
| codigo | varchar(50) | YES |
| descripcion | varchar(256) | NO |
| registroBLOB | varchar(256) | YES |
| actualizacion_local | datetime | YES |
| operacion_local | varchar(10) | YES |
| sincronizado | datetime | YES |
| serverID | uniqueidentifier | YES |
| idMotivoConsulta | int | NO |
| precioBase | decimal | YES |
| orden | int | YES |
| tipo | int | YES |
| descripcionInformes | varchar(150) | YES |
| Padre | bit | YES |
| IdPadre | varchar(50) | YES |
| estado | int | NO |
| precioLista | decimal | NO |

### Columnas en 17dejunio (18 columnas)
| Columna | Tipo | Nullable |
|---------|------|----------|
| id | uniqueidentifier | NO |
| codigo | varchar(50) | YES |
| descripcion | varchar(256) | NO |
| registroBLOB | varchar(256) | YES |
| actualizacion_local | datetime | YES |
| operacion_local | varchar(10) | YES |
| sincronizado | datetime | YES |
| serverID | uniqueidentifier | YES |
| idMotivoConsulta | int | NO |
| precioBase | decimal | YES |
| orden | int | YES |
| tipo | int | YES |
| descripcionInformes | varchar(150) | YES |
| Padre | bit | YES |
| IdPadre | varchar(50) | YES |
| estado | int | NO |
| precioLista | decimal | NO |
| **IPCBase** | **decimal** | **YES** |

## Diferencia Detectada

### Columna Adicional en Destino (17dejunio)
- **IPCBase** (decimal, nullable) - Esta columna NO existe en la base de datos origen MEPRYLv2.1

## Consideraciones para la Migración

1. **Agregar columna IPCBase** a MEPRYLv2.1 antes de migrar datos
2. **Definir valor por defecto** para IPCBase en registros existentes de MEPRYLv2.1
3. **Verificar datos** en 17dejunio para entender el propósito de IPCBase
4. **Validar integridad** de datos después de la migración

## Comandos Útiles

### Ver columnas de especialidad en MEPRYLv2.1
```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "MEPRYLv2.1" -Q "SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'especialidad' ORDER BY ORDINAL_POSITION"
```

### Ver columnas de especialidad en 17dejunio
```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "17dejunio" -Q "SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'especialidad' ORDER BY ORDINAL_POSITION"
```

### Ver datos de especialidad en MEPRYLv2.1
```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "MEPRYLv2.1" -Q "SELECT * FROM especialidad"
```

### Ver datos de especialidad en 17dejunio
```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "17dejunio" -Q "SELECT * FROM especialidad"
```

## Estado de Documentación
- **Fecha**: 01/07/2026
- **Estado**: Pendiente de migración
- **Acciones requeridas**: Ninguna por ahora (solo documentación)
