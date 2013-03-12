using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	public Player newPlayer;
	public Texture2D[] LevelInfo = new Texture2D[11];
	private GUIStyle LevelInfoStyle = new GUIStyle();
	public GUIStyle LevelName = new GUIStyle();
	public GUIStyle[] buttonStyle = new GUIStyle[2];
	public GUIStyle[] PausebuttonStyle = new GUIStyle[2];
	public bool content;
	public static bool selected;
	public static float CurTimeScale = 1;
	
	public static float PowerBarDisplay = 0;
	public GUIStyle power_Empty;
	public GUIStyle power_Full;
	// Update is called once per frame
	void OnGUI () {
		if (newPlayer.show)
		{
			
			GUI.depth = -7;
			// Power Bar , determines how often the player can auto attack
			GUI.BeginGroup(new Rect(0,0,Screen.width,Screen.height));
				GUI.Box(new Rect(0,0,Screen.width,Screen.height),"",power_Empty);
			GUI.BeginGroup(new Rect(0,0,Screen.width,(Screen.height / 7.2f) * PowerBarDisplay));
				GUI.Box(new Rect(0,0,Screen.width,Screen.height),"",power_Full);
				GUI.EndGroup();
			GUI.EndGroup();
			if (GUI.RepeatButton(new Rect(Screen.width / 1.21f,Screen.height / 1.44f,Screen.width / 6.4f,Screen.height / 3.6f),"",buttonStyle[0]) 
				&& !Player.strike && newPlayer.ready && !selected && PowerBarDisplay <= 5)
				{
					PowerBarDisplay += 0.1f;
					newPlayer.StartCoroutine(newPlayer.Striking());
					newPlayer.ready = false;
				}
			GUI.Label(new Rect(0,0,Screen.width,Screen.height),"",LevelInfoStyle);
			if (GUI.Button(new Rect(Screen.width / 85.3f,Screen.height / 1.2f,Screen.width / 12.8f,Screen.height / 7.2f),"",buttonStyle[1]) && !selected && !Cats.CatTap)
				{
					StartCoroutine(WindowOpen());
					selected = true;
				}
			
			if (content == true)
		{
			GUI.Label(new Rect(Screen.width / 10.66f,Screen.height / 7.2f,Screen.width / 0.64f,Screen.height / 7.2f),"PAUSED",LevelName);
			if (GUI.Button(new Rect(Screen.width / 1.82f,Screen.height / 4.11f,Screen.width / 2.84f,Screen.height / 1.6f),"",PausebuttonStyle[0]))
			{
				StartCoroutine(WindowClose());
			}
			if (GUI.Button(new Rect(Screen.width / 8.53f,Screen.height / 4.11f,Screen.width / 2.84f,Screen.height / 1.6f),"",PausebuttonStyle[1]))
			{
				StartCoroutine(Quit());
			}
		}
		}	
	}
	
	void Update()
	{
		PowerBarDisplay -=  Time.deltaTime * 0.4f;
		if (PowerBarDisplay <= 2)
		{
			PowerBarDisplay = 2;
		}
		if (PowerBarDisplay >= 7)
		{
			PowerBarDisplay = 7;
		}
		
	}
	
	public IEnumerator WindowOpen()
	{
		LevelInfoStyle.normal.background = LevelInfo[0];
		yield return new WaitForSeconds(0.03f);
		LevelInfoStyle.normal.background = LevelInfo[1];
		yield return new WaitForSeconds(0.03f);
		LevelInfoStyle.normal.background = LevelInfo[2];
		yield return new WaitForSeconds(0.03f);
		LevelInfoStyle.normal.background = LevelInfo[3];
		yield return new WaitForSeconds(0.03f);
		LevelInfoStyle.normal.background = LevelInfo[4];
		yield return new WaitForSeconds(0.02f);
		LevelInfoStyle.normal.background = LevelInfo[5];
		yield return new WaitForSeconds(0.02f);
		LevelInfoStyle.normal.background = LevelInfo[6];
		yield return new WaitForSeconds(0.02f);
		LevelInfoStyle.normal.background = LevelInfo[7];
		yield return new WaitForSeconds(0.01f);
		LevelInfoStyle.normal.background = LevelInfo[8];
		yield return new WaitForSeconds(0.01f);
		LevelInfoStyle.normal.background = LevelInfo[9];
		yield return new WaitForSeconds(0.01f);
		LevelInfoStyle.normal.background = LevelInfo[10];
		yield return new WaitForSeconds(0.01f);
		content = true;
		Time.timeScale = 0;
	}
	
	public IEnumerator WindowClose()
	{
		Time.timeScale = CurTimeScale;
		LevelInfoStyle.normal.background = LevelInfo[10];
		yield return new WaitForSeconds(0.03f);
		content = false;
		LevelInfoStyle.normal.background = LevelInfo[9];
		yield return new WaitForSeconds(0.03f);
		LevelInfoStyle.normal.background = LevelInfo[8];
		yield return new WaitForSeconds(0.03f);
		LevelInfoStyle.normal.background = LevelInfo[7];
		yield return new WaitForSeconds(0.03f);
		LevelInfoStyle.normal.background = LevelInfo[6];
		yield return new WaitForSeconds(0.02f);
		LevelInfoStyle.normal.background = LevelInfo[5];
		yield return new WaitForSeconds(0.02f);
		LevelInfoStyle.normal.background = LevelInfo[4];
		yield return new WaitForSeconds(0.02f);
		LevelInfoStyle.normal.background = LevelInfo[3];
		yield return new WaitForSeconds(0.01f);
		LevelInfoStyle.normal.background = LevelInfo[2];
		yield return new WaitForSeconds(0.01f);
		LevelInfoStyle.normal.background = LevelInfo[1];
		yield return new WaitForSeconds(0.01f);
		LevelInfoStyle.normal.background = null;
		yield return new WaitForSeconds(0.15f);
		selected = false;
	}
	
	public IEnumerator Quit()
	{
		Time.timeScale = 1;
		LevelInfoStyle.normal.background = LevelInfo[10];
		yield return new WaitForSeconds(0.03f);
		content = false;
		selected = false;
		LevelInfoStyle.normal.background = LevelInfo[9];
		yield return new WaitForSeconds(0.03f);
		LevelInfoStyle.normal.background = LevelInfo[8];
		yield return new WaitForSeconds(0.03f);
		LevelInfoStyle.normal.background = LevelInfo[7];
		yield return new WaitForSeconds(0.03f);
		CatMissed.missed = 5;
		LevelInfoStyle.normal.background = LevelInfo[6];
		yield return new WaitForSeconds(0.02f);
		LevelInfoStyle.normal.background = LevelInfo[5];
		yield return new WaitForSeconds(0.02f);
		LevelInfoStyle.normal.background = LevelInfo[4];
		yield return new WaitForSeconds(0.02f);
		LevelInfoStyle.normal.background = LevelInfo[3];
		yield return new WaitForSeconds(0.01f);
		LevelInfoStyle.normal.background = LevelInfo[2];
		yield return new WaitForSeconds(0.01f);
		LevelInfoStyle.normal.background = LevelInfo[1];
		yield return new WaitForSeconds(0.01f);
		LevelInfoStyle.normal.background = null;
		yield return new WaitForSeconds(0.01f);
	}
}
