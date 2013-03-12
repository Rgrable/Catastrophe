using UnityEngine;
using System.Collections;

public class CatCounter : MonoBehaviour {
	public static int killed;
	public string ShoutOut_m;
	public GUIStyle text = new GUIStyle();
	public GUIStyle ShoutOuts_T = new GUIStyle();
	public bool show;
	
	
	void Start () {
	
	}
	
	void OnGUI () {
		
		if (show)
		{
			GUI.depth = -7;
			GUI.Label(new Rect(Screen.width / 85.3f,Screen.height / 48,Screen.width / 1.28f,Screen.height / 3.6f),killed.ToString(),text);
			GUI.Label(new Rect(Screen.width / 85.3f,Screen.height / 7.2f,Screen.width / 1.28f,Screen.height / 3.6f),ShoutOut_m,ShoutOuts_T);
			//int i = killed / 10;
			//StartCoroutine(ShoutOut(i));
		}
		
	
	}
			
	IEnumerator ShoutOut(int shout)
	{
		switch (shout)
		{
		case 1:
			ShoutOut_m = "CAT-TACULAR!!!";
			yield break;
		}
	}
}
