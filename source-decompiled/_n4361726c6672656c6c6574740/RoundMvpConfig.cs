using System.ComponentModel;

namespace _n4361726c6672656c6c6574740;

public sealed class RoundMvpConfig
{
	[Description("人类玩家击杀 SCP 获得的分数。")]
	public float HumanKillsScpScore { get; set; }

	[Description("人类玩家击杀人类获得的分数。")]
	public float HumanKillsHumanScore { get; set; }

	[Description("SCP 玩家击杀任意玩家获得的分数；默认是人类击杀 SCP 分数的一半。")]
	public float ScpKillScore { get; set; }

	[Description("每造成 1 点伤害获得的分数。")]
	public float DamageScore { get; set; }

	[Description("每次死亡扣除的分数。")]
	public float DeathPenalty { get; set; }

	[Description("每次拾取 SCP 物品获得的分数。")]
	public float ScpItemPickupScore { get; set; }

	[Description("每次拾取 MicroHID 获得的分数。")]
	public float MicroHidPickupScore { get; set; }

	[Description("每次拾取分子裂解者获得的分数。")]
	public float ParticleDisruptorPickupScore { get; set; }

	[Description("每次拾取普通武器获得的分数。")]
	public float WeaponPickupScore { get; set; }

	[Description("每次拾取其他物品获得的分数。设为 0 可关闭普通拾取计分。")]
	public float OtherItemPickupScore { get; set; }

	[Description("每次成功使用医疗物品获得的分数。")]
	public float MedicalItemUseScore { get; set; }

	public RoundMvpConfig()
	{
		_f66122f373b34113336362909392a093935283f64310505183b393133343d1c333f363e606a = 1000f;
		_fFOZZyxqlRXqs = 200f;
		_f6609392a11333636093935283f64310505183b393133343d1c333f363e606a = 500f;
		_f3c44616d61676553636f72653e6b5f5f4261636b696e674669656c643a300 = 1f;
		_f1737b1f77bdaf45c = 100f;
		_fvNSJwmcDggFY = 150f;
		_f4beb673451c1d8f9 = 250f;
		_falvwitqFLtvJ = 200f;
		_f660d3f3b2a35340a3339312f2a093935283f64310505183b393133343d1c333f363e606a = 40f;
		_fWxtWlTGEhBYC = 5f;
		_fauIwyZUStNon = 100f;
		base._002Ector();
	}
}
