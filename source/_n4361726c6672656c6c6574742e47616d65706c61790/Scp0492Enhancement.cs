using System;
using System.Collections.Generic;
using System.Linq;
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

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class Scp0492Enhancement
{
	private const int _fce2d7ac94ea1be4a = 5;

	private const float _f55706772616465645363703034394865616c74683a300 = 200f;

	private const float _f5570677261646548696e74506f736974696f6e3a300 = 300f;

	private const float _fc1df5cf3475efbda = 30f;

	private static readonly IElemReference<SetElement> _f0f2a3d283b3e3f1233342e083f3c606a = DisplayCore.GetReference<SetElement>();

	private readonly Dictionary<int, int> _f313336362918230a363b233f28133e606a = new Dictionary<int, int>();

	private readonly Dictionary<int, Vector3> _f70656e64696e6755706772616465506f736974696f6e733a300 = new Dictionary<int, Vector3>();

	private bool _f656e61626c65643a300;

	public void Enable()
	{
		if (_f656e61626c65643a300)
		{
			return;
		}
		_f656e61626c65643a300 = true;
		Player.Died += _mfcjkSZdMgRiE;
		Player.Spawned += _ma3d4e2d66de93107;
		Player.ChangingRole += _m4f6e4368616e67696e67526f6c653a300;
		Player.Left += _m5895ad191abbde9b;
		Server.RoundStarted += _m4f6e526f756e64537461727465643a300;
		Server.RoundEnded += _m153408352f343e1f343e3f3e606a;
		Server.WaitingForPlayers += _mMKceIZXiqNkP;
		Server.RestartingRound += _m5621ff9eb946101b;
		Player[] array = Player.List.ToArray();
		foreach (Player val in array)
		{
			if (_m4973536370303439323a300(val))
			{
				_f313336362918230a363b233f28133e606a[val.Id] = 0;
			}
		}
	}

	public void Disable()
	{
		if (_f656e61626c65643a300)
		{
			_f656e61626c65643a300 = false;
			Player.Died -= _mfcjkSZdMgRiE;
			Player.Spawned -= _ma3d4e2d66de93107;
			Player.ChangingRole -= _m4f6e4368616e67696e67526f6c653a300;
			Player.Left -= _m5895ad191abbde9b;
			Server.RoundStarted -= _m4f6e526f756e64537461727465643a300;
			Server.RoundEnded -= _m153408352f343e1f343e3f3e606a;
			Server.WaitingForPlayers -= _mMKceIZXiqNkP;
			Server.RestartingRound -= _m5621ff9eb946101b;
			_m19363f3b281b36361233342e29606a();
			_f313336362918230a363b233f28133e606a.Clear();
			_f70656e64696e6755706772616465506f736974696f6e733a300.Clear();
		}
	}

	private void _mfcjkSZdMgRiE(DiedEventArgs ev)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		Player attacker = ev.Attacker;
		if (attacker != null && ev.Player != null && attacker.Id != ev.Player.Id && _m4973536370303439323a300(attacker) && PlayerRolesUtils.IsHuman(ev.TargetOldRole))
		{
			int num = _mbXIEDmxxfZjR(attacker.Id) + 1;
			_f313336362918230a363b233f28133e606a[attacker.Id] = num;
			int num2 = 5 - num;
			if (num2 > 0)
			{
				_maca516c53f34c94d(attacker, num2);
			}
			else
			{
				_m4edfd69c9108ce08(attacker);
			}
		}
	}

	private void _ma3d4e2d66de93107(SpawnedEventArgs ev)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Invalid comparison between Unknown and I4
		Player player = ev.Player;
		if (_m4973536370303439323a300(player))
		{
			_f313336362918230a363b233f28133e606a[player.Id] = 0;
			_f70656e64696e6755706772616465506f736974696f6e733a300.Remove(player.Id);
			_m19363f3b281233342e606a(player);
		}
		else if (player != null && (int)player.Role.Type == 5 && _f70656e64696e6755706772616465506f736974696f6e733a300.ContainsKey(player.Id))
		{
			_mrKHRPEDzPYWL(player);
		}
	}

	private void _m4f6e4368616e67696e67526f6c653a300(ChangingRoleEventArgs ev)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Invalid comparison between Unknown and I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Invalid comparison between Unknown and I4
		if (ev.Player == null)
		{
			return;
		}
		int id = ev.Player.Id;
		_m19363f3b281233342e606a(ev.Player);
		if ((int)ev.NewRole == 10)
		{
			_f313336362918230a363b233f28133e606a[id] = 0;
			_f70656e64696e6755706772616465506f736974696f6e733a300.Remove(id);
			return;
		}
		_f313336362918230a363b233f28133e606a.Remove(id);
		if ((int)ev.NewRole != 5)
		{
			_f70656e64696e6755706772616465506f736974696f6e733a300.Remove(id);
		}
	}

	private void _m5895ad191abbde9b(LeftEventArgs ev)
	{
		if (ev.Player != null)
		{
			_f313336362918230a363b233f28133e606a.Remove(ev.Player.Id);
			_f70656e64696e6755706772616465506f736974696f6e733a300.Remove(ev.Player.Id);
			_m19363f3b281233342e606a(ev.Player);
		}
	}

	private void _m4f6e526f756e64537461727465643a300()
	{
		Reset();
	}

	private void _m153408352f343e1f343e3f3e606a(RoundEndedEventArgs ev)
	{
		Reset();
	}

	private void _mMKceIZXiqNkP()
	{
		Reset();
	}

	private void _m5621ff9eb946101b()
	{
		Reset();
	}

	private void _m4edfd69c9108ce08(Player player)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		if (_m4973536370303439323a300(player))
		{
			int id = player.Id;
			_f70656e64696e6755706772616465506f736974696f6e733a300[id] = player.Position;
			_f313336362918230a363b233f28133e606a.Remove(id);
			_m19363f3b281233342e606a(player);
			player.Role.Set((RoleTypeId)5, (SpawnReason)7, (RoleSpawnFlags)1);
			_mrKHRPEDzPYWL(player);
			Timing.CallDelayed(0f, (Action)delegate
			{
				_mrKHRPEDzPYWL(player);
			});
		}
	}

	private void _mrKHRPEDzPYWL(Player player)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		if (_f656e61626c65643a300 && player != null && !(player.ReferenceHub == (ReferenceHub)null) && player.IsConnected && (int)player.Role.Type == 5 && _f70656e64696e6755706772616465506f736974696f6e733a300.TryGetValue(player.Id, out var value))
		{
			player.Position = value;
			player.MaxHealth = 200f;
			player.Health = 200f;
			_f70656e64696e6755706772616465506f736974696f6e733a300.Remove(player.Id);
			_m19363f3b281233342e606a(player);
		}
	}

	private int _mbXIEDmxxfZjR(int playerId)
	{
		if (!_f313336362918230a363b233f28133e606a.TryGetValue(playerId, out var value))
		{
			return 0;
		}
		return value;
	}

	private static bool _m4973536370303439323a300(Player player)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		if (player != null && player.ReferenceHub != (ReferenceHub)null && player.IsConnected)
		{
			return (int)player.Role.Type == 10;
		}
		return false;
	}

	private static void _maca516c53f34c94d(Player player, int remaining)
	{
		try
		{
			if (player != null && !(player.ReferenceHub == (ReferenceHub)null))
			{
				string content = string.Format(Encoding.UTF8.GetString(Convert.FromBase64String("PGFsaWduPWNlbnRlcj48c2l6ZT17MH0+5YaN5Ye75p2AIDxiPnsxfTwvYj4g5ZCN5Lq657G75Y2z5Y+v5Y2H57qnPC9zaXplPjwvYWxpZ24+")), 30f, remaining);
				DisplayCore displayCore = DisplayCore.Get(player);
				displayCore.SetElementOrNew(_f0f2a3d283b3e3f1233342e083f3c606a, content, 300f);
				displayCore.Update();
			}
		}
		catch (Exception ex)
		{
			Log.Debug(Encoding.UTF8.GetString(Convert.FromBase64String("RmFpbGVkIHRvIHNob3cgU0NQLTA0OS0yIHVwZ3JhZGUgaGludCBmb3IgcGxheWVySWQ9")) + player.Id + Encoding.UTF8.GetString(Convert.FromBase64String("OiA=")) + ex);
		}
	}

	private static void _m19363f3b281233342e606a(Player player)
	{
		if (player == null || player.ReferenceHub == (ReferenceHub)null)
		{
			return;
		}
		try
		{
			DisplayCore displayCore = DisplayCore.Get(player);
			displayCore.SetElementOrNew(_f0f2a3d283b3e3f1233342e083f3c606a, string.Empty, 300f);
			displayCore.Update();
		}
		catch (Exception ex)
		{
			Log.Debug(Encoding.UTF8.GetString(Convert.FromBase64String("RmFpbGVkIHRvIGNsZWFyIFNDUC0wNDktMiB1cGdyYWRlIGhpbnQgZm9yIHBsYXllcklkPQ==")) + player.Id + Encoding.UTF8.GetString(Convert.FromBase64String("OiA=")) + ex);
		}
	}

	private static void _m19363f3b281b36361233342e29606a()
	{
		Player[] array = Player.List.ToArray();
		for (int i = 0; i < array.Length; i++)
		{
			_m19363f3b281233342e606a(array[i]);
		}
	}

	private void Reset()
	{
		_m19363f3b281b36361233342e29606a();
		_f313336362918230a363b233f28133e606a.Clear();
		_f70656e64696e6755706772616465506f736974696f6e733a300.Clear();
	}
}
