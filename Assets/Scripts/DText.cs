using UnityEngine;
using System.Collections;

public class DText : MonoBehaviour {

	public float speed = 120f;

	void Update () {
		Vector3 heading = Camera.main.transform.position - transform.position;
		transform.LookAt(transform.position - heading);
	}

	public void SetNameTag(string name)
	{
		GetComponent<TextMesh> ().text = name;
	}

}
