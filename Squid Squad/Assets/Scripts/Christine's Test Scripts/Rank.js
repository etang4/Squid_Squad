#pragma strict

var rank = 0;
var rankCounter : UnityEngine.UI.Text;

//still need to implement checkpoints for carts in order to determine ranks
function Start () 
{
	rankCounter.text = "Rank: " + rank;
}

function Update () 
{

}

//if trigger has not been entered, then make the first cart ranked #1
function OnCollisionEnter(col: Collision) 
{
	if(col.gameObject.tag == "BluePlayer")
	{
		rank = 1;
		renderer.enabled = false;
	}
	
	rankCounter.text = "Rank: " + rank;
	//renderer.enabled = true;
}