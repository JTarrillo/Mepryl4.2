$connectionString = "Data Source=192.168.1.254;Persist Security Info=False;User ID=user;Password=Mepryl22;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name='SQL Server Management Studio';Command Timeout=30"

$databases = @("3dejunio", "periodico")

foreach ($db in $databases) {
    Write-Host "`n==================================================" -ForegroundColor Cyan
    Write-Host "DATABASE: $db" -ForegroundColor Cyan
    Write-Host "==================================================" -ForegroundColor Cyan

    $conn = New-Object System.Data.SqlClient.SqlConnection
    $conn.ConnectionString = $connectionString
    $conn.Open()

    $cmd = $conn.CreateCommand()
    $cmd.CommandText = "USE [$db];"
    $cmd.ExecuteNonQuery() | Out-Null

    # 1. SELECT * FROM Especialidad
    Write-Host "`n--- [1] SELECT * FROM Especialidad ---" -ForegroundColor Yellow
    $cmd.CommandText = "SELECT TOP 20 * FROM dbo.Especialidad"
    $reader = $cmd.ExecuteReader()
    $table = New-Object System.Data.DataTable
    $table.Load($reader)
    $table | Format-Table -AutoSize
    $reader.Close()

    # 2. SELECT * FROM PrecioPublico
    Write-Host "`n--- [2] SELECT * FROM PrecioPublico ---" -ForegroundColor Yellow
    $cmd.CommandText = "SELECT TOP 20 * FROM dbo.PrecioPublico"
    $reader = $cmd.ExecuteReader()
    $table = New-Object System.Data.DataTable
    $table.Load($reader)
    $table | Format-Table -AutoSize
    $reader.Close()

    # 3. sp_helptext sp_TipoExamenDePaciente_Add
    Write-Host "`n--- [3] sp_TipoExamenDePaciente_Add ---" -ForegroundColor Yellow
    $cmd.CommandText = "EXEC sp_helptext 'sp_TipoExamenDePaciente_Add'"
    $reader = $cmd.ExecuteReader()
    $table = New-Object System.Data.DataTable
    $table.Load($reader)
    $table.Text -join "`n" | Write-Host
    $reader.Close()

    # 4. sp_helptext sp_TipoExamenDePaciente_Update
    Write-Host "`n--- [4] sp_TipoExamenDePaciente_Update ---" -ForegroundColor Yellow
    $cmd.CommandText = "EXEC sp_helptext 'sp_TipoExamenDePaciente_Update'"
    $reader = $cmd.ExecuteReader()
    $table = New-Object System.Data.DataTable
    $table.Load($reader)
    $table.Text -join "`n" | Write-Host
    $reader.Close()

    $conn.Close()
}

Write-Host "`nDone!" -ForegroundColor Green
