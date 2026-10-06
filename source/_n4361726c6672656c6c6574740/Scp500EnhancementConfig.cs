using System.ComponentModel;

namespace _n4361726c6672656c6c6574740;

public sealed class Scp500EnhancementConfig
{
	[Description("是否启用 SCP-500 强化。")]
	public bool IsEnabled { get; set; }

	[Description("SCP-500 持续回血时间倍率；总恢复量保持不变。")]
	public float RegenerationDurationMultiplier { get; set; }

	public Scp500EnhancementConfig()
	{
		_f3c4973456e61626c65643e6b5f5f4261636b696e674669656c643a300 = true;
		_f66083f3d3f343f283b2e3335341e2f283b2e333534172f362e332a36333f2864310505183b393133343d1c333f363e606a = 2f;
		base._002Ector();
	}
}
