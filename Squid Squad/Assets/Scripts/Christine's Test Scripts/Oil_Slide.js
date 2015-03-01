#pragma strict

var check = false;

function Update()
{
	if (check == true)
	{
		//moves the object
		transform.Translate(Vector3.forward * 28 * Time.deltaTime);
	}
	
}
//when object collides with an oil slide, it increases in speed in the direction it has been travelling in.
function OnCollisionEnter(col: Collision) 
{
	//if the other object of collision is tagged as "OilSlide"
	if(col.gameObject.tag == "OilSlide") 
	{
		check = true;
		Destroy(col.gameObject);
		
	}
}