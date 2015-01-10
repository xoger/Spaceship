using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class MenuItem : ScriptableObject {

	public string Name;
	public GUIStyle Style;
	public ScriptableObject Script;

	public void init(string Name, string script, GUIStyle style)
	{
		this.Name = Name;
		Style = style;
		Script = ScriptableObject.CreateInstance (script) as ScriptableObject;
        MethodInfo inish = Script.GetType().GetMethod("init");
        if (inish != null)
            inish.Invoke(Script, null);
	}

	public void pressed()
	{
		MethodInfo Press = Script.GetType ().GetMethod ("pressed");
        if (Press != null)
		    Press.Invoke(Script,null);
	}
	public void draw()
	{
		MethodInfo Draw = Script.GetType ().GetMethod ("draw");
		if (Draw != null)
			Draw.Invoke(Script,null);
	}
}