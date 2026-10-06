using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using HarmonyLib;
using VoiceChat.Networking;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(VoiceTransceiver), "ServerReceiveMessage")]
internal static class _temDLRdteUXiv
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _t8f709c079eafafc1
	{
		public static readonly _t8f709c079eafafc1 _003C_003E9 = new _t8f709c079eafafc1();

		public static Predicate<CodeInstruction> _003C_003E9__0_0;

		internal bool _ma6f1befa037531d7(CodeInstruction instruction)
		{
			if (instruction.operand is MethodInfo methodInfo)
			{
				return methodInfo.Name == Encoding.UTF8.GetString(Convert.FromBase64String("Z2V0X2Nvbm5lY3Rpb25Ub0NsaWVudA=="));
			}
			return false;
		}
	}

	private static IEnumerable<CodeInstruction> _m0e283b34292a33363f28606a(IEnumerable<CodeInstruction> instructions)
	{
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0142: Expected O, but got Unknown
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0150: Expected O, but got Unknown
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Expected O, but got Unknown
		//IL_0167: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Expected O, but got Unknown
		List<CodeInstruction> list = instructions.ToList();
		int num = list.FindIndex(_mzZfBSkNrbvku);
		if (num < 4)
		{
			throw new InvalidOperationException(Encoding.UTF8.GetString(Convert.FromBase64String("Q291bGQgbm90IGxvY2F0ZSB0aGUgdm9pY2UgbWVzc2FnZSBzZW5kIGNhbGwu")));
		}
		int num2 = list.FindLastIndex(num, (CodeInstruction instruction) => instruction.operand is MethodInfo methodInfo2 && methodInfo2.Name == Encoding.UTF8.GetString(Convert.FromBase64String("Z2V0X2Nvbm5lY3Rpb25Ub0NsaWVudA==")));
		if (num2 <= 0)
		{
			throw new InvalidOperationException(Encoding.UTF8.GetString(Convert.FromBase64String("Q291bGQgbm90IGxvY2F0ZSB0aGUgdm9pY2UgcmVjaXBpZW50IGNvbm5lY3Rpb24u")));
		}
		object obj = null;
		for (int num3 = num2 - 1; num3 >= 0; num3--)
		{
			if (list[num3].opcode == OpCodes.Brfalse || list[num3].opcode == OpCodes.Brfalse_S)
			{
				obj = list[num3].operand;
				break;
			}
		}
		if (obj == null)
		{
			throw new InvalidOperationException(Encoding.UTF8.GetString(Convert.FromBase64String("Q291bGQgbm90IGxvY2F0ZSB0aGUgdm9pY2UgcmVjaXBpZW50IGxvb3AgdGFyZ2V0Lg==")));
		}
		CodeInstruction val = list[num2 - 1];
		MethodInfo methodInfo = AccessTools.Method(typeof(SpectatorPrivacySystem), Encoding.UTF8.GetString(Convert.FromBase64String("Q2FuUmVjZWl2ZVZvaWNl")), (Type[])null, (Type[])null);
		list.InsertRange(num2 - 1, (IEnumerable<CodeInstruction>)(object)new CodeInstruction[4]
		{
			new CodeInstruction(val.opcode, val.operand),
			new CodeInstruction(OpCodes.Ldloc_1, (object)null),
			new CodeInstruction(OpCodes.Call, (object)methodInfo),
			new CodeInstruction(OpCodes.Brfalse, obj)
		});
		return list;
	}

	private static bool _mzZfBSkNrbvku(CodeInstruction instruction)
	{
		MethodInfo methodInfo = instruction.operand as MethodInfo;
		if (methodInfo != null && methodInfo.Name == Encoding.UTF8.GetString(Convert.FromBase64String("U2VuZA==")) && methodInfo.IsGenericMethod && methodInfo.GetGenericArguments().Length == 1)
		{
			return methodInfo.GetGenericArguments()[0] == typeof(VoiceMessage);
		}
		return false;
	}
}
