using System.ComponentModel;

namespace _n4361726c6672656c6c6574740;

public sealed class MusicBoxConfig
{
	[Description("是否启用大厅与 MVP 音乐盒。")]
	public bool IsEnabled { get; set; }

	[Description("大厅音乐音量百分比。")]
	public float LobbyVolume { get; set; }

	[Description("MVP 音乐音量百分比。")]
	public float MvpVolume { get; set; }

	public MusicBoxConfig()
	{
		_f3c4973456e61626c65643e6b5f5f4261636b696e674669656c643a300 = true;
		_fEjBLWWrPFbSb = 10f;
		_f66172c2a0c35362f373f64310505183b393133343d1c333f363e606a = 10f;
		base._002Ector();
	}
}
