using UnityEngine;
using System.Collections;
using Leap;

public class RunnerHands : MonoBehaviour {
	
	Controller characterController;

	GameObject handPose;
	bool currentHandPose = false, lastHandPose = false;
	
	// Use this for initialization
	void Start () {
		characterController = new Controller();
	}

	/***********************************adapted code!***********************************/
	// gets the hand that is facing sideway to the screen).
	Hand GetSideFacingHand() {
		
		Frame f = characterController.Frame();
		Hand sidewayHand = null;
		
		//forward axis; the furtherest the hand can stick out over the leap motion
		float zMax = -float.MaxValue;
		
		float xMax = -float.MaxValue;
		
		//for each hand in the number of frames
		for(int i = 0; i < f.Hands.Count; ++i) {
			
			//if the hand is out then maps that to the unity's vector x.
			float palmX = f.Hands[i].PalmPosition.ToUnityScaled().x;
			
			//if palm is at side
			if (palmX > xMax) {
				xMax = palmX;
				sidewayHand = f.Hands[i];
			}
			if (palmX < xMax) {
				xMax = -palmX;
				sidewayHand = f.Hands[i];
			}
			
		}
		
		return sidewayHand;
	}
	//allows runner to move left or right
	void MoveSideWay(Hand hand) {
		float rotThreshold = 0.0f;
		
		//if palm is in x direction or rather in 
		float handX = hand.PalmPosition.ToUnityScaled().x;

		//if the hand is to the right
		if (Mathf.Abs(handX) > rotThreshold) {
			transform.position += Vector3.right * handX * 6f;
		}
		//if the hand is to the left
		if (Mathf.Abs(handX) < rotThreshold)
		{
			transform.position += Vector3.left * handX * 6f;
		}
	}
	
	void MoveFPCharacter(Hand hand) {
		if (hand.PalmPosition.ToUnityScaled().z > 0) {
			transform.position -= Vector3.forward * 0.5f;
		}

		//move backward
		if (hand.PalmPosition.ToUnityScaled().z < -1.0f) {
			transform.position += Vector3.forward * 0.5f;
		}

		/*//get palm normal
		float roll = hand.PalmNormal.Roll;

		if (roll >= 90) {
			transform.position += transform.forward * 0.5f;
		}*/
	}

	void FixedUpdate () {
		/*Hand foremostHand = GetForeMostHand();
		if (foremostHand != null) {
			currentHandPose = IsHandOpen(foremostHand);
			ProcessLook(foremostHand);
			MoveCharacter(foremostHand);
			HandCallbacks(foremostHand);
			MoveCarriedObject();
		}
		lastHandPose = currentHandPose;*/

		Hand sidewayHand = GetSideFacingHand();
		if (sidewayHand != null) {
			currentHandPose = IsHandOpen(sidewayHand);
			MoveSideWay(sidewayHand);
			MoveFPCharacter(sidewayHand);
			HandCallbacks(sidewayHand);
			MoveCarriedObject();
		}
		lastHandPose = currentHandPose;
	}



	// gets the hand furthest away from the user (closest to the screen).
	Hand GetForeMostHand() {
		//From the Leap Motion website: Each Frame object contains an instantaneous snapshot of the scene recorded by the Leap Motion controller. 
		//Hands, fingers, and tools are the basic physical entities tracked by the Leap Motion system.
		Frame f = characterController.Frame();
		Hand foremostHand = null;
		
		//forward axis; the furtherest the hand can stick out over the leap motion
		//largest possible value of the number 
		float zMax = -float.MaxValue;
		
		//for each hand in the number of frames
		for(int i = 0; i < f.Hands.Count; ++i) {
			
			//if the hand is out then maps that to the unity's vector z.
			float palmZ = f.Hands[i].PalmPosition.ToUnityScaled().z;
			
			//if palm is out
			if (palmZ > zMax) {
				zMax = palmZ;
				foremostHand = f.Hands[i];
			}
		}
		
		return foremostHand;
	}
	
	//for grabbing objects
	void OnHandOpen(Hand h) {
		handPose = null;
	}
	
	void OnHandClose(Hand h) {
		// look for an object to pick up.
		RaycastHit hit;
		if(Physics.SphereCast(new Ray(transform.position + transform.forward * 2.0f, transform.forward), 2.0f, out hit)) {
			handPose = hit.collider.gameObject;
		}
	}
	
	bool IsHandOpen(Hand h) {
		return h.Fingers.Count > 1;	
	}
	
	// processes character camera look based on hand position.
	void ProcessLook(Hand hand) {
		float rotThreshold = 0.0f;
		
		//if palm is in x direction or rather in 
		float handX = hand.PalmPosition.ToUnityScaled().x;
		
		if (Mathf.Abs(handX) > rotThreshold) {
			Camera.main.transform.RotateAround(Vector3.up, handX * 0.03f);
		}
	}
	
	void MoveCharacter(Hand hand) {
		if (hand.PalmPosition.ToUnityScaled().z > 0) {
			Camera.main.transform.position += Camera.main.transform.forward * 0.1f;
		}
		
		if (hand.PalmPosition.ToUnityScaled().z < -1.0f) {
			Camera.main.transform.position -= Camera.main.transform.forward * 0.04f;
		}
	}
	
	// Determines if any of the hand open/close functions should be called.
	void HandCallbacks(Hand h) {
		if (currentHandPose && lastHandPose == false) {
			OnHandOpen(h);
		}
		
		if (currentHandPose == false && lastHandPose == true) {
			OnHandClose(h);	
		}
	}
	
	// if we're carrying an object, perform the logic needed to move the object
	// with us as we walk (or pull it toward us if it's far away).
	void MoveCarriedObject() {
		if (handPose != null) {
			Vector3 targetPos = transform.position + new Vector3(transform.forward.x, 0, transform.forward.z) * 5.0f;
			Vector3 deltaVec = targetPos - handPose.transform.position;
			if (deltaVec.magnitude > 0.1f) {
				handPose.rigidbody.velocity = (deltaVec) * 10.0f;
			} else {
				handPose.rigidbody.velocity = Vector3.zero;
			}
		}
	}



}


