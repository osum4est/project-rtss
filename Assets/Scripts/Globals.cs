using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Globals : MonoBehaviour
{
	public static Globals instance;

	[HideInInspector]
	public Text ammoText;
	[HideInInspector]
	public Text maxAmmo;
	[HideInInspector]
	public Slider healthBar;

	// Use this for initialization
	void Start ()
	{
		instance = this;

		ammoText = GameObject.FindGameObjectWithTag ("CurrentAmmo").GetComponent<Text>();
		maxAmmo = GameObject.FindGameObjectWithTag ("MaxAmmo").GetComponent<Text>();
		healthBar = GameObject.FindGameObjectWithTag ("HealthBar").GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
