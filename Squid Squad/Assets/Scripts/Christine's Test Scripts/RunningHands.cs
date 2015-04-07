using UnityEngine;
using System.Collections;
using Leap;

public class RunningHands : MonoBehaviour {

	Controller characterController;
	
	GameObject handPose;
	bool currentHandPose = false, lastHandPose = false;

	Hand currentHand = null;

	//first person movement and acceleration
	public bool negDirection = false;
	public bool posDirection = false;

	//higher acceleration
	public float rAcceleration = 13.0f;
	public float rMaxSpeed = 18.0f;
	public float rMoveForce = 1.0f;
	public float rDeceleration = 10.0f;
	
	// Use this for initialization
	void Start () {
		characterController = new Controller();
	}
	
	//allows runner to move left or right
	void MoveSideWay(Hand hand) {

		//if palm is in x direction or rather in 
		float handX = hand.PalmPosition.ToUnityScaled().x;

		Vector3 direction = Vector3.one;

		//checks for relative direction
		//if incremented the forward position, would it be greater or lesser than current?
		if(transform.position.x + 6 > transform.position.x)
		{
			posDirection = true;
		}
		else
			negDirection = true;

		//if hand is recognized as right
		if(hand.IsRight){

			//if the hand is facing in positive direction,
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
			direction = -Vector3.right;

		}
		//if hand is recognized as left
		if (hand.IsLeft) {
			
			//if the hand is facing in positive direction,
			if (posDirection) {
					//if current force is less than maxSpeed, then increase it
					if (rMoveForce < rMaxSpeed) 
							rMoveForce += rAcceleration * Time.deltaTime;
					else if (rMoveForce >= rMaxSpeed) 
							rMoveForce = rMaxSpeed;
			} else if (negDirection) {
					//if current force is less than or equal to maxSpeed
					if (rMoveForce <= rMaxSpeed) 
							rMoveForce = rMaxSpeed;
					else if (rMoveForce > rMaxSpeed) 
							rMoveForce -= rAcceleration * Time.deltaTime;
			}

			direction = Vector3.right;

		}
		//update the position of the first person character
		float s = Mathf.Clamp01 (rMoveForce * Time.deltaTime);
		//transform.position += transform.right * handX * s;
		//moves the object
		transform.Translate (direction * handX * s);

	}

	//default character's forward movement; accelerate as time goes by
	void MoveFPCharacter(Hand hand) {
		if (hand.PalmPosition.ToUnityScaled().z > 0) {
			transform.position -= Vector3.forward * 0.5f;
		}
		
		//move backward
		if (hand.PalmPosition.ToUnityScaled().z < -1.0f) {
			transform.position += Vector3.forward * 0.5f;
		}

	}

	//jumping behavior for the first person controller; 
	//if two hands are present, the character jumps.
	void Jumping(Hand hand) {
		Frame f = characterController.Frame(); //get the frames

		HandList allHands = f.Hands;

		if (allHands.Count >= 2) {
			transform.position += Vector3.up * 0.5f;
				}
	}
	// gets the hand of the user
	Hand GetHand() {
		Frame f = characterController.Frame();
		Hand theHandThatisOut = null;
		float zMax = -float.MaxValue;
		for(int i = 0; i < f.Hands.Count; ++i) {
			float palmZ = f.Hands[i].PalmPosition.ToUnityScaled().z;
			if (palmZ > zMax) {
				zMax = palmZ;
				theHandThatisOut = f.Hands[i];
			}
		}
		
		return theHandThatisOut;
	}
	void FixedUpdate () {

		Hand runnerHand = GetHand();
		currentHand = runnerHand;

		if (runnerHand != null) {
			//currentHandPose = IsHandOpen(runnerHand);
			MoveSideWay(runnerHand);
			MoveFPCharacter(runnerHand);
			Jumping (currentHand);
		}
		lastHandPose = currentHandPose;
	}

	/*void Update()
	{
		MoveSideWay(currentHand);
		Jumping (currentHand);
	}*/
}
