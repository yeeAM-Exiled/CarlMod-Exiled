# 构建与验证

## 构建安装器

在 Windows x64、安装 .NET 9 SDK 的环境执行：

```powershell
pwsh -NoProfile -ExecutionPolicy Bypass -File .\build\Build-CarlMod-Installer.ps1
```

脚本从 `deployment/CarlMod-AppData` 和 `deployment/Exiled` 生成嵌入式载荷，然后使用 `dotnet publish` 生成 `compiled/CarlMod-Exiled.Installer.exe`。安装器是 `net8.0-windows`、win-x64、自包含单文件程序。

## 自动化验证

```powershell
pwsh -NoProfile -ExecutionPolicy Bypass -File .\build\Test-CarlMod-Installer.ps1
```

验证会在 `docs/installer-test` 创建临时服务器目录，检查：

- 当前用户目录中的 Carl 插件、EXILED 依赖和配置；
- 服务器 `Exiled` 目录中的 Loader 与 `loader.yml`；
- `exiled_directory_path` 是否指向当前用户目录；
- 插件安装器是否能生成 EXILED 插件项目脚手架。

## GitHub 发布布局

仓库源码不追踪 `deployment/Carl Mod Server`，因为完整服务器镜像约 640 MB 且包含超过 GitHub 普通仓库单文件限制的安装包。将 `deployment/Carl Mod Server` 压缩为 Release Asset；源码仓库保留安装器工程、Carl 插件运行时、EXILED 载荷、配置、脚本和验证记录。
