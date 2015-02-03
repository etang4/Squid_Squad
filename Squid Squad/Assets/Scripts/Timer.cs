using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Timer : MonoBehaviour {
	
	
	//public Camera cam;
	//public GameObject[] balls;
	public float timeLeft;
	
	public Text timerText;
	

	
	void FixedUpdate () {
		//if (counting && gameOver==false){
			timeLeft -= Time.deltaTime;
			if (timeLeft < 0) {
				timeLeft = 0;
			}
			timerText.text = "TIME LEFT : " + Mathf.RoundToInt (timeLeft);
		}


	public void GameOver()
	{
		//gameOver = true;
		//gameOverText.SetActive (true);
		//GetComponent<TapControl>().enabled =false;
		//yield return new WaitForSeconds (1.0f);
		//GetComponent<RandomSpawn>().enabled =false;
		//restartButton.SetActive (true);
		
		
	}
	
	
	
	
	
}
