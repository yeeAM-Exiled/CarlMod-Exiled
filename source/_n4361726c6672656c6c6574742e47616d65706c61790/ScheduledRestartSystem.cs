using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using Exiled.Events.Handlers;
using MEC;
using _n4361726c6672656c6c6574740;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class ScheduledRestartSystem
{
	private const float _f456d707479536572766572436865636b496e74657276616c5365636f6e64733a300 = 10f;

	private const string _f193528352f2e33343f0e3b3d606a = "Carlfrellett.ScheduledRestart";

	private readonly ScheduledRestartConfig _f3935343c333d606a;

	private CoroutineHandle _f656d707479536572766572436f726f7574696e653a300;

	private DateTime? _f7dae7e0672d2e861;

	private bool _f7dbe8c87f6ac77c2;

	private bool _f726573746172745265717565737465643a300;

	public ScheduledRestartSystem(ScheduledRestartConfig config)
	{
		_f3935343c333d606a = config ?? new ScheduledRestartConfig();
	}

	public void Enable()
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		if (!_f7dbe8c87f6ac77c2 && _f3935343c333d606a.IsEnabled)
		{
			_f7dbe8c87f6ac77c2 = true;
			_f726573746172745265717565737465643a300 = false;
			_m760667955f0c7c15();
			Player.Verified += _m4f6e506c61796572436f756e744368616e6765643a300;
			Player.Left += _m15340a363b233f2819352f342e19323b343d3f3e606a;
			Server.RoundEnded += _m615d6ff1f188485b;
			Timing.KillCoroutines(Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0LlNjaGVkdWxlZFJlc3RhcnQ=")));
			_f656d707479536572766572436f726f7574696e653a300 = Timing.RunCoroutine(_m1f372a2e23093f282c3f28083f292e3b282e1635352a606a(), (Segment)4, Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0LlNjaGVkdWxlZFJlc3RhcnQ=")));
		}
	}

	public void Disable()
	{
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		if (_f7dbe8c87f6ac77c2)
		{
			_f7dbe8c87f6ac77c2 = false;
			Player.Verified -= _m4f6e506c61796572436f756e744368616e6765643a300;
			Player.Left -= _m15340a363b233f2819352f342e19323b343d3f3e606a;
			Server.RoundEnded -= _m615d6ff1f188485b;
			Timing.KillCoroutines((CoroutineHandle[])(object)new CoroutineHandle[1] { _f656d707479536572766572436f726f7574696e653a300 });
			Timing.KillCoroutines(Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0LlNjaGVkdWxlZFJlc3RhcnQ=")));
			_f7dae7e0672d2e861 = null;
			_f726573746172745265717565737465643a300 = false;
		}
	}

	private void _m615d6ff1f188485b(RoundEndedEventArgs ev)
	{
		if (_f7dbe8c87f6ac77c2 && !_f726573746172745265717565737465643a300)
		{
			int num = Round.UptimeRounds + 1;
			if (num >= _f3935343c333d606a.RoundsPerRestart)
			{
				_f726573746172745265717565737465643a300 = true;
				ServerStatic.StopNextRound = (NextRoundAction)1;
				Log.Info(Encoding.UTF8.GetString(Convert.FromBase64String("W1NjaGVkdWxlZFJlc3RhcnRdIOW3suWujOaIkCA=")) + num + Encoding.UTF8.GetString(Convert.FromBase64String("IOS4quWbnuWQiO+8jOWwhuWcqOacrOWbnuWQiOato+W4uOe7k+eul+WQjui9r+mHjeWQr+acjeWKoeWZqOW5tuiuqeeOqeWutuiHquWKqOmHjei/nuOAgg==")));
			}
		}
	}

	private void _m4f6e506c61796572436f756e744368616e6765643a300(VerifiedEventArgs ev)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		Timing.CallDelayed(0f, (Action)_m760667955f0c7c15);
	}

	private void _m15340a363b233f2819352f342e19323b343d3f3e606a(LeftEventArgs ev)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		Timing.CallDelayed(0f, (Action)_m760667955f0c7c15);
	}

	private IEnumerator<float> _m1f372a2e23093f282c3f28083f292e3b282e1635352a606a()
	{
		while (_f7dbe8c87f6ac77c2)
		{
			yield return Timing.WaitForSeconds(10f);
			if (_f7dbe8c87f6ac77c2 && !_f726573746172745265717565737465643a300)
			{
				_m760667955f0c7c15();
				if (_f7dae7e0672d2e861.HasValue && !((DateTime.UtcNow - _f7dae7e0672d2e861.Value).TotalSeconds < (double)_f3935343c333d606a.EmptyServerRestartSeconds))
				{
					_f726573746172745265717565737465643a300 = true;
					Log.Info("[ScheduledRestart] 服务器已持续无人 " + _f3935343c333d606a.EmptyServerRestartSeconds + " 秒，正在执行软重启。");
					Server.Restart();
				}
			}
		}
	}

	private void _m760667955f0c7c15()
	{
		if (Player.List.Any(_tFpYLlGZVhITT.IsGameplayPlayer))
		{
			_f7dae7e0672d2e861 = null;
		}
		else if (!_f7dae7e0672d2e861.HasValue)
		{
			_f7dae7e0672d2e861 = DateTime.UtcNow;
		}
	}
}
