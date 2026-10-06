using System;
using System.Globalization;
using System.Text;
using CommandSystem;
using Exiled.API.Features;

namespace _n31249790bb438223;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public sealed class AdminAnnouncementCommand : ICommand
{
	private const int _f17333433372f371e2f283b2e333534093f3935343e29606a = 1;

	private const int _f4d6178696d756d4475726174696f6e5365636f6e64733a300 = 30;

	public string Command => Encoding.UTF8.GetString(Convert.FromBase64String("YW5ub3VuY2U="));

	public string[] Aliases => new string[2]
	{
		Encoding.UTF8.GetString(Convert.FromBase64String("YW5u")),
		Encoding.UTF8.GetString(Convert.FromBase64String("5YWs5ZGK"))
	};

	public string Description => Encoding.UTF8.GetString(Convert.FromBase64String("5L2/55SoIFJ1ZUkg5ZCR5omA5pyJ546p5a625pi+56S66YaS55uu55qE566h55CG5ZGY5YWs5ZGK44CC"));

	public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
	{
		int result;
		do
		{
			Player val = Player.Get(sender);
			if (val != null && !val.RemoteAdminAccess)
			{
				response = Encoding.UTF8.GetString(Convert.FromBase64String("5Y+q5pyJ566h55CG5ZGY5Y+v5Lul5L2/55So5q2k5oyH5Luk44CC"));
				return false;
			}
			if (arguments.Count < 2)
			{
				response = Encoding.UTF8.GetString(Convert.FromBase64String("55So5rOVOiBhbm5vdW5jZSA8MS0zMOenkj4gPOWFrOWRiuWGheWuuT4="));
				return false;
			}
		}
		while (int.TryParse(CollectionExtensions.At<string>(arguments, 0), NumberStyles.Integer, CultureInfo.InvariantCulture, out result) && result >= 1 && result <= 30);
		response = Encoding.UTF8.GetString(Convert.FromBase64String("5YWs5ZGK5pe26Ze05b+F6aG75pivIDEg5YiwIDMwIOenkuS5i+mXtOeahOaVtOaVsOOAgg=="));
		return false;
	}
}
