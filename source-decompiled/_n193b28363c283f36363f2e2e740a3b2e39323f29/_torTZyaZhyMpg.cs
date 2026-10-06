using System;
using System.Collections.Generic;
using System.Reflection;
using Christmas.Scp2536.Gifts;
using HarmonyLib;
using InventorySystem.Items.Usables.Scp330;
using UnityEngine;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch]
internal static class _torTZyaZhyMpg
{
	private static IEnumerable<MethodBase> _m4b4a8654bb6c6bf6()
	{
		yield return AccessTools.Method(typeof(Explosives), "ServerGrant", (Type[])null, (Type[])null);
		yield return AccessTools.Method(typeof(Stamina), "ServerGrant", (Type[])null, (Type[])null);
		yield return AccessTools.Method(typeof(LastStand), "ServerGrant", (Type[])null, (Type[])null);
	}

	private static void _m0a35292e3c3322606a(ReferenceHub hub)
	{
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		Scp330Bag val = default(Scp330Bag);
		if (!(hub == (ReferenceHub)null) && Scp330Bag.TryGetBag(hub, ref val) && val.Candies.Count != 0 && !(Random.value >= 0.2f))
		{
			while (val.Candies.Count < 6)
			{
				val.TryAddSpecific(Scp330Candies.GetRandom());
			}
			val.ServerRefreshBag();
		}
	}
}
