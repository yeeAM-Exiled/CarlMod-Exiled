using Exiled.API.Features;
using HarmonyLib;
using PlayerStatsSystem;
using UnityEngine;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(PlayerStats), "DealDamage")]
internal static class _t092e3b2e2f291f3c3c3f392e1e3b373b3d3f1337372f34332e230a3b2e3932606a
{
	[HarmonyPrefix]
	[HarmonyPriority(800)]
	private static bool _mbQyhwUFMpMXQ(PlayerStats __instance, DamageHandlerBase handler, ref bool __result)
	{
		UniversalDamageHandler val = (UniversalDamageHandler)(object)((handler is UniversalDamageHandler) ? handler : null);
		if (val == null)
		{
			return true;
		}
		byte translationId = val.TranslationId;
		if (translationId == DeathTranslations.Scp207.Id && CustomRoleSystem._m49735363703939393a300(Player.Get(((Component)__instance).gameObject)))
		{
			return true;
		}
		if (translationId != DeathTranslations.Scp207.Id && translationId != DeathTranslations.Poisoned.Id)
		{
			return true;
		}
		__result = false;
		return false;
	}
}
