using UnityEngine;
using System.Collections;

using UnityEngine;
using System.Collections;

public class AIDriving : MonoBehaviour {
	public Path racePath; //manually set the path from attributes
	public Transform objectToMoveTowards;
	//public float speed;
	public float turnSpeed;

	//higher acceleration
	public float rAcceleration = 13.0f;
	public float rMaxSpeed = 18.0f;
	public float rMoveForce = 1.0f;
	public float rDeceleration = 10.0f;
	
	public bool negDirection = false;
	public bool posDirection = false;
	
	public GUIText guiObject;

	void Start() 
	{  
		guiObject = GameObject.FindWithTag("GUITEXT1").guiText;
	}
	
	// Update is called once per frame
	void Update () {

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
	//	transform.Translate(Vector3.forward * rMoveForce * Time.deltaTime);
		
		//write to text the position of the object
		guiObject.text = "Red Cart's Speed: " + rMoveForce + "\n" + "Acceleration: " + rAcceleration + "\n" + "MaxSpeed: " + rMaxSpeed;

		
		//if (objectToMoveTowards.position == racePath.transformNodes [2].position || objectToMoveTowards.position == racePath.transformNodes [3].position) {
			float ts = Mathf.Clamp01 (turnSpeed * Time.deltaTime);
			transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (objectToMoveTowards.position - transform.position), ts); 
		
			float s = Mathf.Clamp01 (rMoveForce * Time.deltaTime);
			//transform.position += (objectToMoveTowards.position - transform.position).normalized * s;
			transform.position += transform.forward * s;
		//}

	}
}
