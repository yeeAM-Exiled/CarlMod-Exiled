using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.API.Features.Pickups;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Handlers;
using MEC;
using Mirror;
using UnityEngine;
using _n4361726c6672656c6c6574740;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class UnlimitedAmmo
{
	private const float _f436c65616e757044656c61795365636f6e64733a300 = 0.1f;

	private static readonly AmmoType[] _f6fc1b49983c3e3b2;

	private static readonly List<Pickup> _f436c65616e75704275666665723a300;

	private bool _f7dbe8c87f6ac77c2;

	private bool _f636c65616e75705175657565643a300;

	public UnlimitedAmmo(Plugin plugin)
	{
	}

	public void Enable()
	{
		if (!_f7dbe8c87f6ac77c2)
		{
			_f7dbe8c87f6ac77c2 = true;
			Player.ReloadingWeapon += _m6eddc3246d73a711;
			Player.DroppingAmmo += _m4f6e44726f7070696e67416d6d6f3a300;
			Player.Handcuffing += _m4f6e48616e6463756666696e673a300;
			Player.Died += _mYoPHNHvIpUEX;
			Server.RoundStarted += _m153408352f343e092e3b282e3f3e606a;
			_m19363f3b340d3528363e1b3737350a3339312f2a29606a();
		}
	}

	public void Disable()
	{
		if (_f7dbe8c87f6ac77c2)
		{
			_f7dbe8c87f6ac77c2 = false;
			Player.ReloadingWeapon -= _m6eddc3246d73a711;
			Player.DroppingAmmo -= _m4f6e44726f7070696e67416d6d6f3a300;
			Player.Handcuffing -= _m4f6e48616e6463756666696e673a300;
			Player.Died -= _mYoPHNHvIpUEX;
			Server.RoundStarted -= _m153408352f343e092e3b282e3f3e606a;
			_f636c65616e75705175657565643a300 = false;
			_f436c65616e75704275666665723a300.Clear();
		}
	}

	private void _m6eddc3246d73a711(ReloadingWeaponEventArgs ev)
	{
		_m1f5da5df790da3c4(ev.Player);
	}

	private void _m4f6e44726f7070696e67416d6d6f3a300(DroppingAmmoEventArgs ev)
	{
		ev.IsAllowed = false;
	}

	private void _m4f6e48616e6463756666696e673a300(HandcuffingEventArgs ev)
	{
		if (ev.IsAllowed)
		{
			_m552ad82ec0636b36(ev.Player);
		}
	}

	private void _mYoPHNHvIpUEX(DiedEventArgs ev)
	{
		_m552ad82ec0636b36(ev.Player);
		_m0b2f3f2f3f1b37373519363f3b342f2a606a();
	}

	private void _m153408352f343e092e3b282e3f3e606a()
	{
		_m19363f3b340d3528363e1b3737350a3339312f2a29606a();
	}

	private static void _m1f5da5df790da3c4(Player player)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_007d: Expected I4, but got Unknown
		if (player == null || player.ReferenceHub == (ReferenceHub)null)
		{
			return;
		}
		ushort num = 0;
		ushort num2 = 0;
		ushort num3 = 0;
		ushort num4 = 0;
		ushort num5 = 0;
		foreach (Item item in player.Items)
		{
			Firearm val = (Firearm)(object)((item is Firearm) ? item : null);
			if (val != null)
			{
				ushort val2 = (ushort)Math.Min(65535, val.MaxAmmo + 1);
				AmmoType ammoType = val.AmmoType;
				switch (ammoType - 1)
				{
				case 2:
					num = Math.Max(num, val2);
					break;
				case 0:
					num2 = Math.Max(num2, val2);
					break;
				case 1:
					num3 = Math.Max(num3, val2);
					break;
				case 3:
					num4 = Math.Max(num4, val2);
					break;
				case 4:
					num5 = Math.Max(num5, val2);
					break;
				}
			}
		}
		_m536574416d6d6f49664368616e6765643a300(player, (AmmoType)3, num);
		_m536574416d6d6f49664368616e6765643a300(player, (AmmoType)1, num2);
		_m536574416d6d6f49664368616e6765643a300(player, (AmmoType)2, num3);
		_m536574416d6d6f49664368616e6765643a300(player, (AmmoType)4, num4);
		_m536574416d6d6f49664368616e6765643a300(player, (AmmoType)5, num5);
	}

	private static void _m552ad82ec0636b36(Player player)
	{
		if (player != null && !(player.ReferenceHub == (ReferenceHub)null))
		{
			for (int i = 0; i < _f6fc1b49983c3e3b2.Length; i++)
			{
				_m536574416d6d6f49664368616e6765643a300(player, _f6fc1b49983c3e3b2[i], 0);
			}
		}
	}

	private static void _m536574416d6d6f49664368616e6765643a300(Player player, AmmoType ammoType, ushort amount)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		if (player.GetAmmo(ammoType) != amount)
		{
			player.SetAmmo(ammoType, amount);
		}
	}

	private void _m0b2f3f2f3f1b37373519363f3b342f2a606a()
	{
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		if (!_f7dbe8c87f6ac77c2 || _f636c65616e75705175657565643a300)
		{
			return;
		}
		_f636c65616e75705175657565643a300 = true;
		Timing.CallDelayed(0.1f, (Action)delegate
		{
			_f636c65616e75705175657565643a300 = false;
			if (_f7dbe8c87f6ac77c2)
			{
				_m19363f3b340d3528363e1b3737350a3339312f2a29606a();
			}
		});
	}

	private static void _m19363f3b340d3528363e1b3737350a3339312f2a29606a()
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		_f436c65616e75704275666665723a300.Clear();
		foreach (Pickup item in Pickup.List)
		{
			if (item != null && ItemExtensions.IsAmmo(item.Type))
			{
				_f436c65616e75704275666665723a300.Add(item);
			}
		}
		for (int i = 0; i < _f436c65616e75704275666665723a300.Count; i++)
		{
			Pickup val = _f436c65616e75704275666665723a300[i];
			if (val != null)
			{
				if ((Object)(object)val.GameObject != (Object)null)
				{
					NetworkServer.Destroy(val.GameObject);
				}
				else
				{
					val.Destroy();
				}
			}
		}
		_f436c65616e75704275666665723a300.Clear();
	}

	static UnlimitedAmmo()
	{
		AmmoType[] array = new AmmoType[5];
		RuntimeHelpers.InitializeArray(array, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		_f6fc1b49983c3e3b2 = (AmmoType[])(object)array;
		_f436c65616e75704275666665723a300 = new List<Pickup>(32);
	}

	[CompilerGenerated]
	private void _mIYaUKMXsvZJi()
	{
		_f636c65616e75705175657565643a300 = false;
		if (_f7dbe8c87f6ac77c2)
		{
			_m19363f3b340d3528363e1b3737350a3339312f2a29606a();
		}
	}
}
