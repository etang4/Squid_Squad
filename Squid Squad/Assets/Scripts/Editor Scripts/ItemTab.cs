using UnityEngine;
using System.Collections;

public class ItemTab : MonoBehaviour {

	public GameObject itemTab;
	public GameObject gameplayTab;
	public GameObject chooseFPTab; //this tab will allow users to select a cart to control
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void ClickedItemTab(){
		itemTab.SetActive(true);
		gameplayTab.SetActive(false);
		chooseFPTab.SetActive(false);
	}
	
	public void ClickedGameplayTab(){
		itemTab.SetActive(false);
		gameplayTab.SetActive(true);
		chooseFPTab.SetActive(false);
	}
	
	public void ClickedChooseFPTab(){
		itemTab.SetActive(false);
		gameplayTab.SetActive(false);
		chooseFPTab.SetActive(true);
	}
}
