using UnityEngine;
using System.Collections;

public class ItemsListPanel : MonoBehaviour {

	public GameObject originalButton;
	public GameObject[] items;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < items.Length; i++){
			GameObject newButton = Instantiate(originalButton) as GameObject;
			newButton.transform.parent = this.transform;
			
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
