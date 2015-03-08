using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class anisotropic : ScriptableObject
{
    string amount;
    public void init()
    {
        amount = QualitySettings.anisotropicFiltering.ToString();
        MainMenu menu = GameObject.Find("Main Camera").GetComponent("MainMenu") as MainMenu;
        MenuItem self = menu.findSelf(this as ScriptableObject);
        self.Name = "AF: " + amount + "d";
    }
    public void pressed()
    {
        if (QualitySettings.anisotropicFiltering == AnisotropicFiltering.Enable)
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
        else if (QualitySettings.anisotropicFiltering == AnisotropicFiltering.Disable)
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
        init();
    }
}

