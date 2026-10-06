using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Exiled.API.Interfaces;

namespace _n4361726c6672656c6c6574740;

public class Config : IConfig
{
	[Description("是否启用插件。")]
	public bool IsEnabled { get; set; }

	[Description("是否输出 EXILED 调试日志。")]
	public bool Debug { get; set; }

	[Description("信息刷新间隔，单位为秒。")]
	public float RefreshIntervalSeconds { get; set; }

	[Description("SCP 静止回血相关配置。")]
	public ScpStandStillRegenerationConfig ScpStandStillRegeneration { get; set; }

	[Description("SCP 强化相关配置。")]
	public ScpEnhancementsConfig ScpEnhancements { get; set; }

	[Description("SCP-079 强化相关配置。")]
	public Scp079EnhancementConfig Scp079Enhancement { get; set; }

	[Description("SCP-500 强化相关配置。")]
	public Scp500EnhancementConfig Scp500Enhancement { get; set; }

	[Description("粒子分裂者伤害强化倍率。")]
	public float ParticleDisruptorDamageMultiplier { get; set; }

	[Description("Micro H.I.D. 强化相关配置。")]
	public MicroHidEnhancementConfig MicroHidEnhancement { get; set; }

	[Description("是否移除护甲造成的移动速度降低。")]
	public bool DisableArmorMovementPenalty { get; set; }

	[Description("人类使用枪械攻击人类或 SCP 时的额外命中部位伤害倍率。")]
	public FirearmHitboxDamageConfig FirearmHitboxDamage { get; set; }

	[Description("阵营刷新后的玩家出生保护配置。")]
	public RespawnProtectionConfig RespawnProtection { get; set; }

	[Description("回合 MVP 统计与评分配置。")]
	public RoundMvpConfig RoundMvp { get; set; }

	[Description("大厅与 MVP 音乐盒配置。")]
	public MusicBoxConfig MusicBox { get; set; }

	[Description("怀旧服经验系统配置；每项行为单次最多获得 50 点，击杀类不设次数或每日总量限制。")]
	public ExperienceSystemConfig ExperienceSystem { get; set; }

	[Description("服务器定期软重启配置。软重启会让在线玩家自动重连。")]
	public ScheduledRestartConfig ScheduledRestart { get; set; }

