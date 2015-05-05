private var motor : CharacterMotor;

// Use this for initialization
function Awake () {
	motor = GetComponent(CharacterMotor);
}

// Update is called once per frame
function Update () {
	// Get the input vector from keyboard or analog stick
	/*
	var HorAxis = Input.GetAxis("Horizontal");
	var lWall = GameObject.Find("LeftWall");
	var rWall = GameObject.Find("RightWall");

	var ldist = Mathf.Abs(lWall.transform.position.x - this.gameObject.transform.position.x);
	var rdist = Mathf.Abs(rWall.transform.position.x - this.gameObject.transform.position.x);

	if(ldist < 5){
		HorAxis = Mathf.Min(0, HorAxis);
	}
	if(rdist < 5){
		HorAxis = Mathf.Max(0, HorAxis);
	}
	Debug.Log(ldist);
	*/
	var directionVector = new Vector3(0, 0, 30);
	
	if (directionVector != Vector3.zero) {
		// Get the length of the directon vector and then normalize it
		// Dividing by the length is cheaper than normalizing when we already have the length anyway
		var directionLength = directionVector.magnitude;
		directionVector = directionVector / directionLength;
		
		// Make sure the length is no bigger than 1
		directionLength = Mathf.Min(1, directionLength);
		
		// Make the input vector more sensitive towards the extremes and less sensitive in the middle
		// This makes it easier to control slow speeds when using analog sticks
		directionLength = directionLength * directionLength;
		
		// Multiply the normalized direction vector by the modified length
		directionVector = directionVector * directionLength;
	}
	
	// Apply the direction to the CharacterMotor
	motor.inputMoveDirection = transform.rotation * directionVector * 1000;

	motor.inputJump = Input.GetButton("Jump");
	//motor.inputJump = Input.GetKeyDown(KeyCode.UpArrow);

	var speed : float = gameObject.GetComponent.<CharacterController>().velocity.magnitude;

	if (speed < 0.5){
		GameObject.Find("SpawnPoint").GetComponent("ToggleOnOffERIC").OnTogglePushed();
		Destroy(gameObject);
	}
}

// Require a character controller to be attached to the same game object
@script RequireComponent (CharacterMotor)
@script AddComponentMenu ("Character/FPS Input Runner")
