using System;
using System.Text;
using CommandSystem;
using Exiled.API.Features;
using _n4361726c6672656c6c6574742e47616d65706c61790;

namespace _n4361726c6672656c6c6574742e436f6d6d616e64732e436861740;

internal static class _t09392a193537373b343e1935342e3f222e606a
{
	public static bool TryGet(ICommandSender sender, out Player player, out ScpExchangeSystem system, out string response)
	{
		player = Player.Get(sender);
		system = ScpExchangeSystem.Instance;
		if (player == null)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("5Y+q5pyJ546p5a625Y+v5Lul5L2/55So5q2k5ZG95Luk44CC"));
			return false;
		}
		if (system == null)
		{
			response = Encoding.UTF8.GetString(Convert.FromBase64String("U0NQIOS6pOaNouezu+e7n+WwmuacquWQr+eUqOOAgg=="));
			return false;
		}
		response = null;
		return true;
	}
}
