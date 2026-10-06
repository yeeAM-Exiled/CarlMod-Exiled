param(
    [string]$TestRoot = (Join-Path (Split-Path -Parent $PSScriptRoot) 'docs\installer-test')
)

$ErrorActionPreference = 'Stop'
$packageRoot = Split-Path -Parent $PSScriptRoot
$installer = Join-Path $packageRoot 'compiled\CarlMod-Exiled.Installer.exe'
if (-not (Test-Path $installer)) { throw "找不到安装器：$installer" }
if (Test-Path $TestRoot) { Remove-Item $TestRoot -Recurse -Force }
New-Item -ItemType Directory -Force -Path $TestRoot | Out-Null
$appData = Join-Path $TestRoot 'appdata'
$serverRoot = Join-Path $TestRoot 'server'
$process = Start-Process -FilePath $installer -ArgumentList @('--install', '--silent', '--force', '--appdata', $appData, '--server-root', $serverRoot) -Wait -PassThru
if ($process.ExitCode -ne 0) { throw "安装器退出码：$($process.ExitCode)" }
$pluginProject = Join-Path $TestRoot 'SamplePlugin'
$process = Start-Process -FilePath $installer -ArgumentList @('--install', '--silent', '--appdata', $appData, '--create-plugin', $pluginProject) -Wait -PassThru
if ($process.ExitCode -ne 0) { throw "插件脚手架退出码：$($process.ExitCode)" }
$required = @(
    (Join-Path $appData 'Plugins\Carlfrellett.dll'),
    (Join-Path $appData 'Plugins\dependencies\Exiled.API.dll'),
    (Join-Path $serverRoot 'Exiled\Exiled.Loader.dll'),
    (Join-Path $serverRoot 'Exiled\Configs\loader.yml'),
    (Join-Path $appData 'carlmod-exiled.install.json'),
    (Join-Path $pluginProject 'SamplePlugin.csproj'),
    (Join-Path $pluginProject 'Plugin.cs'),
    (Join-Path $pluginProject 'Config.cs')
)
foreach ($file in $required) {
    if (-not (Test-Path $file -PathType Leaf)) { throw "安装验证缺少文件：$file" }
}
$loader = Get-Content (Join-Path $serverRoot 'Exiled\Configs\loader.yml') -Raw
if ($loader -notmatch [regex]::Escape("exiled_directory_path: $appData")) { throw 'Loader 配置未指向测试 AppData。' }
$files = Get-ChildItem $appData -Recurse -File
$result = [ordered]@{
    passed = $true
    appData = $appData
    serverRoot = $serverRoot
    appDataFileCount = $files.Count
    pluginSha256 = (Get-FileHash (Join-Path $appData 'Plugins\Carlfrellett.dll') -Algorithm SHA256).Hash
    loaderPath = (Join-Path $serverRoot 'Exiled\Configs\loader.yml')
}
$result | ConvertTo-Json | Set-Content (Join-Path $packageRoot 'docs\installer-validation.json') -Encoding UTF8
$result | ConvertTo-Json
