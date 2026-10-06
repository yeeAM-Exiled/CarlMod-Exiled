using HarmonyLib;
using PlayerRoles.Voice;
using UnityEngine;
using VoiceChat;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(HumanVoiceModule), "ValidateSend")]
internal static class _t09392a6f6f6a0c3533393f093f343e0a3b2e3932606a
{
	private static void _m76c92270823c2c72(HumanVoiceModule __instance, VoiceChatChannel channel, ref VoiceChatChannel __result)
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Invalid comparison between Unknown and I4
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Expected I4, but got Unknown
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Invalid comparison between Unknown and I4
		ReferenceHub hub = default(ReferenceHub);
		if ((Object)(object)__instance != (Object)null && ((VoiceModuleBase)__instance).Role.TryGetOwner(ref hub) && CustomRoleSystem._m0a3f5ba5212f6c56(hub) && ((int)channel == 3 || (int)channel == 1))
		{
			__result = (VoiceChatChannel)(int)channel;
		}
	}
}
