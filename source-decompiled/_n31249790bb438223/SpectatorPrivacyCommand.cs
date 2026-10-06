using System;
using System.Runtime.CompilerServices;
using System.Text;
using CommandSystem;
using Exiled.API.Features;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n31249790bb438223;

[CommandHandler(typeof(RemoteAdminCommandHandler))]
public sealed class SpectatorPrivacyCommand : ICommand
{
	public string Command => Encoding.UTF8.GetString(Convert.FromBase64String("c3BlY3RhdG9ycHJpdmFjeQ=="));

	public string[] Aliases => new string[1] { Encoding.UTF8.GetString(Convert.FromBase64String("c3BibG9jaw==")) };

	public string Description => Encoding.UTF8.GetString(Convert.FromBase64String("6ZqQ6JS95Zyw6Zi75q2i5oyH5a6a546p5a625o6l5pS26KeC5a+f6ICF6K+t6Z+z5ZKMIEJDIOiBiuWkqeOAgg=="));

	public unsafe bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
	{
		//IL_0140: Expected native int or pointer, but got O
		Player val = Player.Get(sender);
		if (val != null && !val.RemoteAdminAccess)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5Y+q5pyJ5Y+v6K6/6Zeu566h55CG5ZGY6Z2i5p2/55qE546p5a625omN6IO95L2/55So5q2k5oyH5Luk44CC"));
			return false;
		}
		SpectatorPrivacySystem instance = SpectatorPrivacySystem.Instance;
		if (instance == null)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("6KeC5a+f6ICF6ZqQ56eB57O757uf5bCa5pyq5ZCv55So44CC"));
			return false;
		}
		if (arguments.Count != 2)
		{
			response = _mxTgzelfLugZL();
			return false;
		}
		Player val2 = MusicBoxSystem.FindOnlinePlayer(CollectionExtensions.At<string>(arguments, 0));
		if (val2 == null)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5pyq5om+5Yiw6K+l5Zyo57q/546p5a6277yM6K+35L2/55So5YW25bGA5YaFIElE44CB5a6M5pW0IFVzZXJJRCDmiJblrozmlbTmmLXnp7DjgII="));
			return false;
		}
		string text = (CollectionExtensions.At<string>(arguments, 1) ?? string.Empty).Trim().ToLowerInvariant();
		if (text == Encoding.UTF8.GetString(Convert.FromBase64String("c3RhdHVz")) || text == Encoding.UTF8.GetString(Convert.FromBase64String("54q25oCB")))
		{
			string nickname = val2.Nickname;
			string text2 = Encoding.UTF8.GetString(Convert.FromBase64String("IOW9k+WJjQ=="));
			if (!instance.IsRestricted(val2))
			{
			}
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)nickname, text2 + Encoding.UTF8.GetString(Convert.FromBase64String("5pyq6KKr5bGP6JS9")) + Encoding.UTF8.GetString(Convert.FromBase64String("5bey6KKr5bGP6JS9")) + Encoding.UTF8.GetString(Convert.FromBase64String("6KeC5a+f6ICF6K+t6Z+z5ZKMIEJDIOiBiuWkqeOAgg==")));
			return true;
		}
		bool flag;
		if (text == Encoding.UTF8.GetString(Convert.FromBase64String("b24=")) || text == Encoding.UTF8.GetString(Convert.FromBase64String("ZW5hYmxl")) || text == Encoding.UTF8.GetString(Convert.FromBase64String("MQ==")) || text == Encoding.UTF8.GetString(Convert.FromBase64String("5byA5ZCv")))
		{
			flag = true;
		}
		else
		{
			if (!(text == Encoding.UTF8.GetString(Convert.FromBase64String("b2Zm"))) && !(text == Encoding.UTF8.GetString(Convert.FromBase64String("ZGlzYWJsZQ=="))) && !(text == Encoding.UTF8.GetString(Convert.FromBase64String("MA=="))) && !(text == Encoding.UTF8.GetString(Convert.FromBase64String("5YWz6Zet"))))
			{
				response = _mxTgzelfLugZL();
				return false;
			}
			flag = false;
		}
		bool flag2 = instance.SetRestricted(val2, flag);
		string nickname2 = val2.Nickname;
		string text3;
		if (!flag)
		{
			if (!flag2)
			{
			}
			text3 = Encoding.UTF8.GetString(Convert.FromBase64String("IOW9k+WJjeacquiiq+Wxj+iUve+8jOaXoOmcgOaBouWkjeOAgg=="));
		}
		else
		{
			if (!flag2)
			{
			}
			text3 = Encoding.UTF8.GetString(Convert.FromBase64String("IOW3suWkhOS6juWxj+iUveeKtuaAge+8jOaXoOmcgOmHjeWkjeiuvue9ruOAgg=="));
		}
		response = nickname2 + text3;
		return true;
	}

	private static string _mxTgzelfLugZL()
	{
		return Encoding.UTF8.GetString(Convert.FromBase64String("55So5rOVOiBzcGVjdGF0b3Jwcml2YWN5fHNwYmxvY2sgPOeOqeWutj4gPG9ufG9mZnxzdGF0dXM+"));
	}
}
