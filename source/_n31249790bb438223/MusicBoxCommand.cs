using System;
using System.Text;
using CommandSystem;
using Exiled.API.Features;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n31249790bb438223;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public sealed class MusicBoxCommand : ICommand
{
	public string Command => Encoding.UTF8.GetString(Convert.FromBase64String("bXVyYg=="));

	public string[] Aliases => new string[1] { Encoding.UTF8.GetString(Convert.FromBase64String("bXVzaWNib3g=")) };

	public string Description => Encoding.UTF8.GetString(Convert.FromBase64String("5Li6546p5a6257uR5a6aIE1WUC/lpKfljoXpn7PkuZDjgIHmnLrlmajkurrlkI3np7DkuI7mgLvpn7Pph48="));

	public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
	{
		Player val = Player.Get(sender);
		if (val != null && !val.RemoteAdminAccess)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5Y+q5pyJ5Y+v6K6/6Zeu566h55CG5ZGY6Z2i5p2/55qE546p5a625omN6IO95L2/55So5q2k5ZG95Luk44CC"));
			return false;
		}
		MusicBoxSystem instance = MusicBoxSystem.Instance;
		if (instance == null)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("6Z+z5LmQ55uS57O757uf5bCa5pyq5ZCv55So44CC"));
			return false;
		}
		if (arguments.Count < 2 || arguments.Count > 6)
		{
		}
		response = Encoding.UTF8.GetString(Convert.FromBase64String("55So5rOVOiBtdXJiIDznjqnlrrY+IDxNVlDpn7PkuZA+IFvlpKfljoXpn7PkuZBdIFtNVlDmnLrlmajkurrlkI1dIFvlpKfljoXmnLrlmajkurrlkI1dIFvmgLvpn7Pph49d")) + Environment.NewLine + Encoding.UTF8.GetString(Convert.FromBase64String("TVZQIOmfs+S5kOW/heWhq++8jOWkp+WOhemfs+S5kOWPr+mAie+8m+S4jeWhq+WGmeWkp+WOhemfs+S5kOaXtuS4jeS8muWcqOWkp+WOheaSreaUvuOAgg==")) + Environment.NewLine + Encoding.UTF8.GetString(Convert.FromBase64String("5Y+v6YCJ5Y+C5pWw6ZyA6KaB6Lez6L+H5pe25aGr5YaZIC3vvJvmgLvpn7Pph4/ojIPlm7TkuLogMCDliLAgMTAw44CC")) + Environment.NewLine + Encoding.UTF8.GetString(Convert.FromBase64String("6Z+z5LmQ5ZCN5oiW5py65Zmo5Lq65ZCN5YyF5ZCr56m65qC85pe26K+35L2/55So5byV5Y+344CC")) + Environment.NewLine + Encoding.UTF8.GetString(Convert.FromBase64String("6Z+z5LmQ55uu5b2VOiA=")) + instance.MusicDirectory;
		return false;
	}

	private static string _m4e6f726d616c697a654f7074696f6e616c417267756d656e743a300(string value)
	{
		if (string.IsNullOrWhiteSpace(value) || value.Trim() == Encoding.UTF8.GetString(Convert.FromBase64String("LQ==")))
		{
			return null;
		}
		return value.Trim();
	}
}
