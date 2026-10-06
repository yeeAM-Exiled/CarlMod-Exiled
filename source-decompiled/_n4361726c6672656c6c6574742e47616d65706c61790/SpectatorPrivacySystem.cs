using System.Collections.Generic;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Handlers;
using VoiceChat;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class SpectatorPrivacySystem
{
	private readonly HashSet<ReferenceHub> _flGzmqhWnpdnz = new HashSet<ReferenceHub>();

	private readonly HashSet<string> _fRmIlBfGbNlXm = new HashSet<string>();

	public static SpectatorPrivacySystem Instance { get; private set; }

	public void Enable()
	{
		Instance = this;
		Player.Verified += _m4f6e56657269666965643a300;
		Player.Left += _m5895ad191abbde9b;
		Server.WaitingForPlayers += Reset;
		Server.RestartingRound += Reset;
	}

	public void Disable()
	{
		Player.Verified -= _m4f6e56657269666965643a300;
		Player.Left -= _m5895ad191abbde9b;
		Server.WaitingForPlayers -= Reset;
		Server.RestartingRound -= Reset;
		_flGzmqhWnpdnz.Clear();
		_fRmIlBfGbNlXm.Clear();
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public bool IsRestricted(Player player)
	{
		if (player != null)
		{
			if (!(player.ReferenceHub != (ReferenceHub)null) || !_flGzmqhWnpdnz.Contains(player.ReferenceHub))
			{
				return _fRmIlBfGbNlXm.Contains(_mUJclDnucOjtw(player.UserId));
			}
			return true;
		}
		return false;
	}

	public bool SetRestricted(Player player, bool restricted)
	{
		if (player == null || player.ReferenceHub == (ReferenceHub)null)
		{
			return false;
		}
		string text = _mUJclDnucOjtw(player.UserId);
		bool flag;
		if (restricted)
		{
			flag = _flGzmqhWnpdnz.Add(player.ReferenceHub);
			if (!string.IsNullOrEmpty(text))
			{
				flag |= _fRmIlBfGbNlXm.Add(text);
			}
		}
		else
		{
			flag = _flGzmqhWnpdnz.Remove(player.ReferenceHub);
			if (!string.IsNullOrEmpty(text))
			{
				flag |= _fRmIlBfGbNlXm.Remove(text);
			}
		}
		if (flag)
		{
			RueITextChat.Instance?.RefreshVisibility(player);
		}
		return flag;
	}

	internal static bool _m43616e52656365697665566f6963653a300(ReferenceHub listener, VoiceChatChannel sourceChannel)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Invalid comparison between Unknown and I4
		SpectatorPrivacySystem instance = Instance;
		if ((int)sourceChannel == 4 && instance != null && !(listener == (ReferenceHub)null))
		{
			return !instance._flGzmqhWnpdnz.Contains(listener);
		}
		return true;
	}

	private void _m5895ad191abbde9b(LeftEventArgs ev)
	{
		if (ev.Player != null && ev.Player.ReferenceHub != (ReferenceHub)null)
		{
			_flGzmqhWnpdnz.Remove(ev.Player.ReferenceHub);
		}
	}

	private void _m4f6e56657269666965643a300(VerifiedEventArgs ev)
	{
		if (ev.Player != null && ev.Player.ReferenceHub != (ReferenceHub)null && _fRmIlBfGbNlXm.Contains(_mUJclDnucOjtw(ev.Player.UserId)))
		{
			_flGzmqhWnpdnz.Add(ev.Player.ReferenceHub);
		}
	}

	private void Reset()
	{
		_flGzmqhWnpdnz.Clear();
		_fRmIlBfGbNlXm.Clear();
	}

	private static string _mUJclDnucOjtw(string userId)
	{
		return (userId ?? string.Empty).Trim().ToLowerInvariant();
	}
}
