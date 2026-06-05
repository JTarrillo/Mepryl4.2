# Instrucciones de Conexión y Tabla PrecioPublico

## 1. Cadena de Conexión
```
Data Source=192.168.1.254;Persist Security Info=False;User ID=user;Password=Mepryl22;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name="SQL Server Management Studio";Command Timeout=30
```

## 2. Conexión via sqlcmd (CMD)
Para conectarse a la base de datos desde la línea de comandos:

```bash
sqlcmd -S 192.168.1.254 -U user -P Mepryl22 -d 3dejunio
```

## 3. Base de Datos
- **Nombre**: `3dejunio`

## 4. Tabla PrecioPublico

### Estructura
| Columna | Tipo | Nullable | Descripción |
|---------|------|----------|-------------|
| id | int | NO | Id principal |
| idEspecialidad | uniqueidentifier | NO | Id de la especialidad |
| Descripcion | varchar(256) | NO | Descripción |
| Mes | int | NO | Mes |
| Anio | int | NO | Año |
| FechaModificacion | datetime | YES | Fecha de modificación |
| Eliminado | bit | YES | Marca de eliminado |
| PrecioLista | decimal(18,2) | NO | Precio de lista |
| PrecioPromo | decimal(18,2) | NO | Precio promocional |
| LlevaPlanilla | bit | NO | ¿Lleva planilla? |
| ObservacionesExtra | varchar(200) | YES | Observaciones extra |
| Coeficiente | decimal(18,4) | YES | Coeficiente general |
| CoeficienteIndividual | decimal(18,4) | YES | Coeficiente individual |
| Seña | decimal(18,2) | YES | Seña |
| CoeficienteIndividual01 a CoeficienteIndividual11 | decimal(18,4) | YES | Coeficientes individuales por mes |

### Consultas útiles
- Ver todas las tablas:
  ```sql
  SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME;
  ```

- Ver estructura de PrecioPublico:
  ```sql
  SELECT COLUMN_NAME, DATA_TYPE, IS_NULLABLE, CHARACTER_MAXIMUM_LENGTH, NUMERIC_PRECISION, NUMERIC_SCALE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'PrecioPublico' ORDER BY ORDINAL_POSITION;
  ```

- Ver datos de PrecioPublico (últimos):
  ```sql
  SELECT TOP 20 * FROM PrecioPublico ORDER BY Anio DESC, Mes DESC;
  ```

## 5. Configuración del Proyecto
La clase `Configuracion.cs` en `LibreriasBase\Comunes\` ya ha sido actualizada para usar la cadena de conexión con todos los parámetros.
