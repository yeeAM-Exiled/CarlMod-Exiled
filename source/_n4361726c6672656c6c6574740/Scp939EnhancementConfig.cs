using System.ComponentModel;

namespace _n4361726c6672656c6c6574740;

public sealed class Scp939EnhancementConfig
{
	[Description("是否启用 SCP-939 强化。")]
	public bool IsEnabled { get; set; }

	[Description("SCP-939 等效体力上限倍率；通过同比降低体力消耗实现。")]
	public float StaminaCapacityMultiplier { get; set; }

	[Description("SCP-939 所有攻击伤害倍率。")]
	public float DamageMultiplier { get; set; }

	public Scp939EnhancementConfig()
	{
		_fUzuJGQBtMsNP = true;
		_f3c5374616d696e6143617061636974794d756c7469706c6965723e6b5f5f4261636b696e674669656c643a300 = 10f;
		_f3c44616d6167654d756c7469706c6965723e6b5f5f4261636b696e674669656c643a300 = 2f;
		base._002Ector();
	}
}
