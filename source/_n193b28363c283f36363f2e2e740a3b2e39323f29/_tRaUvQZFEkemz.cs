using Christmas.Scp2536;
using Christmas.Scp2536.Gifts;
using HarmonyLib;
using UnityEngine;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(SpecialWeapons), "ServerGrant")]
internal static class _tRaUvQZFEkemz
{
	private static bool _mLpxbAGctNrhQ(ReferenceHub hub)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		float value = Random.value;
		ItemType val = (ItemType)((value < 0.35f) ? 52 : ((value < 0.7f) ? 47 : 48));
		Scp2536Utils.GrantItem(hub, val);
		return false;
	}
}
