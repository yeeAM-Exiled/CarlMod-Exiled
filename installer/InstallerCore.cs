using System.IO.Compression;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace CarlModExiledInstaller;

internal sealed class InstallResult
{
    public List<string> Messages { get; } = new();
}

internal static class InstallerCore
{
    private const string PayloadResource = "CarlMod-Exiled-Payload.zip";
    private static readonly string DefaultAppDataRoot = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CarlMod-EXILED");

    public static InstallResult InstallRuntime(string appDataRoot, string? serverRoot, bool force)
    {
        appDataRoot = Path.GetFullPath(string.IsNullOrWhiteSpace(appDataRoot) ? DefaultAppDataRoot : appDataRoot);
        var result = new InstallResult();
        var tempRoot = ExtractPayload();
        try
        {
            var payloadAppData = Path.Combine(tempRoot, "AppData");
            if (!Directory.Exists(payloadAppData))
                throw new InvalidDataException("安装包缺少 AppData 载荷。");

            CopyDirectory(payloadAppData, appDataRoot, force, preserveConfiguration: !force);
            result.Messages.Add($"CarlMod-EXILED 已安装到：{appDataRoot}");

            if (!string.IsNullOrWhiteSpace(serverRoot))
            {
                serverRoot = Path.GetFullPath(serverRoot);
                var payloadExiled = Path.Combine(tempRoot, "Exiled");
                var exiledTarget = Path.Combine(serverRoot, "Exiled");
                CopyDirectory(payloadExiled, exiledTarget, force, preserveConfiguration: false);
                var loaderPath = Path.Combine(exiledTarget, "Configs", "loader.yml");
                if (File.Exists(loaderPath))
                {
                    var loader = File.ReadAllText(loaderPath, Encoding.UTF8);
                    loader = Regex.Replace(loader, "(?m)^exiled_directory_path:.*$", "exiled_directory_path: " + appDataRoot);
                    File.WriteAllText(loaderPath, loader, new UTF8Encoding(false));
                }
                result.Messages.Add($"EXILED Loader 已安装到：{exiledTarget}");
            }
            else
            {
                result.Messages.Add("未指定服务器目录；可稍后在安装器中选择服务器根目录以部署 Loader。");
            }

            var marker = new
            {
                product = "CarlMod-Exiled",
                installedAtUtc = DateTimeOffset.UtcNow,
                appDataRoot,
                serverRoot,
                pluginDirectory = Path.Combine(appDataRoot, "Plugins"),
                compatibleWith = "EXILED 6.0.0 / SCP:SL 12.0.1"
            };
            Directory.CreateDirectory(appDataRoot);
            File.WriteAllText(Path.Combine(appDataRoot, "carlmod-exiled.install.json"), JsonSerializer.Serialize(marker, new JsonSerializerOptions { WriteIndented = true }), Encoding.UTF8);
            return result;
        }
        finally
        {
            TryDelete(tempRoot);
        }
    }

    public static string InstallPlugin(string pluginPath, string appDataRoot)
    {
        if (!File.Exists(pluginPath))
            throw new FileNotFoundException("找不到插件 DLL。", pluginPath);
        if (!string.Equals(Path.GetExtension(pluginPath), ".dll", StringComparison.OrdinalIgnoreCase))
            throw new InvalidDataException("EXILED 插件必须是 .dll 文件。");

        var targetDirectory = Path.Combine(Path.GetFullPath(appDataRoot), "Plugins");
        Directory.CreateDirectory(targetDirectory);
        var targetPath = Path.Combine(targetDirectory, Path.GetFileName(pluginPath));
        File.Copy(pluginPath, targetPath, true);
        return $"插件已安装：{targetPath}";
    }

    public static string CreatePluginProject(string directory, string appDataRoot)
    {
        directory = Path.GetFullPath(directory);
        Directory.CreateDirectory(directory);
        var projectName = new DirectoryInfo(directory).Name;
        if (string.IsNullOrWhiteSpace(projectName))
            projectName = "CarlModPlugin";
        var safeName = Regex.Replace(projectName, "[^A-Za-z0-9_]", "_");
        var apiRoot = Path.Combine(Path.GetFullPath(appDataRoot), "Plugins", "dependencies");

        File.WriteAllText(Path.Combine(directory, safeName + ".csproj"), PluginProject(safeName), new UTF8Encoding(false));
        File.WriteAllText(Path.Combine(directory, "Plugin.cs"), PluginSource(safeName), new UTF8Encoding(false));
        File.WriteAllText(Path.Combine(directory, "Config.cs"), ConfigSource(safeName), new UTF8Encoding(false));
        File.WriteAllText(Path.Combine(directory, "README.md"), $"# {safeName}\r\n\r\n使用 .NET SDK 8/9 构建后，将 `bin\\Release\\net48\\{safeName}.dll` 放入 `%APPDATA%\\CarlMod-EXILED\\Plugins`。\r\n\r\n当前 EXILED API 引用目录：`{apiRoot}`。\r\n", new UTF8Encoding(false));
        return $"插件项目已创建：{directory}";
    }

