using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public static int highScore;
	
	
	void Awake()
	{
		highScore = PlayerPrefs.GetInt("Score");
		Debug.Log("Loaded");
	}
	
	void OnApplicationQuit()
	{
		PlayerPrefs.SetInt("Score",highScore);
		Debug.Log("Saved");
	}
	
	// Update is called once per frame
	void Update () {
		
		if (CatCounter.killed >= highScore)
		{
			highScore = CatCounter.killed;
		}
	
	}
}
