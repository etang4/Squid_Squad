using UnityEngine;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public bool isPaused = false;
	public float startTime;
	public float timeGoing;
	
	//for show/display times
	public int minutes, seconds;
	public string timeStr;
	
	public GameObject textTimer;
	public UnityEngine.UI.Text stringTime;

	// Use this for initialization
	public void Start () {
		startTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		DoCountUP();
	}
	void DoCountUP()
	{
		timeGoing = startTime + Time.timeSinceLevelLoad;
		
		ShowTime();
		
	}
	void ShowTime()
	{
		minutes = (int)timeGoing/60;
		seconds = (int) timeGoing%60; //what are remaining after minutes become seconds
		timeStr = minutes.ToString() + ":" + seconds.ToString("D2"); 
		
	}
}
