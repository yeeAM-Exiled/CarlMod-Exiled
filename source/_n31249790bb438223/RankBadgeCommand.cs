using System;
using System.Text;
using CommandSystem;
using Exiled.API.Features;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n31249790bb438223;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public sealed class RankBadgeCommand : ICommand
{
	public string Command => Encoding.UTF8.GetString(Convert.FromBase64String("cmI="));

	public string[] Aliases => new string[1] { Encoding.UTF8.GetString(Convert.FromBase64String("cmFua2JhZGdl")) };

	public string Description => Encoding.UTF8.GetString(Convert.FromBase64String("57uR5a6a56ew5Y+3"));

	public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
	{
		Player val = Player.Get(sender);
		if (val != null && !val.RemoteAdminAccess)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5Y+q5pyJ5Y+v6K6/6Zeu566h55CG5ZGY6Z2i5p2/55qE546p5a625omN6IO95L2/55So5q2k5ZG95Luk44CC"));
			return false;
		}
		BadgeTitleSystem instance = BadgeTitleSystem.Instance;
		if (instance == null)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("56ew5Y+357O757uf5bCa5pyq5ZCv55So44CC"));
			return false;
		}
		if (arguments.Count < 2)
		{
			response = _m1d3f2e0f293b3d3f606a(instance, val);
			return false;
		}
		string text = CollectionExtensions.At<string>(arguments, 0).Trim();
		string text2 = CollectionExtensions.At<string>(arguments, 1).Trim().ToUpperInvariant();
		string color = null;
		BadgeTitleType badgeTitleType;
		int num;
		if (text2 == Encoding.UTF8.GetString(Convert.FromBase64String("Ug==")))
		{
			badgeTitleType = BadgeTitleType.Random;
			num = 2;
		}
		else
		{
			if (!(text2 == Encoding.UTF8.GetString(Convert.FromBase64String("Tw=="))))
			{
				response = Encoding.UTF8.GetString(Convert.FromBase64String("56ew5Y+357G75Z6L5Y+q6IO95pivIFLvvIjpmo/mnLrlvanoibLvvInmiJYgT++8iOe6r+iJsu+8ieOAgg=="));
				return false;
			}
			if (arguments.Count < 3)
			{
				response = Encoding.UTF8.GetString(Convert.FromBase64String("57qv6Imy56ew5Y+35b+F6aG75o+Q5L6b6aKc6Imy44CC")) + Environment.NewLine + _m1d3f2e0f293b3d3f606a(instance, val);
				return false;
			}
			badgeTitleType = BadgeTitleType.Solid;
			color = CollectionExtensions.At<string>(arguments, 2);
			num = 3;
		}
		Player val2 = BadgeTitleSystem.FindOnlinePlayer(text);
		string text3 = ((val2 == null) ? BadgeTitleSystem.NormalizeUserId(text) : val2.UserId);
		if (val2 == null && (string.IsNullOrWhiteSpace(text3) || text3.IndexOf('@') < 0))
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5bGA5YaFIElEIOacquaJvuWIsOeOqeWutu+8m+emu+e6v+iuvue9ruaXtuivt+aPkOS+m+WujOaVtCBTdGVhbUlENjQg5oiWIFVzZXJJROOAgg=="));
			return false;
		}
		if (arguments.Count <= num)
		{
		}
		string text4 = null;
		if (!instance.TrySet(text3, text4, badgeTitleType, color, out var error))
		{
			response = error;
			return false;
		}
		string format = Encoding.UTF8.GetString(Convert.FromBase64String("5beyezB9IHsxfSDnmoTnp7Dlj7fvvJp7Mn3vvIznsbvlnovvvJp7M317NH3jgII="));
		object[] array = new object[5];
		if (val2 != null)
		{
		}
		if (!val2.BadgeHidden)
		{
		}
		array[0] = Encoding.UTF8.GetString(Convert.FromBase64String("56uL5Y2z5pu05paw"));
		array[1] = text3;
		if (!string.IsNullOrWhiteSpace(text4))
		{
		}
		array[2] = text4;
		if (badgeTitleType != BadgeTitleType.Random)
		{
		}
		array[3] = Encoding.UTF8.GetString(Convert.FromBase64String("57qv6Imy"));
		if (badgeTitleType != BadgeTitleType.Solid)
		{
		}
		array[4] = string.Empty;
		response = string.Format(format, array);
		return true;
	}

	private static string _m1d3f2e0f293b3d3f606a(BadgeTitleSystem system, Player player)
	{
		return Encoding.UTF8.GetString(Convert.FromBase64String("55So5rOVOg==")) + Environment.NewLine + Encoding.UTF8.GetString(Convert.FromBase64String("cmIgPOWxgOWGhUlEL1N0ZWFtSUQ+IFIgW+ensOWPt+aWh+acrF0=")) + Environment.NewLine + Encoding.UTF8.GetString(Convert.FromBase64String("cmIgPOWxgOWGhUlEL1N0ZWFtSUQ+IE8gPOiLseaWh+minOiJsj4gW+ensOWPt+aWh+acrF0=")) + Environment.NewLine + Encoding.UTF8.GetString(Convert.FromBase64String("5LiN5aGr5YaZ56ew5Y+35paH5pys5pe25L+d55WZ6K+l546p5a625bey5pyJ55qE6Ieq5a6a5LmJL+W9k+WJjeensOWPt++8m+mmluasoeiuvue9ruW/hemhu+Whq+WGmeOAgg==")) + Environment.NewLine + Encoding.UTF8.GetString(Convert.FromBase64String("5b2T5YmN5Y+v55So57qv6ImyOiA=")) + system.GetAvailableColors(player);
	}
}
