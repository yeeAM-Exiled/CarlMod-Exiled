using System;
using System.Text;
using CommandSystem;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n31249790bb438223;

[CommandHandler(typeof(ClientCommandHandler))]
[CommandHandler(typeof(RemoteAdminCommandHandler))]
public sealed class RoundKillLogCommand : ICommand
{
	public string Command => Encoding.UTF8.GetString(Convert.FromBase64String("Z2s="));

	public string[] Aliases => Array.Empty<string>();

	public string Description => Encoding.UTF8.GetString(Convert.FromBase64String("6I635Y+W5pys5bGA5Ye75p2A6K+m5oOF"));

	public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
	{
		RoundActivityLog instance = RoundActivityLog.Instance;
		if (instance == null)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5Ye75p2A6K6w5b2V5pyN5Yqh5bCa5pyq5ZCv55So44CC"));
			return false;
		}
		response = instance.BuildKillLogText();
		return true;
	}
}
