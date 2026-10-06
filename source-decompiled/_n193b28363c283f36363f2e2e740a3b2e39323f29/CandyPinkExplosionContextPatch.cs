using System;
using HarmonyLib;
using InventorySystem.Items.Usables.Scp330;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(CandyPink), "ServerApplyEffects")]
public static class CandyPinkExplosionContextPatch
{
	private static void _ma4eeca8ad6d2d388(ReferenceHub hub, out ReferenceHub __state)
	{
		__state = _t0a333431193b343e231f222a3635293335341935342e3f222e606a._m6ffdb4f8f2ff515a(hub);
	}

	private static Exception _mqkEDHDESufvl(Exception __exception, ReferenceHub __state)
	{
		_t0a333431193b343e231f222a3635293335341935342e3f222e606a._m1f22332e606a(__state);
		return __exception;
	}
}
