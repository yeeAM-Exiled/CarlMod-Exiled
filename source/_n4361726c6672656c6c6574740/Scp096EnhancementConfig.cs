using System.ComponentModel;

namespace _n4361726c6672656c6c6574740;

public sealed class Scp096EnhancementConfig
{
	[Description("是否启用 SCP-096 强化。")]
	public bool IsEnabled { get; set; }

	[Description("SCP-096 的攻击是否一击必杀。")]
	public bool OneHitKill { get; set; }

	[Description("狂暴期间每个新增目标增加的狂暴时间（秒）。")]
	public float RageSecondsPerTarget { get; set; }

	[Description("兼容旧配置；SCP-096 新增目标不再获得休谟护盾，此值固定为 0。")]
	public float HumeShieldPerTarget { get; set; }

	public Scp096EnhancementConfig()
	{
		_f6613291f343b38363f3e64310505183b393133343d1c333f363e606a = true;
		_f4cf1b6d08aa63db6 = true;
		_f3c526167655365636f6e64735065725461726765743e6b5f5f4261636b696e674669656c643a300 = 15f;
		base._002Ector();
	}
}
