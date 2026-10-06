using Exiled.API.Features;
using HarmonyLib;
using Mirror;
using PlayerRoles.PlayableScps.Scp106;
using _n4361726c6672656c6c6574740;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(/*Could not decode attribute arguments.*/)]
internal static class _t5363703130365669676f7250617463683a300
{
	[HarmonyPatch(typeof(Scp106Vigor), "SpawnObject")]
	private static class _t537061776e50617463683a300
	{
		private static void _ma4eeca8ad6d2d388()
		{
			_f39794e6e16d8f99c = true;
		}

		private static void _mUhjJSLotzMeS()
		{
			_f39794e6e16d8f99c = false;
		}
	}

	private static bool _f39794e6e16d8f99c;

	private static void _mrRCmBESOdeUy(Scp106Vigor __instance, ref float value)
	{
		Scp106EnhancementConfig scp106EnhancementConfig = ((Plugin<Config>)Plugin.Instance)?.Config?.ScpEnhancements?.Scp106;
		if (!_f39794e6e16d8f99c && NetworkServer.active && scp106EnhancementConfig != null && scp106EnhancementConfig.IsEnabled)
		{
			float vigorAmount = __instance.VigorAmount;
			if (value < vigorAmount)
			{
				value = vigorAmount - (vigorAmount - value) / scp106EnhancementConfig.VigorCapacityMultiplier;
			}
		}
	}
}
