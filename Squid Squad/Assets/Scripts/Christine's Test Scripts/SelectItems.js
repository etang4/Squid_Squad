#pragma strict

var selectedObjectName: String;
var camera1 : Camera;
var camera2 : Camera;
var camera3 : Camera;

function Start () {

	 /*var tempCamera = GameObject.FindWithTag("ThirdPerson");
	 camera1 = tempCamera.GetComponent(Camera); 
	 
	 tempCamera = GameObject.FindWithTag("MainCamera");
	 camera2 = tempCamera.GetComponent(Camera);
	 
	 tempCamera = GameObject.FindWithTag("SideCamera");
	 camera3 = tempCamera.GetComponent(Camera);
	 
	 camera1.active = false;	
	camera2.active = true;
	camera3.active = false;*/

}

function Update () {
	}
function ClickedCartItem1()
{
	selectedObjectName = "Player";
	
	PlayerPrefs.SetString("CartCharacter", selectedObjectName);
}
function ClickedCartItem2()
{
	selectedObjectName = "BluePlayer";
	
	PlayerPrefs.SetString("CartCharacter", selectedObjectName);
}
function ClickedNodeItem()
{
	selectedObjectName = "Waypoint";
	
	PlayerPrefs.SetString("CartCharacter", selectedObjectName);
}
function ClickedCamera1Item()
{
	/*camera1.active = true;	
	camera2.active = false;
	camera3.active = false;	*/
}
function ClickedCamera2Item()
{
	/*camera1.active = false;	
	camera2.active = true;
	camera3.active = false;*/
}
