using System;
using System.Text;
using CommandSystem;
using Exiled.API.Features;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n31249790bb438223;

[CommandHandler(typeof(ClientCommandHandler))]
public sealed class LobbyMusicCommand : ICommand
{
	public string Command => Encoding.UTF8.GetString(Convert.FromBase64String("bG9iYnltdXNpYw=="));

	public string[] Aliases => new string[2]
	{
		Encoding.UTF8.GetString(Convert.FromBase64String("bG11c2lj")),
		Encoding.UTF8.GetString(Convert.FromBase64String("5aSn5Y6F6Z+z5LmQ"))
	};

	public string Description => Encoding.UTF8.GetString(Convert.FromBase64String("5byA5ZCv5oiW5ouS57ud5o6l5pS25aSn5Y6F6Z+z5LmQ55uS"));

	public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
	{
		Player val;
		MusicBoxSystem instance;
		do
		{
			val = Player.Get(sender);
			if (val == null)
			{
				response = Encoding.UTF8.GetString(Convert.FromBase64String("5Y+q5pyJ546p5a625Y+v5Lul5L2/55So5q2k5ZG95Luk44CC"));
				return false;
			}
			instance = MusicBoxSystem.Instance;
			if (instance == null)
			{
				response = Encoding.UTF8.GetString(Convert.FromBase64String("6Z+z5LmQ55uS57O757uf5bCa5pyq5ZCv55So44CC"));
				return false;
			}
			if (arguments.Count > 1)
			{
				response = _m1d3f2e0f293b3d3f606a();
				return false;
			}
		}
		while (arguments.Count == 0);
		string text = CollectionExtensions.At<string>(arguments, 0).Trim().ToLowerInvariant();
		if (text == Encoding.UTF8.GetString(Convert.FromBase64String("c3RhdHVz")) || text == Encoding.UTF8.GetString(Convert.FromBase64String("54q25oCB")))
		{
			if (!instance.IsLobbyMusicEnabled(val))
			{
			}
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5b2T5YmN5bey5ouS57ud5o6l5pS25aSn5Y6F6Z+z5LmQ55uS77ybTVZQIOmfs+S5kOS4juS4quS6uuivleWQrOS4jeWPl+W9seWTjeOAgg=="));
			return true;
		}
		bool flag;
		if (text == Encoding.UTF8.GetString(Convert.FromBase64String("b24=")) || text == Encoding.UTF8.GetString(Convert.FromBase64String("5byA5ZCv")) || text == Encoding.UTF8.GetString(Convert.FromBase64String("5oGi5aSN")))
		{
			flag = true;
		}
		if (text == Encoding.UTF8.GetString(Convert.FromBase64String("b2Zm")) || text == Encoding.UTF8.GetString(Convert.FromBase64String("5YWz6Zet")) || text == Encoding.UTF8.GetString(Convert.FromBase64String("5ouS57ud")))
		{
			flag = false;
		}
		else
		{
			if (!(text == Encoding.UTF8.GetString(Convert.FromBase64String("dG9nZ2xl"))) && !(text == Encoding.UTF8.GetString(Convert.FromBase64String("5YiH5o2i"))))
			{
				response = _m1d3f2e0f293b3d3f606a();
				return false;
			}
			flag = !instance.IsLobbyMusicEnabled(val);
		}
		return instance.TrySetLobbyMusicEnabled(val, flag, out response);
	}

	private static string _m1d3f2e0f293b3d3f606a()
	{
		return Encoding.UTF8.GetString(Convert.FromBase64String("55So5rOVOiAubG9iYnltdXNpYyBbb258b2ZmfHRvZ2dsZXxzdGF0dXNd77yI566A5YaZ77yaLmxtdXNpY++8m+S4jeW4puWPguaVsOebtOaOpeWIh+aNou+8iQ=="));
	}
}
