#pragma strict

var sparkles: GameObject;

function Start () {

}

function Update () {

}

function OnCollisionEnter(col: Collision) 
{
	//if the other object of collision is tagged as "Player"
	if(col.gameObject.tag == "Player") 
	{
		//create particles
		Instantiate(sparkles, transform.position, Quaternion.identity);
		var flameEmitter: ParticleSystem = flame.GetComponent(ParticleSystem);
		flameEmitter.enableEmission=true;

		Destroy(gameObject);
	}  
}