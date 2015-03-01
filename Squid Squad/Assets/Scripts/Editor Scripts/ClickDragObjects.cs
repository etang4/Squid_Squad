using UnityEngine;
using System.Collections;

public class ClickDragObjects : MonoBehaviour {

	public GameObject character;
	private Ray screenPoint;
	private RaycastHit hit;
 	public LayerMask terrainMask;
 	private float moveSpeed;

 	private bool justCreated;
 	private bool released;

 	void Start(){
 		moveSpeed = 4f;
 		justCreated = true;
 		released = false;
 	}

 	//object auto follows the cursor
	void Update(){

		//if object is just created, the object will follow the cursor until it is placed.
		if(justCreated){
	 		screenPoint = Camera.main.camera.ScreenPointToRay(Input.mousePosition);
	 		if(Physics.Raycast(screenPoint, out hit, Mathf.Infinity, terrainMask)){
	 			Move(hit.point);
	 		}
	 		if(Input.GetMouseButtonDown(0)){
	 			justCreated = false;
	 			released = true;
	 		}
	 		
 		}
 		//If the object is clicked on and dragged. The object will follow the cursor.
 		if(justCreated == false){
 			if(Input.GetMouseButton(0)){
 				screenPoint = Camera.main.camera.ScreenPointToRay(Input.mousePosition);
 				if(Physics.Raycast(screenPoint, out hit, Mathf.Infinity, terrainMask)){
 					//if(character.transform.position.x >= hit.point.x ){ needs to find a way to detect instance of gameobject and move only that.
 						Move(hit.point);
 					//}
 				}
 				
 			}
 		}
 		
 		if(released == false && Input.GetKeyUp("r")){ //needs to be able to detect instance of gameobject and move only that.
 			character.transform.Rotate(0, character.transform.position.y + 90,0);
 			Debug.Log("rotate");
 		}
 	}

 	void Move(Vector3 targetPos){
 		Vector3 startPosition = character.transform.position;
 		Vector3 endPosition = targetPos;

 		float t = 0.0f;

 		while(t < 1.0f){
 			t += Time.deltaTime * moveSpeed;
 			
 			transform.position = Vector3.Lerp(startPosition, endPosition, t);
 			
 		}
 	}
}
