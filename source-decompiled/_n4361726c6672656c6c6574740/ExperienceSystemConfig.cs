using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _n4361726c6672656c6c6574740;

public sealed class ExperienceSystemConfig
{
	[Description("是否启用怀旧服经验系统。")]
	public bool IsEnabled { get; set; }

	[Description("添加经验接口地址。")]
	public string ApiUrl { get; set; }

	[Description("添加经验接口 Token。")]
	public string Token { get; set; }

	[Description("查询玩家等级与经验信息的接口地址。")]
	public string PlayerInfoApiUrl { get; set; }

	[Description("玩家等级信息缓存时间（秒）；列表读取缓存，避免频繁请求远端接口。")]
	public float PlayerInfoCacheSeconds { get; set; }

	[Description("击杀敌对人类获得的经验值。每项行为最多奖励 50 点。")]
	public double KillExperience { get; set; }

	[Description("击杀武装单位经验。")]
	public double ArmedKillExperience { get; set; }

	[Description("击杀设施警卫经验。")]
	public double FacilityGuardKillExperience { get; set; }

	[Description("击杀小僵尸经验。")]
	public double ZombieKillExperience { get; set; }

	[Description("SCP 击杀敌对人类获得的经验值。")]
	public double ScpHumanKillExperience { get; set; }

	[Description("对敌对人类造成至少 20% 有效伤害并由队友完成击杀时获得的助攻经验。")]
	public double KillAssistExperience { get; set; }

	[Description("助攻击杀武装单位经验。")]
	public double ArmedKillAssistExperience { get; set; }

	[Description("助攻击杀异常经验。")]
	public double AnomalyKillAssistExperience { get; set; }

	[Description("助攻击杀小僵尸经验。")]
	public double ZombieKillAssistExperience { get; set; }

	[Description("对 SCP 完成击杀获得的经验值。")]
	public double ScpKillExperience { get; set; }

	[Description("对 SCP 完成最后一击的额外经验值。")]
	public double ScpFinalBlowExperience { get; set; }

	[Description("对 SCP 造成 100% 有效伤害时获得的经验值；实际按伤害占比分配。")]
	public double ScpFullDamageExperience { get; set; }

	[Description("每台发电机首次插板获得的经验值；同一台发电机本回合只奖励首名玩家。")]
	public double GeneratorUnlockExperience { get; set; }

	[Description("手动成功启动核弹获得的经验值；自动启动不计入玩家。")]
	public double WarheadExperience { get; set; }

	[Description("作为初始单位存活到第一次大部队刷新获得的经验值。")]
	public double InitialWaveSurvivalExperience { get; set; }

	[Description("每名玩家每回合首次成功撤离获得的经验值。")]
	public double EscapeExperience { get; set; }

	[Description("安保撤离经验。")]
	public double GuardEscapeExperience { get; set; }

	[Description("武装被捆绑撤离经验。")]
	public double CuffedArmedEscapeExperience { get; set; }

	[Description("捆绑并护送被捆绑者撤离经验。")]
	public double EscortCuffedEscapeExperience { get; set; }

	[Description("每个 SCP 物品实体首次拾取或首次使用获得的经验值。")]
	public double ScpItemUseExperience { get; set; }

	[Description("每个 Micro H.I.D. 实体首次拾取或首次使用获得的经验值。")]
	public double MicroHidExperience { get; set; }

	[Description("每回合首次成功逃出腐蚀空间获得的经验值。")]
	public double PocketEscapeExperience { get; set; }

	[Description("回合结束时仍存活获得的额外经验值。")]
	public double RoundSurvivalExperience { get; set; }

	[Description("回合结束时所属阵营获胜获得的额外经验值。")]
	public double RoundVictoryExperience { get; set; }

	[Description("获得回合 MVP 的经验值。")]
	public double MvpExperience { get; set; }

	[Description("战败队伍最佳玩家 SVP 经验。")]
	public double SvpExperience { get; set; }

	[Description("经验接口请求超时时间（秒）。")]
	public float RequestTimeoutSeconds { get; set; }

