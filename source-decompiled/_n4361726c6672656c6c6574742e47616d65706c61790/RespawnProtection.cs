using System;
using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.API.Features.DamageHandlers;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using Exiled.Events.Handlers;
using MEC;
using UnityEngine;
using _n193b28363c283f36363f2e2e740a3b2e39323f29;
using _n4361726c6672656c6c6574740;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class RespawnProtection
{
	private readonly RespawnProtectionConfig _f636f6e6669673a300;

	private readonly Dictionary<int, float> _fc40d0497fd1bc904 = new Dictionary<int, float>();

	private bool _f33291f343b38363f3e606a;

	private int _fRtixrAcNiXUU;

	public RespawnProtection(RespawnProtectionConfig config)
	{
		_f636f6e6669673a300 = config ?? new RespawnProtectionConfig();
	}

	public void Enable()
	{
		if (!_f33291f343b38363f3e606a)
		{
			_f33291f343b38363f3e606a = true;
			Server.RespawningTeam += _mFekvjyDvkweQ;
			Server.WaitingForPlayers += _mtbdBYwuThOYA;
			Server.RestartingRound += _mtbdBYwuThOYA;
			Player.Hurting += _m4f6e48757274696e673a300;
			Player.Shooting += _m1534093235352e33343d606a;
			Player.ChangingRole += _m153419323b343d33343d0835363f606a;
			Player.Died += _m259dced7c59bda58;
			Player.Left += _m1534163f3c2e606a;
		}
	}

	public void Disable()
	{
		if (_f33291f343b38363f3e606a)
		{
			_f33291f343b38363f3e606a = false;
			Server.RespawningTeam -= _mFekvjyDvkweQ;
			Server.WaitingForPlayers -= _mtbdBYwuThOYA;
			Server.RestartingRound -= _mtbdBYwuThOYA;
			Player.Hurting -= _m4f6e48757274696e673a300;
			Player.Shooting -= _m1534093235352e33343d606a;
			Player.ChangingRole -= _m153419323b343d33343d0835363f606a;
			Player.Died -= _m259dced7c59bda58;
			Player.Left -= _m1534163f3c2e606a;
			_fRtixrAcNiXUU++;
			_fc40d0497fd1bc904.Clear();
		}
	}

	private void _mFekvjyDvkweQ(RespawningTeamEventArgs ev)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		if (_f33291f343b38363f3e606a && _f636f6e6669673a300.IsEnabled && ev.IsAllowed && !(_f636f6e6669673a300.DurationSeconds <= 0f))
		{
			List<Player> respawningPlayers = ev.Players;
			int generation = _fRtixrAcNiXUU;
			Timing.CallDelayed(0f, (Action)delegate
			{
				_m416374697661746550726f74656374696f6e3a300(respawningPlayers, generation);
			});
		}
	}

	private void _m416374697661746550726f74656374696f6e3a300(IEnumerable<Player> players, int generation)
	{
		if (!_f33291f343b38363f3e606a || !_f636f6e6669673a300.IsEnabled || generation != _fRtixrAcNiXUU)
		{
			return;
		}
		float value = Time.realtimeSinceStartup + _f636f6e6669673a300.DurationSeconds;
		foreach (Player player in players)
		{
			if (player != null && player.IsAlive)
			{
				_fc40d0497fd1bc904[player.Id] = value;
			}
		}
	}

	private void _m4f6e48757274696e673a300(HurtingEventArgs ev)
	{
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Invalid comparison between Unknown and I4
		if (ev.IsAllowed && ev.Player != null && ev.Attacker != null && ev.Player.Id != ev.Attacker.Id && _mDqhqyynoYvHB(ev.Player) && (ev.DamageHandler == null || (int)((DamageHandlerBase)ev.DamageHandler).Type != 11 || !_t0a333431193b343e231f222a3635293335341935342e3f222e606a._md7e3b3f68fc306a8(ev.Attacker.ReferenceHub)))
		{
			ev.Amount = 0f;
			ev.IsAllowed = false;
		}
	}

	private void _m1534093235352e33343d606a(ShootingEventArgs ev)
	{
		if (ev.IsAllowed && ev.Player != null)
		{
			_fc40d0497fd1bc904.Remove(ev.Player.Id);
		}
	}

	private void _m153419323b343d33343d0835363f606a(ChangingRoleEventArgs ev)
	{
		_m083f37352c3f0a28352e3f392e333534606a(ev.Player);
	}

	private void _m259dced7c59bda58(DiedEventArgs ev)
	{
		_m083f37352c3f0a28352e3f392e333534606a(ev.Player);
	}

	private void _m1534163f3c2e606a(LeftEventArgs ev)
	{
		_m083f37352c3f0a28352e3f392e333534606a(ev.Player);
	}

	private bool _mDqhqyynoYvHB(Player player)
	{
		if (!_f636f6e6669673a300.IsEnabled || !_fc40d0497fd1bc904.TryGetValue(player.Id, out var value))
		{
			return false;
		}
		if (Time.realtimeSinceStartup < value)
		{
			return true;
		}
		_fc40d0497fd1bc904.Remove(player.Id);
		return false;
	}

	private void _m083f37352c3f0a28352e3f392e333534606a(Player player)
	{
		if (player != null)
		{
			_fc40d0497fd1bc904.Remove(player.Id);
		}
	}

	private void _mtbdBYwuThOYA()
	{
		_fRtixrAcNiXUU++;
		_fc40d0497fd1bc904.Clear();
	}
}
