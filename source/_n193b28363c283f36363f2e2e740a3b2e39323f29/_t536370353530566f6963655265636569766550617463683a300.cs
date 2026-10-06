using HarmonyLib;
using PlayerRoles.Voice;
using UnityEngine;
using VoiceChat;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(HumanVoiceModule), "ValidateReceive")]
internal static class _t536370353530566f6963655265636569766550617463683a300
{
	private static void _mZuvWaUFAhXRA(HumanVoiceModule __instance, ReferenceHub speaker, VoiceChatChannel channel, ref VoiceChatChannel __result)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		ReferenceHub hub = default(ReferenceHub);
		if ((Object)(object)__instance != (Object)null && ((VoiceModuleBase)__instance).Role.TryGetOwner(ref hub) && CustomRoleSystem._m0a3f5ba5212f6c56(hub) && (int)channel == 3)
		{
			__result = (VoiceChatChannel)3;
		}
	}
}
