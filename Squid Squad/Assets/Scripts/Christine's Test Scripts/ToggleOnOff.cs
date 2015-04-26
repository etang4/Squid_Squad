using UnityEngine;
using System.Collections;

//a visbility switch for the GUI when play button is pressed.
public class ToggleOnOff : MonoBehaviour {

	bool visibility = true;
	public GameObject itemsPanel, visibleButton, racingGUI, scoreBoardGUI;

	public GameObject fpCamera, birdEyeCamera;

	public GameObject fPcharacter;
	Vector3 originalPosition;

	public GameObject countdown1, countdown2, countdown3, startbutton;
	float currentTimer;

	// Use this for initialization
	void Start () {
		visibleButton.SetActive (false);
		racingGUI.SetActive (false);

		fpCamera.SetActive (false);
		birdEyeCamera.SetActive (true);

		scoreBoardGUI.SetActive (false);

		countdown1.SetActive (false);
		countdown2.SetActive (false);
		countdown3.SetActive (false);
		//startbutton.SetActive (false);

		//records the fpCharacter's original position 
		//so that we can have the character start specifically where we desire
		originalPosition = fPcharacter.transform.position;

		//move fpCharacter temporarily away from the current screen
		fPcharacter.transform.position = new Vector3 (0, -15.0f, 0);

		//freeze player's position
		//fPcharacter.rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
	}

	// Update is called once per frame
	void Update () {
	}

	//when exit out of editor mode
	public void OffTogglePushed(){

		itemsPanel.SetActive(false);
		visibleButton.SetActive (true);
		racingGUI.SetActive (true);

		fpCamera.SetActive(true);
		birdEyeCamera.SetActive(false);
		scoreBoardGUI.SetActive (false);

		//countdown1.SetActive (false);
		//countdown2.SetActive (false);
		//countdown3.SetActive (false);

		//fpCharacter to the following position
		Debug.Log("Create character");
		Instantiate(fPcharacter,this.gameObject.transform.position, Quaternion.Euler(0,180,0));
	}
	public void CountdownStart()
	{
		itemsPanel.SetActive(false);
		countdown3.SetActive (true);
		startbutton.SetActive (true);

		visibleButton.SetActive (false);
		racingGUI.SetActive (false);
		
		fpCamera.SetActive(false);
		birdEyeCamera.SetActive(true);
		scoreBoardGUI.SetActive (false);

		float startTime = 0.0f;

		float timeGoing = startTime + Time.timeSinceLevelLoad;

		currentTimer = timeGoing;

		//when one second passes
		if (timeGoing%60 > currentTimer + 1) {
				countdown3.SetActive (false);
				countdown2.SetActive (true);
				countdown1.SetActive (false);

			if (timeGoing%60 > currentTimer + 2) {
						countdown3.SetActive (false);
						countdown2.SetActive (false);
						countdown1.SetActive (true);
				}
			if (timeGoing%60 > currentTimer + 3) {
						countdown3.SetActive (false);
						countdown2.SetActive (false);
						countdown1.SetActive (false);

						OffTogglePushed (); //enters a new state
				}
		}

	}
	//when enter editor's mode
	public void OnTogglePushed(){
		
		itemsPanel.SetActive(true);
		visibleButton.SetActive (false);
		racingGUI.SetActive (false);

		fpCamera.SetActive(false);
		birdEyeCamera.SetActive(true);
		scoreBoardGUI.SetActive (false);

		Debug.Log("Destroy player");

		Destroy(GameObject.FindWithTag("Player"));
		//freeze player's positionI
		//fPcharacter.rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
	}
	public void ScoreBoardOn(){
		scoreBoardGUI.SetActive (true);
		}

}
