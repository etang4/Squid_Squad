using UnityEngine;
using System.Collections;

public class ItemsListPanel : MonoBehaviour {

	public GameObject panel;
	public GameObject[] items;
	public int listSize;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < listSize - 1; i++){
			GameObject pane = Instantiate(panel) as GameObject;
			pane.transform.parent = this.transform;
			//set new panels to correct size
			pane.transform.localScale = new Vector3(panel.transform.localScale.x,panel.transform.localScale.y,1);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
