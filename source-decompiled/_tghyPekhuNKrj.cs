using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class _tghyPekhuNKrj<_003CcurrentPlayers_003Ej__TPar, _003Cstatus_003Ej__TPar, _003CroundElapsedTime_003Ej__TPar, _003CroundElapsedSeconds_003Ej__TPar>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003CcurrentPlayers_003Ej__TPar _fHVWXYnGcDWId;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003Cstatus_003Ej__TPar _f3c7374617475733e695f5f4669656c643a300;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003CroundElapsedTime_003Ej__TPar _f6628352f343e1f363b2a293f3e0e33373f643305051c333f363e606a;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003CroundElapsedSeconds_003Ej__TPar _fZWndnkUZxDqg;

	public _003CcurrentPlayers_003Ej__TPar currentPlayers => this._003CcurrentPlayers_003Ei__Field;

	public _003Cstatus_003Ej__TPar status => this._003Cstatus_003Ei__Field;

	public _003CroundElapsedTime_003Ej__TPar roundElapsedTime => this._003CroundElapsedTime_003Ei__Field;

	public _003CroundElapsedSeconds_003Ej__TPar roundElapsedSeconds => this._003CroundElapsedSeconds_003Ei__Field;

	[DebuggerHidden]
	public _tghyPekhuNKrj(_003CcurrentPlayers_003Ej__TPar currentPlayers, _003Cstatus_003Ej__TPar status, _003CroundElapsedTime_003Ej__TPar roundElapsedTime, _003CroundElapsedSeconds_003Ej__TPar roundElapsedSeconds)
	{
		this._003CcurrentPlayers_003Ei__Field = currentPlayers;
		this._003Cstatus_003Ei__Field = status;
		this._003CroundElapsedTime_003Ei__Field = roundElapsedTime;
		this._003CroundElapsedSeconds_003Ei__Field = roundElapsedSeconds;
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		global::_tghyPekhuNKrj<_003CcurrentPlayers_003Ej__TPar, _003Cstatus_003Ej__TPar, _003CroundElapsedTime_003Ej__TPar, _003CroundElapsedSeconds_003Ej__TPar> tghyPekhuNKrj = value as global::_tghyPekhuNKrj<_003CcurrentPlayers_003Ej__TPar, _003Cstatus_003Ej__TPar, _003CroundElapsedTime_003Ej__TPar, _003CroundElapsedSeconds_003Ej__TPar>;
		if (this != tghyPekhuNKrj)
		{
			if (tghyPekhuNKrj != null && EqualityComparer<_003CcurrentPlayers_003Ej__TPar>.Default.Equals(this._003CcurrentPlayers_003Ei__Field, tghyPekhuNKrj._003CcurrentPlayers_003Ei__Field) && EqualityComparer<_003Cstatus_003Ej__TPar>.Default.Equals(this._003Cstatus_003Ei__Field, tghyPekhuNKrj._003Cstatus_003Ei__Field) && EqualityComparer<_003CroundElapsedTime_003Ej__TPar>.Default.Equals(this._003CroundElapsedTime_003Ei__Field, tghyPekhuNKrj._003CroundElapsedTime_003Ei__Field))
			{
				return EqualityComparer<_003CroundElapsedSeconds_003Ej__TPar>.Default.Equals(this._003CroundElapsedSeconds_003Ei__Field, tghyPekhuNKrj._003CroundElapsedSeconds_003Ei__Field);
			}
			return false;
		}
		return true;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		return (((-1935168627 * -1521134295 + EqualityComparer<_003CcurrentPlayers_003Ej__TPar>.Default.GetHashCode(this._003CcurrentPlayers_003Ei__Field)) * -1521134295 + EqualityComparer<_003Cstatus_003Ej__TPar>.Default.GetHashCode(this._003Cstatus_003Ei__Field)) * -1521134295 + EqualityComparer<_003CroundElapsedTime_003Ej__TPar>.Default.GetHashCode(this._003CroundElapsedTime_003Ei__Field)) * -1521134295 + EqualityComparer<_003CroundElapsedSeconds_003Ej__TPar>.Default.GetHashCode(this._003CroundElapsedSeconds_003Ei__Field);
	}

	[DebuggerHidden]
	public override string ToString()
	{
		string format = Encoding.UTF8.GetString(Convert.FromBase64String("e3sgY3VycmVudFBsYXllcnMgPSB7MH0sIHN0YXR1cyA9IHsxfSwgcm91bmRFbGFwc2VkVGltZSA9IHsyfSwgcm91bmRFbGFwc2VkU2Vjb25kcyA9IHszfSB9fQ=="));
		object[] array = new object[4];
		_003CcurrentPlayers_003Ej__TPar val = this._003CcurrentPlayers_003Ei__Field;
		array[0] = ((val != null) ? val.ToString() : null);
		_003Cstatus_003Ej__TPar val2 = this._003Cstatus_003Ei__Field;
		array[1] = ((val2 != null) ? val2.ToString() : null);
		_003CroundElapsedTime_003Ej__TPar val3 = this._003CroundElapsedTime_003Ei__Field;
		array[2] = ((val3 != null) ? val3.ToString() : null);
		_003CroundElapsedSeconds_003Ej__TPar val4 = this._003CroundElapsedSeconds_003Ei__Field;
		array[3] = ((val4 != null) ? val4.ToString() : null);
		return string.Format(null, format, array);
	}
}
