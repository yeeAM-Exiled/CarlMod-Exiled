using System.Collections.Generic;
using Christmas.Scp2536;
using CustomPlayerEffects;
using HarmonyLib;
using Mirror;
using PlayerRoles;
using PlayerStatsSystem;
using UnityEngine;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(Scp2536GiftController), "ServerInteract")]
internal static class _tJztlcNwspBcB
{
	private static readonly HashSet<uint> _fAVEuuedCAcdx = new HashSet<uint>();

	internal static bool _m52138532c0ee3cae(ReferenceHub hub)
	{
		if (hub != (ReferenceHub)null)
		{
			return _fAVEuuedCAcdx.Contains(((NetworkBehaviour)hub).netId);
		}
		return false;
	}

	private static bool _m5072656669783a300(Scp2536GiftController __instance, ReferenceHub ply, byte colliderId)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		if (ply != (ReferenceHub)null && PlayerRolesUtils.IsHuman(ply) && ply.inventory.UserInventory.Items.Count >= 8)
		{
			_tdc7d223bebb3c685._mxjpOfvgeICZC(ply);
		}
		if (ply == (ReferenceHub)null || (int)PlayerRolesUtils.GetTeam(ply) != 0)
		{
			return true;
		}
		GiftBox val = __instance.GiftBoxes[colliderId % __instance.GiftBoxes.Length];
		if (!val.CanBeOpen)
		{
			return false;
		}
		__instance.RpcSetGiftState((int)colliderId, false);
		HashSet<ushort> existingSerials = (CustomRoleSystem._mXlPQNDWPOAbe(ply) ? new HashSet<ushort>(ply.inventory.UserInventory.Items.Keys) : null);
		_m1d283b342e09392a083f2d3b283e606a(ply);
		_tdc7d223bebb3c685._m508918c5ef2f3332(ply, existingSerials);
		val.CanBeOpen = false;
		return false;
	}

	private static void _m1d283b342e09392a083f2d3b283e606a(ReferenceHub hub)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Invalid comparison between Unknown and I4
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Invalid comparison between Unknown and I4
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Invalid comparison between Unknown and I4
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0201: Invalid comparison between Unknown and I4
		//IL_0216: Unknown result type (might be due to invalid IL or missing references)
		//IL_021a: Invalid comparison between Unknown and I4
		float value = Random.value;
		if ((int)PlayerRolesUtils.GetRoleId(hub) == 10 && value < 0.01f)
		{
			_fAVEuuedCAcdx.Remove(((NetworkBehaviour)hub).netId);
			hub.roleManager.ServerSetRole((RoleTypeId)5, (RoleChangeReason)6, (RoleSpawnFlags)(-1));
			HealthStat module = hub.playerStats.GetModule<HealthStat>();
			HumeShieldStat module2 = hub.playerStats.GetModule<HumeShieldStat>();
			((StatBase)module).CurValue = ((StatBase)module).MaxValue;
			((StatBase)module2).CurValue = ((StatBase)module2).MaxValue;
			return;
		}
		HealthStat module3 = hub.playerStats.GetModule<HealthStat>();
		HumeShieldStat module4 = hub.playerStats.GetModule<HumeShieldStat>();
		if ((int)PlayerRolesUtils.GetRoleId(hub) == 10 && value < 0.05f)
		{
			_fAVEuuedCAcdx.Add(((NetworkBehaviour)hub).netId);
			hub.roleManager.ServerSetRole((RoleTypeId)5, (RoleChangeReason)6, (RoleSpawnFlags)(-1));
			((StatBase)hub.playerStats.GetModule<HealthStat>()).CurValue = 500f;
			((StatBase)hub.playerStats.GetModule<HumeShieldStat>()).CurValue = 0f;
			return;
		}
		if (value < 0.08f)
		{
			((StatBase)module3).CurValue = ((StatBase)module3).MaxValue;
			((StatBase)module4).CurValue = ((StatBase)module4).MaxValue;
			return;
		}
		if (value < 0.11f)
		{
			((StatBase)module4).CurValue = ((StatBase)module4).CurValue + 10000f;
			return;
		}
		if (value < 0.55f)
		{
			module3.ServerHeal(Random.Range(35f, 151f));
			return;
		}
		if (value < 0.7f)
		{
			((StatBase)module4).CurValue = Mathf.Min(((StatBase)module4).CurValue + Random.Range(35f, 151f), ((StatBase)module4).MaxValue);
			return;
		}
		if (value < 0.8f)
		{
			module3.ServerHeal(Random.Range(25f, 101f));
			((StatBase)module4).CurValue = Mathf.Min(((StatBase)module4).CurValue + Random.Range(25f, 101f), ((StatBase)module4).MaxValue);
			return;
		}
		float value2 = Random.value;
		ItemType val = (ItemType)((value2 < 0.5f) ? 18 : ((value2 < 0.75f) ? 33 : ((value2 < 0.9f) ? 17 : 34)));
		Scp2536Utils.GrantItem(hub, val);
		if ((int)val == 18)
		{
			hub.playerEffectsController.EnableEffect<Scp207>(0f, false);
		}
		else if ((int)val == 33)
		{
			hub.playerEffectsController.EnableEffect<Invigorated>(8f, true);
		}
		else if ((int)val == 17)
		{
			hub.playerEffectsController.EnableEffect<Vitality>(15f, true);
		}
	}
}
