#pragma strict

var customSkin: GUISkin;
var textArea1 : Rect = new Rect(100,400, 510, 510); //define the text box area
var style : GUIStyle;

function OnGUI () 
{
	var buttonW: int = 100;
	var buttonH: int = 50;
	var halfScreenW: float = Screen.width/2;
	var halfButtonW: float = buttonW/2;

	//halfScreenW-halfButtonW, 160, 100, 50
	var myRect = new Rect(halfScreenW-halfButtonW - 80, 450, buttonW, buttonH);
	
	GUI.color = Color.black;
	style.fontSize = 60;
	GUI.Label(Rect(halfScreenW-60, (Screen.height/2) - 330, 100, 25), "Credits:",style);

	 GUI.color = Color.black;
	 style.fontSize = 25;
	GUI.Label(Rect (halfScreenW-250, (Screen.height/2) - 250,510,510), "Programmers:\n Eric Tang\n Haider Tariq\n Christine Lam\n\n Artists:\n Lindsay McLean\n  Jyordana Barsuglia ", style);
	
	GUI.color = Color.blue;
	var isButtonCreated : boolean = GUI.Button(new Rect(100 + halfScreenW-halfButtonW, 650, buttonW, buttonH), "Back to Menu");
	
	if (isButtonCreated) 
	{
		GUI.skin = customSkin;
		Application.LoadLevel("Title Menu");
	}
}
