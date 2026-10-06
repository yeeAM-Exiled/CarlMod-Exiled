param(
    [Parameter(Mandatory = $true)]
    [string]$OutputDirectory,
    [string]$AppDataRoot = (Join-Path $env:APPDATA 'CarlMod-EXILED')
)

$ErrorActionPreference = 'Stop'
$name = [IO.Path]::GetFileName((Resolve-Path $OutputDirectory -ErrorAction SilentlyContinue).Path)
if ([string]::IsNullOrWhiteSpace($name)) { $name = 'CarlModPlugin' }
$name = [regex]::Replace($name, '[^A-Za-z0-9_]', '_')
New-Item -ItemType Directory -Force -Path $OutputDirectory | Out-Null
$api = '$(APPDATA)\CarlMod-EXILED\Plugins\dependencies'
@"
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net48</TargetFramework>
    <LangVersion>latest</LangVersion>
    <CarlModAppData Condition="'`$(CarlModAppData)' == ''">`$(APPDATA)\CarlMod-EXILED</CarlModAppData>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Exiled.API"><HintPath>`$(CarlModAppData)\Plugins\dependencies\Exiled.API.dll</HintPath><Private>False</Private></Reference>
    <Reference Include="Exiled.Events"><HintPath>`$(CarlModAppData)\Plugins\Exiled.Events.dll</HintPath><Private>False</Private></Reference>
  </ItemGroup>
</Project>
"@ | Set-Content (Join-Path $OutputDirectory "$name.csproj") -Encoding UTF8
@"
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace $name;

public sealed class Plugin : Plugin<Config>
{
    public override string Name => "$name";
    public override string Author => "CarlMod-Exiled developer";
    public override System.Version Version => new(1, 0, 0);
    public override void OnEnabled() { Exiled.Events.Handlers.Player.Verified += OnVerified; base.OnEnabled(); }
    public override void OnDisabled() { Exiled.Events.Handlers.Player.Verified -= OnVerified; base.OnDisabled(); }
    private void OnVerified(VerifiedEventArgs ev) => Log.Info($"$name loaded player {ev.Player.Nickname}.");
}
"@ | Set-Content (Join-Path $OutputDirectory 'Plugin.cs') -Encoding UTF8
@"
using Exiled.API.Interfaces;
namespace $name;
public sealed class Config : IConfig { public bool IsEnabled { get; set; } = true; public bool Debug { get; set; } }
"@ | Set-Content (Join-Path $OutputDirectory 'Config.cs') -Encoding UTF8
Write-Host "插件项目已创建到 $OutputDirectory"
