using UnityEngine;
using System.Collections;

public class Bombs : MonoBehaviour {
	public Texture2D[] bombs = new Texture2D[3];
	public GUIStyle bombStyle = new GUIStyle();
	public static Rect bombBox;
	private bool moving;
	private bool falling;
	private float x;
	private float y;
	private bool once;
	private bool locked;
	private bool flash;
	private float speed;
	public static bool bombRepel = false;
	
	
	void Start()
	{
		x = -10;
		y = Screen.width / 3.41f;
		moving = true;
		bombStyle.normal.background = bombs[0];
		speed = Random.Range(Screen.width / 3.2f,Screen.width / 1.82f);
		
		
	}
	
	void Update()
	{
		if (!Button.selected)
		{
		if (moving)
			{
				x += Time.deltaTime * speed;
			}	
			
		}
		else if (bombRepel)
		{
			Destroy(gameObject);
		}
		
	}
	
	void OnGUI () {
		
		GUI.depth = -4;
		GUI.Label(bombBox,"",bombStyle);
		bombBox = new Rect(x,y,Screen.width / 12.8f,Screen.height / 7.2f);
		if (Player.strike && bombBox.x >= Screen.width / 1.6f && bombBox.x <= Screen.width / 1.46f)
		{
			bombStyle.normal.background = null;
			once = true;
		}
		
		if (bombBox.x >= Screen.width / 1.28f)
		{
			falling = true;
		}
		
		if (falling)
		{
			y += Time.deltaTime * 300;
		}
		
		if (bombBox.y >= Screen.height)
		{
			Destroy(gameObject);
		}
		
		if (once && !locked)
		{
			Explode.Splode = true;
			locked = true;
		}
		
		if (!flash && !once)
		{
			StartCoroutine(Flashing());
			flash = true;
		}
		
		if (CatMissed.endAll)
		{
			Destroy(gameObject);
		}
	}
	
	IEnumerator Flashing()
	{
		bombStyle.normal.background = bombs[0];
		yield return new WaitForSeconds(0.02f);
		bombStyle.normal.background = bombs[1];
		yield return new WaitForSeconds(0.02f);
		bombStyle.normal.background = bombs[2];
		yield return new WaitForSeconds(0.02f);
		flash = false;
	}
}
