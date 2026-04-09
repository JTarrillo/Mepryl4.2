const express = require('express');
const path = require('path');
const fs = require('fs');
const { getPool, sql } = require('../db');

const router = express.Router();

// Nombres de meses en español para construir la ruta de consolidados
const MESES = [
    '', 'ENERO', 'FEBRERO', 'MARZO', 'ABRIL', 'MAYO', 'JUNIO',
    'JULIO', 'AGOSTO', 'SEPTIEMBRE', 'OCTUBRE', 'NOVIEMBRE', 'DICIEMBRE',
];

// GET /api/examenes
// Lista los exámenes (consultas) del paciente autenticado
router.get('/', async (req, res) => {
    try {
        const { dni, tipo } = req.user;
        const pool = await getPool();

        let query;
        if (tipo === 'laboral') {
            query = `
                SELECT c.id, c.nroOrden, c.tipo, c.fecha, c.codigo,
                       c.observaciones, c.valido, c.eliminado
                FROM dbo.Consulta c
                INNER JOIN dbo.PacienteLaboral pl ON pl.id = c.pacienteID
                WHERE pl.dni = @dni
                  AND (c.eliminado IS NULL OR c.eliminado <> '1')
                ORDER BY c.fecha DESC
            `;
        } else {
            query = `
                SELECT c.id, c.nroOrden, c.tipo, c.fecha, c.codigo,
                       c.observaciones, c.valido, c.eliminado
                FROM dbo.Consulta c
                INNER JOIN dbo.Paciente p ON p.id = c.pacienteID
                WHERE p.dni = @dni
                  AND (c.eliminado IS NULL OR c.eliminado <> '1')
                ORDER BY c.fecha DESC
            `;
        }

        const result = await pool.request()
            .input('dni', sql.VarChar, dni)
            .query(query);

        const examenes = result.recordset.map((row) => ({
            id: row.id,
            nroOrden: row.nroOrden,
            fecha: row.fecha,
            tipo: row.tipo === 'L' ? 'Laboral' : row.tipo === 'P' ? 'Preventiva' : row.tipo,
        }));

        res.json({ examenes });
    } catch (err) {
        console.error('Error al listar exámenes:', err);
        res.status(500).json({ error: 'Error interno del servidor' });
    }
});

// GET /api/examenes/:id/pdf
// Descarga el PDF consolidado de un examen específico
router.get('/:id/pdf', async (req, res) => {
    try {
        const { dni, tipo } = req.user;
        const consultaId = req.params.id;

        // Validar formato UUID
        const uuidRegex = /^[0-9a-f]{8}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{4}-[0-9a-f]{12}$/i;
        if (!uuidRegex.test(consultaId)) {
            return res.status(400).json({ error: 'ID de consulta inválido' });
        }

        const pool = await getPool();

        // Verificar que la consulta pertenece al paciente autenticado
        let query;
        if (tipo === 'laboral') {
            query = `
                SELECT c.id, c.nroOrden, c.fecha
                FROM dbo.Consulta c
                INNER JOIN dbo.PacienteLaboral pl ON pl.id = c.pacienteID
                WHERE c.id = @consultaId AND pl.dni = @dni
            `;
        } else {
            query = `
                SELECT c.id, c.nroOrden, c.fecha
                FROM dbo.Consulta c
                INNER JOIN dbo.Paciente p ON p.id = c.pacienteID
                WHERE c.id = @consultaId AND p.dni = @dni
            `;
        }

        const result = await pool.request()
            .input('consultaId', sql.UniqueIdentifier, consultaId)
            .input('dni', sql.VarChar, dni)
            .query(query);

        if (result.recordset.length === 0) {
            return res.status(404).json({ error: 'Examen no encontrado' });
        }

        const consulta = result.recordset[0];
        const fecha = new Date(consulta.fecha);
        const nroOrden = consulta.nroOrden;

        // Construir la ruta del consolidado (misma lógica que AbrirCarperta en C#)
        const anio = fecha.getFullYear().toString();
        const mes = String(fecha.getMonth() + 1).padStart(2, '0');
        const dia = String(fecha.getDate()).padStart(2, '0');
        const nombreMes = MESES[fecha.getMonth() + 1];
        const fechaCorta = `${dia}-${mes}-${anio}`;

        const dirBase = tipo === 'laboral'
            ? process.env.DIR_CONSOLIDADO_LABORAL
            : process.env.DIR_CONSOLIDADO_PREVENTIVA;

        // Prefijo del archivo: buscar por DNI + fecha en el nombre
        // Formato archivo: L{n} - {dni} - {ddmmyyyy} - {NOMBRE}.pdf
        const fechaArchivo = `${dia}${mes}${anio}`;
        const filtroFn = (name) => name.includes(` - ${dni} - ${fechaArchivo} - `);

        // Intentar ruta directa, si no existe probar en AÑOS ANTERIORES
        let dirConsolidado = path.join(dirBase, anio, `${mes}-${nombreMes}`, fechaCorta);
        if (!fs.existsSync(dirConsolidado)) {
            dirConsolidado = path.join(dirBase, 'AÑOS ANTERIORES', anio, `${mes}-${nombreMes}`, fechaCorta);
        }

        if (!fs.existsSync(dirConsolidado)) {
            return res.status(404).json({ error: 'Consolidado no encontrado. Directorio no existe.' });
        }

        const archivos = buscarArchivosPorFn(dirConsolidado, filtroFn);

        if (archivos.length === 0) {
            return res.status(404).json({ error: 'Archivo PDF consolidado no encontrado' });
        }

        // Devolver el primer PDF encontrado
        const archivoPdf = archivos[0];
        const nombreArchivo = path.basename(archivoPdf);

        res.setHeader('Content-Type', 'application/pdf');
        res.setHeader('Content-Disposition', `inline; filename="${nombreArchivo}"`);
        fs.createReadStream(archivoPdf).pipe(res);
    } catch (err) {
        console.error('Error al descargar PDF:', err);
        res.status(500).json({ error: 'Error interno del servidor' });
    }
});

function buscarArchivosPorFn(dir, matchFn) {
    const resultados = [];
    try {
        const items = fs.readdirSync(dir, { withFileTypes: true });
        for (const item of items) {
            const fullPath = path.join(dir, item.name);
            if (item.isDirectory()) {
                resultados.push(...buscarArchivosPorFn(fullPath, matchFn));
            } else if (matchFn(item.name)) {
                resultados.push(fullPath);
            }
        }
    } catch {
        // directorio inaccesible
    }
    return resultados;
}

module.exports = router;
