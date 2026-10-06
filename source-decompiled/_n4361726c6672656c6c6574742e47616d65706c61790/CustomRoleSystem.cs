using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.API.Features.DamageHandlers;
using Exiled.API.Features.Roles;
using Exiled.API.Features.Spawn;
using Exiled.CustomRoles.API;
using Exiled.CustomRoles.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.EventArgs.Server;
using Exiled.Events.Handlers;
using MEC;
using PlayerRoles;
using RueI.Displays;
using RueI.Elements;
using RueI.Extensions;
using UnityEngine;
using _n27e5a2c35031f8c7;
using _n4361726c6672656c6c6574740;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class CustomRoleSystem
{
	[Serializable]
	[CompilerGenerated]
	private sealed class _t3c3e633a300
	{
		public static readonly _t3c3e633a300 _003C_003E9 = new _t3c3e633a300();

		public static Func<Player, bool> _003C_003E9__32_0;

		public static Func<Player, float> _003C_003E9__32_1;

		public static Func<ItemType, bool> _003C_003E9__51_0;

		internal bool _m3c4170706c7953637030373341667465725265737061776e3e625f5f33325f303a300(Player player)
		{
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Invalid comparison between Unknown and I4
			IReadOnlyCollection<CustomRole> customRoles;
			if (player != null && player.IsAlive && (int)player.Role.Type == 11)
			{
				return !CustomRole.TryGet(player, out customRoles);
			}
			return false;
		}

		internal float _mcaca7ab824a996e7(Player _)
		{
			return Random.value;
		}

		internal bool _m821a3d710f3b736e(ItemType item)
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			return ItemExtensions.IsScp(item);
		}
	}

	private const string _fsiuTHEmchhSk = "Carlfrellett.CustomRoles";

	private const float _f536370313831496e746572616374696f6e4368616e63653a300 = 0.4f;

	private const float _f5363703138314e75636c656172436f7665724368616e63653a300 = 0.1f;

	private const float _fb1bf339e637c6fd4 = 20f;

	private const float _f53637035353044656361795061757365506572696f643a300 = 10f;

	private const float _f09392a6f6f6a1e3f393b231e3b373b3d3f0a3f28093f3935343e606a = 1f;

	private const float _f09392a6f6f6a0a3b282e3339363f1e3329282f2a2e3528083f2933292e3b34393f606a = 0.3f;

	private const float _fGoQKZvISAWUj = 0.5f;

	private const float _f5363703037334669726561726d5265666c656374696f6e3a300 = 5f;

	private const float _fvEYIUhQDJPal = 50f;

	private static readonly IElemReference<SetElement> _f0e332e363f083f3c606a = DisplayCore.GetReference<SetElement>();

	private static readonly IElemReference<SetElement> _fbc652882f49c4815 = DisplayCore.GetReference<SetElement>();

	private static readonly IElemReference<SetElement> _f0413bc06490b62d0 = DisplayCore.GetReference<SetElement>();

	private readonly _t29994c40fa0f1da5 _f289e6441949ed9ca = new _t29994c40fa0f1da5();

	private readonly _t09392a6363630835363f606a _f34fa85facfc23196 = new _t09392a6363630835363f606a();

	private readonly _t536370353530526f6c653a300 _f7363703535303a300 = new _t536370353530526f6c653a300();

	private readonly _t536370303733526f6c653a300 _f7363703037333a300 = new _t536370303733526f6c653a300();

	private readonly Dictionary<string, string> _f68696e7443616368653a300 = new Dictionary<string, string>();

	private readonly Dictionary<string, float> _fPHEHuwxgwlyx = new Dictionary<string, float>();

	private readonly Dictionary<string, float> _f73637035353044656361795374617274733a300 = new Dictionary<string, float>();

	private readonly Dictionary<string, float> _feidaVGCuPBmu = new Dictionary<string, float>();

	private readonly HashSet<int> _f7363703535305265737061776e506c617965724964733a300 = new HashSet<int>();

	private bool _fa1046bb93127ffd6;

	private bool _fxAYvdmEJPmDh;

	private bool _fIgLCUiaHdtmy;

	private bool _f3f343b38363f3e606a;

	public void Enable()
	{
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		if (!_f3f343b38363f3e606a)
		{
			_f3f343b38363f3e606a = true;
			_f289e6441949ed9ca.Register();
			_f34fa85facfc23196.Register();
			_f7363703535303a300.Register();
			_f7363703037333a300.Register();
			Server.RoundStarted += _m153408352f343e092e3b282e3f3e606a;
			Server.RespawningTeam += _m1f4301d5baa9349c;
			Player.Hurting += _m1534122f282e33343d606a;
			Player.Shot += _mirqjnkcGmjYV;
			Player.PickingUpItem += _m4f6e5069636b696e6755704974656d3a300;
			Player.InteractingDoor += _myrURzFtjJlxW;
			Player.InteractingLocker += _m4c390977f3cc4799;
			Player.UnlockingGenerator += _movbxVQoYXhCg;
			Player.ActivatingWarheadPanel += _mcfba8cea5500587c;
			Player.Spawned += _m1534092a3b2d343f3e606a;
			Player.Died += _m15341e333f3e606a;
			Player.Left += _m4f6e4c6566743a300;
			Timing.RunCoroutine(_mf7484fc478e2dcec(), (Segment)4, Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0LkN1c3RvbVJvbGVz")));
		}
	}

	public void Disable()
	{
		if (_f3f343b38363f3e606a)
		{
			_f3f343b38363f3e606a = false;
			Server.RoundStarted -= _m153408352f343e092e3b282e3f3e606a;
			Player.Hurting -= _m1534122f282e33343d606a;
			Player.Shot -= _mirqjnkcGmjYV;
			Player.PickingUpItem -= _m4f6e5069636b696e6755704974656d3a300;
			Player.InteractingDoor -= _myrURzFtjJlxW;
			Player.InteractingLocker -= _m4c390977f3cc4799;
			Player.UnlockingGenerator -= _movbxVQoYXhCg;
			Player.ActivatingWarheadPanel -= _mcfba8cea5500587c;
			Player.Spawned -= _m1534092a3b2d343f3e606a;
			Player.Died -= _m15341e333f3e606a;
			Player.Left -= _m4f6e4c6566743a300;
			Server.RespawningTeam -= _m1f4301d5baa9349c;
			Timing.KillCoroutines(Encoding.UTF8.GetString(Convert.FromBase64String("Q2FybGZyZWxsZXR0LkN1c3RvbVJvbGVz")));
			Player[] array = Player.List.Where((Player player) => player != null && (_f289e6441949ed9ca.Check(player) || _f34fa85facfc23196.Check(player) || _f7363703535303a300.Check(player) || _f7363703037333a300.Check(player))).ToArray();
			_f289e6441949ed9ca.Unregister();
			_f34fa85facfc23196.Unregister();
			_f7363703535303a300.Unregister();
			_f7363703037333a300.Unregister();
			Player[] array2 = array;
			for (int num = 0; num < array2.Length; num++)
			{
				ExperienceSystem._m083f3c283f29321e33292a363b23143b373f606a(array2[num]);
			}
			_f68696e7443616368653a300.Clear();
			_fPHEHuwxgwlyx.Clear();
			_f73637035353044656361795374617274733a300.Clear();
			_feidaVGCuPBmu.Clear();
			_f7363703535305265737061776e506c617965724964733a300.Clear();
		}
	}

	public static bool TryAssign(string roleArgument, string playerArgument, out string response)
	{
		CustomRoleSystem customRoleSystem = Plugin.Instance?._pGqHZUEnFydXx;
		if (customRoleSystem == null)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("6Ieq5a6a5LmJ6KeS6Imy57O757uf5bCa5pyq5ZCv55So44CC"));
			return false;
		}
		Player val = Player.List.FirstOrDefault((Player candidate) => candidate != null && (candidate.Id.ToString() == playerArgument || string.Equals(candidate.UserId, playerArgument, StringComparison.OrdinalIgnoreCase) || string.Equals(candidate.Nickname, playerArgument, StringComparison.OrdinalIgnoreCase)));
		if (val == null)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5pyq5om+5Yiw546p5a6277ya")) + playerArgument;
			return false;
		}
		CustomRole f289e6441949ed9ca;
		if (string.Equals(roleArgument, Encoding.UTF8.GetString(Convert.FromBase64String("MTgx")), StringComparison.OrdinalIgnoreCase) || string.Equals(roleArgument, Encoding.UTF8.GetString(Convert.FromBase64String("c2NwMTgx")), StringComparison.OrdinalIgnoreCase))
		{
			f289e6441949ed9ca = customRoleSystem._f289e6441949ed9ca;
		}
		if (string.Equals(roleArgument, Encoding.UTF8.GetString(Convert.FromBase64String("OTk5")), StringComparison.OrdinalIgnoreCase) || string.Equals(roleArgument, Encoding.UTF8.GetString(Convert.FromBase64String("c2NwOTk5")), StringComparison.OrdinalIgnoreCase))
		{
			f289e6441949ed9ca = customRoleSystem._f34fa85facfc23196;
		}
		if (string.Equals(roleArgument, Encoding.UTF8.GetString(Convert.FromBase64String("NTUw")), StringComparison.OrdinalIgnoreCase) || string.Equals(roleArgument, Encoding.UTF8.GetString(Convert.FromBase64String("c2NwNTUw")), StringComparison.OrdinalIgnoreCase))
		{
			f289e6441949ed9ca = customRoleSystem._f7363703535303a300;
		}
		else
		{
			if (!string.Equals(roleArgument, Encoding.UTF8.GetString(Convert.FromBase64String("MDcz")), StringComparison.OrdinalIgnoreCase) && !string.Equals(roleArgument, Encoding.UTF8.GetString(Convert.FromBase64String("c2NwMDcz")), StringComparison.OrdinalIgnoreCase))
			{
				response = Encoding.UTF8.GetString(Convert.FromBase64String("6KeS6Imy5Y+q6IO95pivIDA3M+OAgTE4MeOAgTU1MCDmiJYgOTk544CC"));
				return false;
			}
			f289e6441949ed9ca = customRoleSystem._f7363703037333a300;
		}
		if (f289e6441949ed9ca == customRoleSystem._f7363703535303a300 && customRoleSystem._fa1046bb93127ffd6)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("U0NQLTU1MCDmr4/lsYDlj6rog73nlJ/miJDkuIDmrKHjgII="));
			return false;
		}
		if (f289e6441949ed9ca == customRoleSystem._f7363703037333a300 && customRoleSystem._m123b2916332c33343d09392a6a6d69606a(val))
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5Zy65YaF5bey5pyJ5LiA5ZCN5a2Y5rS755qEIFNDUC0wNzPjgII="));
			return false;
		}
		CustomRole[] array = new CustomRole[4] { customRoleSystem._f7363703037333a300, customRoleSystem._f289e6441949ed9ca, customRoleSystem._f34fa85facfc23196, customRoleSystem._f7363703535303a300 };
		foreach (CustomRole customRole in array)
		{
			if (customRole.Check(val))
			{
				customRole.RemoveRole(val);
			}
		}
		customRoleSystem._m6c600390893c3ef7(f289e6441949ed9ca, val);
		response = Encoding.UTF8.GetString(Convert.FromBase64String("5bey5bCGIA==")) + val.Nickname + Encoding.UTF8.GetString(Convert.FromBase64String("IOiuvuS4uiA=")) + f289e6441949ed9ca.Name + Encoding.UTF8.GetString(Convert.FromBase64String("44CC"));
		return true;
	}

	private void _m1f4301d5baa9349c(RespawningTeamEventArgs ev)
	{
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0028: Invalid comparison between Unknown and I4
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Invalid comparison between Unknown and I4
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Invalid comparison between Unknown and I4
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		if (ev == null || !ev.IsAllowed || ev.Players == null || ev.Players.Count == 0 || ((int)ev.NextKnownTeam != 2 && (int)ev.NextKnownTeam != 1))
		{
			return;
		}
		if ((int)ev.NextKnownTeam == 2 && !_m123b2916332c33343d09392a6a6d69606a() && !_fIgLCUiaHdtmy)
		{
			_fIgLCUiaHdtmy = true;
			Timing.RunCoroutine(_mgCnSLANGvZcs(ev.Players));
		}
		if (_fa1046bb93127ffd6 || _fxAYvdmEJPmDh)
		{
			return;
		}
		_f7363703535305265737061776e506c617965724964733a300.Clear();
		foreach (Player player in ev.Players)
		{
			if (player != null)
			{
				_f7363703535305265737061776e506c617965724964733a300.Add(player.Id);
			}
		}
		_fxAYvdmEJPmDh = _f7363703535305265737061776e506c617965724964733a300.Count > 0;
		if (!_fxAYvdmEJPmDh)
		{
			return;
		}
		Timing.CallDelayed(10f, (Action)delegate
		{
			if (_fxAYvdmEJPmDh)
			{
				_fxAYvdmEJPmDh = false;
				_f7363703535305265737061776e506c617965724964733a300.Clear();
			}
		});
	}

	private static bool _m7d3e40853408336e(Player player)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Invalid comparison between Unknown and I4
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Invalid comparison between Unknown and I4
		if (player == null)
		{
			return false;
		}
		RoleTypeId type = player.Role.Type;
		IReadOnlyCollection<CustomRole> customRoles;
		if ((int)type == 13 || (int)type == 18)
		{
			return !CustomRole.TryGet(player, out customRoles);
		}
		return false;
	}

	private bool _m123b2916332c33343d09392a6a6d69606a(Player ignoredPlayer = null)
	{
		return Player.List.Any((Player player) => player != null && player != ignoredPlayer && player.IsAlive && _f7363703037333a300.Check(player));
	}

	private IEnumerator<float> _mgCnSLANGvZcs(List<Player> respawnedPlayers)
	{
		for (int attempt = 0; attempt < 100; attempt++)
		{
			if (_m123b2916332c33343d09392a6a6d69606a())
			{
				_fIgLCUiaHdtmy = false;
				yield break;
			}
			IReadOnlyCollection<CustomRole> customRoles;
			Player val = (from _ in respawnedPlayers?.Where((Player player) => player != null && player.IsAlive && (int)player.Role.Type == 11 && !CustomRole.TryGet(player, out customRoles))
				orderby Random.value
				select _).FirstOrDefault();
			if (val != null)
			{
				_m6c600390893c3ef7(_f7363703037333a300, val);
				_fIgLCUiaHdtmy = false;
				yield break;
			}
			yield return Timing.WaitForSeconds(0.1f);
		}
		_fIgLCUiaHdtmy = false;
	}

	private void _m1534092a3b2d343f3e606a(SpawnedEventArgs ev)
	{
		if (_fxAYvdmEJPmDh && ev != null && ev.Player != null && _f7363703535305265737061776e506c617965724964733a300.Remove(ev.Player.Id))
		{
			if (ev.Player.IsAlive && _m7d3e40853408336e(ev.Player))
			{
				_m6c600390893c3ef7(_f7363703535303a300, ev.Player);
				_fxAYvdmEJPmDh = false;
				_f7363703535305265737061776e506c617965724964733a300.Clear();
			}
			else if (_f7363703535305265737061776e506c617965724964733a300.Count == 0)
			{
				_fxAYvdmEJPmDh = false;
			}
		}
	}

	private static void _m3d11935ecf943564(Player player)
	{
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		if (player == null)
		{
			return;
		}
		SpawnLocation randomSpawnLocation = RoleExtensions.GetRandomSpawnLocation((RoleTypeId)5);
		if (randomSpawnLocation != null)
		{
			player.Position = randomSpawnLocation.Position;
			return;
		}
		Room val = Room.Get((RoomType)23);
		if ((Object)(object)val != (Object)null)
		{
			player.Position = val.Position + Vector3.up;
		}
	}

	private void _m153408352f343e092e3b282e3f3e606a()
	{
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		_fa1046bb93127ffd6 = false;
		_fxAYvdmEJPmDh = false;
		_f7363703535305265737061776e506c617965724964733a300.Clear();
		_fIgLCUiaHdtmy = false;
		Timing.CallDelayed(1f, (Action)_mJFymFmVujDis);
	}

	private void _mJFymFmVujDis()
	{
		_mOOmIqwlESMpW((RoleTypeId)1, _f289e6441949ed9ca);
		_mOOmIqwlESMpW((RoleTypeId)15, _f34fa85facfc23196);
	}

	private void _mOOmIqwlESMpW(RoleTypeId type, CustomRole role)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		IReadOnlyCollection<CustomRole> customRoles;
		List<Player> list = Player.List.Where((Player p) => p != null && p.Role.Type == type && !CustomRole.TryGet(p, out customRoles)).ToList();
		if (list.Count > 2)
		{
			_m6c600390893c3ef7(role, list[Random.Range(0, list.Count)]);
		}
	}

	private void _m6c600390893c3ef7(CustomRole role, Player player)
	{
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		role.AddRole(player);
		if (player == null)
		{
			return;
		}
		if (_f7363703535303a300.Check(player))
		{
			_fa1046bb93127ffd6 = true;
			_f73637035353044656361795374617274733a300[player.UserId] = Time.realtimeSinceStartup + 20f;
			_feidaVGCuPBmu.Remove(player.UserId);
			player.Health = Math.Min(500f, player.MaxHealth);
			player.HumeShield = 0f;
			_m3d11935ecf943564(player);
			Timing.CallDelayed(0.1f, (Action)delegate
			{
				if (player != null && player.IsAlive && _f7363703535303a300.Check(player))
				{
					player.Health = Math.Min(500f, player.MaxHealth);
					player.HumeShield = 0f;
					_m3d11935ecf943564(player);
				}
			});
		}
		if (_f7363703037333a300.Check(player))
		{
			player.Health = player.MaxHealth;
			player.HumeShield = 0f;
		}
		ExperienceSystem._m083f3c283f29321e33292a363b23143b373f606a(player);
		_fPHEHuwxgwlyx[player.UserId] = Time.realtimeSinceStartup + 15f;
		_f68696e7443616368653a300.Remove(player.UserId);
	}

	private void _m1534122f282e33343d606a(HurtingEventArgs ev)
	{
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Invalid comparison between Unknown and I4
		//IL_0164: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Invalid comparison between Unknown and I4
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Invalid comparison between Unknown and I4
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c2: Invalid comparison between Unknown and I4
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_016f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0171: Invalid comparison between Unknown and I4
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f2: Invalid comparison between Unknown and I4
		//IL_00d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Invalid comparison between Unknown and I4
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		//IL_020a: Invalid comparison between Unknown and I4
		//IL_00ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Invalid comparison between Unknown and I4
		//IL_0224: Unknown result type (might be due to invalid IL or missing references)
		if (ev.Player == null)
		{
			return;
		}
		if (ev.Attacker != null && ev.Attacker != ev.Player && !_f7363703037333a300.Check(ev.Player) && _md6a40e4754499fc2(ev.Attacker) == _md6a40e4754499fc2(ev.Player))
		{
			ev.IsAllowed = false;
			return;
		}
		if (_f289e6441949ed9ca.Check(ev.Player) && ev.Amount >= ev.Player.Health && Random.value < 0.4f)
		{
			ev.IsAllowed = false;
			return;
		}
		if (_f34fa85facfc23196.Check(ev.Player))
		{
			Player attacker = ev.Attacker;
			RoleTypeId val = (RoleTypeId)((attacker == null) ? (-1) : ((int)attacker.Role.Type));
			if ((int)val != 5 && (int)val != 9 && (int)val != 3 && (int)val != 0)
			{
				CustomDamageHandler damageHandler = ev.DamageHandler;
				if (damageHandler == null || (int)((DamageHandlerBase)damageHandler).Type != 23)
				{
					ev.IsAllowed = true;
					if (ev.DamageHandler != null && (int)((DamageHandlerBase)ev.DamageHandler).Type == 13)
					{
						ev.Amount *= 5f;
					}
					return;
				}
			}
			ev.IsAllowed = false;
			return;
		}
		if (_f34fa85facfc23196.Check(ev.Attacker))
		{
			ev.Amount = 0f;
			ev.IsAllowed = true;
			return;
		}
		if (_f7363703535303a300.Check(ev.Player))
		{
			CustomDamageHandler damageHandler2 = ev.DamageHandler;
			DamageType val2 = (DamageType)((damageHandler2 != null) ? ((int)((DamageHandlerBase)damageHandler2).Type) : 0);
			float num = (((int)val2 == 37) ? 0.3f : (((int)val2 == 7) ? 0.5f : 0f));
			ev.Amount *= 1f - num;
			return;
		}
		if (!_f7363703037333a300.Check(ev.Player) || ev.Attacker == null || ev.Attacker == ev.Player || (int)_md6a40e4754499fc2(ev.Attacker) == 0)
		{
			return;
		}
		CustomDamageHandler damageHandler3 = ev.DamageHandler;
		float num2;
		if (damageHandler3 == null || (int)((DamageHandlerBase)damageHandler3).Type != 40)
		{
			CustomDamageHandler damageHandler4 = ev.DamageHandler;
			if (damageHandler4 == null || (int)((DamageHandlerBase)damageHandler4).Type != 37)
			{
				CustomDamageHandler damageHandler5 = ev.DamageHandler;
				num2 = (_m13291c33283f3b28371e3b373b3d3f606a((damageHandler5 != null) ? new DamageType?(((DamageHandlerBase)damageHandler5).Type) : ((DamageType?)null)) ? 5f : 0f);
				goto IL_0248;
			}
		}
		num2 = 50f;
		goto IL_0248;
		IL_0248:
		float num3 = num2;
		if (num3 > 0f)
		{
			ev.Attacker.Hurt(num3, (DamageType)20, Encoding.UTF8.GetString(Convert.FromBase64String("U0NQLTA3M+WPjeS8pA==")));
		}
	}

	private static bool _m13291c33283f3b28371e3b373b3d3f606a(DamageType? damageType)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Invalid comparison between Unknown and I4
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Invalid comparison between Unknown and I4
		//IL_001c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Invalid comparison between Unknown and I4
		if (damageType.HasValue)
		{
			DamageType valueOrDefault = damageType.GetValueOrDefault();
			if ((int)valueOrDefault == 7 || valueOrDefault - 27 <= 8 || (int)valueOrDefault == 39)
			{
				return true;
			}
		}
		return false;
	}

	internal static bool _m49735363703939393a300(Player player)
	{
		CustomRoleSystem customRoleSystem = Plugin.Instance?._pGqHZUEnFydXx;
		if (customRoleSystem != null && player != null)
		{
			return customRoleSystem._f34fa85facfc23196.Check(player);
		}
		return false;
	}

	internal static bool _m0a3f5ba5212f6c56(ReferenceHub hub)
	{
		if (hub != (ReferenceHub)null)
		{
			return _mLGNqWDwdPFOO(Player.Get(hub));
		}
		return false;
	}

	internal static bool _mLGNqWDwdPFOO(Player player)
	{
		CustomRoleSystem customRoleSystem = Plugin.Instance?._pGqHZUEnFydXx;
		if (customRoleSystem != null && player != null)
		{
			return customRoleSystem._f7363703535303a300.Check(player);
		}
		return false;
	}

	internal static bool _mqUKYWxagClXy(Player player)
	{
		CustomRoleSystem customRoleSystem = Plugin.Instance?._pGqHZUEnFydXx;
		if (customRoleSystem != null && player != null)
		{
			return customRoleSystem._f7363703037333a300.Check(player);
		}
		return false;
	}

	internal static bool _mXlPQNDWPOAbe(ReferenceHub hub)
	{
		Player val = ((hub == (ReferenceHub)null) ? null : Player.Get(hub));
		CustomRoleSystem customRoleSystem = Plugin.Instance?._pGqHZUEnFydXx;
		if (customRoleSystem != null && val != null)
		{
			if (!customRoleSystem._f34fa85facfc23196.Check(val))
			{
				return customRoleSystem._f7363703535303a300.Check(val);
			}
			return true;
		}
		return false;
	}

	internal static bool _m193b340a3339310f2a132e3f37606a(ReferenceHub hub, ItemType itemType)
	{
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		return _m183a350b3238300e2b122f3e36616b((hub == (ReferenceHub)null) ? null : Player.Get(hub), itemType);
	}

	internal static bool _m183a350b3238300e2b122f3e36616b(Player player, ItemType itemType)
	{
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Invalid comparison between Unknown and I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Invalid comparison between Unknown and I4
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Invalid comparison between Unknown and I4
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Invalid comparison between Unknown and I4
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Invalid comparison between Unknown and I4
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Invalid comparison between Unknown and I4
		//IL_0069: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Invalid comparison between Unknown and I4
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Invalid comparison between Unknown and I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		CustomRoleSystem customRoleSystem = Plugin.Instance?._pGqHZUEnFydXx;
		if (customRoleSystem == null || player == null)
		{
			return true;
		}
		if (customRoleSystem._f7363703535303a300.Check(player))
		{
			if ((int)itemType != 17 && (int)itemType != 18 && (int)itemType != 16)
			{
				return !ItemExtensions.IsMedical(itemType);
			}
			return false;
		}
		if (!customRoleSystem._f34fa85facfc23196.Check(player))
		{
			return true;
		}
		if ((int)itemType <= 31)
		{
			if ((int)itemType == 16 || (int)itemType == 31)
			{
				goto IL_006e;
			}
		}
		else if ((int)itemType == 47 || (int)itemType == 52)
		{
			goto IL_006e;
		}
		return true;
		IL_006e:
		return false;
	}

	private void _mirqjnkcGmjYV(ShotEventArgs ev)
	{
		if (ev.Player != null && _f34fa85facfc23196.Check(ev.Player))
		{
			ev.Damage = 0f;
			ev.CanHurt = true;
			if (ev.Target != null && ev.Target.IsAlive && ev.Target.Health < ev.Target.MaxHealth)
			{
				ev.Target.Heal(Math.Min(1f, ev.Target.MaxHealth - ev.Target.Health), false);
			}
		}
	}

	private void _m4f6e5069636b696e6755704974656d3a300(PickingUpItemEventArgs ev)
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		if (ev.Player != null && ev.Pickup != null && !_m183a350b3238300e2b122f3e36616b(ev.Player, ev.Pickup.Type))
		{
			ev.IsAllowed = false;
		}
	}

	private void _myrURzFtjJlxW(InteractingDoorEventArgs ev)
	{
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bc: Unknown result type (might be due to invalid IL or missing references)
		if (ev.Player == null || ev.Door == null)
		{
			return;
		}
		if (_f289e6441949ed9ca.Check(ev.Player) && !ev.IsAllowed && _m132919323f39312a3533342e1e353528606a(ev.Door) && Random.value < 0.4f)
		{
			ev.IsAllowed = true;
		}
		else if (_f34fa85facfc23196.Check(ev.Player))
		{
			if (((object)ev.Door.Type/*cast due to .constrained prefix*/).ToString().Contains(Encoding.UTF8.GetString(Convert.FromBase64String("Q2hlY2twb2ludA=="))))
			{
				ev.IsAllowed = true;
			}
			else if (!ev.IsAllowed && ev.Door.RequiredPermissions != null && ((Enum)ev.Door.RequiredPermissions.RequiredPermissions).HasFlag((Enum)(object)(KeycardPermissions)1))
			{
				ev.IsAllowed = true;
			}
		}
	}

	private void _m4c390977f3cc4799(InteractingLockerEventArgs ev)
	{
		if (ev != null && !ev.IsAllowed && ev.Player != null && _f289e6441949ed9ca.Check(ev.Player) && !((Object)(object)ev.Chamber == (Object)null) && ev.Chamber.AcceptableItems != null && ev.Chamber.AcceptableItems.Any((ItemType item) => ItemExtensions.IsScp(item)) && Random.value < 0.4f)
		{
			ev.IsAllowed = true;
		}
	}

	private void _movbxVQoYXhCg(UnlockingGeneratorEventArgs ev)
	{
		if (ev != null && !ev.IsAllowed && ev.Player != null && _f289e6441949ed9ca.Check(ev.Player) && Random.value < 0.4f)
		{
			ev.IsAllowed = true;
		}
	}

	private void _mcfba8cea5500587c(ActivatingWarheadPanelEventArgs ev)
	{
		if (ev != null && !ev.IsAllowed && ev.Player != null && _f289e6441949ed9ca.Check(ev.Player) && Random.value < 0.1f)
		{
			ev.IsAllowed = true;
		}
	}

	private static bool _m132919323f39312a3533342e1e353528606a(Door door)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		if (door == null)
		{
			return false;
		}
		if (((object)door.Type/*cast due to .constrained prefix*/).ToString().Contains(Encoding.UTF8.GetString(Convert.FromBase64String("Q2hlY2twb2ludA=="))))
		{
			return true;
		}
		if (door.RequiredPermissions != null)
		{
			return ((Enum)door.RequiredPermissions.RequiredPermissions).HasFlag((Enum)(object)(KeycardPermissions)1);
		}
		return false;
	}

	private void _m15341e333f3e606a(DiedEventArgs ev)
	{
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		if (ev.Player == null)
		{
			return;
		}
		_mab958611b1480c8c(ev.Player);
		Player player = ev.Player;
		Timing.CallDelayed(0f, (Action)delegate
		{
			ExperienceSystem._m083f3c283f29321e33292a363b23143b373f606a(player);
		});
		_f73637035353044656361795374617274733a300.Remove(player.UserId);
		_feidaVGCuPBmu.Remove(player.UserId);
		if (ev.Attacker != null && ev.Attacker != ev.Player && _f7363703535303a300.Check(ev.Attacker))
		{
			ev.Attacker.Heal(Math.Min(50f, ev.Attacker.MaxHealth - ev.Attacker.Health), false);
			string userId = ev.Attacker.UserId;
			float num = Time.realtimeSinceStartup + 10f;
			if (!_feidaVGCuPBmu.TryGetValue(userId, out var value) || num > value)
			{
				_feidaVGCuPBmu[userId] = num;
			}
		}
	}

	private void _m4f6e4c6566743a300(LeftEventArgs ev)
	{
		if (ev.Player != null)
		{
			_f68696e7443616368653a300.Remove(ev.Player.UserId);
			_fPHEHuwxgwlyx.Remove(ev.Player.UserId);
			_f73637035353044656361795374617274733a300.Remove(ev.Player.UserId);
			_feidaVGCuPBmu.Remove(ev.Player.UserId);
		}
	}

	private void _mab958611b1480c8c(Player player)
	{
		if (player != null && !(player.ReferenceHub == (ReferenceHub)null) && player.IsVerified && player.IsConnected)
		{
			_f68696e7443616368653a300.Remove(player.UserId);
			_fPHEHuwxgwlyx.Remove(player.UserId);
			DisplayCore displayCore = DisplayCore.Get(player);
			displayCore.SetElementOrNew(_f0e332e363f083f3c606a, string.Empty, 500f);
			displayCore.SetElementOrNew(_fbc652882f49c4815, string.Empty, 460f);
			displayCore.SetElementOrNew(_f0413bc06490b62d0, string.Empty, 25f);
			displayCore.Update();
		}
	}

	private IEnumerator<float> _mf7484fc478e2dcec()
	{
		float damageTick = 0f;
		while (_f3f343b38363f3e606a)
		{
			foreach (Player item in Player.List)
			{
				_mNzdiQbHZllIe(item);
				if (_f7363703535303a300.Check(item) && item.IsAlive)
				{
					if (!_f73637035353044656361795374617274733a300.ContainsKey(item.UserId))
					{
						_f73637035353044656361795374617274733a300[item.UserId] = Time.realtimeSinceStartup + 20f;
					}
					if (item.HumeShield > 0f)
					{
						item.HumeShield = 0f;
					}
				}
			}
			if (damageTick >= 1f)
			{
				float realtimeSinceStartup = Time.realtimeSinceStartup;
				foreach (Player item2 in Player.List)
				{
					if (_f7363703535303a300.Check(item2) && item2.IsAlive && _f73637035353044656361795374617274733a300.TryGetValue(item2.UserId, out var value) && !(realtimeSinceStartup < value) && (!_feidaVGCuPBmu.TryGetValue(item2.UserId, out var value2) || !(realtimeSinceStartup < value2)))
					{
						item2.Hurt(1f, (DamageType)20, "SCP-550 decay");
					}
				}
				damageTick = 0f;
			}
			damageTick += 0.5f;
			yield return Timing.WaitForSeconds(0.5f);
		}
	}

	private void _mNzdiQbHZllIe(Player player)
	{
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c->IL0000: Incompatible stack heights: 1 vs 0
		//IL_006f->IL0000: Incompatible stack heights: 1 vs 0
		//IL_0072->IL0000: Incompatible stack heights: 1 vs 0
		//IL_0075->IL0000: Incompatible stack heights: 1 vs 0
		bool num;
		bool flag;
		bool flag2;
		bool flag3;
		string text;
		do
		{
			if (player == null || !player.IsAlive)
			{
				return;
			}
			num = _f289e6441949ed9ca.Check(player);
			flag = _f34fa85facfc23196.Check(player);
			flag2 = _f7363703535303a300.Check(player);
			flag3 = _f7363703037333a300.Check(player);
			text = Encoding.UTF8.GetString(Convert.FromBase64String("Iw==")) + ColorUtility.ToHtmlStringRGB(player.Role.Color);
		}
		while (num || flag || flag2 || flag3);
		_ = null;
		string text2 = Encoding.UTF8.GetString(Convert.FromBase64String("PGNvbG9yPQ==")) + text + Encoding.UTF8.GetString(Convert.FromBase64String("PlNDUC0wNzM8L2NvbG9yPg=="));
		string text3 = Encoding.UTF8.GetString(Convert.FromBase64String("PGNvbG9yPQ==")) + text + Encoding.UTF8.GetString(Convert.FromBase64String("PlNDUC01NTA8L2NvbG9yPg=="));
		if (text2 == null)
		{
		}
		if (!flag)
		{
		}
		if (!flag2)
		{
		}
		if (!flag3)
		{
		}
		string text4 = null;
		float value;
		bool flag4 = text3 != null && _fPHEHuwxgwlyx.TryGetValue(player.UserId, out value) && Time.realtimeSinceStartup < value;
		string text5 = ((text3 == null) ? string.Empty : (text3 + Encoding.UTF8.GetString(Convert.FromBase64String("fA==")) + text4 + Encoding.UTF8.GetString(Convert.FromBase64String("fA==")) + flag4));
		if (!_f68696e7443616368653a300.TryGetValue(player.UserId, out var value2) || !(value2 == text5))
		{
			_f68696e7443616368653a300[player.UserId] = text5;
			DisplayCore displayCore = DisplayCore.Get(player);
			IElemReference<SetElement> f0e332e363f083f3c606a = _f0e332e363f083f3c606a;
			if (!flag4)
			{
			}
			displayCore.SetElementOrNew(f0e332e363f083f3c606a, string.Empty, 500f);
			IElemReference<SetElement> fbc652882f49c = _fbc652882f49c4815;
			if (!flag4)
			{
			}
			displayCore.SetElementOrNew(fbc652882f49c, string.Empty, 460f);
			displayCore.SetElementOrNew(_f0413bc06490b62d0, (text3 == null) ? string.Empty : (Encoding.UTF8.GetString(Convert.FromBase64String("PGFsaWduPWNlbnRlcj48c2l6ZT0yNT5b")) + text3 + Encoding.UTF8.GetString(Convert.FromBase64String("XSA=")) + text4 + Encoding.UTF8.GetString(Convert.FromBase64String("PC9zaXplPjwvYWxpZ24+"))), 25f);
			displayCore.Update();
		}
	}

	internal bool _m547279476574446973706c6179526f6c654e616d653a300(Player player, out string roleName)
	{
		if (player != null && _f289e6441949ed9ca.Check(player))
		{
			roleName = Encoding.UTF8.GetString(Convert.FromBase64String("U0NQLTE4MQ=="));
			return true;
		}
		if (player != null && _f34fa85facfc23196.Check(player))
		{
			roleName = Encoding.UTF8.GetString(Convert.FromBase64String("U0NQLTk5OQ=="));
			return true;
		}
		if (player != null && _f7363703535303a300.Check(player))
		{
			roleName = Encoding.UTF8.GetString(Convert.FromBase64String("U0NQLTU1MA=="));
			return true;
		}
		if (player != null && _f7363703037333a300.Check(player))
		{
			roleName = Encoding.UTF8.GetString(Convert.FromBase64String("U0NQLTA3Mw=="));
			return true;
		}
		roleName = null;
		return false;
	}

	internal static Team _md6a40e4754499fc2(Player player)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		CustomRoleSystem customRoleSystem = Plugin.Instance?._pGqHZUEnFydXx;
		if (customRoleSystem != null && player != null && customRoleSystem._f7363703535303a300.Check(player))
		{
			return (Team)0;
		}
		Team? obj;
		if (player == null)
		{
			obj = null;
		}
		else
		{
			Role role = player.Role;
			obj = ((role != null) ? new Team?(role.Team) : ((Team?)null));
		}
		return (Team)(((_003F?)obj) ?? 6);
	}

	[CompilerGenerated]
	private bool _ma6cdc26ba61a9545(Player player)
	{
		if (player != null)
		{
			if (!_f289e6441949ed9ca.Check(player) && !_f34fa85facfc23196.Check(player) && !_f7363703535303a300.Check(player))
			{
				return _f7363703037333a300.Check(player);
			}
			return true;
		}
		return false;
	}

	[CompilerGenerated]
	private void _m661534083f292a3b2d3433343d0e3f3b37643805056863056a606a()
	{
		if (_fxAYvdmEJPmDh)
		{
			_fxAYvdmEJPmDh = false;
			_f7363703535305265737061776e506c617965724964733a300.Clear();
		}
	}
}
