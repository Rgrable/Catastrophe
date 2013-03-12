using UnityEngine;
using System.Collections;

public class Block : MonoBehaviour {
	public GUIStyle blockage = new GUIStyle();
	public static bool show;
	
	// Update is called once per frame
	void OnGUI () {
		
		if (show)
		{
			GUI.depth = -4;
			GUI.Label(new Rect(0,0,Screen.width,Screen.height),"",blockage);
		}
	
	}
}
