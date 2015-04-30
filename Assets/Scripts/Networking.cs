using UnityEngine;
using System.Collections;

public class Networking : MonoBehaviour {
	public Texture window;
	// Use this for initialization
	bool connected = true;
	bool notConnected = true;
	void Start () {
		Connect ();
	}

	void Connect() {
		PhotonNetwork.ConnectUsingSettings( "FPS+RTS Demo v001" );
	}
	
	// Update is called once per frame
	void Update () {
		if (PhotonNetwork.connectedAndReady && connected == true) {
			Debug.Log ("Connected to server");
			connected = false;
			notConnected = true;
		}
		if (PhotonNetwork.connectedAndReady == false && notConnected == true){
			Debug.Log ("You are Not Connected");
			connected = true;
			notConnected = false;
			}
	}
	void OnPhotonConnectFailed(){
		Debug.Log ("No Connection. Check your Internet connection or if a firewall is blocking access.");
	}

	void OnGUI () {
		GUILayout.Label (PhotonNetwork.connectionStateDetailed.ToString ());
	}

	void OnJoinedLobby() {
		Debug.Log ("Hi");
		RoomInfo[]roomList = PhotonNetwork.GetRoomList ();
		Debug.Log (roomList.Length);
		for(int i = 0; i != roomList.Length; i++){
			Debug.Log ("For loop worked");
			Debug.Log (i);
			GUILayout.Label(roomList[i].name);
		}
	}
}
