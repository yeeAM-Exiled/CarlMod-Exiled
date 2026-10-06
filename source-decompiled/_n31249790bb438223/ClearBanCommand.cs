using System;
using System.Text;
using CommandSystem;

namespace _n31249790bb438223;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public sealed class ClearBanCommand : ICommand
{
	public string Command => Encoding.UTF8.GetString(Convert.FromBase64String("Y2xiYW4="));

	public string[] Aliases => Array.Empty<string>();

	public string Description => Encoding.UTF8.GetString(Convert.FromBase64String("6YCa6L+HIElQIOaIliBTdGVhbUlEIOebtOaOpeenu+mZpOWwgeemgQ=="));

	public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
	{
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		if (!Misc.CheckPermission(sender, (PlayerPermissions)4, ref response))
		{
			return false;
		}
		if (arguments.Count != 1)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("55So5rOVOiBjbGJhbiA8SVAvU3RlYW1JRD4="));
			return false;
		}
		string text = (CollectionExtensions.At<string>(arguments, 0) ?? string.Empty).Trim();
		IPAddressType val = default(IPAddressType);
		BanType val2;
		string userId;
		string text2;
		if (Misc.ValidateIpOrHostname(text, ref val, false, false))
		{
			val2 = (BanType)1;
			userId = text;
			text2 = Encoding.UTF8.GetString(Convert.FromBase64String("SVA="));
		}
		else
		{
			if (!_m5472794e6f726d616c697a65537465616d49643a300(text, out userId))
			{
				response = Encoding.UTF8.GetString(Convert.FromBase64String("55uu5qCH5qC85byP5peg5pWI77yM6K+35o+Q5L6b5pyJ5pWI55qEIElQdjTjgIFJUHY2IOaIliBTdGVhbUlENjTjgII="));
				return false;
			}
			val2 = (BanType)0;
			text2 = Encoding.UTF8.GetString(Convert.FromBase64String("U3RlYW1JRA=="));
		}
		BanDetails ban = BanHandler.GetBan(userId, val2);
		if (ban == null)
		{
			response = text2 + Encoding.UTF8.GetString(Convert.FromBase64String("IA==")) + text + Encoding.UTF8.GetString(Convert.FromBase64String("IOS4jeWcqOWwgeemgeWIl+ihqOS4reOAgg=="));
			return false;
		}
		BanHandler.RemoveBan(ban.Id, val2, false);
		if (BanHandler.GetBan(ban.Id, val2) != null)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("56e76Zmk5bCB56aB5aSx6LSl77yM5pON5L2c5Y+v6IO96KKr5YW25LuW5o+S5Lu25Y+W5raI44CC"));
			return false;
		}
		ServerLogs.AddLog((Modules)4, sender.LogName + Encoding.UTF8.GetString(Convert.FromBase64String("IHJlbW92ZWQgdGhlIGJhbiBmb3Ig")) + text2 + Encoding.UTF8.GetString(Convert.FromBase64String("IA==")) + ban.Id + Encoding.UTF8.GetString(Convert.FromBase64String("IHVzaW5nIGNsYmFuLg==")), (ServerLogType)1, false);
		response = Encoding.UTF8.GetString(Convert.FromBase64String("5bey56e76ZmkIA==")) + text2 + Encoding.UTF8.GetString(Convert.FromBase64String("IA==")) + ban.Id + Encoding.UTF8.GetString(Convert.FromBase64String("IOeahOWwgeemgeOAgg=="));
		return true;
	}

	private static bool _m5472794e6f726d616c697a65537465616d49643a300(string value, out string userId)
	{
		userId = null;
		if (string.IsNullOrWhiteSpace(value))
		{
			return false;
		}
		string text = value;
		if (value.EndsWith(Encoding.UTF8.GetString(Convert.FromBase64String("QHN0ZWFt")), StringComparison.OrdinalIgnoreCase))
		{
			text = value.Substring(0, value.Length - Encoding.UTF8.GetString(Convert.FromBase64String("QHN0ZWFt")).Length);
		}
		if (text.Length != 17 || !ulong.TryParse(text, out var _))
		{
			return false;
		}
		userId = text + Encoding.UTF8.GetString(Convert.FromBase64String("QHN0ZWFt"));
		return true;
	}
}
