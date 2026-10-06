using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _n4361726c6672656c6c6574740;

public sealed class ScpEnhancementsConfig
{
	[Description("SCP 击杀回血配置。")]
	public ScpKillHealingConfig KillHealing { get; set; }

	[Description("SCP-096 强化配置。")]
	public Scp096EnhancementConfig Scp096 { get; set; }

	[Description("SCP-049 强化配置。")]
	public Scp049EnhancementConfig Scp049 { get; set; }

	[Description("SCP-106 强化配置。")]
	public Scp106EnhancementConfig Scp106 { get; set; }

	[Description("SCP-173 强化配置。")]
	public Scp173EnhancementConfig Scp173 { get; set; }

	[Description("SCP-939 强化配置。")]
	public Scp939EnhancementConfig Scp939 { get; set; }

	internal int _m143528373b3633203f606a()
	{
		int num = 0;
		if (KillHealing == null)
		{
			KillHealing = new ScpKillHealingConfig();
			num++;
		}
		if (Scp096 == null)
		{
			Scp096 = new Scp096EnhancementConfig();
			num++;
		}
		if (Scp049 == null)
		{
			Scp049 = new Scp049EnhancementConfig();
			num++;
		}
		if (Scp106 == null)
		{
			Scp106 = new Scp106EnhancementConfig();
			num++;
		}
		if (Scp173 == null)
		{
			Scp173 = new Scp173EnhancementConfig();
			num++;
		}
		if (Scp939 == null)
		{
			Scp939 = new Scp939EnhancementConfig();
			num++;
		}
		num += _m66673ac9026a904d(KillHealing.HealAmount, 200f, 150f, 100000f, delegate(float value)
		{
			KillHealing.HealAmount = value;
		});
		if (Scp096.RageSecondsPerTarget.Equals(10f) || Scp096.RageSecondsPerTarget.Equals(20f))
		{
			Scp096.RageSecondsPerTarget = 15f;
			num++;
		}
		if (!Scp096.HumeShieldPerTarget.Equals(0f))
		{
			Scp096.HumeShieldPerTarget = 0f;
			num++;
		}
		if (!Scp049.NormalSpeedMultiplier.Equals(1f))
		{
			Scp049.NormalSpeedMultiplier = 1f;
			num++;
		}
		if (!Scp049.LockedTargetSpeedMultiplier.Equals(1f))
		{
			Scp049.LockedTargetSpeedMultiplier = 1f;
			num++;
		}
		if (!Scp173.NormalSpeedMultiplier.Equals(1f))
		{
			Scp173.NormalSpeedMultiplier = 1f;
			num++;
		}
		if (!Scp173.BreakneckSpeedMultiplier.Equals(1f))
		{
			Scp173.BreakneckSpeedMultiplier = 1f;
			num++;
		}
		num += _m66673ac9026a904d(Scp096.RageSecondsPerTarget, 15f, 0f, 3600f, delegate(float value)
		{
			Scp096.RageSecondsPerTarget = value;
		});
		num += _m66673ac9026a904d(Scp049.NormalSpeedMultiplier, 1f, 1f, 1f, delegate(float value)
		{
			Scp049.NormalSpeedMultiplier = value;
		});
		num += _m66673ac9026a904d(Scp049.LockedTargetSpeedMultiplier, 1f, 1f, 1f, delegate(float value)
		{
			Scp049.LockedTargetSpeedMultiplier = value;
		});
		if (!Scp049.ReviveSpeedMultiplier.Equals(1f))
		{
			Scp049.ReviveSpeedMultiplier = 1f;
			num++;
		}
		num += _m66673ac9026a904d(Scp049.ReviveSpeedMultiplier, 1f, 1f, 1f, delegate(float value)
		{
			Scp049.ReviveSpeedMultiplier = value;
		});
		num += _m66673ac9026a904d(Scp106.PocketDeathHeal, 200f, 0f, 100000f, delegate(float value)
		{
			Scp106.PocketDeathHeal = value;
		});
		num += _m66673ac9026a904d(Scp106.InitialVigor, 1f, 0f, 1f, delegate(float value)
		{
			Scp106.InitialVigor = value;
		});
		num += _m66673ac9026a904d(Scp106.VigorCapacityMultiplier, 10f, 0.1f, 100f, delegate(float value)
		{
			Scp106.VigorCapacityMultiplier = value;
		});
		num += _m66673ac9026a904d(Scp173.NormalSpeedMultiplier, 1f, 1f, 1f, delegate(float value)
		{
			Scp173.NormalSpeedMultiplier = value;
		});
		num += _m66673ac9026a904d(Scp173.BreakneckSpeedMultiplier, 1f, 1f, 1f, delegate(float value)
		{
			Scp173.BreakneckSpeedMultiplier = value;
		});
		if (Scp939.StaminaCapacityMultiplier.Equals(4f))
		{
			Scp939.StaminaCapacityMultiplier = 10f;
			num++;
		}
		num += _m66673ac9026a904d(Scp939.StaminaCapacityMultiplier, 10f, 0.1f, 100f, delegate(float value)
		{
			Scp939.StaminaCapacityMultiplier = value;
		});
		return num + _m66673ac9026a904d(Scp939.DamageMultiplier, 2f, 0f, 100f, delegate(float value)
		{
			Scp939.DamageMultiplier = value;
		});
	}

