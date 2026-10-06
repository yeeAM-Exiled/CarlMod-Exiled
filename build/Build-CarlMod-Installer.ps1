param(
    [switch]$SkipPublish
)

$ErrorActionPreference = 'Stop'
$packageRoot = Split-Path -Parent $PSScriptRoot
$installerRoot = Join-Path $packageRoot 'installer'
$stage = Join-Path $installerRoot 'payload-stage'
$payloadDirectory = Join-Path $installerRoot 'payload'
$payloadZip = Join-Path $payloadDirectory 'CarlMod-Exiled-Payload.zip'
$publishDirectory = Join-Path $packageRoot 'compiled\installer-publish'
$finalInstaller = Join-Path $packageRoot 'compiled\CarlMod-Exiled.Installer.exe'

if (Test-Path $stage) { Remove-Item $stage -Recurse -Force }
if (Test-Path $payloadZip) { Remove-Item $payloadZip -Force }
New-Item -ItemType Directory -Force -Path (Join-Path $stage 'AppData'), (Join-Path $stage 'Exiled'), $payloadDirectory | Out-Null
Copy-Item (Join-Path $packageRoot 'deployment\CarlMod-AppData\*') (Join-Path $stage 'AppData') -Recurse -Force
Copy-Item (Join-Path $packageRoot 'deployment\Exiled\*') (Join-Path $stage 'Exiled') -Recurse -Force
Compress-Archive -Path (Join-Path $stage '*') -DestinationPath $payloadZip -CompressionLevel Optimal

if (-not $SkipPublish) {
    if (Test-Path $publishDirectory) { Remove-Item $publishDirectory -Recurse -Force }
    dotnet publish (Join-Path $installerRoot 'CarlMod-Exiled.Installer.csproj') -c Release -r win-x64 --self-contained true -o $publishDirectory -p:PublishSingleFile=true -p:DebugType=None
    if (-not (Test-Path (Join-Path $publishDirectory 'CarlMod-Exiled.Installer.exe'))) {
        throw 'dotnet publish 未生成 CarlMod-Exiled.Installer.exe。'
    }
    Copy-Item (Join-Path $publishDirectory 'CarlMod-Exiled.Installer.exe') $finalInstaller -Force
}

$hash = Get-FileHash $finalInstaller -Algorithm SHA256
$metadata = [ordered]@{
    product = 'CarlMod-Exiled'
    installer = 'CarlMod-Exiled.Installer.exe'
    builtAtUtc = (Get-Date).ToUniversalTime().ToString('o')
    length = (Get-Item $finalInstaller).Length
    sha256 = $hash.Hash
    targetFramework = 'net8.0-windows'
    runtime = 'win-x64 self-contained'
    appData = '%APPDATA%\CarlMod-EXILED'
    exiledCompatibility = 'EXILED 6.0.0 / SCP:SL 12.0.1'
}
$metadata | ConvertTo-Json -Depth 4 | Set-Content (Join-Path $packageRoot 'docs\installer-metadata.json') -Encoding UTF8
Write-Host "Installer: $finalInstaller"
Write-Host "SHA256: $($hash.Hash)"
