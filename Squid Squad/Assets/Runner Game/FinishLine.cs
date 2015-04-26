using UnityEngine;
using System.Collections;

public class FinishLine : MonoBehaviour {

	public GameObject scoreBoardGUI;
	public GameTimer runningTimeScore; //get the timescore
	public int seconds = 0, minutes = 0;
	public UnityEngine.UI.Text str;
	float s = 0f;

	// Use this for initialization
	void Start () {
		runningTimeScore.Start ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other) {

		if(other.tag == "Player"){
			Debug.Log("Finished!");
			scoreBoardGUI.SetActive (true);
			s = 0.0f; //make FP object stop moving

			//get the stopping time for the gameobject
			//seconds = runningTimeScore.seconds;
			//minutes = runningTimeScore.minutes;

			str.text = minutes + " " + seconds;
			
		}
	}

}
