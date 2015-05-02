using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChatManager : Photon.MonoBehaviour
{
	bool typing = false;

	void Start ()
	{
	}
	void Update ()
	{


		if (Input.GetKeyUp (KeyCode.Return) || Input.GetKeyUp (KeyCode.KeypadEnter)) {
			InputField inputField = Globals.instance.hud.GetComponentInChildren<InputField> ();
			Scrollbar scrollbar = Globals.instance.hud.GetComponentInChildren<Scrollbar> ();


			if (typing) {
				inputField.DeactivateInputField ();
				inputField.interactable = false;
				SendMessage (inputField.text);
				((MonoBehaviour)GetComponent ("CharacterMotor")).enabled = true;
				Camera.main.GetComponent<MouseLook> ().enabled = true;
				GetComponent<MouseLook> ().enabled = true;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
				scrollbar.interactable = false;
				GetComponent<Fp_Shooting> ().enabled = true;
				inputField.text = "";
				typing = false;

			} else {
				inputField.interactable = true;
				inputField.ActivateInputField ();
				((MonoBehaviour)GetComponent ("CharacterMotor")).enabled = false;
				Camera.main.GetComponent<MouseLook> ().enabled = false;
				GetComponent<MouseLook> ().enabled = false;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
				scrollbar.interactable = true;
				GetComponent<Fp_Shooting> ().enabled = false;
				typing = true;
			}
		}


	}

	void SendMessage (string message)
	{
		photonView.RPC ("RecieveMessage", PhotonTargets.All, "<color=#D20000><b><i>" + PhotonNetwork.player.name + "</i></b>: </color>" + message);
	}

	[RPC]
	public void RecieveMessage (string message)
	{
		Scrollbar scrollbar = Globals.instance.hud.GetComponentInChildren<Scrollbar> ();
		Text text = Globals.instance.hud.GetComponentInChildren<Text> ();
		text.text += message + "\n";
		scrollbar.value = 0;
	}


}
