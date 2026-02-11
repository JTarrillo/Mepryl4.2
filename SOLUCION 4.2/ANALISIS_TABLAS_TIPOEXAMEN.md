# Análisis de Tablas - Flujo TipoExamen

## 1. TABLA: Especialidad (Tipo de Examen)

**Descripción**: Define los tipos de exámenes disponibles en el sistema.

**Columnas Principales**:

| Columna | Tipo | Nullable | Descripción |
|---------|------|----------|-------------|
| id | uniqueidentifier | NO | Identificador único del examen |
| codigo | varchar | YES | Código identificativo |
| descripcion | varchar | NO | Nombre del tipo de examen |
| idMotivoConsulta | int | NO | FK a tabla MotivoDeConsulta |
| precioBase | decimal | YES | Precio base del examen |
| descripcionInformes | varchar | YES | Descripción para informes |
| orden | int | YES | Orden de visualización |
| tipo | int | YES | Tipo de examen (clasificación) |
| Padre | bit | YES | ¿Es un examen padre? |
| IdPadre | varchar | YES | ID del examen padre (si existe) |
| registroBLOB, actualizacion_local, operacion_local, sincronizado, serverID | - | - | Campos de sincronización/auditoría |

**Cardinalidad**: 1 tabla = N Tipos de Examen

---

## 2. TABLA: EstudiosPorTipoExamen (Estudios Incluidos)

**Descripción**: Define qué estudios/items están incluidos en cada tipo de examen. Usa un modelo de columnas booleanas (item1...item97).

**Estructura**:

| Columna | Tipo | Nullable | Descripción |
|---------|------|----------|-------------|
| id | uniqueidentifier | NO | Identificador único del registro |
| idEspecialidad | uniqueidentifier | NO | FK a tabla Especialidad |
| item1 a item97 | bit | YES | Indicadores booleanos (97 estudios posibles) |

**Significado**:
- `item1` = 1 → Estudio clínico incluido
- `item2` = 1 → Hematología incluida
- `item3` = 1 → Química hematológica incluida
- ... (hasta 97 items)
- NULL o 0 = No incluido

**Cardinalidad**: 1 Especialidad → 1 EstudiosPorTipoExamen (relación 1:1)

---

## 3. TABLA: Items (Detalles de Items)

**Descripción**: Catálogo master de todos los estudios/items disponibles en el sistema.

**Columnas**:

| Columna | Tipo | Nullable | Descripción |
|---------|------|----------|-------------|
| id | int | NO | Identificador único (clave primaria) |
| codigo | int | YES | Código identificativo del item |
| nombreCompleto | varchar | NO | Nombre completo del estudio |
| nombreInformes | varchar | NO | Nombre en reportes/informes |
| ordenFormulario | int | NO | Orden en el formulario (1-12 categorías) |
| precioSuma | decimal | YES | Precio agregado si se suma |
| precioResta | decimal | YES | Precio deducido si se resta |

**Categorías de ordenFormulario**:

| Valor | Categoría |
|-------|-----------|
| 1 | Clínico |
| 2 | Hematología |
| 3 | Química Hematológica |
| 4 | Serología |
| 5 | Perfil Lipídico |
| 6 | Bacteriología |
| 7 | Orina |
| 8 | Laborales Básicas |
| 9 | Cráneo y Miembro Superior |
| 10 | Tronco y Pelvis |
| 11 | Miembro Inferior |
| 12 | Estudios Complementarios |

**Cardinalidad**: 1 tabla = 97 Items posibles

---

## 4. TABLA: EstudiosPorExamen (Instancia para Pacientes)

**Descripción**: Instancia de un examen asignado a un paciente específico. Copia los items del tipo de examen pero puede ser modificado.

**Estructura**:

| Columna | Tipo | Nullable | Descripción |
|---------|------|----------|-------------|
| id | uniqueidentifier | NO | Identificador único de esta instancia |
| idTipoExamen | uniqueidentifier | NO | FK a TipoExamenDePaciente |
| item1 a item97 | bit | YES | Estados de cada estudio para este paciente |

**Diferencia vs EstudiosPorTipoExamen**:
- **EstudiosPorTipoExamen**: Template/plantilla (lo que define el tipo de examen)
- **EstudiosPorExamen**: Instancia real (lo que se le asigna al paciente, puede variar)

**Cardinalidad**: 1 TipoExamenDePaciente → 1 EstudiosPorExamen (relación 1:1)

---

