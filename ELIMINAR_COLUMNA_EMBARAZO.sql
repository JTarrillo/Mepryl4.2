-- Script para eliminar la columna te de la tabla ExamenLaboral
-- Fecha: 2026-08-20
-- Descripción: Elimina la columna te que ya no es necesaria en el sistema

USE [Mepryl] -- Reemplazar con el nombre correcto de la base de datos si es diferente
GO

-- Eliminar la columna te de la tabla ExamenLaboral
ALTER TABLE dbo.ExamenLaboral
DROP COLUMN te;
GO

PRINT 'Columna te eliminada exitosamente de la tabla ExamenLaboral';
GO