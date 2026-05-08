-- ========================================
-- BACKUP DE BASE DE DATOS MEPRYLv2.1
-- Fecha: 07/05/2026
-- ========================================

-- COMANDO PARA CREAR BACKUP
-- Ejecutar en SQL Server Management Studio
-- ========================================

BACKUP DATABASE [MEPRYLv2.1] 
TO DISK = 'C:\Backups\MEPRYLv2.1_Backup_2026-05-07.bak'
WITH 
    FORMAT,
    INIT,
    NAME = 'MEPRYLv2.1-Completo Database Backup',
    SKIP,
    NOREWIND,
    NOUNLOAD,
    STATS = 10

-- ========================================
// turbo
// INSTRUCCIONES:
// 1. Asegurarse que exista la carpeta C:\Backups\
// 2. Ejecutar este comando en SQL Server Management Studio
// 3. Verificar que el archivo .bak se cree correctamente
// 4. Guardar una copia del backup en lugar seguro
// ========================================
