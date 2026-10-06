using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using Exiled.Events.Handlers;
using MEC;
using Newtonsoft.Json;

namespace _n4361726c6672656c6c6574740;

public sealed class WebServer : IDisposable
{
	public const int RequiredGamePort = 30002;

	public const int ListenPort = 8080;

	public const string EndpointPath = "/1121";

	private const float _f193b39323f083f3c283f2932093f3935343e29606a = 60f;

	private static readonly byte[] _f7a5fcc0c3f8eab24 = _mwAhAezHsqTWQ("method_not_allowed", "该端点仅支持 GET 请求。");

	private static readonly byte[] _f4e6f74466f756e64526573706f6e73653a300 = _mwAhAezHsqTWQ("not_found", "未找到请求端点。");

	private readonly HashSet<int> _fDTVIhUvipLbo = new HashSet<int>();

	private HttpListener _fe09b7bb144d1a5aa;

	private CoroutineHandle _f15f5ea420abe0a05;

	private byte[] _fIsiRzDYAcqCz = Array.Empty<byte>();

	private int _f63757272656e74506c61796572733a300;

	private int _f6d6178506c61796572733a300;

	private long _fsDfMSfytDwZg;

	private volatile bool _foPOcVvjkanCd;

	public void Start()
	{
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		if (_foPOcVvjkanCd || Server.Port != 30002)
		{
			return;
		}
		try
		{
			_fe09b7bb144d1a5aa = new HttpListener();
			_fe09b7bb144d1a5aa.Prefixes.Add("http://*:" + 8080 + "/");
			_fe09b7bb144d1a5aa.Start();
			_foPOcVvjkanCd = true;
			Player.Verified += _m7d182fe7c224cf26;
			Player.Left += _m5895ad191abbde9b;
			_m52656672657368416c6c4361636865733a300();
			_f15f5ea420abe0a05 = Timing.RunCoroutine(_m2e87057a08f4d114());
			Task.Run((Func<Task>)_m1633292e3f341b29233439606a);
			Log.Info("Web API 已启动: http://0.0.0.0:" + 8080);
		}
		catch (Exception ex)
		{
			Stop();
			Log.Error("启动 Web API 失败: " + ex);
		}
	}

	private async Task _m1633292e3f341b29233439606a()
	{
		while (_foPOcVvjkanCd && _fe09b7bb144d1a5aa != null && _fe09b7bb144d1a5aa.IsListening)
		{
			try
			{
				_mapVyWqsnjtBI(await _fe09b7bb144d1a5aa.GetContextAsync().ConfigureAwait(continueOnCapturedContext: false));
			}
			catch (ObjectDisposedException)
			{
				break;
			}
			catch (HttpListenerException)
			{
				if (!_foPOcVvjkanCd)
				{
					break;
				}
			}
			catch (Exception)
			{
			}
		}
	}

	private void _mapVyWqsnjtBI(HttpListenerContext context)
	{
		try
		{
			string text = _m143528373b3633203f0a3b2e32606a(context.Request.Url.AbsolutePath);
			if (text.Equals(Encoding.UTF8.GetString(Convert.FromBase64String("LzExMjE=")), StringComparison.OrdinalIgnoreCase) && !context.Request.HttpMethod.Equals(Encoding.UTF8.GetString(Convert.FromBase64String("R0VU")), StringComparison.OrdinalIgnoreCase))
			{
				context.Response.Headers[Encoding.UTF8.GetString(Convert.FromBase64String("QWxsb3c="))] = Encoding.UTF8.GetString(Convert.FromBase64String("R0VU"));
				_m093f343e10293534606a(context.Response, 405, _f7a5fcc0c3f8eab24);
			}
			else if (text.Equals(Encoding.UTF8.GetString(Convert.FromBase64String("LzExMjE=")), StringComparison.OrdinalIgnoreCase))
			{
				_m093f343e10293534606a(context.Response, 200, Volatile.Read(ref _fIsiRzDYAcqCz));
			}
			else
			{
				_m093f343e10293534606a(context.Response, 404, _f4e6f74466f756e64526573706f6e73653a300);
			}
		}
		catch (Exception)
		{
			_m194381511c1711ce(context.Response);
		}
	}

	private void _m7d182fe7c224cf26(VerifiedEventArgs ev)
	{
		if (_foPOcVvjkanCd && ev.Player != null && _fDTVIhUvipLbo.Add(ev.Player.Id))
		{
			_f63757272656e74506c61796572733a300 = _fDTVIhUvipLbo.Count;
			_m083f3c283f2932092e3b2e2f29193b39323f606a();
		}
	}

