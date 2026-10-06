using System;
using System.Text;
using Exiled.API.Enums;
using Exiled.API.Features;
using HarmonyLib;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n4361726c6672656c6c6574740;

public class Plugin : Plugin<Config>
{
	private const string _f123b2837353423133e0a283f3c3322606a = "Carlfrellett";

	private readonly string _f6861726d6f6e7949643a300 = "Carlfrellett." + Guid.NewGuid().ToString("N");

	private PlayerInformationHint _f8dbbf4aadfceb8a4;

	private CustomRoleSystem _f392f292e35370835363f0923292e3f37606a;

	private UnlimitedAmmo _fAfzMGNtCRqtA;

	private GameHelpers _f3d3b373f123f362a3f2829606a;

	private PlayerCountHint _f706c61796572436f756e7448696e743a300;

	private RueITextChat _f282f3f130e3f222e19323b2e606a;

	private SpectatorPrivacySystem _f292a3f392e3b2e35280a28332c3b39230923292e3f37606a;

	private Scp0492Enhancement _f73637030343932456e68616e63656d656e743a300;

	private ScpEnhancements _fTDovaVDmZPGE;

	private RespawnProtection _fgGAgrcMdrOMO;

	private RoundActivityLog _fbziXWRmRdQLy;

	private RoundMvpDisplay _f28352f343e172c2a1e33292a363b23606a;

	private ExperienceSystem _f3f222a3f28333f34393f0923292e3f37606a;

	private BadgeTitleSystem _ftLCkNihZLwCF;

	private MusicBoxSystem _f5e461012bb99d653;

	private RemoteKeycard _fAJQLPUwqUogE;

	private ScpExchangeSystem _fSzOLseXKtiaE;

	private AutomaticCleanupSystem _f6175746f6d61746963436c65616e757053797374656d3a300;

	private SystemWarhead _ff52f2f3e97cf96fe;

	private AdminAnnouncementSystem _f3b3e3733341b3434352f34393f373f342e0923292e3f37606a;

	private ScheduledRestartSystem _f018085f5683c650f;

	private StartRoundDisplay _fRNtWFbeZHjiF;

	private Harmony _f6861726d6f6e793a300;

	private WebServer _fabb0fc5d418d3e7a;

	public static Plugin Instance { get; private set; }

	internal CustomRoleSystem _pGqHZUEnFydXx => _f392f292e35370835363f0923292e3f37606a;

	public override string Author => Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybCBGcmVsbGV0dA=="));

	public override string Name => Encoding.UTF8.GetString(Convert.FromBase64String("VGhlIEJpcmQncyBTb25n"));

	public override PluginPriority Priority => (PluginPriority)(-250);

	public override void OnEnabled()
	{
		Instance = this;
		try
		{
			_m8587eb76f6d3e985();
		}
		catch (Exception ex)
		{
			Log.Error(Encoding.UTF8.GetString(Convert.FromBase64String("W0NhcmxmcmVsbGV0dF0gRW5hYmxlIGZhaWxlZDsgcm9sbGluZyBiYWNrIHBhcnRpYWwgc3RhdGU6IA==")) + ex);
			_mrUjWWwKuGJSm();
			if (Instance == this)
			{
				Instance = null;
			}
			throw;
		}
	}

