using UnityEngine;
using System.Collections;

public class QuitToMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void quitToMenu(){
		Application.LoadLevel("Title Menu");
	}
}
