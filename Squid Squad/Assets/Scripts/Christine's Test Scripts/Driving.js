#pragma strict

var blueCart : GameObject;
var yellowCart : GameObject;

//higher maxSpeed
var bAcceleration = 13.0f;
var bMaxSpeed = 80.0f;
var bMoveForce = 1.0f;

//balanced acceleration and maxSpeed
var yAcceleration = 25.0f;
var yMaxSpeed = 25.0f;
var yMoveForce = 1.0f;

//higher acceleration
var rAcceleration = 33.0f;
var rMaxSpeed = 60.0f;
var rMoveForce = 1.0f;

var steering =1.0f;

function Update() 
{
	//for red cart
	if (Input.GetKey (KeyCode.R)) {
	 	//moves the object
	    /*transform.Translate(Vector3.forward * rMoveForce * Time.deltaTime);
	 
	 	//speed the object
	    rMoveForce += rAcceleration * Time.deltaTime;
	 
	     if(rMoveForce < rMaxSpeed)
	      {
	       	rMoveForce += rAcceleration;
	      }
	      else
	      	rMoveForce = rAcceleration;*/
   }
   if (Input.GetKey (KeyCode.Y)) {
		//moves the object
	    yellowCart.transform.Translate(Vector3.forward * yMoveForce * Time.deltaTime);
	 
	 	//speed the object
	    yMoveForce += yAcceleration * Time.deltaTime;
	 
	    if (yMoveForce < yMaxSpeed)
	        yMoveForce += yAcceleration;
	    else
	    	yMoveForce = yAcceleration;
   }
   if (Input.GetKey (KeyCode.B)) {
		//moves the object
	    blueCart.transform.Translate(Vector3.forward * bMoveForce * Time.deltaTime);
	 
	 	//speed the object
	    bMoveForce += bAcceleration * Time.deltaTime;
	 
	    if (bMoveForce > bMaxSpeed)
	        bMoveForce += bAcceleration;
	    else
	    	bMoveForce = bAcceleration;
   }
}

/*var Speed : float = 0;//Don't touch this 
var MaxSpeed : float = 10;//This is the maximum speed that the object will achieve 
var Acceleration : float = 10;//How fast will object reach a maximum speed 
var Deceleration : float = 10;//How fast will object reach a speed of 0

function Update () 
{ 
	if ((Input.GetKey ("left"))&&(Speed < MaxSpeed)) 
		Speed = Speed - Acceleration Time.deltaTime;
	else if ((Input.GetKey ("right"))&&(Speed > -MaxSpeed)) 
		Speed = Speed + Acceleration Time.deltaTime; 
	else 
	{ 
		if(Speed > Deceleration Time.deltaTime) 
			Speed = Speed - Deceleration Time.deltaTime; 
		else if(Speed < -Deceleration Time.deltaTime) 
			Speed = Speed + Deceleration Time.deltaTime; 
		else Speed = 0; 
	}
	transform.position.x = transform.position.x + Speed * Time.deltaTime; 
}*/
