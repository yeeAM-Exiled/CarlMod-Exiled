param(
    [Parameter(Mandatory = $true)]
    [string]$PluginPath,
    [string]$AppDataRoot = (Join-Path $env:APPDATA 'CarlMod-EXILED')
)

$ErrorActionPreference = 'Stop'
if (-not (Test-Path $PluginPath -PathType Leaf)) { throw "找不到插件文件：$PluginPath" }
if ([IO.Path]::GetExtension($PluginPath) -ne '.dll') { throw 'EXILED 插件必须是 .dll 文件。' }
$target = Join-Path $AppDataRoot 'Plugins'
New-Item -ItemType Directory -Force -Path $target | Out-Null
Copy-Item $PluginPath (Join-Path $target ([IO.Path]::GetFileName($PluginPath))) -Force
Write-Host "插件已安装到 $target"
