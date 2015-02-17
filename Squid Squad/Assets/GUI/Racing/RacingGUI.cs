using UnityEngine;
using System.Collections;

public class RacingGUI : MonoBehaviour {

	public float horizontalSpeed;
	CharacterController controller;
	Vector3 horizontalVelocity;
	Vector3 dialRotation;
	private float rotationAngle;
	public GameObject dialImage;

	// Use this for initialization
	void Start () {
		controller = GetComponent<CharacterController>();
		horizontalVelocity = controller.velocity;
	}
	
	// Update is called once per frame
	void Update () {
		horizontalVelocity = new Vector3(controller.velocity.x,0,controller.velocity.z);
		horizontalSpeed = horizontalVelocity.magnitude;
		if(controller.velocity.x >= 0 && controller.velocity.z >= 0){
			rotationAngle = -Mathf.Lerp(0,1f, horizontalSpeed);
		}else{
			rotationAngle = Mathf.Lerp(0,1f, horizontalSpeed);
		}
		Debug.Log(rotationAngle);
		dialRotation = new Vector3(0,0, rotationAngle);
		dialImage.transform.Rotate(dialRotation);
	}
}
