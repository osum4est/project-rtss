using UnityEngine;
using System.Collections;

public class NetworkCharacter : Photon.MonoBehaviour
{
	Vector3 realPosition = Vector3.zero;
	Quaternion realRotation = Quaternion.identity;

	PlayerStats playerStats;

	bool setID = false;

	// Use this for initialization
	void Start ()
	{
		playerStats = GetComponent<PlayerStats> ();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		if (!photonView.isMine) {
			transform.position = Vector3.Lerp (transform.position, realPosition, 0.1f);
			transform.rotation = Quaternion.Lerp (transform.rotation, realRotation, 0.1f);
		}
	}

	public void OnPhotonSerializeView (PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting) {
			stream.SendNext (transform.position);
			stream.SendNext (transform.rotation);
			stream.SendNext (PhotonNetwork.player.ID);
		} else {
			realPosition = (Vector3)stream.ReceiveNext ();
			realRotation = (Quaternion)stream.ReceiveNext ();
			playerStats.photonPlayer = (int)stream.ReceiveNext();
		}
	}
}
