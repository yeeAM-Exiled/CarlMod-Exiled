using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Christmas.Scp2536.Gifts;
using HarmonyLib;
using InventorySystem.Items;
using InventorySystem.Items.Keycards;
using UnityEngine;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(KeycardUpgrade), "CanBeGranted")]
internal static class _tfBZtEwYnKoez
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _thAVKDEjfkrUb
	{
		public static readonly _thAVKDEjfkrUb _003C_003E9 = new _thAVKDEjfkrUb();

		public static Func<ItemBase, bool> _003C_003E9__0_0;

		internal bool _m660a35292e3c3322643805056a056a606a(ItemBase item)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Invalid comparison between Unknown and I4
			KeycardItem val = (KeycardItem)(object)((item is KeycardItem) ? item : null);
			if ((Object)(object)val != (Object)null)
			{
				return (int)((ItemBase)val).ItemTypeId != 11;
			}
			return false;
		}
	}

	private static void _m76c92270823c2c72(ReferenceHub hub, ref bool __result)
	{
		if (!(hub == (ReferenceHub)null))
		{
			__result = hub.inventory.UserInventory.Items.Values.Any(delegate(ItemBase item)
			{
				//IL_0011: Unknown result type (might be due to invalid IL or missing references)
				//IL_0018: Invalid comparison between Unknown and I4
				KeycardItem val = (KeycardItem)(object)((item is KeycardItem) ? item : null);
				return (Object)(object)val != (Object)null && (int)((ItemBase)val).ItemTypeId != 11;
			});
		}
	}
}
