#pragma strict

var name1: String = "Unknown";
var play: GameObject;
var quit: GameObject;
var customGuiStyle : GUIStyle;

function Start() {
}


function OnGUI() {
 //name1 = GUI.TextField(Rect(50,50,100,25), name1);
if(GUI.Button(Rect(Screen.width/2-350,Screen.height/2,350,300), "Play", customGuiStyle)) {
 play.name = name1;
 Application.LoadLevel("Mush Mush Land");
 }
 if(GUI.Button(Rect(Screen.width/2+100,Screen.height/2,350,300), "Quit", customGuiStyle)) {
 quit.name = name1;
 Application.Quit();
 }
}