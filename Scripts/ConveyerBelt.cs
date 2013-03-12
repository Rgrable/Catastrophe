using UnityEngine;
using System.Collections;

public class ConveyerBelt : MonoBehaviour {
	public GUIStyle conveyerBelt = new GUIStyle();
	public Texture2D[] belt_m = new Texture2D[2];
	private GUIStyle BeltStyle = new GUIStyle();
	public bool show;
	private bool belt_s;
	
	void Start()
	{
		
	}
	
	void OnGUI () {
		
		if (show)
		{
			GUI.depth = -3;
			GUI.Label(new Rect(0,0,Screen.width,Screen.height),"",conveyerBelt);
			GUI.Label(new Rect(0,0,Screen.width,Screen.height),"",BeltStyle);
			
			if (!belt_s)
			{
				StartCoroutine(BeltMove());
				belt_s = true;
			}
		}
	}
	
	IEnumerator BeltMove()
	{
		BeltStyle.normal.background = belt_m[0];
		yield return new WaitForSeconds(0.15f);
		BeltStyle.normal.background = belt_m[1];
		yield return new WaitForSeconds(0.15f);
		belt_s = false;
		
	}
}