	private void _m5895ad191abbde9b(LeftEventArgs ev)
	{
		if (_foPOcVvjkanCd && ev.Player != null && _fDTVIhUvipLbo.Remove(ev.Player.Id))
		{
			_f63757272656e74506c61796572733a300 = _fDTVIhUvipLbo.Count;
			_m083f3c283f2932092e3b2e2f29193b39323f606a();
		}
	}

	private IEnumerator<float> _m2e87057a08f4d114()
	{
		while (_foPOcVvjkanCd)
		{
			yield return Timing.WaitForSeconds(60f);
			if (_foPOcVvjkanCd)
			{
				_m52656672657368416c6c4361636865733a300();
			}
		}
	}

	private void _m52656672657368416c6c4361636865733a300()
	{
		_fDTVIhUvipLbo.Clear();
		foreach (Player item in Player.List)
		{
			if (item != null)
			{
				_fDTVIhUvipLbo.Add(item.Id);
			}
		}
		_f63757272656e74506c61796572733a300 = _fDTVIhUvipLbo.Count;
		_f6d6178506c61796572733a300 = CustomNetworkManager.TypedSingleton.ReservedMaxPlayers;
		_fsDfMSfytDwZg = Round.ElapsedTime.Ticks;
		_m083f3c283f2932092e3b2e2f29193b39323f606a();
	}

	private void _m083f3c283f2932092e3b2e2f29193b39323f606a()
	{
		int f63757272656e74506c61796572733a = _f63757272656e74506c61796572733a300;
		TimeSpan timeSpan = new TimeSpan(_fsDfMSfytDwZg);
		Volatile.Write(ref _fIsiRzDYAcqCz, _mf8b71dadcaf39135(new global::_tghyPekhuNKrj<int, string, string, int>(f63757272656e74506c61796572733a, f63757272656e74506c61796572733a + Encoding.UTF8.GetString(Convert.FromBase64String("Lw==")) + _f6d6178506c61796572733a300, timeSpan.ToString(Encoding.UTF8.GetString(Convert.FromBase64String("aGhcOm1tXDpzcw=="))), (int)timeSpan.TotalSeconds)));
	}

	private static byte[] _mf8b71dadcaf39135(object value)
	{
		return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(value, (Formatting)0));
	}

	private static byte[] _mwAhAezHsqTWQ(string error, string message)
	{
		return _mf8b71dadcaf39135(new global::_t3c3e665f5f416e6f6e796d6f7573547970653160323a300<string, string>(error, message));
	}

	private static void _m093f343e10293534606a(HttpListenerResponse response, int statusCode, byte[] buffer)
	{
		response.StatusCode = statusCode;
		response.ContentType = Encoding.UTF8.GetString(Convert.FromBase64String("YXBwbGljYXRpb24vanNvbjsgY2hhcnNldD11dGYtOA=="));
		response.ContentLength64 = buffer.Length;
		try
		{
			response.OutputStream.Write(buffer, 0, buffer.Length);
		}
		finally
		{
			response.Close();
		}
	}

	private static void _m194381511c1711ce(HttpListenerResponse response)
	{
		try
		{
			response?.Close();
		}
		catch (Exception)
		{
		}
	}

	private static string _m143528373b3633203f0a3b2e32606a(string path)
	{
		while (string.IsNullOrEmpty(path) || path == Encoding.UTF8.GetString(Convert.FromBase64String("Lw==")))
		{
		}
		return path.TrimEnd('/');
	}

	public void Stop()
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		_foPOcVvjkanCd = false;
		Player.Verified -= _m7d182fe7c224cf26;
		Player.Left -= _m5895ad191abbde9b;
		if (((CoroutineHandle)(ref _f15f5ea420abe0a05)).IsRunning)
		{
			Timing.KillCoroutines((CoroutineHandle[])(object)new CoroutineHandle[1] { _f15f5ea420abe0a05 });
		}
		HttpListener fe09b7bb144d1a5aa = _fe09b7bb144d1a5aa;
		_fe09b7bb144d1a5aa = null;
		fe09b7bb144d1a5aa?.Close();
		_fDTVIhUvipLbo.Clear();
	}

	public void Dispose()
	{
		Stop();
	}
}
