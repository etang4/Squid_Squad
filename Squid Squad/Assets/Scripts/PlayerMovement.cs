using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour {
	
	public float PlayerSpeed = 20f;
	public bool moveDown = false;
	// Use this for initialization

	// Update is called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.UpArrow))
			transform.Translate (0,0,PlayerSpeed,Space.World);
		

		if (Input.GetKey (KeyCode.DownArrow))
		{
			transform.Translate (0,0,-PlayerSpeed,Space.World);
		} 

		if (Input.GetKey (KeyCode.LeftArrow))
		{      
			transform.Translate (-PlayerSpeed,0,0,Space.World); 
		}
		
		if (Input.GetKey (KeyCode.RightArrow))
		{     
			transform.Translate (PlayerSpeed,0,0,Space.World); 
		}

		}
}
