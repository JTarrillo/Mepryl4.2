const express = require('express');
const jwt = require('jsonwebtoken');
const { getPool, sql } = require('../db');
const { encriptar } = require('../crypto');

const router = express.Router();

// POST /api/auth/login
// Body: { "dni": "12345678", "password": "mipassword" }
router.post('/login', async (req, res) => {
    try {
        const { dni, password } = req.body;

        if (!dni || !password) {
            return res.status(400).json({ error: 'DNI y contraseña son requeridos' });
        }

        const pool = await getPool();

        // Buscar usuario por DNI que sea paciente
        const result = await pool.request()
            .input('dni', sql.VarChar, dni)
            .query(`
                SELECT u.id, u.username, u.password, u.dni, u.Tipo, u.Activo,
                       u.nombre, u.apellido
                FROM dbo.Usuario u
                WHERE u.dni = @dni
                  AND u.Tipo IN ('PACIENTE LABORAL', 'PACIENTE PREVENTIVA')
            `);

        if (result.recordset.length === 0) {
            return res.status(401).json({ error: 'DNI o contraseña incorrectos' });
        }

        const usuario = result.recordset[0];

        if (!usuario.Activo) {
            return res.status(403).json({ error: 'Usuario inactivo' });
        }

        // Verificar contraseña usando el mismo algoritmo de encriptar de Mepryl
        const passwordEncriptado = encriptar(password);
        if (passwordEncriptado !== usuario.password) {
            return res.status(401).json({ error: 'DNI o contraseña incorrectos' });
        }

        // Determinar tipo de paciente
        const tipoPaciente = usuario.Tipo === 'PACIENTE LABORAL' ? 'laboral' : 'preventiva';

        // Generar JWT
        const token = jwt.sign(
            {
                userId: usuario.id,
                dni: usuario.dni,
                tipo: tipoPaciente,
                nombre: `${usuario.apellido} ${usuario.nombre}`.trim(),
            },
            process.env.JWT_SECRET,
            { expiresIn: process.env.JWT_EXPIRES_IN }
        );

        res.json({
            token,
            usuario: {
                nombre: usuario.nombre,
                apellido: usuario.apellido,
                dni: usuario.dni,
                tipo: tipoPaciente,
            },
        });
    } catch (err) {
        console.error('Error en login:', err);
        res.status(500).json({ error: 'Error interno del servidor' });
    }
});

module.exports = router;