	private void _m8587eb76f6d3e985()
	{
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Expected O, but got Unknown
		int num = base.Config._m4e6f726d616c697a653a300();
		if (num > 0)
		{
			Log.Warn(Encoding.UTF8.GetString(Convert.FromBase64String("W0NhcmxmcmVsbGV0dF0gTm9ybWFsaXplZCA=")) + num + Encoding.UTF8.GetString(Convert.FromBase64String("IGludmFsaWQvbnVsbCBjb25maWd1cmF0aW9uIHZhbHVlKHMpIGJlZm9yZSBlbmFibGluZyB0aGUgcGx1Z2luLg==")));
		}
		_f6861726d6f6e793a300 = new Harmony(_f6861726d6f6e7949643a300);
		_f6861726d6f6e793a300.PatchAll();
		_f8dbbf4aadfceb8a4 = new PlayerInformationHint(this);
		_f392f292e35370835363f0923292e3f37606a = new CustomRoleSystem();
		_fAfzMGNtCRqtA = new UnlimitedAmmo(this);
		_f3d3b373f123f362a3f2829606a = new GameHelpers(this);
		_f706c61796572436f756e7448696e743a300 = new PlayerCountHint();
		_f282f3f130e3f222e19323b2e606a = new RueITextChat();
		_f292a3f392e3b2e35280a28332c3b39230923292e3f37606a = new SpectatorPrivacySystem();
		_f73637030343932456e68616e63656d656e743a300 = new Scp0492Enhancement();
		_fTDovaVDmZPGE = new ScpEnhancements(base.Config.ScpEnhancements, base.Config.MicroHidEnhancement);
		_fgGAgrcMdrOMO = new RespawnProtection(base.Config.RespawnProtection);
		_fbziXWRmRdQLy = new RoundActivityLog();
		_f28352f343e172c2a1e33292a363b23606a = new RoundMvpDisplay(base.Config.RoundMvp);
		_f3f222a3f28333f34393f0923292e3f37606a = new ExperienceSystem(base.Config.ExperienceSystem);
		_ftLCkNihZLwCF = new BadgeTitleSystem();
		_f5e461012bb99d653 = new MusicBoxSystem(base.Config.MusicBox);
		_fAJQLPUwqUogE = new RemoteKeycard(this);
		_fSzOLseXKtiaE = new ScpExchangeSystem(this);
		_f6175746f6d61746963436c65616e757053797374656d3a300 = new AutomaticCleanupSystem();
		_ff52f2f3e97cf96fe = new SystemWarhead();
		_f3b3e3733341b3434352f34393f373f342e0923292e3f37606a = new AdminAnnouncementSystem();
		_f018085f5683c650f = new ScheduledRestartSystem(base.Config.ScheduledRestart);
		_fRNtWFbeZHjiF = new StartRoundDisplay();
		_f8dbbf4aadfceb8a4.Enable();
		_f392f292e35370835363f0923292e3f37606a.Enable();
		_fAfzMGNtCRqtA.Enable();
		_f3d3b373f123f362a3f2829606a.Enable();
		_f706c61796572436f756e7448696e743a300.Enable();
		_fAJQLPUwqUogE.Enable();
		_fSzOLseXKtiaE.Enable();
		_f6175746f6d61746963436c65616e757053797374656d3a300.Enable();
		_ff52f2f3e97cf96fe.Enable();
		_f3b3e3733341b3434352f34393f373f342e0923292e3f37606a.Enable();
		_f292a3f392e3b2e35280a28332c3b39230923292e3f37606a.Enable();
		_f282f3f130e3f222e19323b2e606a.Enable();
		_fTDovaVDmZPGE.Enable();
		_f73637030343932456e68616e63656d656e743a300.Enable();
		_fgGAgrcMdrOMO.Enable();
		_fbziXWRmRdQLy.Enable();
		_f28352f343e172c2a1e33292a363b23606a.Enable();
		_f3f222a3f28333f34393f0923292e3f37606a.Enable();
		_ftLCkNihZLwCF.Enable();
		_f5e461012bb99d653.Enable();
		_f018085f5683c650f.Enable();
		_fRNtWFbeZHjiF.Enable();
		if (Server.Port == 30002)
		{
			_fabb0fc5d418d3e7a = new WebServer();
			_fabb0fc5d418d3e7a.Start();
		}
		base.OnEnabled();
	}

	public override void OnDisabled()
	{
		try
		{
			_mrUjWWwKuGJSm();
		}
		finally
		{
			if (Instance == this)
			{
				Instance = null;
			}
			base.OnDisabled();
		}
	}

