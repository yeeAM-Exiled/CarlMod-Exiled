using System;
using System.Text;
using Exiled.API.Features;
using HarmonyLib;
using PlayerRoles;
using PlayerRoles.FirstPersonControl;
using _n4361726c6672656c6c6574740;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(FpcStateProcessor), "get_ServerUseRate")]
internal static class _t5363703933395374616d696e6150617463683a300
{
	private static void _mJJZBzaQAuipj(FpcStateProcessor __instance, ref float __result)
	{
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Invalid comparison between Unknown and I4
		Scp939EnhancementConfig scp939EnhancementConfig = ((Plugin<Config>)Plugin.Instance)?.Config?.ScpEnhancements?.Scp939;
		ReferenceHub value = Traverse.Create((object)__instance).Field(Encoding.UTF8.GetString(Convert.FromBase64String("X2h1Yg=="))).GetValue<ReferenceHub>();
		if (scp939EnhancementConfig != null && scp939EnhancementConfig.IsEnabled && value != (ReferenceHub)null && (int)PlayerRolesUtils.GetRoleId(value) == 16)
		{
			__result /= scp939EnhancementConfig.StaminaCapacityMultiplier;
		}
	}
}
