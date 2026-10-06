using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using Exiled.Events.Handlers;
using RueI.Displays;
using RueI.Elements;
using RueI.Extensions;
using _n4361726c6672656c6c6574740;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class RoundMvpDisplay
{
	private sealed class _t506c6179657253746174733a300
	{
		public string UserId { get; }

		public string Name { get; set; }

		public int Kills { get; set; }

		public float Damage { get; set; }

		public int Deaths { get; set; }

		public float Score { get; set; }

		public HashSet<ushort> PickedUpItemSerials { get; }

		public bool HasActivity
		{
			get
			{
				if (Kills <= 0 && !(Damage > 0f) && Deaths <= 0)
				{
					return Score != 0f;
				}
				return true;
			}
		}

		public _t506c6179657253746174733a300(string userId)
		{
			_f1d3caadb2ef77a85 = new HashSet<ushort>();
			base._002Ector();
			_f3c5573657249643e6b5f5f4261636b696e674669656c643a300 = userId;
		}
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _t8f709c079eafafc1
	{
		public static readonly _t8f709c079eafafc1 _003C_003E9 = new _t8f709c079eafafc1();

		public static Func<_t506c6179657253746174733a300, bool> _003C_003E9__22_0;

		public static Func<_t506c6179657253746174733a300, float> _003C_003E9__22_1;

		public static Func<_t506c6179657253746174733a300, int> _003C_003E9__22_2;

		public static Func<_t506c6179657253746174733a300, float> _003C_003E9__22_3;

		public static Func<_t506c6179657253746174733a300, int> _003C_003E9__22_4;

		public static Func<Player, bool> _003C_003E9__22_6;

		public static Func<_t506c6179657253746174733a300, bool> _003C_003E9__35_0;

		public static Func<_t506c6179657253746174733a300, float> _003C_003E9__35_1;

		public static Func<_t506c6179657253746174733a300, int> _003C_003E9__35_2;

		public static Func<_t506c6179657253746174733a300, float> _003C_003E9__35_3;

		public static Func<_t506c6179657253746174733a300, int> _003C_003E9__35_4;

		internal bool _m27d4446d8d921d2a(_t506c6179657253746174733a300 candidate)
		{
			return candidate.HasActivity;
		}

		internal float _m454536fbbdfd7d0c(_t506c6179657253746174733a300 candidate)
		{
			return candidate.Score;
		}

		internal int _m661d3f2e092c2a0a363b233f286438050568680568606a(_t506c6179657253746174733a300 candidate)
		{
			return candidate.Kills;
		}

		internal float _mTkgDGlGIeVfj(_t506c6179657253746174733a300 candidate)
		{
			return candidate.Damage;
		}

		internal int _m661d3f2e092c2a0a363b233f28643805056868056e606a(_t506c6179657253746174733a300 candidate)
		{
			return candidate.Deaths;
		}

		internal bool _m3c476574537670506c617965723e625f5f32325f363a300(Player player)
		{
			return player != null;
		}

		internal bool _m661c33343e172c2a64380505696f056a606a(_t506c6179657253746174733a300 candidate)
		{
			return candidate.HasActivity;
		}

		internal float _m3c46696e644d76703e625f5f33355f313a300(_t506c6179657253746174733a300 candidate)
		{
			return candidate.Score;
		}

		internal int _ma7d305b88e0c138d(_t506c6179657253746174733a300 candidate)
		{
			return candidate.Kills;
		}

		internal float _m661c33343e172c2a64380505696f0569606a(_t506c6179657253746174733a300 candidate)
		{
			return candidate.Damage;
		}

		internal int _m3c46696e644d76703e625f5f33355f343a300(_t506c6179657253746174733a300 candidate)
		{
			return candidate.Deaths;
		}
	}

	private const float _f5469746c65506f736974696f6e3a300 = 900f;

	private const float _f01299191dc50c5f6 = 850f;

	private const float _f093935283f0a3529332e333534606a = 810f;

	private const float _fJXmuzyKxTIhy = 770f;

	private const float _fvwsyWwwnKBNO = 55f;

	private const float _f506c617965724e616d6553697a653a300 = 40f;

	private const float _f1c2be0d9c903e92c = 28f;

	private static readonly IElemReference<SetElement> _f5469746c655265663a300 = DisplayCore.GetReference<SetElement>();

	private static readonly IElemReference<SetElement> _fSSPeiWPMaGIL = DisplayCore.GetReference<SetElement>();

	private static readonly IElemReference<SetElement> _f093935283f083f3c606a = DisplayCore.GetReference<SetElement>();

	private static readonly IElemReference<SetElement> _f092e3b2e29083f3c606a = DisplayCore.GetReference<SetElement>();

	private readonly RoundMvpConfig _f3935343c333d606a;

	private readonly Dictionary<string, _t506c6179657253746174733a300> _fRyEGJdwRdQXB = new Dictionary<string, _t506c6179657253746174733a300>();

	public static RoundMvpDisplay Instance { get; private set; }

	public RoundMvpDisplay(RoundMvpConfig config)
	{
		_f3935343c333d606a = config ?? new RoundMvpConfig();
	}

	public void Enable()
	{
		Instance = this;
		Player.Hurting += _m1534122f282e33343d606a;
		Player.Died += _m4f6e446965643a300;
		Player.PickingUpItem += _m15340a33393133343d0f2a132e3f37606a;
		Player.UsedItem += _m3f6db6586448d855;
		Server.RoundStarted += _m153408352f343e092e3b282e3f3e606a;
		Server.RoundEnded += _mXYgUSeklwZAV;
		Server.WaitingForPlayers += _ma1729e593cb3db56;
		Server.RestartingRound += _m1534083f292e3b282e33343d08352f343e606a;
	}

	public void Disable()
	{
		Player.Hurting -= _m1534122f282e33343d606a;
		Player.Died -= _m4f6e446965643a300;
		Player.PickingUpItem -= _m15340a33393133343d0f2a132e3f37606a;
		Player.UsedItem -= _m3f6db6586448d855;
		Server.RoundStarted -= _m153408352f343e092e3b282e3f3e606a;
		Server.RoundEnded -= _mXYgUSeklwZAV;
		Server.WaitingForPlayers -= _ma1729e593cb3db56;
		Server.RestartingRound -= _m1534083f292e3b282e33343d08352f343e606a;
		_fRyEGJdwRdQXB.Clear();
		_m436c656172416c6c506c61796572733a300();
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public Player GetMvpPlayer()
	{
		_t506c6179657253746174733a300 mvp = _m1c33343e172c2a606a();
		if (mvp == null)
		{
			return null;
		}
		return Player.List.FirstOrDefault((Player player) => player != null && string.Equals(_m1d3f2e0a363b233f28113f23606a(player), mvp.UserId, StringComparison.OrdinalIgnoreCase));
	}

	public string GetMvpUserId()
	{
		return _m1c33343e172c2a606a()?.UserId;
	}

	public Player GetSvpPlayer(LeadingTeam losingTeam)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		return (from candidate in _fRyEGJdwRdQXB.Values
			where candidate.HasActivity
			orderby candidate.Score descending, candidate.Kills descending, candidate.Damage descending, candidate.Deaths
			select Player.List.FirstOrDefault((Player player) => player != null && player.LeadingTeam == losingTeam && string.Equals(_m1d3f2e0a363b233f28113f23606a(player), candidate.UserId, StringComparison.OrdinalIgnoreCase))).FirstOrDefault((Player player) => player != null);
	}

	private void _m1534122f282e33343d606a(HurtingEventArgs ev)
	{
		if (ev.IsAllowed && ev.Attacker != null && ev.Player != null && !(ev.Amount <= 0f) && ev.Attacker.Id != ev.Player.Id)
		{
			_t506c6179657253746174733a300 t506c6179657253746174733a = _m1d3f2e092e3b2e29606a(ev.Attacker);
			t506c6179657253746174733a.Damage += ev.Amount;
			t506c6179657253746174733a.Score += ev.Amount * _f3935343c333d606a.DamageScore;
		}
	}

	private void _m4f6e446965643a300(DiedEventArgs ev)
	{
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		if (ev.Player != null)
		{
			_t506c6179657253746174733a300 t506c6179657253746174733a = _m1d3f2e092e3b2e29606a(ev.Player);
			t506c6179657253746174733a.Deaths++;
			t506c6179657253746174733a.Score -= _f3935343c333d606a.DeathPenalty;
		}
		if (ev.Attacker != null && ev.Player != null && ev.Attacker.Id != ev.Player.Id)
		{
			_t506c6179657253746174733a300 t506c6179657253746174733a2 = _m1d3f2e092e3b2e29606a(ev.Attacker);
			t506c6179657253746174733a2.Kills++;
			if (ev.Attacker.IsScp)
			{
				t506c6179657253746174733a2.Score += _f3935343c333d606a.ScpKillScore;
			}
			else if ((int)RoleExtensions.GetTeam(ev.TargetOldRole) == 0)
			{
				t506c6179657253746174733a2.Score += _f3935343c333d606a.HumanKillsScpScore;
			}
			else
			{
				t506c6179657253746174733a2.Score += _f3935343c333d606a.HumanKillsHumanScore;
			}
		}
	}

	private void _m15340a33393133343d0f2a132e3f37606a(PickingUpItemEventArgs ev)
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		if (ev.IsAllowed && ev.Player != null && ev.Pickup != null)
		{
			_t506c6179657253746174733a300 t506c6179657253746174733a = _m1d3f2e092e3b2e29606a(ev.Player);
			if (t506c6179657253746174733a.PickedUpItemSerials.Add(ev.Pickup.Serial))
			{
				t506c6179657253746174733a.Score += _m4765745069636b757053636f72653a300(ev.Pickup.Type);
			}
		}
	}

	private void _m3f6db6586448d855(UsedItemEventArgs ev)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		if (ev.Player != null && ev.Item != null && ItemExtensions.IsMedical(((Item)ev.Item).Type))
		{
			_m1d3f2e092e3b2e29606a(ev.Player).Score += _f3935343c333d606a.MedicalItemUseScore;
		}
	}

	private float _m4765745069636b757053636f72653a300(ItemType itemType)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Invalid comparison between Unknown and I4
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Invalid comparison between Unknown and I4
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		if ((int)itemType == 16)
		{
			return _f3935343c333d606a.MicroHidPickupScore;
		}
		if ((int)itemType == 47)
		{
			return _f3935343c333d606a.ParticleDisruptorPickupScore;
		}
		if (ItemExtensions.IsScp(itemType))
		{
			return _f3935343c333d606a.ScpItemPickupScore;
		}
		if (ItemExtensions.IsWeapon(itemType, true))
		{
			return _f3935343c333d606a.WeaponPickupScore;
		}
		return _f3935343c333d606a.OtherItemPickupScore;
	}

	private void _m153408352f343e092e3b282e3f3e606a()
	{
		Reset();
	}

	private void _mXYgUSeklwZAV(RoundEndedEventArgs ev)
	{
		_m53686f774d76703a300();
	}

	private void _ma1729e593cb3db56()
	{
		Reset();
	}

	private void _m1534083f292e3b282e33343d08352f343e606a()
	{
		Reset();
	}

	private void Reset()
	{
		_fRyEGJdwRdQXB.Clear();
		_m436c656172416c6c506c61796572733a300();
	}

	private _t506c6179657253746174733a300 _m1d3f2e092e3b2e29606a(Player player)
	{
		string text = _m1d3f2e0a363b233f28113f23606a(player);
		if (!_fRyEGJdwRdQXB.TryGetValue(text, out var value))
		{
			value = new _t506c6179657253746174733a300(text);
			_fRyEGJdwRdQXB[text] = value;
		}
		value.Name = player.Nickname;
		return value;
	}

	private void _m53686f774d76703a300()
	{
		_t506c6179657253746174733a300 t506c6179657253746174733a = _m1c33343e172c2a606a();
		if (t506c6179657253746174733a == null)
		{
			_m436c656172416c6c506c61796572733a300();
			return;
		}
		foreach (Player item in Player.List.ToList())
		{
			if (_tFpYLlGZVhITT.IsGameplayPlayer(item))
			{
				_m7f97dbdd1b4135b0(item, t506c6179657253746174733a);
			}
		}
	}

	private _t506c6179657253746174733a300 _m1c33343e172c2a606a()
	{
		return (from candidate in _fRyEGJdwRdQXB.Values
			where candidate.HasActivity
			orderby candidate.Score descending, candidate.Kills descending, candidate.Damage descending, candidate.Deaths
			select candidate).FirstOrDefault();
	}

	private static void _m7f97dbdd1b4135b0(Player player, _t506c6179657253746174733a300 mvp)
	{
		if (player != null && !(player.ReferenceHub == (ReferenceHub)null))
		{
			DisplayCore displayCore = DisplayCore.Get(player);
			displayCore.SetElementOrNew(_f5469746c655265663a300, _m3ddaa44b427fa5a1(), 900f);
			displayCore.SetElementOrNew(_fSSPeiWPMaGIL, _mbfe10f80d9500dd7(mvp.Name), 850f);
			displayCore.SetElementOrNew(_f093935283f083f3c606a, _m4275696c644c696e653a300(Encoding.UTF8.GetString(Convert.FromBase64String("PGNvbG9yPSNGRkQ3MDA+57uT566X5YiG5pWwPC9jb2xvcj46IDxjb2xvcj0jRkZGRkZGPjxiPg==")) + _m1c3528373b2e142f37383f28606a(mvp.Score) + Encoding.UTF8.GetString(Convert.FromBase64String("PC9iPjwvY29sb3I+"))), 810f);
			displayCore.SetElementOrNew(_f092e3b2e29083f3c606a, _m4275696c644c696e653a300(Encoding.UTF8.GetString(Convert.FromBase64String("PGNvbG9yPSNGRkZGRkY+fCDlh7vmnYAg")) + mvp.Kills + Encoding.UTF8.GetString(Convert.FromBase64String("IHwg5Lyk5a6zIA==")) + _m1c3528373b2e142f37383f28606a(mvp.Damage) + Encoding.UTF8.GetString(Convert.FromBase64String("IHwg5q275LqhIA==")) + mvp.Deaths + Encoding.UTF8.GetString(Convert.FromBase64String("IHw8L2NvbG9yPg=="))), 770f);
			displayCore.Update();
		}
	}

	private static void _m436c656172416c6c506c61796572733a300()
	{
		foreach (Player item in Player.List.ToList())
		{
			if (_tFpYLlGZVhITT.IsGameplayPlayer(item))
			{
				_mbb25e63f765cc8fe(item);
			}
		}
	}

	private static void _mbb25e63f765cc8fe(Player player)
	{
		if (player != null && !(player.ReferenceHub == (ReferenceHub)null))
		{
			DisplayCore displayCore = DisplayCore.Get(player);
			displayCore.SetElementOrNew(_f5469746c655265663a300, string.Empty, 900f);
			displayCore.SetElementOrNew(_fSSPeiWPMaGIL, string.Empty, 850f);
			displayCore.SetElementOrNew(_f093935283f083f3c606a, string.Empty, 810f);
			displayCore.SetElementOrNew(_f092e3b2e29083f3c606a, string.Empty, 770f);
			displayCore.Update();
		}
	}

	private static string _m3ddaa44b427fa5a1()
	{
		return string.Format(Encoding.UTF8.GetString(Convert.FromBase64String("PGFsaWduPWNlbnRlcj48c2l6ZT17MH0+PGNvbG9yPSNGRkQ3MDA+PGI+4piFIE0gViBQIOKYhTwvYj48L2NvbG9yPjwvc2l6ZT48L2FsaWduPg==")), 55f);
	}

	private static string _mbfe10f80d9500dd7(string playerName)
	{
		return string.Format(Encoding.UTF8.GetString(Convert.FromBase64String("PGFsaWduPWNlbnRlcj48c2l6ZT17MH0+PGNvbG9yPSNGRkZGRkY+ezF9PC9jb2xvcj48L3NpemU+PC9hbGlnbj4=")), 40f, _m1f29393b2a3f083339320e3f222e606a(playerName));
	}

	private static string _m4275696c644c696e653a300(string text)
	{
		return string.Format(Encoding.UTF8.GetString(Convert.FromBase64String("PGFsaWduPWNlbnRlcj48c2l6ZT17MH0+ezF9PC9zaXplPjwvYWxpZ24+")), 28f, text);
	}

	private static string _m1c3528373b2e142f37383f28606a(float value)
	{
		return value.ToString(Encoding.UTF8.GetString(Convert.FromBase64String("MA==")));
	}

	private static string _m1d3f2e0a363b233f28113f23606a(Player player)
	{
		if (string.IsNullOrEmpty(player.UserId))
		{
			return Encoding.UTF8.GetString(Convert.FromBase64String("cGxheWVyOg==")) + player.Id;
		}
		return player.UserId;
	}

	private static string _m1f29393b2a3f083339320e3f222e606a(string text)
	{
		if (string.IsNullOrEmpty(text))
		{
			return string.Empty;
		}
		return text.Replace(Encoding.UTF8.GetString(Convert.FromBase64String("Jg==")), Encoding.UTF8.GetString(Convert.FromBase64String("JmFtcDs="))).Replace(Encoding.UTF8.GetString(Convert.FromBase64String("PA==")), Encoding.UTF8.GetString(Convert.FromBase64String("Jmx0Ow=="))).Replace(Encoding.UTF8.GetString(Convert.FromBase64String("Pg==")), Encoding.UTF8.GetString(Convert.FromBase64String("Jmd0Ow==")));
	}
}
