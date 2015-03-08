using UnityEngine;
using System.Collections;

public class hud : MonoBehaviour {

	public Texture2D crosshair;
	Rect crosshairpos;
	Rect healthpos;
	Rect speedpos;
	Movement move;
	Rigidbody rig;
	Font font;
	GUIStyle style = new GUIStyle();
	void Start () {
		crosshairpos = new Rect((Screen.width - crosshair.width) / 2, (Screen.height - crosshair.height) / 2,crosshair.width,crosshair.height);
		move = GameObject.Find ("player").GetComponent("Movement") as Movement;
		rig = GameObject.Find ("player").rigidbody;

		style.fontSize = 40;
		style.normal.textColor = new Color (255, 255, 0);
		Vector2 healthsize = style.CalcSize (new GUIContent ("Health: 100"));
		healthpos = new Rect (Screen.width - 30 - healthsize.x, Screen.height - 30 - healthsize.y, healthsize.x, healthsize.y);
		Vector2 speedsize = style.CalcSize (new GUIContent ("Speed: 100kph"));
		speedpos = new Rect (30, Screen.height - 30 - speedsize.y, speedsize.x, speedsize.y);
	}
	void OnGUI()
	{
		GUI.DrawTexture (crosshairpos,crosshair);

		GUI.Label(healthpos, "Health: " + move.health.ToString (),style);
		GUI.Label(speedpos, "Speed: " +(int) rig.velocity.magnitude*10 + "kph",style);
	}
}
