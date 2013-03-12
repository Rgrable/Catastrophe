using UnityEngine;
using System.Collections;

public class PlayingField : MonoBehaviour {
	public bool show;
	public GUIStyle Level;
	public GUIStyle ButtonStyle;
	public Player newPlayer;
	public ConveyerBelt newBelt;
	public CatCounter newCounter;
	public CatMissed newMissed;
	public PowerUps newPower;
	public GameObject[] cat = new GameObject[2];
	public GameObject bomb;
	public static float Ctimer;
	public static float Btimer;
	private float Crech = 5.0f;
	private float Brech = 20.0f;
	private float GameTimer;
	private float gameTimerOrig = 10.0f;
	private float timeTaken = 0.2f;
	public static bool Frenzy;
	
	
	void OnGUI () {
		
		if (show)
		{
			newBelt.show = true;
			newPlayer.show = true;
			newCounter.show = true;
			Flicker_Left.show = true;
			Flicker_Right.show = true;
			newMissed.show = true;
			newPower.show = true;
			Block.show = true;
			
			GUI.Label(new Rect(0,0,Screen.width,Screen.height),"",Level);
			
		}
		else
		{
			newBelt.show = false;
			newPlayer.show = false;
			newCounter.show = false;
			Flicker_Left.show = false;
			Flicker_Right.show = false;
			newMissed.show = false;
			newPower.show = false;
			Block.show = false;
		}
		
		
		
	
	}
	
	void Update()
	{
		if (show)
		{
			if (Frenzy)
			{
				Ctimer += Time.deltaTime * 3;
				Btimer += Time.deltaTime / 3;
			}
			else 
			{
				Ctimer += Time.deltaTime;
				Btimer += Time.deltaTime;
			}
			
			
			GameTimer += Time.deltaTime;
			
			if (Ctimer >= Crech)
			{
				Cat();
			}
			
			if (Btimer >= Brech)
			{
				Bomb();
			}
			
			if (GameTimer >= gameTimerOrig)
			{
				gameTimerOrig += 10.0f;
				Crech -= timeTaken;
				Brech -= timeTaken;
			}
			
			if (gameTimerOrig >= 500)
			{
				timeTaken = 0.001f;
			}
			else if (gameTimerOrig >= 200)
			{
				timeTaken = 0.01f;
			}
			
		}
	}
	
	
	public void Cat()
	{
		GameObject newCat = (GameObject)Instantiate(cat[Random.Range(0,2)]);
		newCat.transform.position = cat[0].transform.position;
		Ctimer = Random.Range(0.0f,Crech);
	}
	
	public void Bomb()
	{
			GameObject newBomb = (GameObject)Instantiate(bomb);
			newBomb.transform.position = bomb.transform.position;
			Btimer = Random.Range(0.0f,Brech);
	}
	
	public void Reset()
	{
		CatCounter.killed = 0;
		newMissed.killMarker = 50;
		BloodyRoom.cats = 0;
		timeTaken = 0.2f;
		Crech = 5.0f;
		Brech = 20.0f;
		GameTimer = 0.0f;
		gameTimerOrig = 10.0f;
		PowerUps.p_Kills = 0;
	}
}
