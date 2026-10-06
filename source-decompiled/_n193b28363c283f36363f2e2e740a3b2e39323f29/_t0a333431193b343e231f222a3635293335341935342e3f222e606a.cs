using System;

namespace _n193b28363c283f36363f2e2e740a3b2e39323f29;

internal static class _t0a333431193b343e231f222a3635293335341935342e3f222e606a
{
	[ThreadStatic]
	private static ReferenceHub _f392f28283f342e1b2e2e3b39313f28606a;

	internal static ReferenceHub _m6ffdb4f8f2ff515a(ReferenceHub attacker)
	{
		ReferenceHub f392f28283f342e1b2e2e3b39313f28606a = _f392f28283f342e1b2e2e3b39313f28606a;
		_f392f28283f342e1b2e2e3b39313f28606a = attacker;
		return f392f28283f342e1b2e2e3b39313f28606a;
	}

	internal static void _m1f22332e606a(ReferenceHub previousAttacker)
	{
		_f392f28283f342e1b2e2e3b39313f28606a = previousAttacker;
	}

	internal static bool _md7e3b3f68fc306a8(ReferenceHub attacker)
	{
		if (attacker != (ReferenceHub)null)
		{
			return _f392f28283f342e1b2e2e3b39313f28606a == attacker;
		}
		return false;
	}
}
