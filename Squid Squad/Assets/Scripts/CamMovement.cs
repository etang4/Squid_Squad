using UnityEngine;
using System.Collections;

public class CamMovement : MonoBehaviour {

	public float CamSpeed = 20f;
	public bool moveDown = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void MoveCameraDown(){
		transform.Translate (0,0,-CamSpeed,Space.World);
	}

	public void MoveCameraUp(){
		transform.Translate (0,0,CamSpeed,Space.World);
	}

	public void MoveCameraLeft(){
		transform.Translate (-CamSpeed,0,0,Space.World);
	}

	public void MoveCameraRight(){
		transform.Translate (CamSpeed,0,0,Space.World);
	}

	public void AdjustCamSpeed(float value){
		CamSpeed = value;
	}
}
