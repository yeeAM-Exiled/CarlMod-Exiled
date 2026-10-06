using System;
using System.Text;
using HarmonyLib;
using PlayerRoles.Voice;
using UnityEngine;
using VoiceChat;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(GlobalVoiceModuleBase), "ValidateSend")]
internal static class _txYxKJIeCexlr
{
	private static void _m506f73746669783a300(GlobalVoiceModuleBase __instance, VoiceChatChannel channel, ref VoiceChatChannel __result)
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Invalid comparison between Unknown and I4
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Expected I4, but got Unknown
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Invalid comparison between Unknown and I4
		ReferenceHub val = default(ReferenceHub);
		if ((Object)(object)__instance != (Object)null && ((VoiceModuleBase)__instance).Role.TryGetOwner(ref val) && ((object)val.roleManager.CurrentRole.RoleTypeId/*cast due to .constrained prefix*/).ToString().StartsWith(Encoding.UTF8.GetString(Convert.FromBase64String("U2Nw"))) && ((int)channel == 3 || (int)channel == 1))
		{
			__result = (VoiceChatChannel)(int)channel;
		}
	}
}
