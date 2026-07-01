# Script de Migración - Agregar Columna IPCBase

## Objetivo
Actualizar la base de datos de producción `MEPRYLv2.1` para que tenga la misma estructura que `17dejunio` agregando la columna `IPCBase`.

## Consulta SQL para Ejecutar en MEPRYLv2.1

```sql
USE MEPRYLv2.1
GO

-- Agregar columna IPCBase a la tabla especialidad
ALTER TABLE especialidad
ADD IPCBase decimal NULL;
GO
```

## Verificación

### Verificar que la columna fue agregada correctamente
```sql
USE MEPRYLv2.1
GO

SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'especialidad' 
ORDER BY ORDINAL_POSITION
GO
```

### Verificar estructura completa (debe tener 18 columnas)
```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "MEPRYLv2.1" -Q "SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'especialidad' ORDER BY ORDINAL_POSITION"
```

## Comando para Ejecutar desde CMD

```bash
sqlcmd -S "192.168.1.254" -U "user" -P "Mepryl22" -d "MEPRYLv2.1" -Q "ALTER TABLE especialidad ADD IPCBase decimal NULL"
```

## Notas Importantes
- La columna `IPCBase` es nullable (acepta NULL)
- Tipo de dato: decimal
- Esta columna existe en `17dejunio` y faltaba en `MEPRYLv2.1`
- Después de ejecutar, ambas bases de datos tendrán la misma estructura (18 columnas)

## Estado
- **Fecha**: 01/07/2026
- **Base de datos destino**: MEPRYLv2.1
- **Acción**: Pendiente de ejecución
