using UnityEngine;
using System.Collections;

public class ItemTab : MonoBehaviour {

	public GameObject itemTab;
	public GameObject gameplayTab;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ClickedItemTab(){
		itemTab.SetActive(true);
		gameplayTab.SetActive(false);
	}

	public void ClickedGameplayTab(){
		itemTab.SetActive(false);
		gameplayTab.SetActive(true);
	}
}