	private static int _m66673ac9026a904d(float configured, float fallback, float minimum, float maximum, Action<float> assign)
	{
		float obj = ((float.IsNaN(configured) || float.IsInfinity(configured)) ? fallback : Math.Max(minimum, Math.Min(maximum, configured)));
		assign(obj);
		return (!configured.Equals(obj)) ? 1 : 0;
	}

	public ScpEnhancementsConfig()
	{
		_f3c4b696c6c4865616c696e673e6b5f5f4261636b696e674669656c643a300 = new ScpKillHealingConfig();
		_f870a9cffd81c19e1 = new Scp096EnhancementConfig();
		_fe7405fa2c4d92cdd = new Scp049EnhancementConfig();
		_ff7d8a4f0b7efdf6b = new Scp106EnhancementConfig();
		_f3c5363703137333e6b5f5f4261636b696e674669656c643a300 = new Scp173EnhancementConfig();
		_fd37360004e2a31e2 = new Scp939EnhancementConfig();
		base._002Ector();
	}

	[CompilerGenerated]
	private void _m66143528373b3633203f64380505686e056a606a(float value)
	{
		KillHealing.HealAmount = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f32345f313a300(float value)
	{
		Scp096.RageSecondsPerTarget = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f32345f323a300(float value)
	{
		Scp049.NormalSpeedMultiplier = value;
	}

	[CompilerGenerated]
	private void _mORfmmUXwUDwH(float value)
	{
		Scp049.LockedTargetSpeedMultiplier = value;
	}

	[CompilerGenerated]
	private void _maopyjqnUrTcO(float value)
	{
		Scp049.ReviveSpeedMultiplier = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f32345f353a300(float value)
	{
		Scp106.PocketDeathHeal = value;
	}

	[CompilerGenerated]
	private void _mjIwusgnUFdtd(float value)
	{
		Scp106.InitialVigor = value;
	}

	[CompilerGenerated]
	private void _m634791d8b3ddaf56(float value)
	{
		Scp106.VigorCapacityMultiplier = value;
	}

	[CompilerGenerated]
	private void _mgrRSDQFfjWeR(float value)
	{
		Scp173.NormalSpeedMultiplier = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f32345f393a300(float value)
	{
		Scp173.BreakneckSpeedMultiplier = value;
	}

	[CompilerGenerated]
	private void _maRXKPhXMAxuR(float value)
	{
		Scp939.StaminaCapacityMultiplier = value;
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f32345f31313a300(float value)
	{
		Scp939.DamageMultiplier = value;
	}
}
