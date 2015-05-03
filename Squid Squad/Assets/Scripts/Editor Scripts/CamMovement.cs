using UnityEngine;
using System.Collections;

public class CamMovement : MonoBehaviour {



	public float CamSpeed = 20f;
	public bool Invert = false;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void MoveCameraDown(){
		if(!Invert){
			transform.Translate (0,0,-CamSpeed,Space.World);
		}
		else{
			transform.Translate (0,0,CamSpeed,Space.World);
		}
	}

	public void MoveCameraUp(){
		if(!Invert){
			transform.Translate (0,0,CamSpeed,Space.World);
		}
		else{
			transform.Translate (0,0,-CamSpeed,Space.World);
		}
	}

	public void MoveCameraLeft(){
		if(!Invert){
			transform.Translate (-CamSpeed,0,0,Space.World);
		}
		else{
			transform.Translate (CamSpeed,0,0,Space.World);
		}
	}

	public void MoveCameraRight(){
		if(!Invert){
			transform.Translate (CamSpeed,0,0,Space.World);
		}
		else{
			transform.Translate (-CamSpeed,0,0,Space.World);
		}
	}

	public void AdjustCamSpeed(float value){
		CamSpeed = value;
	}
}
