using UnityEngine;
using System.Collections;

public class Networkstuff : MonoBehaviour
{
	public static PlayerStats me;
	public static Networkstuff instance;

	public void Start ()
	{
		instance = this;
		Connect ();
	}
	
	void Connect ()
	{
		int pickedLevel = MenuManager.instance.level;
		
		string build = "003";
		if (pickedLevel == 1) {
			if (!PhotonNetwork.connectedAndReady)
				PhotonNetwork.ConnectUsingSettings ("FPS+RTS MountainRange " + build);
			else
				SpawnMyPlayer ();
		}
		else if (pickedLevel == 2){
			if (!PhotonNetwork.connectedAndReady)
				PhotonNetwork.ConnectUsingSettings ("FPS+RTS DarkForest " + build);
			else
				SpawnMyPlayer ();
		} 
		else if (pickedLevel == 3){
			if (!PhotonNetwork.connectedAndReady)
				PhotonNetwork.ConnectUsingSettings ("FPS+RTS ParticleTree " + build);
			else
				SpawnMyPlayer ();
		}
		else if (pickedLevel == 4){
			if (!PhotonNetwork.connectedAndReady)
				PhotonNetwork.ConnectUsingSettings ("FPS+RTS Mineshaft " + build);
			else
				SpawnMyPlayer ();
		}
	}

	void OnGUI ()
	{
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}

	void OnJoinedLobby ()
	{
		PhotonNetwork.JoinRandomRoom ();
	}

	void OnPhotonRandomJoinFailed ()
	{
		PhotonNetwork.CreateRoom (null);
	}

	void OnJoinedRoom ()
	{
		SpawnMyPlayer ();
	}

	public void SpawnMyPlayer ()
	{
		GameObject myPlayer = (GameObject)PhotonNetwork.Instantiate ("CharacterController", Vector3.zero + Vector3.up * 5, Quaternion.identity, 0);

		//((MonoBehaviour)GameObject.Find ("Main Camera").GetComponent ("MouseLook")).enabled = true;
		//((MonoBehaviour)GameObject.FindGameObjectWithTag ("MainCamera").GetComponent ("MouseLook")).enabled = true;

		((MonoBehaviour)myPlayer.GetComponent ("FPSInputController")).enabled = true;
		((MonoBehaviour)myPlayer.GetComponent ("MouseLook")).enabled = true;
		((MonoBehaviour)myPlayer.GetComponent ("CharacterMotor")).enabled = true;
		((MonoBehaviour)myPlayer.GetComponent ("Fp_Shooting")).enabled = true;

		myPlayer.GetComponentInChildren<AudioListener> ().enabled = true;
		myPlayer.GetComponentInChildren<Camera> ().enabled = true;
		myPlayer.GetComponentInChildren<MouseLook> ().enabled = true;



		//myPlayer.GetComponentInChildren
		myPlayer.GetComponent<PlayerStats> ().isPlayer = true;

	}
}
