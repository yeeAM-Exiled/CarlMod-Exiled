using System.ComponentModel;

namespace _n4361726c6672656c6c6574740;

public sealed class Scp049EnhancementConfig
{
	[Description("是否启用 SCP-049 强化。")]
	public bool IsEnabled { get; set; }

	[Description("SCP-049 的攻击是否一击必杀。")]
	public bool OneHitKill { get; set; }

	[Description("兼容旧配置；SCP-049 不再额外加速，此值固定为 1 倍。")]
	public float NormalSpeedMultiplier { get; set; }

	[Description("兼容旧配置；SCP-049 不再额外加速，此值固定为 1 倍。")]
	public float LockedTargetSpeedMultiplier { get; set; }

	[Description("兼容旧配置；SCP-049 复活 SCP-049-2 不再加速，此值固定为 1 倍。")]
	public float ReviveSpeedMultiplier { get; set; }

	public Scp049EnhancementConfig()
	{
		_f9379f70c7297ea08 = true;
		_fqBCFStgmnJPm = true;
		_f66143528373b36092a3f3f3e172f362e332a36333f2864310505183b393133343d1c333f363e606a = 1f;
		_fvFMehlLIkzEK = 1f;
		_fLDqAeDIJoaBn = 1f;
		base._002Ector();
	}
}
