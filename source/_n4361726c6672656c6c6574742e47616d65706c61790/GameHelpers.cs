using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.DamageHandlers;
using Exiled.API.Structs;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using Exiled.Events.Handlers;
using InventorySystem.Items.Usables.Scp330;
using MEC;
using PlayerRoles;
using UnityEngine;
using _n4361726c6672656c6c6574740;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class GameHelpers
{
	private sealed class _ta1785cb76d3ff2c3
	{
		public Vector3 LastPosition { get; set; }

		public float StandingStillSeconds { get; set; }
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _t666439606a
	{
		public static readonly _t666439606a _003C_003E9 = new _t666439606a();

		public static Func<ItemType, bool> _003C_003E9__20_0;

		internal bool _mFbIJhdtUNwfb(ItemType item)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_0003: Invalid comparison between Unknown and I4
			return (int)item != 42;
		}
	}

	private const float _f083f3d3f343f283b2e3335340e333931093f3935343e29606a = 1f;

	private const float _f4d6f76656d656e74546f6c6572616e63655371724d61676e69747564653a300 = 0.0025f;

	private const float _f4c6576656c4c6f61646f757452657472795365636f6e64733a300 = 0.25f;

	private const int _f7102befa31c4c61c = 40;

	private const int _fDOYAEyasNwMx = 200;

	private static readonly HashSet<ItemType> _f4b6579636172644974656d733a300 = new HashSet<ItemType>
	{
		(ItemType)0,
		(ItemType)1,
		(ItemType)2,
		(ItemType)3,
		(ItemType)4,
		(ItemType)6,
		(ItemType)9,
		(ItemType)10,
		(ItemType)11
	};

	private readonly Plugin _fDLiPIlmIxfdv;

	private readonly Dictionary<int, _ta1785cb76d3ff2c3> _fIVepPzJGyOzi = new Dictionary<int, _ta1785cb76d3ff2c3>();

	private readonly Dictionary<int, CoroutineHandle> _fd096204ba859dc84 = new Dictionary<int, CoroutineHandle>();

	private CoroutineHandle _fcajaRuOzcRzo;

	public GameHelpers(Plugin plugin)
	{
		_fDLiPIlmIxfdv = plugin;
	}

	public void Enable()
	{
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		Player.ChangingRole += _m15340a363b233f2819323b343d3f3e0835363f606a;
		Player.Hurting += _mdAhlJqWDsNcz;
		Player.Died += _m4f6e506c61796572446965643a300;
		Player.Left += _m1cdda5bd85f18bde;
		Player.Spawned += _m811303b95316bbaf;
		Player.PickingUpItem += _m644691d553d0d361;
		Server.RoundStarted += _mjasvFjiJErey;
		Server.RoundEnded += _msoHDqdKkNLRc;
		_fcajaRuOzcRzo = Timing.RunCoroutine(_m5363705374616e645374696c6c526567656e65726174696f6e4c6f6f703a300());
	}

	public void Disable()
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ce: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		Player.ChangingRole -= _m15340a363b233f2819323b343d3f3e0835363f606a;
		Player.Hurting -= _mdAhlJqWDsNcz;
		Player.Died -= _m4f6e506c61796572446965643a300;
		Player.Left -= _m1cdda5bd85f18bde;
		Player.Spawned -= _m811303b95316bbaf;
		Player.PickingUpItem -= _m644691d553d0d361;
		Server.RoundStarted -= _mjasvFjiJErey;
		Server.RoundEnded -= _msoHDqdKkNLRc;
		if (((CoroutineHandle)(ref _fcajaRuOzcRzo)).IsRunning)
		{
			Timing.KillCoroutines((CoroutineHandle[])(object)new CoroutineHandle[1] { _fcajaRuOzcRzo });
		}
		_fIVepPzJGyOzi.Clear();
		foreach (CoroutineHandle value in _fd096204ba859dc84.Values)
		{
			Timing.KillCoroutines((CoroutineHandle[])(object)new CoroutineHandle[1] { value });
		}
		_fd096204ba859dc84.Clear();
	}

	private void _mdAhlJqWDsNcz(HurtingEventArgs ev)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Invalid comparison between Unknown and I4
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Invalid comparison between Unknown and I4
		if (ev != null && ev.Player != null && ev.DamageHandler != null)
		{
			if ((int)((DamageHandlerBase)ev.DamageHandler).Type == 29 && !CustomRoleSystem._m49735363703939393a300(ev.Attacker))
			{
				ev.Amount += 50f;
			}
			if ((int)ev.Player.Role.Team == 0 && (int)((DamageHandlerBase)ev.DamageHandler).Type == 37)
			{
				ev.Amount = 500f;
				Player player = ev.Player;
				player.HumeShield -= ev.Player.HumeShield;
			}
		}
	}

	private void _m15340a363b233f2819323b343d3f3e0835363f606a(ChangingRoleEventArgs ev)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		_m399c351d732f3657(ev.Player);
		_mHLvSQAObPyVX(ev.Player);
		if (_mDXQUpEHgiPjb(ev))
		{
			int level;
			bool flag = ExperienceSystem.TryGetPlayerLevel(ev.Player, out level);
			_m3539163d82031f58(ev.Items, ev.NewRole, flag ? level : 0);
			if (!flag)
			{
				_maxngDgrSKjph(ev.Player, ev.NewRole);
			}
		}
		RoleTypeId expectedRole = ev.NewRole;
		Timing.CallDelayed(0.5f, (Action)delegate
		{
			//IL_0012: Unknown result type (might be due to invalid IL or missing references)
			_m416464556e6368616e676564526f6c654974656d733a300(ev.Player, expectedRole);
		});
	}

	private void _m416464556e6368616e676564526f6c654974656d733a300(Player player, RoleTypeId expectedRole)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Expected I4, but got Unknown
		if (player != null && !(player.ReferenceHub == (ReferenceHub)null) && player.Role.Type == expectedRole)
		{
			RoleTypeId type = player.Role.Type;
			switch (type - 4)
			{
			case 11:
				player.AddItem((ItemType)39, (IEnumerable<AttachmentIdentifier>)null);
				break;
			case 9:
				player.AddItem((ItemType)26, (IEnumerable<AttachmentIdentifier>)null);
				player.AddItem((ItemType)13, (IEnumerable<AttachmentIdentifier>)null);
				break;
			case 7:
				player.AddItem((ItemType)26, (IEnumerable<AttachmentIdentifier>)null);
				player.AddItem((ItemType)30, (IEnumerable<AttachmentIdentifier>)null);
				player.AddItem((ItemType)33, (IEnumerable<AttachmentIdentifier>)null);
				break;
			case 8:
				player.AddItem((ItemType)26, (IEnumerable<AttachmentIdentifier>)null);
				player.AddItem((ItemType)30, (IEnumerable<AttachmentIdentifier>)null);
				break;
			case 0:
				player.AddItem((ItemType)26, (IEnumerable<AttachmentIdentifier>)null);
				player.AddItem((ItemType)30, (IEnumerable<AttachmentIdentifier>)null);
				player.AddItem((ItemType)33, (IEnumerable<AttachmentIdentifier>)null);
				break;
			case 14:
			case 16:
				player.AddItem((ItemType)26, (IEnumerable<AttachmentIdentifier>)null);
				break;
			case 15:
				player.AddItem((ItemType)26, (IEnumerable<AttachmentIdentifier>)null);
				player.AddItem((ItemType)25, (IEnumerable<AttachmentIdentifier>)null);
				break;
			case 4:
				player.AddItem((ItemType)26, (IEnumerable<AttachmentIdentifier>)null);
				player.AddItem((ItemType)25, (IEnumerable<AttachmentIdentifier>)null);
				player.AddItem((ItemType)33, (IEnumerable<AttachmentIdentifier>)null);
				break;
			case 1:
			case 2:
			case 3:
			case 5:
			case 6:
			case 10:
			case 12:
			case 13:
				break;
			}
		}
	}

	private static bool _mDXQUpEHgiPjb(ChangingRoleEventArgs ev)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Invalid comparison between Unknown and I4
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Invalid comparison between Unknown and I4
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Invalid comparison between Unknown and I4
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Invalid comparison between Unknown and I4
		if (ev == null || ev.Player == null || ((int)ev.NewRole != 1 && (int)ev.NewRole != 6 && (int)ev.NewRole != 15))
		{
			return false;
		}
		if ((int)ev.Reason != 1)
		{
			return (int)ev.Reason == 2;
		}
		return true;
	}

	private static void _m3539163d82031f58(IList<ItemType> items, RoleTypeId role, int level)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Invalid comparison between Unknown and I4
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Invalid comparison between Unknown and I4
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Invalid comparison between Unknown and I4
		if (items == null)
		{
			return;
		}
		if ((int)role != 1 && (int)role != 6)
		{
			if ((int)role == 15)
			{
				_mssNiBiJoNvkJ(items, level);
			}
		}
		else
		{
			_mTKNsgGiZbDoW(items, level);
		}
	}

	private static void _msKWTWyaJALWe(Player player, RoleTypeId role, int level)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		if (player == null || player.ReferenceHub == (ReferenceHub)null || player.Role.Type != role)
		{
			return;
		}
		if ((int)role != 1 && (int)role != 6)
		{
			if ((int)role == 15)
			{
				_moOEEQYpAcUZZ(player, level);
			}
		}
		else
		{
			_ma2fd9d04bc0fb197(player, level);
		}
	}

	private static void _mTKNsgGiZbDoW(IList<ItemType> items, int level)
	{
		int num = _m1d15b6a33abfc1cc(level);
		if (num <= 30)
		{
			_m416464556e697175653a300(items, (ItemType)0);
			_m416464556e697175653a300(items, (ItemType)14);
			return;
		}
		_m416464556e697175653a300(items, (ItemType)1);
		if (num >= 91)
		{
			_m416464556e697175653a300(items, (ItemType)3);
		}
		if (num >= 121)
		{
			_m416464556e697175653a300(items, (ItemType)17);
		}
		else if (num >= 61)
		{
			_m416464556e697175653a300(items, (ItemType)14);
		}
		_m416464556e697175653a300(items, (ItemType)33);
		if (num >= 61)
		{
			_m416464556e697175653a300(items, (ItemType)42);
		}
		if (num >= 91)
		{
			_m416464556e697175653a300(items, (ItemType)18);
		}
	}

	private static void _ma2fd9d04bc0fb197(Player player, int level)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		List<ItemType> list = new List<ItemType>();
		_mTKNsgGiZbDoW(list, level);
		foreach (ItemType item in list.Where((ItemType item) => (int)item != 42))
		{
			player.AddItem(item, (IEnumerable<AttachmentIdentifier>)null);
		}
		_m4769766543616e646965733a300(player, _m1d3f2e19332c3336333b34193b343e2319352f342e606a(level));
	}

	private static void _mssNiBiJoNvkJ(IList<ItemType> items, int level)
	{
		int num = _m1d15b6a33abfc1cc(level);
		if (num >= 151)
		{
			_m416464556e697175653a300(items, (ItemType)17);
		}
		else if (num >= 121)
		{
			_m416464556e697175653a300(items, (ItemType)34);
			_m416464556e697175653a300(items, (ItemType)33);
		}
		else if (num >= 91)
		{
			_m416464556e697175653a300(items, (ItemType)33);
		}
		else if (num >= 61)
		{
			_m416464556e697175653a300(items, (ItemType)14);
		}
		else if (num >= 31)
		{
			_m416464556e697175653a300(items, (ItemType)34);
		}
	}

	private static void _moOEEQYpAcUZZ(Player player, int level)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		List<ItemType> list = new List<ItemType>();
		_mssNiBiJoNvkJ(list, level);
		foreach (ItemType item in list)
		{
			player.AddItem(item, (IEnumerable<AttachmentIdentifier>)null);
		}
	}

	private static int _m1d15b6a33abfc1cc(int level)
	{
		return Math.Max(1, Math.Min(200, level));
	}

	private static int _m1d3f2e19332c3336333b34193b343e2319352f342e606a(int level)
	{
		int num = _m1d15b6a33abfc1cc(level);
		if (num < 151)
		{
			if (num < 121)
			{
				return (num >= 61) ? 1 : 0;
			}
			return 2;
		}
		return 3;
	}

	private static void _m4769766543616e646965733a300(Player player, int count)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		for (int i = 0; i < count; i++)
		{
			player.TryAddCandy(Scp330Candies.GetRandom());
		}
	}

	private static bool _m49734c6576656c5265776172644974656d3a300(ItemType item)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Invalid comparison between Unknown and I4
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Invalid comparison between Unknown and I4
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		if (!_f4b6579636172644974656d733a300.Contains(item) && !_m49734c6576656c4d65646963616c4974656d3a300(item) && (int)item != 17 && (int)item != 18)
		{
			return (int)item == 42;
		}
		return true;
	}

	private static void _m083f37352c3f173f3e33393b36132e3f3729606a(IList<ItemType> items)
	{
		_mSPtSTvKYMNhP(items, _m49734c6576656c4d65646963616c4974656d3a300);
	}

	private static bool _m49734c6576656c4d65646963616c4974656d3a300(ItemType item)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Invalid comparison between Unknown and I4
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Invalid comparison between Unknown and I4
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Invalid comparison between Unknown and I4
		if ((int)item != 34 && (int)item != 14 && (int)item != 33)
		{
			return (int)item == 17;
		}
		return true;
	}

	private static void _mSPtSTvKYMNhP(IList<ItemType> items, Func<ItemType, bool> predicate)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		for (int num = items.Count - 1; num >= 0; num--)
		{
			if (predicate(items[num]))
			{
				items.RemoveAt(num);
			}
		}
	}

	private static void _m416464556e697175653a300(IList<ItemType> items, ItemType item)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		if (!items.Contains(item))
		{
			items.Add(item);
		}
	}

	private void _maxngDgrSKjph(Player player, RoleTypeId role)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		if (player != null)
		{
			ReferenceHub referenceHub = player.ReferenceHub;
			string userId = player.UserId;
			CoroutineHandle value = Timing.RunCoroutine(_m57616974466f724c6576656c416e64526566726573684c6f61646f75743a300(player.Id, referenceHub, userId, role), (Segment)4);
			_fd096204ba859dc84[player.Id] = value;
		}
	}

	private IEnumerator<float> _m57616974466f724c6576656c416e64526566726573684c6f61646f75743a300(int playerId, ReferenceHub expectedHub, string expectedUserId, RoleTypeId role)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		for (int attempt = 0; attempt < 40; attempt++)
		{
			yield return Timing.WaitForSeconds(0.25f);
			Player val = Player.Get(playerId);
			if (!_tFpYLlGZVhITT.IsSameSession(val, expectedHub, expectedUserId) || val.Role.Type != role)
			{
				_fd096204ba859dc84.Remove(playerId);
				yield break;
			}
			if (ExperienceSystem.TryGetPlayerLevel(val, out var level))
			{
				_msKWTWyaJALWe(val, role, level);
				_fd096204ba859dc84.Remove(playerId);
				yield break;
			}
		}
		_fd096204ba859dc84.Remove(playerId);
	}

	private void _mHLvSQAObPyVX(Player player)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		if (player != null && _fd096204ba859dc84.TryGetValue(player.Id, out var value))
		{
			Timing.KillCoroutines((CoroutineHandle[])(object)new CoroutineHandle[1] { value });
			_fd096204ba859dc84.Remove(player.Id);
		}
	}

	private void _m4f6e506c61796572446965643a300(DiedEventArgs ev)
	{
		_m399c351d732f3657(ev.Player);
		_mHLvSQAObPyVX(ev.Player);
	}

	private void _m1cdda5bd85f18bde(LeftEventArgs ev)
	{
		_m399c351d732f3657(ev.Player);
		_mHLvSQAObPyVX(ev.Player);
	}

	private void _m811303b95316bbaf(SpawnedEventArgs ev)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Invalid comparison between Unknown and I4
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Invalid comparison between Unknown and I4
		_m399c351d732f3657(ev.Player);
		if (ev.Player != null && ((int)ev.Player.Role.Type == 1 || (int)ev.Player.Role.Type == 6) && ExperienceSystem.TryGetPlayerLevel(ev.Player, out var level))
		{
			_m4769766543616e646965733a300(ev.Player, _m1d3f2e19332c3336333b34193b343e2319352f342e606a(level));
		}
	}

	private static void _m644691d553d0d361(PickingUpItemEventArgs ev)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Invalid comparison between Unknown and I4
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Invalid comparison between Unknown and I4
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Invalid comparison between Unknown and I4
		if (ev.IsAllowed && ev.Player != null && ev.Pickup != null && (int)ev.Player.Role.Team == 0)
		{
			ItemType type = ev.Pickup.Type;
			if (ItemExtensions.IsScp(type) || (int)type == 16 || (int)type == 47 || (int)type == 52)
			{
				ev.IsAllowed = false;
			}
		}
	}

	private void _mjasvFjiJErey()
	{
		_fIVepPzJGyOzi.Clear();
	}

	private void _msoHDqdKkNLRc(RoundEndedEventArgs ev)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		_fIVepPzJGyOzi.Clear();
		foreach (CoroutineHandle value in _fd096204ba859dc84.Values)
		{
			Timing.KillCoroutines((CoroutineHandle[])(object)new CoroutineHandle[1] { value });
		}
		_fd096204ba859dc84.Clear();
	}

	private IEnumerator<float> _m5363705374616e645374696c6c526567656e65726174696f6e4c6f6f703a300()
	{
		while (true)
		{
			try
			{
				_m4f99c103e43d0f04();
			}
			catch (Exception ex)
			{
				Log.Error("Failed to process SCP stand-still regeneration: " + ex);
			}
			yield return Timing.WaitForSeconds(1f);
		}
	}

	private void _m4f99c103e43d0f04()
	{
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		ScpStandStillRegenerationConfig scpStandStillRegeneration = ((Plugin<Config>)_fDLiPIlmIxfdv).Config.ScpStandStillRegeneration;
		if (scpStandStillRegeneration == null || !scpStandStillRegeneration.IsEnabled || !Round.IsStarted)
		{
			_fIVepPzJGyOzi.Clear();
			return;
		}
		float num = Math.Max(0f, scpStandStillRegeneration.StartAfterSeconds);
		float num2 = Math.Max(0f, scpStandStillRegeneration.HealPerSecond);
		foreach (Player item in Player.List)
		{
			if (!_m53686f756c64547261636b5363703a300(item))
			{
				_m399c351d732f3657(item);
				continue;
			}
			_ta1785cb76d3ff2c3 ta1785cb76d3ff2c = _mce7575a02087981d(item);
			Vector3 position = item.Position;
			Vector3 val = position - ta1785cb76d3ff2c.LastPosition;
			if (((Vector3)(ref val)).sqrMagnitude > 0.0025f)
			{
				ta1785cb76d3ff2c.LastPosition = position;
				ta1785cb76d3ff2c.StandingStillSeconds = 0f;
				continue;
			}
			ta1785cb76d3ff2c.LastPosition = position;
			ta1785cb76d3ff2c.StandingStillSeconds += 1f;
			if (!(ta1785cb76d3ff2c.StandingStillSeconds < num) && !(item.Health >= item.MaxHealth) && !(num2 <= 0f))
			{
				item.Health = Math.Min(item.MaxHealth, item.Health + num2);
			}
		}
	}

	private static bool _m53686f756c64547261636b5363703a300(Player player)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Invalid comparison between Unknown and I4
		if (player != null && player.ReferenceHub != (ReferenceHub)null && player.IsAlive)
		{
			return (int)player.Role.Team == 0;
		}
		return false;
	}

	private _ta1785cb76d3ff2c3 _mce7575a02087981d(Player player)
	{
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		if (!_fIVepPzJGyOzi.TryGetValue(player.Id, out var value))
		{
			value = new _ta1785cb76d3ff2c3
			{
				LastPosition = player.Position,
				StandingStillSeconds = 0f
			};
			_fIVepPzJGyOzi[player.Id] = value;
		}
		return value;
	}

	private void _m399c351d732f3657(Player player)
	{
		if (player != null)
		{
			_fIVepPzJGyOzi.Remove(player.Id);
		}
	}
}
