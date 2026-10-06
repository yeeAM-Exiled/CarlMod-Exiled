namespace CarlModExiledInstaller;

internal sealed record InstallerArguments(
    bool Install,
    bool Silent,
    bool Force,
    string AppDataRoot,
    string? ServerRoot,
    string? PluginPath,
    string? CreatePluginDirectory)
{
    public static InstallerArguments Parse(string[] args)
    {
        var install = false;
        var silent = false;
        var force = false;
        var appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CarlMod-EXILED");
        string? server = null;
        string? plugin = null;
        string? create = null;

        for (var i = 0; i < args.Length; i++)
        {
            switch (args[i].ToLowerInvariant())
            {
                case "--install": install = true; break;
                case "--silent": silent = true; break;
                case "--force": force = true; break;
                case "--appdata": appData = Next(args, ref i, "--appdata"); break;
                case "--server-root": server = Next(args, ref i, "--server-root"); break;
                case "--plugin": plugin = Next(args, ref i, "--plugin"); install = true; break;
                case "--create-plugin": create = Next(args, ref i, "--create-plugin"); install = true; break;
            }
        }

        return new InstallerArguments(install, silent, force, Path.GetFullPath(appData), server is null ? null : Path.GetFullPath(server), plugin, create);
    }

    private static string Next(string[] args, ref int index, string option)
    {
        if (++index >= args.Length || string.IsNullOrWhiteSpace(args[index]))
            throw new ArgumentException($"{option} 需要一个路径参数。", option);
        return args[index];
    }
}
