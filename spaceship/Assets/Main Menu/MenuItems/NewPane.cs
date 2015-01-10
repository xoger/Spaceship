using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class NewPane : ScriptableObject
{
    
    public void pressed()
    {
        List<string[]> nextpane = new List<string[]>();
        MainMenu menu = GameObject.Find("Main Camera").GetComponent("MainMenu") as MainMenu;
        MenuItem self = menu.findSelf(this as ScriptableObject);
        Vector2 posision = menu.findpos(this as ScriptableObject);
        for (int i = 0; i < menu.StartingItems.Count; i++)
        {
            if (menu.StartingItems[i][2] == self.Name)
            {
                nextpane.Add(new string[3] { menu.StartingItems[i][0], menu.StartingItems[i][1], null });
            }
        }
        menu.AddPane(nextpane, (int)posision.x, (int)posision.y);
    }
}