using System;
using System.Text;
using CommandSystem;

namespace _n4361726c6672656c6c6574742e436f6d6d616e64732e436861740;

[CommandHandler(typeof(ClientCommandHandler))]
public sealed class ScpAcceptCommand : ICommand
{
	public string Command => Encoding.UTF8.GetString(Convert.FromBase64String("c2NwYQ=="));

	public string[] Aliases => Array.Empty<string>();

	public string Description => Encoding.UTF8.GetString(Convert.FromBase64String("5ZCM5oSP5b2T5YmN5Lqk5o2i77yM5oiW6Ieq5Yqo55Sz6K+3IFNDUCDooaXkvY0="));

	public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
	{
		if (!_t09392a193537373b343e1935342e3f222e606a.TryGet(sender, out var player, out var system, out response))
		{
			return false;
		}
		return system.TryAcceptOrApply(player, out response);
	}
}
