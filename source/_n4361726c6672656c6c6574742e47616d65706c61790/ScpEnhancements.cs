using System;
using System.Collections.Generic;
using System.Linq;
using Exiled.API.Features;
using Exiled.API.Features.DamageHandlers;
using Exiled.API.Features.Roles;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Scp096;
using Exiled.Events.EventArgs.Server;
using Exiled.Events.Handlers;
using MEC;
using PlayerRoles;
using PlayerStatsSystem;
using _n4361726c6672656c6c6574740;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class ScpEnhancements
{
	private const float _f15343f12332e113336361e3b373b3d3f606a = 100000f;

	private readonly ScpEnhancementsConfig _f6c31d377d97c7aaa;

	private readonly MicroHidEnhancementConfig _f49f334f24a7c542e;

	private readonly Dictionary<int, Player> _f706f636b6574436170746f72733a300 = new Dictionary<int, Player>();

	public ScpEnhancements(ScpEnhancementsConfig config, MicroHidEnhancementConfig microHidConfig)
	{
		_f6c31d377d97c7aaa = config ?? new ScpEnhancementsConfig();
		_f49f334f24a7c542e = microHidConfig ?? new MicroHidEnhancementConfig();
	}

	public void Enable()
	{
		Scp096.AddingTarget += _m4f6e536370303936416464696e675461726765743a300;
		Player.EnteringPocketDimension += _mPdiQbjgHfycU;
		Player.EscapingPocketDimension += _m15341f29393b2a33343d0a3539313f2e1e33373f3429333534606a;
		Player.Died += _m259dced7c59bda58;
		Player.Hurting += _mqNPuDsXgkEKx;
		Player.UsingMicroHIDEnergy += _mEHAsbpZubOWB;
		Player.Spawned += _m1534092a3b2d343f3e606a;
		Player.Escaping += _m15341f29393b2a33343d606a;
		Player.Left += _m5895ad191abbde9b;
		Server.RoundEnded += _mwWBeQUOMQlZT;
		Server.RestartingRound += _mLIrGBPquILUS;
		Server.WaitingForPlayers += _m4f6e57616974696e67466f72506c61796572733a300;
	}

	public void Disable()
	{
		Scp096.AddingTarget -= _m4f6e536370303936416464696e675461726765743a300;
		Player.EnteringPocketDimension -= _mPdiQbjgHfycU;
		Player.EscapingPocketDimension -= _m15341f29393b2a33343d0a3539313f2e1e33373f3429333534606a;
		Player.Died -= _m259dced7c59bda58;
		Player.Hurting -= _mqNPuDsXgkEKx;
		Player.UsingMicroHIDEnergy -= _mEHAsbpZubOWB;
		Player.Spawned -= _m1534092a3b2d343f3e606a;
		Player.Escaping -= _m15341f29393b2a33343d606a;
		Player.Left -= _m5895ad191abbde9b;
		Server.RoundEnded -= _mwWBeQUOMQlZT;
		Server.RestartingRound -= _mLIrGBPquILUS;
		Server.WaitingForPlayers -= _m4f6e57616974696e67466f72506c61796572733a300;
		_f706f636b6574436170746f72733a300.Clear();
	}

	private void _m4f6e536370303936416464696e675461726765743a300(AddingTargetEventArgs ev)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Invalid comparison between Unknown and I4
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		if (!_f6c31d377d97c7aaa.Scp096.IsEnabled || !ev.IsAllowed || ev.Player == null || ev.Target == null)
		{
			return;
		}
		Player scp096 = ev.Player;
		Player target = ev.Target;
		Role role = scp096.Role;
		Scp096Role val = (Scp096Role)(object)((role is Scp096Role) ? role : null);
		bool wasEnraged = (Role)(object)val != (Role)null && (int)val.RageState == 2;
		Timing.CallDelayed(0f, (Action)delegate
		{
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Invalid comparison between Unknown and I4
			//IL_0054: Unknown result type (might be due to invalid IL or missing references)
			//IL_005a: Invalid comparison between Unknown and I4
			if (scp096 != null && (int)scp096.Role.Type == 9)
			{
				Role role2 = scp096.Role;
				Scp096Role val2 = (Scp096Role)(object)((role2 is Scp096Role) ? role2 : null);
				if (!((Role)(object)val2 == (Role)null) && val2.Targets.Contains(target) && wasEnraged && (int)val2.RageState == 2)
				{
					float rageSecondsPerTarget = _f6c31d377d97c7aaa.Scp096.RageSecondsPerTarget;
					val2.EnragedTimeLeft += rageSecondsPerTarget;
					val2.TotalEnrageTime += rageSecondsPerTarget;
				}
			}
		});
	}

	private void _mPdiQbjgHfycU(EnteringPocketDimensionEventArgs ev)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Invalid comparison between Unknown and I4
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		if (!ev.IsAllowed || ev.Player == null || ev.Scp106 == null || (int)ev.Scp106.Role.Type != 3 || !_f6c31d377d97c7aaa.Scp106.IsEnabled)
		{
			return;
		}
		Player victim = ev.Player;
		Player captor = ev.Scp106;
		Timing.CallDelayed(0f, (Action)delegate
		{
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002e: Invalid comparison between Unknown and I4
			if (victim != null && captor != null && victim.IsInPocketDimension && (int)captor.Role.Type == 3)
			{
				_f706f636b6574436170746f72733a300[victim.Id] = captor;
			}
		});
	}

	private void _m15341f29393b2a33343d0a3539313f2e1e33373f3429333534606a(EscapingPocketDimensionEventArgs ev)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		if (!ev.IsAllowed || ev.Player == null)
		{
			return;
		}
		Player victim = ev.Player;
		Timing.CallDelayed(0f, (Action)delegate
		{
			if (victim != null && !victim.IsInPocketDimension)
			{
				_f706f636b6574436170746f72733a300.Remove(victim.Id);
			}
		});
	}

	private void _m259dced7c59bda58(DiedEventArgs ev)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Invalid comparison between Unknown and I4
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008e: Invalid comparison between Unknown and I4
		if (ev.Player != null)
		{
			Player value = null;
			bool num = _f6c31d377d97c7aaa.Scp106.IsEnabled && ((ev.DamageHandler != null && (int)((DamageHandlerBase)ev.DamageHandler).Type == 17) || ev.Player.IsInPocketDimension) && _f706f636b6574436170746f72733a300.TryGetValue(ev.Player.Id, out value);
			_f706f636b6574436170746f72733a300.Remove(ev.Player.Id);
			if (!num)
			{
				_m123f3b3609392a113336363f28606a(ev);
			}
			if (num && value != null && (int)value.Role.Type == 3 && !(value.Health >= value.MaxHealth))
			{
				value.Heal(_f6c31d377d97c7aaa.Scp106.PocketDeathHeal, false);
			}
		}
	}

	private void _m123f3b3609392a113336363f28606a(DiedEventArgs ev)
	{
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		ScpKillHealingConfig killHealing = _f6c31d377d97c7aaa.KillHealing;
		Player attacker = ev.Attacker;
		if (killHealing != null && killHealing.IsEnabled && !(killHealing.HealAmount <= 0f) && attacker != null && attacker != ev.Player && attacker.IsScp && (int)PlayerRolesUtils.GetTeam(ev.TargetOldRole) != 0 && !(attacker.Health <= 0f) && !(attacker.Health >= attacker.MaxHealth))
		{
			attacker.Heal(killHealing.HealAmount, false);
		}
	}

	private void _mqNPuDsXgkEKx(HurtingEventArgs ev)
	{
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Invalid comparison between Unknown and I4
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Invalid comparison between Unknown and I4
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Invalid comparison between Unknown and I4
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		if (!ev.IsAllowed || ev.Player == null || ev.DamageHandler == null)
		{
			return;
		}
		if (_mf9364905f10d62ec(ev) && _f6c31d377d97c7aaa.Scp049.IsEnabled && _f6c31d377d97c7aaa.Scp049.OneHitKill)
		{
			ev.Amount = 100000f;
			return;
		}
		if ((int)((DamageHandlerBase)ev.DamageHandler).Type == 22 && _f6c31d377d97c7aaa.Scp096.IsEnabled && _f6c31d377d97c7aaa.Scp096.OneHitKill)
		{
			ev.Amount = -1f;
			return;
		}
		if ((int)((DamageHandlerBase)ev.DamageHandler).Type == 8 && _f49f334f24a7c542e.IsEnabled && ev.Amount > 0f)
		{
			ev.Amount *= _f49f334f24a7c542e.DamageMultiplier;
		}
		if ((int)((DamageHandlerBase)ev.DamageHandler).Type == 37 && Plugin.Instance != null && ((Plugin<Config>)Plugin.Instance).Config.ParticleDisruptorDamageMultiplier > 0f && ev.Amount > 0f)
		{
			ev.Amount *= ((Plugin<Config>)Plugin.Instance).Config.ParticleDisruptorDamageMultiplier;
		}
		if (ev.Attacker != null)
		{
			float num = _m2ab9fd45fbeaa6f0(ev.Attacker.Role.Type);
			if (!num.Equals(1f))
			{
				ev.Amount *= num;
			}
		}
	}

	private static bool _mf9364905f10d62ec(HurtingEventArgs ev)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Invalid comparison between Unknown and I4
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Invalid comparison between Unknown and I4
		if (ev.Attacker == null || (int)ev.Attacker.Role.Type != 5 || ev.Player == null || ev.Player == ev.Attacker || !PlayerRolesUtils.IsHuman(ev.Player.Role.Type))
		{
			return false;
		}
		DamageHandlerBase customBase = ev.DamageHandler.CustomBase;
		DamageHandlerBase obj = ((customBase != null) ? customBase.Base : null);
		Scp049DamageHandler val = (Scp049DamageHandler)(object)((obj is Scp049DamageHandler) ? obj : null);
		if (val != null)
		{
			return (int)val.DamageSubType == 0;
		}
		return false;
	}

	private void _mEHAsbpZubOWB(UsingMicroHIDEnergyEventArgs ev)
	{
		if (_f49f334f24a7c542e.IsEnabled && ev.IsAllowed && !(ev.Drain <= 0f))
		{
			ev.Drain /= _f49f334f24a7c542e.EnergyCapacityMultiplier;
		}
	}

	private float _m2ab9fd45fbeaa6f0(RoleTypeId role)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Invalid comparison between Unknown and I4
		if ((int)role == 16 && _f6c31d377d97c7aaa.Scp939.IsEnabled)
		{
			return _f6c31d377d97c7aaa.Scp939.DamageMultiplier;
		}
		return 1f;
	}

	private void _m1534092a3b2d343f3e606a(SpawnedEventArgs ev)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Invalid comparison between Unknown and I4
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Invalid comparison between Unknown and I4
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Invalid comparison between Unknown and I4
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Invalid comparison between Unknown and I4
		if (ev.Player == null)
		{
			return;
		}
		RoleTypeId type = ev.Player.Role.Type;
		if ((int)type <= 3)
		{
			if ((int)type != 0 && (int)type == 3)
			{
				_m4170706c795363703130365669676f723a300(ev.Player);
			}
		}
		else if ((int)type != 5 && (int)type != 9 && (int)type == 16)
		{
			_mYzzYuxHAesAe(ev.Player);
		}
	}

	private void _m4170706c795363703130365669676f723a300(Player player)
	{
		if (_f6c31d377d97c7aaa.Scp106.IsEnabled)
		{
			Role role = player.Role;
			Scp106Role val = (Scp106Role)(object)((role is Scp106Role) ? role : null);
			if (!((Role)(object)val == (Role)null))
			{
				val.Vigor = _f6c31d377d97c7aaa.Scp106.InitialVigor;
			}
		}
	}

	private void _mYzzYuxHAesAe(Player player)
	{
		if (_f6c31d377d97c7aaa.Scp939.IsEnabled && !((Role)/*isinst with value type is only supported in some contexts*/ == (Role)null))
		{
			player.ResetStamina();
		}
	}

	private static void _m15341f29393b2a33343d606a(EscapingEventArgs ev)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Invalid comparison between Unknown and I4
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Expected I4, but got Unknown
		if (ev == null || !ev.IsAllowed || ev.Player == null || !ev.Player.IsCuffed)
		{
			return;
		}
		RoleTypeId type = ev.Player.Role.Type;
		if ((int)type != 4)
		{
			switch (type - 8)
			{
			default:
				return;
			case 3:
			case 4:
			case 5:
				break;
			case 0:
			case 10:
			case 11:
			case 12:
				ev.NewRole = (RoleTypeId)13;
				return;
			case 1:
			case 2:
			case 6:
			case 7:
			case 8:
			case 9:
				return;
			}
		}
		ev.NewRole = (RoleTypeId)8;
	}

	private void _m5895ad191abbde9b(LeftEventArgs ev)
	{
		if (ev.Player == null)
		{
			return;
		}
		_f706f636b6574436170746f72733a300.Remove(ev.Player.Id);
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, Player> item in _f706f636b6574436170746f72733a300)
		{
			if (item.Value == ev.Player)
			{
				list.Add(item.Key);
			}
		}
		foreach (int item2 in list)
		{
			_f706f636b6574436170746f72733a300.Remove(item2);
		}
	}

	private void _mwWBeQUOMQlZT(RoundEndedEventArgs ev)
	{
		_f706f636b6574436170746f72733a300.Clear();
	}

	private void _mLIrGBPquILUS()
	{
		_f706f636b6574436170746f72733a300.Clear();
	}

	private void _m4f6e57616974696e67466f72506c61796572733a300()
	{
		_f706f636b6574436170746f72733a300.Clear();
	}
}
