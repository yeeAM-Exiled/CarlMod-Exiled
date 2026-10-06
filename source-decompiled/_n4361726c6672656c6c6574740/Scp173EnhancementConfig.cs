using System.ComponentModel;

namespace _n4361726c6672656c6c6574740;

public sealed class Scp173EnhancementConfig
{
	[Description("是否启用 SCP-173 强化。")]
	public bool IsEnabled { get; set; }

	[Description("兼容旧配置；SCP-173 不再额外加速，此值固定为 1 倍。")]
	public float NormalSpeedMultiplier { get; set; }

	[Description("兼容旧配置；SCP-173 不再额外加速，此值固定为 1 倍。")]
	public float BreakneckSpeedMultiplier { get; set; }

	public Scp173EnhancementConfig()
	{
		_f6613291f343b38363f3e64310505183b393133343d1c333f363e606a = true;
		_fae361863bb7d6c80 = 1f;
		_f3c427265616b6e65636b53706565644d756c7469706c6965723e6b5f5f4261636b696e674669656c643a300 = 1f;
		base._002Ector();
	}
}
