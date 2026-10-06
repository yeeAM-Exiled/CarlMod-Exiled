using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _n4361726c6672656c6c6574740;

public sealed class ScheduledRestartConfig
{
	[Description("是否启用服务器定期软重启。")]
	public bool IsEnabled { get; set; }

	[Description("每完成多少个回合后软重启服务器。")]
	public int RoundsPerRestart { get; set; }

	[Description("服务器持续没有真实玩家多少秒后软重启。默认 3600 秒，即 1 小时。")]
	public float EmptyServerRestartSeconds { get; set; }

	internal int _m143528373b3633203f606a()
	{
		return 0 + _m66673ac9026a904d(RoundsPerRestart, 5, 1, 1000, delegate(int value)
		{
			RoundsPerRestart = value;
		}) + _mFYGFbriWAdLJ(EmptyServerRestartSeconds, 3600f, 60f, 86400f, delegate(float value)
		{
			EmptyServerRestartSeconds = value;
		});
	}

	private static int _mFYGFbriWAdLJ(float configured, float fallback, float minimum, float maximum, Action<float> assign)
	{
		float obj = ((float.IsNaN(configured) || float.IsInfinity(configured)) ? fallback : Math.Max(minimum, Math.Min(maximum, configured)));
		assign(obj);
		return (!configured.Equals(obj)) ? 1 : 0;
	}

	private static int _m66673ac9026a904d(int configured, int fallback, int minimum, int maximum, Action<int> assign)
	{
		int num = Math.Max(minimum, Math.Min(maximum, configured));
		assign(num);
		return (configured != num) ? 1 : 0;
	}

	public ScheduledRestartConfig()
	{
		_f3c4973456e61626c65643e6b5f5f4261636b696e674669656c643a300 = true;
		_f3c526f756e6473506572526573746172743e6b5f5f4261636b696e674669656c643a300 = 5;
		_fb23d03652ef5acda = 3600f;
		base._002Ector();
	}

	[CompilerGenerated]
	private void _m3c4e6f726d616c697a653e625f5f31325f303a300(int value)
	{
		RoundsPerRestart = value;
	}

	[CompilerGenerated]
	private void _mrJcnYWVHKkKb(float value)
	{
		EmptyServerRestartSeconds = value;
	}
}
