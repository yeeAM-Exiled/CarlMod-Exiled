using System;
using System.Text;
using Exiled.API.Features;
using Exiled.CustomRoles.API.Features;
using PlayerRoles;

namespace _n27e5a2c35031f8c7;

internal sealed class _t29994c40fa0f1da5 : CustomRole
{
	public override uint Id
	{
		get
		{
			return 181u;
		}
		set
		{
		}
	}

	public override int MaxHealth
	{
		get
		{
			return 100;
		}
		set
		{
		}
	}

	public override string Name
	{
		get
		{
			return Encoding.UTF8.GetString(Convert.FromBase64String("U0NQLTE4MQ=="));
		}
		set
		{
		}
	}

	public override string Description
	{
		get
		{
			return Encoding.UTF8.GetString(Convert.FromBase64String("5aW96L+Q5bi45Ly05ZC+6Lqr77yb5byA5ZCvU0NQ5p+c5a2Q44CB5Y+R55S156uZ5ZKM6Zeo56aB5pe25pyJNDAl5qaC546H5peg6KeG5p2D6ZmQ5Y2h77yM5byA5ZCv5qC45by555uW5a2Q5pe25pyJMTAl5qaC546H55u05o6l5omT5byA"));
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

	public override RoleTypeId Role
	{
		get
		{
			return (RoleTypeId)1;
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

	public override bool KeepInventoryOnSpawn
	{
		get
		{
			return true;
		}
		set
		{
		}
	}

	public override bool KeepRoleOnChangingRole
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
