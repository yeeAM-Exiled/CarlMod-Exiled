using HarmonyLib;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(/*Could not decode attribute arguments.*/)]
public static class CandyPinkPatch
{
	private static void _m76c92270823c2c72(ref float __result)
	{
		__result = 0.5f;
	}
}
