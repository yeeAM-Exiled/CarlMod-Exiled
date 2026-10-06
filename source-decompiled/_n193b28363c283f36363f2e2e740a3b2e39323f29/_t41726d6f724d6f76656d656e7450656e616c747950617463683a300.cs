using Exiled.API.Features;
using HarmonyLib;
using _n4361726c6672656c6c6574740;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(/*Could not decode attribute arguments.*/)]
internal static class _t41726d6f724d6f76656d656e7450656e616c747950617463683a300
{
	private static void _mKfDZrLjXdtEf(ref float __result)
	{
		Plugin instance = Plugin.Instance;
		if (instance != null && ((Plugin<Config>)instance).Config?.DisableArmorMovementPenalty == true)
		{
			__result = 1f;
		}
	}
}
