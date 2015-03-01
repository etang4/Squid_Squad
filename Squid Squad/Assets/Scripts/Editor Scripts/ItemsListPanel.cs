using UnityEngine;
using System.Collections;

public class ItemsListPanel : MonoBehaviour {

	public GameObject originalButton;
	public GameObject[] itemsList;
	public int listSize;
	//public GameObject[] items;

	// Use this for initialization
	void Start () {
		
		for(int i = 0; i < listSize - 1; i++){
			GameObject newButton = Instantiate(itemsList[i]) as GameObject;
			newButton.transform.parent = this.transform;
			//set new panels to correct size
			
			//Resize image/button with screen height and screen width.
			//newButton.transform.localScale = new Vector3(originalButton.transform.localScale.x,originalButton.transform.localScale.y,1);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*public void itemZero(){
		GameObject item0 = (GameObject) Instantiate(items[0]);
	}*/
}