	internal int _m4e6f726d616c697a653a300()
	{
		int num = 0;
		if (ScpStandStillRegeneration == null)
		{
			ScpStandStillRegeneration = new ScpStandStillRegenerationConfig();
			num++;
		}
		if (ScpEnhancements == null)
		{
			ScpEnhancements = new ScpEnhancementsConfig();
			num++;
		}
		if (Scp079Enhancement == null)
		{
			Scp079Enhancement = new Scp079EnhancementConfig();
			num++;
		}
		if (Scp500Enhancement == null)
		{
			Scp500Enhancement = new Scp500EnhancementConfig();
			num++;
		}
		if (MicroHidEnhancement == null)
		{
			MicroHidEnhancement = new MicroHidEnhancementConfig();
			num++;
		}
		if (FirearmHitboxDamage == null)
		{
			FirearmHitboxDamage = new FirearmHitboxDamageConfig();
			num++;
		}
		if (RespawnProtection == null)
		{
			RespawnProtection = new RespawnProtectionConfig();
			num++;
		}
		if (RoundMvp == null)
		{
			RoundMvp = new RoundMvpConfig();
			num++;
		}
		if (MusicBox == null)
		{
			MusicBox = new MusicBoxConfig();
			num++;
		}
		if (ExperienceSystem == null)
		{
			ExperienceSystem = new ExperienceSystemConfig();
			num++;
		}
		if (ScheduledRestart == null)
		{
			ScheduledRestart = new ScheduledRestartConfig();
			num++;
		}
		num += _mad02df709401ef69(RefreshIntervalSeconds, 1f, 0.25f, 60f, delegate(float value)
		{
			RefreshIntervalSeconds = value;
		});
		num += _mad02df709401ef69(ScpStandStillRegeneration.StartAfterSeconds, 5f, 0f, 600f, delegate(float value)
		{
			ScpStandStillRegeneration.StartAfterSeconds = value;
		});
		num += _mad02df709401ef69(ScpStandStillRegeneration.HealPerSecond, 3f, 0f, 10000f, delegate(float value)
		{
			ScpStandStillRegeneration.HealPerSecond = value;
		});
		num += ScpEnhancements._m143528373b3633203f606a();
		num += _mad02df709401ef69(Scp079Enhancement.EnergyRegenerationMultiplier, 3f, 0.1f, 100f, delegate(float value)
		{
			Scp079Enhancement.EnergyRegenerationMultiplier = value;
		});
		num += _mad02df709401ef69(Scp079Enhancement.GhostlightInstantKillChance, 0.001f, 0f, 1f, delegate(float value)
		{
			Scp079Enhancement.GhostlightInstantKillChance = value;
		});
		num += _mad02df709401ef69(Scp500Enhancement.RegenerationDurationMultiplier, 2f, 1f, 20f, delegate(float value)
		{
			Scp500Enhancement.RegenerationDurationMultiplier = value;
		});
		num += _mad02df709401ef69(ParticleDisruptorDamageMultiplier, 2f, 0f, 100f, delegate(float value)
		{
			ParticleDisruptorDamageMultiplier = value;
		});
		num += _mad02df709401ef69(MicroHidEnhancement.DamageMultiplier, 2f, 0f, 100f, delegate(float value)
		{
			MicroHidEnhancement.DamageMultiplier = value;
		});
		if (MicroHidEnhancement.EnergyCapacityMultiplier.Equals(2f))
		{
			MicroHidEnhancement.EnergyCapacityMultiplier = 3f;
			num++;
		}
		num += _mad02df709401ef69(MicroHidEnhancement.EnergyCapacityMultiplier, 3f, 0.1f, 100f, delegate(float value)
		{
			MicroHidEnhancement.EnergyCapacityMultiplier = value;
		});
		num += _mad02df709401ef69(FirearmHitboxDamage.HumanHeadshotMultiplier, 1.5f, 0f, 100f, delegate(float value)
		{
			FirearmHitboxDamage.HumanHeadshotMultiplier = value;
		});
		num += _mad02df709401ef69(FirearmHitboxDamage.HumanBodyMultiplier, 0.5f, 0f, 100f, delegate(float value)
		{
			FirearmHitboxDamage.HumanBodyMultiplier = value;
		});
		num += _mad02df709401ef69(FirearmHitboxDamage.ScpHeadshotMultiplier, 1.5f, 0f, 100f, delegate(float value)
		{
			FirearmHitboxDamage.ScpHeadshotMultiplier = value;
		});
		num += _mad02df709401ef69(RespawnProtection.DurationSeconds, 40f, 0f, 600f, delegate(float value)
		{
			RespawnProtection.DurationSeconds = value;
		});
		num += _mad02df709401ef69(RoundMvp.HumanKillsScpScore, 1000f, 0f, 100000f, delegate(float value)
		{
			RoundMvp.HumanKillsScpScore = value;
		});
		num += _mad02df709401ef69(RoundMvp.HumanKillsHumanScore, 200f, 0f, 100000f, delegate(float value)
		{
			RoundMvp.HumanKillsHumanScore = value;
		});
		num += _mad02df709401ef69(RoundMvp.ScpKillScore, 500f, 0f, 100000f, delegate(float value)
		{
			RoundMvp.ScpKillScore = value;
		});
		num += _mad02df709401ef69(RoundMvp.DamageScore, 1f, 0f, 1000f, delegate(float value)
		{
			RoundMvp.DamageScore = value;
		});
		num += _mad02df709401ef69(RoundMvp.DeathPenalty, 100f, 0f, 100000f, delegate(float value)
		{
			RoundMvp.DeathPenalty = value;
		});
		num += _mad02df709401ef69(RoundMvp.ScpItemPickupScore, 150f, 0f, 100000f, delegate(float value)
		{
			RoundMvp.ScpItemPickupScore = value;
		});
		num += _mad02df709401ef69(RoundMvp.MicroHidPickupScore, 250f, 0f, 100000f, delegate(float value)
		{
			RoundMvp.MicroHidPickupScore = value;
		});
		num += _mad02df709401ef69(RoundMvp.ParticleDisruptorPickupScore, 200f, 0f, 100000f, delegate(float value)
		{
			RoundMvp.ParticleDisruptorPickupScore = value;
		});
		num += _mad02df709401ef69(RoundMvp.WeaponPickupScore, 40f, 0f, 100000f, delegate(float value)
		{
			RoundMvp.WeaponPickupScore = value;
		});
		num += _mad02df709401ef69(RoundMvp.OtherItemPickupScore, 5f, 0f, 100000f, delegate(float value)
		{
			RoundMvp.OtherItemPickupScore = value;
		});
		num += _mad02df709401ef69(RoundMvp.MedicalItemUseScore, 100f, 0f, 100000f, delegate(float value)
		{
			RoundMvp.MedicalItemUseScore = value;
		});
		num += _mad02df709401ef69(MusicBox.LobbyVolume, 10f, 0f, 100f, delegate(float value)
		{
			MusicBox.LobbyVolume = value;
		});
		num += _mad02df709401ef69(MusicBox.MvpVolume, 10f, 0f, 100f, delegate(float value)
		{
			MusicBox.MvpVolume = value;
		});
		num += ExperienceSystem._m143528373b3633203f606a();
		return num + ScheduledRestart._m143528373b3633203f606a();
	}

	private static int _mad02df709401ef69(float configured, float fallback, float minimum, float maximum, Action<float> assign)
	{
		float obj = ((float.IsNaN(configured) || float.IsInfinity(configured)) ? fallback : Math.Max(minimum, Math.Min(maximum, configured)));
		assign(obj);
		return (!configured.Equals(obj)) ? 1 : 0;
	}

