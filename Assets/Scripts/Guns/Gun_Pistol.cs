using UnityEngine;
using System.Collections;

public class Gun_Pistol : Gun
{
	public Gun_Pistol ()
	{
		gun = Resources.Load ("Guns/Pistol") as GameObject;

		maxAmmo = 10;
		currentAmmo = maxAmmo;
	}
}
