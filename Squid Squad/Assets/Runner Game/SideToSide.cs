using UnityEngine;
using System.Collections;

public class SideToSide : MonoBehaviour {
	GameObject lWall, rWall;
	float horAxis, ldist, rdist;
	public float speed;

	// Use this for initialization
	void Start () {
		lWall = GameObject.Find("LeftWall");
		rWall = GameObject.Find("RightWall");
		
	}
	
	// Update is called once per frame
	void Update () {
		horAxis = Input.GetAxis("Horizontal");
		Debug.Log(horAxis);

		ldist = Mathf.Abs(lWall.transform.position.x - this.gameObject.transform.position.x);
		rdist = Mathf.Abs(rWall.transform.position.x - this.gameObject.transform.position.x);

		if(ldist < 5){
			horAxis = Mathf.Min(0, horAxis);
		}
		if(rdist < 5){
			horAxis = Mathf.Max(0, horAxis);
		}

		Vector3 directionVector = new Vector3 (0,0,0);
		if(horAxis > 0){
			directionVector = new Vector3 (-1 * speed,0,0);
		}

		if(horAxis < 0){
			directionVector = new Vector3 (1 * speed,0,0);
		}

		transform.Translate(directionVector * Time.deltaTime, Space.World);
	}

	/*void OnCollision(Collision other){
		if(other.gameObject.tag == "Obstacle"){
			GameObject.Find("SpawnPoint").GetComponent<ToggleOnOffERIC>().OnTogglePushed();
			Destroy(gameObject);
		}
	}*/
}
