using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Exiled.API.Features;
using MEC;
using Mirror;
using NVorbis;
using UnityEngine;
using VoiceChat;
using VoiceChat.Codec;
using VoiceChat.Codec.Enums;
using VoiceChat.Networking;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

internal sealed class _tcjhuCaiWsEuc : MonoBehaviour
{
	private const int _fFmbbTnCrfQEE = 480;

	private const int _f4865616453616d706c65733a300 = 1920;

	private const int _f714aae5760544b59 = 3;

	private readonly OpusEncoder _f73bcca6206d68430 = new OpusEncoder((OpusApplicationType)2048);

	private readonly PlaybackBuffer _fvRjjwolpUmkx = new PlaybackBuffer(24000, false);

	private readonly byte[] _f290145ed72184caf = new byte[512];

	private readonly Queue<float> _fa944d713d1b2f00b = new Queue<float>(9600);

	private CoroutineHandle _f7feb1b43d68dd0f1;

	private VorbisReader _f766f726269735265616465723a300;

	private MemoryStream _f30e59f4e4e12e36e;

	private float[] _f293f343e182f3c3c3f28606a;

	private float[] _fsVqZTSJhWSzZ;

	private float _f65e680013409463e;

	private int _fPjUtXkreOClq;

	private bool _fb4851751dca9e4ac;

	[CompilerGenerated]
	private Action _fenlYnZQndtHF;

	public ReferenceHub Owner { get; private set; }

	public string CurrentTrack { get; private set; }

	public float Volume { get; set; }

	public bool Loop { get; set; }

	public float StartupDelay { get; set; }

	public VoiceChatChannel BroadcastChannel { get; set; }

	public ReferenceHub TargetReceiver { get; set; }

	public Func<ReferenceHub, bool> ReceiverFilter { get; set; }

