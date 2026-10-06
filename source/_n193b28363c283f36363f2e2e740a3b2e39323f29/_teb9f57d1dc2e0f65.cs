using System;
using System.Text;
using HarmonyLib;
using PlayerRoles.Voice;
using UnityEngine;
using VoiceChat;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(GlobalVoiceModuleBase), "ProcessInputs")]
internal static class _teb9f57d1dc2e0f65
{
	private static void _m506f73746669783a300(GlobalVoiceModuleBase __instance, bool primary, bool alt, ref VoiceChatChannel __result)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		ReferenceHub val = default(ReferenceHub);
		if (!((Object)(object)__instance == (Object)null) && ((VoiceModuleBase)__instance).Role.TryGetOwner(ref val) && ((object)val.roleManager.CurrentRole.RoleTypeId/*cast due to .constrained prefix*/).ToString().StartsWith(Encoding.UTF8.GetString(Convert.FromBase64String("U2Nw"))))
		{
			__result = (VoiceChatChannel)(alt ? 1 : (primary ? 3 : 0));
		}
	}
}
