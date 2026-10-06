using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exiled.API.Features;
using Exiled.API.Features.Roles;
using MEC;
using RueI.Displays;
using RueI.Elements;
using RueI.Extensions;
using _n4361726c6672656c6c6574740;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class PlayerCountHint
{
	private const float _fRuxpIoYeCOoB = 990f;

	private const float _fCuqjawayiQyD = 1f;

	private static readonly IElemReference<SetElement> _f48696e745265663a300 = DisplayCore.GetReference<SetElement>();

	private static readonly string _fcc47e65a5dfcd752 = typeof(Plugin).Assembly.GetName().Version.ToString(3);

	private CoroutineHandle _fa304dd6efc54ad6f;

	private bool _f7dbe8c87f6ac77c2;

	public void Enable()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		if (!_f7dbe8c87f6ac77c2)
		{
			_f7dbe8c87f6ac77c2 = true;
			_myoHSWdfGlzsj();
			_fa304dd6efc54ad6f = Timing.RunCoroutine(_m526566726573684c6f6f703a300(), (Segment)4);
			Log.Debug(Encoding.UTF8.GetString(Convert.FromBase64String("UGxheWVyLWNvdW50IGFuZCB2ZXJzaW9uIGRpc3BsYXkgZW5hYmxlZC4=")));
		}
	}

	public void Disable()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		if (_f7dbe8c87f6ac77c2)
		{
			_f7dbe8c87f6ac77c2 = false;
			Timing.KillCoroutines((CoroutineHandle[])(object)new CoroutineHandle[1] { _fa304dd6efc54ad6f });
			Player[] array = Player.List.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				_m19363f3b28606a(array[i]);
			}
			Log.Debug(Encoding.UTF8.GetString(Convert.FromBase64String("UGxheWVyLWNvdW50IGFuZCB2ZXJzaW9uIGRpc3BsYXkgZGlzYWJsZWQgYW5kIGNsZWFyZWQu")));
		}
	}

	private IEnumerator<float> _m526566726573684c6f6f703a300()
	{
		while (_f7dbe8c87f6ac77c2)
		{
			yield return Timing.WaitForSeconds(1f);
			if (_f7dbe8c87f6ac77c2)
			{
				_myoHSWdfGlzsj();
			}
		}
	}

	private static void _myoHSWdfGlzsj()
	{
		Player[] array = Player.List.Where(_m4973446973706c617961626c65506c617965723a300).ToArray();
		Dictionary<uint, int> dictionary = _m436f756e74537065637461746f727342795461726765743a300(array);
		Player[] array2 = array;
		foreach (Player val in array2)
		{
			try
			{
				string content;
				if (val.Role is SpectatorRole)
				{
					content = string.Format(Encoding.UTF8.GetString(Convert.FromBase64String("PGFsaWduPWNlbnRlcj48c2l6ZT0xNT57MH0gfCDmnI3liqHlmajkurrmlbAgezF9IHwg6K+V6aqM54mI5pysPC9zaXplPjwvYWxpZ24+")), _fcc47e65a5dfcd752, array.Length);
				}
				else
				{
					dictionary.TryGetValue(val.NetId, out var value);
					content = string.Format(Encoding.UTF8.GetString(Convert.FromBase64String("PGFsaWduPWNlbnRlcj48c2l6ZT0xNT57MH0gfCDmnI3liqHlmajkurrmlbAgezF9IHwg6KeC5LyXIHsyfSB8IOivlemqjOeJiOacrDwvc2l6ZT48L2FsaWduPg==")), _fcc47e65a5dfcd752, array.Length, value);
				}
				DisplayCore displayCore = DisplayCore.Get(val);
				displayCore.SetElementOrNew(_f48696e745265663a300, content, 990f);
				displayCore.Update();
			}
			catch (Exception ex)
			{
				Log.Debug(Encoding.UTF8.GetString(Convert.FromBase64String("SW5kZXBlbmRlbnQgcGxheWVyLWNvdW50IGhpbnQgcmVmcmVzaCBmYWlsZWQgZm9yIHBsYXllcklkPQ==")) + ((val == null) ? (-1) : val.Id) + Encoding.UTF8.GetString(Convert.FromBase64String("OiA=")) + ex);
			}
		}
	}

	private static Dictionary<uint, int> _m436f756e74537065637461746f727342795461726765743a300(IEnumerable<Player> players)
	{
		Dictionary<uint, int> dictionary = new Dictionary<uint, int>();
		foreach (Player player in players)
		{
			Role role = player.Role;
			Role obj = ((role is SpectatorRole) ? role : null);
			Player val = ((obj != null) ? ((SpectatorRole)obj).SpectatedPlayer : null);
			if (_m4973446973706c617961626c65506c617965723a300(val))
			{
				dictionary.TryGetValue(val.NetId, out var value);
				dictionary[val.NetId] = value + 1;
			}
		}
		return dictionary;
	}

	private static bool _m4973446973706c617961626c65506c617965723a300(Player player)
	{
		if (_tFpYLlGZVhITT.IsGameplayPlayer(player))
		{
			return player != Server.Host;
		}
		return false;
	}

	private static void _m19363f3b28606a(Player player)
	{
		if (!_m4973446973706c617961626c65506c617965723a300(player))
		{
			return;
		}
		try
		{
			DisplayCore displayCore = DisplayCore.Get(player);
			displayCore.SetElementOrNew(_f48696e745265663a300, string.Empty, 990f);
			displayCore.Update();
		}
		catch (Exception ex)
		{
			Log.Debug(Encoding.UTF8.GetString(Convert.FromBase64String("SW5kZXBlbmRlbnQgcGxheWVyLWNvdW50IGhpbnQgY2xlYXIgZmFpbGVkIGZvciBwbGF5ZXJJZD0=")) + player.Id + Encoding.UTF8.GetString(Convert.FromBase64String("OiA=")) + ex);
		}
	}
}
