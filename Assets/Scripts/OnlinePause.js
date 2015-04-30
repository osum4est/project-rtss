/*#pragma strict
import UnityEngine.UI;

var skin : GUISkin;
var buttonOutlineAndTextColor = Color.white;

private var currentPage : onlinePage;
private var toolbarInt : int = 0;
private var toolbarStrings : String[] = ["Audio", "Graphics"];
private var firstPersonControllerCamera : MouseLook;
private var mainCamera : MouseLook;
private var shootScript;

public var MainMenu = Rect (Screen.width,Screen.height,Screen.width,Screen.height);
public var Settings = Rect (Screen.width,Screen.height,Screen.width,Screen.height);
public var openSettings = false;

enum onlinePage{
None, Main, Options, Credits
} 
function centerRectangle (someRect : Rect) : Rect {
	someRect.x = (Screen.width - someRect.width)/2;
	someRect.y = (Screen.height - someRect.height)/2;
	return someRect;
}

function LateUpdate() 
{
	if (Input.GetKeyDown("escape") || Input.GetButtonDown("Pause")) 
	{
        switch (currentPage) 
		{
            case onlinePage.None : PauseGame(); 
			break;
			
            case onlinePage.Main : UnPauseGame(); 
			break;
			
            default : currentPage = onlinePage.Main;
        }
    }
}

function OnGUI() 
{
	var centeredRect : Rect = centerRectangle(MainMenu);
	var	centeredSettings : Rect = centerRectangle(Settings);
	
    if (skin != null) 
	{
		GUI.skin = skin;
	}
		
	if (IsGamePaused() && currentPage == onlinePage.Main) 
	{
        GUI.color = buttonOutlineAndTextColor;

        
		switch (currentPage) 
		{
            case onlinePage.Main: PauseMenu(); 
			break;
			
			case onlinePage.Options: ShowToolbar(); 
			break;
            
        }
    }
    
    if (IsGamePaused() && currentPage == onlinePage.Options) 
	{
        GUI.color = buttonOutlineAndTextColor;

        
		switch (currentPage) 
		{
      
			case onlinePage.Options: ShowToolbar(); 
			break;
			
			case onlinePage.Main: PauseMenu(); 
			break;
            
        }
    }
    
}

function BeginPage(width : int, height : int) 
{
    GUILayout.BeginArea(Rect((Screen.width - width) / 2, (Screen.height - height) / 2, width, height));
}

function EndPage() 
{
    GUILayout.EndArea();
}

function ShowToolbar()
{	
	GUILayout.Label("Quality");
	
	GUILayout.BeginHorizontal();
	
    if (GUILayout.Button("Decrease")) 
	{
        QualitySettings.DecreaseLevel();
    }
	
    if (GUILayout.Button("Increase")) 
	{
        QualitySettings.IncreaseLevel();
    }
	
    GUILayout.EndHorizontal();
    
    GUILayout.Label("Use the slider to adjust the volume. Note that the volume is defaulted at 100%.");
    
    AudioListener.volume = GUILayout.HorizontalSlider(AudioListener.volume, 0.0, 1.0);
    
    GUILayout.Label("Use the sliders to adjust the mouse sensitivity");
    
    GUILayout.BeginHorizontal();
    
   	GUILayout.Label("Y Axis");
   	
   	mainCamera.sensitivityY = GUILayout.HorizontalSlider(mainCamera.sensitivityY,1F, 30F);
    
    GUILayout.EndHorizontal();
    
 	GUILayout.BeginHorizontal();
    
    GUILayout.Label("X Axis");
   	
   	firstPersonControllerCamera.sensitivityX = GUILayout.HorizontalSlider(firstPersonControllerCamera.sensitivityX,1F, 30F);
    
    GUILayout.EndHorizontal();
	
	if (GUILayout.Button("Back")) 
	{
        openSettings = false;
    }
    
    if (openSettings == false)
    {
    	PauseMenu();
    }
}

function PauseMenu() 
{
	GUI.Box(Rect(0, 0, Screen.width, Screen.height), "");
	GUI.Box(Rect(0, 0, Screen.width, Screen.height), "");
	GUI.Box(Rect(0, 0, Screen.width, Screen.height), "");
	GUI.Box(Rect(0, 0, Screen.width, Screen.height), "");
	
	BeginPage(400, 200);
    if(openSettings == true)
    {
    	ShowToolbar();
    }
    else
    {
    	if (GUILayout.Button("Continue"))
			{
			UnPauseGame();
			}
		
		if (GUILayout.Button ("Settings"))
			{
			openSettings = true;
    		}
    		
    	if (GUILayout.Button("Main Menu"))
			{
			Application.LoadLevel (0);
			}
			
		if (GUILayout.Button("Exit to Desktop"))
			{
			Application.Quit();
			}
    }
	
    EndPage();
	
}

function PauseGame() 
{
	//firstPersonControllerCamera = GameObject.Find("CharacterController").GetComponent(MouseLook);
	//mainCamera = GameObject.Find("Main Camera").GetComponent(MouseLook);
	//firstPersonControllerCamera.enabled = false;
	//mainCamera.enabled = false;
	Cursor.lockState = CursorLockMode.None;
	Cursor.visible = true;
	
    currentPage = onlinePage.Main;
}

function UnPauseGame() 
{
	//firstPersonControllerCamera.enabled = true;
	//mainCamera.enabled = true;
    Cursor.lockState = CursorLockMode.Locked;
	Cursor.visible = false;
	
    currentPage = onlinePage.None;
}

function IsGamePaused() 
{
}

function OnApplicationPause (pause : boolean) 
{
    if (IsGamePaused()) 
	{
		AudioListener.pause = true;
    }
}
*/
