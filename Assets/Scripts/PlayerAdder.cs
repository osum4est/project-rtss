using UnityEngine;
using System.Collections;

public class PlayerAdder : MonoBehaviour {

	bool set = false;
	//bool addPlayer = false;
	public int mode = 0;
	public int id;

	void Update () 
	{
//		if (addPlayer)
//		{
//			set = true;
//			addPlayer = false;
//			Debug.Log("TRYING TO ADD PLAYER");
//		}

		if (!false)
		{
			int i = -1;
			bool repeat = false;
			
			foreach (GameObject p in GameObject.FindGameObjectsWithTag("Player"))
			{
				if (i == -1)
				{
					i = p.GetComponent<PlayerStats>().photonPlayer;
					continue;
				}
				else
				{
					if (i == p.GetComponent<PlayerStats>().photonPlayer)
					{
						repeat = true;
						break;
					}
				}
				
			}

			if (!repeat)
			{

				if (mode == 0)
				{
					foreach (PhotonPlayer photonPlayer in PhotonNetwork.otherPlayers)
					{
						Networkstuff.instance.AddPlayerStats(photonPlayer.ID);
					}
				}
				else if (mode == 1)
				{
					Networkstuff.instance.AddPlayerStats(id);
				}

				set = true;
				repeat = true;
				Destroy(this);
				return;
			}
		}
	}


}
