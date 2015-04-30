/*using UnityEngine;
using System.Collections;

public class Networkstuff : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
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
	}

	void OnGUI ()
	{
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}

	void OnJoinedLobby ()
	{
		Debug.Log ("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom ();
	}

	void OnPhotonRandomJoinFailed ()
	{
		Debug.Log ("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom (null);
	}

	void OnJoinedRoom ()
	{
		Debug.Log ("OnJoinedRoom");
		SpawnMyPlayer ();
	}

	void SpawnMyPlayer ()
	{
		GameObject myPlayer = (GameObject)PhotonNetwork.Instantiate ("CharacterController", Vector3.zero + Vector3.up * 5, Quaternion.identity, 0);
		((MonoBehaviour)myPlayer.GetComponent ("FPSInputController")).enabled = true;
		((MonoBehaviour)myPlayer.GetComponent ("MouseLook")).enabled = true;
		((MonoBehaviour)myPlayer.GetComponent ("CharacterMotor")).enabled = true;
		((MonoBehaviour)myPlayer.GetComponent ("Fp_Shooting")).enabled = true;

		myPlayer.GetComponentInChildren<AudioListener> ().enabled = true;
		myPlayer.GetComponentInChildren<Camera> ().enabled = true;

		((MonoBehaviour)GameObject.Find ("Main Camera").GetComponent ("MouseLook")).enabled = true;

		//myPlayer.GetComponentInChildren
		//((MonoBehaviour)myPlayer.GetComponentInChildren ("MouseLook")).enabled = true;
	}
}*/
