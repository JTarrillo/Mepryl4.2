$baseConnectionString = "Data Source=192.168.1.254;Persist Security Info=False;User ID=user;Password=Mepryl22;Pooling=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Application Name='SQL Server Management Studio'"
$dbName = "3dejunio"

function ExecuteNonQuery($query) {
    try {
        $conn = New-Object System.Data.SqlClient.SqlConnection
        $conn.ConnectionString = $baseConnectionString + ";Initial Catalog=$dbName"
        $conn.Open()
        $cmd = $conn.CreateCommand()
        $cmd.CommandTimeout = 30
        $cmd.CommandText = $query
        $result = $cmd.ExecuteNonQuery()
        $conn.Close()
        Write-Host "OK: Query executed successfully" -ForegroundColor Green
        return $result
    } catch {
        Write-Host "ERROR: $_" -ForegroundColor Red
        return $null
    }
}

Write-Host "==================================================" -ForegroundColor Cyan
Write-Host "Updating database: $dbName" -ForegroundColor Cyan
Write-Host "==================================================" -ForegroundColor Cyan

# Step 1: Add "seña" column to TipoExamenDePaciente if it doesn't exist
Write-Host "`n[1] Checking for 'seña' column in TipoExamenDePaciente..." -ForegroundColor Yellow
ExecuteNonQuery @"
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.TipoExamenDePaciente') AND name = 'seña')
BEGIN
    ALTER TABLE dbo.TipoExamenDePaciente ADD seña DECIMAL(18, 2) NULL;
    PRINT 'Column "seña" added';
END
ELSE
BEGIN
    PRINT 'Column "seña" already exists';
END
"@

# Step 2: Make sure "precioLista" is correct in TipoExamenDePaciente
Write-Host "`n[2] Checking for 'precioLista' column in TipoExamenDePaciente..." -ForegroundColor Yellow
ExecuteNonQuery @"
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('dbo.TipoExamenDePaciente') AND name = 'precioLista')
BEGIN
    ALTER TABLE dbo.TipoExamenDePaciente ADD precioLista DECIMAL(18, 2) NULL;
    PRINT 'Column "precioLista" added';
END
ELSE
BEGIN
    PRINT 'Column "precioLista" already exists';
END
"@

# Step 3: Drop and recreate sp_TipoExamenDePaciente_Add
Write-Host "`n[3] Updating sp_TipoExamenDePaciente_Add..." -ForegroundColor Yellow
ExecuteNonQuery "DROP PROCEDURE IF EXISTS dbo.sp_TipoExamenDePaciente_Add"
ExecuteNonQuery @"
CREATE PROCEDURE dbo.sp_TipoExamenDePaciente_Add
    @idConsulta uniqueidentifier,
    @idTurno uniqueidentifier,
    @modificado varchar(3),
    @idEspecialidad uniqueidentifier,
    @importe decimal(18,2),
    @factClub varchar(1),
    @precioLista decimal(18,2),
    @seña decimal(18,2) = 0,
    @retorno uniqueidentifier OUTPUT
AS
BEGIN
    DECLARE @id uniqueidentifier;
    SET @id = NEWID();
    INSERT INTO dbo.TipoExamenDePaciente(
        id, idConsulta, idTurno, modificado, idEspecialidad,
        precioExamen, factClub, precioLista, seña
    ) VALUES (
        @id, @idConsulta, @idTurno, @modificado, @idEspecialidad,
        @importe, @factClub, @precioLista, @seña
    );
    SET @retorno = @id;
END
"@

# Step 4: Drop and recreate sp_TipoExamenDePaciente_Update
Write-Host "`n[4] Updating sp_TipoExamenDePaciente_Update..." -ForegroundColor Yellow
ExecuteNonQuery "DROP PROCEDURE IF EXISTS dbo.sp_TipoExamenDePaciente_Update"
ExecuteNonQuery @"
CREATE PROCEDURE dbo.sp_TipoExamenDePaciente_Update
    @idTurno uniqueidentifier,
    @valor varchar(3),
    @importe decimal(18,2),
    @factClub varchar(1),
    @precioLista decimal(18,2),
    @seña decimal(18,2) = 0
AS
BEGIN
    UPDATE dbo.TipoExamenDePaciente
    SET
        modificado = @valor,
        precioExamen = @importe,
        factClub = @factClub,
        precioLista = @precioLista,
        seña = @seña
    WHERE idTurno = @idTurno;
END
"@

Write-Host "`n==================================================" -ForegroundColor Cyan
Write-Host "Update completed!" -ForegroundColor Cyan
Write-Host "==================================================" -ForegroundColor Cyan
