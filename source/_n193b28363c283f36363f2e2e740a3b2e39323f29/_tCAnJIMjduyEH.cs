using System;
using System.Reflection;
using System.Text;
using Exiled.API.Features;
using HarmonyLib;
using PlayerRoles;
using PlayerRoles.FirstPersonControl;
using UnityEngine;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(Escape), "ServerGetScenario")]
internal static class _tCAnJIMjduyEH
{
	private static readonly FieldInfo _fEwExVswJEprd = AccessTools.Field(typeof(CharacterClassManager), "CuffedChangeTeam");

	private static readonly FieldInfo _f576f726c64506f736974696f6e4669656c643a300 = AccessTools.Field(typeof(Escape), "WorldPos");

	private static readonly FieldInfo _f083b3e332f29092b2f3b283f3e1c333f363e606a = AccessTools.Field(typeof(Escape), "RadiusSqr");

	private static readonly FieldInfo _f17333433372f371b36332c3f0e33373f1c333f363e606a = AccessTools.Field(typeof(Escape), "MinAliveTime");

	private static bool _f3935372a3b2e33383336332e231c3b33362f283f16353d3d3f3e606a;

	private static bool _m0a283f3c3322606a(ReferenceHub hub, ref EscapeScenarioType __result)
	{
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Invalid comparison between Unknown and I4
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected I4, but got Unknown
		try
		{
			Player val = Player.Get(hub);
			object obj;
			if (hub == null)
			{
				obj = null;
			}
			else
			{
				PlayerRoleManager roleManager = hub.roleManager;
				obj = ((roleManager != null) ? roleManager.CurrentRole : null);
			}
			HumanRole val2 = (HumanRole)((obj is HumanRole) ? obj : null);
			if (val == null || (Object)(object)val2 == (Object)null || (Object)(object)((FpcStandardRoleBase)val2).FpcModule == (Object)null || !val.IsCuffed || !_mLbqIzdPXstGz(out var cuffedChangeTeam, out var worldPosition, out var radiusSquared, out var minimumAliveTime) || !cuffedChangeTeam)
			{
				return true;
			}
			Vector3 val3 = ((FpcStandardRoleBase)val2).FpcModule.Position - worldPosition;
			if (((Vector3)(ref val3)).sqrMagnitude > radiusSquared || ((PlayerRoleBase)val2).ActiveTime < minimumAliveTime)
			{
				return true;
			}
			RoleTypeId type = val.Role.Type;
			if ((int)type != 4)
			{
				switch (type - 8)
				{
				case 3:
				case 4:
				case 5:
					break;
				case 0:
				case 10:
				case 11:
				case 12:
					__result = (EscapeScenarioType)2;
					return false;
				default:
					return true;
				}
			}
			__result = (EscapeScenarioType)4;
			return false;
		}
		catch (Exception exception)
		{
			_mtmuecVQSaHZk(exception);
			return true;
		}
	}

	private static bool _mLbqIzdPXstGz(out bool cuffedChangeTeam, out Vector3 worldPosition, out float radiusSquared, out float minimumAliveTime)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		cuffedChangeTeam = false;
		worldPosition = default(Vector3);
		radiusSquared = 0f;
		minimumAliveTime = 0f;
		if (_fEwExVswJEprd == null || _f576f726c64506f736974696f6e4669656c643a300 == null || _f083b3e332f29092b2f3b283f3e1c333f363e606a == null || _f17333433372f371b36332c3f0e33373f1c333f363e606a == null)
		{
			return false;
		}
		try
		{
			cuffedChangeTeam = (bool)_fEwExVswJEprd.GetValue(null);
			worldPosition = (Vector3)_f576f726c64506f736974696f6e4669656c643a300.GetValue(null);
			radiusSquared = Convert.ToSingle(_f083b3e332f29092b2f3b283f3e1c333f363e606a.GetRawConstantValue());
			minimumAliveTime = Convert.ToSingle(_f17333433372f371b36332c3f0e33373f1c333f363e606a.GetRawConstantValue());
			return true;
		}
		catch (Exception exception)
		{
			_mtmuecVQSaHZk(exception);
			return false;
		}
	}

	private static void _mtmuecVQSaHZk(Exception exception)
	{
		if (!_f3935372a3b2e33383336332e231c3b33362f283f16353d3d3f3e606a)
		{
			_f3935372a3b2e33383336332e231c3b33362f283f16353d3d3f3e606a = true;
			Log.Warn(Encoding.UTF8.GetString(Convert.FromBase64String("W0NhcmxmcmVsbGV0dF0gQ3VmZmVkIGZhY3Rpb24gZXNjYXBlIGNvbXBhdGliaWxpdHkgcGF0Y2ggd2FzIGRpc2FibGVkOiA=")) + exception.Message);
		}
	}
}
