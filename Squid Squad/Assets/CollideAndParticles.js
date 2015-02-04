#pragma strict

var sparkles: GameObject;

function OnCollisionEnter(col: Collision) 
{
	//if the other object of collision is tagged as "Player"
	if(col.gameObject.tag == "Player") 
	{
		//create particles
		var sparkling = Instantiate(sparkles, transform.position, Quaternion.identity);
		/*var flameEmitter: ParticleSystem = flame.GetComponent(ParticleSystem);
		flameEmitter.enableEmission=true;*/

		Destroy(sparkling);
	}  
}