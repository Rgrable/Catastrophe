using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {
	public Texture2D[] menu = new Texture2D[7];
	private GUIStyle backGround = new GUIStyle();
	public GUIStyle settings = new GUIStyle();
	public GUIStyle start = new GUIStyle();
	public GUIStyle quit = new GUIStyle();
	public GUIStyle textStyle = new GUIStyle();
	public bool show;
	public bool played;
	public PlayingField accessGame;
	public SettingsScreen accessSettings;
	private bool flicker;
	private float flicker_time;
	private Vector2 pivot = new Vector2();
	
	public GUIStyle HighScore = new GUIStyle();
	
	void Start()
	{
		show = true;
		backGround.normal.background = menu[0];
	}
	
	void OnGUI()
	{
		
		if (show)
		{
			GUI.depth = -20;
			GUI.Label(new Rect(0,0,Screen.width,Screen.height),"",backGround);
			if (GUI.Button(new Rect(Screen.width / 2.32f,0,Screen.width / 6.4f,Screen.height / 3.6f),"",start) && !played)
			{
				played = true;
				CatMissed.missed = 0;
				accessGame.Reset();
				StartCoroutine(LightSmash());
			}
			if (GUI.Button(new Rect(Screen.width / 85.3f,0,Screen.width / 17,Screen.height / 9.6f),"",quit) && !played)
			{
				Application.Quit();
			}
			
			
			if (GUI.Button(new Rect(Screen.width / 1.06f,0,Screen.width / 17,Screen.height / 9.6f),"",settings) && !played)
			{
				accessSettings.show = true;
			}
			flicker_time += Time.deltaTime;
			if (flicker_time >= 5.0f && !played)
			{
				StartCoroutine(Lighting());
				flicker_time = Random.Range(0.0f,3.0f);
			}
			GUI.Label(new Rect(Screen.width / 85.3f,Screen.height / 1.6f,Screen.width / 1.28f,Screen.height / 3.6f),"Tap the Light to Begin...",start);
			GUIUtility.RotateAroundPivot(-25,pivot);
			GUI.Label(new Rect(Screen.width / 3.68f,Screen.height / 0.81f,Screen.width / 6.4f,Screen.height / 7.2f),Score.highScore.ToString(),textStyle);
			GUI.Label(new Rect(Screen.width / 3.68f,Screen.height / 0.815f,Screen.width / 6.4f,Screen.height / 7.2f),Score.highScore.ToString(),HighScore);
			
		}
	}
	
	IEnumerator LightSmash()
	{
		backGround.normal.background = menu[2];
		yield return new WaitForSeconds(0.01f);
		backGround.normal.background = menu[3];
		yield return new WaitForSeconds(0.01f);
		backGround.normal.background = menu[4];
		yield return new WaitForSeconds(0.01f);
		backGround.normal.background = menu[5];
		yield return new WaitForSeconds(0.01f);
		backGround.normal.background = menu[6];
		yield return new WaitForSeconds(0.03f);
		show = false;
		yield return new WaitForSeconds(3);
		backGround.normal.background = menu[0];
		accessGame.show = true;
		
	}
	
	IEnumerator Lighting()
	{
		backGround.normal.background = menu[1];
		yield return new WaitForSeconds(0.03f);
		backGround.normal.background = menu[0];
	}
}
