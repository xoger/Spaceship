using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	public Texture2D fullHealthBar;
	public Texture2D halfHealthBar;
	public Texture2D emptyHealthBar;

	
	Rect HealthBarPos;
	Movement move;

	int health;

	GUIStyle style = new GUIStyle();


	void Start () 
	{
		move=GameObject.Find ("player").GetComponent("Movement") as Movement;

	}
	void OnGUI()
	{

		HealthBarPos = new Rect (Screen.width-280, 100, emptyHealthBar.width, emptyHealthBar.height);
		health = move.health;

		if (health > 80)
		{
			GUI.DrawTexture(HealthBarPos,fullHealthBar);
		}

		if (health > 50 && health <80) 
		{
			GUI.DrawTexture(HealthBarPos,halfHealthBar);
				
		}

		if (health < 50) 
		{
			GUI.DrawTexture(HealthBarPos,emptyHealthBar);
				
		}

	

	}
}