    private static string ExtractPayload()
    {
        var root = Path.Combine(Path.GetTempPath(), "CarlMod-Exiled-Installer", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(root);
        using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(PayloadResource)
            ?? throw new InvalidDataException("安装器未包含 CarlMod-Exiled 载荷。请重新构建安装器。");
        using var archive = new ZipArchive(stream, ZipArchiveMode.Read, leaveOpen: false);
        foreach (var entry in archive.Entries)
        {
            var target = Path.GetFullPath(Path.Combine(root, entry.FullName));
            if (!target.StartsWith(root + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase) && !string.Equals(target, root, StringComparison.OrdinalIgnoreCase))
                throw new InvalidDataException("安装包包含非法路径。");
            if (string.IsNullOrEmpty(entry.Name))
            {
                Directory.CreateDirectory(target);
                continue;
            }
            Directory.CreateDirectory(Path.GetDirectoryName(target)!);
            entry.ExtractToFile(target, overwrite: true);
        }
        return root;
    }

    private static void CopyDirectory(string source, string target, bool force, bool preserveConfiguration)
    {
        Directory.CreateDirectory(target);
        foreach (var directory in Directory.GetDirectories(source, "*", SearchOption.AllDirectories))
            Directory.CreateDirectory(Path.Combine(target, Path.GetRelativePath(source, directory)));
        foreach (var file in Directory.GetFiles(source, "*", SearchOption.AllDirectories))
        {
            var destination = Path.Combine(target, Path.GetRelativePath(source, file));
            Directory.CreateDirectory(Path.GetDirectoryName(destination)!);
            var isConfiguration = preserveConfiguration && (file.EndsWith(".yml", StringComparison.OrdinalIgnoreCase) || file.EndsWith(".yaml", StringComparison.OrdinalIgnoreCase) || file.EndsWith(".json", StringComparison.OrdinalIgnoreCase));
            if (isConfiguration && File.Exists(destination) && !force)
                continue;
            File.Copy(file, destination, true);
        }
    }

    private static void TryDelete(string path)
    {
        try { if (Directory.Exists(path)) Directory.Delete(path, true); } catch { }
    }

    private static string PluginProject(string name) => $$"""
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <TargetFramework>net48</TargetFramework>
    <LangVersion>latest</LangVersion>
    <Nullable>enable</Nullable>
    <AssemblyName>{{name}}</AssemblyName>
    <RootNamespace>{{name}}</RootNamespace>
    <CarlModAppData Condition="'$(CarlModAppData)' == ''">$(APPDATA)\CarlMod-EXILED</CarlModAppData>
  </PropertyGroup>
  <ItemGroup>
    <Reference Include="Exiled.API"><HintPath>$(CarlModAppData)\Plugins\dependencies\Exiled.API.dll</HintPath><Private>False</Private></Reference>
    <Reference Include="Exiled.Events"><HintPath>$(CarlModAppData)\Plugins\Exiled.Events.dll</HintPath><Private>False</Private></Reference>
    <Reference Include="YamlDotNet"><HintPath>$(CarlModAppData)\Plugins\dependencies\YamlDotNet.dll</HintPath><Private>False</Private></Reference>
  </ItemGroup>
</Project>
""";

    private static string PluginSource(string name) => $$"""
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;

namespace {{name}};

public sealed class Plugin : Plugin<Config>
{
    public override string Name => "{{name}}";
    public override string Author => "CarlMod-Exiled developer";
    public override System.Version Version => new(1, 0, 0);

    public override void OnEnabled()
    {
        Exiled.Events.Handlers.Player.Verified += OnVerified;
        base.OnEnabled();
    }

    public override void OnDisabled()
    {
        Exiled.Events.Handlers.Player.Verified -= OnVerified;
        base.OnDisabled();
    }

    private void OnVerified(VerifiedEventArgs ev)
    {
        Log.Info($"{{name}} loaded player {ev.Player.Nickname}.");
    }
}
""";

    private static string ConfigSource(string name) => $$"""
using Exiled.API.Interfaces;

namespace {{name}};

public sealed class Config : IConfig
{
    public bool IsEnabled { get; set; } = true;
    public bool Debug { get; set; }
}
""";
}
