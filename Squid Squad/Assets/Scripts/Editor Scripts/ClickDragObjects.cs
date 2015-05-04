using UnityEngine;
using System.Collections;

public class ClickDragObjects : MonoBehaviour {

	public GameObject character;
	private Ray screenPoint;
	private RaycastHit hit;
 	public LayerMask terrainMask;
 	private float moveSpeed;
 	float snapUnit;

 	private bool justCreated;

 	void Start(){
 		snapUnit = 5f;
 		moveSpeed = 40f;
 		justCreated = true;
 	}

 	//object auto follows the cursor
	void Update(){
		//Delete Object
		if(Input.GetMouseButtonDown(1)){
			screenPoint = Camera.main.camera.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(screenPoint, out hit, Mathf.Infinity)){
				if(hit.collider.gameObject == character){
					Destroy(character);
				}
			}
 		}
		//if object is just created, the object will follow the cursor until it is placed.
		if(justCreated){
	 		screenPoint = Camera.main.camera.ScreenPointToRay(Input.mousePosition);
	 		if(Physics.Raycast(screenPoint, out hit, Mathf.Infinity, terrainMask)){
	 			Move(hit.point);
	 		}
	 		if(Input.GetMouseButtonDown(0)){
	 			justCreated = false;
	 		}
 		}
 		//If the object is clicked on and dragged. The object will follow the cursor.
 		else{		
 			if(Input.GetMouseButtonDown(0)){
 				screenPoint = Camera.main.camera.ScreenPointToRay(Input.mousePosition);
 				if(Physics.Raycast(screenPoint, out hit, Mathf.Infinity)){
 					if(hit.collider.gameObject == character){
 						character.GetComponent<ClickDragObjects>().justCreated = true;
 					}
 				}
 			}
 		}
 	}

 	void Move(Vector3 targetPos){
 		//Allow Rotation
 		Rotate();
 		Vector3 startPosition = character.transform.position;
 		Vector3 endPosition = targetPos;
 		character.transform.position = new Vector3(((int) (endPosition.x / snapUnit))* snapUnit,((int)(endPosition.y / snapUnit))* snapUnit,((int) (endPosition.z / snapUnit))* snapUnit);
 		

 		float t = 0.0f;

 		while(t < 1.0f){
 			t += Time.deltaTime * moveSpeed;	
 		}
 	}

 	void Rotate(){
 		if(Input.GetKeyUp("r")){
 			transform.Rotate(0,90,0);
 		}
 		if(Input.GetKeyUp("e")){
 			transform.Rotate(90,0,0);
 		}
 		if(Input.GetKeyUp("w")){
 			transform.Rotate(0,0,90);
 		}
 	}
}
