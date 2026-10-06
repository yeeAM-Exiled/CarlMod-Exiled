using HarmonyLib;
using PlayerRoles;
using PlayerRoles.PlayableScps;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(/*Could not decode attribute arguments.*/)]
internal static class _t4368726973746d6173547265654c696d697465645363703034394865616c746850617463683a300
{
	[HarmonyPriority(0)]
	private static void _m0a35292e3c3322606a(FpcStandardScp __instance, ref float __result)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Invalid comparison between Unknown and I4
		ReferenceHub hub = default(ReferenceHub);
		if ((int)((PlayerRoleBase)__instance).RoleTypeId == 5 && ((PlayerRoleBase)__instance).TryGetOwner(ref hub) && _tJztlcNwspBcB._m52138532c0ee3cae(hub))
		{
			__result = 500f;
		}
	}
}
