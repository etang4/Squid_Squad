using UnityEngine;
using System.Collections;

//a visbility switch for the GUI when play button is pressed.
public class ToggleOnOff : MonoBehaviour {

	bool visibility = true;
	public GameObject itemsPanel, visibleButton, racingGUI, scoreBoardGUI;

	public GameObject fpCamera, birdEyeCamera;

	public GameObject fPcharacter;

	// Use this for initialization
	void Start () {
		visibleButton.SetActive (false);
		racingGUI.SetActive (false);

		fpCamera.SetActive (false);
		birdEyeCamera.SetActive (true);

		scoreBoardGUI.SetActive (false);

		//freeze player's position
		//fPcharacter.rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
	}

	// Update is called once per frame
	void Update () {
	}

	public void OffTogglePushed(){
		visibility = !visibility;

		itemsPanel.SetActive(visibility);
		visibleButton.SetActive (true);
		racingGUI.SetActive (true);

		fpCamera.SetActive(true);
		birdEyeCamera.SetActive(false);
		scoreBoardGUI.SetActive (false);

		//reset fpCharacter to the following position
		fPcharacter.transform.position = new Vector3 ((float)-497.5, (float)5.7, (float)198.6907);
	}

	public void OnTogglePushed(){
		visibility = !visibility;
		
		itemsPanel.SetActive(visibility);
		visibleButton.SetActive (false);
		racingGUI.SetActive (false);

		fpCamera.SetActive(false);
		birdEyeCamera.SetActive(true);
		scoreBoardGUI.SetActive (false);

		//freeze player's position
		//fPcharacter.rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
	}
	public void ScoreBoardOn(){
		scoreBoardGUI.SetActive (true);
		}
}
