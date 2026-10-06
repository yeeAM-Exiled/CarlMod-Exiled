using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Server;
using Exiled.Events.EventArgs.Warhead;
using Exiled.Events.Handlers;
using MEC;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class SystemWarhead
{
	private const float _f1b392e332c3b2e333534093f3935343e29606a = 1800f;

	private const string _f193528352f2e33343f0e3b3d606a = "Carlfrellett.SystemWarhead";

	private CoroutineHandle _f3b145302314b39ae;

	private bool _f3f343b38363f3e606a;

	private bool _f235fab3c39b6a3ec;

	private bool _ff490c62d375a037c;

	private bool _f00fce2e0a3c225fa;

	public void Enable()
	{
		if (!_f3f343b38363f3e606a)
		{
			_f3f343b38363f3e606a = true;
			Warhead.Detonating += _m4f6e4465746f6e6174696e673a300;
			Warhead.Stopping += _mBFUqQyJyqUyx;
			Server.RoundStarted += _mzMbTLlOljnbo;
			Server.WaitingForPlayers += _m5f3117306b41eb1a;
			Server.RestartingRound += _m5f3117306b41eb1a;
			Server.RoundEnded += _m615d6ff1f188485b;
		}
	}

	public void Disable()
	{
		if (_f3f343b38363f3e606a)
		{
			_f3f343b38363f3e606a = false;
			Warhead.Detonating -= _m4f6e4465746f6e6174696e673a300;
			Warhead.Stopping -= _mBFUqQyJyqUyx;
			Server.RoundStarted -= _mzMbTLlOljnbo;
			Server.WaitingForPlayers -= _m5f3117306b41eb1a;
			Server.RestartingRound -= _m5f3117306b41eb1a;
			Server.RoundEnded -= _m615d6ff1f188485b;
			_mzzYWVmTPspuU();
			_ff490c62d375a037c = false;
			if (_f00fce2e0a3c225fa)
			{
				Server.FriendlyFire = false;
				_f00fce2e0a3c225fa = false;
			}
		}
	}

	private void _mzMbTLlOljnbo()
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		_mzzYWVmTPspuU();
		_ff490c62d375a037c = false;
		Server.FriendlyFire = false;
		_f00fce2e0a3c225fa = true;
		_f3b145302314b39ae = Timing.RunCoroutine(_m20f7157b6b3441e2(), (Segment)4, Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0LlN5c3RlbVdhcmhlYWQ=")));
	}

	private void _m615d6ff1f188485b(RoundEndedEventArgs ev)
	{
		_mzzYWVmTPspuU();
		_ff490c62d375a037c = true;
		Server.FriendlyFire = true;
		_f00fce2e0a3c225fa = true;
		Log.Info(Encoding.UTF8.GetString(Convert.FromBase64String("W1JvdW5kU2V0dGxlbWVudF0g5Zue5ZCI57uT566X5bey5byA5ZCv5Y+L5Lyk77yM5bm256aB5q2i5qC45by554iG54K444CC")));
	}

	private void _m5f3117306b41eb1a()
	{
		_mzzYWVmTPspuU();
		_ff490c62d375a037c = false;
		Server.FriendlyFire = false;
		_f00fce2e0a3c225fa = true;
	}

	private void _m4f6e4465746f6e6174696e673a300(DetonatingEventArgs ev)
	{
		if (_ff490c62d375a037c)
		{
			ev.IsAllowed = false;
		}
	}

	private IEnumerator<float> _m20f7157b6b3441e2()
	{
		yield return Timing.WaitForSeconds(1800f);
		if (!_f3f343b38363f3e606a || !Round.IsStarted || Round.IsEnded || Warhead.IsDetonated)
		{
			yield break;
		}
		_f235fab3c39b6a3ec = true;
		Warhead.IsLocked = true;
		if (!Warhead.IsInProgress)
		{
			Warhead.Start();
			Log.Info("[SystemWarhead] 系统核已启动并上锁。禁止关闭。");
		}
		else
		{
			Log.Info("[SystemWarhead] 核弹已在运行，系统核仅接管并锁定，不修改剩余时间。");
		}
		Timing.CallDelayed(0f, (Action)delegate
		{
			if (_f3f343b38363f3e606a && _f235fab3c39b6a3ec && !Warhead.IsDetonated)
			{
				Warhead.IsLocked = true;
			}
		});
	}

	private void _mBFUqQyJyqUyx(StoppingEventArgs ev)
	{
		if (_f235fab3c39b6a3ec)
		{
			ev.IsAllowed = false;
			Warhead.IsLocked = true;
		}
	}

	private void _mzzYWVmTPspuU()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		Timing.KillCoroutines((CoroutineHandle[])(object)new CoroutineHandle[1] { _f3b145302314b39ae });
		Timing.KillCoroutines(Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0LlN5c3RlbVdhcmhlYWQ=")));
		_f235fab3c39b6a3ec = false;
	}

	[CompilerGenerated]
	private void _muhlBVCwWkYbk()
	{
		if (_f3f343b38363f3e606a && _f235fab3c39b6a3ec && !Warhead.IsDetonated)
		{
			Warhead.IsLocked = true;
		}
	}
}