	public event Action PlaybackFinished
	{
		[CompilerGenerated]
		add
		{
			Action action = _fenlYnZQndtHF;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Combine(action2, value);
				action = Interlocked.CompareExchange(ref _fenlYnZQndtHF, value2, action2);
			}
			while ((object)action != action2);
		}
		[CompilerGenerated]
		remove
		{
			Action action = _fenlYnZQndtHF;
			Action action2;
			do
			{
				action2 = action;
				Action value2 = (Action)Delegate.Remove(action2, value);
				action = Interlocked.CompareExchange(ref _fenlYnZQndtHF, value2, action2);
			}
			while ((object)action != action2);
		}
	}

	public static _tcjhuCaiWsEuc Get(ReferenceHub hub)
	{
		_tcjhuCaiWsEuc tcjhuCaiWsEuc = ((Component)hub).gameObject.GetComponent<_tcjhuCaiWsEuc>();
		if ((Object)(object)tcjhuCaiWsEuc == (Object)null)
		{
			tcjhuCaiWsEuc = ((Component)hub).gameObject.AddComponent<_tcjhuCaiWsEuc>();
		}
		tcjhuCaiWsEuc.Owner = hub;
		return tcjhuCaiWsEuc;
	}

	public static _tcjhuCaiWsEuc Create(ReferenceHub voiceOwner)
	{
		while (!(voiceOwner == (ReferenceHub)null))
		{
		}
		return null;
	}

	public void Dispose()
	{
		Stop();
		if ((Object)(object)((Component)this).gameObject != (Object)null)
		{
			Object.Destroy((Object)(object)((Component)this).gameObject);
		}
	}

	public void Play(string path)
	{
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		Stop();
		CurrentTrack = path;
		_f7feb1b43d68dd0f1 = Timing.RunCoroutine(_mhtITFbJyWhfN(), (Segment)1);
	}

	public void Stop()
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (((CoroutineHandle)(ref _f7feb1b43d68dd0f1)).IsRunning)
		{
			Timing.KillCoroutines((CoroutineHandle[])(object)new CoroutineHandle[1] { _f7feb1b43d68dd0f1 });
		}
		_mc42ac2caeeec59b3();
		_fa944d713d1b2f00b.Clear();
		_fvRjjwolpUmkx.Clear();
		_f65e680013409463e = 0f;
		_fb4851751dca9e4ac = false;
		CurrentTrack = null;
	}

	private IEnumerator<float> _mhtITFbJyWhfN()
	{
		if (StartupDelay > 0f)
		{
			yield return Timing.WaitForSeconds(StartupDelay);
		}
		if (Owner == (ReferenceHub)null)
		{
			_m14352e333c230a363b23383b39311c33343329323f3e606a();
			yield break;
		}
		do
		{
			if (!_m0e2823152a3f340e283b3931606a())
			{
				_m14352e333c230a363b23383b39311c33343329323f3e606a();
				yield break;
			}
			_fPjUtXkreOClq = 48000;
			_f293f343e182f3c3c3f28606a = new float[_fPjUtXkreOClq / 5 + 1920];
			_fsVqZTSJhWSzZ = new float[_fPjUtXkreOClq / 5 + 1920];
			while (true)
			{
				int num;
				int count = (num = _f766f726269735265616465723a300.ReadSamples(_fsVqZTSJhWSzZ, 0, _fsVqZTSJhWSzZ.Length));
				if (num <= 0)
				{
					break;
				}
				while (_fa944d713d1b2f00b.Count >= _fsVqZTSJhWSzZ.Length)
				{
					_fb4851751dca9e4ac = true;
					yield return float.NegativeInfinity;
				}
				for (int i = 0; i < count; i++)
				{
					_fa944d713d1b2f00b.Enqueue(_fsVqZTSJhWSzZ[i]);
				}
				_fb4851751dca9e4ac = true;
			}
			_mc42ac2caeeec59b3();
			while (_fa944d713d1b2f00b.Count > 0 || _fvRjjwolpUmkx.Length >= 480)
			{
				yield return float.NegativeInfinity;
			}
			_fvRjjwolpUmkx.Clear();
		}
		while (Loop && !string.IsNullOrEmpty(CurrentTrack));
		_fb4851751dca9e4ac = false;
		_m14352e333c230a363b23383b39311c33343329323f3e606a();
	}

	private void _m14352e333c230a363b23383b39311c33343329323f3e606a()
	{
		_fenlYnZQndtHF?.Invoke();
	}

	private bool _m0e2823152a3f340e283b3931606a()
	{
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Expected O, but got Unknown
		try
		{
			while (!File.Exists(CurrentTrack))
			{
			}
			if (!CurrentTrack.EndsWith(Encoding.UTF8.GetString(Convert.FromBase64String("Lm9nZw==")), StringComparison.OrdinalIgnoreCase))
			{
				Log.Error(Encoding.UTF8.GetString(Convert.FromBase64String("W011c2ljQm94XSDpn7PkuZDmlofku7bkuI3lrZjlnKjmiJbkuI3mmK8gT0dHOiA=")) + CurrentTrack);
				return false;
			}
			_f30e59f4e4e12e36e = new MemoryStream(File.ReadAllBytes(CurrentTrack));
			_f766f726269735265616465723a300 = new VorbisReader((Stream)_f30e59f4e4e12e36e, true);
			if (_f766f726269735265616465723a300.Channels == 1)
			{
			}
			if (_f766f726269735265616465723a300.SampleRate != 48000)
			{
				Log.Error(Encoding.UTF8.GetString(Convert.FromBase64String("W011c2ljQm94XSDpn7PkuZDlv4XpobvkuLrljZXlo7DpgZMg")) + 48000 + Encoding.UTF8.GetString(Convert.FromBase64String("IEh6IE9HRyBWb3JiaXM6IA==")) + CurrentTrack);
				_mc42ac2caeeec59b3();
				return false;
			}
			return true;
		}
		catch (Exception ex)
		{
			Log.Error(Encoding.UTF8.GetString(Convert.FromBase64String("W011c2ljQm94XSDml6Dms5XmiZPlvIDpn7PkuZAg")) + CurrentTrack + Encoding.UTF8.GetString(Convert.FromBase64String("OiA=")) + ex.Message);
			_mc42ac2caeeec59b3();
			return false;
		}
	}

	private void Update()
	{
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		if (Owner == (ReferenceHub)null || !_fb4851751dca9e4ac || _fa944d713d1b2f00b.Count == 0)
		{
			return;
		}
		_f65e680013409463e += Time.deltaTime * (float)_fPjUtXkreOClq;
		int num = Mathf.Min(Mathf.FloorToInt(_f65e680013409463e), _fa944d713d1b2f00b.Count);
		for (int i = 0; i < num; i++)
		{
			_fvRjjwolpUmkx.Write(_fa944d713d1b2f00b.Dequeue() * (Volume / 100f));
		}
		_f65e680013409463e -= num;
		int num2 = 0;
		while (_fvRjjwolpUmkx.Length >= 480 && num2++ < 3)
		{
			_fvRjjwolpUmkx.ReadTo(_f293f343e182f3c3c3f28606a, 480L, 0L);
			int num3 = _f73bcca6206d68430.Encode(_f293f343e182f3c3c3f28606a, _f290145ed72184caf, 480);
			if (TargetReceiver != (ReferenceHub)null)
			{
				if (_m1329083f3b3e231936333f342e606a(TargetReceiver))
				{
					((NetworkBehaviour)TargetReceiver).connectionToClient.Send<VoiceMessage>(new VoiceMessage(Owner, BroadcastChannel, _f290145ed72184caf, num3, false), 0);
				}
				continue;
			}
			foreach (ReferenceHub allHub in ReferenceHub.AllHubs)
			{
				if (_m1329083f3b3e231936333f342e606a(allHub) && (ReceiverFilter == null || ReceiverFilter(allHub)))
				{
					((NetworkBehaviour)allHub).connectionToClient.Send<VoiceMessage>(new VoiceMessage(Owner, BroadcastChannel, _f290145ed72184caf, num3, false), 0);
				}
			}
		}
	}

	private static bool _m1329083f3b3e231936333f342e606a(ReferenceHub hub)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Invalid comparison between Unknown and I4
		if (hub != (ReferenceHub)null && ((NetworkBehaviour)hub).connectionToClient != null && (int)hub.Mode == 1 && hub.nicknameSync.NickSet && !((NetworkBehaviour)hub).isLocalPlayer && !string.IsNullOrEmpty(hub.characterClassManager.UserId))
		{
			return !hub.characterClassManager.UserId.Contains(Encoding.UTF8.GetString(Convert.FromBase64String("RHVtbXk=")));
		}
		return false;
	}

	private void _mc42ac2caeeec59b3()
	{
		if (_f766f726269735265616465723a300 != null)
		{
			_f766f726269735265616465723a300.Dispose();
		}
		if (_f30e59f4e4e12e36e != null)
		{
			_f30e59f4e4e12e36e.Dispose();
		}
		_f766f726269735265616465723a300 = null;
		_f30e59f4e4e12e36e = null;
	}

	private void OnDestroy()
	{
		Stop();
		_f73bcca6206d68430.Dispose();
		_fvRjjwolpUmkx.Dispose();
	}

	public _tcjhuCaiWsEuc()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		_ffywwVQxjxCxh = 10f;
		_f3c42726f6164636173744368616e6e656c3e6b5f5f4261636b696e674669656c643a300 = (VoiceChatChannel)6;
		((MonoBehaviour)this)._002Ector();
	}
}
