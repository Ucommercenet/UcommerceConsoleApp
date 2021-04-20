# Used to copy assets to bin/debug for hitting F5 and running the solution manually:-) 
# Stop on first error.
Set-StrictMode -Version Latest
$version = "9.4.1.21068"
$searchProvider = "Ucommerce.Search.Lucene"
$ErrorActionPreference = "Stop"
$PSDefaultParameterValues['*:ErrorAction'] = 'Stop'

# Temporarily change to the correct folder containing script
$scriptPath = (Get-Variable MyInvocation -Scope Script).Value.MyCommand.Path
$currentFolder = Split-Path $scriptPath
Push-Location $currentFolder

# Set src folder based on location of script location in /tools/deploy
$integrationProjectBinDebug = ".\..\src\RunningUCommerce\bin\debug"
$Ucommercefolder = ".\..\src\packages\Ucommerce.Client.WebForms.$version\UcommerceFiles\Ucommerce"

if (!(Test-Path $integrationProjectBinDebug))
{
    New-Item "$integrationProjectBinDebug" -Force -ItemType Directory
}

if (Test-Path "$integrationProjectBinDebug\ucommerce")
{
    Remove-Item -Recurse "$integrationProjectBinDebug\ucommerce\*" -Force
    New-Item "$integrationProjectBinDebug\ucommerce" -Force -ItemType Directory
}

Copy-Item "$Ucommercefolder\configuration" "$integrationProjectBinDebug\Ucommerce\configuration" -Recurse -Force

Copy-Item "$Ucommercefolder\apps\Ucommerce.Search.ElasticSearch.disabled" "$integrationProjectBinDebug\Ucommerce\Apps\Ucommerce.Search.ElasticSearch.disabled" -Recurse -Force
Copy-Item "$Ucommercefolder\apps\Ucommerce.Search.Lucene" "$integrationProjectBinDebug\Ucommerce\Apps\Ucommerce.Search.Lucene" -Recurse -Force
Copy-Item "$Ucommercefolder\pipelines" "$integrationProjectBinDebug\Ucommerce\" -Recurse -Force

Rename-Item -Path "$integrationProjectBinDebug\Ucommerce\configuration\settings\settings.umbraco7.config.default" -NewName "settings.config" -Force
Push-Location "$integrationProjectBinDebug\Ucommerce\"
Write-Host "Copying all config files to integration test bin dir..."
Get-ChildItem *.config.default -recurse | ForEach-Object { Move-Item -Force -Path $_.FullName -Destination ($_.FullName.Replace('config.default', 'config')) }

Write-Host "Replacing all async pipeline tasks with their sync counterparts..."
Get-ChildItem *.config -Recurse | ForEach-Object { (Get-Content $_) -replace '\<value\>\$\{(.+?)\.IndexAsync\}\<\/value\>', '<value>${$1.Index}</value>' | Set-Content $_  }

Pop-Location
$_FileType= @("*.*dll")
Write-Host "$Ucommercefolder\apps\Ucommerce.Search.Lucene\bin"
Write-Host "$integrationProjectBinDebug"

Get-ChildItem -recurse ("$integrationProjectBinDebug\ucommerce\apps\Ucommerce.Search.Lucene\bin") -include ($_FileType) | Move-Item -Destination ($integrationProjectBinDebug) -Force
Write-Host "Done"
exit 0
