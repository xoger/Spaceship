using UnityEngine;
using System.Collections;

public class SplashScreen : MonoBehaviour {

	public Texture2D splash;
	Rect splashpos;
	void Start () 
	{
		splashpos = new Rect ((Screen.width - splash.width) / 2, (Screen.height - splash.height) / 2, Screen.width, Screen.height);
	}
	float timer = 0;
	void Update () 
	{
		timer += Time.deltaTime;
		if (timer >= 5)
						Application.LoadLevel (Application.loadedLevel + 1);
	}
	void OnGUI()
	{
		GUI.Label (splashpos, splash);
	}
}
