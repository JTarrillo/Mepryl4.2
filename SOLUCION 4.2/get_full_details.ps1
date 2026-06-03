$baseConnectionString = "Data Source=192.168.1.254;Persist Security Info=False;User ID=user;Password=Mepryl22;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name='SQL Server Management Studio'"

function RunQuery($dbName, $query) {
    try {
        $conn = New-Object System.Data.SqlClient.SqlConnection
        $conn.ConnectionString = if ($dbName) { $baseConnectionString + ";Initial Catalog=$dbName" } else { $baseConnectionString }
        $conn.Open()
        $cmd = $conn.CreateCommand()
        $cmd.CommandTimeout = 30
        $cmd.CommandText = $query
        $reader = $cmd.ExecuteReader()
        $table = New-Object System.Data.DataTable
        $table.Load($reader)
        $reader.Close()
        $conn.Close()
        return $table
    } catch {
        Write-Host "ERROR: $_" -ForegroundColor Red
        return $null
    }
}

Write-Host "`n==================================================" -ForegroundColor Cyan
Write-Host "1. LIST ALL AVAILABLE DATABASES" -ForegroundColor Cyan
Write-Host "==================================================" -ForegroundColor Cyan
$dbs = RunQuery $null "SELECT name FROM sys.databases WHERE database_id > 4 ORDER BY name"
if ($dbs) { $dbs | Format-Table -AutoSize }

Write-Host "`n==================================================" -ForegroundColor Cyan
Write-Host "2. 3DEJUNIO: FULL sp_TipoExamenDePaciente_Add" -ForegroundColor Cyan
Write-Host "==================================================" -ForegroundColor Cyan
$procAdd = RunQuery "3dejunio" "EXEC sp_helptext 'sp_TipoExamenDePaciente_Add'"
if ($procAdd) { ($procAdd.Text -join "`n") | Write-Host }

Write-Host "`n==================================================" -ForegroundColor Cyan
Write-Host "3. 3DEJUNIO: FULL sp_TipoExamenDePaciente_Update" -ForegroundColor Cyan
Write-Host "==================================================" -ForegroundColor Cyan
$procUpdate = RunQuery "3dejunio" "EXEC sp_helptext 'sp_TipoExamenDePaciente_Update'"
if ($procUpdate) { ($procUpdate.Text -join "`n") | Write-Host }

Write-Host "`n==================================================" -ForegroundColor Cyan
Write-Host "4. 3DEJUNIO: COLUMNS OF Especialidad" -ForegroundColor Cyan
Write-Host "==================================================" -ForegroundColor Cyan
$colsEspecialidad = RunQuery "3dejunio" "SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Especialidad' ORDER BY ORDINAL_POSITION"
if ($colsEspecialidad) { $colsEspecialidad | Format-Table -AutoSize }

Write-Host "`n==================================================" -ForegroundColor Cyan
Write-Host "5. 3DEJUNIO: COLUMNS OF PrecioPublico" -ForegroundColor Cyan
Write-Host "==================================================" -ForegroundColor Cyan
$colsPrecioPublico = RunQuery "3dejunio" "SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='PrecioPublico' ORDER BY ORDINAL_POSITION"
if ($colsPrecioPublico) { $colsPrecioPublico | Format-Table -AutoSize }

Write-Host "`n==================================================" -ForegroundColor Cyan
Write-Host "6. 3DEJUNIO: COLUMNS OF TipoExamenDePaciente" -ForegroundColor Cyan
Write-Host "==================================================" -ForegroundColor Cyan
$colsTipoExamen = RunQuery "3dejunio" "SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='TipoExamenDePaciente' ORDER BY ORDINAL_POSITION"
if ($colsTipoExamen) { $colsTipoExamen | Format-Table -AutoSize }
