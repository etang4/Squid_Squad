using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour {

	// Use this for initialization
	public GameObject AIplayer;
	public GameObject[] wayPoints;
	public float speed = 30;
	private int currentWayPoint;
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// if the currentWayPoint is not more than the last waypoint
		if (currentWayPoint < wayPoints.Length) {

			// set the target to the position of the current wayPoint
			Vector3 target = wayPoints[currentWayPoint].transform.position;

			// which direction to move 
			Vector3 moveDirection = target - transform.position;



			// If the distance to the target is less than 1 then go to next waypoint
			if(moveDirection.magnitude < 1)
			{
				currentWayPoint++;
			}
			// else keep on moving
			else
			{
				float step = speed * Time.deltaTime;
				AIplayer.gameObject.transform.position = Vector3.MoveTowards(transform.position, target, step);
			}



		}


	
	}
}
