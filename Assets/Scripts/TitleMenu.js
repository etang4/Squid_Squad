#pragma strict

var customSkin: GUISkin;

function OnGUI () 
{
	var buttonW: int = 100;
	var buttonH: int = 50;
	var halfScreenW: float = Screen.width/2;
	var halfButtonW: float = buttonW/2;

	//halfScreenW-halfButtonW, 160, 100, 50
	var myRect = new Rect(halfScreenW-halfButtonW - 60, 300, buttonW, buttonH);
	
	var isButtonCreated : boolean = GUI.Button(myRect, "Play Game");
	
	var isButtonCreated2 : boolean = GUI.Button(new Rect(halfScreenW-halfButtonW -60, 380, buttonW, buttonH), "Credits");
	
	GUI.color = Color.white;
	
	if (isButtonCreated) 
	{
		GUI.skin = customSkin;
		Application.LoadLevel("LevelOne");
	}
	
	if (isButtonCreated2) 
	{
		GUI.skin = customSkin;
		Application.LoadLevel("Credits");
	}
	
}
