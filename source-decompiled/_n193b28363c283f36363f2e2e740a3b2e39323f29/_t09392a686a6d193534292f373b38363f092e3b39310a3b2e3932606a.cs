using CustomPlayerEffects;
using HarmonyLib;
using InventorySystem.Items;
using InventorySystem.Items.Usables;
using PlayerStatsSystem;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(Scp207), "OnEffectsActivated")]
internal static class _t09392a686a6d193534292f373b38363f092e3b39310a3b2e3932606a
{
	private static bool _mWLpkKxRzYCuN(Scp207 __instance)
	{
		ReferenceHub val = ((__instance != null) ? ((ItemBase)__instance).Owner : null);
		if (val == (ReferenceHub)null)
		{
			return true;
		}
		((StatBase)val.playerStats.GetModule<StaminaStat>()).CurValue = 1f;
		val.playerStats.GetModule<HealthStat>().ServerHeal(30f);
		Scp207 val2 = default(Scp207);
		if (!val.playerEffectsController.TryGetEffect<Scp207>(ref val2))
		{
			return false;
		}
		byte b = ((((StatusEffectBase)val2).Intensity == byte.MaxValue) ? byte.MaxValue : ((byte)(((StatusEffectBase)val2).Intensity + 1)));
		val.playerEffectsController.ChangeState<Scp207>(b, 0f, false);
		return false;
	}
}
