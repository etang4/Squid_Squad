#pragma strict

//higher maxSpeed
var bAcceleration = 6.0f;
var bMaxSpeed = 25.0f;
var bMoveForce = 0.0f;
var bDeceleration = 3.0f;

var negDirection = false;
var posDirection = false;

//steering
var turnSpeed = 6.0f;
var steering : float;

//Some GUI Debugging
var guiObject : GUIText;

//Speedometer GUI Stuffs
var rotationAngle : float;
var dialImage : GameObject;
var dialRotation : Vector3;

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
					
				//rotates the speed needle corresponding to the ticks on the speedometer
				rotationAngle = -Mathf.Lerp(0,1f, bMoveForce);
			   	//dialMovement.rotation = bMoveForce/2.5; 
			   	
			   	dialRotation = new Vector3(0,0, rotationAngle);
				dialImage.transform.Rotate(dialRotation);
			   		
			}
			else if (negDirection)
			{
				//if current force is less than or equal to maxSpeed
				if(bMoveForce <= bMaxSpeed) 
					bMoveForce = bMaxSpeed;
				else if (bMoveForce > bMaxSpeed) 
					bMoveForce -= bAcceleration * Time.deltaTime;
					
				//rotates the speed needle corresponding to the ticks on the speedometer
				rotationAngle = Mathf.Lerp(0,1f, bMoveForce);
			   	//dialMovement.rotation = bMoveForce/2.5; 
			   	
			   	dialRotation = new Vector3(0,0, rotationAngle);
				dialImage.transform.Rotate(dialRotation);
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
	   		{
				bMoveForce -= bDeceleration * Time.deltaTime; 
				
				//rotates the speed needle towards zero, corresponding to the ticks on the speedometer
				//note the from and to parameters are switched
				rotationAngle = -Mathf.Lerp(0f,1f, bMoveForce);
				
			   dialRotation = new Vector3(0,0, Mathf.Clamp(-rotationAngle,-151.2083f, 328.4432f));
			   //dialRotation = new Vector3(0,0, Remap(-rotationAngle,0, 1, -151.2083f, 328.4432f));
				dialImage.transform.Rotate(dialRotation);
			}
			
			//for negativeDirected Cart: else if the current force is less than the negative deceleration, then increase it.
			else if(bMoveForce < (-bDeceleration * Time.deltaTime))
			{ 
				bMoveForce += bDeceleration * Time.deltaTime; 
				
				//rotates the speed needle towards zero, corresponding to the ticks on the speedometer
				//note the from and to parameters are switched
				rotationAngle = Mathf.Lerp(0f,1f, bMoveForce);
			   	//dialMovement.rotation = bMoveForce/2.5; 
			   	
			   	//rotates the dial back towards 0 while keeping it within 0 to 1 range
			   	//dialRotation = new Vector3(0,0, Remap(-rotationAngle,0, 1, -151.2083f, 328.4432f));
			   	dialRotation = new Vector3(0,0, Mathf.Clamp(-rotationAngle,-151.2083f, 328.4432f));
				dialImage.transform.Rotate(dialRotation);
			}
			//otherwise, stop the speed
			else 
			  	bMoveForce = 0; 
			  	
			//moves the object
		    transform.Translate(Vector3.forward * bMoveForce * Time.deltaTime);
		    
		    //write to text the position of the object
		   	guiObject.text = "Blue Cart's Speed: " + bMoveForce + "\n" + "Acceleration: " + bAcceleration + "\n" + "MaxSpeed: " + bMaxSpeed;
	   }
	   //rotate the cube
	   if(Input.GetKey (KeyCode.V))
	   {
	   		steering = Mathf.Clamp01(turnSpeed * Time.deltaTime);
			transform.Rotate(steering * Vector3.up); 
			//transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(objectToMoveTowards.position - transform.position), ts);
	   }
	   if (Input.GetKey (KeyCode.N))
	   {
	   		steering = Mathf.Clamp01(turnSpeed * Time.deltaTime);
			transform.Rotate(-steering * Vector3.up); 
	   }
	   
}
/*function Remap(var thisValue: float, var from1:float, float to1, float from2, float to2) 
{
    return (thisValue - from1) / (to1 - from1) * (to2 - from2) + from2;
}*/
   