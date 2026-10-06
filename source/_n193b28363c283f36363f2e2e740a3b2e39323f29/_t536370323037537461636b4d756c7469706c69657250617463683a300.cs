using CustomPlayerEffects;
using HarmonyLib;
using UnityEngine;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(/*Could not decode attribute arguments.*/)]
internal static class _t536370323037537461636b4d756c7469706c69657250617463683a300
{
	private const byte _f0c3b343336363b173b2233372f3713342e3f3429332e23606a = 4;

	private static void _m506f73746669783a300(Scp207 __instance, ref float __result)
	{
		if (!((Object)(object)__instance == (Object)null) && ((StatusEffectBase)__instance).Intensity > 4 && !(__result <= 0f))
		{
			int num = ((StatusEffectBase)__instance).Intensity - 4;
			float num2 = Mathf.Pow(2f, (float)num);
			__result = ((num2 > float.MaxValue / __result) ? float.MaxValue : (__result * num2));
		}
	}
}
