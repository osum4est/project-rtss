using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : Photon.MonoBehaviour
{
	public int startingHealth = 100;
	public int currentHealth;

	public int photonPlayer;


	public bool isPlayer = false;

	void Start ()
	{
		currentHealth = startingHealth;
		Globals.instance.healthBar.maxValue = startingHealth;
	}

	void Update()
	{
	}

	[RPC]
	public void TakeDamage (int amount)
	{
		currentHealth -= amount;
		if (isPlayer)
			Globals.instance.healthBar.value = currentHealth;
		if (currentHealth <= 0) {
			GameObject.Destroy (gameObject);

			if (isPlayer)
				Respawn ();

		}
	}


	[RPC]
	public void OtherPlayerSpawn(int id)
	{
		PlayerAdder pa = gameObject.AddComponent<PlayerAdder>();
		pa.mode = 1;
		pa.id = id;
	}

	public void Respawn ()
	{
		currentHealth = startingHealth;
		if (isPlayer) {
			Globals.instance.healthBar.value = currentHealth;
			Globals.instance.opponents.Remove(PhotonNetwork.player.ID);
			Networkstuff.instance.SpawnMyPlayer ();
		}
	}
}
