using UnityEngine;
using System.Collections;

public class ItemsListPanel : MonoBehaviour {

	public GameObject originalButton;
	public GameObject[] items;
	public int listSize;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < listSize - 1; i++){
			GameObject newButton = Instantiate(originalButton) as GameObject;
			newButton.transform.parent = this.transform;
			//set new panels to correct size
			Debug.Log (Screen.height);// / 15.04f
			Debug.Log(Screen.width);// / 8.33f
			//Resize image/button with screen height and screen width.
			//newButton.transform.localScale = new Vector3(originalButton.transform.localScale.x,originalButton.transform.localScale.y,1);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
