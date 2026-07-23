-- Buscar el identificador L-2 en todas las tablas del esquema dbo
DECLARE @TableName NVARCHAR(255)
DECLARE @ColumnName NVARCHAR(255)
DECLARE @SQL NVARCHAR(MAX)

DECLARE cursor_tables CURSOR FOR
SELECT TABLE_NAME, COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_SCHEMA = 'dbo' 
AND COLUMN_NAME LIKE '%identificador%'
ORDER BY TABLE_NAME, COLUMN_NAME

OPEN cursor_tables
FETCH NEXT FROM cursor_tables INTO @TableName, @ColumnName

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @SQL = 'IF EXISTS (SELECT 1 FROM dbo.' + @TableName + ' WHERE [' + @ColumnName + '] = ''L-2'') 
                PRINT ''Encontrado en tabla: ' + @TableName + ', columna: ' + @ColumnName + ''''
    
    EXEC sp_executesql @SQL
    
    FETCH NEXT FROM cursor_tables INTO @TableName, @ColumnName
END

CLOSE cursor_tables
DEALLOCATE cursor_tables
