using System.ComponentModel;

namespace _n4361726c6672656c6c6574740;

public sealed class Scp106EnhancementConfig
{
	[Description("是否启用 SCP-106 强化。")]
	public bool IsEnabled { get; set; }

	[Description("第一次成功攻击是否立即将目标送入口袋空间。")]
	public bool CaptureOnFirstHit { get; set; }

	[Description("由口袋空间杀死玩家时 SCP-106 恢复的生命值；不会超过生命上限。")]
	public float PocketDeathHeal { get; set; }

	[Description("SCP-106 出生时的初始活力，范围为 0 到 1。")]
	public float InitialVigor { get; set; }

	[Description("SCP-106 等效活力上限倍率；通过同比降低活力消耗实现。")]
	public float VigorCapacityMultiplier { get; set; }

	public Scp106EnhancementConfig()
	{
		_fcTrfIDSAUCXu = true;
		_fnqKsQCqMhRgD = true;
		_f3c506f636b657444656174684865616c3e6b5f5f4261636b696e674669656c643a300 = 200f;
		_f3c496e697469616c5669676f723e6b5f5f4261636b696e674669656c643a300 = 1f;
		_f660c333d3528193b2a3b39332e23172f362e332a36333f2864310505183b393133343d1c333f363e606a = 10f;
		base._002Ector();
	}
}
