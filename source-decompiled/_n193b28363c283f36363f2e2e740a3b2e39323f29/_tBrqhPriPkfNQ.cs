using HarmonyLib;
using PlayerRoles.PlayableScps.HumeShield;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(/*Could not decode attribute arguments.*/)]
internal static class _tBrqhPriPkfNQ
{
	private static void _m506f73746669783a300(DynamicHumeShieldController __instance, ref float __result)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Invalid comparison between Unknown and I4
		ReferenceHub hub = default(ReferenceHub);
		if ((int)((HumeShieldModuleBase)__instance).Role.RoleTypeId == 5 && ((HumeShieldModuleBase)__instance).Role.TryGetOwner(ref hub) && _tJztlcNwspBcB._m52138532c0ee3cae(hub))
		{
			__result = 0f;
		}
	}
}
