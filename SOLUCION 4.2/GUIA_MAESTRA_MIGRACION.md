# Guía Maestra de Migración: Sincronización Estructural y de Datos

Esta guía detalla el orden exacto de consultas y modificaciones realizadas durante la "Prueba Piloto" para nivelar una base de datos desactualizada a la versión **Master (3dejunio)**. Sigue este orden para evitar errores de dependencias.

## Fase 1: Sincronización Estructural (Tablas)

### 1. Actualizar Tabla `Especialidad`
Asegura la jerarquía de subtipos y estados.
```sql
ALTER TABLE dbo.Especialidad ADD Padre BIT DEFAULT 0;
ALTER TABLE dbo.Especialidad ADD IdPadre UNIQUEIDENTIFIER NULL;
ALTER TABLE dbo.Especialidad ADD estado BIT DEFAULT 1;
ALTER TABLE dbo.Especialidad ADD precioLista DECIMAL(18, 2) DEFAULT 0;
ALTER TABLE dbo.Especialidad ADD IPCBase DECIMAL(18, 2) DEFAULT 0;
```

### 2. Actualizar Tabla `TipoExamenDePaciente`
Prepara la tabla para recibir cobros parciales y precios de lista.
```sql
ALTER TABLE dbo.TipoExamenDePaciente ADD seña DECIMAL(18, 2) DEFAULT 0;
ALTER TABLE dbo.TipoExamenDePaciente ADD precioLista DECIMAL(18, 2) DEFAULT 0;
```

### 3. Crear Tabla `PrecioPublico`
Fundamental para la segunda pestaña de precios.
```sql
CREATE TABLE [dbo].[PrecioPublico](
    [id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [idEspecialidad] [uniqueidentifier] NOT NULL,
    [Descripcion] [varchar](256) NOT NULL,
    [Mes] [int] NOT NULL,
    [Anio] [int] NOT NULL,
    [PrecioLista] [decimal](18, 2) NOT NULL,
    [PrecioPromo] [decimal](18, 2) NOT NULL,
    [Seña] [decimal](18, 2) NULL DEFAULT 0,
    [Coeficiente] [decimal](18, 4) NULL,
    [CoeficienteIndividual] [decimal](18, 4) NULL,
    [LlevaPlanilla] [bit] NOT NULL DEFAULT 0,
    [ObservacionesExtra] [varchar](200) NULL,
    [FechaModificacion] [datetime] NULL DEFAULT GETDATE(),
    [Eliminado] [bit] NULL DEFAULT 0
);
```

### 4. Crear Tabla `PrecioPromo`
Tabla espejo para la gestión promocional.
```sql
CREATE TABLE [dbo].[PrecioPromo](
    [id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [idEspecialidad] [uniqueidentifier] NOT NULL,
    [Descripcion] [varchar](256) NOT NULL,
    [Mes] [int] NOT NULL,
    [Anio] [int] NOT NULL,
    [PrecioPromo] [decimal](18, 2) NOT NULL,
    [Seña] [decimal](18, 2) NULL DEFAULT 0,
    [LlevaPlanilla] [bit] NOT NULL DEFAULT 0,
    [ObservacionesExtra] [varchar](200) NULL,
    [CoeficienteIndividual] [decimal](18, 4) NULL DEFAULT 0,
    [FechaModificacion] [datetime] NULL DEFAULT GETDATE(),
    [Eliminado] [bit] NULL DEFAULT 0
);
```

### 5. Crear Tabla `ConfigPrecioEspecialidad` y `ObservacionPredefinida`
```sql
CREATE TABLE [dbo].[ConfigPrecioEspecialidad](
    [idEspecialidad] [uniqueidentifier] NOT NULL PRIMARY KEY,
    [Seña] [decimal](18, 2) NULL DEFAULT 0,
    [LlevaPlanilla] [bit] NOT NULL DEFAULT 0,
    [Observaciones] [varchar](200) NULL,
    [FechaModificacion] [datetime] NULL DEFAULT GETDATE()
);

CREATE TABLE [dbo].[ObservacionPredefinida](
    [id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [texto] [varchar](200) NOT NULL,
    [descripcion] [varchar](200) NULL,
    [activo] [bit] NOT NULL DEFAULT 1
);
```

---

## Fase 2: Procedimientos Almacenados (Lógica)

### 1. Sincronizar `sp_TipoExamenDePaciente_Add` (Igualar a 3dejunio)
*Importante: Debe usar @seña con Ñ.*
```sql
CREATE PROCEDURE dbo.sp_TipoExamenDePaciente_Add
    @idConsulta uniqueidentifier, @idTurno uniqueidentifier, @modificado varchar(3),
    @idEspecialidad uniqueidentifier, @importe decimal(18,2), @factClub varchar(1),
    @precioLista decimal(18,2), @seña decimal(18,2) = 0, @retorno uniqueidentifier OUTPUT
AS
BEGIN
    INSERT INTO dbo.TipoExamenDePaciente (..., seña, precioLista) 
    VALUES (..., @seña, @precioLista);
    SET @retorno = SCOPE_IDENTITY(); -- o el ID generado
END
```

### 2. Sincronizar `sp_TipoExamenDePaciente_Update`
```sql
CREATE PROCEDURE dbo.sp_TipoExamenDePaciente_Update
    @idTurno uniqueidentifier, @valor varchar(3), @importe decimal(18,2),
    @factClub varchar(1), @precioLista decimal(18,2), @seña decimal(18,2) = 0
AS
BEGIN
    UPDATE dbo.TipoExamenDePaciente 
    SET precioExamen = @importe, precioLista = @precioLista, seña = @seña
    WHERE idTurno = @idTurno;
END
```

---

## Fase 3: Migración de Datos (Copia Fiel)

### 1. Migrar `PrecioPromo`
```sql
TRUNCATE TABLE [Destino].[dbo].[PrecioPromo];
INSERT INTO [Destino].[dbo].[PrecioPromo] (...)
SELECT ... FROM [3dejunio].[dbo].[PrecioPromo];
```

### 2. Migrar `PrecioPublico`
```sql
TRUNCATE TABLE [Destino].[dbo].[PrecioPublico];
INSERT INTO [Destino].[dbo].[PrecioPublico] (...)
SELECT ... FROM [3dejunio].[dbo].[PrecioPublico];
```

---

## Fase 4: Control de Calidad (Checklist Final)

1.  **Validar Ñ**: Ejecutar `SELECT name FROM sys.columns WHERE name LIKE 'Se%a'` para asegurar que no se haya corrompido el nombre a `SeÃ±a`.
2.  **Validar SPs**: Ejecutar `EXEC sp_helptext 'nombre_procedimiento'` y comparar línea a línea con la base 3dejunio.
3.  **Probar Agenda**: Cargar un paciente laboral y verificar que `ppLab` no sea nulo y los precios se muestren correctamente.

> **Nota de Seguridad**: Siempre realizar un Backup antes de ejecutar la Fase 1.
