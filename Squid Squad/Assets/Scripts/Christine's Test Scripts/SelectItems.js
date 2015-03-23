#pragma strict

var selectedObjectName: String;

function Start () {

}

function Update () {
	}

function ClickedCartItem1()
{
	selectedObjectName = "BluePlayer";
	
	PlayerPrefs.SetString("CartCharacter", selectedObjectName);
}
function ClickedCartItem2()
{
	selectedObjectName = "RedPlayer";
	
	PlayerPrefs.SetString("CartCharacter", selectedObjectName);
}
function ClickedCartItem3()
{
	selectedObjectName = "YellowPlayer";
	
	PlayerPrefs.SetString("CartCharacter", selectedObjectName);
}
function ClickedNodeItem()
{
	selectedObjectName = "Waypoint";
	
	PlayerPrefs.SetString("CartCharacter", selectedObjectName);
}
