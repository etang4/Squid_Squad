#pragma strict
 
import UnityEngine;

private var prefab: Transform; 
private var placedItem: Transform; 
private var hit : RaycastHit; //gets the target of where the ray hits

var gos: GameObject[];

function Start()
{
	
	
}
function Update ()
{	
	gos = GameObject.FindGameObjectsWithTag(PlayerPrefs.GetString("CartCharacter"));
	Selection.objects = gos;
	
	prefab = Selection.activeTransform;
	
	//if user left-clicks, then 
	if(Input.GetButtonDown("Fire1"))
	{
		//use camera's ray to get mouse position
		var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		//works on terrain level
		var layerMask = 1 << 8; //use the 8th layer which is the terrain
		 
		//if ray hits an object that already exists, then
		if (Physics.Raycast (ray, hit, Mathf.Infinity, layerMask))
		{
			placedItem = hit.transform; //change the position of the item based on where the mouse is
		}
		//otherwise, add a new object 
		else
		{ 
			//invert layermask so we do not touch the layer
			layerMask = ~layerMask;
			
			if (Physics.Raycast (ray, hit, Mathf.Infinity, layerMask))
				placedItem = Instantiate(prefab, hit.point, Quaternion.identity);
		}
	}
	
	//once the button is released, make the placedItem null so that we can add new one if necessary
	if(Input.GetButtonUp("Fire1")) 
	{
		placedItem = null; 
	}
	
	//while button is held down for dragging
	if(Input.GetButton("Fire1")) 
	{
		//if the placeitem has something or if we are clicking on something
		if (placedItem != null)
		{
			var ray2 = Camera.main.ScreenPointToRay (Input.mousePosition);
			var hit2 : RaycastHit;
			var layerMask2 = 1 << 8;
			
			layerMask2 = ~layerMask2; //casting ray other than 8
		
			if (Physics.Raycast (ray2, hit2, Mathf.Infinity, layerMask2))
			{
				//move new object to new mouse position
				placedItem.position = hit2.point; 
			}
		}
	}
}