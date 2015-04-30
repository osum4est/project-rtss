using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Kill_me : MonoBehaviour {
public GameObject firstPersonController;
public Text targetText;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter () {
		int targets = int.Parse (targetText.text);
		targetText.text = (targets - 1).ToString();
		firstPersonController.GetComponent<AudioSource>().Play();
		Destroy(gameObject);
	}
}
