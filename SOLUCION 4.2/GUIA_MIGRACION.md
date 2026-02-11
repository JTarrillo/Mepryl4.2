# Guía: Migrar Backup Mejorado a BD Original

## Resumen del Problema

Tu tabla `TipoExamen` tiene inconsistencias:
- **Duplicados** de especialidades con el mismo nombre pero diferente GUID
- **Referencias rotas** (IdPadre apuntando a IDs que no existen)
- **Valores incorrectos en EsPadre** (marcados como Padre cuando son Subtipos)

## Solución: Script SQL de Migración

Se ha creado el archivo: **`MIGRACION_BACKUP_A_ORIGINAL.sql`**

### ¿Qué hace el script?

1. **PASO 1:** Analiza problemas actuales
2. **PASO 2:** Corrige valores de `EsPadre` (1→0 para subtipos)
3. **PASO 3:** Actualiza referencias de `IdPadre` correctamente
4. **PASO 4:** Verifica que no haya referencias rotas
5. **PASO 5:** Proporciona opción de ROLLBACK

---

## Instrucciones de Ejecución

### Opción A: Ejecución SEGURA (RECOMENDADO)

```sql
-- 1. HACER BACKUP PRIMERO
BACKUP DATABASE [TuBaseDatos] 
TO DISK = 'C:\Backups\TipoExamen_Backup_2025-11-26.bak'

-- 2. Ejecutar script dentro de transacción
BEGIN TRANSACTION

-- 3. Pegar todo el contenido del MIGRACION_BACKUP_A_ORIGINAL.sql

-- 4. REVISAR los mensajes de PASO 4 (verificación)

-- 5. Si todo está bien:
COMMIT

-- 6. Si hay problemas:
-- ROLLBACK  -- Descomenta si necesitas deshacer
```

### Opción B: Ejecución Directa

```sql
-- Simplemente abre y ejecuta MIGRACION_BACKUP_A_ORIGINAL.sql en SQL Server Management Studio
```

---

## Verificación Post-Migración

### Ejecutar después de migrar:

```sql
-- 1. Ver estructura corregida
SELECT 
    IdTipoExamen,
    Numero,
    Nombre,
    EsPadre,
    IdPadre,
    CASE WHEN EsPadre = 1 THEN 'PADRE' ELSE 'Subtipo' END as Tipo
FROM TipoExamen
WHERE Nombre IN ('FUTBOL', 'RUGBY', 'ECOCARDIOGRAMA', 'BUZO')
ORDER BY Nombre, EsPadre DESC

-- 2. Contar padres y subtipos
SELECT 
    'EsPadre=1 (Padres)' as Tipo,
    COUNT(*) as Cantidad
FROM TipoExamen
WHERE EsPadre = 1
UNION ALL
SELECT 
    'EsPadre=0 (Subtipos)' as Tipo,
    COUNT(*) as Cantidad
FROM TipoExamen
WHERE EsPadre = 0

-- 3. Buscar referencias rotas (debe estar vacío)
SELECT *
FROM TipoExamen t1
WHERE EsPadre = 0 
  AND IdPadre IS NOT NULL
  AND IdPadre NOT IN (SELECT IdTipoExamen FROM TipoExamen)
```

---

## Cambios Principales

### Subtipos convertidos a EsPadre=0:

```
REPETICIONES → referencia correcta
LEY + AUDIOMETRIA → referencia correcta
INDICE DE TORG-PAVLOV → referencia correcta
PSICOTECNICO → referencia correcta
TRAUMATOLOGIA → referencia correcta
... y muchos más
```

### Ejemplos de correcciones:

| ID | Nombre | Anterior | Nuevo | IdPadre Anterior | IdPadre Nuevo |
|----|--------|----------|-------|------------------|---------------|
| 254110EB... | CONSULTORIO | EsPadre=0 | EsPadre=0 | E554A1AF... | AADF0EE7... |
| 5A89F848... | REPETICIONES | EsPadre=1 | EsPadre=0 | 0B4BD854... | FC32BF07... |
| 19160B7C... | TRAUMATOLOGIA | EsPadre=0 | EsPadre=0 | B7195C7F... | B1A9127D... |

---

## ⚠️ Precauciones Importantes

1. **Hacer BACKUP antes** - Es esencial
2. **Probar en ambiente de QA primero** - Si es posible
3. **Revisar PASO 4 del script** - Verificar no hay referencias rotas
4. **Usar transacción** - Para poder deshacer si hay problemas
5. **Validar datos después** - Ejecutar verificación post-migración

---

## Si algo sale mal

### Opción 1: Rollback (si está en transacción)
```sql
ROLLBACK
```

### Opción 2: Restaurar desde backup
```sql
RESTORE DATABASE [TuBaseDatos]
FROM DISK = 'C:\Backups\TipoExamen_Backup_2025-11-26.bak'
```

---

## Próximos Pasos Recomendados

1. ✅ Ejecutar migración
2. ✅ Verificar integridad
3. ✅ Probar eliminación de especialidades (sin subtipos)
4. ✅ Validar relaciones en aplicación
5. ✅ Documentar cambios en control de versiones

---

## Contacto/Soporte

Si encuentras errores:
- Revisa el archivo `ANALISIS_ELIMINACION_ESPECIALIDADES.md`
- Verifica que todos los GUIDs de IdPadre existan en la tabla
- Comprueba permisos de BD

