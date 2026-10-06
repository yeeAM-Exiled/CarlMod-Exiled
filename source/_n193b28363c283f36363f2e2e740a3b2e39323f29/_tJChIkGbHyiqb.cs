using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Christmas.Scp2536;
using Christmas.Scp2536.Gifts;
using HarmonyLib;
using InventorySystem.Items;
using UnityEngine;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(LastStand), "ServerGrant")]
internal static class _tJChIkGbHyiqb
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _tSzcfhlyONIrZ
	{
		public static readonly _tSzcfhlyONIrZ _003C_003E9 = new _tSzcfhlyONIrZ();

		public static Func<ItemBase, bool> _003C_003E9__0_0;

		internal bool _m3c5072656669783e625f5f305f303a300(ItemBase item)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Invalid comparison between Unknown and I4
			return (int)item.ItemTypeId == 49;
		}
	}

	private static bool _micYuZPluaCzM(ReferenceHub hub)
	{
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Invalid comparison between Unknown and I4
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Invalid comparison between Unknown and I4
		//IL_0074: Unknown result type (might be due to invalid IL or missing references)
		if (Random.value < 0.2f && _tdc7d223bebb3c685._md10c11c6f8d3fe5e(hub, 4))
		{
			return true;
		}
		ItemType[] array = new ItemType[3];
		RuntimeHelpers.InitializeArray(array, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		ItemType val = array[Random.Range(0, 3)];
		ItemBase val2 = null;
		if ((int)val == 49)
		{
			if (!hub.inventory.UserInventory.Items.Values.Any((ItemBase item) => (int)item.ItemTypeId == 49))
			{
				val2 = Scp2536Utils.GrantItem(hub, val);
			}
		}
		else
		{
			val2 = Scp2536Utils.GrantItem(hub, val);
		}
		if ((int)val == 24 && (Object)(object)val2 != (Object)null)
		{
			Scp2536Utils.GrantRewardAmmo(val2);
		}
		return false;
	}
}
