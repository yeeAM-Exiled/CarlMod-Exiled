using System;
using System.Text;
using CommandSystem;
using Exiled.API.Features;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n31249790bb438223;

[CommandHandler(typeof(ClientCommandHandler))]
public sealed class ExperienceInfoCommand : ICommand
{
	public string Command => Encoding.UTF8.GetString(Convert.FromBase64String("ZXhw"));

	public string[] Aliases => new string[1] { Encoding.UTF8.GetString(Convert.FromBase64String("eHA=")) };

	public string Description => Encoding.UTF8.GetString(Convert.FromBase64String("5p+l6K+i562J57qn44CB57uP6aqM44CB5qKm5rOh5LiO5Y2H57qn6L+b5bqm"));

	public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
	{
		Player val = Player.Get(sender);
		if (val == null)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5Y+q5pyJ546p5a625Y+v5Lul5L2/55So5q2k5ZG95Luk44CC"));
			return false;
		}
		ExperienceSystem instance = ExperienceSystem.Instance;
		if (instance == null)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("57uP6aqM57O757uf5bCa5pyq5ZCv55So44CC"));
			return false;
		}
		return instance.TryBuildCurrentExperienceResponse(val, out response);
	}
}
