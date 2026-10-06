param(
    [Parameter(Mandatory = $true)]
    [string]$ServerRoot,
    [string]$AppDataRoot = (Join-Path $env:APPDATA 'CarlMod-EXILED')
)

$ErrorActionPreference = 'Stop'
$packageRoot = Split-Path -Parent $PSScriptRoot
$deploymentRoot = Join-Path $packageRoot 'deployment'
$serverSource = Join-Path $deploymentRoot 'Carl Mod Server'
$exiledSource = Join-Path $deploymentRoot 'Exiled'
$exiledTarget = Join-Path $ServerRoot 'Exiled'

New-Item -ItemType Directory -Force -Path $ServerRoot | Out-Null
Copy-Item -Path (Join-Path $serverSource '*') -Destination $ServerRoot -Recurse -Force
New-Item -ItemType Directory -Force -Path $exiledTarget | Out-Null
New-Item -ItemType Directory -Force -Path $AppDataRoot | Out-Null
Copy-Item -Path (Join-Path $exiledSource '*') -Destination $exiledTarget -Recurse -Force
Copy-Item -Path (Join-Path $deploymentRoot 'CarlMod-AppData\*') -Destination $AppDataRoot -Recurse -Force

$loaderPath = Join-Path $exiledTarget 'Configs\loader.yml'
if (Test-Path $loaderPath) {
    $loader = Get-Content -Raw $loaderPath
    $loader = [regex]::Replace($loader, '(?m)^exiled_directory_path:.*$', "exiled_directory_path: $AppDataRoot")
    Set-Content -Path $loaderPath -Value $loader -Encoding UTF8
}

Write-Host "Carl Mod EXILED installed to $ServerRoot"
Write-Host "Carl Mod AppData installed to $AppDataRoot"
