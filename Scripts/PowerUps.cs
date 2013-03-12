using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour {
	public Texture2D[] p_Textures = new Texture2D[10];
	public GUIStyle[] p_Ups = new GUIStyle[5];
	public static int p_Kills;
	public float[] p_Timers = new float[5];
	public GUIStyle text;
	private bool InUse;
	public bool show;
	
	// Use this for initialization
	void Start () {
		
		p_Kills = 0;
	
	}
	
	// Update is called once per frame
	void OnGUI () {
		GUI.depth = -6;
		if (show)
		{
			Powers();
			if (GUI.Button(new Rect(Screen.width / 6.4f,Screen.height / 1.3f,Screen.width / 8.53f,Screen.height / 4.8f),"",p_Ups[0]) && !Button.selected && p_Kills >= 15)
			{
				Bombs.bombRepel = true;
				InUse = true;
				p_Kills = 0;
			}
			if (GUI.Button(new Rect(Screen.width / 3.2f,Screen.height / 1.3f,Screen.width / 8.53f,Screen.height / 4.8f),"",p_Ups[1]) && !Button.selected && p_Kills >= 30)
			{
				Cats.CatTap = true;
				Button.CurTimeScale = 0.1f;
				Time.timeScale = 0.1f;
				InUse = true;
				p_Kills = 0;
			}
			if (GUI.Button(new Rect(Screen.width / 2.13f,Screen.height / 1.3f,Screen.width / 8.53f,Screen.height / 4.8f),"",p_Ups[2]) && !Button.selected && p_Kills >= 45)
			{
				PlayingField.Frenzy = true;
				InUse = true;
				p_Kills = 0;
			}
			
			if (Bombs.bombRepel)
			{
				GUI.Label(new Rect(Screen.width / 6.4f,Screen.height / 1.2f,Screen.width / 8.53f,Screen.height / 4.8f),p_Timers[0].ToString("F0"),text);
			}
			if (Cats.CatTap)
			{
				GUI.Label(new Rect(Screen.width / 3.2f,Screen.height / 1.2f,Screen.width / 8.53f,Screen.height / 4.8f),p_Timers[1].ToString("F0"),text);
			}
			if (PlayingField.Frenzy)
			{
				GUI.Label(new Rect(600,Screen.height / 1.2f,Screen.width / 8.53f,Screen.height / 4.8f),p_Timers[2].ToString("F0"),text);
			}
			
			
		}
	
	}
	
	void Update()
	{
		if (Bombs.bombRepel)
		{
			p_Timers[0] -= Time.deltaTime;
			if (p_Timers[0] <= 0)
			{
				Bombs.bombRepel = false;
				InUse = false;
				p_Timers[0] = 30;
			}
		}
		if (Cats.CatTap)
		{
			p_Timers[1] -= Time.deltaTime * 10;

			if (p_Timers[1] <= 0)
			{
				Cats.CatTap = false;
				Button.CurTimeScale = 1;
				Time.timeScale = 1;
				InUse = false;
				p_Timers[1] = 10;
			}
		}
		if (PlayingField.Frenzy)
		{
			p_Timers[2] -= Time.deltaTime;
			
			if (p_Timers[2] <= 0)
			{
				PlayingField.Frenzy = false;
				InUse = false;
				p_Timers[2] = 20;
			}
		}
	}
	
	private void Powers()
	{
		if (p_Kills >= 15 && !InUse)
		{
			p_Ups[0].normal.background = p_Textures[5];
		}
		else
		{
			p_Ups[0].normal.background = p_Textures[0];
		}
		
		if (p_Kills >= 30 && !InUse)
		{
			p_Ups[1].normal.background = p_Textures[6];
		}
		else
		{
			p_Ups[1].normal.background = p_Textures[1];
		}
		if (p_Kills >= 45 && !InUse)
		{
			p_Ups[2].normal.background = p_Textures[7];
		}
		else
		{
			p_Ups[2].normal.background = p_Textures[2];
		}
	}
}
