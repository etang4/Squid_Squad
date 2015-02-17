#pragma strict

//balanced acceleration and maxSpeed
var yAcceleration = 14.0f;
var yMaxSpeed = 14.0f;
var yMoveForce = 0.0f;
var yDeceleration = 12.0f;

var negDirection = false;
var posDirection = false;

var guiObject : GUIText;

function Start() 
{  
	guiObject = GameObject.FindWithTag("GUITEXT2").guiText;
}

function Update () 
{ 
	//going forward
	if (Input.GetKey (KeyCode.Y)) {

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
				if(yMoveForce < yMaxSpeed) 
					yMoveForce += yAcceleration * Time.deltaTime;
				else if (yMoveForce >= yMaxSpeed) 
					yMoveForce = yMaxSpeed;
			}
			else if (negDirection)
			{
				//if current force is less than or equal to maxSpeed
				if(yMoveForce <= yMaxSpeed) 
					yMoveForce = yMaxSpeed;
				else if (yMoveForce > yMaxSpeed) 
					yMoveForce -= yAcceleration * Time.deltaTime;
			}
			
			//moves the object
		    transform.Translate(Vector3.forward * yMoveForce * Time.deltaTime);
		    
		    //write to text the position of the object
		    guiObject.text = "Yellow Cart's Speed: " + yMoveForce + "\n" + "Acceleration: " + yAcceleration + "\n" + "MaxSpeed: " + yMaxSpeed;

	   }
	   //if the player is not pressing the key button, then decelerate the speedForce of cart.
	   else
	   {
	   		//for positiveDirected Cart: if the current force is more than the decelerating force, then decrease it.
	   		if(yMoveForce > (yDeceleration * Time.deltaTime)) 
				yMoveForce -= yDeceleration * Time.deltaTime; 
			
			//for negativeDirected Cart: else if the current force is less than the negative deceleration, then increase it.
			else if(yMoveForce < (-yDeceleration * Time.deltaTime)) 
				yMoveForce += yDeceleration * Time.deltaTime; 
				
			//otherwise, stop the speed
			else 
			  	yMoveForce = 0; 
			  	
			//moves the object
		    transform.Translate(Vector3.forward * yMoveForce * Time.deltaTime);
		    
		    //write to text the position of the object
		   	guiObject.text = "Yellow Cart's Speed: " + yMoveForce + "\n" + "Acceleration: " + yAcceleration + "\n" + "MaxSpeed: " + yMaxSpeed;
	   }
}