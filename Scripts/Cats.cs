using UnityEngine;
using System.Collections;

public class Cats : MonoBehaviour {
	public Texture2D cats;
	public Texture2D[] catPieces = new Texture2D[4];
	private GUIStyle catPieceStyle = new GUIStyle();
	private GUIStyle catStyle = new GUIStyle();
	public Rect catBox;
	private bool moving;
	private bool falling;
	private float x;
	private float y;
	private bool once;
	private bool locked;
	private bool death;
	private float speed;
	public static bool CatTap;
	
	void Start()
	{
		x = -10;
		y = Screen.height / 1.8f;
		moving = true;
		catStyle.normal.background = cats;
		catPieceStyle.normal.background = null;
		speed = Random.Range(Screen.width / 4.26f,Screen.width / 2.56f);
	}
	
	void Update()
	{
		if (!Button.selected)
		{
		if (moving && PlayingField.Frenzy)
			{
				x += Time.deltaTime * speed * 1.5f;
			}
		if (moving)
			{
				x += Time.deltaTime * speed;
			}	
		}
	}
	
	void OnGUI () {
		
//		if (PlayingField.Btimer >= 4.0f && x <= -10)
//		{
//			Destroy(gameObject);
//		}
		
		GUI.depth = -4;
		catBox = new Rect(x,y,Screen.width/ 7.90f,Screen.height/8.57f);
		if (CatTap)
		{
			if (GUI.Button(catBox,"",catStyle) && !death)
			{
				catStyle.normal.background = null;
				death = true;
				StartCoroutine(Flying());
				once = true;
			}
		}
		else
		{
			GUI.Label(catBox,"",catStyle);
			if (Player.strike && catBox.x >= Screen.width / 1.68f && catBox.x <= Screen.width / 1.38f && !death)
			{
				catStyle.normal.background = null;
				death = true;
				StartCoroutine(Flying());
				once = true;
			}	
		}
		
		if (catBox.x >= Screen.width / 1.28f)
		{
			falling = true;
		}
		
		
		
		if (falling)
		{
			y += Time.deltaTime * 300;
		}
		
		if (catBox.y >= Screen.height && !locked)
		{
			locked = true;
			PowerUps.p_Kills = 0;
			CatMissed.missed++;
			Destroy(gameObject);
		}
		if (catBox.x >= Screen.width && !locked)
		{
			locked = true;
			Destroy(gameObject);
		}
		
		if (once && !locked)
		{
			BloodyRoom.cats++;
			PowerUps.p_Kills++;
			CatCounter.killed++;
			locked = true;
		}
		if (death)
		{
			GUI.Label(new Rect(x - Screen.width / 2,y - Screen.height / 2,Screen.width,Screen.height),"",catPieceStyle);
			
		}
		
		if (CatMissed.endAll)
		{
			Destroy(gameObject);
		}
	}
	
	IEnumerator Flying()
	{
		catPieceStyle.normal.background = catPieces[0];
		yield return new WaitForSeconds(0.07f);
		catPieceStyle.normal.background = catPieces[1];
		yield return new WaitForSeconds(0.07f);
		catPieceStyle.normal.background = catPieces[2];
		yield return new WaitForSeconds(0.07f);
		catPieceStyle.normal.background = catPieces[3];
		yield return new WaitForSeconds(0.07f);
		Destroy(gameObject);
		
		
		
	}
}
