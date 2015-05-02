using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Globals : MonoBehaviour
{
	public static Globals instance;

	[HideInInspector]
	public Text ammoText;
	[HideInInspector]
	public Text maxAmmo;
	[HideInInspector]
	public Slider healthBar;

	[HideInInspector]
	public string chosenName;

	[HideInInspector]
	public GameObject hud;

	[HideInInspector]
	public Dictionary<int, PlayerStats> opponents;
	
	void Start ()
	{
		instance = this;

		opponents = new Dictionary<int, PlayerStats>();

		ammoText = GameObject.FindGameObjectWithTag ("CurrentAmmo").GetComponent<Text>();
		maxAmmo = GameObject.FindGameObjectWithTag ("MaxAmmo").GetComponent<Text>();
		healthBar = GameObject.FindGameObjectWithTag ("HealthBar").GetComponent<Slider>();
	}

	public void AddPlayer(int id, PlayerStats playerStats)
	{

		Debug.Log("setting tag to: " + PhotonPlayer.Find(id).name);
		playerStats.GetComponentInChildren<DText>().SetNameTag(PhotonPlayer.Find(id).name);
		opponents.Add(id, playerStats);
	}


}
