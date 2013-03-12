using UnityEngine;
using System.Collections;

public class CatMissed : MonoBehaviour {
	public static int missed;
	public bool show;
	private bool once;
	public PlayingField newField;
	public StartMenu newMenu;
	public Texture2D[] attempts = new Texture2D[6];
	public Texture2D[] GO_Screen = new Texture2D[6];
	private GUIStyle GOStyle = new GUIStyle();
	private GUIStyle attemptStyle = new GUIStyle();
	public static bool endAll;
	public int killMarker = 50;

	
	// Update is called once per frame
	void OnGUI () {
		GUI.depth = -10;
		if (show)
		{
			if (missed >= 5 && !once)
			{
				missed = 5;
				once = true;
				StartCoroutine(GameOver());
			}
			
			if(missed <= 0)
			{
				missed = 0;
			}
			
			attemptStyle.normal.background = attempts[missed];
			GUI.Label(new Rect(0,0,Screen.width,Screen.height),"",GOStyle);
			GUI.Label(new Rect(0,0,Screen.width,Screen.height),"",attemptStyle);
			
			if (missed >= 5)
			{
				missed = 5;
			}
			
			if (CatCounter.killed >= killMarker)
			{
				killMarker += 50;
				missed -= 1;
			}
		}
	}
	
	
	IEnumerator GameOver()
	{
		endAll = true;
		GOStyle.normal.background = GO_Screen[0];
		yield return new  WaitForSeconds(0.05f);
		GOStyle.normal.background = GO_Screen[1];
		yield return new  WaitForSeconds(0.05f);
		GOStyle.normal.background = GO_Screen[2];
		yield return new  WaitForSeconds(0.05f);
		GOStyle.normal.background = GO_Screen[3];
		yield return new  WaitForSeconds(0.05f);
		GOStyle.normal.background = GO_Screen[4];
		yield return new  WaitForSeconds(0.05f);
		GOStyle.normal.background = GO_Screen[5];
		yield return new  WaitForSeconds(3);
		newField.show = false;
		newField.Reset();
		once = false;
		endAll = false;
		missed = 0;
		GOStyle.normal.background = null;
		newMenu.played = false;
		newMenu.show = true;
		
	}

}
