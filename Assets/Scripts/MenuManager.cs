using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuManager : MonoBehaviour
{
	public InputField serverInput;
	public InputField inputName;
	public string nickName;

	public GameObject CurrentMenu;

	public static MenuManager instance;

	public int level = 0;
	public string serverName { 
		get { return serverInput.text; } 
		set { serverInput.text = value; } 
	}

	public GameObject scripts;
	public GameObject canvas;
	public GameObject events;

	public void Start ()
	{
		ShowMenu (CurrentMenu);
		instance = this;
	}

	public void ShowMenu (GameObject menu)
	{
		if (CurrentMenu != null) 
			CurrentMenu.GetComponent<MenuHandler> ().IsOpen = false;
		

		CurrentMenu = menu;
		CurrentMenu.GetComponent<MenuHandler> ().IsOpen = true;
	}

	public void ExitGame ()
	{
		Application.Quit (); 
		
	}

	public void StartMountainRange ()
	{
		level = 1;
		loadLevel (1); 
		
	}

	public void StartDarkForest ()
	{
		level = 2;
		loadLevel (2); 
	}

	public void StartMountainRangeOffline ()
	{
		level = 0;
		Application.LoadLevel (3); 
		
	}
	
	public void StartDarkForestOffline ()
	{
		level = 0;
		Application.LoadLevel (4); 
		
	}
	public void StartTheTree ()
	{
		level = 3;
		loadLevel (5); 
		
	}
	
	public void StartTheTreetOffline ()
	{
		level = 0;
		Application.LoadLevel (6); 
		
	}

	public void StartMineshaft ()
	{
		level = 4;
		loadLevel (7);
	}

	public void StartMuseum ()
	{
		level = 5;
		loadLevel (8);
	}

	void loadLevel (int x)
	{

		GameObject c = GameObject.Instantiate (canvas);
		DontDestroyOnLoad (c);

		GameObject s = GameObject.Instantiate (scripts);
		DontDestroyOnLoad (s);

		GameObject e = GameObject.Instantiate (events);
		DontDestroyOnLoad (e);

		nickName = inputName.text;

		s.GetComponent<Globals> ().hud = c;

		Application.LoadLevel (x);

	}

}
