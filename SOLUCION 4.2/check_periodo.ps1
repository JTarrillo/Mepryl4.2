$baseConnectionString = "Data Source=192.168.1.254;Persist Security Info=False;User ID=user;Password=Mepryl22;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name='SQL Server Management Studio'"

function RunQuery($dbName, $query) {
    try {
        $conn = New-Object System.Data.SqlClient.SqlConnection
        $conn.ConnectionString = $baseConnectionString + ";Initial Catalog=$dbName"
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

$dbName = "periodo"
Write-Host "`n==================================================" -ForegroundColor Cyan
Write-Host "DATABASE: $dbName" -ForegroundColor Cyan
Write-Host "==================================================" -ForegroundColor Cyan

Write-Host "`n--- sp_TipoExamenDePaciente_Add ---" -ForegroundColor Yellow
$procAdd = RunQuery $dbName "EXEC sp_helptext 'sp_TipoExamenDePaciente_Add'"
if ($procAdd) { ($procAdd.Text -join "`n") | Write-Host }

Write-Host "`n--- sp_TipoExamenDePaciente_Update ---" -ForegroundColor Yellow
$procUpdate = RunQuery $dbName "EXEC sp_helptext 'sp_TipoExamenDePaciente_Update'"
if ($procUpdate) { ($procUpdate.Text -join "`n") | Write-Host }

Write-Host "`n--- TipoExamenDePaciente Columns ---" -ForegroundColor Yellow
$cols = RunQuery $dbName "SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='TipoExamenDePaciente' ORDER BY ORDINAL_POSITION"
if ($cols) { $cols | Format-Table -AutoSize }

Write-Host "`n--- PrecioPublico Columns ---" -ForegroundColor Yellow
$colsPrecio = RunQuery $dbName "SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='PrecioPublico' ORDER BY ORDINAL_POSITION"
if ($colsPrecio) { $colsPrecio | Format-Table -AutoSize }

Write-Host "`n--- Especialidad Columns ---" -ForegroundColor Yellow
$colsEsp = RunQuery $dbName "SELECT COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME='Especialidad' ORDER BY ORDINAL_POSITION"
if ($colsEsp) { $colsEsp | Format-Table -AutoSize }
