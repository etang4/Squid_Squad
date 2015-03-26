using UnityEngine;
using System.Collections;

public class Path : MonoBehaviour {

	public Transform[] transformNodes; 
	
	void Start ()
	{
		//transformNodes = GetComponentsInChildren<Transform>();

		/*if (transformNodes == null || transformNodes.Length == 0)
			transformNodes = null;*/

		for (int i = 0; i < 18; i++) {
			transformNodes[i] = transform.GetChild (i);
				}
	}
	void Update()
	{
		transformNodes = GetComponentsInChildren<Transform>();

		if (transform.childCount == 0) {
			for (int i = 0; i < 18; i++) {
					transformNodes [i] = transform.GetChild (i);
			}
		}
	}
}
