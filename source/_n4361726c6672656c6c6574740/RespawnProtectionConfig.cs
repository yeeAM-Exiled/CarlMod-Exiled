using System.ComponentModel;

namespace _n4361726c6672656c6c6574740;

public sealed class RespawnProtectionConfig
{
	[Description("是否启用阵营刷新出生保护。")]
	public bool IsEnabled { get; set; }

	[Description("阵营刷新玩家免疫其他玩家伤害的时间（秒）；开枪后立即失效。")]
	public float DurationSeconds { get; set; }

	public RespawnProtectionConfig()
	{
		_f6613291f343b38363f3e64310505183b393133343d1c333f363e606a = true;
		_f661e2f283b2e333534093f3935343e2964310505183b393133343d1c333f363e606a = 40f;
		base._002Ector();
	}
}
