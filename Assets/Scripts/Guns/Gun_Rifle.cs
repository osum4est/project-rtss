using UnityEngine;
using System.Collections;

public class Gun_Rifle : Gun
{

	public Gun_Rifle ()
	{

		gun = Resources.Load ("Guns/Sniper") as GameObject;
		maxAmmo = 30;
		currentAmmo = maxAmmo;
	}
	
}
