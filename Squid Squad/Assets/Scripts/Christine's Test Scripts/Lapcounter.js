#pragma strict

var lapCount = 0;
var lapCounter : UnityEngine.UI.Text;
//var timer : Gameobject
//Must include ways to get lap object active again
function Start () 
{
	lapCounter.text = "Laps: " + lapCount;
}

function Update () 
{

}

function OnCollisionEnter(col: Collision) 
{
	if(col.gameObject.tag == "BluePlayer")
	{
		lapCount++;
		renderer.enabled = false;
	}
	
	lapCounter.text = "Laps: " + lapCount;
	//renderer.enabled = true;
}