	internal int _m143528373b3633203f606a()
	{
		int num = 0;
		if (ApiUrl == null)
		{
			ApiUrl = string.Empty;
			num++;
		}
		if (Token == null)
		{
			Token = string.Empty;
			num++;
		}
		if (PlayerInfoApiUrl == null)
		{
			PlayerInfoApiUrl = string.Empty;
			num++;
		}
		if (KillExperience.Equals(5.0))
		{
			KillExperience = 1.0;
			num++;
		}
		if (ScpHumanKillExperience.Equals(6.0))
		{
			ScpHumanKillExperience = 1.0;
			num++;
		}
		if (KillAssistExperience.Equals(3.0))
		{
			KillAssistExperience = 0.5;
			num++;
		}
		if (ScpKillExperience.Equals(35.0))
		{
			ScpKillExperience = 10.0;
			num++;
		}
		if (ScpFinalBlowExperience.Equals(10.0))
		{
			ScpFinalBlowExperience = 5.0;
			num++;
		}
		if (GeneratorUnlockExperience.Equals(5.0) || GeneratorUnlockExperience.Equals(2.0))
		{
			GeneratorUnlockExperience = 1.0;
			num++;
		}
		if (WarheadExperience.Equals(15.0) || WarheadExperience.Equals(1.0))
		{
			WarheadExperience = 3.0;
			num++;
		}
		if (InitialWaveSurvivalExperience.Equals(6.0) || InitialWaveSurvivalExperience.Equals(2.0))
		{
			InitialWaveSurvivalExperience = 3.0;
			num++;
		}
		if (EscapeExperience.Equals(25.0) || EscapeExperience.Equals(10.0))
		{
			EscapeExperience = 20.0;
			num++;
		}
		if (ScpItemUseExperience.Equals(4.0))
		{
			ScpItemUseExperience = 1.0;
			num++;
		}
		if (PocketEscapeExperience.Equals(8.0))
		{
			PocketEscapeExperience = 1.0;
			num++;
		}
		if (RoundSurvivalExperience.Equals(6.0))
		{
			RoundSurvivalExperience = 5.0;
			num++;
		}
		if (RoundVictoryExperience.Equals(8.0))
		{
			RoundVictoryExperience = 10.0;
			num++;
		}
		if (MvpExperience.Equals(15.0))
		{
			MvpExperience = 20.0;
			num++;
		}
		num += _m4e6f726d616c697a65457870657269656e63653a300(KillExperience, 1.0, delegate(double value)
		{
			KillExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(ArmedKillExperience, 1.5, delegate(double value)
		{
			ArmedKillExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(FacilityGuardKillExperience, 0.0, delegate(double value)
		{
			FacilityGuardKillExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(ZombieKillExperience, 5.0, delegate(double value)
		{
			ZombieKillExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(ScpHumanKillExperience, 1.0, delegate(double value)
		{
			ScpHumanKillExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(KillAssistExperience, 0.5, delegate(double value)
		{
			KillAssistExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(ArmedKillAssistExperience, 0.75, delegate(double value)
		{
			ArmedKillAssistExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(AnomalyKillAssistExperience, 5.0, delegate(double value)
		{
			AnomalyKillAssistExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(ZombieKillAssistExperience, 1.5, delegate(double value)
		{
			ZombieKillAssistExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(ScpKillExperience, 10.0, delegate(double value)
		{
			ScpKillExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(ScpFinalBlowExperience, 5.0, delegate(double value)
		{
			ScpFinalBlowExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(ScpFullDamageExperience, 20.0, delegate(double value)
		{
			ScpFullDamageExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(GeneratorUnlockExperience, 2.0, delegate(double value)
		{
			GeneratorUnlockExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(WarheadExperience, 1.0, delegate(double value)
		{
			WarheadExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(InitialWaveSurvivalExperience, 2.0, delegate(double value)
		{
			InitialWaveSurvivalExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(EscapeExperience, 10.0, delegate(double value)
		{
			EscapeExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(GuardEscapeExperience, 10.0, delegate(double value)
		{
			GuardEscapeExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(CuffedArmedEscapeExperience, 5.0, delegate(double value)
		{
			CuffedArmedEscapeExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(EscortCuffedEscapeExperience, 3.0, delegate(double value)
		{
			EscortCuffedEscapeExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(ScpItemUseExperience, 1.0, delegate(double value)
		{
			ScpItemUseExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(MicroHidExperience, 1.0, delegate(double value)
		{
			MicroHidExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(PocketEscapeExperience, 1.0, delegate(double value)
		{
			PocketEscapeExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(RoundSurvivalExperience, 5.0, delegate(double value)
		{
			RoundSurvivalExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(RoundVictoryExperience, 10.0, delegate(double value)
		{
			RoundVictoryExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(MvpExperience, 15.0, delegate(double value)
		{
			MvpExperience = value;
		});
		num += _m4e6f726d616c697a65457870657269656e63653a300(SvpExperience, 10.0, delegate(double value)
		{
			SvpExperience = value;
		});
		float num2 = ((float.IsNaN(RequestTimeoutSeconds) || float.IsInfinity(RequestTimeoutSeconds)) ? 10f : Math.Max(1f, Math.Min(60f, RequestTimeoutSeconds)));
		if (!RequestTimeoutSeconds.Equals(num2))
		{
			num++;
		}
		RequestTimeoutSeconds = num2;
		float num3 = ((float.IsNaN(PlayerInfoCacheSeconds) || float.IsInfinity(PlayerInfoCacheSeconds)) ? 60f : Math.Max(5f, Math.Min(3600f, PlayerInfoCacheSeconds)));
		if (!PlayerInfoCacheSeconds.Equals(num3))
		{
			num++;
		}
		PlayerInfoCacheSeconds = num3;
		return num;
	}

	private static int _m4e6f726d616c697a65457870657269656e63653a300(double configured, double fallback, Action<double> assign)
	{
		double obj = ((double.IsNaN(configured) || double.IsInfinity(configured)) ? fallback : Math.Max(0.0, Math.Min(50.0, configured)));
		assign(obj);
		return (!configured.Equals(obj)) ? 1 : 0;
	}

	public ExperienceSystemConfig()
	{
		_fuzoZROsRmWvI = true;
		_feMWZsEtUbxfD = "http://msjpage.yinnai.top/api/hj/addexp";
		_f3c546f6b656e3e6b5f5f4261636b696e674669656c643a300 = "hj2026-8-7";
		_f3c506c61796572496e666f41706955726c3e6b5f5f4261636b696e674669656c643a300 = "https://msjpage.yinnai.top/api/hj/getplayerinfo";
		_f5b5e740f5382e38a = 60f;
		_f451f29fa6f805223 = 1.0;
		_f0705adb86875ef5d = 1.5;
		_f10da9f326a2a409b = 5.0;
		_f6609392a122f373b34113336361f222a3f28333f34393f64310505183b393133343d1c333f363e606a = 1.0;
		_f66113336361b292933292e1f222a3f28333f34393f64310505183b393133343d1c333f363e606a = 0.5;
		_f423cd5254c0ae632 = 0.75;
		_f928a17f06b0fbceb = 5.0;
		_ffmkEkZYjnShH = 1.5;
		_f3c5363704b696c6c457870657269656e63653e6b5f5f4261636b696e674669656c643a300 = 10.0;
		_f3c53637046696e616c426c6f77457870657269656e63653e6b5f5f4261636b696e674669656c643a300 = 5.0;
		_f3c53637046756c6c44616d616765457870657269656e63653e6b5f5f4261636b696e674669656c643a300 = 20.0;
		_f3c47656e657261746f72556e6c6f636b457870657269656e63653e6b5f5f4261636b696e674669656c643a300 = 1.0;
		_f1b379e61172df8da = 3.0;
		_fd96ec4a367003109 = 3.0;
		_f1f1269b8597be90e = 20.0;
		_fgMqHdcrvkwfF = 10.0;
		_f8471195e803b8d58 = 5.0;
		_f661f293935282e192f3c3c3f3e1f29393b2a3f1f222a3f28333f34393f64310505183b393133343d1c333f363e606a = 3.0;
		_f6609392a132e3f370f293f1f222a3f28333f34393f64310505183b393133343d1c333f363e606a = 1.0;
		_fXszpWjIPwqLs = 1.0;
		_f660a3539313f2e1f29393b2a3f1f222a3f28333f34393f64310505183b393133343d1c333f363e606a = 1.0;
		_f77f650bf9d053359 = 5.0;
		_f6608352f343e0c33392e3528231f222a3f28333f34393f64310505183b393133343d1c333f363e606a = 10.0;
		_f06df2c0908e7f1f1 = 20.0;
		_f66092c2a1f222a3f28333f34393f64310505183b393133343d1c333f363e606a = 10.0;
		_fOOdQWpizYLjA = 10f;
		base._002Ector();
	}

	[CompilerGenerated]
	private void _mzcnLgUCRvNHq(double value)
	{
		KillExperience = value;
	}

	[CompilerGenerated]
	private void _me7baeab0a9967072(double value)
	{
		ArmedKillExperience = value;
	}

	[CompilerGenerated]
	private void _mxmaSoRBqPqKD(double value)
	{
		FacilityGuardKillExperience = value;
	}

	[CompilerGenerated]
	private void _mHWEwJaKidzQE(double value)
	{
		ZombieKillExperience = value;
	}

	[CompilerGenerated]
	private void _m66143528373b3633203f643805056b6862056e606a(double value)
	{
		ScpHumanKillExperience = value;
	}

	[CompilerGenerated]
	private void _mMvyDCeNKVdaW(double value)
	{
		KillAssistExperience = value;
	}

	[CompilerGenerated]
	private void _m66143528373b3633203f643805056b6862056c606a(double value)
	{
		ArmedKillAssistExperience = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f3132385f373a300(double value)
	{
		AnomalyKillAssistExperience = value;
	}

	[CompilerGenerated]
	private void _m66143528373b3633203f643805056b68620562606a(double value)
	{
		ZombieKillAssistExperience = value;
	}

	[CompilerGenerated]
	private void _m66143528373b3633203f643805056b68620563606a(double value)
	{
		ScpKillExperience = value;
	}

	[CompilerGenerated]
	private void _mVkDUTrrXGzRm(double value)
	{
		ScpFinalBlowExperience = value;
	}

	[CompilerGenerated]
	private void _mZmMjBbVQyQgj(double value)
	{
		ScpFullDamageExperience = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f3132385f31323a300(double value)
	{
		GeneratorUnlockExperience = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f3132385f31333a300(double value)
	{
		WarheadExperience = value;
	}

	[CompilerGenerated]
	private void _m9d40b6483384ae40(double value)
	{
		InitialWaveSurvivalExperience = value;
	}

	[CompilerGenerated]
	private void _m97ad580624de085c(double value)
	{
		EscapeExperience = value;
	}

	[CompilerGenerated]
	private void _mcbf8746ac9f9f7d1(double value)
	{
		GuardEscapeExperience = value;
	}

	[CompilerGenerated]
	private void _mIaLFAZPeTHMi(double value)
	{
		CuffedArmedEscapeExperience = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f3132385f31383a300(double value)
	{
		EscortCuffedEscapeExperience = value;
	}

	[CompilerGenerated]
	private void _mHCaCXpbMOaoW(double value)
	{
		ScpItemUseExperience = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f3132385f32303a300(double value)
	{
		MicroHidExperience = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f3132385f32313a300(double value)
	{
		PocketEscapeExperience = value;
	}

	[CompilerGenerated]
	private void _mrbebaLlmoLbr(double value)
	{
		RoundSurvivalExperience = value;
	}

	[CompilerGenerated]
	private void _ma3a36dab4dfb7c76(double value)
	{
		RoundVictoryExperience = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f3132385f32343a300(double value)
	{
		MvpExperience = value;
	}

	[CompilerGenerated]
	private void _mfzTiBHLYjQtU(double value)
	{
		SvpExperience = value;
	}
}
