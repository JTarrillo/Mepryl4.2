# Script para leer encabezados de Excel usando COM
$excel = New-Object -ComObject Excel.Application
$excel.Visible = $false
$excel.DisplayAlerts = $false

try {
    $workbook = $excel.Workbooks.Open("C:\Mepryl4.2\SOLUCION 4.2\18.xlsx")
    $sheet = $workbook.Sheets.Item(1)
    
    Write-Host "=== ESTRUCTURA DEL EXCEL 18.xlsx ===" -ForegroundColor Green
    Write-Host ""
    
    $usedRange = $sheet.UsedRange
    $colCount = $usedRange.Columns.Count
    
    Write-Host "Total de columnas: $colCount" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "Encabezados de columnas:" -ForegroundColor Yellow
    
    for ($i = 1; $i -le $colCount; $i++) {
        $header = $sheet.Cells.Item(1, $i).Value2
        if ($header -eq $null) { $header = "<VACÍO>" }
        Write-Host "[$($i-1)] $header"
    }
    
    Write-Host ""
    Write-Host "=== PRIMERA FILA DE DATOS ===" -ForegroundColor Green
    for ($i = 1; $i -le [Math]::Min($colCount, 20); $i++) {
        $value = $sheet.Cells.Item(2, $i).Value2
        if ($value -eq $null) { $value = "<VACÍO>" }
        Write-Host "[$($i-1)] $value"
    }
    
    $workbook.Close($false)
}
catch {
    Write-Host "Error: $_" -ForegroundColor Red
}
finally {
    $excel.Quit()
    [System.Runtime.Interopservices.Marshal]::ReleaseComObject($excel) | Out-Null
}
