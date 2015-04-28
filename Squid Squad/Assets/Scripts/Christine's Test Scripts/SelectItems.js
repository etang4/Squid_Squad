#pragma strict

var selectedObjectName: String;
var music1 : AudioClip;
var music2 : AudioClip;
var music3 : AudioClip;
var music4 : AudioClip;
var music5 : AudioClip;
var music6 : AudioClip;

var someMusic : AudioSource;
var camera1 : Camera;

function Start () {
	selectedObjectName = "RaceTrackNode";
	
	someMusic.Play();
}

function Update () {
	//someMusic.Play();
	}

/*Choose Music*/
function ClickMusic1()
{
	//if(someMusic.isPlaying)
	//	someMusic.Stop();
	
	someMusic.clip = music1;
	someMusic.Play();
}
function ClickMusic2()
{
	//if(someMusic.isPlaying)
	//	someMusic.Stop();
	
	someMusic.clip = music2;
	someMusic.Play();
}
function ClickMusic3()
{
	if(someMusic.isPlaying)
		someMusic.Stop();
	
	someMusic.clip = music3;
	someMusic.Play();
}
function ClickMusic4()
{
	if(someMusic.isPlaying)
		someMusic.Stop();
	
	someMusic.clip = music4;
	someMusic.Play();
}
function ClickMusic5()
{
	if(someMusic.isPlaying)
		someMusic.Stop();
	
	someMusic.clip = music5;
	someMusic.Play();
}
function ClickMusic6()
{
	if(someMusic.isPlaying)
		someMusic.Stop();
	
	someMusic.clip = music6;
	someMusic.Play();
}

/*ChooseCarts*/
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
function ClickedRaceTrackItem()
{
	selectedObjectName = "RaceTrackNode";
	
	PlayerPrefs.SetString("CartCharacter", selectedObjectName);
}

