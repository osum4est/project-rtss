using UnityEngine;
using System.Collections;

public class Networkstuff : Photon.MonoBehaviour
{
	public static PlayerStats me;
	public static Networkstuff instance;
	public GameObject player;

	public void Start ()
	{
		instance = this;
		Connect ();
	}
	
	void Connect ()
	{
		int pickedLevel = MenuManager.instance.level;
		string server = MenuManager.instance.serverName;
		PhotonNetwork.player.name = MenuManager.instance.nickName;

		string build = "005" + server;
		if (pickedLevel == 1) {
			if (!PhotonNetwork.connectedAndReady)
				PhotonNetwork.ConnectUsingSettings ("FPS+RTS MountainRange " + build);
			else
				SpawnMyPlayer ();
		} else if (pickedLevel == 2) {
			if (!PhotonNetwork.connectedAndReady)
				PhotonNetwork.ConnectUsingSettings ("FPS+RTS DarkForest " + build);
			else
				SpawnMyPlayer ();
		} else if (pickedLevel == 3) {
			if (!PhotonNetwork.connectedAndReady)
				PhotonNetwork.ConnectUsingSettings ("FPS+RTS ParticleTree " + build);
			else
				SpawnMyPlayer ();
		} else if (pickedLevel == 4) {
			if (!PhotonNetwork.connectedAndReady)
				PhotonNetwork.ConnectUsingSettings ("FPS+RTS Mineshaft " + build);
			else
				SpawnMyPlayer ();
		} else if (pickedLevel == 5) {
			if (!PhotonNetwork.connectedAndReady)
				PhotonNetwork.ConnectUsingSettings ("FPS+RTS Museum " + build);
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
		player = SpawnMyPlayer ();
		player.GetPhotonView ().RPC ("RecieveMessage", PhotonTargets.All, "<color=#820000><b><i>" + PhotonNetwork.player.name + "</i></b> has joined.</color>");


	}

	public GameObject SpawnMyPlayer ()
	{
		Transform[] points = GameObject.FindGameObjectWithTag ("Spawn Point").GetComponent<SpawnPoints> ().spawnPoints;
		int i = Random.Range (0, points.Length);
		Transform spawnPoint = points [i];
		
		GameObject myPlayer = (GameObject)PhotonNetwork.Instantiate ("CharacterController", spawnPoint.position, Quaternion.identity, 0);

		((MonoBehaviour)myPlayer.GetComponent ("FPSInputController")).enabled = true;
		((MonoBehaviour)myPlayer.GetComponent ("MouseLook")).enabled = true;
		((MonoBehaviour)myPlayer.GetComponent ("CharacterMotor")).enabled = true;
		((MonoBehaviour)myPlayer.GetComponent ("Fp_Shooting")).enabled = true;

		myPlayer.GetComponentInChildren<AudioListener> ().enabled = true;
		myPlayer.GetComponentInChildren<Camera> ().enabled = true;
		myPlayer.GetComponentInChildren<MouseLook> ().enabled = true;
		myPlayer.GetComponentInChildren<PlayerStats> ().enabled = true;
		myPlayer.GetComponentInChildren<ChatManager> ().enabled = true;
		myPlayer.AddComponent<PlayerAdder> ();

		myPlayer.GetComponentInChildren<PlayerStats> ().isPlayer = true;

		myPlayer.GetComponentInChildren<MeshRenderer> ().enabled = false;

		Globals.instance.AddPlayer (PhotonNetwork.player.ID, myPlayer.GetComponentInChildren<PlayerStats> ());
		myPlayer.GetPhotonView ().RPC ("OtherPlayerSpawn", PhotonTargets.Others, PhotonNetwork.player.ID);

		Globals.instance.me = myPlayer;

		return myPlayer;
	}

	public void AddPlayerStats (int id)
	{
		GameObject playerMatch = null;
		foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
			if (id == player.GetComponent<PlayerStats> ().photonPlayer) {
				playerMatch = player;
				break;
			}
		}
		
		if (playerMatch == null) {
			Debug.LogError ("No match for player id");
		} else {
			Globals.instance.AddPlayer (id, playerMatch.GetComponent<PlayerStats> ());
		}
	}
}
