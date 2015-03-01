using UnityEngine;
using System.Collections;

public class Path : MonoBehaviour {

	public Transform[] transformNodes; 
	
	void Start ()
	{
		transformNodes = GetComponentsInChildren<Transform>();
	}
	void Update()
	{
		
	}
}
