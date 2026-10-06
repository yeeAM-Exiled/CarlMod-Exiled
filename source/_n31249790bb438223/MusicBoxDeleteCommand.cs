using System;
using System.Text;
using CommandSystem;
using Exiled.API.Features;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n31249790bb438223;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public sealed class MusicBoxDeleteCommand : ICommand
{
	public string Command => Encoding.UTF8.GetString(Convert.FromBase64String("bXVyYmQ="));

	public string[] Aliases => new string[1] { Encoding.UTF8.GetString(Convert.FromBase64String("bXVzaWNib3hkZWxldGU=")) };

	public string Description => Encoding.UTF8.GetString(Convert.FromBase64String("56e76Zmk546p5a6257uR5a6a55qE6Z+z5LmQ55uS"));

	public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
	{
		Player val = Player.Get(sender);
		if (val != null && !val.RemoteAdminAccess)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5Y+q5pyJ5Y+v6K6/6Zeu566h55CG5ZGY6Z2i5p2/55qE546p5a625omN6IO95L2/55So5q2k5ZG95Luk44CC"));
			return false;
		}
		if (arguments.Count != 1)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("55So5rOVOiBtdXJiZCA8546p5a62SUQvU3RlYW1JRD4="));
			return false;
		}
		MusicBoxSystem instance = MusicBoxSystem.Instance;
		if (instance == null)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("6Z+z5LmQ55uS57O757uf5bCa5pyq5ZCv55So44CC"));
			return false;
		}
		string text = (CollectionExtensions.At<string>(arguments, 0) ?? string.Empty).Trim();
		Player val2 = MusicBoxSystem.FindOnlinePlayer(text);
		string text2 = ((val2 == null) ? MusicBoxSystem.NormalizeUserId(text) : val2.UserId);
		if (val2 == null && (string.IsNullOrWhiteSpace(text2) || text2.IndexOf('@') < 0))
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5bGA5YaFIElEIOacquaJvuWIsOeOqeWutu+8m+emu+e6v+enu+mZpOaXtuivt+aPkOS+m+WujOaVtCBTdGVhbUlENjQg5oiWIFVzZXJJROOAgg=="));
			return false;
		}
		if (!instance.TryRemove(text2, out var normalizedUserId, out var error))
		{
			response = error;
			return false;
		}
		response = Encoding.UTF8.GetString(Convert.FromBase64String("5bey56e76ZmkIA==")) + normalizedUserId + Encoding.UTF8.GetString(Convert.FromBase64String("IOeahOmfs+S5kOebkuOAgg=="));
		return true;
	}
}
