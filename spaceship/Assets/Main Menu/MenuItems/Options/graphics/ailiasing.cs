using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ailiasing : ScriptableObject
{
    string amount;
    public void init()
    {
        amount = QualitySettings.antiAliasing.ToString() + "X";
        MainMenu menu = GameObject.Find("Main Camera").GetComponent("MainMenu") as MainMenu;
        MenuItem self = menu.findSelf(this as ScriptableObject);
        self.Name = "AA: " + amount;
    }
    public void pressed()
    {
        if (QualitySettings.antiAliasing == 0)
            QualitySettings.antiAliasing = 2;
        else if (QualitySettings.antiAliasing == 2)
            QualitySettings.antiAliasing = 4;
        else if (QualitySettings.antiAliasing == 4)
            QualitySettings.antiAliasing = 8;
        else if (QualitySettings.antiAliasing == 8)
            QualitySettings.antiAliasing = 0;
        init();
    }
}

