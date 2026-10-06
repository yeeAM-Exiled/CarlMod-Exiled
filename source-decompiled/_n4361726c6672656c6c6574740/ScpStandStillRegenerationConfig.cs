using System.ComponentModel;

namespace _n4361726c6672656c6c6574740;

public sealed class ScpStandStillRegenerationConfig
{
	[Description("是否允许 SCP 在静止一段时间后自动恢复生命值。")]
	public bool IsEnabled { get; set; }

	[Description("SCP 必须静止多少秒后才开始回血。")]
	public float StartAfterSeconds { get; set; }

	[Description("SCP 静止回血时每秒恢复的生命值。")]
	public float HealPerSecond { get; set; }

	public ScpStandStillRegenerationConfig()
	{
		_fdPWwcsFkzwOh = true;
		_f3c537461727441667465725365636f6e64733e6b5f5f4261636b696e674669656c643a300 = 5f;
		_f86e36e2554e48f2c = 3f;
		base._002Ector();
	}
}
