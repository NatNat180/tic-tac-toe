using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	public static bool lastTileX;

	void Start () 
	{
		gameObject.tag = "isInactive";
	}

    void OnMouseDown()
    {
		if (gameObject.tag == "isInactive") 
		{
			if (lastTileX)
			{
				gameObject.tag = "isOActive";
				lastTileX = false;
			} 
			else
			{
				gameObject.tag = "isXActive";
				lastTileX = true;
			}
		}
		Debug.Log("Tile activated! = " + gameObject.tag);
    }
}
