using HarmonyLib;
using PlayerRoles.Voice;
using UnityEngine;
using VoiceChat;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(HumanVoiceModule), "ProcessInputs")]
internal static class _tdc1392cddca91fbc
{
	private static void _mWaBnyDJfLKSp(HumanVoiceModule __instance, bool primary, bool alt, ref VoiceChatChannel __result)
	{
		ReferenceHub hub = default(ReferenceHub);
		if (!((Object)(object)__instance == (Object)null) && ((VoiceModuleBase)__instance).Role.TryGetOwner(ref hub) && CustomRoleSystem._m0a3f5ba5212f6c56(hub))
		{
			__result = (VoiceChatChannel)(alt ? 1 : (primary ? 3 : 0));
		}
	}
}
