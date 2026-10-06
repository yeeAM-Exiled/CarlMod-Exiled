using System.ComponentModel;

namespace _n4361726c6672656c6c6574740;

public sealed class Scp079EnhancementConfig
{
	[Description("是否启用 SCP-079 强化。")]
	public bool IsEnabled { get; set; }

	[Description("SCP-079 电力恢复速度倍率。")]
	public float EnergyRegenerationMultiplier { get; set; }

	[Description("鬼灯在 SCP-079 当前观察的房间内生效时直接杀死 SCP-079 的概率；0.001 表示千分之一。")]
	public float GhostlightInstantKillChance { get; set; }

	public Scp079EnhancementConfig()
	{
		_f9379f70c7297ea08 = true;
		_fkkGlPgHIXLQf = 3f;
		_f9750df4514ca8e72 = 0.001f;
		base._002Ector();
	}
}
