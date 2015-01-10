using UnityEngine;
using System.Collections;

public class startgame : ScriptableObject {

	public void pressed ()
	{
		Application.LoadLevel ("Main");
	}
}
