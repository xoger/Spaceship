using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class vsync : ScriptableObject
{

    public void init()
    {
        MainMenu menu = GameObject.Find("Main Camera").GetComponent("MainMenu") as MainMenu;
        MenuItem self = menu.findSelf(this as ScriptableObject);
        self.Name = "vsync: ";
        if (QualitySettings.vSyncCount == 0)
            self.Name += "off";
        if (QualitySettings.vSyncCount == 1)
            self.Name += "on";
        if (QualitySettings.vSyncCount == 2)
            self.Name += "double buffer";
    }
    public void pressed()
    {
        if (QualitySettings.vSyncCount < 2)
            QualitySettings.vSyncCount++;
        else
            QualitySettings.vSyncCount = 0;
        init();
    }
}