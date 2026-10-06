using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Core;
using Exiled.API.Features.Roles;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using Exiled.Events.Handlers;
using PlayerRoles;
using PlayerRoles.Spectating;
using PlayerStatsSystem;
using Respawning;
using RueI.Displays;
using RueI.Displays.Scheduling;
using RueI.Elements;
using RueI.Extensions;
using UnityEngine;
using _n4361726c6672656c6c6574740;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class PlayerInformationHint
{
	private enum _t48696e74416c69676e6d656e743a300
	{
		Left,
		Center,
		Right
	}

	private sealed class _t506c61796572446973706c617953746174653a300
	{
		public readonly Player Player;

		public readonly ReferenceHub Hub;

		public readonly string UserId;

		public readonly Action RefreshAction;

		public readonly string[] ObserverLines = new string[5];

		public readonly string[] HumanLines = new string[10];

		public readonly string[] ScpLines = new string[16];

		public string PlayerStatus;

		public _t506c61796572446973706c617953746174653a300(Player player, Action refreshAction)
		{
			Player = player;
			Hub = player.ReferenceHub;
			UserId = player.UserId;
			RefreshAction = refreshAction;
		}
	}

	private readonly struct _t526f6c65446973706c61793a300
	{
		public string Name { get; }

		public string Color { get; }

		public _t526f6c65446973706c61793a300(string name, string color)
		{
			_f3c4e616d653e6b5f5f4261636b696e674669656c643a300 = name;
			_f94edfa0a45a8ceea = color;
		}
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _t666439606a
	{
		public static readonly _t666439606a _003C_003E9 = new _t666439606a();

		public static Func<Player, bool> _003C_003E9__57_0;

		internal bool _m66182f33363e0a363b233f28092e3b2e2f29643805056f6d056a606a(Player spectator)
		{
			return spectator != null;
		}
	}

	private const int _f1538293f282c3f281633343f19352f342e606a = 5;

	private const int _f122f373b341633343f193b2a3b39332e23606a = 10;

	private const int _f5363704c696e6543617061636974793a300 = 16;

	private const float _fsjiqTYgBosXE = 500f;

	private const string _f50616e656c506f735461673a300 = "<pos=-350>";

	private const float _f122f373b340a3529332e333534606a = 500f;

	private const float _f122f373b341633343f153c3c293f2e606a = 32f;

	private const float _f09392a0a3529332e333534606a = 500f;

	private const float _figmxTpswFUTI = 64f;

	private const float _f1538293f282c3f2819352f342e3e352d340a3529332e333534606a = 300f;

	private const float _f1538293f282c3f280e3f3b370a3529332e333534606a = 270f;

	private const float _fkvhpgRCVBbup = 240f;

	private const float _f4f627365727665724368616f73566f746573506f736974696f6e3a300 = 210f;

	private const float _f1538293f282c3f281c35352e3f280a3529332e333534606a = 8f;

	private const float _f68eb9a3035b45e6b = 0f;

	private const string _fwKtOKPVWyFjt = "<align=center><size=30><color=#FF8FAB>梦时镜</color><color=#FFFFFF>*</color><color=#7FDBFF>鸟之诗</color> <color=#F6C445>怀旧服</color></size></align>";

	private static readonly IElemReference<SetElement>[] _f1538293f282c3f28083f3c29606a = _mWGbVsEQnEaqu(5);

	private static readonly IElemReference<SetElement>[] _f48756d616e526566733a300 = _mWGbVsEQnEaqu(10);

	private static readonly IElemReference<SetElement>[] _f85483bcdf4ec696f = _mWGbVsEQnEaqu(16);

	private static readonly IElemReference<SetElement> _f506c617965725374617475735265663a300 = DisplayCore.GetReference<SetElement>();

	private static MethodInfo _f707562675465616d6d617465496e666f726d6174696f6e4d6574686f643a300;

	private readonly Plugin _f2a362f3d3334606a;

	private readonly JobToken _f89eeb4733e4734a2 = new JobToken();

	private readonly Dictionary<int, _t506c61796572446973706c617953746174653a300> _f2a363b233f28092e3b2e3f29606a = new Dictionary<int, _t506c61796572446973706c617953746174653a300>();

	private readonly Dictionary<RoleTypeId, int> _f3b36332c3f0835363f19352f342e29606a = new Dictionary<RoleTypeId, int>();

	private readonly List<Player> _fdde95a75e12b222b = new List<Player>(8);

	private bool _f6973526f756e644163746976653a300;

	private bool _f29343b2a2932352e1e33282e23606a = true;

	private long _f7f200bec1eacd181;

	public PlayerInformationHint(Plugin plugin)
	{
		_f2a362f3d3334606a = plugin;
	}

	public void Enable()
	{
		Player.Verified += _m7d182fe7c224cf26;
		Player.Left += _m5895ad191abbde9b;
		Player.Died += _m4f6e446965643a300;
		Player.ChangingRole += _m4f6e4368616e67696e67526f6c653a300;
		Server.RoundStarted += _m153408352f343e092e3b282e3f3e606a;
		Server.RoundEnded += _m4f6e526f756e64456e6465643a300;
		Server.WaitingForPlayers += _mJpBZMQMpjKxL;
		Server.RestartingRound += _m1534083f292e3b282e33343d08352f343e606a;
		_f6973526f756e644163746976653a300 = Round.IsStarted && Round.InProgress && !Round.IsEnded;
		_m4d61726b536e617073686f7444697274793a300();
		if (_f6973526f756e644163746976653a300)
		{
			_m083f3c283f29321b36360a363b233f2829606a();
		}
	}

	public void Disable()
	{
		Player.Verified -= _m7d182fe7c224cf26;
		Player.Left -= _m5895ad191abbde9b;
		Player.Died -= _m4f6e446965643a300;
		Player.ChangingRole -= _m4f6e4368616e67696e67526f6c653a300;
		Server.RoundStarted -= _m153408352f343e092e3b282e3f3e606a;
		Server.RoundEnded -= _m4f6e526f756e64456e6465643a300;
		Server.WaitingForPlayers -= _mJpBZMQMpjKxL;
		Server.RestartingRound -= _m1534083f292e3b282e33343d08352f343e606a;
		_m092e352a606a();
	}

	private void _m7d182fe7c224cf26(VerifiedEventArgs ev)
	{
		_m4d61726b536e617073686f7444697274793a300();
		if (_mfBLDPETZSjpb() && ev.Player != null)
		{
			_m083f3c283f29320a363b233f28606a(ev.Player);
		}
	}

	private void _m5895ad191abbde9b(LeftEventArgs ev)
	{
		if (ev.Player != null)
		{
			_m19363f3b280a363b233f28606a(ev.Player, ev.Player.ReferenceHub);
		}
		_m4d61726b536e617073686f7444697274793a300();
	}

	private void _m4f6e446965643a300(DiedEventArgs ev)
	{
		_m4d61726b536e617073686f7444697274793a300();
		if (_mfBLDPETZSjpb() && ev.Player != null)
		{
			_m083f3c283f29320a363b233f28606a(ev.Player);
		}
	}

	private void _m4f6e4368616e67696e67526f6c653a300(ChangingRoleEventArgs ev)
	{
		_m4d61726b536e617073686f7444697274793a300();
		if (ev != null && ev.Player != null && _f2a363b233f28092e3b2e3f29606a.TryGetValue(ev.Player.Id, out var value) && value.Hub == ev.Player.ReferenceHub)
		{
			_m083f3c283f29320a363b233f28606a(ev.Player);
		}
	}

	private void _m153408352f343e092e3b282e3f3e606a()
	{
		_f6973526f756e644163746976653a300 = true;
		_m4d61726b536e617073686f7444697274793a300();
		_m083f3c283f29321b36360a363b233f2829606a();
	}

	private void _m4f6e526f756e64456e6465643a300(RoundEndedEventArgs ev)
	{
		_m092e352a606a();
	}

	private void _mJpBZMQMpjKxL()
	{
		_m092e352a606a();
	}

	private void _m1534083f292e3b282e33343d08352f343e606a()
	{
		_m092e352a606a();
	}

	private void _m083f3c283f29321b36360a363b233f2829606a()
	{
		foreach (Player item in Player.List)
		{
			if (_tFpYLlGZVhITT.IsGameplayPlayer(item))
			{
				_m083f3c283f29320a363b233f28606a(item);
			}
		}
	}

	private void _m083f3c283f29320a363b233f28606a(Player player)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Invalid comparison between Unknown and I4
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Invalid comparison between Unknown and I4
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Invalid comparison between Unknown and I4
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		if (!_tFpYLlGZVhITT.IsGameplayPlayer(player))
		{
			_m19363f3b280a363b233f28606a(player, player.ReferenceHub);
			return;
		}
		if (player.ReferenceHub == (ReferenceHub)null)
		{
			_f2a363b233f28092e3b2e3f29606a.Remove(player.Id);
			return;
		}
		_t506c61796572446973706c617953746174653a300 t506c61796572446973706c617953746174653a = _m1d3f2e152819283f3b2e3f092e3b2e3f606a(player);
		DisplayCore displayCore = DisplayCore.Get(player);
		if (!_mfBLDPETZSjpb())
		{
			_mbb25e63f765cc8fe(player);
			return;
		}
		displayCore.Scheduler.ReplaceJob(TimeSpan.FromSeconds(_mLsDmXXlwHShi()), t506c61796572446973706c617953746174653a.RefreshAction, _f89eeb4733e4734a2);
		_m456e73757265536e617073686f743a300();
		RoleTypeId val = _m476574526f6c65547970653a300(player);
		bool flag = CustomRoleSystem._mLGNqWDwdPFOO(player);
		bool flag2;
		if (player.Role == (Role)null || (int)val == -1 || ((int)val == 14 && !flag))
		{
			flag2 = _mbc96164ec9e3958e(displayCore, t506c61796572446973706c617953746174653a);
		}
		else if ((int)val == 2 || player.IsDead)
		{
			flag2 = _m5570646174654f627365727665723a300(displayCore, t506c61796572446973706c617953746174653a);
			flag2 |= _mnbVXVvkJyQDE(displayCore, t506c61796572446973706c617953746174653a);
			flag2 |= _m436c6561725363704c696e65733a300(displayCore, t506c61796572446973706c617953746174653a);
		}
		else if ((int)CustomRoleSystem._md6a40e4754499fc2(player) == 0)
		{
			flag2 = _m19363f3b281538293f282c3f281633343f29606a(displayCore, t506c61796572446973706c617953746174653a);
			flag2 |= _mnbVXVvkJyQDE(displayCore, t506c61796572446973706c617953746174653a);
			flag2 |= _m0f2a3e3b2e3f09392a606a(displayCore, t506c61796572446973706c617953746174653a, player);
		}
		else if (player.IsHuman)
		{
			flag2 = _m19363f3b281538293f282c3f281633343f29606a(displayCore, t506c61796572446973706c617953746174653a);
			flag2 |= _m1ef13f7776a6b2c3(displayCore, t506c61796572446973706c617953746174653a, player);
			flag2 |= _m436c6561725363704c696e65733a300(displayCore, t506c61796572446973706c617953746174653a);
		}
		else
		{
			flag2 = _mbc96164ec9e3958e(displayCore, t506c61796572446973706c617953746174653a);
		}
		if (flag2 | _m0f2a3e3b2e3f0a363b233f28092e3b2e2f29606a(displayCore, t506c61796572446973706c617953746174653a, player))
		{
			displayCore.Update();
		}
	}

	private _t506c61796572446973706c617953746174653a300 _m1d3f2e152819283f3b2e3f092e3b2e3f606a(Player player)
	{
		if (_f2a363b233f28092e3b2e3f29606a.TryGetValue(player.Id, out var value) && value.Hub == player.ReferenceHub && string.Equals(value.UserId, player.UserId, StringComparison.OrdinalIgnoreCase))
		{
			return value;
		}
		if (value != null)
		{
			_m436c65617253746174653a300(value);
			_f2a363b233f28092e3b2e3f29606a.Remove(player.Id);
		}
		ReferenceHub expectedHub = player.ReferenceHub;
		string expectedUserId = player.UserId;
		value = new _t506c61796572446973706c617953746174653a300(player, delegate
		{
			if (_tFpYLlGZVhITT.IsSameSession(player, expectedHub, expectedUserId))
			{
				if (_mfBLDPETZSjpb())
				{
					_m083f3c283f29320a363b233f28606a(player);
				}
				else
				{
					_m19363f3b280a363b233f28606a(player, expectedHub);
				}
			}
		});
		_f2a363b233f28092e3b2e3f29606a[player.Id] = value;
		return value;
	}

	private void _m092e352a606a()
	{
		_f6973526f756e644163746976653a300 = false;
		foreach (Player item in Player.List)
		{
			_mbb25e63f765cc8fe(item);
		}
		_f2a363b233f28092e3b2e3f29606a.Clear();
		_f3b36332c3f0835363f19352f342e29606a.Clear();
		_fdde95a75e12b222b.Clear();
		_m4d61726b536e617073686f7444697274793a300();
	}

	private void _mbb25e63f765cc8fe(Player player)
	{
		_m19363f3b280a363b233f28606a(player, null);
	}

	private void _m19363f3b280a363b233f28606a(Player player, ReferenceHub expectedHub)
	{
		if (player == null || !_f2a363b233f28092e3b2e3f29606a.TryGetValue(player.Id, out var value) || (expectedHub != (ReferenceHub)null && value.Hub != expectedHub))
		{
			return;
		}
		if (value.Hub != (ReferenceHub)null)
		{
			DisplayCore displayCore = DisplayCore.Get(value.Player);
			displayCore.Scheduler.KillJob(_f89eeb4733e4734a2);
			if (_mbc96164ec9e3958e(displayCore, value))
			{
				displayCore.Update();
			}
		}
		_f2a363b233f28092e3b2e3f29606a.Remove(player.Id);
	}

	private void _m436c65617253746174653a300(_t506c61796572446973706c617953746174653a300 state)
	{
		if (state != null && !(state.Hub == (ReferenceHub)null) && !((Object)(object)((Component)state.Hub).gameObject == (Object)null))
		{
			DisplayCore displayCore = DisplayCore.Get(state.Player);
			displayCore.Scheduler.KillJob(_f89eeb4733e4734a2);
			if (_mbc96164ec9e3958e(displayCore, state))
			{
				displayCore.Update();
			}
		}
	}

	private bool _mfBLDPETZSjpb()
	{
		if (_f6973526f756e644163746976653a300 && Round.IsStarted && Round.InProgress && !Round.IsEnded)
		{
			return !_mdYqlSUEHLmaD();
		}
		return false;
	}

	private static bool _mdYqlSUEHLmaD()
	{
		return MusicBoxSystem.Instance?.IsPlaying ?? false;
	}

	private void _m4d61726b536e617073686f7444697274793a300()
	{
		_f29343b2a2932352e1e33282e23606a = true;
		_f7f200bec1eacd181 = 0L;
	}

	private void _m456e73757265536e617073686f743a300()
	{
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Invalid comparison between Unknown and I4
		long ticks = DateTime.UtcNow.Ticks;
		if (!_f29343b2a2932352e1e33282e23606a && ticks < _f7f200bec1eacd181)
		{
			return;
		}
		_f29343b2a2932352e1e33282e23606a = false;
		_f7f200bec1eacd181 = ticks + TimeSpan.FromSeconds(_mLsDmXXlwHShi()).Ticks;
		_f3b36332c3f0835363f19352f342e29606a.Clear();
		_fdde95a75e12b222b.Clear();
		HashSet<int> hashSet = new HashSet<int>();
		foreach (Player item in Player.List)
		{
			if (_tFpYLlGZVhITT.IsGameplayPlayer(item) && !(item.Role == (Role)null) && item.IsAlive && hashSet.Add(item.Id))
			{
				RoleTypeId val = _m476574526f6c65547970653a300(item);
				_f3b36332c3f0835363f19352f342e29606a.TryGetValue(val, out var value);
				_f3b36332c3f0835363f19352f342e29606a[val] = value + 1;
				if ((int)CustomRoleSystem._md6a40e4754499fc2(item) == 0 && (int)val != 10)
				{
					_fdde95a75e12b222b.Add(item);
				}
			}
		}
		_fdde95a75e12b222b.Sort(_mdfe002fd9b50ca48);
	}

	private static int _mdfe002fd9b50ca48(Player left, Player right)
	{
		int num = _m476574536370536f72744f726465723a300(left).CompareTo(_m476574536370536f72744f726465723a300(right));
		if (num != 0)
		{
			return num;
		}
		return string.Compare(_m1d3f2e09392a1e33292a363b23143b373f606a(left), _m1d3f2e09392a1e33292a363b23143b373f606a(right), StringComparison.Ordinal);
	}

	private static int _md049df2d0b7679a0(Player left, Player right)
	{
		return string.Compare((left == null) ? string.Empty : left.Nickname, (right == null) ? string.Empty : right.Nickname, StringComparison.Ordinal);
	}

	private bool _m5570646174654f627365727665723a300(DisplayCore core, _t506c61796572446973706c617953746174653a300 state)
	{
		TimeSpan timeUntilSpawnWave;
		do
		{
			timeUntilSpawnWave = Respawn.TimeUntilSpawnWave;
		}
		while (!(timeUntilSpawnWave < TimeSpan.Zero));
		timeUntilSpawnWave = TimeSpan.Zero;
		string text = string.Format(Encoding.UTF8.GetString(Convert.FromBase64String("PGNvbG9yPSNGRkQxNjY+PGI+ezB9PC9iPjwvY29sb3I+PGNvbG9yPSNGRkYwQjM+5YiGPC9jb2xvcj48Y29sb3I9IzdGREJGRj48Yj57MX08L2I+PC9jb2xvcj48Y29sb3I9I0Q2RjBGRj7np5I8L2NvbG9yPg==")), (int)timeUntilSpawnWave.TotalMinutes, timeUntilSpawnWave.Seconds);
		return (byte)(0u | (_mYnwxzoTYGRJZ(core, state.ObserverLines, _f1538293f282c3f28083f3c29606a, 0, _msaEwpvegVCGM(_t48696e74416c69676e6d656e743a300.Center, Encoding.UTF8.GetString(Convert.FromBase64String("PGNvbG9yPSNGOEY5RkE+5L2g5bCG5ZyoPC9jb2xvcj4g")) + text + Encoding.UTF8.GetString(Convert.FromBase64String("IDxjb2xvcj0jRjhGOUZBPuWQjumHjeeUn+S4ujwvY29sb3I+"))), 300f) ? 1u : 0u) | (_mYnwxzoTYGRJZ(core, state.ObserverLines, _f1538293f282c3f28083f3c29606a, 1, _msaEwpvegVCGM(_t48696e74416c69676e6d656e743a300.Center, _m4765744e6578745265737061776e546578743a300()), 270f) ? 1u : 0u) | (_mYnwxzoTYGRJZ(core, state.ObserverLines, _f1538293f282c3f28083f3c29606a, 2, _msaEwpvegVCGM(_t48696e74416c69676e6d656e743a300.Left, Encoding.UTF8.GetString(Convert.FromBase64String("PGNvbG9yPWJsdWU+5Lmd5bC+54uQ56Wo5pWwPC9jb2xvcj46IDxjb2xvcj0jRUFGNkZGPjxiPg==")) + (int)Respawn.NtfTickets + Encoding.UTF8.GetString(Convert.FromBase64String("PC9iPjwvY29sb3I+"))), 240f) ? 1u : 0u) | (_mYnwxzoTYGRJZ(core, state.ObserverLines, _f1538293f282c3f28083f3c29606a, 3, _msaEwpvegVCGM(_t48696e74416c69676e6d656e743a300.Left, Encoding.UTF8.GetString(Convert.FromBase64String("PGNvbG9yPWdyZWVuPua3t+ayjOWIhuijguiAheelqOaVsDwvY29sb3I+OiA8Y29sb3I9I0YyRkZGMj48Yj4=")) + (int)Respawn.ChaosTickets + Encoding.UTF8.GetString(Convert.FromBase64String("PC9iPjwvY29sb3I+"))), 210f) ? 1u : 0u) | (_mYnwxzoTYGRJZ(core, state.ObserverLines, _f1538293f282c3f28083f3c29606a, 4, string.Empty, 8f) ? 1u : 0u)) != 0;
	}

	private bool _m0f2a3e3b2e3f0a363b233f28092e3b2e2f29606a(DisplayCore core, _t506c61796572446973706c617953746174653a300 state, Player player)
	{
		string text = _mmSFZsiCWFAtX(player);
		if (string.Equals(state.PlayerStatus, text, StringComparison.Ordinal))
		{
			return false;
		}
		state.PlayerStatus = text;
		core.SetElementOrNew(_f506c617965725374617475735265663a300, text, 0f);
		return true;
	}

	private static string _mmSFZsiCWFAtX(Player player)
	{
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Invalid comparison between Unknown and I4
		if (player == null)
		{
			return string.Empty;
		}
		if (!ExperienceSystem.TryGetPlayerLevel(player, out var level))
		{
			level = 0;
		}
		int uid;
		string text = (ExperienceSystem.TryGetPlayerUid(player, out uid) ? uid.ToString() : Encoding.UTF8.GetString(Convert.FromBase64String("LS0=")));
		if (player.Role != (Role)null && ((int)player.Role.Type == 2 || player.IsDead))
		{
			Player val = _m0e28231d3f2e092a3f392e3b2e35280e3b283d3f2e606a(player);
			if (val == null)
			{
				return _mOJnbMNTSTUVY(_t48696e74416c69676e6d656e743a300.Center, Encoding.UTF8.GetString(Convert.FromBase64String("PGNvbG9yPSNFQUY2RkY+VUlEOiA=")) + text + Encoding.UTF8.GetString(Convert.FromBase64String("PC9jb2xvcj4gfCBMdi4=")) + level + Encoding.UTF8.GetString(Convert.FromBase64String("IHwgPGNvbG9yPSNCOEM0RDY+5L2g5b2T5YmN5rKh5pyJ6KeC5oiY55uu5qCHPC9jb2xvcj4=")));
			}
			int num = val.CurrentSpectatingPlayers.Count((Player spectator) => spectator != null);
			string text2 = _m1f29393b2a3f083339320e3f222e606a(val.Nickname);
			return _mOJnbMNTSTUVY(_t48696e74416c69676e6d656e743a300.Center, Encoding.UTF8.GetString(Convert.FromBase64String("PGNvbG9yPSNFQUY2RkY+VUlEOiA=")) + text + Encoding.UTF8.GetString(Convert.FromBase64String("PC9jb2xvcj4gfCBMdi4=")) + level + Encoding.UTF8.GetString(Convert.FromBase64String("IHwgPGNvbG9yPSNGRkQxNjY+5L2g5q2j5Zyo6KeC5oiY77yaPC9jb2xvcj48Y29sb3I9IzdGREJGRj4=")) + text2 + Encoding.UTF8.GetString(Convert.FromBase64String("PC9jb2xvcj4gfCA8Y29sb3I9I0I4QzRENj7lvZPliY3mnIk=")) + num + Encoding.UTF8.GetString(Convert.FromBase64String("5ZCN546p5a625q2j5Zyo6KeC5oiY5a6DPC9jb2xvcj4=")));
		}
		_t526f6c65446973706c61793a300 t526f6c65446973706c61793a = _m1d3f2e0835363f1e33292a363b23606a(player);
		return _mOJnbMNTSTUVY(_t48696e74416c69676e6d656e743a300.Center, Encoding.UTF8.GetString(Convert.FromBase64String("PGNvbG9yPSNFQUY2RkY+VUlEOiA=")) + text + Encoding.UTF8.GetString(Convert.FromBase64String("PC9jb2xvcj4gfCBMdi4=")) + level + Encoding.UTF8.GetString(Convert.FromBase64String("IHwgPGNvbG9yPQ==")) + t526f6c65446973706c61793a.Color + Encoding.UTF8.GetString(Convert.FromBase64String("Pg==")) + t526f6c65446973706c61793a.Name + Encoding.UTF8.GetString(Convert.FromBase64String("PC9jb2xvcj4=")));
	}

	private static Player _m0e28231d3f2e092a3f392e3b2e35280e3b283d3f2e606a(Player spectator)
	{
		object obj;
		if (spectator == null)
		{
			obj = null;
		}
		else
		{
			ReferenceHub referenceHub = spectator.ReferenceHub;
			if (referenceHub == null)
			{
				obj = null;
			}
			else
			{
				PlayerRoleManager roleManager = referenceHub.roleManager;
				obj = ((roleManager != null) ? roleManager.CurrentRole : null);
			}
		}
		SpectatorRole val = (SpectatorRole)((obj is SpectatorRole) ? obj : null);
		ReferenceHub val2 = default(ReferenceHub);
		if (!((Object)(object)val != (Object)null) || !ReferenceHub.TryGetHubNetID(val.SyncedSpectatedNetId, ref val2))
		{
			return null;
		}
		return Player.Get(val2);
	}

	private unsafe static _t526f6c65446973706c61793a300 _m1d3f2e0835363f1e33292a363b23606a(Player player)
	{
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cd: Expected I4, but got Unknown
		//IL_02a2: Unknown result type (might be due to invalid IL or missing references)
		while (true)
		{
			if (CustomRoleSystem._mqUKYWxagClXy(player))
			{
				return new _t526f6c65446973706c61793a300(Encoding.UTF8.GetString(Convert.FromBase64String("U0NQLTA3Mw==")), Encoding.UTF8.GetString(Convert.FromBase64String("I0ZGNTU1NQ==")));
			}
			if (CustomRoleSystem._mLGNqWDwdPFOO(player))
			{
				break;
			}
			RoleTypeId val = _m476574526f6c65547970653a300(player);
			switch ((int)val)
			{
			case 0:
			case 1:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 15:
			case 16:
			case 18:
			case 19:
			case 20:
				continue;
			}
			string name = ((object)(*(RoleTypeId*)(&val))/*cast due to .constrained prefix*/).ToString();
			return new _t526f6c65446973706c61793a300(name, Encoding.UTF8.GetString(Convert.FromBase64String("Iw==")) + ColorUtility.ToHtmlStringRGB(player.Role.Color));
		}
		return new _t526f6c65446973706c61793a300(Encoding.UTF8.GetString(Convert.FromBase64String("U0NQLTU1MA==")), Encoding.UTF8.GetString(Convert.FromBase64String("I0ZGNTU1NQ==")));
	}

	private bool _m1ef13f7776a6b2c3(DisplayCore core, _t506c61796572446973706c617953746174653a300 state, Player viewer)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Invalid comparison between Unknown and I4
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Invalid comparison between Unknown and I4
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c4: Invalid comparison between Unknown and I4
		//IL_01c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c8: Invalid comparison between Unknown and I4
		if (_mMUWOeVBvhKNI(viewer, out var lines))
		{
			return _mLjrvZVIQIbHq(core, state, lines);
		}
		int num = 0;
		Team team = viewer.Role.Team;
		float num2 = _ma0d3865062047cc1(_m1d3f2e122f373b340a3b343f36132e3f3719352f342e606a(team), 32f);
		bool flag = _mYnwxzoTYGRJZ(core, state.HumanLines, _f48756d616e526566733a300, num, _m86f4136fba95b7c8(Encoding.UTF8.GetString(Convert.FromBase64String("IzdGREJGRg==")), Encoding.UTF8.GetString(Convert.FromBase64String("6Zif5Y+L54q25oCB"))), num2);
		num++;
		if ((int)team == 2 || (int)team == 4)
		{
			flag |= _m81e594398ddea67d(core, state, ref num, num2, Encoding.UTF8.GetString(Convert.FromBase64String("5re35rKM5b6B5Y+s5YW1")), Encoding.UTF8.GetString(Convert.FromBase64String("IzU4RDY4RA==")), _m436f756e74416c6976653a300((RoleTypeId)8));
			flag |= _m81e594398ddea67d(core, state, ref num, num2, Encoding.UTF8.GetString(Convert.FromBase64String("5re35rKM5o6g5aS66ICF")), Encoding.UTF8.GetString(Convert.FromBase64String("IzJFQ0M3MQ==")), _m436f756e74416c6976653a300((RoleTypeId)20));
			flag |= _m81e594398ddea67d(core, state, ref num, num2, Encoding.UTF8.GetString(Convert.FromBase64String("5re35rKM5Y6L5Yi26ICF")), Encoding.UTF8.GetString(Convert.FromBase64String("IzI3QUU2MA==")), _m436f756e74416c6976653a300((RoleTypeId)19));
			flag |= _m81e594398ddea67d(core, state, ref num, num2, Encoding.UTF8.GetString(Convert.FromBase64String("5re35rKM5q2l5p6q5YW1")), Encoding.UTF8.GetString(Convert.FromBase64String("IzgyRTBBQQ==")), _m436f756e74416c6976653a300((RoleTypeId)18));
			flag |= _m81e594398ddea67d(core, state, ref num, num2, Encoding.UTF8.GetString(Convert.FromBase64String("ROe6p+S6uuWRmA==")), Encoding.UTF8.GetString(Convert.FromBase64String("b3Jhbmdl")), _m436f756e74416c6976653a300((RoleTypeId)1));
		}
		else if ((int)team == 1 || (int)team == 3)
		{
			flag |= _m81e594398ddea67d(core, state, ref num, num2, Encoding.UTF8.GetString(Convert.FromBase64String("5Lmd5bC+54uQ5pS25a655LiT5a62")), Encoding.UTF8.GetString(Convert.FromBase64String("IzAwODZFNA==")), _m436f756e74416c6976653a300((RoleTypeId)4));
			flag |= _m81e594398ddea67d(core, state, ref num, num2, Encoding.UTF8.GetString(Convert.FromBase64String("5Lmd5bC+54uQ5YiX5YW1")), Encoding.UTF8.GetString(Convert.FromBase64String("IzYyQUNFMg==")), _m436f756e74416c6976653a300((RoleTypeId)13));
			flag |= _m81e594398ddea67d(core, state, ref num, num2, Encoding.UTF8.GetString(Convert.FromBase64String("5Lmd5bC+54uQ5Lit5aOr")), Encoding.UTF8.GetString(Convert.FromBase64String("IzAwODZFNA==")), _m436f756e74416c6976653a300((RoleTypeId)11));
			flag |= _m81e594398ddea67d(core, state, ref num, num2, Encoding.UTF8.GetString(Convert.FromBase64String("5Lmd5bC+54uQ5oyH5oyl5a6Y")), Encoding.UTF8.GetString(Convert.FromBase64String("Ymx1ZQ==")), _m436f756e74416c6976653a300((RoleTypeId)12));
			flag |= _m81e594398ddea67d(core, state, ref num, num2, Encoding.UTF8.GetString(Convert.FromBase64String("56eR5a2m5a62")), Encoding.UTF8.GetString(Convert.FromBase64String("eWVsbG93")), _m436f756e74416c6976653a300((RoleTypeId)6));
			flag |= _m81e594398ddea67d(core, state, ref num, num2, Encoding.UTF8.GetString(Convert.FromBase64String("6K6+5pa96K2m5Y2r")), Encoding.UTF8.GetString(Convert.FromBase64String("IzVCNjM3MQ==")), _m436f756e74416c6976653a300((RoleTypeId)15));
		}
		return flag | _m19363f3b281633343f291c283537606a(core, state.HumanLines, _f48756d616e526566733a300, num, 10, num2, 32f);
	}

	private static bool _mMUWOeVBvhKNI(Player viewer, out string[] lines)
	{
		lines = null;
		try
		{
			if (_f707562675465616d6d617465496e666f726d6174696f6e4d6574686f643a300 == null)
			{
				Type type = Type.GetType(Encoding.UTF8.GetString(Convert.FromBase64String("QXV0b0V2ZW50LkdhbWVzLlBVQkcuUHViZ0dhbWVNb2RlLCBBdXRvRXZlbnQ=")), throwOnError: false);
				if (type == null)
				{
					return false;
				}
				_f707562675465616d6d617465496e666f726d6174696f6e4d6574686f643a300 = type.GetMethod(Encoding.UTF8.GetString(Convert.FromBase64String("R2V0VGVhbW1hdGVJbmZvcm1hdGlvbg==")), BindingFlags.Static | BindingFlags.Public, null, new Type[1] { typeof(Player) }, null);
			}
			if (_f707562675465616d6d617465496e666f726d6174696f6e4d6574686f643a300 == null)
			{
				return false;
			}
			lines = _f707562675465616d6d617465496e666f726d6174696f6e4d6574686f643a300.Invoke(null, new object[1] { viewer }) as string[];
			return lines != null && lines.Length != 0;
		}
		catch
		{
			lines = null;
			return false;
		}
	}

	private static bool _mLjrvZVIQIbHq(DisplayCore core, _t506c61796572446973706c617953746174653a300 state, string[] teammateLines)
	{
		int num = Math.Min(teammateLines.Length, 9);
		float num2 = _ma0d3865062047cc1(num + 1, 32f);
		bool flag = _mYnwxzoTYGRJZ(core, state.HumanLines, _f48756d616e526566733a300, 0, _m86f4136fba95b7c8(Encoding.UTF8.GetString(Convert.FromBase64String("I0ZGRDY2Ng==")), Encoding.UTF8.GetString(Convert.FromBase64String("UFVCRyDpmJ/lj4vnirbmgIE="))), num2);
		int num3 = 1;
		int num4 = 0;
		while (num4 < num && num3 < 10)
		{
			string content = _msaEwpvegVCGM(_t48696e74416c69676e6d656e743a300.Left, Encoding.UTF8.GetString(Convert.FromBase64String("PHBvcz0tMzUwPjxzaXplPTE4PjxsaW5lLWhlaWdodD0yND4=")) + teammateLines[num4] + Encoding.UTF8.GetString(Convert.FromBase64String("PC9zaXplPg==")));
			flag |= _mYnwxzoTYGRJZ(core, state.HumanLines, _f48756d616e526566733a300, num3, content, num2 - 32f * (float)num3);
			num4++;
			num3++;
		}
		return flag | _m19363f3b281633343f291c283537606a(core, state.HumanLines, _f48756d616e526566733a300, num3, 10, num2, 32f);
	}

	private static bool _m81e594398ddea67d(DisplayCore core, _t506c61796572446973706c617953746174653a300 state, ref int line, float panelPosition, string label, string color, int count)
	{
		if (count <= 0 || line >= 10)
		{
			return false;
		}
		string content = _msaEwpvegVCGM(_t48696e74416c69676e6d656e743a300.Left, Encoding.UTF8.GetString(Convert.FromBase64String("PHBvcz0tMzUwPg==")) + string.Format(Encoding.UTF8.GetString(Convert.FromBase64String("PHNpemU9MTg+PGxpbmUtaGVpZ2h0PTI0Pjxjb2xvcj0jQUFBQUFBPuKXhjwvY29sb3I+IDxjb2xvcj17MH0+ezF9PC9jb2xvcj4gPGNvbG9yPSNBQUFBQUE+OjwvY29sb3I+IDxjb2xvcj13aGl0ZT48Yj57Mn08L2I+IOS6ujwvY29sb3I+PC9zaXplPg==")), color, label, count));
		bool result = _mYnwxzoTYGRJZ(core, state.HumanLines, _f48756d616e526566733a300, line, content, panelPosition - 32f * (float)line);
		line++;
		return result;
	}

	private bool _m0f2a3e3b2e3f09392a606a(DisplayCore core, _t506c61796572446973706c617953746174653a300 state, Player viewer)
	{
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Invalid comparison between Unknown and I4
		int num = 0;
		float num2 = _ma0d3865062047cc1(_m1d3f2e09392a0a3b343f36132e3f3719352f342e606a(), 64f);
		bool flag = _mYnwxzoTYGRJZ(core, state.ScpLines, _f85483bcdf4ec696f, num, _m86f4136fba95b7c8(Encoding.UTF8.GetString(Convert.FromBase64String("I0ZGNTU1NQ==")), Encoding.UTF8.GetString(Convert.FromBase64String("6Zif5Y+L54q25oCB"))), num2);
		num++;
		if (viewer.IsAlive && (int)CustomRoleSystem._md6a40e4754499fc2(viewer) == 0 && (int)_m476574526f6c65547970653a300(viewer) != 10)
		{
			flag |= _m0d28332e3f09392a1633343f606a(core, state, ref num, num2, viewer);
		}
		for (int i = 0; i < _fdde95a75e12b222b.Count; i++)
		{
			if (num >= 16)
			{
				break;
			}
			Player val = _fdde95a75e12b222b[i];
			if (val != null && val.Id != viewer.Id)
			{
				flag |= _m0d28332e3f09392a1633343f606a(core, state, ref num, num2, val);
			}
		}
		int num3 = _m436f756e74416c6976653a300((RoleTypeId)10);
		if (num3 > 0 && num < 16)
		{
			flag |= _mYnwxzoTYGRJZ(core, state.ScpLines, _f85483bcdf4ec696f, num, _msaEwpvegVCGM(_t48696e74416c69676e6d656e743a300.Left, Encoding.UTF8.GetString(Convert.FromBase64String("PHBvcz0tMzUwPjxzaXplPTE2PjxsaW5lLWhlaWdodD0yMj48Y29sb3I9I0FBQUFBQT7lsI/lg7XlsLg6PC9jb2xvcj4gPGNvbG9yPSNGRjU1NTU+PGI+")) + num3 + Encoding.UTF8.GetString(Convert.FromBase64String("PC9iPiDlj6o8L2NvbG9yPjwvc2l6ZT4="))), num2 - 64f * (float)num);
			num++;
		}
		List<string> list = new List<string>();
		foreach (Generator item in Generator.List)
		{
			if (item != null && item.IsActivating)
			{
				list.Add(string.Format(Encoding.UTF8.GetString(Convert.FromBase64String("PGNvbG9yPSNBQUFBQUE+5Y+R55S15py6OjwvY29sb3I+IDxjb2xvcj0jNTVGRjU1PnswfTwvY29sb3I+IDxjb2xvcj0jQUFBQUFBPuWJqeS9mTo8L2NvbG9yPiA8Y29sb3I9I0ZGNTU1NT57MX3np5I8L2NvbG9yPg==")), _mf4c97aa861381068(item.Room), Math.Max(0, (int)item.CurrentTime)));
			}
		}
		if (list.Count > 0 && num < 16)
		{
			string text = Encoding.UTF8.GetString(Convert.FromBase64String("PHBvcz0tMzUwPgo8c2l6ZT0xNT48bGluZS1oZWlnaHQ9MjA+")) + string.Join(Encoding.UTF8.GetString(Convert.FromBase64String("ICAgIA==")), list) + Encoding.UTF8.GetString(Convert.FromBase64String("PC9zaXplPg=="));
			flag |= _mYnwxzoTYGRJZ(core, state.ScpLines, _f85483bcdf4ec696f, num, _msaEwpvegVCGM(_t48696e74416c69676e6d656e743a300.Left, text), num2 - 64f * (float)num);
			num++;
		}
		return flag | _m19363f3b281633343f291c283537606a(core, state.ScpLines, _f85483bcdf4ec696f, num, 16, num2, 64f);
	}

	private static bool _m0d28332e3f09392a1633343f606a(DisplayCore core, _t506c61796572446973706c617953746174653a300 state, ref int line, float panelPosition, Player scp)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Invalid comparison between Unknown and I4
		while (true)
		{
			if (scp == null || scp.Role == (Role)null || line >= 16)
			{
				return false;
			}
			RoleTypeId val = _m476574526f6c65547970653a300(scp);
			if ((int)val == 7)
			{
				Scp079Role val2 = ((TypeCastObject<Role>)(object)scp.Role).As<Scp079Role>();
				if ((Role)(object)val2 == (Role)null)
				{
					break;
				}
			}
		}
		return false;
	}

	private static bool _mYnwxzoTYGRJZ(DisplayCore core, string[] cache, IElemReference<SetElement>[] references, int index, string content, float position)
	{
		if (content == null)
		{
			content = string.Empty;
		}
		string text = cache[index];
		if (string.IsNullOrEmpty(text) && content.Length == 0)
		{
			cache[index] = string.Empty;
			return false;
		}
		if (string.Equals(text, content, StringComparison.Ordinal))
		{
			SetElement element = core.GetElement(references[index]);
			if (element != null && Math.Abs(element.Position - position) < 0.01f)
			{
				return false;
			}
		}
		cache[index] = content;
		core.SetElementOrNew(references[index], content, position);
		return true;
	}

	private static bool _m19363f3b281633343f291c283537606a(DisplayCore core, string[] cache, IElemReference<SetElement>[] references, int startIndex, int capacity, float startPosition, float lineOffset)
	{
		bool flag = false;
		int num = Math.Min(capacity, references.Length);
		for (int i = startIndex; i < num; i++)
		{
			flag |= _mYnwxzoTYGRJZ(core, cache, references, i, string.Empty, startPosition - lineOffset * (float)i);
		}
		return flag;
	}

	private static bool _m19363f3b281538293f282c3f281633343f29606a(DisplayCore core, _t506c61796572446973706c617953746174653a300 state)
	{
		return (byte)(0u | (_mYnwxzoTYGRJZ(core, state.ObserverLines, _f1538293f282c3f28083f3c29606a, 0, string.Empty, 300f) ? 1u : 0u) | (_mYnwxzoTYGRJZ(core, state.ObserverLines, _f1538293f282c3f28083f3c29606a, 1, string.Empty, 270f) ? 1u : 0u) | (_mYnwxzoTYGRJZ(core, state.ObserverLines, _f1538293f282c3f28083f3c29606a, 2, string.Empty, 240f) ? 1u : 0u) | (_mYnwxzoTYGRJZ(core, state.ObserverLines, _f1538293f282c3f28083f3c29606a, 3, string.Empty, 210f) ? 1u : 0u) | (_mYnwxzoTYGRJZ(core, state.ObserverLines, _f1538293f282c3f28083f3c29606a, 4, string.Empty, 8f) ? 1u : 0u)) != 0;
	}

	private static bool _mnbVXVvkJyQDE(DisplayCore core, _t506c61796572446973706c617953746174653a300 state)
	{
		return _m19363f3b281633343f291c283537606a(core, state.HumanLines, _f48756d616e526566733a300, 0, 10, 500f, 32f);
	}

	private static bool _m436c6561725363704c696e65733a300(DisplayCore core, _t506c61796572446973706c617953746174653a300 state)
	{
		return _m19363f3b281633343f291c283537606a(core, state.ScpLines, _f85483bcdf4ec696f, 0, 16, 500f, 64f);
	}

	private static bool _mbc96164ec9e3958e(DisplayCore core, _t506c61796572446973706c617953746174653a300 state)
	{
		bool flag = _m19363f3b281538293f282c3f281633343f29606a(core, state);
		flag |= _mnbVXVvkJyQDE(core, state);
		flag |= _m436c6561725363704c696e65733a300(core, state);
		if (!string.IsNullOrEmpty(state.PlayerStatus))
		{
			state.PlayerStatus = string.Empty;
			core.SetElementOrNew(_f506c617965725374617475735265663a300, string.Empty, 0f);
			flag = true;
		}
		return flag;
	}

	private int _m436f756e74416c6976653a300(RoleTypeId roleType)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		if (!_f3b36332c3f0835363f19352f342e29606a.TryGetValue(roleType, out var value))
		{
			return 0;
		}
		return value;
	}

	private int _m1d3f2e122f373b340a3b343f36132e3f3719352f342e606a(Team team)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0004: Invalid comparison between Unknown and I4
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Invalid comparison between Unknown and I4
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Invalid comparison between Unknown and I4
		int num = 1;
		if ((int)team == 2 || (int)team == 4)
		{
			num += ((_m436f756e74416c6976653a300((RoleTypeId)8) > 0) ? 1 : 0);
			num += ((_m436f756e74416c6976653a300((RoleTypeId)20) > 0) ? 1 : 0);
			num += ((_m436f756e74416c6976653a300((RoleTypeId)19) > 0) ? 1 : 0);
			num += ((_m436f756e74416c6976653a300((RoleTypeId)18) > 0) ? 1 : 0);
			num += ((_m436f756e74416c6976653a300((RoleTypeId)1) > 0) ? 1 : 0);
		}
		else if ((int)team == 1 || (int)team == 3)
		{
			num += ((_m436f756e74416c6976653a300((RoleTypeId)4) > 0) ? 1 : 0);
			num += ((_m436f756e74416c6976653a300((RoleTypeId)13) > 0) ? 1 : 0);
			num += ((_m436f756e74416c6976653a300((RoleTypeId)11) > 0) ? 1 : 0);
			num += ((_m436f756e74416c6976653a300((RoleTypeId)12) > 0) ? 1 : 0);
			num += ((_m436f756e74416c6976653a300((RoleTypeId)6) > 0) ? 1 : 0);
			num += ((_m436f756e74416c6976653a300((RoleTypeId)15) > 0) ? 1 : 0);
		}
		return Math.Min(10, num);
	}

	private int _m1d3f2e09392a0a3b343f36132e3f3719352f342e606a()
	{
		int num = 1 + _fdde95a75e12b222b.Count;
		num += ((_m436f756e74416c6976653a300((RoleTypeId)10) > 0) ? 1 : 0);
		bool flag = false;
		foreach (Generator item in Generator.List)
		{
			if (item != null && item.IsActivating)
			{
				flag = true;
				break;
			}
		}
		num += (flag ? 1 : 0);
		return Math.Min(16, num);
	}

	private static float _ma0d3865062047cc1(int itemCount, float lineOffset)
	{
		return 500f + (float)(Math.Max(1, itemCount) - 1) * lineOffset / 2f;
	}

	private static IElemReference<SetElement>[] _mWGbVsEQnEaqu(int amount)
	{
		IElemReference<SetElement>[] array = new IElemReference<SetElement>[amount];
		for (int i = 0; i < amount; i++)
		{
			array[i] = DisplayCore.GetReference<SetElement>();
		}
		return array;
	}

	private static string _msaEwpvegVCGM(_t48696e74416c69676e6d656e743a300 alignment, string text)
	{
		while (alignment == _t48696e74416c69676e6d656e743a300.Center || alignment != _t48696e74416c69676e6d656e743a300.Right)
		{
		}
		return Encoding.UTF8.GetString(Convert.FromBase64String("PGFsaWduPXJpZ2h0PjxzaXplPTMwPg==")) + text + Encoding.UTF8.GetString(Convert.FromBase64String("PC9zaXplPjwvYWxpZ24+"));
	}

	private static string _mOJnbMNTSTUVY(_t48696e74416c69676e6d656e743a300 alignment, string text)
	{
		while (alignment == _t48696e74416c69676e6d656e743a300.Center || alignment != _t48696e74416c69676e6d656e743a300.Right)
		{
		}
		return Encoding.UTF8.GetString(Convert.FromBase64String("PGFsaWduPXJpZ2h0PjxzaXplPTIwPg==")) + text + Encoding.UTF8.GetString(Convert.FromBase64String("PC9zaXplPjwvYWxpZ24+"));
	}

	private static string _m86f4136fba95b7c8(string color, string title)
	{
		return Encoding.UTF8.GetString(Convert.FromBase64String("PGFsaWduPWxlZnQ+PHBvcz0tMzUwPg==")) + string.Format(Encoding.UTF8.GetString(Convert.FromBase64String("PGxpbmUtaGVpZ2h0PTE1PjxzaXplPTI1Pjxjb2xvcj17MH0+WzwvY29sb3I+IDxjb2xvcj13aGl0ZT57MX08L2NvbG9yPiA8Y29sb3I9ezB9Pl08L2NvbG9yPjwvc2l6ZT48L2FsaWduPg==")), color, title);
	}

	private static string _mfd6cf2e7459656ca(string color, string roleName, string nickname)
	{
		return Encoding.UTF8.GetString(Convert.FromBase64String("PHBvcz0tMzUwPg==")) + string.Format(Encoding.UTF8.GetString(Convert.FromBase64String("PHNpemU9MjA+PGxpbmUtaGVpZ2h0PTI1Pjxjb2xvcj17MH0+ezF9PC9jb2xvcj4gPGNvbG9yPXdoaXRlPnsyfTwvY29sb3I+PC9zaXplPg==")), color, roleName, _m1f29393b2a3f083339320e3f222e606a(nickname));
	}

	private static string _muQTwowPoYrcV(Player player)
	{
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		float num = Math.Max(0f, player.HumeShield);
		float value = Math.Max(num, ((StatBase)player.HumeShieldStat).MaxValue);
		return Encoding.UTF8.GetString(Convert.FromBase64String("Cjxwb3M9LTM1MD4=")) + string.Format(Encoding.UTF8.GetString(Convert.FromBase64String("PHNpemU9MTU+PGxpbmUtaGVpZ2h0PTIwPjxjb2xvcj0jQUFBQUFBPkhQOjwvY29sb3I+IDxjb2xvcj0jRkY1NTU1PnswfS97MX08L2NvbG9yPiB8IDxjb2xvcj0jQUFBQUFBPkhTOjwvY29sb3I+IDxjb2xvcj0jNTU1NUZGPnsyfS97M308L2NvbG9yPiB8IDxjb2xvcj0jQUFBQUFBPuS9jee9rjo8L2NvbG9yPiA8Y29sb3I9IzU1RkY1NT57NH08L2NvbG9yPjwvc2l6ZT4=")), _m1c3528373b2e142f37383f28606a(player.Health), _m1c3528373b2e142f37383f28606a(player.MaxHealth), _m1c3528373b2e142f37383f28606a(num), _m1c3528373b2e142f37383f28606a(value), _mXjJTnVeDBjPd(player.Zone));
	}

	private static string _m1f29393b2a3f083339320e3f222e606a(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return Encoding.UTF8.GetString(Convert.FromBase64String("5pyq55+l546p5a62"));
		}
		return value.Replace(Encoding.UTF8.GetString(Convert.FromBase64String("PA==")), Encoding.UTF8.GetString(Convert.FromBase64String("77yc"))).Replace(Encoding.UTF8.GetString(Convert.FromBase64String("Pg==")), Encoding.UTF8.GetString(Convert.FromBase64String("77ye")));
	}

	private static RoleTypeId _m476574526f6c65547970653a300(Player player)
	{
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (player == null || (Object)(object)player.RoleManager == (Object)null)
		{
			return (RoleTypeId)(-1);
		}
		return player.RoleManager.CurrentRole.RoleTypeId;
	}

	private static string _mXjJTnVeDBjPd(ZoneType zone)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected I4, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		while (true)
		{
			switch (zone - 1)
			{
			case 0:
			case 1:
			case 2:
			case 3:
				continue;
			}
			if ((int)zone != 8 && (int)zone == 16)
			{
			}
		}
	}

	private static string _mf4c97aa861381068(Room room)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Expected I4, but got Unknown
		while (!((Object)(object)room == (Object)null))
		{
			RoomType type = room.Type;
			switch (type - 17)
			{
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
				continue;
			}
			return Encoding.UTF8.GetString(Convert.FromBase64String("U0NQLTA3OeaUtuWuueWupA=="));
		}
		return Encoding.UTF8.GetString(Convert.FromBase64String("5pyq55+l"));
	}

	private static string _m1d3f2e09392a6a636c092e3b2e3f143b373f606a(Scp096Role role)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		string text;
		do
		{
			text = ((object)role.RageState/*cast due to .constrained prefix*/).ToString();
		}
		while (text == Encoding.UTF8.GetString(Convert.FromBase64String("RG9jaWxl")) || text == Encoding.UTF8.GetString(Convert.FromBase64String("RGlzdHJlc3NlZA==")) || text == Encoding.UTF8.GetString(Convert.FromBase64String("RW5yYWdlZA==")));
		if (!(text == Encoding.UTF8.GetString(Convert.FromBase64String("Q2FsbWluZw=="))))
		{
		}
		return Encoding.UTF8.GetString(Convert.FromBase64String("5bmz6Z2Z"));
	}

	private unsafe static string _md9c5612854a446df(RoleTypeId roleType)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected I4, but got Unknown
		while (true)
		{
			switch (roleType - 1)
			{
			case 0:
			case 3:
			case 5:
			case 7:
			case 10:
			case 11:
			case 12:
			case 14:
			case 17:
			case 18:
			case 19:
				break;
			default:
				return Encoding.UTF8.GetString(Convert.FromBase64String("ROe6p+S6uuWRmA=="));
			case 1:
			case 2:
			case 4:
			case 6:
			case 8:
			case 9:
			case 13:
			case 15:
			case 16:
				return ((object)(*(RoleTypeId*)(&roleType))/*cast due to .constrained prefix*/).ToString();
			}
		}
	}

	private static string _m4765744e6578745265737061776e546578743a300()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		while (true)
		{
			SpawnableTeamType nextKnownTeam = Respawn.NextKnownTeam;
			if ((int)nextKnownTeam != 1 && (int)nextKnownTeam == 2)
			{
			}
		}
	}

	private static int _m476574536370536f72744f726465723a300(Player player)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Expected I4, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Invalid comparison between Unknown and I4
		if (CustomRoleSystem._mLGNqWDwdPFOO(player))
		{
			return 6;
		}
		RoleTypeId val = _m476574526f6c65547970653a300(player);
		if ((int)val != 0)
		{
			switch (val - 3)
			{
			default:
				if ((int)val != 16)
				{
					break;
				}
				return 5;
			case 4:
				return 0;
			case 2:
				return 1;
			case 6:
				return 2;
			case 0:
				return 3;
			case 1:
			case 3:
			case 5:
				break;
			}
			return 99;
		}
		return 4;
	}

	private static string _m1d3f2e09392a1e33292a363b23143b373f606a(Player player)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Expected I4, but got Unknown
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Invalid comparison between Unknown and I4
		while (true)
		{
			if (CustomRoleSystem._mqUKYWxagClXy(player))
			{
				return Encoding.UTF8.GetString(Convert.FromBase64String("U0NQLTA3Mw=="));
			}
			if (CustomRoleSystem._mLGNqWDwdPFOO(player))
			{
				break;
			}
			RoleTypeId val = _m476574526f6c65547970653a300(player);
			switch ((int)val)
			{
			case 0:
			case 3:
			case 5:
			case 7:
			case 9:
			case 10:
				continue;
			case 1:
			case 2:
			case 4:
			case 6:
			case 8:
				return ((object)_m476574526f6c65547970653a300(player)/*cast due to .constrained prefix*/).ToString();
			}
			if ((int)val != 16)
			{
				return Encoding.UTF8.GetString(Convert.FromBase64String("U0NQLTA0OQ=="));
			}
		}
		return Encoding.UTF8.GetString(Convert.FromBase64String("U0NQLTU1MA=="));
	}

	private static string _m1c3528373b2e142f37383f28606a(float value)
	{
		return Math.Max(0f, value).ToString(Encoding.UTF8.GetString(Convert.FromBase64String("MA==")));
	}

	private float _mLsDmXXlwHShi()
	{
		return Math.Max(0.25f, ((Plugin<Config>)_f2a362f3d3334606a).Config.RefreshIntervalSeconds);
	}
}
