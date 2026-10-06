using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

[CompilerGenerated]
internal sealed class _t3c3e665f5f416e6f6e796d6f7573547970653160323a300<_003Cerror_003Ej__TPar, _003Cmessage_003Ej__TPar>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003Cerror_003Ej__TPar _f3c6572726f723e695f5f4669656c643a300;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly _003Cmessage_003Ej__TPar _fa84972c2cc463b9d;

	public _003Cerror_003Ej__TPar error => this._003Cerror_003Ei__Field;

	public _003Cmessage_003Ej__TPar message => this._003Cmessage_003Ei__Field;

	[DebuggerHidden]
	public _t3c3e665f5f416e6f6e796d6f7573547970653160323a300(_003Cerror_003Ej__TPar error, _003Cmessage_003Ej__TPar message)
	{
		this._003Cerror_003Ei__Field = error;
		this._003Cmessage_003Ei__Field = message;
	}

	[DebuggerHidden]
	public override bool Equals(object value)
	{
		global::_t3c3e665f5f416e6f6e796d6f7573547970653160323a300<_003Cerror_003Ej__TPar, _003Cmessage_003Ej__TPar> t3c3e665f5f416e6f6e796d6f7573547970653160323a = value as global::_t3c3e665f5f416e6f6e796d6f7573547970653160323a300<_003Cerror_003Ej__TPar, _003Cmessage_003Ej__TPar>;
		if (this != t3c3e665f5f416e6f6e796d6f7573547970653160323a)
		{
			if (t3c3e665f5f416e6f6e796d6f7573547970653160323a != null && EqualityComparer<_003Cerror_003Ej__TPar>.Default.Equals(this._003Cerror_003Ei__Field, t3c3e665f5f416e6f6e796d6f7573547970653160323a._003Cerror_003Ei__Field))
			{
				return EqualityComparer<_003Cmessage_003Ej__TPar>.Default.Equals(this._003Cmessage_003Ei__Field, t3c3e665f5f416e6f6e796d6f7573547970653160323a._003Cmessage_003Ei__Field);
			}
			return false;
		}
		return true;
	}

	[DebuggerHidden]
	public override int GetHashCode()
	{
		return (-706705485 * -1521134295 + EqualityComparer<_003Cerror_003Ej__TPar>.Default.GetHashCode(this._003Cerror_003Ei__Field)) * -1521134295 + EqualityComparer<_003Cmessage_003Ej__TPar>.Default.GetHashCode(this._003Cmessage_003Ei__Field);
	}

	[DebuggerHidden]
	public override string ToString()
	{
		string format = Encoding.UTF8.GetString(Convert.FromBase64String("e3sgZXJyb3IgPSB7MH0sIG1lc3NhZ2UgPSB7MX0gfX0="));
		object[] array = new object[2];
		_003Cerror_003Ej__TPar val = this._003Cerror_003Ei__Field;
		array[0] = ((val != null) ? val.ToString() : null);
		_003Cmessage_003Ej__TPar val2 = this._003Cmessage_003Ei__Field;
		array[1] = ((val2 != null) ? val2.ToString() : null);
		return string.Format(null, format, array);
	}
}
