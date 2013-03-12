using UnityEngine;
using System.Collections;

public class Explode : MonoBehaviour {
	public static bool Splode;
	public Texture2D[] explosion = new Texture2D[5];
	private GUIStyle explodeStyle = new GUIStyle();
	public PlayingField newField;
	public StartMenu newMenu;
	
	// Update is called once per frame
	void OnGUI () {
		GUI.depth = -10;
		if (Splode)
		{
			StartCoroutine(GameOver());
			Splode = false;
		}
		GUI.Label(new Rect(0,0,1280,720),"",explodeStyle);
	
	}
	
	IEnumerator GameOver()
	{
		explodeStyle.normal.background = explosion[0];
		yield return new WaitForSeconds(0.01f);
		explodeStyle.normal.background = explosion[1];
		yield return new WaitForSeconds(0.01f);
		explodeStyle.normal.background = explosion[2];
		yield return new WaitForSeconds(0.01f);
		explodeStyle.normal.background = explosion[3];
		yield return new WaitForSeconds(0.01f);
		explodeStyle.normal.background = explosion[4];
		yield return new WaitForSeconds(0.01f);
		newField.show = false;
		yield return new WaitForSeconds(3.0f);
		newField.Reset();
		explodeStyle.normal.background = null;
		newMenu.played = false;
		newMenu.show = true;
		
	}
}
