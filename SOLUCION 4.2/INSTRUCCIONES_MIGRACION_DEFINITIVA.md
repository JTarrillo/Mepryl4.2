# Migración Definitiva: Backup Mejorado → BD Original

## 📋 Resumen de Cambios

### Tabla: `Especialidad`

### Lo que hace el script:

1. **PASO 0:** Inserta **23 nuevas especialidades PADRE** del backup
   - Estas son contenedores para los subtipos
   - Ejemplo: `D6A02B46-FB57-44E1-9469-6315FC8236EF` = FUTBOL (padre)

2. **PASO 1:** Verifica integridad (duplicados/referencias rotas)

3. **PASO 2:** Convierte **45 subtipos** de `Padre=1` a `Padre=0`
   - REPETICIONES, LEY + AUDIOMETRIA, PSICOTECNICO, etc.

4. **PASO 3:** Actualiza **45 referencias de IdPadre**
   - Apuntan correctamente a sus padres nuevos

5. **PASO 4:** Verifica que no haya referencias rotas

---

## 🚀 Ejecución

### Opción A: Con Transacción (SEGURO - Recomendado)

```sql
-- 1. Backup de BD (por seguridad)
BACKUP DATABASE [TU_BD] 
TO DISK = 'C:\Backups\Especialidad_2025-11-26.bak'

-- 2. Ejecutar script
USE [TU_BD]
GO

BEGIN TRANSACTION

-- Pega todo el contenido de: MIGRACION_COMPLETA_CON_PADRES_CORREGIDA.sql

-- 3. Revisar PASO 4 en la salida
-- Si está todo OK:
COMMIT

-- Si hay problema:
-- ROLLBACK
```

### Opción B: Ejecución Directa

1. Abre SQL Server Management Studio
2. Conecta a tu BD
3. Abre `MIGRACION_COMPLETA_CON_PADRES.sql`
4. Reemplaza `[Tu_Base_De_Datos]` por tu BD real
5. Ejecuta (Ctrl+Shift+E)

---

## ✅ Verificar Resultados

Después de migrar, ejecuta esto:

```sql
-- 1. Ver estructura jerárquica
SELECT 
    CASE WHEN Padre = 1 THEN '► PADRE' ELSE '  └─ Subtipo' END as Tipo,
    descripcion,
    tipo,
    id,
    IdPadre
FROM Especialidad
WHERE descripcion LIKE '%FUTBOL%' OR IdPadre = 'D6A02B46-FB57-44E1-9469-6315FC8236EF'
ORDER BY Padre DESC, descripcion

-- 2. Contar total
SELECT 
    COUNT(*) as Total,
    SUM(CASE WHEN Padre = 1 THEN 1 ELSE 0 END) as Padres,
    SUM(CASE WHEN Padre = 0 THEN 1 ELSE 0 END) as Subtipos
FROM Especialidad

-- 3. Referencias rotas (debe estar vacío)
SELECT COUNT(*) as ReferenciaRotas
FROM Especialidad e1
WHERE Padre = 0 
  AND IdPadre IS NOT NULL
  AND IdPadre NOT IN (SELECT id FROM Especialidad)
  AND IdPadre != ''
```

---

## 📊 Cambios Específicos

### Nuevas Especialidades PADRE:

| GUID | Nombre | Subtipos Asociados |
|------|--------|-------------------|
| `FC32BF07-...` | REPETICIONES | 1 subtipo |
| `E90DD2CB-...` | INDICE DE TORG-PAVLOV | 1 subtipo |
| `22D5B906-...` | PSICOTECNICO | 1 subtipo |
| `8F2212CD-...` | BASQUET | 3 subtipos |
| `3EF76F6D-...` | APTO BASICO | 2 subtipos |
| `71522E88-...` | FUERZAS SEGURIDAD | 3 subtipos |
| `D6A02B46-...` | FUTBOL | 3 subtipos |
| ... | ... | ... |

### Ejemplos de Correcciones:

**FUTBOL (antes - incorrecto):**
```
Padre:       FUTBOL (ID: 3E05D251-...) - EsPadre=1
  Subtipo:   FUTBOL AFA (ID: 48AD474E-...) - EsPadre=1 ❌
  Subtipo:   FUTBOL PARTICULAR (ID: EEBE9644-...) - EsPadre=1 ❌
```

**FUTBOL (después - correcto):**
```
Padre:       FUTBOL (ID: D6A02B46-...) - EsPadre=1 ✓
  Subtipo:   FUTBOL AFA (ID: 48AD474E-...) - EsPadre=0, IdPadre=D6A02B46-... ✓
  Subtipo:   FUTBOL PARTICULAR (ID: EEBE9644-...) - EsPadre=0, IdPadre=D6A02B46-... ✓
  Subtipo:   FUTBOL METRO (ID: 60E94892-...) - EsPadre=0, IdPadre=D6A02B46-... ✓
```

---

## ⚠️ Precauciones

- ✅ **BACKUP PRIMERO** - Es obligatorio
- ✅ **Usar Transacción** - Para poder deshacer
- ✅ **Revisar PASO 4** - Antes de COMMIT
- ✅ **Probar en QA** - Si tienes ambiente de prueba
- ✅ **Avisar al equipo** - Cambios importantes en estructura

---

## 🔄 Si algo sale mal

### Opción 1: Rollback en SQL
```sql
ROLLBACK  -- Deshace toda la transacción
```

### Opción 2: Restaurar desde Backup
```sql
RESTORE DATABASE [TU_BD]
FROM DISK = 'C:\Backups\TipoExamen_2025-11-26.bak'
```

---

## 📝 Documentación de Cambios

**Archivo:** `MIGRACION_COMPLETA_CON_PADRES_CORREGIDA.sql`

**Responsable:** Sistema de Migración de Datos

**Fecha:** 2025-11-26

**Estado:** Listo para Producción

---

## ❓ FAQ

### ¿Se pierden datos?
No. Solo se reorganizan referencias y se marcan correctamente como padre/subtipo.

### ¿Puedo revertir?
Sí, con ROLLBACK o restaurando desde backup.

### ¿Cuánto tiempo tarda?
Depende del tamaño de BD, pero típicamente < 1 segundo.

### ¿Afecta a aplicación C#?
No si usas `eliminarTipoExamenPadre()`. El método viejo es problemático.

### ¿Qué pasa con las relaciones existentes?
Se conservan todas. Solo se corrigen las referencias rotas.

