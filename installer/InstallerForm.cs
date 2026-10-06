using System.Diagnostics;

namespace CarlModExiledInstaller;

internal sealed class InstallerForm : Form
{
    private readonly TextBox _serverRoot = new();
    private readonly TextBox _appDataRoot = new();
    private readonly TextBox _status = new();

    public InstallerForm()
    {
        Text = "CarlMod-Exiled Installer";
        StartPosition = FormStartPosition.CenterScreen;
        MinimumSize = new Size(760, 520);
        Width = 820;
        Height = 560;

        var appData = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CarlMod-EXILED");
        _appDataRoot.Text = appData;
        _appDataRoot.ReadOnly = true;
        _status.Multiline = true;
        _status.ScrollBars = ScrollBars.Vertical;
        _status.ReadOnly = true;
        _status.Dock = DockStyle.Fill;

        var root = new TableLayoutPanel { Dock = DockStyle.Fill, Padding = new Padding(18), ColumnCount = 3, RowCount = 8 };
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 145));
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
        root.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 55));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 42));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 55));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 55));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 55));
        root.RowStyles.Add(new RowStyle(SizeType.Absolute, 55));
        root.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

        var title = new Label { Text = "CarlMod-Exiled", Font = new Font(Font.FontFamily, 18, FontStyle.Bold), Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft };
        root.Controls.Add(title, 0, 0); root.SetColumnSpan(title, 3);
        root.Controls.Add(new Label { Text = "当前用户目录", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 0, 1);
        root.Controls.Add(_appDataRoot, 1, 1); root.SetColumnSpan(_appDataRoot, 2);
        root.Controls.Add(new Label { Text = "服务器根目录", Dock = DockStyle.Fill, TextAlign = ContentAlignment.MiddleLeft }, 0, 2);
        root.Controls.Add(_serverRoot, 1, 2);
        var browse = new Button { Text = "选择目录", Dock = DockStyle.Fill };
        browse.Click += (_, _) => BrowseServer();
        root.Controls.Add(browse, 2, 2);

        var install = new Button { Text = "安装 CarlMod-Exiled", Dock = DockStyle.Fill };
        install.Click += (_, _) => RunInstall();
        root.Controls.Add(install, 0, 3); root.SetColumnSpan(install, 3);
        var plugin = new Button { Text = "安装插件 DLL", Dock = DockStyle.Fill };
        plugin.Click += (_, _) => InstallPlugin();
        root.Controls.Add(plugin, 0, 4); root.SetColumnSpan(plugin, 3);
        var create = new Button { Text = "创建插件项目", Dock = DockStyle.Fill };
        create.Click += (_, _) => CreatePlugin();
        root.Controls.Add(create, 0, 5); root.SetColumnSpan(create, 3);
        var open = new Button { Text = "打开 CarlMod-EXILED 文件夹", Dock = DockStyle.Fill };
        open.Click += (_, _) => Process.Start(new ProcessStartInfo("explorer.exe", _appDataRoot.Text) { UseShellExecute = true });
        root.Controls.Add(open, 0, 6); root.SetColumnSpan(open, 3);
        root.Controls.Add(_status, 0, 7); root.SetColumnSpan(_status, 3);
        Controls.Add(root);
        Append("准备就绪。选择服务器目录后点击安装，可同时部署 EXILED Loader；留空则只安装当前用户插件运行时。\r\n");
    }

    private void BrowseServer()
    {
        using var dialog = new FolderBrowserDialog { Description = "选择 SCP: Secret Laboratory / Carl Mod 服务器根目录" };
        if (dialog.ShowDialog(this) == DialogResult.OK)
            _serverRoot.Text = dialog.SelectedPath;
    }

    private void RunInstall()
    {
        try
        {
            var result = InstallerCore.InstallRuntime(_appDataRoot.Text, string.IsNullOrWhiteSpace(_serverRoot.Text) ? null : _serverRoot.Text, force: false);
            foreach (var message in result.Messages) Append(message + "\r\n");
            MessageBox.Show(this, "安装完成。", "CarlMod-Exiled", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex) { ShowError(ex); }
    }

    private void InstallPlugin()
    {
        using var dialog = new OpenFileDialog { Filter = "EXILED 插件 (*.dll)|*.dll|所有文件 (*.*)|*.*", Multiselect = true };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        try
        {
            foreach (var path in dialog.FileNames)
                Append(InstallerCore.InstallPlugin(path, _appDataRoot.Text) + "\r\n");
        }
        catch (Exception ex) { ShowError(ex); }
    }

    private void CreatePlugin()
    {
        using var dialog = new FolderBrowserDialog { Description = "选择新插件项目目录（建议新建空文件夹）" };
        if (dialog.ShowDialog(this) != DialogResult.OK) return;
        try { Append(InstallerCore.CreatePluginProject(dialog.SelectedPath, _appDataRoot.Text) + "\r\n"); }
        catch (Exception ex) { ShowError(ex); }
    }

    private void Append(string message) => _status.AppendText(message);
    private void ShowError(Exception ex) => MessageBox.Show(this, ex.Message, "操作失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
}
