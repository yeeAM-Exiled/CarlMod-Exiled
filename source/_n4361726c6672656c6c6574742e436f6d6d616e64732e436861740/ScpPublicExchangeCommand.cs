using System;
using System.Text;
using CommandSystem;

namespace _n4361726c6672656c6c6574742e436f6d6d616e64732e436861740;

[CommandHandler(typeof(ClientCommandHandler))]
public sealed class ScpPublicExchangeCommand : ICommand
{
	public string Command => Encoding.UTF8.GetString(Convert.FromBase64String("c2NwcA=="));

	public string[] Aliases => Array.Empty<string>();

	public string Description => Encoding.UTF8.GetString(Convert.FromBase64String("5Y+R6LW36Z2i5ZCR5omA5pyJ546p5a6255qEIFNDUCDlhazlvIDkuqTmjaI="));

	public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
	{
		if (!_t09392a193537373b343e1935342e3f222e606a.TryGet(sender, out var player, out var system, out response))
		{
			return false;
		}
		return system.TryOpenPublicExchange(player, out response);
	}
}
