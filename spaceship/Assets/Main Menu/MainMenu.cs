using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class MainMenu : MonoBehaviour {

	public List<List<MenuItem>> panes = new List<List<MenuItem>> ();
    public List<int> startingposs = new List<int>();
	public GUIStyle normalstyle = new GUIStyle ();
	GUIStyle hoverstyle = new GUIStyle ();
    public Rect textpos;
	int itemspacing = 25;
	Texture2D pane;
	public float Pane_Transparency;
	public float Pane_shade;
    public int pane_gap = 10;
    public GUIStyle Title = new GUIStyle();
	public List<string[]>StartingItems = new List<string[]>();
	void Start () {
        StartingItems.Add(new string[3] { "New Game", "NewPane", null });
            StartingItems.Add(new string[3] { "Name: ", "name", "New Game" });
            StartingItems.Add(new string[3] { "Start", "startgame", "New Game" });
        StartingItems.Add(new string[3] { "Load Game", "DoNothing", null });
        StartingItems.Add(new string[3] { "Options", "NewPane", null });
            StartingItems.Add(new string[3] { "Graphics", "NewPane", "Options"});
                StartingItems.Add(new string[3] { "AA: ", "ailiasing", "Graphics" });
                StartingItems.Add(new string[3] { "AF: ", "anisotropic", "Graphics" });
                StartingItems.Add(new string[3] { "vsync: ", "vsync", "Graphics" });
        StartingItems.Add(new string[3] { "Exit", "NewPane", null });
            StartingItems.Add(new string[3] { "Sure?", "quit", "Exit" });
        
		AddPane (StartingItems, 0,0);

		normalstyle.normal.textColor = new Color (1, 1, 1);
		normalstyle.fontSize = 20;

		hoverstyle.normal.textColor = new Color (1, 1, 0);
		hoverstyle.fontSize = 20;
        textpos = new Rect(70, 500, 200, 20);
		pane = new Texture2D ((int)textpos.width, Screen.height);
		for (int x = 0; x < pane.width; x++) {
			for (int y = 0; y < pane.height; y++) {
				pane.SetPixel (x, y, new Color(Pane_shade,Pane_shade,Pane_shade,Pane_Transparency));
			}
		}
		pane.Apply ();
	}

	public void AddPane (List<string[]> items, int PaneIndex, int startpos)
	{
		for (int i = PaneIndex + 1; i < panes.Count; i++)
		{
			panes.RemoveAt(i);
            
            startingposs.RemoveAt(i);
            i--;
		}
		panes.Add (new List<MenuItem> ());
        startingposs.Add(startpos);
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i][2] == null)
            {
                panes[panes.Count - 1].Add(ScriptableObject.CreateInstance("MenuItem") as MenuItem);
                panes[panes.Count - 1][panes[panes.Count - 1].Count-1].init(items[i][0], items[i][1], normalstyle);
            }
        }
	}
    public MenuItem findSelf(ScriptableObject script)
    {
        for (int p = 0; p<panes.Count; p++)
            for (int i = 0; i<panes[p].Count; i++)
            {
                if (panes[p][i].Script == script)
                {
                    return panes[p][i];
                }
                
            }
        return null;
    }
    public Vector2 findpos(ScriptableObject script)
    {
        for (int p = 0; p < panes.Count; p++)
            for (int i = 0; i < panes[p].Count; i++)
            {
                if (panes[p][i].Script == script)
                {
                        return new Vector2(p, i);
                }
                
            }
        return Vector2.zero;
    }
	void Update () {
		Vector2 mousepos = new Vector2 (Input.mousePosition.x, Screen.height - Input.mousePosition.y);
		for (int p = 0; p< panes.Count; p++) {
			for (int i = 0; i < panes[p].Count; i++)
			{
				Rect temptextpos = textpos;
                temptextpos.x += (pane.width + pane_gap) * p;
                temptextpos.y += itemspacing * (i+startingposs[p]);
				if (temptextpos.Contains (mousepos) == true) {
					if (Input.GetMouseButtonDown (0) == true)
					{
						panes [p] [i].pressed ();
					}
					panes [p] [i].Style = hoverstyle;
					} 
				else
				{
					panes [p] [i].Style = normalstyle;
				}
			}
		}
	}
	void OnGUI () {
		Rect panepos = new Rect (60, 0, pane.width, pane.height);
		for (int i = 0; i < panes.Count; i++) 
		{
            panepos.Set(panepos.xMin,textpos.yMin-10+(startingposs[i]*itemspacing),pane.width, (int)textpos.height + (panes[i].Count-1) * itemspacing+20);
			GUI.DrawTexture (panepos, pane);

			panepos.x+= pane.width + pane_gap;
		}
        GUI.Label(new Rect(textpos.x, textpos.y-50,500,500), "Blast Off", Title);
		for (int p = 0; p < panes.Count; p++) 
		{
			float plusY = startingposs[p]*itemspacing;
			for (int i = 0; i < panes[p].Count; i++) {
				Rect temptextpos = textpos;
                temptextpos.x += (pane.width + pane_gap) * p;
				temptextpos.y += plusY;
				GUI.Label (temptextpos, panes [p] [i].Name, panes [p] [i].Style);
				panes[p][i].draw();
				plusY += itemspacing;
			}

		}
	}
}

