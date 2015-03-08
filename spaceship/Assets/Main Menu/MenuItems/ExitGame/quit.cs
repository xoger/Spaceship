using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class quit : ScriptableObject
{

    public void pressed()
    {
        Application.Quit();
    }
    public void draw()
    {
    }
}