using System.Diagnostics;

namespace CarlModExiledInstaller;

internal static class Program
{
    [STAThread]
    private static void Main(string[] args)
    {
        ApplicationConfiguration.Initialize();

        try
        {
            var command = InstallerArguments.Parse(args);
            if (command.Install)
            {
                var result = InstallerCore.InstallRuntime(command.AppDataRoot, command.ServerRoot, command.Force);
                if (command.PluginPath is not null)
                    result.Messages.Add(InstallerCore.InstallPlugin(command.PluginPath, command.AppDataRoot));
                if (command.CreatePluginDirectory is not null)
                    result.Messages.Add(InstallerCore.CreatePluginProject(command.CreatePluginDirectory, command.AppDataRoot));

                if (command.Silent)
                    return;

                MessageBox.Show(string.Join(Environment.NewLine, result.Messages), "CarlMod-Exiled 安装完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Application.Run(new InstallerForm());
        }
        catch (Exception ex)
        {
            if (Debugger.IsAttached)
                throw;

            MessageBox.Show(ex.ToString(), "CarlMod-Exiled 安装失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.ExitCode = 1;
        }
    }
}
