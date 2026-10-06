using System;
using System.Text;
using CommandSystem;
using Exiled.API.Features;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n4361726c6672656c6c6574742e436f6d6d616e64732e436861740;

[CommandHandler(typeof(ClientCommandHandler))]
public sealed class AdminCallCommand : ICommand
{
	public string Command => Encoding.UTF8.GetString(Convert.FromBase64String("YWM="));

	public string[] Aliases => new string[1] { Encoding.UTF8.GetString(Convert.FromBase64String("YWRtaW5jYWxs")) };

	public string Description => Encoding.UTF8.GetString(Convert.FromBase64String("566h55CG5ZGY5rGC5Yqp"));

	public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
	{
		RueITextChat instance;
		do
		{
			if (arguments.Count == 0)
			{
				response = Encoding.UTF8.GetString(Convert.FromBase64String("55So5rOVOiAuYWMgPOaWh+acrD4="));
				return false;
			}
			Player val = Player.Get(sender);
			if (val == null)
			{
				response = Encoding.UTF8.GetString(Convert.FromBase64String("5Y+q5pyJ546p5a625Y+v5Lul5L2/55So5q2k5ZG95Luk44CC"));
				return false;
			}
			instance = RueITextChat.Instance;
		}
		while (instance != null);
		response = Encoding.UTF8.GetString(Convert.FromBase64String("UnVlSSDmlofmnKzogYrlpKnlsJrmnKrlkK/nlKjjgII="));
		return false;
	}
}
