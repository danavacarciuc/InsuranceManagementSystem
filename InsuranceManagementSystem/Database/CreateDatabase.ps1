$databasePath = Join-Path $PSScriptRoot "InsuranceManagementSystem.accdb"
if (Test-Path $databasePath) {
   Write-Host "Database already exists."
   exit
}
$catalog = New-Object -ComObject ADOX.Catalog
$connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=$databasePath;"
try {
   $catalog.Create($connectionString)
   Write-Host "Database created successfully!"
}
catch {
   Write-Host "Error creating database:"
   Write-Host $_.Exception.Message
}
finally {
   if ($null -ne $catalog) {
       [void][System.Runtime.InteropServices.Marshal]::ReleaseComObject($catalog)
   }
}