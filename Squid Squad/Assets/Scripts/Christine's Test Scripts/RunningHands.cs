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
	public float jumpMaxHeight = 8.0f;
	public float rMoveForce = 1.0f;
	public float rDeceleration = 10.0f;
	float s = 0;

	public GameObject scoreBoardGUI;
	GameTimer runningTimeScore; //get the timescore
	public int seconds = 0, minutes = 0;
	public UnityEngine.UI.Text str;
	
	// Use this for initialization
	void Start () {
		characterController = new Controller();

		scoreBoardGUI.SetActive (false);

		runningTimeScore.Start ();
	}
	
	//allows runner to move left or right
	void MoveSideWay(Hand hand) {
		
		//if palm is in x direction or rather in 
		float handX = hand.PalmPosition.ToUnityScaled().x;
		
		Vector3 direction = Vector3.one;
		
		//checks for relative direction
		//if incremented the forward position, would it be greater or lesser than current?
		if(Vector3.Dot(transform.right, Vector3.right) > 0.0f)
		{
			posDirection = true;
		}
		else if(Vector3.Dot(transform.right, Vector3.right) < 0.0f)
			negDirection = true;
		
		//if hand is recognized as right
		if(hand.IsRight){
			
			//if the hand is facing in positive direction,
			if (posDirection)
			{
				//moves the object
				//transform.position += -Vector3.right * 0.1f;
				direction = Vector3.right;
			}
			else if (negDirection)
			{
				//moves the object
				//transform.position += Vector3.right * 0.1f;
				direction = -Vector3.right;
			}			
		}
		//if hand is recognized as left
		if (hand.IsLeft) {
			
			//if the hand is facing in positive direction,
			if (posDirection) {
				//moves the object
				//transform.position += Vector3.right * 0.1f;
				direction = -Vector3.right;
			} else if (negDirection) {
				//transform.position += -Vector3.right * 0.1f;
				direction = Vector3.right;
			}
		}
		transform.Translate (direction * 0.15f);
	}
	
	//default character's forward movement; accelerate as time goes by
	void MoveFPCharacter(Hand hand) {
		/*if (hand.PalmPosition.ToUnityScaled().z > 0) {
			transform.position -= Vector3.forward * 0.5f;
		}
		
		//move backward
		if (hand.PalmPosition.ToUnityScaled().z < -1.0f) {
			transform.position += Vector3.forward * 0.5f;
		}
		*/
		Vector3 direction = Vector3.one;

		//if controller is facing positive direction,then move forwards in that direction
		if (Vector3.Dot(transform.forward, Vector3.forward) > 0.0f) {
			direction = -Vector3.forward;
			
			//if current force is less than maxSpeed, then increase it
			if(rMoveForce < rMaxSpeed) 
				rMoveForce += rAcceleration * Time.deltaTime;
			else if (rMoveForce >= rMaxSpeed) 
				rMoveForce = rMaxSpeed;
		}
		
		//else, move backward
		else if (Vector3.Dot(transform.forward, Vector3.forward) < 0) {
			direction = Vector3.forward;
			
			//if current force is less than or equal to maxSpeed
			if(rMoveForce <= rMaxSpeed) 
				rMoveForce = rMaxSpeed;
			else if (rMoveForce > rMaxSpeed) 
				rMoveForce -= rAcceleration * Time.deltaTime;
		}
		//update the position of the first person character
		s = Mathf.Clamp01 (rMoveForce * Time.deltaTime);
		//transform.position += transform.right * handX * s;
		//moves the object
		
		//transform.position += direction * 0.5f * s;
		transform.Translate (direction * 0.8f * s);
	}
	
	//jumping behavior for the first person controller; 
	//if two hands are present, the character jumps.
	void Jumping(Hand hand) {
		Frame f = characterController.Frame(); //get the frames
		
		HandList allHands = f.Hands;
		
		if (allHands.Count >= 2) {

			//transform.position += Vector3.up * 0.15f;
			transform.Translate(Vector3.up * 1.5f);

			/*//if current force is less than or equal to maxSpeed
			if(rMoveForce <= 10) 
				rMoveForce = 10;
			else if (rMoveForce > 10) 
				rMoveForce -= rAcceleration * Time.deltaTime;

			float s = Mathf.Clamp01 (rMoveForce * Time.deltaTime);

			rigidbody.AddForce(Vector3.up * s);*/
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
		Frame f = characterController.Frame ();
		Hand runnerHand = GetHand();
		currentHand = runnerHand;
		
		HandList allHands = f.Hands;

		//currentHandPose = IsHandOpen(runnerHand);
		MoveFPCharacter(runnerHand);
		if(allHands.Count >= 2) 
			Jumping (currentHand);
		else
		{
			if(runnerHand.IsLeft || runnerHand.IsRight)
				MoveSideWay(runnerHand);
		}

		lastHandPose = currentHandPose;
	}
	
	/*void Update()
	{
		MoveFPCharacter(currentHand);
	}*/

	void OnCollisionEnter(Collision collision) {

		//if the player has collided into objects more than 3 times, then 
		if (collision.contacts.Length >= 3) {
			s = 0.0f; //make FP object stop moving

			//get the stopping time for the gameobject
			seconds = runningTimeScore.seconds;
			minutes = runningTimeScore.minutes;

			str.text = minutes + " " + seconds;
			scoreBoardGUI.SetActive (true);

				}
	}
}
