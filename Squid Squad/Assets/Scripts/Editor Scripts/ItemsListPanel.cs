using UnityEngine;
using System.Collections;

public class ItemsListPanel : MonoBehaviour {

	public GameObject originalButton;
	public GameObject[] itemsList;
	public int listSize;
	public GameObject[] items;

	// Use this for initialization
	void Start () {
		
		for(int i = 0; i < listSize; i++){
			GameObject newButton = Instantiate(itemsList[i]) as GameObject;
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

	public void itemZero(){
		GameObject item0 = (GameObject) Instantiate(items[0]);
	}

	public void itemOne(){
		GameObject item1 = (GameObject) Instantiate(items[1]);
	}

	public void itemTwo(){
		GameObject item2 = (GameObject) Instantiate(items[2]);
	}

	public void itemThree(){
		GameObject item3 = (GameObject) Instantiate(items[3]);
	}

	public void itemFour(){
		GameObject item4 = (GameObject) Instantiate(items[4]);
	}

	public void itemFive(){
		GameObject item5 = (GameObject) Instantiate(items[5]);
	}

	public void itemSix(){
		GameObject item6 = (GameObject) Instantiate(items[6]);
	}

	public void itemSeven(){
		GameObject item7 = (GameObject) Instantiate(items[7]);
	}

	public void itemEight(){
		GameObject item8 = (GameObject) Instantiate(items[8]);
	}

	public void itemNine(){
		GameObject item8 = (GameObject) Instantiate(items[9]);
	}

	public void itemTen(){
		GameObject item8 = (GameObject) Instantiate(items[10]);
	}

	public void itemEleven(){
		GameObject item8 = (GameObject) Instantiate(items[11]);
	}

	public void itemTwelve(){
		GameObject item8 = (GameObject) Instantiate(items[12]);
	}

	public void itemThirteen(){
		GameObject item8 = (GameObject) Instantiate(items[13]);
	}
}
