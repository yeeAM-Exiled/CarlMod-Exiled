param(
    [string]$PackageRoot = (Split-Path -Parent $PSScriptRoot),
    [string]$AppDataRoot = (Join-Path $env:APPDATA 'CarlMod-EXILED')
)

$ErrorActionPreference = 'Stop'
$compiledPath = Join-Path $PackageRoot 'compiled\Carlfrellett.dll'
$assemblyName = [System.Reflection.AssemblyName]::GetAssemblyName($compiledPath)
$assembly = [System.Reflection.Assembly]::LoadFile((Resolve-Path $compiledPath).Path)
$hash = (Get-FileHash $compiledPath -Algorithm SHA256).Hash
$sourcePath = Join-Path $PackageRoot 'source'
$serverPath = Join-Path $PackageRoot 'deployment\Carl Mod Server'
$appPackagePath = Join-Path $PackageRoot 'deployment\CarlMod-AppData'
$configPath = Join-Path $appPackagePath 'Configs\Carlfrellett'
$result = [ordered]@{
    generatedAt = (Get-Date).ToUniversalTime().ToString('o')
    assembly = [ordered]@{
        name = $assemblyName.Name
        version = $assemblyName.Version.ToString()
        sha256 = $hash
        length = (Get-Item $compiledPath).Length
        referencedAssemblies = @($assembly.GetReferencedAssemblies() | Sort-Object Name,Version | ForEach-Object FullName)
    }
    source = [ordered]@{
        csharpFiles = @(Get-ChildItem $sourcePath -Recurse -File -Filter '*.cs').Count
        totalFiles = @(Get-ChildItem $sourcePath -Recurse -File).Count
    }
    deployment = [ordered]@{
        serverFiles = @(Get-ChildItem $serverPath -Recurse -File).Count
        serverBytes = ((Get-ChildItem $serverPath -Recurse -File | Measure-Object Length -Sum).Sum)
        appDataFiles = @(Get-ChildItem $appPackagePath -Recurse -File).Count
        appDataBytes = ((Get-ChildItem $appPackagePath -Recurse -File | Measure-Object Length -Sum).Sum)
        loaderConfig = (Get-Content -Raw (Join-Path $serverPath 'Exiled\Configs\loader.yml')).Trim()
        pluginConfigFiles = @(Get-ChildItem $configPath -Recurse -File).Count
    }
    appData = [ordered]@{
        path = $AppDataRoot
        exists = (Test-Path $AppDataRoot)
        pluginExists = (Test-Path (Join-Path $AppDataRoot 'Plugins\Carlfrellett.dll'))
        configExists = (Test-Path (Join-Path $AppDataRoot 'Configs\Carlfrellett'))
    }
}
$json = $result | ConvertTo-Json -Depth 8
$json | Set-Content -Path (Join-Path $PackageRoot 'compiled\metadata.json') -Encoding UTF8
$json | Set-Content -Path (Join-Path $PackageRoot 'docs\validation-result.json') -Encoding UTF8
$result | ConvertTo-Json -Depth 8
