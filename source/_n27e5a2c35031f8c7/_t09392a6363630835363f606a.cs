using System;
using System.Text;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using PlayerRoles;
using UnityEngine;

namespace _n27e5a2c35031f8c7;

internal sealed class _t09392a6363630835363f606a : CustomRole
{
	public override uint Id
	{
		get
		{
			return 999u;
		}
		set
		{
		}
	}

	public override string Name
	{
		get
		{
			return Encoding.UTF8.GetString(Convert.FromBase64String("U0NQLTk5OQ=="));
		}
		set
		{
		}
	}

	public override string Description
	{
		get
		{
			return Encoding.UTF8.GetString(Convert.FromBase64String("5pS75Ye75LuW5Lq65Y+v5Li65LuW5Lq65Yqg6KGA77yM5Y+v5Y+j5Y+v5LmQ5Lya5a+55L2g55qE6Lqr5L2T6YCg5oiQ5Lil6YeN5Lyk5a6z"));
		}
		set
		{
		}
	}

	public override RoleTypeId Role
	{
		get
		{
			return (RoleTypeId)14;
		}
		set
		{
		}
	}

	public override int MaxHealth
	{
		get
		{
			return 20000;
		}
		set
		{
		}
	}

	public override Vector3 Scale
	{
		get
		{
			//IL_0000: Unknown result type (might be due to invalid IL or missing references)
			//IL_000a: Unknown result type (might be due to invalid IL or missing references)
			return Vector3.one * 0.5f;
		}
		set
		{
		}
	}

	public override string CustomInfo
	{
		get
		{
			return string.Empty;
		}
		set
		{
		}
	}

	public override bool KeepPositionOnSpawn
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	protected override void ShowMessage(Player player)
	{
	}
}
