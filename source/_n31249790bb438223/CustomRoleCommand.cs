using System;
using System.Text;
using CommandSystem;
using Exiled.API.Features;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n31249790bb438223;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public sealed class CustomRoleCommand : ICommand
{
	public string Command => Encoding.UTF8.GetString(Convert.FromBase64String("Y3VzdG9tcm9sZQ=="));

	public string[] Aliases => new string[1] { Encoding.UTF8.GetString(Convert.FromBase64String("Y3JvbGU=")) };

	public string Description => Encoding.UTF8.GetString(Convert.FromBase64String("5by65Yi26LWL5LqI5Zyo57q/546p5a625LiA5Liq6Ieq5a6a5LmJ6KeS6Imy44CC"));

	public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
	{
		Player val = Player.Get(sender);
		if (val != null && !val.RemoteAdminAccess)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5Y+q5pyJ566h55CG5ZGY5omN6IO95L2/55So5q2k5oyH5Luk44CC"));
			return false;
		}
		if (arguments.Count != 2)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("55So5rOVOiBjdXN0b21yb2xlfGNyb2xlIDwwNzN8MTgxfDU1MHw5OTk+IDznjqnlrrZJRC9Vc2VySUQv5pi156ewPg=="));
			return false;
		}
		return CustomRoleSystem.TryAssign(CollectionExtensions.At<string>(arguments, 0), CollectionExtensions.At<string>(arguments, 1), out response);
	}
}
