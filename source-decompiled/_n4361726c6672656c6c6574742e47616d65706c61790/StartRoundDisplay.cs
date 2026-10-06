using System;
using System.Text;
using Exiled.Events.Handlers;
using UnityEngine;

namespace _n4361726c6672656c6c6574742e47616d65706c61790;

public sealed class StartRoundDisplay
{
	private static readonly Vector3 _f1935342e3f342e09393b363f606a = Vector3.one * 0.5f;

	private bool _ffofjtniwOHft;

	public void Enable()
	{
		if (!_ffofjtniwOHft)
		{
			_ffofjtniwOHft = true;
			Server.WaitingForPlayers += _m4f6e57616974696e67466f72506c61796572733a300;
		}
	}

	public void Disable()
	{
		if (_ffofjtniwOHft)
		{
			_ffofjtniwOHft = false;
			Server.WaitingForPlayers -= _m4f6e57616974696e67466f72506c61796572733a300;
		}
	}

	private static void _m4f6e57616974696e67466f72506c61796572733a300()
	{
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		GameObject val = GameObject.Find(Encoding.UTF8.GetString(Convert.FromBase64String("U3RhcnRSb3VuZA==")));
		if ((Object)(object)val == (Object)null)
		{
			return;
		}
		val.transform.localScale = _f1935342e3f342e09393b363f606a;
		Transform val2 = val.transform.Find(Encoding.UTF8.GetString(Convert.FromBase64String("Q29udGVudA==")));
		if ((Object)(object)val2 != (Object)null)
		{
			((Component)val2).gameObject.SetActive(true);
		}
		Component[] componentsInChildren = val.GetComponentsInChildren<Component>(true);
		foreach (Component obj in componentsInChildren)
		{
			string name = ((object)obj).GetType().Name;
			Behaviour val3 = (Behaviour)(object)((obj is Behaviour) ? obj : null);
			if ((Object)(object)val3 != (Object)null && (name == Encoding.UTF8.GetString(Convert.FromBase64String("SW1hZ2U=")) || name == Encoding.UTF8.GetString(Convert.FromBase64String("UmF3SW1hZ2U="))))
			{
				val3.enabled = false;
			}
		}
	}
}
