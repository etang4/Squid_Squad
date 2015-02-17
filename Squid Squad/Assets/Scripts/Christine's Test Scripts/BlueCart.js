#pragma strict

//higher maxSpeed
var bAcceleration = 6.0f;
var bMaxSpeed = 25.0f;
var bMoveForce = 0.0f;
var bDeceleration = 3.0f;

var negDirection = false;
var posDirection = false;

var guiObject : GUIText;

function Start() 
{  
	guiObject = GameObject.FindWithTag("GUITEXT").guiText;
}

function Update () 
{ 
	//going forward
	if (Input.GetKey (KeyCode.B)) {

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
				if(bMoveForce < bMaxSpeed) 
					bMoveForce += bAcceleration * Time.deltaTime;
				else if (bMoveForce >= bMaxSpeed) 
					bMoveForce = bMaxSpeed;
			}
			else if (negDirection)
			{
				//if current force is less than or equal to maxSpeed
				if(bMoveForce <= bMaxSpeed) 
					bMoveForce = bMaxSpeed;
				else if (bMoveForce > bMaxSpeed) 
					bMoveForce -= bAcceleration * Time.deltaTime;
			}
			
			//moves the object
		    transform.Translate(Vector3.forward * bMoveForce * Time.deltaTime);
		    
		    //write to text the position of the object
		    guiObject.text = "Blue Cart's Speed: " + bMoveForce + "\n" + "Acceleration: " + bAcceleration + "\n" + "MaxSpeed: " + bMaxSpeed;

	   }
	   //if the player is not pressing the key button, then decelerate the speedForce of cart.
	   else
	   {
	   		//for positiveDirected Cart: if the current force is more than the decelerating force, then decrease it.
	   		if(bMoveForce > (bDeceleration * Time.deltaTime)) 
				bMoveForce -= bDeceleration * Time.deltaTime; 
			
			//for negativeDirected Cart: else if the current force is less than the negative deceleration, then increase it.
			else if(bMoveForce < (-bDeceleration * Time.deltaTime)) 
				bMoveForce += bDeceleration * Time.deltaTime; 
				
			//otherwise, stop the speed
			else 
			  	bMoveForce = 0; 
			  	
			//moves the object
		    transform.Translate(Vector3.forward * bMoveForce * Time.deltaTime);
		    
		    //write to text the position of the object
		   	guiObject.text = "Blue Cart's Speed: " + bMoveForce + "\n" + "Acceleration: " + bAcceleration + "\n" + "MaxSpeed: " + bMaxSpeed;
	   }
}