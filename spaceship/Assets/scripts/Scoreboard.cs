using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Scoreboard : MonoBehaviour {

    List<int> Scores = new List<int>();

    Rect scorepos;
    Font font;
    GUIStyle style = new GUIStyle();

	void Start () {



        style.fontSize = 40;
        style.normal.textColor = new Color(255, 255, 0);
        //Vector2 scorepos = style.CalcSize(new GUIContent("Score: 100"));
        scorepos = new Rect(100, 100, 100, 100);
	}
    void OnGUI()
    {
        for (int i = 0; i < Scores.Count; i++)
        {
            GUI.Label(scorepos, "Score: " + Scores[i], style);
            scorepos.y += 100;
        }
        scorepos.y = 100;
	}
}
