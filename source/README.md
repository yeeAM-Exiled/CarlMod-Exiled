# Carl Mod 源码快照

本目录由 `output.no-proxies.dll` 反编译生成，保留了插件主类、配置模型、管理员命令、经验系统、音乐盒、MVP、Web API、SCP 强化、Harmony 补丁等实现。由于原程序集使用了混淆命名空间，文件名和类型名中仍会出现 `_n...`、`_t...` 形式。

这是维护和审计用快照。原程序集中的 `ExperienceSystem.Enable` 含有损坏/异常控制流，反编译器报告 `The end must be after the start`，所以快照不能直接视为可重建源码；运行时使用 `compiled/Carlfrellett.dll` 中经过历史启动验证的原始程序集。
