using CustomPlayerEffects;
using Exiled.API.Enums;
using Exiled.API.Features;
using Exiled.API.Features.Items;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Handlers;
using Interactables.Interobjects.DoorUtils;
using UnityEngine;
using _n4361726c6672656c6c6574740;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class RemoteKeycard
{
	private bool _f7dbe8c87f6ac77c2;

	public RemoteKeycard(Plugin plugin)
	{
	}

	public void Enable()
	{
		if (!_f7dbe8c87f6ac77c2)
		{
			_f7dbe8c87f6ac77c2 = true;
			Player.InteractingDoor += _m4f6e496e746572616374696e67446f6f723a300;
			Player.UnlockingGenerator += _mfivUSHQijkzv;
			Player.InteractingLocker += _m4f6e496e746572616374696e674c6f636b65723a300;
			Player.ActivatingWarheadPanel += _m4f6e41637469766174696e675761726865616450616e656c3a300;
		}
	}

	public void Disable()
	{
		if (_f7dbe8c87f6ac77c2)
		{
			_f7dbe8c87f6ac77c2 = false;
			Player.InteractingDoor -= _m4f6e496e746572616374696e67446f6f723a300;
			Player.UnlockingGenerator -= _mfivUSHQijkzv;
			Player.InteractingLocker -= _m4f6e496e746572616374696e674c6f636b65723a300;
			Player.ActivatingWarheadPanel -= _m4f6e41637469766174696e675761726865616450616e656c3a300;
		}
	}

	private static void _m4f6e496e746572616374696e67446f6f723a300(InteractingDoorEventArgs ev)
	{
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		if (!ev.IsAllowed && ev.Player != null && ev.Door != null && !((Object)(object)ev.Door.Base == (Object)null) && !_m4973426c6f636b65644279446f6f724c6f636b3a300(ev.Player, ev.Door.Base))
		{
			DoorPermissions requiredPermissions = ev.Door.RequiredPermissions;
			if (requiredPermissions != null)
			{
				KeycardPermissions requiredPermissions2 = (KeycardPermissions)requiredPermissions.RequiredPermissions;
				ev.IsAllowed = _m486173496e76656e746f72795065726d697373696f6e3a300(ev.Player, requiredPermissions2, requiredPermissions.RequireAll);
			}
		}
	}

	private static void _mfivUSHQijkzv(UnlockingGeneratorEventArgs ev)
	{
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		if (!ev.IsAllowed && ev.Player != null && ev.Generator != null)
		{
			ev.IsAllowed = _m486173496e76656e746f72795065726d697373696f6e3a300(ev.Player, ev.Generator.KeycardPermissions, requireAll: true);
		}
	}

	private static void _m4f6e496e746572616374696e674c6f636b65723a300(InteractingLockerEventArgs ev)
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		if (!ev.IsAllowed && ev.Player != null && !((Object)(object)ev.Chamber == (Object)null))
		{
			KeycardPermissions requiredPermissions = (KeycardPermissions)ev.Chamber.RequiredPermissions;
			ev.IsAllowed = _m486173496e76656e746f72795065726d697373696f6e3a300(ev.Player, requiredPermissions, requireAll: true);
		}
	}

	private static void _m4f6e41637469766174696e675761726865616450616e656c3a300(ActivatingWarheadPanelEventArgs ev)
	{
		if (!ev.IsAllowed && ev.Player != null)
		{
			ev.IsAllowed = _m486173496e76656e746f72795065726d697373696f6e3a300(ev.Player, (KeycardPermissions)8, requireAll: true);
		}
	}

	private static bool _m486173496e76656e746f72795065726d697373696f6e3a300(Player player, KeycardPermissions requiredPermissions, bool requireAll)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Invalid comparison between Unknown and I4
		if (player == null || player.ReferenceHub == (ReferenceHub)null || (int)requiredPermissions == 0)
		{
			return false;
		}
		AmnesiaItems effect = player.ReferenceHub.playerEffectsController.GetEffect<AmnesiaItems>();
		if ((Object)(object)effect != (Object)null && ((StatusEffectBase)effect).IsEnabled)
		{
			return false;
		}
		foreach (Item item in player.Items)
		{
			Keycard val = (Keycard)(object)((item is Keycard) ? item : null);
			if (val != null && !((Object)(object)val.Base == (Object)null))
			{
				KeycardPermissions permissions = val.Permissions;
				if (requireAll ? ((KeycardPermissions)(permissions & requiredPermissions) == requiredPermissions) : ((permissions & requiredPermissions) > 0))
				{
					return true;
				}
			}
		}
		return false;
	}

	private static bool _m4973426c6f636b65644279446f6f724c6f636b3a300(Player player, DoorVariant door)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Invalid comparison between Unknown and I4
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Invalid comparison between Unknown and I4
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Invalid comparison between Unknown and I4
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (player == null || (Object)(object)door == (Object)null || door.ActiveLocks == 0 || player.IsBypassModeEnabled)
		{
			return false;
		}
		DoorLockMode mode = DoorLockUtils.GetMode((DoorLockReason)door.ActiveLocks);
		bool flag = (mode & 1) == 1;
		bool flag2 = (mode & 2) == 2;
		if ((mode & 4) == 4 && player.IsScp)
		{
			return false;
		}
		if ((int)mode != 0 && (!door.TargetState || flag2))
		{
			if (!door.TargetState)
			{
				return !flag;
			}
			return false;
		}
		return true;
	}
}
