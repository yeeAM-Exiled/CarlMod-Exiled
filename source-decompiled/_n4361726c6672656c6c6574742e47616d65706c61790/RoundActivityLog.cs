using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Exiled.API.Features;
using Exiled.API.Features.DamageHandlers;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Handlers;
using PlayerRoles;
using UnityEngine;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class RoundActivityLog
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _t666439606a
	{
		public static readonly _t666439606a _003C_003E9 = new _t666439606a();

		public static Func<Player, int> _003C_003E9__17_0;

		internal int _mgnDVjDYiGEVl(Player player)
		{
			return player.Id;
		}
	}

	public const string KillLogTitle = "击杀记录";

	public const string AdminCommandLogTitle = "管理员使用权限记录";

	private static readonly Regex _f526963685465787454616752656765783a300 = new Regex("<[^>]*>", RegexOptions.Compiled);

	private readonly object _fFiYSFEIPEplz = new object();

	private readonly List<string> _f6b696c6c5265636f7264733a300 = new List<string>();

	private readonly List<string> _f3b3e373334193537373b343e083f3935283e29606a = new List<string>();

	public static RoundActivityLog Instance { get; private set; }

	public void Enable()
	{
		Instance = this;
		Player.Died += _m15341e333f3e606a;
		Server.RoundStarted += _m4f6e526f756e64537461727465643a300;
		Server.WaitingForPlayers += _mmkFyOeeTWTag;
		Server.RestartingRound += _m4f6e52657374617274696e67526f756e643a300;
		Reset();
	}

	public void Disable()
	{
		Player.Died -= _m15341e333f3e606a;
		Server.RoundStarted -= _m4f6e526f756e64537461727465643a300;
		Server.WaitingForPlayers -= _mmkFyOeeTWTag;
		Server.RestartingRound -= _m4f6e52657374617274696e67526f756e643a300;
		Reset();
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public string BuildKillLogText()
	{
		lock (_fFiYSFEIPEplz)
		{
			return _m4275696c64526573706f6e73653a300(Encoding.UTF8.GetString(Convert.FromBase64String("5Ye75p2A6K6w5b2V")), _f6b696c6c5265636f7264733a300);
		}
	}

	public string BuildAdminCommandLogText()
	{
		lock (_fFiYSFEIPEplz)
		{
			return _m4275696c64526573706f6e73653a300(Encoding.UTF8.GetString(Convert.FromBase64String("W+euoeeQhuWRmOS9v+eUqOadg+mZkOiusOW9lV0=")), _f3b3e373334193537373b343e083f3935283e29606a);
		}
	}

	public string BuildPlayerListText()
	{
		return string.Join(Environment.NewLine, GetPlayerRecords());
	}

	public string[] GetKillRecords()
	{
		lock (_fFiYSFEIPEplz)
		{
			return _f6b696c6c5265636f7264733a300.ToArray();
		}
	}

	public string[] GetAdminCommandRecords()
	{
		lock (_fFiYSFEIPEplz)
		{
			return _f3b3e373334193537373b343e083f3935283e29606a.ToArray();
		}
	}

	public string[] GetPlayerRecords()
	{
		return (from player in Player.List.Where(_tFpYLlGZVhITT.IsGameplayPlayer)
			orderby player.Id
			select player).Select(_m5c2a48c86396856c).ToArray();
	}

	private static string _m5c2a48c86396856c(Player player)
	{
		int level;
		string arg = (ExperienceSystem.TryGetPlayerLevel(player, out level) ? level.ToString() : Encoding.UTF8.GetString(Convert.FromBase64String("LS0=")));
		return string.Format(Encoding.UTF8.GetString(Convert.FromBase64String("THYuezB9IHwgezF9")), arg, _m0e350a363b33340e3f222e606a(player.Nickname));
	}

	public void RecordAdminCommand(Player administrator, string commandText)
	{
		do
		{
			if (administrator == null || string.IsNullOrWhiteSpace(commandText))
			{
				return;
			}
		}
		while (string.IsNullOrWhiteSpace(administrator.GroupName));
		string groupName = administrator.GroupName;
		string item = string.Format(Encoding.UTF8.GetString(Convert.FromBase64String("W3swfV1bezF9XSDkvb/nlKjkuobvvJp7Mn0=")), _m0e350a363b33340e3f222e606a(administrator.Nickname), _m0e350a363b33340e3f222e606a(groupName), _m0e350a363b33340e3f222e606a(commandText));
		lock (_fFiYSFEIPEplz)
		{
			_f3b3e373334193537373b343e083f3935283e29606a.Add(item);
		}
	}

	private void _m15341e333f3e606a(DiedEventArgs ev)
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		string text;
		string value;
		string value2;
		string value3;
		do
		{
			if (ev == null || ev.Attacker == null || ev.Player == null)
			{
				return;
			}
			text = _m466f726d6174456c617073656454696d653a300(Round.ElapsedTime);
			value = _m476574526f6c65446973706c61794e616d653a300(ev.Attacker.Role.Type);
			value2 = _m476574526f6c65446973706c61794e616d653a300(ev.TargetOldRole);
			value3 = _m4765744b696c6c536f757263653a300(ev.DamageHandler);
		}
		while ((Object)(object)ev.Player.CurrentRoom == (Object)null);
		string value4 = ((object)ev.Player.CurrentRoom.Type/*cast due to .constrained prefix*/).ToString();
		string item = string.Format(Encoding.UTF8.GetString(Convert.FromBase64String("W3swfV1bezF9XVt7Mn1dW3szfV0g5L2/55SoIFt7NH1dIOadgOatu+S6hiBbezV9XVt7Nn1dW3s3fV0=")), text, ev.Attacker.Id, _m0e350a363b33340e3f222e606a(ev.Attacker.Nickname), _m0e350a363b33340e3f222e606a(value), _m0e350a363b33340e3f222e606a(value3), _m0e350a363b33340e3f222e606a(ev.Player.Nickname), _m0e350a363b33340e3f222e606a(value2), _m0e350a363b33340e3f222e606a(value4));
		lock (_fFiYSFEIPEplz)
		{
			_f6b696c6c5265636f7264733a300.Add(item);
		}
	}

	private void _m4f6e526f756e64537461727465643a300()
	{
		Reset();
	}

	private void _mmkFyOeeTWTag()
	{
		Reset();
	}

	private void _m4f6e52657374617274696e67526f756e643a300()
	{
		Reset();
	}

	private void Reset()
	{
		lock (_fFiYSFEIPEplz)
		{
			_f6b696c6c5265636f7264733a300.Clear();
			_f3b3e373334193537373b343e083f3935283e29606a.Clear();
		}
	}

	private static string _m4275696c64526573706f6e73653a300(string title, IList<string> records)
	{
		if (records.Count == 0)
		{
			return title;
		}
		StringBuilder stringBuilder = new StringBuilder(title);
		foreach (string record in records)
		{
			stringBuilder.AppendLine();
			stringBuilder.Append(record);
		}
		return stringBuilder.ToString();
	}

	private static string _m466f726d6174456c617073656454696d653a300(TimeSpan elapsed)
	{
		return Math.Max(0, (int)elapsed.TotalMinutes).ToString(Encoding.UTF8.GetString(Convert.FromBase64String("MDA="))) + Encoding.UTF8.GetString(Convert.FromBase64String("Og==")) + elapsed.Seconds.ToString(Encoding.UTF8.GetString(Convert.FromBase64String("MDA=")));
	}

	private static string _mZzKVoBtyBZae(string userId)
	{
		string text = _m0e350a363b33340e3f222e606a(userId);
		int num = text.LastIndexOf('@');
		if (num <= 0)
		{
			return text;
		}
		return text.Substring(0, num);
	}

	private static string _m4765744b696c6c536f757263653a300(CustomDamageHandler damageHandler)
	{
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		if (damageHandler == null)
		{
			return Encoding.UTF8.GetString(Convert.FromBase64String("VW5rbm93bg=="));
		}
		DamageHandlerBase customBase = damageHandler.CustomBase;
		FirearmDamageHandler val = (FirearmDamageHandler)(object)((customBase is FirearmDamageHandler) ? customBase : null);
		if (val != null && val.Item != null)
		{
			string text = ((object)val.Item.Type/*cast due to .constrained prefix*/).ToString();
			if (!text.StartsWith(Encoding.UTF8.GetString(Convert.FromBase64String("R3Vu")), StringComparison.Ordinal))
			{
				return text;
			}
			return text.Substring(3);
		}
		string text2 = ((object)((DamageHandlerBase)damageHandler).Type/*cast due to .constrained prefix*/).ToString();
		if ((string.Equals(text2, Encoding.UTF8.GetString(Convert.FromBase64String("Q3VzdG9t")), StringComparison.OrdinalIgnoreCase) || string.Equals(text2, Encoding.UTF8.GetString(Convert.FromBase64String("VW5rbm93bg==")), StringComparison.OrdinalIgnoreCase)) && damageHandler.CustomBase != null && !string.IsNullOrWhiteSpace(damageHandler.CustomBase.ServerLogsText))
		{
			return damageHandler.CustomBase.ServerLogsText;
		}
		return text2;
	}

	private static string _m0e350a363b33340e3f222e606a(string value)
	{
		if (string.IsNullOrEmpty(value))
		{
			return string.Empty;
		}
		return _f526963685465787454616752656765783a300.Replace(value, string.Empty).Replace(Encoding.UTF8.GetString(Convert.FromBase64String("DQ==")), Encoding.UTF8.GetString(Convert.FromBase64String("IA=="))).Replace(Encoding.UTF8.GetString(Convert.FromBase64String("Cg==")), Encoding.UTF8.GetString(Convert.FromBase64String("IA==")))
			.Replace(Encoding.UTF8.GetString(Convert.FromBase64String("PA==")), string.Empty)
			.Replace(Encoding.UTF8.GetString(Convert.FromBase64String("Pg==")), string.Empty);
	}

	private unsafe static string _m476574526f6c65446973706c61794e616d653a300(RoleTypeId roleType)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected I4, but got Unknown
		while (true)
		{
			switch ((int)roleType)
			{
			case 0:
			case 1:
			case 2:
			case 3:
			case 4:
			case 5:
			case 6:
			case 7:
			case 8:
			case 9:
			case 10:
			case 11:
			case 12:
			case 13:
			case 14:
			case 15:
			case 16:
			case 18:
			case 19:
			case 20:
			case 21:
				break;
			default:
				return Encoding.UTF8.GetString(Convert.FromBase64String("ROe6p+S6uuWRmA=="));
			case 17:
				return ((object)(*(RoleTypeId*)(&roleType))/*cast due to .constrained prefix*/).ToString();
			}
		}
	}
}
