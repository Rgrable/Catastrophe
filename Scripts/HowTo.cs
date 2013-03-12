using UnityEngine;
using System.Collections;

public class HowTo : MonoBehaviour {
	public bool show;
	public Texture2D[] screens = new Texture2D[7];
	public GUIStyle[] buttonStyle = new GUIStyle[3];
	private GUIStyle screenStyle = new GUIStyle();
	private int i = 0;
	public SettingsScreen settings;
	public StartMenu startscreen;
	
	void OnGUI () {
		GUI.depth = -35;
		if (show)
		{
			screenStyle.normal.background = screens[i];
			GUI.Label(new Rect(0,0,Screen.width,Screen.height),"",screenStyle);
			if (i == 0)
			{
				if (GUI.Button(new Rect(Screen.width / 2.56f,Screen.height / 1.2f,Screen.width / 12.8f,Screen.height / 7.2f),"",buttonStyle[0]))
				{
					show = false;
					settings.show = true;
				}
			}
			else if (i > 0)
			{
				if (GUI.Button(new Rect(Screen.width / 2.56f,Screen.height / 1.2f,Screen.width / 12.8f,Screen.height / 7.2f),"",buttonStyle[0]))
				{
					i -= 1;
				}
			}
			
			if (GUI.Button(new Rect(Screen.width / 2.13f,Screen.height / 1.2f,Screen.width / 12.8f,Screen.height / 7.2f),"",buttonStyle[1]))
			{
				show = false;
				i = 0;
				startscreen.show = true;
			}
			if (i < 6)
			{
				if (GUI.Button(new Rect(Screen.width / 1.82f,Screen.height / 1.2f,Screen.width / 12.8f,Screen.height / 7.2f),"",buttonStyle[2]))
				{
					i += 1;
				}
			}
			
			
		}
	
	}
}
