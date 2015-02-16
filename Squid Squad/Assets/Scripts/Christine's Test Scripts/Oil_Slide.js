#pragma strict

//when object collides with an oil slide, it increases in speed in the direction it has been travelling in.
function OnCollisionEnter(col: Collision) 
{
	//if the other object of collision is tagged as "OilSlide"
	if(col.gameObject.tag == "OilSlide") 
	{
		Destroy(col.gameObject);
    	
    transform.Translate(new Vector3(0, 0, 16));
		rigidbody.AddForce(transform.forward *60, ForceMode.Impulse);
		
	}
}