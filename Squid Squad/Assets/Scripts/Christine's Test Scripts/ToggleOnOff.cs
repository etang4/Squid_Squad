using UnityEngine;
using System.Collections;

//a visbility switch for the GUI when play button is pressed.
public class ToggleOnOff : MonoBehaviour {

	bool visibility = true;
	public GameObject itemsPanel, visibleButton, racingGUI;

	public GameObject fpCamera, birdEyeCamera;

	// Use this for initialization
	void Start () {
		visibleButton.SetActive (false);
		racingGUI.SetActive (false);

		fpCamera.SetActive(false);
		birdEyeCamera.SetActive(true);
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
	}

	public void OnTogglePushed(){
		visibility = !visibility;
		
		itemsPanel.SetActive(visibility);
		visibleButton.SetActive (false);
		racingGUI.SetActive (false);

		fpCamera.SetActive(false);
		birdEyeCamera.SetActive(true);
	}
}
