using System;
using System.Linq;
using System.Text;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Handlers;
using MEC;
using RueI.Displays;
using RueI.Displays.Scheduling;
using RueI.Elements;
using RueI.Extensions;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class AdminAnnouncementSystem
{
	private const float _f0e9cdaf5d3f6859f = 610f;

	private static readonly TimedElemRef<SetElement> _f6acc7c5469d56503 = new TimedElemRef<SetElement>();

	private string _f616374697665436f6e74656e743a300;

	private DateTime _f349381632d66fc0d = DateTime.MinValue;

	public static AdminAnnouncementSystem Instance { get; private set; }

	public void Enable()
	{
		Instance = this;
		Player.Verified += _m7d182fe7c224cf26;
	}

	public void Disable()
	{
		Player.Verified -= _m7d182fe7c224cf26;
		foreach (Player item in Player.List.ToList())
		{
			_m0932352d606a(item, string.Empty, TimeSpan.FromSeconds(0.1));
		}
		_f616374697665436f6e74656e743a300 = null;
		_f349381632d66fc0d = DateTime.MinValue;
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public int Announce(string message, int durationSeconds)
	{
		string text = RueITextChat._m4e6f726d616c697a654d6573736167653a300(message);
		if (string.IsNullOrWhiteSpace(text))
		{
			return 0;
		}
		_f616374697665436f6e74656e743a300 = _m0e36f43d0254085e(text);
		_f349381632d66fc0d = DateTime.UtcNow.AddSeconds(durationSeconds);
		TimeSpan duration = TimeSpan.FromSeconds(durationSeconds);
		int num = 0;
		foreach (Player item in Player.List.ToList())
		{
			if (_m0932352d606a(item, _f616374697665436f6e74656e743a300, duration))
			{
				num++;
			}
		}
		return num;
	}

	private void _m7d182fe7c224cf26(VerifiedEventArgs ev)
	{
		//IL_006f: Unknown result type (might be due to invalid IL or missing references)
		if (ev.Player == null || string.IsNullOrEmpty(_f616374697665436f6e74656e743a300))
		{
			return;
		}
		if (_f349381632d66fc0d - DateTime.UtcNow <= TimeSpan.Zero)
		{
			_f616374697665436f6e74656e743a300 = null;
			_f349381632d66fc0d = DateTime.MinValue;
			return;
		}
		Timing.CallDelayed(0.5f, (Action)delegate
		{
			TimeSpan timeSpan = _f349381632d66fc0d - DateTime.UtcNow;
			if (timeSpan > TimeSpan.Zero)
			{
				_m0932352d606a(ev.Player, _f616374697665436f6e74656e743a300, timeSpan);
			}
		});
	}

	private static bool _m0932352d606a(Player player, string content, TimeSpan duration)
	{
		if (player == null || player.ReferenceHub == (ReferenceHub)null || !player.IsConnected || duration <= TimeSpan.Zero)
		{
			return false;
		}
		DisplayCore.Get(player).SetElemTemp(content, 610f, duration, _f6acc7c5469d56503);
		return true;
	}

	private static string _m0e36f43d0254085e(string message)
	{
		return Encoding.UTF8.GetString(Convert.FromBase64String("PGFsaWduPWNlbnRlcj48Yj48c2l6ZT0zOD48Y29sb3I9I0ZGM0IzMD7jgJDnrqHnkIblkZjlhazlkYrjgJE8L2NvbG9yPjwvc2l6ZT48L2I+CjxiPjxzaXplPTM0Pjxjb2xvcj0jRkZEMTY2Pg==")) + RueITextChat._mAdhxsEIzxZbu(message) + Encoding.UTF8.GetString(Convert.FromBase64String("PC9jb2xvcj48L3NpemU+PC9iPjwvYWxpZ24+"));
	}
}
