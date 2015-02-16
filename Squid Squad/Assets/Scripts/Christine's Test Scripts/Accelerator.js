#pragma strict

//an invisible target for the object to reach when it 
var targetPos = Vector3(50.22, 6, 35.96); 
var targetPos2 = Vector3(42.46, 0, 35.96);

var gravity = Vector3(0, -9.81f, 0);

//when object collides with a boost or rather a ramp, it flies in the air at an angle and comes down.
function OnCollisionEnter(col: Collision) 
{
	//if the other object of collision is tagged as "Boost"
	if(col.gameObject.tag == "Boost") 
	{
		/*this is for when I will add time, 
		var horizontalSpeed : float = Input.GetAxis("Horizontal") * Time.deltaTime * 10;
    	var verticalSpeed : float = Input.GetAxis("Vertical") * Time.deltaTime * 10;
    	transform.Translate(new Vector3(0, verticalSpeed, horizontalSpeed));
    	*/
    	transform.Translate(new Vector3(0, 6, 6));
    
		rigidbody.AddForce(transform.forward *6);
	}
}