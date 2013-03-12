using UnityEngine;
using System.Collections;

public class Flicker_Right : MonoBehaviour {
	public Texture2D[] light_m = new Texture2D[2];
	private GUIStyle lightStyle = new GUIStyle();
	private float timer;
	public static bool show;
	
	void Start()
	{
		lightStyle.normal.background = light_m[0];
	}
	// Update is called once per frame
	
	void OnGUI () {
		
		if (show)
		{
			
		GUI.depth = -5;
		GUI.Label(new Rect(0,0,Screen.width,Screen.height),"",lightStyle);
		
		}
		
	
	}
	
	void Update()
	{
		timer += Time.deltaTime;
		if  (timer >= 5.0f)
		{
			Flick();
		}
	}
	
	void Flick()
	{
		lightStyle.normal.background = light_m[Random.Range(0,2)];
		timer = Random.Range(4.6f,4.9f);
	}
}
