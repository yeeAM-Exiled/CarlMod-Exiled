using Christmas.Scp2536.Gifts;
using HarmonyLib;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(SpecialWeapons), "get_IgnoredByRandomness")]
internal static class _tvvtRcjfplVGw
{
	private static void _m506f73746669783a300(ref bool __result)
	{
		__result = false;
	}
}
