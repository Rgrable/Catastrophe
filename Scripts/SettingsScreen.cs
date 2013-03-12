using UnityEngine;
using System.Collections;

public class SettingsScreen : MonoBehaviour {
	public GUIStyle setting_s = new GUIStyle();
	public bool show;
	public GUIStyle[] buttons = new GUIStyle[3];
	public HowTo howToScreen;
	
	void OnGUI () {
		GUI.depth = -30;
		if (show)
		{
			GUI.Label(new Rect(0,0,Screen.width,Screen.height),"",setting_s);
			if (GUI.Button(new Rect(Screen.width / 85.3f,Screen.height / 2.4f,Screen.width / 2.13f,Screen.height / 7.2f),"Reset Data"))
			{
				Score.highScore = 0;
			}
			if (GUI.Button(new Rect(Screen.width / 85.3f, 450,Screen.width / 2.13f,Screen.height / 7.2f),"How To Play"))
			{
				howToScreen.show = true;
				show = false;
			}
			
			if (GUI.Button(new Rect(Screen.width / 85.3f,Screen.height / 1.30f,Screen.width / 8.53f,Screen.height / 4.8f),"",buttons[0]))
			{
				show = false;
			}
		}
		
		
	
	}
}
