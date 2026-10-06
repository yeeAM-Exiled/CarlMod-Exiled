using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using Exiled.Events.EventArgs.Map;
using Exiled.Events.EventArgs.Server;
using Exiled.Events.Handlers;
using MEC;
using Mirror;
using UnityEngine;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class AutomaticCleanupSystem
{
	private sealed class _tFSvmwPozWjQP
	{
		public int Pickups { get; set; }

		public int Ragdolls { get; set; }
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _trSoPmoWepldn
	{
		public static readonly _trSoPmoWepldn _003C_003E9 = new _trSoPmoWepldn();

		public static Func<ZoneType, bool> _003C_003E9__12_1;

		public static Func<Pickup, bool> _003C_003E9__12_2;

		public static Func<ZoneType, bool> _003C_003E9__14_0;

		public static Func<Pickup, bool> _003C_003E9__14_1;

		public static Func<ZoneType, bool> _003C_003E9__15_0;

		public static Func<Pickup, bool> _003C_003E9__15_1;

		public static Func<Player, bool> _003C_003E9__16_0;

		public static Func<ZoneType, bool> _003C_003E9__16_1;

		public static Func<Pickup, bool> _003C_003E9__16_2;

		public static Func<Pickup, bool> _003C_003E9__18_0;

		public static Func<Ragdoll, bool> _003C_003E9__18_1;

		internal bool _m3c4f6e576172686561644465746f6e617465643e625f5f31325f313a300(ZoneType zone)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			return !((Enum)zone).HasFlag((Enum)(object)(ZoneType)8);
		}

		internal bool _m6615340d3b28323f3b3e1e3f2e35343b2e3f3e643805056b680568606a(Pickup pickup)
		{
			return true;
		}

		internal bool _mc438c130388e9a3e(ZoneType zone)
		{
			return true;
		}

		internal bool _m661534083f292a3b2d3433343d0e3f3b37643805056b6e056b606a(Pickup pickup)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Invalid comparison between Unknown and I4
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0012: Invalid comparison between Unknown and I4
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Invalid comparison between Unknown and I4
			if ((int)pickup.Type != 12 && (int)pickup.Type != 13)
			{
				return (int)pickup.Type == 30;
			}
			return true;
		}

		internal bool _m3c506572696f646963436c65616e75704c6f6f703e625f5f31355f303a300(ZoneType zone)
		{
			return true;
		}

		internal bool _m660a3f2833353e333919363f3b342f2a1635352a643805056b6f056b606a(Pickup pickup)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return !_mKQCaFlEoNVYd(pickup.Type);
		}

		internal bool _m3c436c65616e75704c69676874436f6e7461696e6d656e745768656e456d7074793e625f5f31365f303a300(Player player)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			if (player != null && player.IsAlive)
			{
				return ((Enum)player.Zone).HasFlag((Enum)(object)(ZoneType)1);
			}
			return false;
		}

		internal bool _m6619363f3b342f2a16333d322e1935342e3b3334373f342e0d323f341f372a2e23643805056b6c056b606a(ZoneType zone)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			return ((Enum)zone).HasFlag((Enum)(object)(ZoneType)1);
		}

		internal bool _m6619363f3b342f2a16333d322e1935342e3b3334373f342e0d323f341f372a2e23643805056b6c0568606a(Pickup pickup)
		{
			return true;
		}

		internal bool _m3c436c65616e75705a6f6e653e625f5f31385f303a300(Pickup item)
		{
			return item != null;
		}

		internal bool _m6619363f3b342f2a0035343f643805056b62056b606a(Ragdoll item)
		{
			return item != null;
		}
	}

	private const float _f0a3f2833353e333919363f3b342f2a093f3935343e29606a = 720f;

	private const float _fzZMtoHdLjGck = 0.5f;

	private const string _fhdMGbYLQbCfV = "Carlfrellett.AutomaticCleanup.Periodic";

	private const string _fGhyeuyndadsS = "Carlfrellett.AutomaticCleanup.Decontamination";

	private static readonly HashSet<ItemType> _f8ed0509b4a9d133e = new HashSet<ItemType>
	{
		(ItemType)16,
		(ItemType)52,
		(ItemType)40,
		(ItemType)41,
		(ItemType)20,
		(ItemType)24,
		(ItemType)25,
		(ItemType)26,
		(ItemType)38,
		(ItemType)14
	};

	private CoroutineHandle _f706572696f646963436f726f7574696e653a300;

	private CoroutineHandle _f3e3f3935342e3b3733343b2e333534193528352f2e33343f606a;

	private bool _fZQIPQuHiMARw;

	public void Enable()
	{
		if (!_fZQIPQuHiMARw)
		{
			_fZQIPQuHiMARw = true;
			Warhead.Detonated += _m4f6e576172686561644465746f6e617465643a300;
			Map.Decontaminating += _mkKSYUQmknsdv;
			Server.RespawningTeam += _muFdnNcyohkmK;
			Server.RoundStarted += _muqOsoJcDxIjB;
			Server.WaitingForPlayers += _m4f6e526f756e6452657365743a300;
			Server.RestartingRound += _m4f6e526f756e6452657365743a300;
		}
	}

	public void Disable()
	{
		if (_fZQIPQuHiMARw)
		{
			_fZQIPQuHiMARw = false;
			Warhead.Detonated -= _m4f6e576172686561644465746f6e617465643a300;
			Map.Decontaminating -= _mkKSYUQmknsdv;
			Server.RespawningTeam -= _muFdnNcyohkmK;
			Server.RoundStarted -= _muqOsoJcDxIjB;
			Server.WaitingForPlayers -= _m4f6e526f756e6452657365743a300;
			Server.RestartingRound -= _m4f6e526f756e6452657365743a300;
			_mljenczGQdfLc();
		}
	}

	private void _muqOsoJcDxIjB()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		_mljenczGQdfLc();
		_f706572696f646963436f726f7574696e653a300 = Timing.RunCoroutine(_m0a3f2833353e333919363f3b342f2a1635352a606a(), (Segment)4, Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0LkF1dG9tYXRpY0NsZWFudXAuUGVyaW9kaWM=")));
	}

	private void _m4f6e526f756e6452657365743a300()
	{
		_mljenczGQdfLc();
	}

	private void _m4f6e576172686561644465746f6e617465643a300()
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		Timing.CallDelayed(0.2f, (Action)delegate
		{
			if (_fZQIPQuHiMARw)
			{
				_tFSvmwPozWjQP result = _mc1c2c0f9728dd441((ZoneType zone) => !((Enum)zone).HasFlag((Enum)(object)(ZoneType)8), (Pickup pickup) => true, cleanupRagdolls: true);
				_mCCDBtxKuTYhr(Encoding.UTF8.GetString(Convert.FromBase64String("d2FyaGVhZA==")), result);
			}
		});
	}

	private void _mkKSYUQmknsdv(DecontaminatingEventArgs ev)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		if (ev != null && ev.IsAllowed)
		{
			Timing.KillCoroutines((CoroutineHandle[])(object)new CoroutineHandle[1] { _f3e3f3935342e3b3733343b2e333534193528352f2e33343f606a });
			Timing.KillCoroutines(Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0LkF1dG9tYXRpY0NsZWFudXAuRGVjb250YW1pbmF0aW9u")));
			_f3e3f3935342e3b3733343b2e333534193528352f2e33343f606a = Timing.RunCoroutine(_meb3ff2a662e8f06c(), (Segment)4, Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0LkF1dG9tYXRpY0NsZWFudXAuRGVjb250YW1pbmF0aW9u")));
		}
	}

	private void _muFdnNcyohkmK(RespawningTeamEventArgs ev)
	{
		if (ev != null && ev.IsAllowed)
		{
			_tFSvmwPozWjQP result = _mc1c2c0f9728dd441((ZoneType zone) => true, (Pickup pickup) => (int)pickup.Type == 12 || (int)pickup.Type == 13 || (int)pickup.Type == 30, cleanupRagdolls: false);
			_mCCDBtxKuTYhr(Encoding.UTF8.GetString(Convert.FromBase64String("dGVhbSByZXNwYXdu")), result);
		}
	}

	private IEnumerator<float> _m0a3f2833353e333919363f3b342f2a1635352a606a()
	{
		while (_fZQIPQuHiMARw && Round.IsStarted && !Round.IsEnded)
		{
			yield return Timing.WaitForSeconds(720f);
			if (!_fZQIPQuHiMARw || !Round.IsStarted || Round.IsEnded)
			{
				break;
			}
			_tFSvmwPozWjQP result = _mc1c2c0f9728dd441((ZoneType zone) => true, (Pickup pickup) => !_mKQCaFlEoNVYd(pickup.Type), cleanupRagdolls: true);
			_mCCDBtxKuTYhr("12-minute interval", result);
		}
	}

	private IEnumerator<float> _meb3ff2a662e8f06c()
	{
		while (_fZQIPQuHiMARw && Round.IsStarted && !Round.IsEnded)
		{
			if (!Player.List.Any((Player player) => player != null && player.IsAlive && ((Enum)player.Zone).HasFlag((Enum)(object)(ZoneType)1)))
			{
				_tFSvmwPozWjQP result = _mc1c2c0f9728dd441((ZoneType zone) => ((Enum)zone).HasFlag((Enum)(object)(ZoneType)1), (Pickup pickup) => true, cleanupRagdolls: true);
				_mCCDBtxKuTYhr("light containment decontamination", result);
				break;
			}
			yield return Timing.WaitForSeconds(0.5f);
		}
	}

	private static bool _mKQCaFlEoNVYd(ItemType itemType)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		if (_f8ed0509b4a9d133e.Contains(itemType))
		{
			return true;
		}
		if ((int)itemType != 42)
		{
			return ItemExtensions.IsScp(itemType);
		}
		return false;
	}

	private static _tFSvmwPozWjQP _mc1c2c0f9728dd441(Func<ZoneType, bool> zonePredicate, Func<Pickup, bool> pickupPredicate, bool cleanupRagdolls)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		_tFSvmwPozWjQP tFSvmwPozWjQP = new _tFSvmwPozWjQP();
		foreach (Pickup item in Pickup.List.Where((Pickup item) => item != null).ToList())
		{
			ZoneType arg = (ZoneType)((!((Object)(object)item.Room == (Object)null)) ? ((int)item.Room.Zone) : 0);
			if (zonePredicate(arg) && pickupPredicate(item))
			{
				if ((Object)(object)item.GameObject != (Object)null)
				{
					NetworkServer.Destroy(item.GameObject);
				}
				else
				{
					item.Destroy();
				}
				tFSvmwPozWjQP.Pickups++;
			}
		}
		if (!cleanupRagdolls)
		{
			return tFSvmwPozWjQP;
		}
		foreach (Ragdoll item2 in Ragdoll.List.Where((Ragdoll item) => item != null).ToList())
		{
			ZoneType arg2 = (ZoneType)((!((Object)(object)item2.Room == (Object)null)) ? ((int)item2.Room.Zone) : 0);
			if (zonePredicate(arg2))
			{
				item2.Destroy();
				tFSvmwPozWjQP.Ragdolls++;
			}
		}
		return tFSvmwPozWjQP;
	}

	private static void _mCCDBtxKuTYhr(string reason, _tFSvmwPozWjQP result)
	{
		Log.Info(Encoding.UTF8.GetString(Convert.FromBase64String("W0F1dG9tYXRpY0NsZWFudXBdIA==")) + reason + Encoding.UTF8.GetString(Convert.FromBase64String("OiByZW1vdmVkIA==")) + result.Pickups + Encoding.UTF8.GetString(Convert.FromBase64String("IHBpY2t1cChzKSBhbmQg")) + result.Ragdolls + Encoding.UTF8.GetString(Convert.FromBase64String("IHJhZ2RvbGwocyku")));
	}

	private void _mljenczGQdfLc()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		Timing.KillCoroutines((CoroutineHandle[])(object)new CoroutineHandle[1] { _f706572696f646963436f726f7574696e653a300 });
		Timing.KillCoroutines((CoroutineHandle[])(object)new CoroutineHandle[1] { _f3e3f3935342e3b3733343b2e333534193528352f2e33343f606a });
		Timing.KillCoroutines(Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0LkF1dG9tYXRpY0NsZWFudXAuUGVyaW9kaWM=")));
		Timing.KillCoroutines(Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0LkF1dG9tYXRpY0NsZWFudXAuRGVjb250YW1pbmF0aW9u")));
	}

	[CompilerGenerated]
	private void _m3c4f6e576172686561644465746f6e617465643e625f5f31325f303a300()
	{
		if (_fZQIPQuHiMARw)
		{
			_tFSvmwPozWjQP result = _mc1c2c0f9728dd441((ZoneType zone) => !((Enum)zone).HasFlag((Enum)(object)(ZoneType)8), (Pickup pickup) => true, cleanupRagdolls: true);
			_mCCDBtxKuTYhr(Encoding.UTF8.GetString(Convert.FromBase64String("d2FyaGVhZA==")), result);
		}
	}
}
