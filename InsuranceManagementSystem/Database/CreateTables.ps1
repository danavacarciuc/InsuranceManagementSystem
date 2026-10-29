$databasePath = Join-Path $PSScriptRoot "InsuranceManagementSystem.accdb"
$connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=$databasePath;"
$connection = $null
try {
   if (-not (Test-Path $databasePath)) {
       throw "Database file not found."
   }
   $connection = New-Object -ComObject ADODB.Connection
   $connection.Open($connectionString)
   $tables = @(
       @{
           Name = "Clients"
           SQL = @"
CREATE TABLE Clients (
   Id COUNTER PRIMARY KEY,
   FirstName TEXT(100) NOT NULL,
   LastName TEXT(100) NOT NULL,
   Email TEXT(255),
   Phone TEXT(50),
   RegistrationDate DATETIME
)
"@
       },
       @{
           Name = "Insurances"
           SQL = @"
CREATE TABLE Insurances (
   Id COUNTER PRIMARY KEY,
   ClientId LONG NOT NULL,
   PolicyNumber TEXT(100),
   InsuranceType TEXT(50),
   Premium CURRENCY,
   StartDate DATETIME,
   EndDate DATETIME,
   CoverageAmount CURRENCY,
   Beneficiary TEXT(255),
   PropertyAddress TEXT(255),
   PropertyType TEXT(100),
   PropertyValue CURRENCY
)
"@
       }
   )
   foreach ($table in $tables) {
       try {
           $schema = $connection.OpenSchema(20)
           $exists = $false
           while (-not $schema.EOF) {
               if ($schema.Fields.Item("TABLE_NAME").Value -eq $table.Name -and
                   $schema.Fields.Item("TABLE_TYPE").Value -eq "TABLE") {
                   $exists = $true
                   break
               }
               $schema.MoveNext()
           }
           $schema.Close()
           if ($exists) {
               Write-Host "$($table.Name) already exists."
               continue
           }
           $affected = 0
           $connection.Execute($table.SQL, [ref]$affected, 128) | Out-Null
           Write-Host "$($table.Name) created successfully."
       }
       catch {
           Write-Host "Error creating $($table.Name): $($_.Exception.Message)"
       }
   }
}
catch {
   Write-Host "Error: $($_.Exception.Message)"
}
finally {
   if ($null -ne $connection) {
       if ($connection.State -eq 1) {
           $connection.Close()
       }
       [void][System.Runtime.InteropServices.Marshal]::ReleaseComObject($connection)
   }
}