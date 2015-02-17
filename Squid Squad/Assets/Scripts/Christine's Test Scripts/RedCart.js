#pragma strict

//higher acceleration
var rAcceleration = 13.0f;
var rMaxSpeed = 18.0f;
var rMoveForce = 1.0f;
var rDeceleration = 10.0f;

var negDirection = false;
var posDirection = false;

var guiObject : GUIText;

function Start() 
{  
	guiObject = GameObject.FindWithTag("GUITEXT1").guiText;
}

function Update () 
{ 
	//going forward
	if (Input.GetKey (KeyCode.R)) {

			//checks for relative direction
			//if incremented the forward position, would it be greater or lesser than current?
			if(transform.position.z + 6 > transform.position.z)
			{
				posDirection = true;
			}
			else
				negDirection = true;
				
			//if the cart is facing in positive direction,
			if (posDirection)
			{
				//if current force is less than maxSpeed, then increase it
				if(rMoveForce < rMaxSpeed) 
					rMoveForce += rAcceleration * Time.deltaTime;
				else if (rMoveForce >= rMaxSpeed) 
					rMoveForce = rMaxSpeed;
			}
			else if (negDirection)
			{
				//if current force is less than or equal to maxSpeed
				if(rMoveForce <= rMaxSpeed) 
					rMoveForce = rMaxSpeed;
				else if (rMoveForce > rMaxSpeed) 
					rMoveForce -= rAcceleration * Time.deltaTime;
			}
			
			//moves the object
		    transform.Translate(Vector3.forward * rMoveForce * Time.deltaTime);
		    
		    //write to text the position of the object
		    guiObject.text = "Red Cart's Speed: " + rMoveForce + "\n" + "Acceleration: " + rAcceleration + "\n" + "MaxSpeed: " + rMaxSpeed;

	   }
	   //if the player is not pressing the key button, then decelerate the speedForce of cart.
	   else
	   {
	   		//for positiveDirected Cart: if the current force is more than the decelerating force, then decrease it.
	   		if(rMoveForce > (rDeceleration * Time.deltaTime)) 
				rMoveForce -= rDeceleration * Time.deltaTime; 
			
			//for negativeDirected Cart: else if the current force is less than the negative deceleration, then increase it.
			else if(rMoveForce < (-rDeceleration * Time.deltaTime)) 
				rMoveForce += rDeceleration * Time.deltaTime; 
				
			//otherwise, stop the speed
			else 
			  	rMoveForce = 0; 
			  	
			//moves the object
		    transform.Translate(Vector3.forward * rMoveForce * Time.deltaTime);
		    
		    //write to text the position of the object
		   	guiObject.text = "Red Cart's Speed: " + rMoveForce + "\n" + "Acceleration: " + rAcceleration + "\n" + "MaxSpeed: " + rMaxSpeed;
	   }
}