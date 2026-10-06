using System;
using System.Text;
using Mirror;

namespace _n4361726c6672656c6c6574742e436f6d7061746962696c6974790;

internal sealed class _t1c3b313f193534343f392e333534606a : NetworkConnectionToClient
{
	public override string address => Encoding.UTF8.GetString(Convert.FromBase64String("bG9jYWxob3N0"));

	public _t1c3b313f193534343f392e333534606a(int connectionId)
		: base(connectionId, false, 0f)
	{
	}

	public override void Send(ArraySegment<byte> segment, int channelId = 0)
	{
	}
}
