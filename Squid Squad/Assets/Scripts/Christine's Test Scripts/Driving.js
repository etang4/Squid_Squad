#pragma strict

var acceleration = 45.0f;
var maxSpeed = 200.0f;
var steering =1.0f;
 
function Update() 
{
	if (Input.GetKey (KeyCode.U)) {
	//rigidbody.AddForce (Vector3.forward * -6);
	
 	//moves the object
    transform.Translate(Vector3.forward * steering * Time.deltaTime);
 
 	//speed the object
    steering += acceleration * Time.deltaTime;
 
    if (steering > maxSpeed)
        steering = maxSpeed;
   }
}
/*
if (Input.GetKey ("up")) {
rigidbody.AddForce (Vector3.forward * -6);
}
if (Input.GetKey ("down")) {
rigidbody.AddForce (Vector3.forward * 5);
}
if (Input.GetKey ("left")) {
rigidbody.AddForce (Vector3.right * 5);
}
if (Input.GetKey ("right")) {
rigidbody.AddForce (Vector3.left * 5);
*/