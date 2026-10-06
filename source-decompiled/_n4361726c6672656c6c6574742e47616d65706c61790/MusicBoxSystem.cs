using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using Exiled.Events.Handlers;
using MEC;
using Mirror;
using NVorbis;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using VoiceChat;
using _n4361726c6672656c6c6574740;
using _n4361726c6672656c6c6574742e436f6d7061746962696c6974790;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class MusicBoxSystem
{
	private sealed class _tufsKzvyQsPaj
	{
		public string MvpMusic { get; set; }

		public string LobbyMusic { get; set; }

		public string MvpBotName { get; set; }

		public string LobbyBotName { get; set; }

		public float? Volume { get; set; }
	}

	private sealed class _t0a363b233b38363f172f293339606a
	{
		public string Name { get; private set; }

		public string Path { get; private set; }

		public string BotName { get; private set; }

		public float Volume { get; private set; }

		public _t0a363b233b38363f172f293339606a(string name, string path, string botName, float volume)
		{
			Name = name;
			Path = path;
			BotName = botName;
			Volume = volume;
		}
	}

	private sealed class _t7bb602a000314f11
	{
		public ReferenceHub ListenerHub { get; set; }

		public _ta3fc8a7f01ee229b Bot { get; set; }

		public _tcjhuCaiWsEuc Player { get; set; }

		public Action FinishedHandler { get; set; }
	}

	private sealed class _ta3fc8a7f01ee229b : IDisposable
	{
		private const int _fektfAEbXYrfn = 900;

		private static readonly HashSet<int> _fcEHBamydTUdN = new HashSet<int>();

		private static int _fe9c55c357a6b92ec = 900;

		private _t1c3b313f193534343f392e333534606a _f74c8a9e8d9e59a3a;

		private GameObject _f6bdf0fe02bdb7e91;

		private bool _f3e33292a35293f3e606a;

		public int Id { get; private set; }

		public ReferenceHub Hub { get; private set; }

		private _ta3fc8a7f01ee229b(int id, ReferenceHub hub, _t1c3b313f193534343f392e333534606a connection, GameObject gameObject)
		{
			Id = id;
			Hub = hub;
			_f74c8a9e8d9e59a3a = connection;
			_f6bdf0fe02bdb7e91 = gameObject;
		}

		public static _ta3fc8a7f01ee229b Create(string requestedName)
		{
			//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
			while (true)
			{
				int num = _me45fc57a77eba59c();
				GameObject val = null;
				_t1c3b313f193534343f392e333534606a t1c3b313f193534343f392e333534606a = null;
				try
				{
					if ((Object)(object)NetworkManager.singleton == (Object)null)
					{
						continue;
					}
					if ((Object)(object)NetworkManager.singleton.playerPrefab == (Object)null)
					{
						throw new InvalidOperationException(Encoding.UTF8.GetString(Convert.FromBase64String("5pyN5Yqh5Zmo546p5a626aKE5Yi25L2T5bCa5pyq5Yid5aeL5YyW44CC")));
					}
					val = Object.Instantiate<GameObject>(NetworkManager.singleton.playerPrefab);
					ReferenceHub component = val.GetComponent<ReferenceHub>();
					if (!(component == (ReferenceHub)null) && !((Object)(object)component.characterClassManager == (Object)null))
					{
						if ((Object)(object)component.nicknameSync == (Object)null)
						{
							throw new InvalidOperationException(Encoding.UTF8.GetString(Convert.FromBase64String("6Z+z5LmQ55uS5py65Zmo5Lq657y65bCR5b+F6KaB55qE546p5a6257uE5Lu244CC")));
						}
						t1c3b313f193534343f392e333534606a = new _t1c3b313f193534343f392e333534606a(num);
						if (!NetworkServer.AddPlayerForConnection((NetworkConnection)(object)t1c3b313f193534343f392e333534606a, val))
						{
							throw new InvalidOperationException(Encoding.UTF8.GetString(Convert.FromBase64String("TWlycm9yIOaLkue7neeUn+aIkOmfs+S5kOebkuacuuWZqOS6uuOAgg==")));
						}
						RecyclablePlayerId playerId = component._playerId;
						component.Network_playerId = new RecyclablePlayerId(num);
						((RecyclablePlayerId)(ref playerId)).Destroy();
						component.characterClassManager.InstanceMode = (ClientInstanceMode)0;
						NicknameSync nicknameSync = component.nicknameSync;
						if (!string.IsNullOrWhiteSpace(requestedName))
						{
						}
						nicknameSync.Network_myNickSync = requestedName;
						string myNick = component.nicknameSync.MyNick;
						Log.Debug(Encoding.UTF8.GetString(Convert.FromBase64String("W011c2ljQm94XSDlt7LliJvlu7rmnLrlmajkurogSUQ9")) + num + Encoding.UTF8.GetString(Convert.FromBase64String("77yM5ZCN56ewPQ==")) + myNick);
						return new _ta3fc8a7f01ee229b(num, component, t1c3b313f193534343f392e333534606a, val);
					}
				}
				catch (Exception ex)
				{
					Log.Error(Encoding.UTF8.GetString(Convert.FromBase64String("W011c2ljQm94XSDliJvlu7ogSUQ9")) + num + Encoding.UTF8.GetString(Convert.FromBase64String("IOeahOmfs+S5kOebkuacuuWZqOS6uuWksei0pTog")) + ex);
					if (t1c3b313f193534343f392e333534606a != null && (Object)(object)((NetworkConnection)t1c3b313f193534343f392e333534606a).identity != (Object)null)
					{
						try
						{
							NetworkServer.RemovePlayerForConnection((NetworkConnection)(object)t1c3b313f193534343f392e333534606a, true);
						}
						catch (Exception ex2)
						{
							Log.Error(Encoding.UTF8.GetString(Convert.FromBase64String("W011c2ljQm94XSDmuIXnkIbliJvlu7rlpLHotKXnmoTmnLrlmajkurogSUQ9")) + num + Encoding.UTF8.GetString(Convert.FromBase64String("IOaXtuWPkeeUn+mUmeivrzog")) + ex2);
							if ((Object)(object)val != (Object)null)
							{
								Object.Destroy((Object)(object)val);
							}
						}
					}
					else if ((Object)(object)val != (Object)null)
					{
						Object.Destroy((Object)(object)val);
					}
					_mMaDaXbtEfbWl(num);
					return null;
				}
			}
		}

		public void Dispose()
		{
			//IL_0054->IL0054: Incompatible stack heights: 0 vs 1
			if (_f3e33292a35293f3e606a)
			{
				return;
			}
			_f3e33292a35293f3e606a = true;
			try
			{
				if (_f74c8a9e8d9e59a3a != null && (Object)(object)((NetworkConnection)_f74c8a9e8d9e59a3a).identity != (Object)null)
				{
					NetworkServer.RemovePlayerForConnection((NetworkConnection)(object)_f74c8a9e8d9e59a3a, true);
				}
				else if ((Object)(object)_f6bdf0fe02bdb7e91 != (Object)null)
				{
					Object.Destroy((Object)(object)_f6bdf0fe02bdb7e91);
				}
				/*Error near IL_0052: Could not find block for branch target IL_0054*/;
			}
			catch (Exception ex)
			{
				Log.Error(Encoding.UTF8.GetString(Convert.FromBase64String("W011c2ljQm94XSDnp7vpmaTmnLrlmajkurogSUQ9")) + Id + Encoding.UTF8.GetString(Convert.FromBase64String("IOWksei0pTog")) + ex);
				if ((Object)(object)_f6bdf0fe02bdb7e91 != (Object)null)
				{
					Object.Destroy((Object)(object)_f6bdf0fe02bdb7e91);
				}
			}
			finally
			{
				_mMaDaXbtEfbWl(Id);
				_f74c8a9e8d9e59a3a = null;
				_f6bdf0fe02bdb7e91 = null;
				Hub = null;
			}
		}

		private static int _me45fc57a77eba59c()
		{
			lock (_fcEHBamydTUdN)
			{
				int candidate;
				for (candidate = Math.Max(_fe9c55c357a6b92ec, 900); _fcEHBamydTUdN.Contains(candidate) || ReferenceHub.AllHubs.Any((ReferenceHub hub) => hub != (ReferenceHub)null && hub.PlayerId == candidate); candidate++)
				{
				}
				_fcEHBamydTUdN.Add(candidate);
				_fe9c55c357a6b92ec = candidate + 1;
				return candidate;
			}
		}

		private static void _mMaDaXbtEfbWl(int id)
		{
			lock (_fcEHBamydTUdN)
			{
				_fcEHBamydTUdN.Remove(id);
			}
		}
	}

	[Serializable]
	[CompilerGenerated]
	private sealed class _t666439606a
	{
		public static readonly _t666439606a _003C_003E9 = new _t666439606a();

		public static Func<string, string> _003C_003E9__63_0;

		internal string _m3c53617665507265666572656e6365733e625f5f36335f303a300(string value)
		{
			return value;
		}
	}

	private const string _f4c6f626279436f726f7574696e655461673a300 = "Carlfrellett.MusicBox.Lobby";

	private readonly MusicBoxConfig _fPkewkxQPfmTD;

	private readonly Dictionary<string, _tufsKzvyQsPaj> _f372f29333918230f293f28133e606a = new Dictionary<string, _tufsKzvyQsPaj>(StringComparer.OrdinalIgnoreCase);

	private readonly Dictionary<ReferenceHub, _t7bb602a000314f11> _f74657374506c61796261636b733a300 = new Dictionary<ReferenceHub, _t7bb602a000314f11>();

	private readonly HashSet<string> _f3635383823172f2933391e33293b38363f3e0f293f28133e29606a = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

	private readonly Random _f283b343e3537606a = new Random();

	private _tcjhuCaiWsEuc _f2c31453fb4a6360d;

	private _ta3fc8a7f01ee229b _fBOxrFJpBcoGz;

	private CoroutineHandle _f3635383823193528352f2e33343f606a;

	private bool _f656e61626c65643a300;

	private bool _f6973506c6179696e673a300;

	private bool _f08d8914419b0dedb;

	public static MusicBoxSystem Instance { get; private set; }

	public bool IsPlaying => _f6973506c6179696e673a300;

	public string DataPath { get; private set; }

	public string MusicDirectory { get; private set; }

	public string PreferenceDataPath { get; private set; }

	public MusicBoxSystem(MusicBoxConfig config)
	{
		_fPkewkxQPfmTD = config ?? new MusicBoxConfig();
	}

	public void Enable()
	{
		if (!_f656e61626c65643a300 && _fPkewkxQPfmTD.IsEnabled)
		{
			_f656e61626c65643a300 = true;
			Instance = this;
			string text = Path.Combine(Path.GetDirectoryName(Paths.Config), Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0")));
			DataPath = Path.Combine(text, Encoding.UTF8.GetString(Convert.FromBase64String("bXVzaWNfYm94ZXMuanNvbg==")));
			MusicDirectory = Path.Combine(text, Encoding.UTF8.GetString(Convert.FromBase64String("bXVzaWM=")));
			PreferenceDataPath = Path.Combine(Paths.Configs, Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0")), Server.Port + Encoding.UTF8.GetString(Convert.FromBase64String("LW11c2ljLWJveC1wcmVmZXJlbmNlcy5qc29u")));
			Directory.CreateDirectory(text);
			Directory.CreateDirectory(MusicDirectory);
			_m1b6c67b688f429e1();
			_m16353b3e0a283f3c3f283f34393f29606a();
			Player.Verified += _m7d182fe7c224cf26;
			Player.Left += _mjCJhjLwKrgiu;
			Server.WaitingForPlayers += _mEkHZggnFRvdW;
			Server.RoundStarted += _m4f6e526f756e64537461727465643a300;
			Server.RoundEnded += _m153408352f343e1f343e3f3e606a;
			Server.RestartingRound += _m1534083f292e3b282e33343d08352f343e606a;
		}
	}

	public void Disable()
	{
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		if (!_f656e61626c65643a300)
		{
			return;
		}
		_f656e61626c65643a300 = false;
		Player.Verified -= _m7d182fe7c224cf26;
		Player.Left -= _mjCJhjLwKrgiu;
		Server.WaitingForPlayers -= _mEkHZggnFRvdW;
		Server.RoundStarted -= _m4f6e526f756e64537461727465643a300;
		Server.RoundEnded -= _m153408352f343e1f343e3f3e606a;
		Server.RestartingRound -= _m1534083f292e3b282e33343d08352f343e606a;
		Timing.KillCoroutines((CoroutineHandle[])(object)new CoroutineHandle[1] { _f3635383823193528352f2e33343f606a });
		Timing.KillCoroutines(Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0Lk11c2ljQm94LkxvYmJ5")));
		Timing.KillCoroutines(Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0Lk11c2ljQm94")));
		_f08d8914419b0dedb = false;
		_m092e352a0a363b23383b3931606a();
		foreach (ReferenceHub item in _f74657374506c61796261636b733a300.Keys.ToList())
		{
			_m53746f7054657374506c61796261636b3a300(item);
		}
		_f372f29333918230f293f28133e606a.Clear();
		_f3635383823172f2933391e33293b38363f3e0f293f28133e29606a.Clear();
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public bool TrySet(string userId, string requestedMvpMusicName, string requestedLobbyMusicName, string requestedMvpBotName, string requestedLobbyBotName, float? requestedVolume, out string mvpMusicName, out string lobbyMusicName, out string mvpBotName, out string lobbyBotName, out float? volume, out string error)
	{
		bool replacedExisting;
		return TrySet(userId, requestedMvpMusicName, requestedLobbyMusicName, requestedMvpBotName, requestedLobbyBotName, requestedVolume, out mvpMusicName, out lobbyMusicName, out mvpBotName, out lobbyBotName, out volume, out replacedExisting, out error);
	}

	public bool TrySet(string userId, string requestedMvpMusicName, string requestedLobbyMusicName, string requestedMvpBotName, string requestedLobbyBotName, float? requestedVolume, out string mvpMusicName, out string lobbyMusicName, out string mvpBotName, out string lobbyBotName, out float? volume, out bool replacedExisting, out string error)
	{
		error = null;
		replacedExisting = false;
		mvpMusicName = _m143528373b3633203f172f293339143b373f606a(requestedMvpMusicName);
		lobbyMusicName = _m143528373b3633203f172f293339143b373f606a(requestedLobbyMusicName);
		mvpBotName = _mb7d63e8196a40a23(requestedMvpBotName) ?? _m7c78faa12389f33b(mvpMusicName);
		lobbyBotName = _mb7d63e8196a40a23(requestedLobbyBotName) ?? _m7c78faa12389f33b(lobbyMusicName);
		volume = requestedVolume;
		userId = NormalizeUserId(userId);
		if (string.IsNullOrWhiteSpace(userId))
		{
			error = Encoding.UTF8.GetString(Convert.FromBase64String("U3RlYW1JRC9Vc2VySUQg5LiN6IO95Li656m644CC"));
			return false;
		}
		if (string.IsNullOrWhiteSpace(mvpMusicName))
		{
			error = Encoding.UTF8.GetString(Convert.FromBase64String("TVZQIOmfs+S5kOWQjeensOS4jeiDveS4uuepuuOAgg=="));
			return false;
		}
		if (!_mDyiMUrBjclZR(mvpMusicName, out var musicPath, out error))
		{
			return false;
		}
		if (!string.IsNullOrWhiteSpace(lobbyMusicName) && !_mDyiMUrBjclZR(lobbyMusicName, out musicPath, out error))
		{
			return false;
		}
		if (volume.HasValue && (float.IsNaN(volume.Value) || float.IsInfinity(volume.Value) || volume.Value < 0f || volume.Value > 100f))
		{
			error = Encoding.UTF8.GetString(Convert.FromBase64String("5oC76Z+z6YeP5b+F6aG75Li6IDAg5YiwIDEwMOOAgg=="));
			return false;
		}
		_tufsKzvyQsPaj value;
		bool flag = _f372f29333918230f293f28133e606a.TryGetValue(userId, out value);
		_tufsKzvyQsPaj value2 = new _tufsKzvyQsPaj
		{
			MvpMusic = mvpMusicName,
			LobbyMusic = lobbyMusicName,
			MvpBotName = mvpBotName,
			LobbyBotName = lobbyBotName,
			Volume = volume
		};
		if (flag)
		{
			_f372f29333918230f293f28133e606a.Remove(userId);
		}
		_f372f29333918230f293f28133e606a.Add(userId, value2);
		if (!_mEIkBtTRJQmGE(out error))
		{
			if (flag)
			{
				_f372f29333918230f293f28133e606a[userId] = value;
			}
			else
			{
				_f372f29333918230f293f28133e606a.Remove(userId);
			}
			return false;
		}
		replacedExisting = flag;
		return true;
	}

	public bool TryRemove(string userId, out string normalizedUserId, out string error)
	{
		error = null;
		normalizedUserId = NormalizeUserId(userId);
		if (string.IsNullOrWhiteSpace(normalizedUserId))
		{
			error = Encoding.UTF8.GetString(Convert.FromBase64String("U3RlYW1JRC9Vc2VySUQg5LiN6IO95Li656m644CC"));
			return false;
		}
		if (!_f372f29333918230f293f28133e606a.TryGetValue(normalizedUserId, out var value))
		{
			error = normalizedUserId + Encoding.UTF8.GetString(Convert.FromBase64String("IOWwmuacque7keWumumfs+S5kOebkuOAgg=="));
			return false;
		}
		_f372f29333918230f293f28133e606a.Remove(normalizedUserId);
		if (!_mEIkBtTRJQmGE(out error))
		{
			_f372f29333918230f293f28133e606a[normalizedUserId] = value;
			return false;
		}
		return true;
	}

	public bool IsLobbyMusicEnabled(Player player)
	{
		if (player != null)
		{
			return _m49734c6f6262794d75736963456e61626c65643a300(player.ReferenceHub);
		}
		return false;
	}

	public bool TrySetLobbyMusicEnabled(Player player, bool isEnabled, out string response)
	{
		response = null;
		if (!_f656e61626c65643a300 || player == null || string.IsNullOrWhiteSpace(player.UserId))
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5peg5rOV6K+G5Yir546p5a6277yM5oiW6Z+z5LmQ55uS57O757uf5bCa5pyq5ZCv55So44CC"));
			return false;
		}
		string item = NormalizeUserId(player.UserId);
		bool flag = _f3635383823172f2933391e33293b38363f3e0f293f28133e29606a.Contains(item);
		if (isEnabled)
		{
			_f3635383823172f2933391e33293b38363f3e0f293f28133e29606a.Remove(item);
		}
		else
		{
			_f3635383823172f2933391e33293b38363f3e0f293f28133e29606a.Add(item);
		}
		if (!_m3de7cea2d87dee4a(out var error))
		{
			if (flag)
			{
				_f3635383823172f2933391e33293b38363f3e0f293f28133e29606a.Add(item);
			}
			else
			{
				_f3635383823172f2933391e33293b38363f3e0f293f28133e29606a.Remove(item);
			}
			response = error;
			return false;
		}
		if (!isEnabled)
		{
		}
		response = Encoding.UTF8.GetString(Convert.FromBase64String("5bey5ouS57ud5o6l5pS25aSn5Y6F6Z+z5LmQ55uS77yM6K6+572u5bey5oyB5LmF5YyW77ybTVZQIOmfs+S5kOS4juS4quS6uuivleWQrOS4jeWPl+W9seWTjeOAgg=="));
		return true;
	}

	public bool TryPlayTest(Player listener, bool lobby, out string musicName, out string error)
	{
		return TryPlayTest(listener, (listener == null) ? null : listener.UserId, lobby, out musicName, out error);
	}

	public bool TryPlayTest(Player listener, string musicOwnerUserId, bool lobby, out string musicName, out string error)
	{
		musicName = null;
		error = null;
		if (!_f656e61626c65643a300 || listener == null || listener.ReferenceHub == (ReferenceHub)null || !listener.IsConnected)
		{
			error = Encoding.UTF8.GetString(Convert.FromBase64String("5rWL6K+V546p5a625peg5pWI5oiW6Z+z5LmQ55uS57O757uf5bCa5pyq5ZCv55So44CC"));
			return false;
		}
		string text = NormalizeUserId(musicOwnerUserId);
		if (string.IsNullOrWhiteSpace(text) || !_f372f29333918230f293f28133e606a.TryGetValue(text, out var value) || value == null)
		{
			error = Encoding.UTF8.GetString(Convert.FromBase64String("5L2g5bCa5pyq57uR5a6a6Z+z5LmQ55uS44CC"));
			return false;
		}
		musicName = (lobby ? value.LobbyMusic : value.MvpMusic);
		if (string.IsNullOrWhiteSpace(musicName))
		{
			if (!lobby)
			{
			}
			error = Encoding.UTF8.GetString(Convert.FromBase64String("5L2g5bCa5pyq57uR5a6aIE1WUCDpn7PkuZDjgII="));
			return false;
		}
		if (!_mDyiMUrBjclZR(musicName, out var musicPath, out error))
		{
			return false;
		}
		ReferenceHub listenerHub = listener.ReferenceHub;
		_m53746f7054657374506c61796261636b3a300(listenerHub);
		_ta3fc8a7f01ee229b bot;
		_tcjhuCaiWsEuc tcjhuCaiWsEuc = _me3fe8c24892bffe8(_mc3b70ce847f71fda(value, lobby, musicName), out bot);
		if ((Object)(object)tcjhuCaiWsEuc == (Object)null)
		{
			error = Encoding.UTF8.GetString(Convert.FromBase64String("5peg5rOV5Yib5bu66Z+z5LmQ55uS5rWL6K+V5pKt5pS+5Zmo77yM6K+35p+l55yL5pyN5Yqh56uv5pel5b+X44CC"));
			return false;
		}
		_t7bb602a000314f11 playback = new _t7bb602a000314f11
		{
			Bot = bot,
			Player = tcjhuCaiWsEuc,
			ListenerHub = listenerHub
		};
		playback.FinishedHandler = delegate
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			Timing.CallDelayed(0.1f, (Action)delegate
			{
				_m436f6d706c65746554657374506c61796261636b3a300(listenerHub, playback);
			});
		};
		tcjhuCaiWsEuc.BroadcastChannel = (VoiceChatChannel)6;
		tcjhuCaiWsEuc.TargetReceiver = listenerHub;
		tcjhuCaiWsEuc.Volume = _m1d3f2e0c35362f373f606a(value, lobby);
		tcjhuCaiWsEuc.Loop = false;
		tcjhuCaiWsEuc.PlaybackFinished += playback.FinishedHandler;
		_f74657374506c61796261636b733a300[listenerHub] = playback;
		tcjhuCaiWsEuc.Play(musicPath);
		return true;
	}

	public bool StopTest(Player listener)
	{
		if (listener != null)
		{
			return _m53746f7054657374506c61796261636b3a300(listener.ReferenceHub);
		}
		return false;
	}

	private void _m7d182fe7c224cf26(VerifiedEventArgs ev)
	{
		if (_f08d8914419b0dedb && !_f6973506c6179696e673a300)
		{
			_m0939323f3e2f363f1635383823172f293339606a();
		}
	}

	private void _mjCJhjLwKrgiu(LeftEventArgs ev)
	{
		if (ev.Player != null)
		{
			_m53746f7054657374506c61796261636b3a300(ev.Player.ReferenceHub);
		}
	}

	private void _mEkHZggnFRvdW()
	{
		_f08d8914419b0dedb = true;
		_m092e352a0a363b23383b3931606a();
		_m0939323f3e2f363f1635383823172f293339606a();
	}

	private void _m4f6e526f756e64537461727465643a300()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		_f08d8914419b0dedb = false;
		Timing.KillCoroutines((CoroutineHandle[])(object)new CoroutineHandle[1] { _f3635383823193528352f2e33343f606a });
		Timing.KillCoroutines(Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0Lk11c2ljQm94LkxvYmJ5")));
		Timing.KillCoroutines(Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0Lk11c2ljQm94")));
		_m092e352a0a363b23383b3931606a();
	}

	private void _m153408352f343e1f343e3f3e606a(RoundEndedEventArgs ev)
	{
		_f08d8914419b0dedb = false;
		_m092e352a0a363b23383b3931606a();
		string userId = RoundMvpDisplay.Instance?.GetMvpUserId();
		if (_m547279476574506c617961626c654d757369633a300(userId, lobby: false, out var musicName, out var musicPath, out var botName, out var volume))
		{
			_m485e8a9ec4062262(musicName, musicPath, botName, volume, loop: false);
		}
	}

	private void _m1534083f292e3b282e33343d08352f343e606a()
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		_f08d8914419b0dedb = false;
		Timing.KillCoroutines((CoroutineHandle[])(object)new CoroutineHandle[1] { _f3635383823193528352f2e33343f606a });
		Timing.KillCoroutines(Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0Lk11c2ljQm94LkxvYmJ5")));
		Timing.KillCoroutines(Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0Lk11c2ljQm94")));
		_m092e352a0a363b23383b3931606a();
	}

	private void _m0939323f3e2f363f1635383823172f293339606a()
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		Timing.KillCoroutines((CoroutineHandle[])(object)new CoroutineHandle[1] { _f3635383823193528352f2e33343f606a });
		Timing.KillCoroutines(Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0Lk11c2ljQm94LkxvYmJ5")));
		_f3635383823193528352f2e33343f606a = Timing.RunCoroutine(_m53746172744c6f6262794d75736963416674657244656c61793a300(), (Segment)4, Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0Lk11c2ljQm94LkxvYmJ5")));
	}

	private IEnumerator<float> _m53746172744c6f6262794d75736963416674657244656c61793a300()
	{
		yield return Timing.WaitForSeconds(1f);
		if (_f656e61626c65643a300 && _f08d8914419b0dedb && !_f6973506c6179696e673a300)
		{
			_mqNJbgSjwCuLP();
		}
	}

	private void _mqNJbgSjwCuLP()
	{
		if (!_f656e61626c65643a300 || !_f08d8914419b0dedb || _f6973506c6179696e673a300)
		{
			return;
		}
		List<_t0a363b233b38363f172f293339606a> list = new List<_t0a363b233b38363f172f293339606a>();
		foreach (Player item in Player.List.ToList())
		{
			if (_tFpYLlGZVhITT.IsGameplayPlayer(item) && item != Server.Host && _m547279476574506c617961626c654d757369633a300(item.UserId, lobby: true, out var musicName, out var musicPath, out var botName, out var volume))
			{
				list.Add(new _t0a363b233b38363f172f293339606a(musicName, musicPath, botName, volume));
			}
		}
		if (list.Count != 0)
		{
			_t0a363b233b38363f172f293339606a t0a363b233b38363f172f293339606a = list[_f283b343e3537606a.Next(list.Count)];
			_m485e8a9ec4062262(t0a363b233b38363f172f293339606a.Name, t0a363b233b38363f172f293339606a.Path, t0a363b233b38363f172f293339606a.BotName, t0a363b233b38363f172f293339606a.Volume, loop: true);
		}
	}

	private void _m485e8a9ec4062262(string musicName, string musicPath, string botName, float volume, bool loop)
	{
		if (!_f656e61626c65643a300 || string.IsNullOrWhiteSpace(musicPath))
		{
			return;
		}
		_m092e352a0a363b23383b3931606a();
		_f2c31453fb4a6360d = _me3fe8c24892bffe8(botName, out _fBOxrFJpBcoGz);
		if ((Object)(object)_f2c31453fb4a6360d == (Object)null)
		{
			Log.Error(Encoding.UTF8.GetString(Convert.FromBase64String("W011c2ljQm94XSDml6Dms5XliJvlu7rpn7PkuZDnm5IgYm9044CC6KaB5pKt5pS+55qE6Z+z5LmQOiA=")) + musicName);
			return;
		}
		_f2c31453fb4a6360d.BroadcastChannel = (VoiceChatChannel)6;
		if (loop)
		{
			_f2c31453fb4a6360d.ReceiverFilter = _mYZQxjDGkFROS;
		}
		_f2c31453fb4a6360d.Volume = volume;
		_f2c31453fb4a6360d.Loop = loop;
		_f2c31453fb4a6360d.PlaybackFinished += _m4f6e506c61796261636b46696e69736865643a300;
		_f2c31453fb4a6360d.Play(musicPath);
		_f6973506c6179696e673a300 = true;
	}

	private void _m4f6e506c61796261636b46696e69736865643a300()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		_tcjhuCaiWsEuc completedPlayer = _f2c31453fb4a6360d;
		Timing.CallDelayed(0.1f, (Action)delegate
		{
			if (_f2c31453fb4a6360d == completedPlayer)
			{
				_m092e352a0a363b23383b3931606a();
			}
		});
	}

	private bool _m547279476574506c617961626c654d757369633a300(string userId, bool lobby, out string musicName, out string musicPath, out string botName, out float volume)
	{
		musicName = null;
		musicPath = null;
		botName = null;
		volume = 0f;
		userId = NormalizeUserId(userId);
		if (string.IsNullOrWhiteSpace(userId) || !_f372f29333918230f293f28133e606a.TryGetValue(userId, out var value) || value == null)
		{
			return false;
		}
		musicName = (lobby ? value.LobbyMusic : value.MvpMusic);
		if (string.IsNullOrWhiteSpace(musicName))
		{
			return false;
		}
		if (!_mDyiMUrBjclZR(musicName, out musicPath, out var _))
		{
			return false;
		}
		botName = _mc3b70ce847f71fda(value, lobby, musicName);
		volume = _m1d3f2e0c35362f373f606a(value, lobby);
		return true;
	}

	private float _m1d3f2e0c35362f373f606a(_tufsKzvyQsPaj selection, bool lobby)
	{
		float? volume = selection.Volume;
		if (!volume.HasValue)
		{
			if (!lobby)
			{
				return _fPkewkxQPfmTD.MvpVolume;
			}
			return _fPkewkxQPfmTD.LobbyVolume;
		}
		return volume.GetValueOrDefault();
	}

	private static string _mc3b70ce847f71fda(_tufsKzvyQsPaj selection, bool lobby, string musicName)
	{
		string text = (lobby ? selection.LobbyBotName : selection.MvpBotName);
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return _m7c78faa12389f33b(musicName);
	}

	private bool _mDyiMUrBjclZR(string musicName, out string musicPath, out string error)
	{
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Expected O, but got Unknown
		error = null;
		musicPath = Path.Combine(MusicDirectory, musicName + Encoding.UTF8.GetString(Convert.FromBase64String("Lm9nZw==")));
		if (!File.Exists(musicPath))
		{
			error = Encoding.UTF8.GetString(Convert.FromBase64String("5pyq5om+5Yiw6Z+z5LmQ5paH5Lu2OiA=")) + musicPath;
			return false;
		}
		try
		{
			VorbisReader val = new VorbisReader(musicPath);
			try
			{
				if (val.Channels != 1 || val.SampleRate != 48000)
				{
					error = Encoding.UTF8.GetString(Convert.FromBase64String("6Z+z5LmQ5b+F6aG75Li6IE9HRyBWb3JiaXPjgIHljZXlo7DpgZPjgIE=")) + 48000 + Encoding.UTF8.GetString(Convert.FromBase64String("IEh644CC"));
					return false;
				}
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			return true;
		}
		catch (Exception ex)
		{
			error = Encoding.UTF8.GetString(Convert.FromBase64String("5peg5rOV6K+75Y+WIE9HRyBWb3JiaXMg6Z+z5LmQOiA=")) + ex.Message;
			return false;
		}
	}

	private void _m092e352a0a363b23383b3931606a()
	{
		_f6973506c6179696e673a300 = false;
		_tcjhuCaiWsEuc f2c31453fb4a6360d = _f2c31453fb4a6360d;
		_ta3fc8a7f01ee229b fBOxrFJpBcoGz = _fBOxrFJpBcoGz;
		_f2c31453fb4a6360d = null;
		_fBOxrFJpBcoGz = null;
		if ((Object)(object)f2c31453fb4a6360d != (Object)null)
		{
			f2c31453fb4a6360d.PlaybackFinished -= _m4f6e506c61796261636b46696e69736865643a300;
			f2c31453fb4a6360d.Dispose();
		}
		fBOxrFJpBcoGz?.Dispose();
	}

	private void _m436f6d706c65746554657374506c61796261636b3a300(ReferenceHub listenerHub, _t7bb602a000314f11 playback)
	{
		if (listenerHub != (ReferenceHub)null && _f74657374506c61796261636b733a300.TryGetValue(listenerHub, out var value) && value == playback)
		{
			_m53746f7054657374506c61796261636b3a300(listenerHub);
		}
	}

	private bool _m53746f7054657374506c61796261636b3a300(ReferenceHub listenerHub)
	{
		if (listenerHub == (ReferenceHub)null || !_f74657374506c61796261636b733a300.TryGetValue(listenerHub, out var value))
		{
			return false;
		}
		_f74657374506c61796261636b733a300.Remove(listenerHub);
		if ((Object)(object)value.Player != (Object)null)
		{
			value.Player.PlaybackFinished -= value.FinishedHandler;
			value.Player.Dispose();
		}
		if (value.Bot != null)
		{
			value.Bot.Dispose();
		}
		return true;
	}

	private bool _mYZQxjDGkFROS(ReferenceHub listenerHub)
	{
		if (_m49734c6f6262794d75736963456e61626c65643a300(listenerHub))
		{
			return !_f74657374506c61796261636b733a300.ContainsKey(listenerHub);
		}
		return false;
	}

	private bool _m49734c6f6262794d75736963456e61626c65643a300(ReferenceHub listenerHub)
	{
		Player val = ((listenerHub == (ReferenceHub)null) ? null : Player.Get(listenerHub));
		string text = ((val == null) ? null : NormalizeUserId(val.UserId));
		if (!string.IsNullOrWhiteSpace(text))
		{
			return !_f3635383823172f2933391e33293b38363f3e0f293f28133e29606a.Contains(text);
		}
		return false;
	}

	private static _tcjhuCaiWsEuc _me3fe8c24892bffe8(string botName, out _ta3fc8a7f01ee229b bot)
	{
		bot = _ta3fc8a7f01ee229b.Create(botName);
		if (bot == null)
		{
			return null;
		}
		_tcjhuCaiWsEuc tcjhuCaiWsEuc = _tcjhuCaiWsEuc.Create(bot.Hub);
		if ((Object)(object)tcjhuCaiWsEuc == (Object)null)
		{
			bot.Dispose();
			bot = null;
		}
		else
		{
			tcjhuCaiWsEuc.StartupDelay = 0.75f;
		}
		return tcjhuCaiWsEuc;
	}

	private void _m16353b3e0a283f3c3f283f34393f29606a()
	{
		_f3635383823172f2933391e33293b38363f3e0f293f28133e29606a.Clear();
		try
		{
			if (!File.Exists(PreferenceDataPath))
			{
				return;
			}
			List<string> list = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(PreferenceDataPath));
			if (list == null)
			{
			}
			foreach (string item in list)
			{
				string text = NormalizeUserId(item);
				if (!string.IsNullOrWhiteSpace(text))
				{
					_f3635383823172f2933391e33293b38363f3e0f293f28133e29606a.Add(text);
				}
			}
		}
		catch (Exception ex)
		{
			Log.Error(Encoding.UTF8.GetString(Convert.FromBase64String("W011c2ljQm94XSDml6Dms5Xor7vlj5Yg")) + PreferenceDataPath + Encoding.UTF8.GetString(Convert.FromBase64String("OiA=")) + ex);
		}
	}

	private bool _m3de7cea2d87dee4a(out string error)
	{
		error = null;
		string text = PreferenceDataPath + Encoding.UTF8.GetString(Convert.FromBase64String("LnRtcA=="));
		try
		{
			Directory.CreateDirectory(Path.GetDirectoryName(PreferenceDataPath));
			File.WriteAllText(text, JsonConvert.SerializeObject((object)_f3635383823172f2933391e33293b38363f3e0f293f28133e29606a.OrderBy((string value) => value).ToList(), (Formatting)1));
			if (File.Exists(PreferenceDataPath))
			{
				File.Replace(text, PreferenceDataPath, null);
			}
			else
			{
				File.Move(text, PreferenceDataPath);
			}
			return true;
		}
		catch (Exception ex)
		{
			error = Encoding.UTF8.GetString(Convert.FromBase64String("5L+d5a2Y5aSn5Y6F6Z+z5LmQ55uS5Liq5oCn5YyW6K6+572u5aSx6LSlOiA=")) + ex.Message;
			Log.Error(Encoding.UTF8.GetString(Convert.FromBase64String("W011c2ljQm94XSA=")) + error);
			try
			{
				if (File.Exists(text))
				{
					File.Delete(text);
				}
			}
			catch
			{
			}
			return false;
		}
	}

	private void _m1b6c67b688f429e1()
	{
		_f372f29333918230f293f28133e606a.Clear();
		try
		{
			if (!File.Exists(DataPath))
			{
				return;
			}
			Dictionary<string, JToken> dictionary = JsonConvert.DeserializeObject<Dictionary<string, JToken>>(File.ReadAllText(DataPath));
			if (dictionary == null)
			{
				return;
			}
			foreach (KeyValuePair<string, JToken> item in dictionary)
			{
				string text = NormalizeUserId(item.Key);
				_tufsKzvyQsPaj tufsKzvyQsPaj = _mAyXuriyUHzGb(item.Value);
				if (!string.IsNullOrWhiteSpace(text) && tufsKzvyQsPaj != null && !string.IsNullOrWhiteSpace(tufsKzvyQsPaj.MvpMusic))
				{
					_f372f29333918230f293f28133e606a[text] = tufsKzvyQsPaj;
				}
			}
		}
		catch (Exception ex)
		{
			Log.Error(Encoding.UTF8.GetString(Convert.FromBase64String("W011c2ljQm94XSDml6Dms5Xor7vlj5Yg")) + DataPath + Encoding.UTF8.GetString(Convert.FromBase64String("OiA=")) + ex);
		}
	}

	private bool _mEIkBtTRJQmGE(out string error)
	{
		error = null;
		try
		{
			Directory.CreateDirectory(Path.GetDirectoryName(DataPath));
			string text = DataPath + Encoding.UTF8.GetString(Convert.FromBase64String("LnRtcA=="));
			File.WriteAllText(text, JsonConvert.SerializeObject((object)_f372f29333918230f293f28133e606a, (Formatting)1));
			if (File.Exists(DataPath))
			{
				File.Replace(text, DataPath, null);
			}
			else
			{
				File.Move(text, DataPath);
			}
			return true;
		}
		catch (Exception ex)
		{
			error = Encoding.UTF8.GetString(Convert.FromBase64String("5L+d5a2Y6Z+z5LmQ55uS5pWw5o2u5aSx6LSlOiA=")) + ex.Message;
			Log.Error(Encoding.UTF8.GetString(Convert.FromBase64String("W011c2ljQm94XSA=")) + error);
			return false;
		}
	}

	public static Player FindOnlinePlayer(string target)
	{
		return BadgeTitleSystem.FindOnlinePlayer(target);
	}

	public static string NormalizeUserId(string value)
	{
		return BadgeTitleSystem.NormalizeUserId(value);
	}

	private static string _m143528373b3633203f172f293339143b373f606a(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			return null;
		}
		string text = Path.GetFileNameWithoutExtension(Path.GetFileName(value.Trim())).Trim();
		if (!string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		return null;
	}

	private static string _mb7d63e8196a40a23(string value)
	{
		if (string.IsNullOrWhiteSpace(value) || value.Trim() == Encoding.UTF8.GetString(Convert.FromBase64String("LQ==")))
		{
			return null;
		}
		string text = value.Trim().Replace(Encoding.UTF8.GetString(Convert.FromBase64String("DQ==")), string.Empty).Replace(Encoding.UTF8.GetString(Convert.FromBase64String("Cg==")), string.Empty);
		if (text.Length > 48)
		{
			return text.Substring(0, 48);
		}
		return text;
	}

	private static string _m7c78faa12389f33b(string musicName)
	{
		if (!string.IsNullOrWhiteSpace(musicName))
		{
			return _mb7d63e8196a40a23(Encoding.UTF8.GetString(Convert.FromBase64String("44CO")) + musicName + Encoding.UTF8.GetString(Convert.FromBase64String("44CP")));
		}
		return null;
	}

	private static _tufsKzvyQsPaj _mAyXuriyUHzGb(JToken token)
	{
		//IL_0004: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Invalid comparison between Unknown and I4
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Invalid comparison between Unknown and I4
		if (token == null || (int)token.Type == 10)
		{
			return null;
		}
		if ((int)token.Type == 8)
		{
			string text = _m143528373b3633203f172f293339143b373f606a(Extensions.Value<string>((IEnumerable<JToken>)token));
			if (!string.IsNullOrWhiteSpace(text))
			{
				return new _tufsKzvyQsPaj
				{
					MvpMusic = text
				};
			}
			return null;
		}
		JObject val = (JObject)(object)((token is JObject) ? token : null);
		if (val == null)
		{
			return null;
		}
		string text2 = _m143528373b3633203f172f293339143b373f606a((string)val[Encoding.UTF8.GetString(Convert.FromBase64String("TXZwTXVzaWM="))]);
		string text3 = _m143528373b3633203f172f293339143b373f606a((string)val[Encoding.UTF8.GetString(Convert.FromBase64String("TG9iYnlNdXNpYw=="))]);
		string text4 = _mb7d63e8196a40a23((string)val[Encoding.UTF8.GetString(Convert.FromBase64String("TXZwQm90TmFtZQ=="))]);
		string text5 = _mb7d63e8196a40a23((string)val[Encoding.UTF8.GetString(Convert.FromBase64String("TG9iYnlCb3ROYW1l"))]);
		float? volume = (float?)val[Encoding.UTF8.GetString(Convert.FromBase64String("Vm9sdW1l"))];
		if (volume.HasValue && (float.IsNaN(volume.Value) || float.IsInfinity(volume.Value) || volume.Value < 0f || volume.Value > 100f))
		{
			volume = null;
		}
		if (!string.IsNullOrWhiteSpace(text2))
		{
			return new _tufsKzvyQsPaj
			{
				MvpMusic = text2,
				LobbyMusic = text3,
				MvpBotName = (text4 ?? _m7c78faa12389f33b(text2)),
				LobbyBotName = (text5 ?? _m7c78faa12389f33b(text3)),
				Volume = volume
			};
		}
		return null;
	}
}
