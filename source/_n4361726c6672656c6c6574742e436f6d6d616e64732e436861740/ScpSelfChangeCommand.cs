using System;
using System.Text;
using CommandSystem;

namespace _n4361726c6672656c6c6574742e436f6d6d616e64732e436861740;

[CommandHandler(typeof(ClientCommandHandler))]
public sealed class ScpSelfChangeCommand : ICommand
{
	public string Command => Encoding.UTF8.GetString(Convert.FromBase64String("c2NwYw=="));

	public string[] Aliases => Array.Empty<string>();

	public string Description => Encoding.UTF8.GetString(Convert.FromBase64String("6Ieq5Yqp5pu05o2i5Li65b2T5YmN5peg5Lq65Y2g55So55qEIFNDUA=="));

	public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
	{
		if (!_t09392a193537373b343e1935342e3f222e606a.TryGet(sender, out var player, out var system, out response))
		{
			return false;
		}
		string roleCode = ((arguments.Count > 0) ? CollectionExtensions.At<string>(arguments, 0) : null);
		return system.TrySelfChange(player, roleCode, out response);
	}
}
