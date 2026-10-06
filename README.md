# Carl Mod EXILED 6.1.0-rc.1

这是面向 Carl Mod（游戏版本 12.0.1）的 EXILED 部署与源码归档。

## 目录

- `source/`：从原始 `output.no-proxies.dll` 导出的 C# 维护快照。
- `build/`：构建说明、项目引用清单和验证脚本。
- `deployment/`：包含完整 Carl Mod 服务端与 EXILED 运行时的可部署副本。
- `compiled/`：已验证的 Carl 插件程序集及元数据、SHA-256 哈希。
- `docs/`：验证记录、依赖和已知限制。

## 部署

1. 使用 `deployment/Carl Mod Server/` 作为服务器目录。
2. 使用安装脚本把 `deployment/Carl Mod Server/` 同步到服务器根目录；其中已经包含 `Exiled/Exiled.Loader.dll` 和 Loader 配置模板。
3. 安装后 `Carlfrellett.dll` 位于 `%AppData%\Roaming\CarlMod-EXILED\Plugins\`，依赖位于同目录的 `Plugins\dependencies\`。
4. 运行 `build/Install-CarlMod.ps1` 可把 EXILED 文件和配置同步到指定的服务端目录。
5. 配置和音乐资源默认位于 `%AppData%\Roaming\CarlMod-EXILED`。

## CarlMod-Exiled Installer

`compiled/CarlMod-Exiled.Installer.exe` 是 Windows x64 自包含安装器。双击后默认使用当前用户的 `%APPDATA%\CarlMod-EXILED`；选择服务器根目录后，安装器还会把 `Exiled.Loader.dll` 和 Loader 配置写入该服务器的 `Exiled` 目录，并自动把 `exiled_directory_path` 指向当前用户目录。

安装器支持：

- 安装或更新 Carl Mod 插件、EXILED API 依赖、配置和音乐资源。
- 选择一个或多个 `.dll`，直接安装到 `%APPDATA%\CarlMod-EXILED\Plugins`。
- 创建可构建的 EXILED 插件项目脚手架，项目引用当前安装的 `Exiled.API.dll`、`Exiled.Events.dll` 和 `YamlDotNet.dll`。

命令行自动安装示例：

```powershell
.\CarlMod-Exiled.Installer.exe --install --silent --server-root "D:\\SCP Secret Laboratory"
```

也可以使用 `build/Install-Plugin.ps1` 安装外部插件，或使用 `build/New-CarlPlugin.ps1` 创建插件项目。插件遵循 EXILED 的标准 `Plugins` / `Plugins\dependencies` 目录布局，因此可按普通 EXILED 插件方式开发、安装和加载。

## 构建状态

`compiled/Carlfrellett.dll` 是从已在 EXILED 6.0.0 / 游戏 12.0.1 环境成功加载的原始 Carl Mod 2.1.0 程序集逐字节归档，并保留原始文件 `output.no-proxies.dll`。`source/` 是反编译源码快照，便于维护和审计；由于原程序集中的 `ExperienceSystem.Enable` 存在损坏/异常控制流，反编译器无法生成可直接重编译的完整项目，因此本归档不声称该快照可直接产出相同二进制。

## 运行时要求

- Windows x64
- Carl Mod 游戏服务端 12.0.1
- EXILED Loader 6.0.0（本归档来自工作区内的 Exiled12.0.1）
- .NET Framework 4.8 / Mono 运行环境由游戏服务端提供

目录名 `EXILED-6.1.0-rc.1` 是用户指定的归档路径；运行时版本以 Carl 原始插件的 6.0.0 引用和已验证日志为准。
