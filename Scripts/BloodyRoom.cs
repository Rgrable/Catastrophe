using UnityEngine;
using System.Collections;

public class BloodyRoom : MonoBehaviour {
	public GUIStyle bloodStyle = new GUIStyle();
	public GUIStyle text = new GUIStyle();
	public Texture2D[] Blood = new Texture2D[11];
	public static int cats;
	public float timer = 15.0f;
	
	void Start()
	{
	}
	
	void OnGUI()
	{
		GUI.depth = -6;
		GUI.Label(new Rect(0,0,Screen.width,Screen.height),"",bloodStyle);
		int j = cats / 100;
		
		if (j >= 10)
		{
			cats = 100;
			timer -= Time.deltaTime;
		}
		if (timer <= 0)
		{
			
			if (GUI.Button(new Rect(15,550,500,100),"clean off screen"))
			{
				timer = 15.0f;
				cats = 0;
			}
		}

		bloodStyle.normal.background = Blood[j];
	}
}
