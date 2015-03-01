#pragma strict
import UnityEngine.UI.Text;

var isPaused :boolean = false;
var startTime :float;
var timeGoing : float;

//for show/display times
var minutes: int;
var seconds: int;
var timeStr: String;

var textTimer : GameObject;
var stringTime : UnityEngine.UI.Text;

function Start () {

	startTime = 0.0;
	
	//stringTime = textTimer.GetComponent<UnityEngine.UI.Text>();
}

function Update()
{
	DoCountUP();
}
function DoCountUP()
{
	timeGoing = startTime + Time.timeSinceLevelLoad;

	ShowTime();
	
	stringTime.text = "Time: " + timeStr;
	
}
function ShowTime()
{
	minutes = timeGoing/60;
	seconds = timeGoing%60; //what are remaining after minutes become seconds
	timeStr = minutes.ToString() + ":" + seconds.ToString("D2"); 
	
}