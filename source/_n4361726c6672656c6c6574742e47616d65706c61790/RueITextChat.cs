using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Exiled.API.Features;
using Exiled.API.Features.Roles;
using Exiled.Events.EventArgs.Server;
using Exiled.Events.Handlers;
using MEC;
using PlayerRoles;
using RueI.Displays;
using RueI.Elements;
using RueI.Extensions;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class RueITextChat
{
	private enum _t436861745669736962696c6974793a300
	{
		All,
		Team,
		SpecificPlayers,
		RemoteAdmins
	}

	private enum _tstgqQoiczAfo
	{
		None,
		Scp,
		ChaosInsurgency,
		Foundation
	}

	private sealed class _t19323b2e173f29293b3d3f606a
	{
		public string Text { get; }

		public bool IsExpired => DateTime.UtcNow >= _pa3f1618aa5d332fd;

		private _t436861745669736962696c6974793a300 _p0c332933383336332e23606a { get; }

		private _tstgqQoiczAfo _p0e3f3b37606a { get; }

		private HashSet<string> _p526563697069656e744b6579733a300 { get; }

		private DateTime _pa3f1618aa5d332fd { get; }

		private _t19323b2e173f29293b3d3f606a(string text, _t436861745669736962696c6974793a300 visibility, _tstgqQoiczAfo team, IEnumerable<string> recipientKeys = null)
		{
			_f660e3f222e64310505183b393133343d1c333f363e606a = text;
			_fkBYRSbvtCaJQ = visibility;
			_f3c5465616d3e6b5f5f4261636b696e674669656c643a300 = team;
			_f66083f39332a333f342e113f232964310505183b393133343d1c333f363e606a = ((recipientKeys == null) ? null : new HashSet<string>(recipientKeys, StringComparer.OrdinalIgnoreCase));
			_f3c4578706972657341743e6b5f5f4261636b696e674669656c643a300 = DateTime.UtcNow.AddSeconds(5.0);
		}

		public static _t19323b2e173f29293b3d3f606a ToAll(string text)
		{
			return new _t19323b2e173f29293b3d3f606a(text, _t436861745669736962696c6974793a300.All, _tstgqQoiczAfo.None);
		}

		public static _t19323b2e173f29293b3d3f606a ToTeam(string text, _tstgqQoiczAfo team)
		{
			return new _t19323b2e173f29293b3d3f606a(text, _t436861745669736962696c6974793a300.Team, team);
		}

		public static _t19323b2e173f29293b3d3f606a ToSpecificPlayers(string text, IEnumerable<string> recipientKeys)
		{
			return new _t19323b2e173f29293b3d3f606a(text, _t436861745669736962696c6974793a300.SpecificPlayers, _tstgqQoiczAfo.None, recipientKeys);
		}

		public static _t19323b2e173f29293b3d3f606a ToRemoteAdmins(string text)
		{
			return new _t19323b2e173f29293b3d3f606a(text, _t436861745669736962696c6974793a300.RemoteAdmins, _tstgqQoiczAfo.None);
		}

		public bool IsVisibleTo(Player player)
		{
			if (player == null)
			{
				return false;
			}
			switch (_p0c332933383336332e23606a)
			{
			case _t436861745669736962696c6974793a300.All:
				if (SpectatorPrivacySystem.Instance != null)
				{
					return !SpectatorPrivacySystem.Instance.IsRestricted(player);
				}
				return true;
			case _t436861745669736962696c6974793a300.Team:
			{
				if (_mefecc69909dc8405(player, out var chatTeam))
				{
					return chatTeam == _p0e3f3b37606a;
				}
				return false;
			}
			case _t436861745669736962696c6974793a300.SpecificPlayers:
				if (_p526563697069656e744b6579733a300 != null)
				{
					return _p526563697069656e744b6579733a300.Contains(_mbKmpaThyhUsg(player));
				}
				return false;
			case _t436861745669736962696c6974793a300.RemoteAdmins:
				return player.RemoteAdminAccess;
			default:
				return false;
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _t3c3e633a300
	{
		public static readonly _t3c3e633a300 _003C_003E9 = new _t3c3e633a300();

		public static Func<Player, bool> _003C_003E9__18_0;

		public static Func<Player, bool> _003C_003E9__21_0;

		public static Predicate<_t19323b2e173f29293b3d3f606a> _003C_003E9__30_0;

		internal bool _m661828353b3e393b292e643805056b62056a606a(Player player)
		{
			if (SpectatorPrivacySystem.Instance != null)
			{
				return !SpectatorPrivacySystem.Instance.IsRestricted(player);
			}
			return true;
		}

		internal bool _m3c53656e6441646d696e43616c6c3e625f5f32315f303a300(Player player)
		{
			return player.RemoteAdminAccess;
		}

		internal bool _mdaPcDyLQxRim(_t19323b2e173f29293b3d3f606a message)
		{
			return message.IsExpired;
		}
	}

	private const int _frsrIBLOqdgsX = 15;

	private const int _f4d617853746f7265644d657373616765733a300 = 75;

	private const float _f19323b2e092e3b282e0a3529332e333534606a = 900f;

	private const float _f19323b2e1633343f153c3c293f2e606a = 30f;

	private const float _fd4adcd30b2d66e9f = 25f;

	private const float _f8127c7fa9a51e5f9 = 5f;

	private const float _f23f1ea1c1a7de762 = 0.25f;

	private static readonly IElemReference<SetElement>[] _f24fe8469c6a1c0f7 = _m4372656174655265666572656e6365733a300(15);

	private static readonly Regex _f526963685465787454616752656765783a300 = new Regex("<[^>]*>", RegexOptions.Compiled);

	private static MethodInfo _f707562675465616d43686174526563697069656e744d6574686f643a300;

	private readonly List<_t19323b2e173f29293b3d3f606a> _f62c9720bbaaaca24 = new List<_t19323b2e173f29293b3d3f606a>();

	private CoroutineHandle _fLJCZoolMMZlC;

	public static RueITextChat Instance { get; private set; }

	public void Enable()
	{
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		Instance = this;
		Server.RoundStarted += _m153408352f343e092e3b282e3f3e606a;
		Server.RoundEnded += _m615d6ff1f188485b;
		Server.WaitingForPlayers += _m15340d3b332e33343d1c35280a363b233f2829606a;
		Server.RestartingRound += _m4f6e52657374617274696e67526f756e643a300;
		_fLJCZoolMMZlC = Timing.RunCoroutine(_m45787069726174696f6e4c6f6f703a300());
	}

	public void Disable()
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		Server.RoundStarted -= _m153408352f343e092e3b282e3f3e606a;
		Server.RoundEnded -= _m615d6ff1f188485b;
		Server.WaitingForPlayers -= _m15340d3b332e33343d1c35280a363b233f2829606a;
		Server.RestartingRound -= _m4f6e52657374617274696e67526f756e643a300;
		if (((CoroutineHandle)(ref _fLJCZoolMMZlC)).IsRunning)
		{
			Timing.KillCoroutines((CoroutineHandle[])(object)new CoroutineHandle[1] { _fLJCZoolMMZlC });
		}
		_m436c656172436861743a300();
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void Broadcast(Player sender, string text)
	{
		if (sender == null || string.IsNullOrWhiteSpace(text))
		{
			return;
		}
		string text2 = _m4e6f726d616c697a654d6573736167653a300(text);
		if (!string.IsNullOrWhiteSpace(text2))
		{
			_m1b3e3e173f29293b3d3f606a(_t19323b2e173f29293b3d3f606a.ToAll(_m182f33363e1633343f606a(Encoding.UTF8.GetString(Convert.FromBase64String("IzdGREJGRg==")), Encoding.UTF8.GetString(Convert.FromBase64String("5YWo5L2T")), sender, text2)));
			_m52656672657368506c61796572733a300(sender);
			_mc2701165a4f6aa9b(sender, text2, Encoding.UTF8.GetString(Convert.FromBase64String("5YWo5L2T")), Encoding.UTF8.GetString(Convert.FromBase64String("eWVsbG93")), (Player player) => SpectatorPrivacySystem.Instance == null || !SpectatorPrivacySystem.Instance.IsRestricted(player));
		}
	}

	public void RefreshVisibility(Player player)
	{
		_mdkulpfmFDktp(player);
	}

	public void SendTeam(Player sender, string text)
	{
		if (sender == null || string.IsNullOrWhiteSpace(text))
		{
			return;
		}
		string text2 = _m4e6f726d616c697a654d6573736167653a300(text);
		if (string.IsNullOrWhiteSpace(text2))
		{
			return;
		}
		if (_m0e28231d3f2e0a2f383d0e3f3b3719323b2e083f39332a333f342e29606a(sender, out var recipientKeys))
		{
		}
		if (recipientKeys.Length == 0)
		{
			return;
		}
		_m1b3e3e173f29293b3d3f606a(_t19323b2e173f29293b3d3f606a.ToSpecificPlayers(_m182f33363e1633343f606a(Encoding.UTF8.GetString(Convert.FromBase64String("IzU3RDY4RA==")), Encoding.UTF8.GetString(Convert.FromBase64String("6Zif5LyN")), sender, text2), recipientKeys));
		HashSet<string> recipients = new HashSet<string>(recipientKeys, StringComparer.OrdinalIgnoreCase);
		_mc2701165a4f6aa9b(sender, text2, Encoding.UTF8.GetString(Convert.FromBase64String("6Zif5LyN")), Encoding.UTF8.GetString(Convert.FromBase64String("Z3JlZW4=")), (Player player) => recipients.Contains(_mbKmpaThyhUsg(player)));
		if (_mefecc69909dc8405(sender, out var team))
		{
			_m1b3e3e173f29293b3d3f606a(_t19323b2e173f29293b3d3f606a.ToTeam(_m182f33363e1633343f606a(Encoding.UTF8.GetString(Convert.FromBase64String("IzU3RDY4RA==")), Encoding.UTF8.GetString(Convert.FromBase64String("5Zui6Zif")), sender, text2), team));
			_mc2701165a4f6aa9b(sender, text2, Encoding.UTF8.GetString(Convert.FromBase64String("5Zui6Zif")), Encoding.UTF8.GetString(Convert.FromBase64String("Z3JlZW4=")), (Player player) => _mefecc69909dc8405(player, out var chatTeam) && chatTeam == team);
			_m52656672657368506c61796572733a300(sender);
		}
	}

	public void SendAdminCall(Player sender, string text)
	{
		if (sender == null || string.IsNullOrWhiteSpace(text))
		{
			return;
		}
		string text2 = _m4e6f726d616c697a654d6573736167653a300(text);
		if (!string.IsNullOrWhiteSpace(text2))
		{
			_m1b3e3e173f29293b3d3f606a(_t19323b2e173f29293b3d3f606a.ToRemoteAdmins(_m182f33363e1633343f606a(Encoding.UTF8.GetString(Convert.FromBase64String("I0ZGNEQ0Rg==")), Encoding.UTF8.GetString(Convert.FromBase64String("546p5a625rGC5Yqp")), sender, text2)));
			_m52656672657368506c61796572733a300(sender);
			_mc2701165a4f6aa9b(sender, text2, Encoding.UTF8.GetString(Convert.FromBase64String("546p5a625rGC5Yqp")), Encoding.UTF8.GetString(Convert.FromBase64String("cmVk")), (Player player) => player.RemoteAdminAccess);
		}
	}

	private static void _mc2701165a4f6aa9b(Player sender, string message, string header, string color, Func<Player, bool> canReceive)
	{
		string text = string.Format(Encoding.UTF8.GetString(Convert.FromBase64String("W3swfV0gezF9OiB7Mn0=")), _mCBEQPEgTvwsu(header), _mCBEQPEgTvwsu((sender == null) ? null : sender.DisplayNickname), _mCBEQPEgTvwsu(message));
		foreach (Player item in Player.List.ToList())
		{
			if (item != null && !(item.ReferenceHub == (ReferenceHub)null) && item.IsConnected && (canReceive == null || canReceive(item)))
			{
				item.SendConsoleMessage(text, color);
			}
		}
	}

	public bool CanUseTeamChat(Player player)
	{
		if (_m0e28231d3f2e0a2f383d0e3f3b3719323b2e083f39332a333f342e29606a(player, out var recipientKeys))
		{
			return recipientKeys.Any((string key) => key.Equals(_mbKmpaThyhUsg(player), StringComparison.OrdinalIgnoreCase));
		}
		_tstgqQoiczAfo chatTeam;
		return _mefecc69909dc8405(player, out chatTeam);
	}

	private void _m153408352f343e092e3b282e3f3e606a()
	{
		_m436c656172436861743a300();
	}

	private void _m615d6ff1f188485b(RoundEndedEventArgs ev)
	{
		_m436c656172436861743a300();
	}

	private void _m15340d3b332e33343d1c35280a363b233f2829606a()
	{
		_m436c656172436861743a300();
	}

	private void _m4f6e52657374617274696e67526f756e643a300()
	{
		_m436c656172436861743a300();
	}

	private void _m1b3e3e173f29293b3d3f606a(_t19323b2e173f29293b3d3f606a message)
	{
		_mbe22109c636dba41();
		_f62c9720bbaaaca24.Insert(0, message);
		while (_f62c9720bbaaaca24.Count > 75)
		{
			_f62c9720bbaaaca24.RemoveAt(_f62c9720bbaaaca24.Count - 1);
		}
	}

	private IEnumerator<float> _m45787069726174696f6e4c6f6f703a300()
	{
		while (true)
		{
			try
			{
				if (_mbe22109c636dba41())
				{
					_m52656672657368416c6c506c61796572733a300();
				}
			}
			catch (Exception ex)
			{
				Log.Error("Failed to expire RueI text chat messages: " + ex);
			}
			yield return Timing.WaitForSeconds(0.25f);
		}
	}

	private bool _mbe22109c636dba41()
	{
		return _f62c9720bbaaaca24.RemoveAll((_t19323b2e173f29293b3d3f606a message) => message.IsExpired) > 0;
	}

	private void _m436c656172436861743a300()
	{
		_f62c9720bbaaaca24.Clear();
		_mHSkMXfmZAFTj();
	}

	private void _m52656672657368416c6c506c61796572733a300()
	{
		foreach (Player item in Player.List.ToList())
		{
			_mdkulpfmFDktp(item);
		}
	}

	private void _m52656672657368506c61796572733a300(Player sender)
	{
		List<Player> list = Player.List.ToList();
		_mdkulpfmFDktp(sender);
		foreach (Player item in list)
		{
			if (item != null && item != sender)
			{
				_mdkulpfmFDktp(item);
			}
		}
	}

	private void _mdkulpfmFDktp(Player player)
	{
		if (player != null && !(player.ReferenceHub == (ReferenceHub)null))
		{
			DisplayCore displayCore = DisplayCore.Get(player);
			for (int i = 0; i < _f24fe8469c6a1c0f7.Length; i++)
			{
				string content = _mTOSwUhuBTOqn(player, i);
				float position = 900f - 30f * (float)i;
				displayCore.SetElementOrNew(_f24fe8469c6a1c0f7[i], content, position);
			}
			displayCore.Update();
		}
	}

	private string _mTOSwUhuBTOqn(Player player, int index)
	{
		int num = 0;
		foreach (_t19323b2e173f29293b3d3f606a item in _f62c9720bbaaaca24)
		{
			if (item.IsVisibleTo(player) && !item.IsExpired)
			{
				if (num == index)
				{
					return _mbc508f069fcb748e(item.Text);
				}
				num++;
			}
		}
		return string.Empty;
	}

	private static IElemReference<SetElement>[] _m4372656174655265666572656e6365733a300(int amount)
	{
		IElemReference<SetElement>[] array = new IElemReference<SetElement>[amount];
		for (int i = 0; i < amount; i++)
		{
			array[i] = DisplayCore.GetReference<SetElement>();
		}
		return array;
	}

	private static void _mHSkMXfmZAFTj()
	{
		foreach (Player item in Player.List.ToList())
		{
			_m436c656172506c617965723a300(item);
		}
	}

	private static void _m436c656172506c617965723a300(Player player)
	{
		if (player != null && !(player.ReferenceHub == (ReferenceHub)null))
		{
			DisplayCore displayCore = DisplayCore.Get(player);
			for (int i = 0; i < _f24fe8469c6a1c0f7.Length; i++)
			{
				displayCore.SetElementOrNew(_f24fe8469c6a1c0f7[i], string.Empty, 900f - 30f * (float)i);
			}
			displayCore.Update();
		}
	}

	private static string _mbc508f069fcb748e(string text)
	{
		return string.Format(Encoding.UTF8.GetString(Convert.FromBase64String("PGFsaWduPWxlZnQ+PHNpemU9ezB9PnsxfTwvc2l6ZT48L2FsaWduPg==")), 25f, text);
	}

	private static string _m182f33363e1633343f606a(string headerColor, string header, Player sender, string message)
	{
		return string.Format(Encoding.UTF8.GetString(Convert.FromBase64String("PGNvbG9yPXswfT5bezF9XTwvY29sb3I+IDxjb2xvcj0jRjZDNDQ1PnsyfTwvY29sb3I+OiA8Y29sb3I9I0Y4RjlGQT57M308L2NvbG9yPg==")), headerColor, _mAdhxsEIzxZbu(header), _mAdhxsEIzxZbu(sender.Nickname), _mAdhxsEIzxZbu(message));
	}

	private static bool _mefecc69909dc8405(Player player, out _tstgqQoiczAfo chatTeam)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected I4, but got Unknown
		chatTeam = _tstgqQoiczAfo.None;
		if (player == null || player.Role == (Role)null)
		{
			return false;
		}
		Team val = CustomRoleSystem._md6a40e4754499fc2(player);
		switch ((int)val)
		{
		case 0:
			chatTeam = _tstgqQoiczAfo.Scp;
			return true;
		case 2:
		case 4:
			chatTeam = _tstgqQoiczAfo.ChaosInsurgency;
			return true;
		case 1:
		case 3:
			chatTeam = _tstgqQoiczAfo.Foundation;
			return true;
		default:
			return false;
		}
	}

	private static bool _m0e28231d3f2e0a2f383d0e3f3b3719323b2e083f39332a333f342e29606a(Player player, out string[] recipientKeys)
	{
		recipientKeys = null;
		try
		{
			if (_f707562675465616d43686174526563697069656e744d6574686f643a300 == null)
			{
				Type type = Type.GetType(Encoding.UTF8.GetString(Convert.FromBase64String("QXV0b0V2ZW50LkdhbWVzLlBVQkcuUHViZ0dhbWVNb2RlLCBBdXRvRXZlbnQ=")), throwOnError: false);
				if (type == null)
				{
					return false;
				}
				_f707562675465616d43686174526563697069656e744d6574686f643a300 = type.GetMethod(Encoding.UTF8.GetString(Convert.FromBase64String("R2V0VGVhbUNoYXRSZWNpcGllbnRLZXlz")), BindingFlags.Static | BindingFlags.Public, null, new Type[1] { typeof(Player) }, null);
			}
			if (_f707562675465616d43686174526563697069656e744d6574686f643a300 == null)
			{
				return false;
			}
			recipientKeys = _f707562675465616d43686174526563697069656e744d6574686f643a300.Invoke(null, new object[1] { player }) as string[];
			return recipientKeys != null;
		}
		catch
		{
			recipientKeys = null;
			return false;
		}
	}

	private static string _mbKmpaThyhUsg(Player player)
	{
		if (player == null)
		{
			return string.Empty;
		}
		if (string.IsNullOrWhiteSpace(player.UserId))
		{
			return Encoding.UTF8.GetString(Convert.FromBase64String("cGxheWVyOg==")) + player.Id;
		}
		return player.UserId.Trim();
	}

	internal static string _m4e6f726d616c697a654d6573736167653a300(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return string.Empty;
		}
		string text2 = text.Replace(Encoding.UTF8.GetString(Convert.FromBase64String("DQ==")), Encoding.UTF8.GetString(Convert.FromBase64String("IA=="))).Replace(Encoding.UTF8.GetString(Convert.FromBase64String("Cg==")), Encoding.UTF8.GetString(Convert.FromBase64String("IA=="))).Trim();
		if (text2.Length > 160)
		{
			return text2.Substring(0, 160);
		}
		return text2;
	}

	internal static string _mCBEQPEgTvwsu(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return string.Empty;
		}
		string input = WebUtility.HtmlDecode(text);
		return WebUtility.HtmlDecode(_f526963685465787454616752656765783a300.Replace(input, string.Empty)).Replace(Encoding.UTF8.GetString(Convert.FromBase64String("DQ==")), Encoding.UTF8.GetString(Convert.FromBase64String("IA=="))).Replace(Encoding.UTF8.GetString(Convert.FromBase64String("Cg==")), Encoding.UTF8.GetString(Convert.FromBase64String("IA==")));
	}

	internal static string _mAdhxsEIzxZbu(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return string.Empty;
		}
		return text.Replace(Encoding.UTF8.GetString(Convert.FromBase64String("Jg==")), Encoding.UTF8.GetString(Convert.FromBase64String("JmFtcDs="))).Replace(Encoding.UTF8.GetString(Convert.FromBase64String("PA==")), Encoding.UTF8.GetString(Convert.FromBase64String("Jmx0Ow=="))).Replace(Encoding.UTF8.GetString(Convert.FromBase64String("Pg==")), Encoding.UTF8.GetString(Convert.FromBase64String("Jmd0Ow==")));
	}
}
