using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public bool show;
	public GUIStyle playerStyle;
	private GUIStyle strikeStyle = new GUIStyle();
	public static bool strike;
	public Texture2D[] player = new Texture2D[3];
	public Texture2D[] striking = new Texture2D[6];
	public bool ready;
	
	void Start()
	{
		playerStyle.normal.background = player[0];
		strikeStyle.normal.background = striking[0];
		ready = true;
	}
	
	void OnGUI () {
		
		if (show)
		{
			GUI.depth = -2;
			GUI.Label(new Rect(Screen.width / 1.5f,Screen.height / 4,Screen.width/3.84f,Screen.height/1.5f),"",playerStyle);
			GUI.Label(new Rect(Screen.width / 1.5f,Screen.height / 4,Screen.width/3.84f,Screen.height/1.5f),"",strikeStyle);
			
		}
	
	}
	
	public IEnumerator Striking()
	{
		playerStyle.normal.background = player[1];
		strikeStyle.normal.background = striking[1];
		yield return new WaitForSeconds(0.03f);
		playerStyle.normal.background = player[2];
		strikeStyle.normal.background = striking[2];
		yield return new WaitForSeconds(0.03f);
		strike = true;
		yield return new WaitForSeconds(0.01f);
		strike = false;
		yield return new WaitForSeconds(0.04f);
		ready = true;
		playerStyle.normal.background = player[1];
		strikeStyle.normal.background = striking[1];
		yield return new WaitForSeconds(0.03f);
		playerStyle.normal.background = player[0];
		strikeStyle.normal.background = striking[0];
		yield return new WaitForSeconds(0.03f);
		
	}
}
