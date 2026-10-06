using System;
using System.Text;
using CommandSystem;
using Exiled.API.Features;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n31249790bb438223;

[CommandHandler(typeof(ClientCommandHandler))]
[CommandHandler(typeof(RemoteAdminCommandHandler))]
public sealed class MusicBoxTestCommand : ICommand
{
	public string Command => Encoding.UTF8.GetString(Convert.FromBase64String("bWJ0ZXN0"));

	public string[] Aliases => new string[2]
	{
		Encoding.UTF8.GetString(Convert.FromBase64String("bXVzaWN0ZXN0")),
		Encoding.UTF8.GetString(Convert.FromBase64String("6Z+z5LmQ55uS5rWL6K+V"))
	};

	public string Description => Encoding.UTF8.GetString(Convert.FromBase64String("5LuF6Ieq5bex6K+V5ZCs5bey57uR5a6a55qE6Z+z5LmQ55uS6Z+z6aKR"));

	public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
	{
		Player val;
		MusicBoxSystem instance;
		Player val2;
		do
		{
			val = Player.Get(sender);
			if (val == null)
			{
				response = Encoding.UTF8.GetString(Convert.FromBase64String("6K+l5oyH5Luk5Y+q6IO955Sx5bGA5YaF546p5a625L2/55So44CC"));
				return false;
			}
			instance = MusicBoxSystem.Instance;
			if (instance == null)
			{
				response = Encoding.UTF8.GetString(Convert.FromBase64String("6Z+z5LmQ55uS57O757uf5bCa5pyq5ZCv55So44CC"));
				return false;
			}
			if (arguments.Count > 2)
			{
				response = _m1d3f2e0f293b3d3f606a(val.RemoteAdminAccess);
				return false;
			}
			val2 = val;
		}
		while (arguments.Count == 0);
		string text = CollectionExtensions.At<string>(arguments, 0).Trim().ToLowerInvariant();
		if (!_m132917353e3f606a(text))
		{
			if (!val.RemoteAdminAccess)
			{
				response = _m1d3f2e0f293b3d3f606a(canTestOthers: false);
				return false;
			}
			val2 = MusicBoxSystem.FindOnlinePlayer(CollectionExtensions.At<string>(arguments, 0).Trim());
			if (val2 == null)
			{
				response = Encoding.UTF8.GetString(Convert.FromBase64String("5pyq5om+5Yiw5oyH5a6a55qE5bGA5YaF546p5a6244CC"));
				return false;
			}
			text = ((arguments.Count >= 2) ? CollectionExtensions.At<string>(arguments, 1).Trim().ToLowerInvariant() : Encoding.UTF8.GetString(Convert.FromBase64String("bXZw")));
		}
		if (text == Encoding.UTF8.GetString(Convert.FromBase64String("c3RvcA==")) || text == Encoding.UTF8.GetString(Convert.FromBase64String("5YGc5q2i")))
		{
			bool flag = instance.StopTest(val);
			if (!flag)
			{
			}
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5b2T5YmN5rKh5pyJ5q2j5Zyo5pKt5pS+55qE5rWL6K+V6Z+z6aKR44CC"));
			return flag;
		}
		bool flag2;
		if (text == Encoding.UTF8.GetString(Convert.FromBase64String("bXZw")))
		{
			flag2 = false;
		}
		else
		{
			if (!(text == Encoding.UTF8.GetString(Convert.FromBase64String("bG9iYnk="))) && !(text == Encoding.UTF8.GetString(Convert.FromBase64String("5aSn5Y6F"))))
			{
				response = _m1d3f2e0f293b3d3f606a(val.RemoteAdminAccess);
				return false;
			}
			flag2 = true;
		}
		if (!instance.TryPlayTest(val, val2.UserId, flag2, out var musicName, out var error))
		{
			response = error;
			return false;
		}
		string[] obj = new string[7]
		{
			Encoding.UTF8.GetString(Convert.FromBase64String("5q2j5Zyo6K+V5ZCs")),
			null,
			null,
			null,
			null,
			null,
			null
		};
		if (!flag2)
		{
		}
		obj[1] = Encoding.UTF8.GetString(Convert.FromBase64String("TVZQ"));
		obj[2] = Encoding.UTF8.GetString(Convert.FromBase64String("6Z+z5LmQ44CO"));
		obj[3] = musicName;
		obj[4] = Encoding.UTF8.GetString(Convert.FromBase64String("44CP"));
		obj[5] = ((val2 == val) ? string.Empty : (Encoding.UTF8.GetString(Convert.FromBase64String("77yI57uR5a6a546p5a6277ya")) + val2.Nickname + Encoding.UTF8.GetString(Convert.FromBase64String("77yJ"))));
		obj[6] = Encoding.UTF8.GetString(Convert.FromBase64String("77yM5pys5qyh6Z+z6aKR5LuF5L2g5Y+v5ZCs44CC6L6T5YWlIC5tYnRlc3Qgc3RvcCDlj6/lgZzmraLjgII="));
		response = string.Concat(obj);
		return true;
	}

	private static bool _m132917353e3f606a(string mode)
	{
		if (!(mode == Encoding.UTF8.GetString(Convert.FromBase64String("bXZw"))) && !(mode == Encoding.UTF8.GetString(Convert.FromBase64String("bG9iYnk="))) && !(mode == Encoding.UTF8.GetString(Convert.FromBase64String("5aSn5Y6F"))) && !(mode == Encoding.UTF8.GetString(Convert.FromBase64String("c3RvcA=="))))
		{
			return mode == Encoding.UTF8.GetString(Convert.FromBase64String("5YGc5q2i"));
		}
		return true;
	}

	private static string _m1d3f2e0f293b3d3f606a(bool canTestOthers)
	{
		string text = Encoding.UTF8.GetString(Convert.FromBase64String("55So5rOVOiAubWJ0ZXN0IFttdnB8bG9iYnl8c3RvcF3vvIjpu5jorqTmtYvor5Xoh6rlt7HnmoQgTVZQIOmfs+S5kO+8iQ=="));
		if (!canTestOthers)
		{
			return text;
		}
		return text + Environment.NewLine + Encoding.UTF8.GetString(Convert.FromBase64String("566h55CG5ZGY5Luj5rWLOiBtYnRlc3QgPOWxgOWGheeOqeWutklEL1N0ZWFtSUQ2NC9Vc2VySUQ+IFttdnB8bG9iYnld"));
	}
}
