using System;
using System.Text;
using CommandSystem;

namespace _n31249790bb438223;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public class SendCommandToServer : ICommand
{
	public string Command => Encoding.UTF8.GetString(Convert.FromBase64String("c2VuZGNvbW1hbmR0b3NlcnZlcg=="));

	public string[] Aliases => new string[1] { Encoding.UTF8.GetString(Convert.FromBase64String("c2Nz")) };

	public string Description => Encoding.UTF8.GetString(Convert.FromBase64String("6L+c56iL5omn6KGM5pyN5Yqh5Zmo5oyH5Luk"));

	public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
	{
		//Discarded unreachable code: IL_0041, IL_00a7
		while (arguments.Count != 0)
		{
		}
		response = Encoding.UTF8.GetString(Convert.FromBase64String("55So5rOVOiBzY3MgPHNlcnZlcl9jb21tYW5kPg=="));
		return false;
	}
}
