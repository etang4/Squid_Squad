﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class terrain : MonoBehaviour {

	public Terrain myTerrain;
	public static bool allowTerrainMod;
	Button b;
	ColorBlock cb;
	TerrainData tData;
	int xResolution;
	int zResolution;
	float [,] heights;


	// Use this for initialization
	void Start () {
		tData = myTerrain.terrainData;
		xResolution = tData.heightmapWidth;
		zResolution = tData.heightmapHeight;
		heights = tData.GetHeights(0,0,xResolution, zResolution);
	}
	
	// Update is called once per frame
	void Update () {
		if(allowTerrainMod == true){
			if(Input.GetMouseButton(0)){
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if(Physics.Raycast(ray, out hit)){
					raiseTerrain(hit.point);
				}
			}
			if(Input.GetMouseButton(1)){
				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if(Physics.Raycast(ray, out hit)){
					lowerTerrain(hit.point);
				}
			}
		}
	}

	private void raiseTerrain(Vector3 point){
		int mouseX = (int) ((point.x/tData.size.x) * xResolution);
		int mouseZ = (int) ((point.z/tData.size.z) * zResolution);
		//brush size
		float[,] modHeights = new float[1,1];
		float y = heights[mouseX,mouseZ];
		y += 0.05f * Time.deltaTime;
		if(y > tData.size.y){
			y = tData.size.y;
		}
		modHeights[0,0] = y;
		heights[mouseX,mouseZ] = y;
		tData.SetHeights(mouseX,mouseZ, modHeights);
	}

	private void lowerTerrain(Vector3 point){
		int mouseX = (int) ((point.x/tData.size.x) * xResolution);
		int mouseZ = (int) ((point.z/tData.size.z) * zResolution);
		//brush size
		float[,] modHeights = new float[1,1];
		float y = heights[mouseX,mouseZ];
		y -= 0.05f * Time.deltaTime;
		if(y > 0.0f){
			y = 0.0f;
		}
		modHeights[0,0] = y;
		heights[mouseX,mouseZ] = y;
		tData.SetHeights(mouseX,mouseZ, modHeights);
	}

	public void toggleTerrainMod(){
		allowTerrainMod = !allowTerrainMod;
		if(allowTerrainMod == true){
			b = GameObject.Find("Editor UI/ItemPanel/GameplayScrollView/TerrainModButton").GetComponent<Button>();
			Debug.Log(b);
			cb = b.colors;
			cb.normalColor = Color.green;
			cb.highlightedColor = Color.green;
			b.colors = cb;
		}
		else{
			b = GameObject.Find("Editor UI/ItemPanel/GameplayScrollView/TerrainModButton").GetComponent<Button>();
			Debug.Log(b);
			cb = b.colors;
			cb.normalColor = Color.white;
			cb.highlightedColor = Color.white;
			b.colors = cb;
		}
		Debug.Log("TerrainMod: " + allowTerrainMod);
	}
}
