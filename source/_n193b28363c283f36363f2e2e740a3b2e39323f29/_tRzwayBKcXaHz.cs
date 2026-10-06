using Christmas.Scp2536;
using HarmonyLib;
using PlayerRoles;
using UnityEngine;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(Scp2536GiftController), "ServerGrantRandomGift")]
internal static class _tRzwayBKcXaHz
{
	private static bool _ma4eeca8ad6d2d388(ReferenceHub hub)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		if (hub == (ReferenceHub)null || (int)PlayerRolesUtils.GetTeam(hub) == 0 || Random.value >= 0.35f)
		{
			return true;
		}
		if (hub.inventory.UserInventory.Items.Count >= 8)
		{
			_tdc7d223bebb3c685._mxjpOfvgeICZC(hub);
		}
		float value = Random.value;
		ItemType val = ((value < 0.55f) ? ((ItemType)18) : ((value < 0.82f) ? ((ItemType)17) : ((value < 0.95f) ? ((ItemType)49) : ((!(value < 0.975f)) ? ((ItemType)45) : ((ItemType)44)))));
		Scp2536Utils.GrantItem(hub, val);
		return false;
	}
}
