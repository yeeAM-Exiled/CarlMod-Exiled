using System.ComponentModel;

namespace _n4361726c6672656c6c6574740;

public sealed class ScpKillHealingConfig
{
	[Description("是否允许 SCP 击杀非 SCP 玩家后恢复生命值。")]
	public bool IsEnabled { get; set; }

	[Description("SCP 每次完成有效击杀后恢复的生命值；不会超过生命上限。")]
	public float HealAmount { get; set; }

	public ScpKillHealingConfig()
	{
		_f6613291f343b38363f3e64310505183b393133343d1c333f363e606a = true;
		_fmdCgpzlDMdFn = 200f;
		base._002Ector();
	}
}
