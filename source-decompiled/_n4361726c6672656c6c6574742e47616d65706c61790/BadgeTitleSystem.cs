using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Handlers;
using MEC;
using Newtonsoft.Json;
using UnityEngine;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class BadgeTitleSystem
{
	private sealed class _t4f726967696e616c42616467653a300
	{
		public string Name { get; private set; }

		public string Color { get; private set; }

		public _t4f726967696e616c42616467653a300(string name, string color)
		{
			Name = name;
			Color = color;
		}
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _t3c3e633a300
	{
		public static readonly _t3c3e633a300 _003C_003E9 = new _t3c3e633a300();

		public static Func<Player, bool> _003C_003E9__27_0;

		public static Func<NamedColor, bool> _003C_003E9__27_1;

		public static Func<NamedColor, string> _003C_003E9__27_2;

		public static Func<string, string> _003C_003E9__27_3;

		internal bool _m6eabf184b69bb882(Player player)
		{
			if (player != null && player.ReferenceHub != (ReferenceHub)null)
			{
				return (Object)(object)player.ReferenceHub.serverRoles != (Object)null;
			}
			return false;
		}

		internal bool _mhGimLfkqOLfZ(NamedColor color)
		{
			if (color != null && !color.Restricted && !string.IsNullOrWhiteSpace(color.Name))
			{
				return !string.Equals(color.Name, Encoding.UTF8.GetString(Convert.FromBase64String("ZGVmYXVsdA==")), StringComparison.OrdinalIgnoreCase);
			}
			return false;
		}

		internal string _m57417a350e44e228(NamedColor color)
		{
			return color.Name.ToLowerInvariant();
		}

		internal string _me2d43bee44b8450c(string color)
		{
			return color;
		}
	}

	private const string _f1db60cf514dbdff2 = "Carlfrellett.BadgeTitleSystem";

	private const string _f90a83e0e330a14cc = "『★』";

	private const float _fBFMQaLfidQPT = 1f;

	private readonly Dictionary<string, BadgeTitleRecord> _f7265636f7264733a300 = new Dictionary<string, BadgeTitleRecord>(StringComparer.OrdinalIgnoreCase);

	private readonly Dictionary<string, _t4f726967696e616c42616467653a300> _ff5b24f8618c45e36 = new Dictionary<string, _t4f726967696e616c42616467653a300>(StringComparer.OrdinalIgnoreCase);

	private readonly Random _f72616e646f6d3a300 = new Random();

	private CoroutineHandle _f72656672657368436f726f7574696e653a300;

	private bool _fMWJIVWTeSIyz;

	public static BadgeTitleSystem Instance { get; private set; }

	public string DataPath { get; private set; }

	public void Enable()
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		if (_fMWJIVWTeSIyz)
		{
			return;
		}
		_fMWJIVWTeSIyz = true;
		Instance = this;
		DataPath = Path.Combine(Path.GetDirectoryName(Paths.Config), Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0")), Encoding.UTF8.GetString(Convert.FromBase64String("YmFkZ2VzLmpzb24=")));
		_mhtsgxczPdaSI();
		Player.Verified += _m7d182fe7c224cf26;
		Timing.KillCoroutines(Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0LkJhZGdlVGl0bGVTeXN0ZW0=")));
		_f72656672657368436f726f7574696e653a300 = Timing.RunCoroutine(_m083f3c283f29321635352a606a(), (Segment)4, Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0LkJhZGdlVGl0bGVTeXN0ZW0=")));
		foreach (Player item in Player.List.ToList())
		{
			_m4170706c793a300(item, rotateRandomColor: false);
		}
	}

	public void Disable()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		if (!_fMWJIVWTeSIyz)
		{
			return;
		}
		_fMWJIVWTeSIyz = false;
		Player.Verified -= _m7d182fe7c224cf26;
		Timing.KillCoroutines((CoroutineHandle[])(object)new CoroutineHandle[1] { _f72656672657368436f726f7574696e653a300 });
		Timing.KillCoroutines(Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0LkJhZGdlVGl0bGVTeXN0ZW0=")));
		foreach (Player item in Player.List.ToList())
		{
			_m526573746f72653a300(item);
		}
		_ff5b24f8618c45e36.Clear();
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public bool TrySet(string userId, string title, BadgeTitleType type, string color, out string error)
	{
		error = null;
		userId = NormalizeUserId(userId);
		title = title?.Trim();
		color = color?.Trim().ToLowerInvariant();
		if (string.IsNullOrWhiteSpace(userId))
		{
			error = Encoding.UTF8.GetString(Convert.FromBase64String("U3RlYW1JRC9Vc2VySUQg5LiN6IO95Li656m644CC"));
			return false;
		}
		if (string.IsNullOrWhiteSpace(title) && _f7265636f7264733a300.TryGetValue(userId, out var value))
		{
			title = value.Title;
		}
		Player val = FindOnlinePlayer(userId);
		if (string.IsNullOrWhiteSpace(title) && val != null)
		{
			title = val.RankName;
		}
		if (string.IsNullOrWhiteSpace(title))
		{
			error = Encoding.UTF8.GetString(Convert.FromBase64String("6aaW5qyh6K6+572u5b+F6aG75o+Q5L6b56ew5Y+35paH5pys44CC"));
			return false;
		}
		if (title.IndexOf('<') >= 0 || title.IndexOf('>') >= 0 || title.IndexOf('[') >= 0 || title.IndexOf(']') >= 0)
		{
			error = Encoding.UTF8.GetString(Convert.FromBase64String("56ew5Y+35LiN6IO95YyF5ZCrIDzjgIE+44CBWyDmiJYgXeOAgg=="));
			return false;
		}
		if (type == BadgeTitleType.Solid)
		{
			if (string.IsNullOrWhiteSpace(color))
			{
				error = Encoding.UTF8.GetString(Convert.FromBase64String("57qv6Imy56ew5Y+35b+F6aG75oyH5a6a6Iux5paH6aKc6Imy5ZCN44CC"));
				return false;
			}
			if (!_m3db16b9b93c6ec4e(color, val, out error))
			{
				return false;
			}
		}
		else
		{
			color = null;
		}
		BadgeTitleRecord value2;
		bool flag = _f7265636f7264733a300.TryGetValue(userId, out value2);
		_f7265636f7264733a300[userId] = new BadgeTitleRecord
		{
			Title = title,
			Type = type,
			Color = color
		};
		if (!_m168c5bb944c55b8f(out error))
		{
			if (flag)
			{
				_f7265636f7264733a300[userId] = value2;
			}
			else
			{
				_f7265636f7264733a300.Remove(userId);
			}
			return false;
		}
		if (val != null)
		{
			_m4170706c793a300(val, rotateRandomColor: true);
		}
		return true;
	}

	public static Player FindOnlinePlayer(string target)
	{
		if (string.IsNullOrWhiteSpace(target))
		{
			return null;
		}
		target = target.Trim();
		if (int.TryParse(target, out var result))
		{
			Player val = Player.Get(result);
			if (val != null)
			{
				return val;
			}
		}
		string normalized = NormalizeUserId(target);
		return Player.List.FirstOrDefault((Player player) => player != null && (string.Equals(NormalizeUserId(player.UserId), normalized, StringComparison.OrdinalIgnoreCase) || string.Equals(player.RawUserId, target, StringComparison.OrdinalIgnoreCase)));
	}

	public static string NormalizeUserId(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return null;
		}
		value = value.Trim();
		if (value.IndexOf('@') < 0 && value.Length == 17 && value.All(char.IsDigit))
		{
			return value + Encoding.UTF8.GetString(Convert.FromBase64String("QHN0ZWFt"));
		}
		return value;
	}

	public string GetAvailableColors(Player preferredPlayer = null)
	{
		List<string> list;
		do
		{
			list = _mgjWpZhslyVxN(preferredPlayer);
		}
		while (list.Count == 0);
		return string.Join(Encoding.UTF8.GetString(Convert.FromBase64String("LCA=")), list);
	}

	private void _m7d182fe7c224cf26(VerifiedEventArgs ev)
	{
		_m4170706c793a300(ev.Player, rotateRandomColor: false);
	}

	private IEnumerator<float> _m083f3c283f29321635352a606a()
	{
		while (_fMWJIVWTeSIyz)
		{
			yield return Timing.WaitForSeconds(1f);
			foreach (Player item in Player.List.ToList())
			{
				_m4170706c793a300(item, rotateRandomColor: true);
			}
		}
	}

	private void _m4170706c793a300(Player player, bool rotateRandomColor)
	{
		if (!_fMWJIVWTeSIyz || player == null || player.ReferenceHub == (ReferenceHub)null || string.IsNullOrWhiteSpace(player.UserId) || player.BadgeHidden)
		{
			return;
		}
		string key = NormalizeUserId(player.UserId);
		if (!_f7265636f7264733a300.TryGetValue(key, out var value) || value == null || string.IsNullOrWhiteSpace(value.Title))
		{
			return;
		}
		if (!_ff5b24f8618c45e36.ContainsKey(key))
		{
			_ff5b24f8618c45e36[key] = new _t4f726967696e616c42616467653a300(player.RankName, player.RankColor);
		}
		if (!player.RemoteAdminAccess)
		{
		}
		string text = string.Empty + value.Title;
		if (!string.Equals(player.RankName, text, StringComparison.Ordinal))
		{
			player.RankName = text;
		}
		if (value.Type == BadgeTitleType.Solid)
		{
			if (!string.Equals(player.RankColor, value.Color, StringComparison.OrdinalIgnoreCase))
			{
				player.RankColor = value.Color;
			}
		}
		else
		{
			if (!rotateRandomColor && !string.IsNullOrWhiteSpace(player.RankColor))
			{
				return;
			}
			List<string> list = _mgjWpZhslyVxN(player);
			if (list.Count != 0)
			{
				List<string> list2 = list.Where((string candidate) => !string.Equals(candidate, player.RankColor, StringComparison.OrdinalIgnoreCase)).ToList();
				player.RankColor = ((list2.Count > 0) ? list2 : list)[_f72616e646f6d3a300.Next((list2.Count > 0) ? list2.Count : list.Count)];
			}
		}
	}

	private void _m526573746f72653a300(Player player)
	{
		if (player != null && !(player.ReferenceHub == (ReferenceHub)null) && !string.IsNullOrWhiteSpace(player.UserId) && !player.BadgeHidden && _ff5b24f8618c45e36.TryGetValue(NormalizeUserId(player.UserId), out var value))
		{
			player.RankName = value.Name;
			player.RankColor = value.Color;
		}
	}

	private bool _m3db16b9b93c6ec4e(string color, Player preferredPlayer, out string error)
	{
		error = null;
		List<string> list = _mgjWpZhslyVxN(preferredPlayer);
		if (list.Count == 0)
		{
			error = Encoding.UTF8.GetString(Convert.FromBase64String("5b2T5YmN5peg5rOV6K+75Y+W5pyN5Yqh56uvIEJhZGdlIOminOiJsuihqO+8jOivt+WcqOiHs+WwkeS4gOWQjeeOqeWutuWcqOe6v+aXtuiuvue9rue6r+iJsuensOWPt+OAgg=="));
			return false;
		}
		if (!list.Contains(color, StringComparer.OrdinalIgnoreCase))
		{
			error = Encoding.UTF8.GetString(Convert.FromBase64String("5peg5pWI5oiW5Y+X6ZmQ55qEIEJhZGdlIOminOiJsiAn")) + color + Encoding.UTF8.GetString(Convert.FromBase64String("J+OAguWPr+eUqOminOiJsjog")) + string.Join(Encoding.UTF8.GetString(Convert.FromBase64String("LCA=")), list);
			return false;
		}
		return true;
	}

	private static List<string> _mgjWpZhslyVxN(Player preferredPlayer)
	{
		Player val = preferredPlayer;
		if (val == null || val.ReferenceHub == (ReferenceHub)null || (Object)(object)val.ReferenceHub.serverRoles == (Object)null)
		{
			val = Player.List.FirstOrDefault((Player player) => player != null && player.ReferenceHub != (ReferenceHub)null && (Object)(object)player.ReferenceHub.serverRoles != (Object)null);
		}
		if (val == null || val.ReferenceHub.serverRoles.NamedColors == null)
		{
			return new List<string>();
		}
		return (from color in val.ReferenceHub.serverRoles.NamedColors
			where color != null && !color.Restricted && !string.IsNullOrWhiteSpace(color.Name) && !string.Equals(color.Name, Encoding.UTF8.GetString(Convert.FromBase64String("ZGVmYXVsdA==")), StringComparison.OrdinalIgnoreCase)
			select color.Name.ToLowerInvariant()).Distinct(StringComparer.OrdinalIgnoreCase).OrderBy((string color) => color, StringComparer.OrdinalIgnoreCase).ToList();
	}

	private void _mhtsgxczPdaSI()
	{
		_f7265636f7264733a300.Clear();
		try
		{
			if (!File.Exists(DataPath))
			{
				return;
			}
			Dictionary<string, BadgeTitleRecord> dictionary = JsonConvert.DeserializeObject<Dictionary<string, BadgeTitleRecord>>(File.ReadAllText(DataPath));
			if (dictionary == null)
			{
				return;
			}
			foreach (KeyValuePair<string, BadgeTitleRecord> item in dictionary)
			{
				string text = NormalizeUserId(item.Key);
				if (!string.IsNullOrWhiteSpace(text) && item.Value != null && !string.IsNullOrWhiteSpace(item.Value.Title))
				{
					_f7265636f7264733a300[text] = item.Value;
				}
			}
		}
		catch (Exception ex)
		{
			Log.Error(Encoding.UTF8.GetString(Convert.FromBase64String("W0JhZGdlVGl0bGVdIOaXoOazleivu+WPliA=")) + DataPath + Encoding.UTF8.GetString(Convert.FromBase64String("OiA=")) + ex);
		}
	}

	private bool _m168c5bb944c55b8f(out string error)
	{
		error = null;
		try
		{
			Directory.CreateDirectory(Path.GetDirectoryName(DataPath));
			string text = DataPath + Encoding.UTF8.GetString(Convert.FromBase64String("LnRtcA=="));
			File.WriteAllText(text, JsonConvert.SerializeObject((object)_f7265636f7264733a300, (Formatting)1));
			if (File.Exists(DataPath))
			{
				File.Replace(text, DataPath, null);
			}
			else
			{
				File.Move(text, DataPath);
			}
			return true;
		}
		catch (Exception ex)
		{
			error = Encoding.UTF8.GetString(Convert.FromBase64String("5L+d5a2Y56ew5Y+35pWw5o2u5aSx6LSlOiA=")) + ex.Message;
			Log.Error(Encoding.UTF8.GetString(Convert.FromBase64String("W0JhZGdlVGl0bGVdIA==")) + error);
			return false;
		}
	}
}
