using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RacingTime : MonoBehaviour {

	public Text myText;
	float seconds = 0f;
	float minutes = 0f;
	Text timer;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		seconds += Time.deltaTime;
		if(seconds > 60){
			minutes++;
			seconds = 0;
		}
		myText.text = minutes + ":" + (int) seconds;
	}
}
