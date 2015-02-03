using UnityEngine;
using System.Collections;

public class Play : MonoBehaviour {



	public Camera OrthCam ;
	public Camera FPCam ;
	public Canvas canvas;

	public void OnMouseDown () {

		// changes camera from orthographic to perspective
	
		OrthCam.enabled = false ;
		FPCam.enabled = true;
		canvas.enabled = false ;
	}

}