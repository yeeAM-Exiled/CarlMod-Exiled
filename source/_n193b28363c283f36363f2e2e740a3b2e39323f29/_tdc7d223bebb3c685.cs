using System.Collections.Generic;
using Christmas.Scp2536;
using HarmonyLib;
using InventorySystem;
using InventorySystem.Items;
using InventorySystem.Items.Keycards;
using InventorySystem.Items.Pickups;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(Scp2536GiftController), "ServerGrantRandomGift")]
internal static class _tdc7d223bebb3c685
{
	private sealed class _t14c08e3b27efbc4d
	{
		internal ReferenceHub _p6d65426ffb94aadb { get; }

		internal HashSet<ushort> _p4578697374696e6753657269616c733a300 { get; }

		internal _t14c08e3b27efbc4d(ReferenceHub hub)
		{
			_fe0947e4dd277fceb = hub;
			_f3c4578697374696e6753657269616c733e6b5f5f4261636b696e674669656c643a300 = new HashSet<ushort>(hub.inventory.UserInventory.Items.Keys);
		}
	}

	[HarmonyPriority(800)]
	private static void _mLRkPqnIulTTz(ReferenceHub hub, out _t14c08e3b27efbc4d __state)
	{
		__state = ((hub != (ReferenceHub)null && CustomRoleSystem._mXlPQNDWPOAbe(hub)) ? new _t14c08e3b27efbc4d(hub) : null);
	}

	private static void _mVoRJwbSGHxeN(_t14c08e3b27efbc4d __state)
	{
		if (__state != null)
		{
			_m508918c5ef2f3332(__state._p6d65426ffb94aadb, __state._p4578697374696e6753657269616c733a300);
		}
	}

	internal static void _m508918c5ef2f3332(ReferenceHub hub, HashSet<ushort> existingSerials)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (hub == (ReferenceHub)null || existingSerials == null)
		{
			return;
		}
		List<ushort> list = new List<ushort>();
		foreach (KeyValuePair<ushort, ItemBase> item in hub.inventory.UserInventory.Items)
		{
			if (!existingSerials.Contains(item.Key) && !CustomRoleSystem._m193b340a3339310f2a132e3f37606a(hub, item.Value.ItemTypeId))
			{
				list.Add(item.Key);
			}
		}
		foreach (ushort item2 in list)
		{
			InventoryExtensions.ServerRemoveItem(hub.inventory, item2, (ItemPickupBase)null);
		}
	}

	internal static bool _mxjpOfvgeICZC(ReferenceHub hub)
	{
		if (hub == (ReferenceHub)null)
		{
			return false;
		}
		foreach (KeyValuePair<ushort, ItemBase> item in hub.inventory.UserInventory.Items)
		{
			if (!(item.Value is KeycardItem))
			{
				InventoryExtensions.ServerDropItem(hub.inventory, item.Key);
				return true;
			}
		}
		return false;
	}

	internal static bool _md10c11c6f8d3fe5e(ReferenceHub hub, int requiredSlots)
	{
		if (hub == (ReferenceHub)null || requiredSlots < 0)
		{
			return false;
		}
		while (hub.inventory.UserInventory.Items.Count + requiredSlots > 8)
		{
			if (!_mxjpOfvgeICZC(hub))
			{
				return false;
			}
		}
		return true;
	}
}
