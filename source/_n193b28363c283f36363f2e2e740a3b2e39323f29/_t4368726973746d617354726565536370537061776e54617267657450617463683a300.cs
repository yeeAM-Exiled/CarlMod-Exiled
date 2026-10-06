using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using Christmas.Scp2536;
using HarmonyLib;
using PlayerRoles;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(Scp2536Controller), "ServerFindTarget")]
internal static class _t4368726973746d617354726565536370537061776e54617267657450617463683a300
{
	private static readonly Team[] _f1b3636352d3f3e0e3f3b3729606a;

	private static IEnumerable<CodeInstruction> _mLFYfgnlxEBDm(IEnumerable<CodeInstruction> instructions)
	{
		FieldInfo whitelist = AccessTools.Field(typeof(Scp2536Controller), "WhitelistedTeams");
		MethodInfo replacement = AccessTools.Method(typeof(_t4368726973746d617354726565536370537061776e54617267657450617463683a300), "GetAllowedTeams", (Type[])null, (Type[])null);
		foreach (CodeInstruction instruction in instructions)
		{
			if (instruction.opcode == OpCodes.Ldsfld && object.Equals(instruction.operand, whitelist))
			{
				yield return new CodeInstruction(OpCodes.Call, (object)replacement);
			}
			else
			{
				yield return instruction;
			}
		}
	}

	private static Team[] _m1d3f2e1b3636352d3f3e0e3f3b3729606a()
	{
		return _f1b3636352d3f3e0e3f3b3729606a;
	}

	static _t4368726973746d617354726565536370537061776e54617267657450617463683a300()
	{
		Team[] array = new Team[4];
		RuntimeHelpers.InitializeArray(array, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
		_f1b3636352d3f3e0e3f3b3729606a = (Team[])(object)array;
	}
}
