using System;
using System.Text;
using Exiled.API.Features;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

internal static class _tFpYLlGZVhITT
{
	public static bool IsGameplayPlayer(Player player)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Invalid comparison between Unknown and I4
		if (player != null && player.ReferenceHub != (ReferenceHub)null && player.IsConnected && player.IsVerified && (int)player.ReferenceHub.Mode == 1 && !string.IsNullOrWhiteSpace(player.UserId))
		{
			return player.UserId.IndexOf(Encoding.UTF8.GetString(Convert.FromBase64String("RHVtbXk=")), StringComparison.OrdinalIgnoreCase) < 0;
		}
		return false;
	}

	public static bool IsSameSession(Player player, ReferenceHub hub, string userId)
	{
		if (IsGameplayPlayer(player) && hub != (ReferenceHub)null && player.ReferenceHub == hub)
		{
			return string.Equals(player.UserId, userId, StringComparison.OrdinalIgnoreCase);
		}
		return false;
	}
}
