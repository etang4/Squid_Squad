using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RaceTrack : MonoBehaviour 
{
	public Path racePath; //manually set the path from attributes

	//nextTargetNode is always changing; 
	//it is like an imaginary target node that makes sure the kart moving towards all the real nodes
	public Transform targetNode, nextTargetNode;
	public Transform currentNode;
	public int numPositionInPath = 0;

	// Use this for initialization
	void Start () 
	{
		//find the starting node of the AI path; go through each node
		for(int i = 0; i < racePath.transformNodes.Length; i++)
		{
			//if the targetNode is the one in the racetrack, then make it the current node  
			if(targetNode == racePath.transformNodes[i])
			{
				currentNode = racePath.transformNodes[i];
				numPositionInPath = i;// keep track of the index of current nodes in the path
				break;
			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		float magnitude = 0, relativeOrientation = 0;

		checkDistanceBetweenNodes (currentNode, magnitude, relativeOrientation, numPositionInPath);

		//if the kart has a relative orientation that is more than the distance between current and next target node
		//basically, if the kart has passed the current node 
		if(relativeOrientation > magnitude)
		{
			Transform potentialNextNode = racePath.transformNodes[numPositionInPath + 1];

			//checks if kart is oriented linearly to the next node
			checkDistanceBetweenNodes(potentialNextNode, magnitude, relativeOrientation, numPositionInPath + 1);

			//the kart's relative orientation is not anywhere relative or aligned to the currentnode it has passed
			//if kart is facing away from the next node
			if( relativeOrientation >= 0 )
			{
				numPositionInPath++;

				//makes sure node exists within path
				if(numPositionInPath + 1 >= racePath.transformNodes.Length) 
					numPositionInPath = 0;	

				//increment to the position of the next one
				//makes the new target node the next one in the path's list of nodes
				nextTargetNode.position = potentialNextNode.position;
			}
			//otherwise, the kart is moving aligned to the currentNode
			else
			{
				numPositionInPath++; //increment

				//set the position of the next node somewhere between the current and the next ones in the path. 
				nextTargetNode.position = (currentNode.position + racePath.transformNodes[numPositionInPath].position)/2;
			}
		}
		//if the kart is not anywhere past the current node
		else if( relativeOrientation < 0 )
		{
			Transform previousNode = racePath.transformNodes[numPositionInPath - 1];
			
			//checks if kart is oriented linearly to the next node
			checkDistanceBetweenNodes(previousNode, magnitude, relativeOrientation, numPositionInPath - 1);

			//the kart's relative orientation is not anywhere relative or aligned to the currentnode it has passed
			//kart is moving towards the current node
			if( relativeOrientation <= magnitude )
			{
				//holds back the next node the kart can arrive to
				numPositionInPath--;
				
				//checks if node is within the path
				if(numPositionInPath < 0) 
					numPositionInPath = racePath.transformNodes.Length-1;
				
				//makes sure the next target node is the current node the kart is assigned
				nextTargetNode.position = racePath.transformNodes[numPositionInPath].position;
			}
			//otherwise, if the kart is not moving towards current node, set the next target somewhere between previous and assigned nodes
			else
			{
				int oldNode = numPositionInPath-1;
				
				//checks if old node is within the path
				if(oldNode < 0) 
					oldNode = racePath.transformNodes.Length-1;
				
				nextTargetNode.position = (racePath.transformNodes[numPositionInPath].position + racePath.transformNodes[oldNode].position)/2;
			}
		}
		//else if the kart is moving towards the current node it is assigned
		else
		{
			//then makes the target node the current node it is supposedly assigned 
			nextTargetNode.position = racePath.transformNodes[numPositionInPath].position;
		}

	}

	void checkDistanceBetweenNodes(Transform currentWayPoint, float magnitude, float relativeOrientation, int index)
	{
		//checks if index is within the path's nodes
		if(index >= racePath.transformNodes.Length) 
			index = 0;

		if(index < 0) 
			index = racePath.transformNodes.Length-1;

		//get the distance between next and current node
		Vector3 distance = (nextTargetNode.position - currentWayPoint.position);
		magnitude = distance.magnitude;

		Vector3 direction = distance / magnitude;
		
		//gets the angle relative to the direction and kart's position
		relativeOrientation = Vector3.Dot(direction, transform.position - currentWayPoint.position);
	}
}
