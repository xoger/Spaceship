using UnityEngine;
using System.Collections;

public class name : ScriptableObject {

	public string player_name = "Player";
	public void draw()
	{

		MainMenu menu = GameObject.Find ("Main Camera").GetComponent ("MainMenu") as MainMenu;
		Rect textbox = new Rect ();
		if (menu.textpos != null) {
			textbox = menu.textpos;
			textbox.x += 215 + menu.normalstyle.CalcSize(new GUIContent(menu.panes[1][0].Name)).x;
		}

		player_name =  GUI.TextField(textbox, player_name, menu.normalstyle);
	}
}
