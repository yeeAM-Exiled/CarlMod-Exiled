using System;
using System.Text;
using CommandSystem;
using Exiled.API.Features;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n4361726c6672656c6c6574742e436f6d6d616e64732e436861740;

[CommandHandler(typeof(ClientCommandHandler))]
public sealed class TeamChatCommand : ICommand
{
	public string Command => Encoding.UTF8.GetString(Convert.FromBase64String("Yw=="));

	public string[] Aliases => new string[1] { Encoding.UTF8.GetString(Convert.FromBase64String("dGVhbWNoYXQ=")) };

	public string Description => Encoding.UTF8.GetString(Convert.FromBase64String("5Zui6Zif6IGK5aSp"));

	public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
	{
		if (arguments.Count == 0)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("55So5rOVOiAuYyA85paH5pysPg=="));
			return false;
		}
		Player val = Player.Get(sender);
		if (val == null)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5Y+q5pyJ546p5a625Y+v5Lul5L2/55So5q2k5ZG95Luk44CC"));
			return false;
		}
		if (val.IsMuted)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5L2g5b2T5YmN5aSE5LqO56aB6KiA54q25oCB77yM5peg5rOV5L2/55So6IGK5aSp5ZG95Luk44CC"));
			return false;
		}
		RueITextChat instance = RueITextChat.Instance;
		if (instance == null)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("UnVlSSDmlofmnKzogYrlpKnlsJrmnKrlkK/nlKjjgII="));
			return false;
		}
		if (!instance.CanUseTeamChat(val))
		{
		}
		response = Encoding.UTF8.GetString(Convert.FromBase64String("5b2T5YmN6KeS6Imy5rKh5pyJ5Y+v55So55qE5Zui6Zif6IGK5aSp6Zi16JCl44CC"));
		return false;
	}
}
