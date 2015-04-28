using UnityEngine;
using System.Collections;

public class MusicSelection : MonoBehaviour {

	public AudioClip music1, music2, music3, music4, music5, music6;
	public AudioSource someMusic;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*Choose Music*/
	public void ClickMusic1()
	{
		//if(someMusic.isPlaying)
		//	someMusic.Stop();
		
		someMusic.clip = music1;
		someMusic.PlayOneShot(music1);
	}
	public void ClickMusic2()
	{
		//if(someMusic.isPlaying)
		//	someMusic.Stop();
		
		someMusic.clip = music2;
		someMusic.PlayOneShot(music2);
	}
	public void ClickMusic3()
	{
		if(someMusic.isPlaying)
			someMusic.Stop();
		
		someMusic.clip = music3;
		someMusic.Play();
	}
	public void ClickMusic4()
	{
		if(someMusic.isPlaying)
			someMusic.Stop();
		
		someMusic.clip = music4;
		someMusic.Play();
	}
	public void ClickMusic5()
	{
		if(someMusic.isPlaying)
			someMusic.Stop();
		
		someMusic.clip = music5;
		someMusic.Play();
	}
	public void ClickMusic6()
	{
		if(someMusic.isPlaying)
			someMusic.Stop();
		
		someMusic.clip = music6;
		someMusic.Play();
	}

}
