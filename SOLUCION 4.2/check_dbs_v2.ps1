# Correct connection string (Command Timeout → we can set on SqlCommand, Connect Timeout is for connection)
$baseConnectionString = "Data Source=192.168.1.254;Persist Security Info=False;User ID=user;Password=Mepryl22;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name='SQL Server Management Studio'"
$databases = @("3dejunio", "periodico")

function RunQuery($dbName, $query, $description) {
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
        Write-Host "`n--- $description ---" -ForegroundColor Yellow
        if ($table.Rows.Count -gt 0) {
            $table | Format-Table -AutoSize | Out-Host
        } else {
            Write-Host "(No rows returned)" -ForegroundColor Gray
        }
        $reader.Close()
        $conn.Close()
        return $table
    } catch {
        Write-Host "ERROR: $_" -ForegroundColor Red
        return $null
    }
}

foreach ($db in $databases) {
    Write-Host "`n==================================================" -ForegroundColor Cyan
    Write-Host "DATABASE: $db" -ForegroundColor Cyan
    Write-Host "==================================================" -ForegroundColor Cyan

    # 1. Check Especialidad structure and data
    RunQuery $db "SELECT TOP 10 * FROM dbo.Especialidad" "SELECT * FROM Especialidad"
    
    # 2. Check PrecioPublico structure and data
    RunQuery $db "SELECT TOP 10 * FROM dbo.PrecioPublico" "SELECT * FROM PrecioPublico"
    
    # 3. sp_helptext sp_TipoExamenDePaciente_Add
    $procAdd = RunQuery $db "EXEC sp_helptext 'sp_TipoExamenDePaciente_Add'" "sp_TipoExamenDePaciente_Add"
    if ($procAdd) {
        ($procAdd.Text -join "`n") | Write-Host
    }
    
    # 4. sp_helptext sp_TipoExamenDePaciente_Update
    $procUpdate = RunQuery $db "EXEC sp_helptext 'sp_TipoExamenDePaciente_Update'" "sp_TipoExamenDePaciente_Update"
    if ($procUpdate) {
        ($procUpdate.Text -join "`n") | Write-Host
    }
}

Write-Host "`nDone!" -ForegroundColor Green
