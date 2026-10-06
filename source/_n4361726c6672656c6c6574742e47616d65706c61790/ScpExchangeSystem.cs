using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using Exiled.Events.Handlers;
using MEC;
using PlayerRoles;
using RueI.Displays;
using RueI.Elements;
using RueI.Extensions;
using UnityEngine;
using _n4361726c6672656c6c6574740;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class ScpExchangeSystem
{
	private sealed class _tb5698684f40e40d1
	{
		public readonly int InitiatorPlayerId;

		public readonly RoleTypeId TargetRole;

		public readonly bool IsPublic;

		public readonly int Generation;

		public readonly float ExpiresAt;

		public _tb5698684f40e40d1(int initiatorPlayerId, RoleTypeId targetRole, bool isPublic, int generation, float expiresAt)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			InitiatorPlayerId = initiatorPlayerId;
			TargetRole = targetRole;
			IsPublic = isPublic;
			Generation = generation;
			ExpiresAt = expiresAt;
		}
	}

	private sealed class _t3ba6decb1ce4e0a8
	{
		public readonly _t526f6c6553746174653a300 State;

		public readonly long Sequence;

		public readonly int Generation;

		public readonly float ExpiresAt;

		public _t3ba6decb1ce4e0a8(_t526f6c6553746174653a300 state, long sequence, int generation, float expiresAt)
		{
			State = state;
			Sequence = sequence;
			Generation = generation;
			ExpiresAt = expiresAt;
		}
	}

	private sealed class _t526f6c6553746174653a300
	{
		public RoleTypeId Role { get; private set; }

		public float Health { get; private set; }

		public float HumeShield { get; private set; }

		public Vector3 Position { get; private set; }

		public static _t526f6c6553746174653a300 Capture(Player player)
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			return new _t526f6c6553746174653a300
			{
				Role = player.Role.Type,
				Health = player.Health,
				HumeShield = player.HumeShield,
				Position = player.Position
			};
		}
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _tipAmyFlkeZNp
	{
		public static readonly _tipAmyFlkeZNp _003C_003E9 = new _tipAmyFlkeZNp();

		public static Func<_t3ba6decb1ce4e0a8, long> _003C_003E9__20_0;

		public static Func<KeyValuePair<RoleTypeId, _t3ba6decb1ce4e0a8>, RoleTypeId> _003C_003E9__35_1;

		public static Func<RoleTypeId, string> _003C_003E9__44_0;

		public static Func<_t3ba6decb1ce4e0a8, long> _003C_003E9__48_0;

		public static Func<_t3ba6decb1ce4e0a8, string> _003C_003E9__48_1;

		internal long _m3c5472794163636570744f724170706c793e625f5f32305f303a300(_t3ba6decb1ce4e0a8 item)
		{
			return item.Sequence;
		}

		internal RoleTypeId _m3c4578706972655374616c6553746174653e625f5f33355f313a300(KeyValuePair<RoleTypeId, _t3ba6decb1ce4e0a8> item)
		{
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			return item.Key;
		}

		internal string _m34bbc86dce8e447c(RoleTypeId role)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			return _mWKPddarPEbxN(role).Replace(Encoding.UTF8.GetString(Convert.FromBase64String("U0NQLQ==")), string.Empty);
		}

		internal long _m3c4275696c6448696e743e625f5f34385f303a300(_t3ba6decb1ce4e0a8 item)
		{
			return item.Sequence;
		}

		internal string _m3c4275696c6448696e743e625f5f34385f313a300(_t3ba6decb1ce4e0a8 item)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return _mWKPddarPEbxN(item.State.Role);
		}
	}

	private const float _f1233342e0a3529332e333534606a = 800f;

	private const float _f1f2239323b343d3f0d33343e352d093f3935343e29606a = 180f;

	private const float _f657428f3ccc39258 = 120f;

	private const float _f3c415eb5ba35afe8 = 120f;

	private const RoleSpawnFlags _f1f2239323b343d3f092a3b2d341c363b3d29606a = (RoleSpawnFlags)3;

	private static readonly IElemReference<SetElement> _fAZFIKoUXyvTE = DisplayCore.GetReference<SetElement>();

	private readonly Dictionary<RoleTypeId, _t3ba6decb1ce4e0a8> _f766163616e636965733a300 = new Dictionary<RoleTypeId, _t3ba6decb1ce4e0a8>();

	private readonly HashSet<int> _fDhJMNsoxfZaO = new HashSet<int>();

	private _tb5698684f40e40d1 _fcdaa1f12e04059af;

	private float _f28352f343e092e3b282e3f3e1b2e606a;

	private int _fb533f052d7522541;

	private long _f766163616e637953657175656e63653a300;

	private bool _f7dbe8c87f6ac77c2;

	public static ScpExchangeSystem Instance { get; private set; }

	public ScpExchangeSystem(Plugin plugin)
	{
	}

	public void Enable()
	{
		if (!_f7dbe8c87f6ac77c2)
		{
			_f7dbe8c87f6ac77c2 = true;
			Instance = this;
			Player.Verified += _m4f6e56657269666965643a300;
			Player.Left += _m1534163f3c2e606a;
			Player.Hurting += _m4f6e48757274696e673a300;
			Player.ChangingRole += _m4f6e4368616e67696e67526f6c653a300;
			Server.RoundStarted += _m153408352f343e092e3b282e3f3e606a;
			Server.RoundEnded += _m615d6ff1f188485b;
			Server.WaitingForPlayers += _m153408352f343e083f293f2e606a;
			Server.RestartingRound += _m153408352f343e083f293f2e606a;
		}
	}

	public void Disable()
	{
		if (_f7dbe8c87f6ac77c2)
		{
			Player.Verified -= _m4f6e56657269666965643a300;
			Player.Left -= _m1534163f3c2e606a;
			Player.Hurting -= _m4f6e48757274696e673a300;
			Player.ChangingRole -= _m4f6e4368616e67696e67526f6c653a300;
			Server.RoundStarted -= _m153408352f343e092e3b282e3f3e606a;
			Server.RoundEnded -= _m615d6ff1f188485b;
			Server.WaitingForPlayers -= _m153408352f343e083f293f2e606a;
			Server.RestartingRound -= _m153408352f343e083f293f2e606a;
			_m19363f3b28092e3b2e3f606a();
			_m19363f3b281b36361233342e29606a();
			_f7dbe8c87f6ac77c2 = false;
			if (Instance == this)
			{
				Instance = null;
			}
		}
	}

	public bool TryAcceptOrApply(Player player, out string response)
	{
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		_m4578706972655374616c6553746174653a300();
		if (player == null || !player.IsAlive)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5Y+q5pyJ5a2Y5rS7546p5a625Y+v5Lul5ZCM5oSP5Lqk5o2i5oiW55Sz6K+36KGl5L2N44CC"));
			return false;
		}
		if (_fcdaa1f12e04059af != null)
		{
			return _m54727941636365707445786368616e67653a300(player, out response);
		}
		_t3ba6decb1ce4e0a8 t3ba6decb1ce4e0a = _f766163616e636965733a300.Values.OrderBy((_t3ba6decb1ce4e0a8 item) => item.Sequence).FirstOrDefault();
		if (t3ba6decb1ce4e0a == null)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5b2T5YmN5rKh5pyJ5Lqk5o2i6K+35rGC5oiW5b6F6KGl5L2N55qEIFNDUOOAgg=="));
			return false;
		}
		if ((int)player.Role.Team == 0)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("U0NQIOeOqeWutuS4jeiDveeUs+ivt+W8guW4uOemu+WcuuihpeS9jeOAgg=="));
			return false;
		}
		_f766163616e636965733a300.Remove(t3ba6decb1ce4e0a.State.Role);
		_me7e18252167f1765(player, t3ba6decb1ce4e0a.State, restorePosition: true);
		_m083f3c283f29321b36361233342e29606a();
		response = Encoding.UTF8.GetString(Convert.FromBase64String("5bey6Ieq5Yqo6KGl5L2NIA==")) + _mWKPddarPEbxN(t3ba6decb1ce4e0a.State.Role) + Encoding.UTF8.GetString(Convert.FromBase64String("44CC"));
		Log.Info(Encoding.UTF8.GetString(Convert.FromBase64String("W1NDUCBleGNoYW5nZV0g")) + player.Nickname + Encoding.UTF8.GetString(Convert.FromBase64String("IGZpbGxlZCA=")) + ((object)t3ba6decb1ce4e0a.State.Role/*cast due to .constrained prefix*/).ToString() + Encoding.UTF8.GetString(Convert.FromBase64String("Lg==")));
		return true;
	}

	public bool TryOpenInternalExchange(Player initiator, string roleCode, out string response)
	{
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		if (!_m193b34152a3f341f2239323b343d3f606a(initiator, out response))
		{
			return false;
		}
		if (!_mde5a5e85afa09d64(roleCode, out var targetRole))
		{
			response = _m4275696c64526f6c655461626c653a300(Encoding.UTF8.GetString(Convert.FromBase64String("LnNjcHM=")));
			return false;
		}
		if (Player.List.FirstOrDefault((Player player) => player != null && player != initiator && player.IsAlive && player.Role.Type == targetRole) == null)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("6K+lIFNDUCDlvZPliY3msqHmnInlhbbku5bnjqnlrrblj6/kvpvkuqTmjaLjgIIK")) + _m4275696c64526f6c655461626c653a300(Encoding.UTF8.GetString(Convert.FromBase64String("LnNjcHM=")));
			return false;
		}
		int num = ++_fb533f052d7522541;
		_fcdaa1f12e04059af = new _tb5698684f40e40d1(initiator.Id, targetRole, isPublic: false, num, _m47657445786368616e6765526571756573744578706972793a300());
		_m0939323f3e2f363f083f2b2f3f292e1f222a33283b2e333534606a(num, _fcdaa1f12e04059af.ExpiresAt);
		_m083f3c283f29321b36361233342e29606a();
		response = Encoding.UTF8.GetString(Convert.FromBase64String("5bey5ZCRIA==")) + _mWKPddarPEbxN(targetRole) + Encoding.UTF8.GetString(Convert.FromBase64String("IOWPkei1t+WGhemDqOS6pOaNou+8m+WvueaWuei+k+WFpSAuc2NwYSDlkIzmhI/jgILor7fmsYIgMiDliIbpkp/lkI7liLDmnJ/jgII="));
		return true;
	}

	public bool TryOpenPublicExchange(Player initiator, out string response)
	{
		if (!_m193b34152a3f341f2239323b343d3f606a(initiator, out response))
		{
			return false;
		}
		if (_fDhJMNsoxfZaO.Contains(initiator.Id))
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5L2g5Zyo5pys5qyhIFNDUCDop5LoibLmnJ/pl7Tlt7Lnu4/lj5fliLDkvKTlrrPvvIzkuI3og73lj5HotbflhazlvIDkuqTmjaLjgII="));
			return false;
		}
		int num = ++_fb533f052d7522541;
		_fcdaa1f12e04059af = new _tb5698684f40e40d1(initiator.Id, (RoleTypeId)(-1), isPublic: true, num, _m47657445786368616e6765526571756573744578706972793a300());
		_m0939323f3e2f363f083f2b2f3f292e1f222a33283b2e333534606a(num, _fcdaa1f12e04059af.ExpiresAt);
		_m083f3c283f29321b36361233342e29606a();
		response = Encoding.UTF8.GetString(Convert.FromBase64String("5bey5Y+R6LW35YWs5byA5Lqk5o2i77yb56ys5LiA5L2N6L6T5YWlIC5zY3BhIOeahOWtmOa0u+eOqeWutuWwhueri+WNs+WujOaIkOS6pOaNouOAguivt+axgiAyIOWIhumSn+WQjuWIsOacn+OAgg=="));
		return true;
	}

	public bool TrySelfChange(Player player, string roleCode, out string response)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_011d: Unknown result type (might be due to invalid IL or missing references)
		//IL_013a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		if (player == null || !player.IsAlive || (int)player.Role.Team != 0)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5Y+q5pyJ5a2Y5rS755qEIFNDUCDlj6/ku6Xoh6rliqnmm7TmjaIgU0NQIOinkuiJsuOAgg=="));
			return false;
		}
		if (!_mxRzixtBXSAUb(120f))
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("6Ieq5Yqp5Lqk5o2i5LuF6ZmQ5Zue5ZCI5byA5aeL5ZCO55qEIDIg5YiG6ZKf5YaF44CC"));
			return false;
		}
		if (_fDhJMNsoxfZaO.Contains(player.Id))
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5L2g5Zyo5pys5qyhIFNDUCDop5LoibLmnJ/pl7Tlt7Lnu4/lj5fliLDkvKTlrrPvvIzkuI3og73oh6rliqnkuqTmjaLjgII="));
			return false;
		}
		if (!_mde5a5e85afa09d64(roleCode, out var role))
		{
			response = _m4275696c64526f6c655461626c653a300(Encoding.UTF8.GetString(Convert.FromBase64String("LnNjcGM=")));
			return false;
		}
		if (role == player.Role.Type)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5L2g5bey57uP5pivIA==")) + _mWKPddarPEbxN(role) + Encoding.UTF8.GetString(Convert.FromBase64String("44CC"));
			return false;
		}
		if (_m825e9ed5a8fc5f8b(role) != null)
		{
			response = _mWKPddarPEbxN(role) + Encoding.UTF8.GetString(Convert.FromBase64String("IOW3suiiq+WNoOeUqO+8jOS4jeiDveiHquWKqeS6pOaNouOAgg=="));
			return false;
		}
		player.Role.Set(role, (SpawnReason)7, (RoleSpawnFlags)3);
		response = Encoding.UTF8.GetString(Convert.FromBase64String("5bey6Ieq5Yqp5pu05o2i5Li6IA==")) + _mWKPddarPEbxN(role) + Encoding.UTF8.GetString(Convert.FromBase64String("44CC"));
		return true;
	}

	private bool _m54727941636365707445786368616e67653a300(Player player, out string response)
	{
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		if (!_mxRzixtBXSAUb(180f))
		{
			_m193635293f1f2239323b343d3f083f2b2f3f292e606a();
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5Lqk5o2i5LuF6ZmQ5Zue5ZCI5byA5aeL5ZCO55qEIDMg5YiG6ZKf5YaF44CC"));
			return false;
		}
		_tb5698684f40e40d1 fcdaa1f12e04059af = _fcdaa1f12e04059af;
		Player val = ((fcdaa1f12e04059af == null) ? null : Player.Get(fcdaa1f12e04059af.InitiatorPlayerId));
		if (fcdaa1f12e04059af == null || val == null || !val.IsAlive || (int)val.Role.Team != 0 || val == player)
		{
			_m193635293f1f2239323b343d3f083f2b2f3f292e606a();
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5Lqk5o2i6K+35rGC5bey57uP5aSx5pWI44CC"));
			return false;
		}
		if (!fcdaa1f12e04059af.IsPublic && player.Role.Type != fcdaa1f12e04059af.TargetRole)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("6K+l5YaF6YOo5Lqk5o2i5LuF562J5b6FIA==")) + _mWKPddarPEbxN(fcdaa1f12e04059af.TargetRole) + Encoding.UTF8.GetString(Convert.FromBase64String("IOeOqeWutuWQjOaEj+OAgg=="));
			return false;
		}
		_fcdaa1f12e04059af = null;
		_m381fed3f9c325f90(val, player);
		_m083f3c283f29321b36361233342e29606a();
		response = Encoding.UTF8.GetString(Convert.FromBase64String("5bey5LiOIA==")) + val.Nickname + Encoding.UTF8.GetString(Convert.FromBase64String("IOWujOaIkOinkuiJsuS6pOaNouOAgg=="));
		Log.Info(Encoding.UTF8.GetString(Convert.FromBase64String("W1NDUCBleGNoYW5nZV0g")) + val.Nickname + Encoding.UTF8.GetString(Convert.FromBase64String("IGV4Y2hhbmdlZCB3aXRoIA==")) + player.Nickname + Encoding.UTF8.GetString(Convert.FromBase64String("Lg==")));
		return true;
	}

	private bool _m193b34152a3f341f2239323b343d3f606a(Player initiator, out string response)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		_m4578706972655374616c6553746174653a300();
		if (initiator == null || !initiator.IsAlive || (int)initiator.Role.Team != 0)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5Y+q5pyJ5a2Y5rS755qEIFNDUCDlj6/ku6Xlj5HotbfkuqTmjaLjgII="));
			return false;
		}
		if (!_mxRzixtBXSAUb(180f))
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5Lqk5o2i5LuF6ZmQ5Zue5ZCI5byA5aeL5ZCO55qEIDMg5YiG6ZKf5YaF44CC"));
			return false;
		}
		if (_fcdaa1f12e04059af != null)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5b2T5YmN5bey5pyJ5LiA5Liq5Lqk5o2i6K+35rGC77yM6K+3562J5b6F5YW25a6M5oiQ5oiW5ZyoIDIg5YiG6ZKf5ZCO5Yiw5pyf44CC"));
			return false;
		}
		response = null;
		return true;
	}

	private void _m4f6e56657269666965643a300(VerifiedEventArgs ev)
	{
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		if (ev.Player != null)
		{
			Timing.CallDelayed(0f, (Action)delegate
			{
				_m5265667265736848696e743a300(ev.Player);
			});
		}
	}

	private void _m4f6e48757274696e673a300(HurtingEventArgs ev)
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		if (ev != null && ev.IsAllowed && !(ev.Amount <= 0f) && ev.Player != null && (int)ev.Player.Role.Team == 0)
		{
			_fDhJMNsoxfZaO.Add(ev.Player.Id);
		}
	}

	private void _m4f6e4368616e67696e67526f6c653a300(ChangingRoleEventArgs ev)
	{
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		if (ev.Player != null)
		{
			_fDhJMNsoxfZaO.Remove(ev.Player.Id);
			Timing.CallDelayed(0f, (Action)delegate
			{
				_m5265667265736848696e743a300(ev.Player);
			});
		}
	}

	private void _m1534163f3c2e606a(LeftEventArgs ev)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Invalid comparison between Unknown and I4
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_012c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0131: Unknown result type (might be due to invalid IL or missing references)
		Player player = ev.Player;
		if (_f7dbe8c87f6ac77c2 && player != null)
		{
			_fDhJMNsoxfZaO.Remove(player.Id);
			if (_fcdaa1f12e04059af != null && _fcdaa1f12e04059af.InitiatorPlayerId == player.Id)
			{
				_m193635293f1f2239323b343d3f083f2b2f3f292e606a();
			}
			if (Round.IsStarted && !Round.IsEnded && (int)player.Role.Team == 0 && _mlbQSKEFtybzL(player.Role.Type) && (int)player.Role.Type != 10)
			{
				_t526f6c6553746174653a300 t526f6c6553746174653a = _t526f6c6553746174653a300.Capture(player);
				long sequence = ++_f766163616e637953657175656e63653a300;
				int num = ++_fb533f052d7522541;
				_f766163616e636965733a300[t526f6c6553746174653a.Role] = new _t3ba6decb1ce4e0a8(t526f6c6553746174653a, sequence, num, Time.realtimeSinceStartup + 120f);
				_maMXoTAYVsDVJ(t526f6c6553746174653a.Role, num);
				_m083f3c283f29321b36361233342e29606a();
				Log.Info(Encoding.UTF8.GetString(Convert.FromBase64String("W1NDUCBleGNoYW5nZV0g")) + player.Nickname + Encoding.UTF8.GetString(Convert.FromBase64String("IGxlZnQgYXMg")) + ((object)t526f6c6553746174653a.Role/*cast due to .constrained prefix*/).ToString() + Encoding.UTF8.GetString(Convert.FromBase64String("OyB2YWNhbmN5IG9wZW5lZC4=")));
			}
		}
	}

	private void _m153408352f343e092e3b282e3f3e606a()
	{
		_m19363f3b28092e3b2e3f606a();
		_f28352f343e092e3b282e3f3e1b2e606a = Time.realtimeSinceStartup;
		_m083f3c283f29321b36361233342e29606a();
	}

	private void _m615d6ff1f188485b(RoundEndedEventArgs ev)
	{
		_m153408352f343e083f293f2e606a();
	}

	private void _m153408352f343e083f293f2e606a()
	{
		_m19363f3b28092e3b2e3f606a();
		_m19363f3b281b36361233342e29606a();
	}

	private void _m0939323f3e2f363f083f2b2f3f292e1f222a33283b2e333534606a(int requestGeneration, float expiresAt)
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		Timing.CallDelayed(Math.Max(0f, expiresAt - Time.realtimeSinceStartup), (Action)delegate
		{
			if (_f7dbe8c87f6ac77c2 && _fcdaa1f12e04059af != null && _fcdaa1f12e04059af.Generation == requestGeneration)
			{
				_fcdaa1f12e04059af = null;
				_m083f3c283f29321b36361233342e29606a();
			}
		});
	}

	private void _maMXoTAYVsDVJ(RoleTypeId role, int vacancyGeneration)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		Timing.CallDelayed(120f, (Action)delegate
		{
			//IL_0019: Unknown result type (might be due to invalid IL or missing references)
			//IL_0042: Unknown result type (might be due to invalid IL or missing references)
			if (_f7dbe8c87f6ac77c2 && _f766163616e636965733a300.TryGetValue(role, out var value) && value.Generation == vacancyGeneration)
			{
				_f766163616e636965733a300.Remove(role);
				_m083f3c283f29321b36361233342e29606a();
			}
		});
	}

	private void _m4578706972655374616c6553746174653a300()
	{
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		float now = Time.realtimeSinceStartup;
		if (_fcdaa1f12e04059af != null && _fcdaa1f12e04059af.ExpiresAt <= now)
		{
			_fcdaa1f12e04059af = null;
		}
		foreach (RoleTypeId item in (from item in _f766163616e636965733a300
			where item.Value.ExpiresAt <= now
			select item.Key).ToList())
		{
			_f766163616e636965733a300.Remove(item);
		}
	}

	private void _m193635293f1f2239323b343d3f083f2b2f3f292e606a()
	{
		_fcdaa1f12e04059af = null;
		_m083f3c283f29321b36361233342e29606a();
	}

	private bool _mxRzixtBXSAUb(float seconds)
	{
		if (Round.IsStarted && !Round.IsEnded && _f28352f343e092e3b282e3f3e1b2e606a > 0f)
		{
			return Time.realtimeSinceStartup - _f28352f343e092e3b282e3f3e1b2e606a <= seconds;
		}
		return false;
	}

	private float _m47657445786368616e6765526571756573744578706972793a300()
	{
		return Math.Min(Time.realtimeSinceStartup + 120f, _f28352f343e092e3b282e3f3e1b2e606a + 180f);
	}

	private static void _m381fed3f9c325f90(Player first, Player second)
	{
		_t526f6c6553746174653a300 state = _t526f6c6553746174653a300.Capture(first);
		_t526f6c6553746174653a300 state2 = _t526f6c6553746174653a300.Capture(second);
		_me7e18252167f1765(first, state2, restorePosition: false);
		_me7e18252167f1765(second, state, restorePosition: false);
	}

	private static void _me7e18252167f1765(Player player, _t526f6c6553746174653a300 state, bool restorePosition)
	{
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		player.Role.Set(state.Role, (SpawnReason)7, (RoleSpawnFlags)3);
		Action action = delegate
		{
			//IL_0020: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
			if (player != null && player.IsConnected && player.Role.Type == state.Role)
			{
				player.MaxHealth = Math.Max(player.MaxHealth, state.Health);
				player.Health = Math.Min(player.MaxHealth, state.Health);
				player.HumeShield = state.HumeShield;
				if (restorePosition)
				{
					player.Position = state.Position;
				}
			}
		};
		action();
		Timing.CallDelayed(0f, action);
	}

	private static Player _m825e9ed5a8fc5f8b(RoleTypeId role)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return Player.List.FirstOrDefault((Player player) => player != null && player.IsAlive && player.Role.Type == role);
	}

	private static bool _mde5a5e85afa09d64(string value, out RoleTypeId role)
	{
		role = (RoleTypeId)(-1);
		if (string.IsNullOrWhiteSpace(value))
		{
			return false;
		}
		string text = value.Trim().Replace(Encoding.UTF8.GetString(Convert.FromBase64String("LQ==")), string.Empty);
		if (!text.StartsWith(Encoding.UTF8.GetString(Convert.FromBase64String("U2Nw")), StringComparison.OrdinalIgnoreCase))
		{
			text = Encoding.UTF8.GetString(Convert.FromBase64String("U2Nw")) + text;
		}
		if (Enum.TryParse<RoleTypeId>(text, ignoreCase: true, out role))
		{
			return _mlbQSKEFtybzL(role);
		}
		return false;
	}

	private static bool _mlbQSKEFtybzL(RoleTypeId role)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Expected I4, but got Unknown
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Invalid comparison between Unknown and I4
		switch ((int)role)
		{
		default:
			if ((int)role != 16)
			{
				break;
			}
			goto case 0;
		case 0:
		case 3:
		case 5:
		case 7:
		case 9:
		case 10:
			return true;
		case 1:
		case 2:
		case 4:
		case 6:
		case 8:
			break;
		}
		return false;
	}

	private static string _m4275696c64526f6c655461626c653a300(string command)
	{
		RoleTypeId[] source = Enum.GetValues(typeof(RoleTypeId)).Cast<RoleTypeId>().Where(_mlbQSKEFtybzL)
			.OrderBy(_mWKPddarPEbxN)
			.ToArray();
		return Encoding.UTF8.GetString(Convert.FromBase64String("U0NQIOS7o+eggeWvueeFp++8iOagvOW8j++8mg==")) + command + Encoding.UTF8.GetString(Convert.FromBase64String("IOS7o+egge+8ie+8mg==")) + string.Join(Encoding.UTF8.GetString(Convert.FromBase64String("44CB")), source.Select((RoleTypeId role) => _mWKPddarPEbxN(role).Replace(Encoding.UTF8.GetString(Convert.FromBase64String("U0NQLQ==")), string.Empty)));
	}

	private unsafe static string _mWKPddarPEbxN(RoleTypeId role)
	{
		return ((object)(*(RoleTypeId*)(&role))/*cast due to .constrained prefix*/).ToString().Replace(Encoding.UTF8.GetString(Convert.FromBase64String("U2Nw")), Encoding.UTF8.GetString(Convert.FromBase64String("U0NQLQ==")));
	}

	private void _m083f3c283f29321b36361233342e29606a()
	{
		foreach (Player item in Player.List.ToList())
		{
			_m5265667265736848696e743a300(item);
		}
	}

	private void _m5265667265736848696e743a300(Player player)
	{
		if (player != null && !(player.ReferenceHub == (ReferenceHub)null) && player.IsConnected)
		{
			DisplayCore.Get(player).SetElementOrNew(_fAZFIKoUXyvTE, _m182f33363e1233342e606a(player), 800f);
		}
	}

	private string _m182f33363e1233342e606a(Player viewer)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0139: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0109: Unknown result type (might be due to invalid IL or missing references)
		//IL_0161: Unknown result type (might be due to invalid IL or missing references)
		List<string> list = new List<string>();
		if (_f766163616e636965733a300.Count > 0)
		{
			if ((int)viewer.Role.Team != 0)
			{
			}
			string text = string.Join(Encoding.UTF8.GetString(Convert.FromBase64String("44CB")), from item in _f766163616e636965733a300.Values
				orderby item.Sequence
				select _mWKPddarPEbxN(item.State.Role));
			list.Add(Encoding.UTF8.GetString(Convert.FromBase64String("PGFsaWduPWNlbnRlcj48c2l6ZT0yNj48Y29sb3I9I0ZGNkI2Qj7lvoXooaXkvY3vvJo=")) + text + Encoding.UTF8.GetString(Convert.FromBase64String("PC9jb2xvcj4gIDxjb2xvcj0jRkZGRkZGPi5zY3BhIOiHquWKqOeUs+ivtzwvY29sb3I+PC9zaXplPjwvYWxpZ24+")));
		}
		_tb5698684f40e40d1 fcdaa1f12e04059af = _fcdaa1f12e04059af;
		if (fcdaa1f12e04059af != null)
		{
		}
		Player val = Player.Get(fcdaa1f12e04059af.InitiatorPlayerId);
		if (val != null)
		{
		}
		if (val.IsAlive)
		{
		}
		if (fcdaa1f12e04059af.IsPublic)
		{
			list.Add(Encoding.UTF8.GetString(Convert.FromBase64String("PGFsaWduPWNlbnRlcj48c2l6ZT0yNj48Y29sb3I9IzdGREJGRj4=")) + _mWKPddarPEbxN(val.Role.Type) + Encoding.UTF8.GetString(Convert.FromBase64String("IOWFrOW8gOS6pOaNojwvY29sb3I+ICA8Y29sb3I9I0ZGRkZGRj4uc2NwYSDlkIzmhI88L2NvbG9yPjwvc2l6ZT48L2FsaWduPg==")));
		}
		if (viewer.Role.Type == fcdaa1f12e04059af.TargetRole)
		{
		}
		list.Add(Encoding.UTF8.GetString(Convert.FromBase64String("PGFsaWduPWNlbnRlcj48c2l6ZT0yNj48Y29sb3I9IzdGREJGRj4=")) + _mWKPddarPEbxN(val.Role.Type) + Encoding.UTF8.GetString(Convert.FromBase64String("IOivt+axguS4juS9oOWGhemDqOS6pOaNojwvY29sb3I+ICA8Y29sb3I9I0ZGRkZGRj4uc2NwYSDlkIzmhI88L2NvbG9yPjwvc2l6ZT48L2FsaWduPg==")));
		return string.Join(Encoding.UTF8.GetString(Convert.FromBase64String("Cg==")), list);
	}

	private void _m19363f3b281b36361233342e29606a()
	{
		foreach (Player item in Player.List.ToList())
		{
			if (((item != null) ? item.ReferenceHub : null) != (ReferenceHub)null)
			{
				DisplayCore.Get(item).SetElementOrNew(_fAZFIKoUXyvTE, string.Empty, 800f);
			}
		}
	}

	private void _m19363f3b28092e3b2e3f606a()
	{
		_fb533f052d7522541++;
		_f766163616e637953657175656e63653a300 = 0L;
		_fcdaa1f12e04059af = null;
		_f766163616e636965733a300.Clear();
		_fDhJMNsoxfZaO.Clear();
		_f28352f343e092e3b282e3f3e1b2e606a = 0f;
	}
}
