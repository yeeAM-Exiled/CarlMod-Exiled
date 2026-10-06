using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using CommandSystem;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.Pickups;
using Mirror;
using UnityEngine;

namespace _n4361726c6672656c6c6574742e436f6d6d616e64732e436861740;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public sealed class CleanupCommand : ICommand
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _t3c3e633a300
	{
		public static readonly _t3c3e633a300 _003C_003E9 = new _t3c3e633a300();

		public static Func<Pickup, bool> _003C_003E9__11_1;

		public static Func<Pickup, bool> _003C_003E9__11_2;

		public static Func<Pickup, bool> _003C_003E9__11_3;

		public static Func<Pickup, bool> _003C_003E9__11_4;

		public static Func<Pickup, bool> _003C_003E9__11_5;

		public static Func<Pickup, bool> _003C_003E9__11_6;

		public static Func<Pickup, bool> _003C_003E9__11_7;

		public static Func<Pickup, bool> _003C_003E9__11_8;

		public static Func<Pickup, bool> _003C_003E9__11_9;

		public static Func<Pickup, bool> _003C_003E9__13_0;

		internal bool _m2f0c3d6d2e60a705(Pickup pickup)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return ItemExtensions.IsAmmo(pickup.Type);
		}

		internal bool _m3c457865637574653e625f5f31315f323a300(Pickup pickup)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return _f858a241a41b0343b.Contains(pickup.Type);
		}

		internal bool _m3c457865637574653e625f5f31315f333a300(Pickup pickup)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return _fsslMmxUxfLrM.Contains(pickup.Type);
		}

		internal bool _m3c457865637574653e625f5f31315f343a300(Pickup pickup)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return _fsySSSLMrkMYE.Contains(pickup.Type);
		}

		internal bool _mFTHabmANbwHP(Pickup pickup)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Invalid comparison between Unknown and I4
			return (int)pickup.Type == 16;
		}

		internal bool _m661f223f392f2e3f643805056b6b056c606a(Pickup pickup)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Invalid comparison between Unknown and I4
			return (int)pickup.Type == 47;
		}

		internal bool _mTjZKtYPIqbsI(Pickup pickup)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return _f41726d6f724974656d733a300.Contains(pickup.Type);
		}

		internal bool _mAEaGxXgQRbte(Pickup pickup)
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Invalid comparison between Unknown and I4
			return (int)pickup.Type == 12;
		}

		internal bool _mjVwtGGbsXjDU(Pickup pickup)
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return _fbff16bc5e6d34fd0.Contains(pickup.Type);
		}

		internal bool _mCZIGJLnYpYSw(Pickup pickup)
		{
			return pickup != null;
		}
	}

	private static readonly HashSet<ItemType> _f858a241a41b0343b = new HashSet<ItemType>
	{
		(ItemType)31,
		(ItemType)46,
		(ItemType)18,
		(ItemType)43,
		(ItemType)44,
		(ItemType)45,
		(ItemType)32,
		(ItemType)42,
		(ItemType)17
	};

	private static readonly HashSet<ItemType> _fsslMmxUxfLrM = new HashSet<ItemType>
	{
		(ItemType)33,
		(ItemType)14,
		(ItemType)34,
		(ItemType)17
	};

	private static readonly HashSet<ItemType> _fsySSSLMrkMYE = new HashSet<ItemType>
	{
		(ItemType)13,
		(ItemType)30,
		(ItemType)21,
		(ItemType)20,
		(ItemType)23,
		(ItemType)24,
		(ItemType)39,
		(ItemType)41,
		(ItemType)40,
		(ItemType)26,
		(ItemType)25
	};

	private static readonly HashSet<ItemType> _f41726d6f724974656d733a300 = new HashSet<ItemType>
	{
		(ItemType)37,
		(ItemType)38,
		(ItemType)36
	};

	private static readonly HashSet<ItemType> _fbff16bc5e6d34fd0 = new HashSet<ItemType>
	{
		(ItemType)0,
		(ItemType)1,
		(ItemType)2,
		(ItemType)3,
		(ItemType)4,
		(ItemType)6,
		(ItemType)9,
		(ItemType)10,
		(ItemType)11
	};

	public string Command => Encoding.UTF8.GetString(Convert.FromBase64String("Y2FybGZjbGVhbnVw"));

	public string[] Aliases => new string[1] { Encoding.UTF8.GetString(Convert.FromBase64String("Y2xw")) };

	public string Description => Encoding.UTF8.GetString(Convert.FromBase64String("6auY57qn5riF55CG5Yqf6IO9"));

	public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		if (arguments.Count == 0)
		{
			response = _m1d3f2e0f293b3d3f606a();
			return false;
		}
		List<Func<Pickup, bool>> list = new List<Func<Pickup, bool>>();
		HashSet<ItemType> directItemTypes = new HashSet<ItemType>();
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		foreach (string item in (IEnumerable<string>)arguments/*cast due to .constrained prefix*/)
		{
			string text = ((item == null) ? string.Empty : item.Trim());
			if (string.IsNullOrEmpty(text))
			{
				continue;
			}
			if (flag3)
			{
				if (!_md51abc1ed27554ae(text, out var itemType))
				{
					response = Encoding.UTF8.GetString(Convert.FromBase64String("5peg5rOV6K+G5YirIEl0ZW1UeXBlIOWPguaVsDog")) + text;
					return false;
				}
				directItemTypes.Add(itemType);
				continue;
			}
			switch (text.ToUpperInvariant())
			{
			case "0":
				flag = true;
				break;
			case "1":
				flag2 = true;
				break;
			case "2":
				list.Add((Pickup pickup) => ItemExtensions.IsAmmo(pickup.Type));
				break;
			case "3":
				list.Add((Pickup pickup) => _f858a241a41b0343b.Contains(pickup.Type));
				break;
			case "4":
				list.Add((Pickup pickup) => _fsslMmxUxfLrM.Contains(pickup.Type));
				break;
			case "5":
				list.Add((Pickup pickup) => _fsySSSLMrkMYE.Contains(pickup.Type));
				break;
			case "6":
				list.Add((Pickup pickup) => (int)pickup.Type == 16);
				break;
			case "7":
				list.Add((Pickup pickup) => (int)pickup.Type == 47);
				break;
			case "8":
				list.Add((Pickup pickup) => _f41726d6f724974656d733a300.Contains(pickup.Type));
				goto case "9";
			case "9":
				list.Add((Pickup pickup) => (int)pickup.Type == 12);
				break;
			case "K":
				list.Add((Pickup pickup) => _fbff16bc5e6d34fd0.Contains(pickup.Type));
				break;
			case "Z":
				flag3 = true;
				break;
			default:
				response = Encoding.UTF8.GetString(Convert.FromBase64String("5peg5rOV6K+G5Yir55qE5riF55CG5Y+C5pWwOiA=")) + text + Environment.NewLine + _m1d3f2e0f293b3d3f606a();
				return false;
			}
		}
		if (flag3 && directItemTypes.Count == 0)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5Y+C5pWwIFog5ZCO6ZyA6KaB57un57ut5Lyg5YWl6Iez5bCR5LiA5LiqIEl0ZW1UeXBl44CC"));
			return false;
		}
		if (directItemTypes.Count > 0)
		{
			list.Add((Pickup pickup) => directItemTypes.Contains(pickup.Type));
		}
		if (!flag && !flag2 && list.Count == 0)
		{
			response = _m1d3f2e0f293b3d3f606a();
			return false;
		}
		int num = (flag ? _m436c65616e7570526167646f6c6c733a300() : 0);
		int num2 = _mPkLCoJfAEyGg(flag2, list);
		response = string.Format(Encoding.UTF8.GetString(Convert.FromBase64String("5riF55CG5a6M5oiQ77yM5biD5aiD5aiDIHswfSDkuKrvvIznianlk4EgezF9IOS4quOAgg==")), num, num2);
		return true;
	}

	private static int _m436c65616e7570526167646f6c6c733a300()
	{
		int num = 0;
		foreach (Ragdoll item in Ragdoll.List.ToList())
		{
			if (item != null)
			{
				item.Destroy();
				num++;
			}
		}
		return num;
	}

	private static int _mPkLCoJfAEyGg(bool cleanAllPickups, IList<Func<Pickup, bool>> predicates)
	{
		int num = 0;
		foreach (Pickup pickup in Pickup.List.Where((Pickup val) => val != null).ToList())
		{
			if (cleanAllPickups || predicates.Any((Func<Pickup, bool> predicate) => predicate(pickup)))
			{
				if ((Object)(object)pickup.GameObject != (Object)null)
				{
					NetworkServer.Destroy(pickup.GameObject);
				}
				else
				{
					pickup.Destroy();
				}
				num++;
			}
		}
		return num;
	}

	private static bool _md51abc1ed27554ae(string value, out ItemType itemType)
	{
		if (int.TryParse(value, out var result) && Enum.IsDefined(typeof(ItemType), result))
		{
			itemType = (ItemType)result;
			return true;
		}
		return Enum.TryParse<ItemType>(value, ignoreCase: true, out itemType);
	}

	private static string _m1d3f2e0f293b3d3f606a()
	{
		return Encoding.UTF8.GetString(Convert.FromBase64String("55So5rOVOiBjYXJsZmNsZWFudXB8Y2xwIDzlj4LmlbAuLi4+")) + Environment.NewLine + Encoding.UTF8.GetString(Convert.FromBase64String("MD3muIXnkIblhajlm77luIPlqIPlqIMgMT3muIXnkIblhajlm77nianlk4EgMj3lrZDlvLkgMz1TQ1Dnianlk4EgND3ljLvnlpfnianlk4EgNT3mrablmago5LiN5ZCrTWljcm9ISUQvUGFydGljbGVEaXNydXB0b3Ip")) + Environment.NewLine + Encoding.UTF8.GetString(Convert.FromBase64String("Nj1NaWNyb0hJRCA3PVBhcnRpY2xlRGlzcnVwdG9yIDg95oqk55SyIDk95a+56K6y5py6IEs96ZKl5YyZ5Y2hIFo95ZCO57ut5Y+C5pWw5oyJSXRlbVR5cGXlpITnkIbvvIzkvovlpoI6IGNscCBaIDE0"));
	}
}
