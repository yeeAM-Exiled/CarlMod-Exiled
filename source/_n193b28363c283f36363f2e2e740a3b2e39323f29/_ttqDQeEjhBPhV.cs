using Exiled.API.Features;
using HarmonyLib;
using InventorySystem.Items.ThrowableProjectiles;
using PlayerRoles;
using PlayerRoles.PlayableScps.Scp096;
using _n4361726c6672656c6c6574740;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(FlashbangGrenade), "ProcessPlayer")]
internal static class _ttqDQeEjhBPhV
{
	private static bool _ma4eeca8ad6d2d388(ReferenceHub hub)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		if (!(hub == (ReferenceHub)null))
		{
			PlayerRoleBase currentRole = hub.roleManager.CurrentRole;
			Scp096Role val = (Scp096Role)(object)((currentRole is Scp096Role) ? currentRole : null);
			if (val != null)
			{
				Scp096EnhancementConfig scp096EnhancementConfig = ((Plugin<Config>)Plugin.Instance)?.Config?.ScpEnhancements?.Scp096;
				if (scp096EnhancementConfig != null && scp096EnhancementConfig.IsEnabled)
				{
					return (int)val.StateController.RageState != 2;
				}
				return true;
			}
		}
		return true;
	}
}
