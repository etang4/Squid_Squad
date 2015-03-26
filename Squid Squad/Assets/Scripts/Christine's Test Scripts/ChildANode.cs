using UnityEngine;
using System.Collections;

public class ChildANode : MonoBehaviour {

	public Path nodeParentObject;

	private Transform[] childNodes;

	public GameObject parentNode;
	
	private int counter  = 0;

	// Use this for initialization
	void Start () {
	
		parentNode = GameObject.FindGameObjectWithTag ("NodeList");

		childNodes = GetComponentsInChildren<Transform> ();

		counter = nodeParentObject.transformNodes.Length;

	}
	
	// Update is called once per frame
	void Update () {

		transform.parent = parentNode.transform;

		nodeParentObject.transformNodes[counter + 1] = transform;

	}
}
