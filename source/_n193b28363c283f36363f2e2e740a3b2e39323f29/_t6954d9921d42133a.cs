using Christmas.Scp2536;
using Christmas.Scp2536.Gifts;
using HarmonyLib;
using InventorySystem;
using InventorySystem.Items;
using InventorySystem.Items.Keycards;
using InventorySystem.Items.Pickups;
using UnityEngine;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(KeycardUpgrade), "ServerGrant")]
internal static class _t6954d9921d42133a
{
	private static bool _meYSNVZgfviqb(ReferenceHub hub)
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009a: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		KeycardItem val = null;
		int num = -1;
		foreach (ItemBase value in hub.inventory.UserInventory.Items.Values)
		{
			KeycardItem val2 = (KeycardItem)(object)((value is KeycardItem) ? value : null);
			if (!((Object)(object)val2 == (Object)null))
			{
				int num2 = _m52616e6b3a300(((ItemBase)val2).ItemTypeId);
				if (num2 > num && num2 < 6)
				{
					val = val2;
					num = num2;
				}
			}
		}
		if ((Object)(object)val == (Object)null)
		{
			return false;
		}
		InventoryExtensions.ServerRemoveItem(hub.inventory, ((ItemBase)val).ItemSerial, (ItemPickupBase)null);
		ItemType val3 = (ItemType)((Random.value < 0.1f) ? 11 : ((int)_me3213e1220a59386(((ItemBase)val).ItemTypeId)));
		Scp2536Utils.GrantItem(hub, val3);
		return false;
	}

	private static int _m52616e6b3a300(ItemType type)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Expected I4, but got Unknown
		switch ((int)type)
		{
		case 0:
			return 0;
		case 1:
			return 1;
		case 2:
		case 3:
		case 4:
			return 2;
		case 5:
		case 6:
			return 3;
		case 7:
			return 4;
		case 8:
		case 9:
		case 10:
			return 5;
		case 11:
			return 6;
		default:
			return -1;
		}
	}

	private static ItemType _me3213e1220a59386(ItemType type)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Expected I4, but got Unknown
		switch ((int)type)
		{
		case 0:
			if (Random.value < 0.5f)
			{
				return (ItemType)1;
			}
			return (ItemType)3;
		case 1:
			return (ItemType)2;
		case 2:
			if (Random.value < 0.5f)
			{
				return (ItemType)6;
			}
			return (ItemType)9;
		case 3:
			if (Random.value < 0.5f)
			{
				return (ItemType)7;
			}
			return (ItemType)9;
		case 4:
			return (ItemType)5;
		case 5:
			return (ItemType)7;
		case 6:
			return (ItemType)9;
		case 7:
			return (ItemType)8;
		default:
			return (ItemType)11;
		}
	}
}
