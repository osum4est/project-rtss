using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TargetPlusOne : MonoBehaviour {
public Text targetText; 
public Text maxTargetText;

	// Use this for initialization
	void Start () {
		int targets = int.Parse (targetText.text);
		targetText.text = (targets + 1).ToString();
		int maxTargets = int.Parse (maxTargetText.text);
		maxTargetText.text = (maxTargets + 1).ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
