using System.ComponentModel;

namespace _n4361726c6672656c6c6574740;

public sealed class MicroHidEnhancementConfig
{
	[Description("是否启用 Micro H.I.D. 伤害强化。")]
	public bool IsEnabled { get; set; }

	[Description("Micro H.I.D. 实际伤害倍率。")]
	public float DamageMultiplier { get; set; }

	[Description("Micro H.I.D. 等效电量上限倍率；通过同比降低所有状态的能量消耗实现。")]
	public float EnergyCapacityMultiplier { get; set; }

	public MicroHidEnhancementConfig()
	{
		_fCCpYgKLxnuqQ = true;
		_fwlLAcejFCwem = 2f;
		_fe62cf40e4a91adeb = 3f;
		base._002Ector();
	}
}
