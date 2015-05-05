#pragma strict

var name1: String = "Unknown";
var shooter: GameObject;
var runner: GameObject;
var customGuiStyle : GUIStyle;

function Start() {
}


function OnGUI() {
 //name1 = GUI.TextField(Rect(50,50,100,25), name1);
if(GUI.Button(Rect(Screen.width/2-350,Screen.height/2,350,300), "Build Runner", customGuiStyle)) {
 shooter.name = name1;
 Application.LoadLevel("RunnerEric");
 }
 if(GUI.Button(Rect(Screen.width/2+100,Screen.height/2,350,300), "Demo Runner", customGuiStyle)) {
 runner.name = name1;
 Application.LoadLevel("RunnerDemo");
 }
}