using HarmonyLib;
using InventorySystem.Items.Jailbird;
using PlayerStatsSystem;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch]
internal static class _t4a61696c62697264486561767941747461636b50617463683a300
{
	[HarmonyPatch(typeof(JailbirdDamageHandler), "ApplyDamage")]
	private static class _tb7699d7dc1dd953b
	{
		private static void _m0a283f3c3322606a(JailbirdDamageHandler __instance, ReferenceHub ply)
		{
			//IL_0032: Unknown result type (might be due to invalid IL or missing references)
			//IL_0039: Invalid comparison between Unknown and I4
			if (_f6973486561767941747461636b3a300 && !(ply == (ReferenceHub)null))
			{
				((StatBase)ply.playerStats.GetModule<HumeShieldStat>()).CurValue = 0f;
				((StandardDamageHandler)__instance).Damage = (((int)ply.roleManager.CurrentRole.RoleTypeId == 10) ? 125f : 500f);
			}
		}
	}

	private const float _f7e627ee8636c175a = 500f;

	private const float _f5363703034393244616d6167654d756c7469706c6965723a300 = 4f;

	private static bool _f6973486561767941747461636b3a300;

	[HarmonyPatch(typeof(JailbirdHitreg), "ServerAttack")]
	[HarmonyPrefix]
	private static void _mHhwdCvnLVift(bool isCharging, out bool __state)
	{
		__state = _f6973486561767941747461636b3a300;
		_f6973486561767941747461636b3a300 = isCharging;
	}

	[HarmonyPatch(typeof(JailbirdHitreg), "ServerAttack")]
	[HarmonyFinalizer]
	private static void _m8228f7b82be81530(bool __state)
	{
		_f6973486561767941747461636b3a300 = __state;
	}
}
