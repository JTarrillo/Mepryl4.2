$connectionString = "Server=192.168.1.254;Database=MEPRYLv2.1;User Id=user;Password=Mepryl22;"
$version = "4.1"
$ipLocal = (Get-NetIPAddress -AddressFamily IPv4 | Where-Object {$_.InterfaceAlias -ne "Loopback"} | Select-Object -First 1 -ExpandProperty IPAddress)
$nombreEquipo = $env:COMPUTERNAME
$ipEquipo = "$ipLocal|$nombreEquipo"

$query = "UPDATE ActualizacionesSistema SET Estado = 0 WHERE Version = '$version' AND IpEquipo = '$ipEquipo'"

$sqlConnection = New-Object System.Data.SqlClient.SqlConnection $connectionString
$sqlConnection.Open()
$command = $sqlConnection.CreateCommand()
$command.CommandText = $query
$command.ExecuteNonQuery()
$sqlConnection.Close()