## Flujo de Datos

```
┌─────────────────────────────────────────────────────────────────┐
│  1. Especialidad (TEMPLATE)                                      │
│     - Define un tipo de examen (ej: "Examen Preventivo")        │
│     - Tiene código, descripción, precio base                     │
└────────────────────┬────────────────────────────────────────────┘
                     │
                     │ Define qué estudios incluye
                     ↓
┌─────────────────────────────────────────────────────────────────┐
│  2. EstudiosPorTipoExamen (TEMPLATE DETALLE)                    │
│     - 97 columnas booleanas (item1...item97)                    │
│     - Indica qué Items están disponibles para este examen       │
│     - Relación 1:1 con Especialidad                            │
└────────────────────┬────────────────────────────────────────────┘
                     │
                     │ Referencia a Items
                     ↓
┌─────────────────────────────────────────────────────────────────┐
│  3. Items (CATÁLOGO MASTER)                                     │
│     - 97 estudios disponibles en el sistema                     │
│     - Cada item tiene: código, nombre, categoría (1-12)         │
│     - Los booleanos de EstudiosPorTipoExamen enlazan aquí       │
└────────────────────┬────────────────────────────────────────────┘
                     │
                     │ Se COPIA cuando se asigna a un paciente
                     ↓
┌─────────────────────────────────────────────────────────────────┐
│  4. EstudiosPorExamen (INSTANCIA PACIENTE)                      │
│     - Copia de EstudiosPorTipoExamen para un paciente           │
│     - Puede ser MODIFICADA para ese paciente específico         │
│     - Los cambios NO afectan al template                        │
│     - Relación 1:1 con TipoExamenDePaciente                    │
└─────────────────────────────────────────────────────────────────┘
```

---

## Ejemplo Práctico

### Tipo de Examen: "Examen Preventivo Completo"

**Especialidad**:
```
ID: 550e8400-e29b-41d4-a716-446655440000
código: 1
descripción: Examen Preventivo Completo
precioBase: 150.00
idMotivoConsulta: 1
```

**EstudiosPorTipoExamen**:
```
ID: 550e8400-e29b-41d4-a716-446655440001
idEspecialidad: 550e8400-e29b-41d4-a716-446655440000
item1: 1  (Clínico - SÍ)
item2: 1  (Hematología - SÍ)
item3: 1  (Química - SÍ)
item4: 0  (Serología - NO)
item5: 1  (Perfil Lipídico - SÍ)
item6: 0  (Bacteriología - NO)
...
item97: 0
```

**Items** (muestra):
```
ID: 1, código: 1, nombreCompleto: "Hemograma",    ordenFormulario: 2
ID: 2, código: 2, nombreCompleto: "Hematocrito",  ordenFormulario: 2
ID: 3, código: 3, nombreCompleto: "Glucosa",      ordenFormulario: 3
...
```

**EstudiosPorExamen** (cuando se asigna a paciente Juan):
```
ID: 550e8400-e29b-41d4-a716-446655440002
idTipoExamen: 550e8400-e29b-41d4-a716-446655440001
item1: 1  (Clínico - SÍ)
item2: 1  (Hematología - SÍ)
item3: 0  (Química - NO para este paciente ← MODIFICADO)
item4: 0  (Serología - NO)
item5: 1  (Perfil Lipídico - SÍ)
...
```

---

## Relaciones y Claves Foráneas

```
Items (id=1..97)
    ↑
    │ Referenciado por índices (item1...item97)
    │
EstudiosPorTipoExamen (FK: idEspecialidad → Especialidad.id)
    ↑
    │ Template copiado a
    │
EstudiosPorExamen (FK: idTipoExamen → TipoExamenDePaciente.id)
    ↑
    │
Especialidad
    ↓
    │ FK: idMotivoConsulta → MotivoDeConsulta.id
    │
MotivoDeConsulta

TipoExamenDePaciente
    ↓
EstudiosPorExamen (1:1)
```

---

## Puntos Clave

1. **Template Pattern**: Las tablas Especialidad + EstudiosPorTipoExamen forman un template que se replica a EstudiosPorExamen
2. **97 Estudios**: El sistema soporta hasta 97 items diferentes
3. **Modificabilidad**: EstudiosPorExamen puede variar del template sin afectarlo
4. **Categorización**: Los Items están organizados en 12 categorías (ordenFormulario)
5. **Precios**: Se pueden ajustar por item (precioSuma/precioResta en Items)
