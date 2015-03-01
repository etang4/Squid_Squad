using UnityEngine;
using System.Collections;

public class MaterialListPanel : MonoBehaviour {

	public GameObject originalButton;
	public GameObject[] items0;
	public GameObject[] items0Prefabs;
	public int items0Size;
	public GameObject[] items1;
	public int items1Size;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void cleanList(){
		Transform currentList = GameObject.Find("Materials").transform;
		foreach(Transform child in currentList){
			Destroy(child.gameObject);
		}
	}

	public void materialListZero(){
		cleanList();
		for(int i = 0; i < items0Size; i++){
			GameObject newButton = Instantiate(items0[i]) as GameObject;
			newButton.transform.SetParent(GameObject.Find("Materials").transform);

		}
	}

	public void materialListOne(){
		cleanList();
		for(int i = 0; i < items1Size; i++){
			GameObject newButton = Instantiate(items1[i]) as GameObject;
			newButton.transform.SetParent(GameObject.Find("Materials").transform);

		}
	}

	public void item0Zero(){
		GameObject item0 = (GameObject) Instantiate(items0Prefabs[0]);
	}
}