	public Config()
	{
		_fJhztRhfUtVJA = true;
		_f66083f3c283f293213342e3f282c3b36093f3935343e2964310505183b393133343d1c333f363e606a = 1f;
		_f1e8cc6e3e9cb5ade = new ScpStandStillRegenerationConfig();
		_f6609392a1f34323b34393f373f342e2964310505183b393133343d1c333f363e606a = new ScpEnhancementsConfig();
		_f0571965a360e444f = new Scp079EnhancementConfig();
		_f6609392a6f6a6a1f34323b34393f373f342e64310505183b393133343d1c333f363e606a = new Scp500EnhancementConfig();
		_f996a816a72d6f31e = 2f;
		_fKeBuvNPFTpYG = new MicroHidEnhancementConfig();
		_f4489f9b2610be615 = true;
		_f3c4669726561726d486974626f7844616d6167653e6b5f5f4261636b696e674669656c643a300 = new FirearmHitboxDamageConfig();
		_figBtaSNriXvK = new RespawnProtectionConfig();
		_f6608352f343e172c2a64310505183b393133343d1c333f363e606a = new RoundMvpConfig();
		_f66172f29333918352264310505183b393133343d1c333f363e606a = new MusicBoxConfig();
		_fecrUBNxEnmfp = new ExperienceSystemConfig();
		_f147c20df246574a7 = new ScheduledRestartConfig();
		base._002Ector();
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f36345f303a300(float value)
	{
		RefreshIntervalSeconds = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f36345f313a300(float value)
	{
		ScpStandStillRegeneration.StartAfterSeconds = value;
	}

	[CompilerGenerated]
	private void _m3f5c4a00e37bdd55(float value)
	{
		ScpStandStillRegeneration.HealPerSecond = value;
	}

	[CompilerGenerated]
	private void _mAsDRJVxDBRVs(float value)
	{
		Scp079Enhancement.EnergyRegenerationMultiplier = value;
	}

	[CompilerGenerated]
	private void _m66143528373b3633203f643805056c6e056e606a(float value)
	{
		Scp079Enhancement.GhostlightInstantKillChance = value;
	}

	[CompilerGenerated]
	private void _mOsmnrXMWRJSd(float value)
	{
		Scp500Enhancement.RegenerationDurationMultiplier = value;
	}

	[CompilerGenerated]
	private void _m66143528373b3633203f643805056c6e056c606a(float value)
	{
		ParticleDisruptorDamageMultiplier = value;
	}

	[CompilerGenerated]
	private void _m87a0da3ab60c1b78(float value)
	{
		MicroHidEnhancement.DamageMultiplier = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f36345f383a300(float value)
	{
		MicroHidEnhancement.EnergyCapacityMultiplier = value;
	}

	[CompilerGenerated]
	private void _m1b8d7d6c3a37d635(float value)
	{
		FirearmHitboxDamage.HumanHeadshotMultiplier = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f36345f31303a300(float value)
	{
		FirearmHitboxDamage.HumanBodyMultiplier = value;
	}

	[CompilerGenerated]
	private void _m9c12ea55cd27eeda(float value)
	{
		FirearmHitboxDamage.ScpHeadshotMultiplier = value;
	}

	[CompilerGenerated]
	private void _m061fddd3f655a403(float value)
	{
		RespawnProtection.DurationSeconds = value;
	}

	[CompilerGenerated]
	private void _mxOkosEfADZVv(float value)
	{
		RoundMvp.HumanKillsScpScore = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f36345f31343a300(float value)
	{
		RoundMvp.HumanKillsHumanScore = value;
	}

	[CompilerGenerated]
	private void _m66143528373b3633203f643805056c6e056b6f606a(float value)
	{
		RoundMvp.ScpKillScore = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f36345f31363a300(float value)
	{
		RoundMvp.DamageScore = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f36345f31373a300(float value)
	{
		RoundMvp.DeathPenalty = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f36345f31383a300(float value)
	{
		RoundMvp.ScpItemPickupScore = value;
	}

	[CompilerGenerated]
	private void _mANLqKWzqmQTM(float value)
	{
		RoundMvp.MicroHidPickupScore = value;
	}

	[CompilerGenerated]
	private void _m66143528373b3633203f643805056c6e05686a606a(float value)
	{
		RoundMvp.ParticleDisruptorPickupScore = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f36345f32313a300(float value)
	{
		RoundMvp.WeaponPickupScore = value;
	}

	[CompilerGenerated]
	private void _m8b6038f32d9c9624(float value)
	{
		RoundMvp.OtherItemPickupScore = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f36345f32333a300(float value)
	{
		RoundMvp.MedicalItemUseScore = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f36345f32343a300(float value)
	{
		MusicBox.LobbyVolume = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f36345f32353a300(float value)
	{
		MusicBox.MvpVolume = value;
	}
}
