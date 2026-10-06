using System.ComponentModel;

namespace _n4361726c6672656c6c6574740;

public sealed class FirearmHitboxDamageConfig
{
	[Description("是否启用枪械命中部位额外伤害倍率。")]
	public bool IsEnabled { get; set; }

	[Description("人类目标头部伤害在原版最终伤害基础上的倍率。")]
	public float HumanHeadshotMultiplier { get; set; }

	[Description("人类目标身体伤害在原版最终伤害基础上的倍率。")]
	public float HumanBodyMultiplier { get; set; }

	[Description("SCP 目标头部伤害在原版最终伤害基础上的倍率。")]
	public float ScpHeadshotMultiplier { get; set; }

	public FirearmHitboxDamageConfig()
	{
		_f6613291f343b38363f3e64310505183b393133343d1c333f363e606a = true;
		_f66122f373b34123f3b3e2932352e172f362e332a36333f2864310505183b393133343d1c333f363e606a = 1.5f;
		_fTEYTgczOIkNj = 0.5f;
		_fGLHYnAMIxtRI = 1.5f;
		base._002Ector();
	}
}
