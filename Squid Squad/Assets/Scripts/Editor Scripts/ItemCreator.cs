using UnityEngine;
using System.Collections;

public class ItemCreator : MonoBehaviour {

	public GameObject item;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void itemZero(){
		GameObject item0 = (GameObject) Instantiate(item);
	}
}