	private void _mrUjWWwKuGJSm()
	{
		WebServer server = _fabb0fc5d418d3e7a;
		_fabb0fc5d418d3e7a = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("d2ViIHNlcnZlcg==")), delegate
		{
			server?.Dispose();
		});
		PlayerCountHint countHint = _f706c61796572436f756e7448696e743a300;
		_f706c61796572436f756e7448696e743a300 = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("cGxheWVyLWNvdW50IGhpbnQ=")), delegate
		{
			countHint?.Disable();
		});
		PlayerInformationHint informationHint = _f8dbbf4aadfceb8a4;
		_f8dbbf4aadfceb8a4 = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("aW5mb3JtYXRpb24gaGludA==")), delegate
		{
			informationHint?.Disable();
		});
		CustomRoleSystem roles = _f392f292e35370835363f0923292e3f37606a;
		_f392f292e35370835363f0923292e3f37606a = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("Y3VzdG9tIHJvbGVz")), delegate
		{
			roles?.Disable();
		});
		UnlimitedAmmo ammo = _fAfzMGNtCRqtA;
		_fAfzMGNtCRqtA = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("dW5saW1pdGVkIGFtbW8=")), delegate
		{
			ammo?.Disable();
		});
		GameHelpers helpers = _f3d3b373f123f362a3f2829606a;
		_f3d3b373f123f362a3f2829606a = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("Z2FtZSBoZWxwZXJz")), delegate
		{
			helpers?.Disable();
		});
		RueITextChat chat = _f282f3f130e3f222e19323b2e606a;
		_f282f3f130e3f222e19323b2e606a = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("dGV4dCBjaGF0")), delegate
		{
			chat?.Disable();
		});
		SpectatorPrivacySystem spectatorPrivacy = _f292a3f392e3b2e35280a28332c3b39230923292e3f37606a;
		_f292a3f392e3b2e35280a28332c3b39230923292e3f37606a = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("c3BlY3RhdG9yIHByaXZhY3k=")), delegate
		{
			spectatorPrivacy?.Disable();
		});
		Scp0492Enhancement zombieEnhancement = _f73637030343932456e68616e63656d656e743a300;
		_f73637030343932456e68616e63656d656e743a300 = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("U0NQLTA0OS0yIGVuaGFuY2VtZW50")), delegate
		{
			zombieEnhancement?.Disable();
		});
		ScpEnhancements enhancements = _fTDovaVDmZPGE;
		_fTDovaVDmZPGE = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("U0NQIGVuaGFuY2VtZW50cw==")), delegate
		{
			enhancements?.Disable();
		});
		RespawnProtection protection = _fgGAgrcMdrOMO;
		_fgGAgrcMdrOMO = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("cmVzcGF3biBwcm90ZWN0aW9u")), delegate
		{
			protection?.Disable();
		});
		RoundActivityLog activityLog = _fbziXWRmRdQLy;
		_fbziXWRmRdQLy = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("cm91bmQgYWN0aXZpdHkgbG9n")), delegate
		{
			activityLog?.Disable();
		});
		RoundMvpDisplay mvp = _f28352f343e172c2a1e33292a363b23606a;
		_f28352f343e172c2a1e33292a363b23606a = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("cm91bmQgTVZQ")), delegate
		{
			mvp?.Disable();
		});
		ExperienceSystem experience = _f3f222a3f28333f34393f0923292e3f37606a;
		_f3f222a3f28333f34393f0923292e3f37606a = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("ZXhwZXJpZW5jZSBzeXN0ZW0=")), delegate
		{
			experience?.Dispose();
		});
		BadgeTitleSystem badges = _ftLCkNihZLwCF;
		_ftLCkNihZLwCF = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("YmFkZ2UgdGl0bGUgc3lzdGVt")), delegate
		{
			badges?.Disable();
		});
		MusicBoxSystem musicBoxes = _f5e461012bb99d653;
		_f5e461012bb99d653 = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("bXVzaWMgYm94IHN5c3RlbQ==")), delegate
		{
			musicBoxes?.Disable();
		});
		RemoteKeycard keycard = _fAJQLPUwqUogE;
		_fAJQLPUwqUogE = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("cmVtb3RlIGtleWNhcmQ=")), delegate
		{
			keycard?.Disable();
		});
		ScpExchangeSystem exchange = _fSzOLseXKtiaE;
		_fSzOLseXKtiaE = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("U0NQIGV4Y2hhbmdl")), delegate
		{
			exchange?.Disable();
		});
		AutomaticCleanupSystem automaticCleanup = _f6175746f6d61746963436c65616e757053797374656d3a300;
		_f6175746f6d61746963436c65616e757053797374656d3a300 = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("YXV0b21hdGljIGNsZWFudXA=")), delegate
		{
			automaticCleanup?.Disable();
		});
		SystemWarhead currentSystemWarhead = _ff52f2f3e97cf96fe;
		_ff52f2f3e97cf96fe = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("c3lzdGVtIHdhcmhlYWQ=")), delegate
		{
			currentSystemWarhead?.Disable();
		});
		AdminAnnouncementSystem announcements = _f3b3e3733341b3434352f34393f373f342e0923292e3f37606a;
		_f3b3e3733341b3434352f34393f373f342e0923292e3f37606a = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("YWRtaW4gYW5ub3VuY2VtZW50cw==")), delegate
		{
			announcements?.Disable();
		});
		ScheduledRestartSystem scheduledRestart = _f018085f5683c650f;
		_f018085f5683c650f = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("c2NoZWR1bGVkIHJlc3RhcnQ=")), delegate
		{
			scheduledRestart?.Disable();
		});
		StartRoundDisplay roundDisplay = _fRNtWFbeZHjiF;
		_fRNtWFbeZHjiF = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("c3RhcnQgcm91bmQgZGlzcGxheQ==")), delegate
		{
			roundDisplay?.Disable();
		});
		Harmony currentHarmony = _f6861726d6f6e793a300;
		_f6861726d6f6e793a300 = null;
		_m547279436c65616e75703a300(Encoding.UTF8.GetString(Convert.FromBase64String("SGFybW9ueSBwYXRjaGVz")), delegate
		{
			Harmony obj = currentHarmony;
			if (obj != null)
			{
				obj.UnpatchAll(_f6861726d6f6e7949643a300);
			}
		});
	}

	private static void _m547279436c65616e75703a300(string stage, Action cleanup)
	{
		try
		{
			cleanup();
		}
		catch (Exception ex)
		{
			Log.Error(Encoding.UTF8.GetString(Convert.FromBase64String("W0NhcmxmcmVsbGV0dF0gQ2xlYW51cCBmYWlsZWQgZm9yIA==")) + stage + Encoding.UTF8.GetString(Convert.FromBase64String("OiA=")) + ex);
		}
	}
}
