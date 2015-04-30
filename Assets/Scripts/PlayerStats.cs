using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : Photon.MonoBehaviour
{

	public int startingHealth = 100;
	public int currentHealth;
	public PhotonPlayer photonPlayer;

	public bool isPlayer = false;

	void Start ()
	{
		currentHealth = startingHealth;
		Globals.instance.healthBar.maxValue = startingHealth;
	}

	[RPC]
	public void TakeDamage (int amount)
	{
		currentHealth -= amount;
		if (isPlayer)
			Globals.instance.healthBar.value = currentHealth;
		if (currentHealth <= 0) {
			//Debug.Log (name + " should DIE");
			GameObject.Destroy (gameObject);

			if (isPlayer)
				Respawn ();

		}
	}

	public void Respawn ()
	{
		currentHealth = startingHealth;
		if (isPlayer) {
			Globals.instance.healthBar.value = currentHealth;
			Networkstuff.instance.SpawnMyPlayer ();
		}
	}
}
