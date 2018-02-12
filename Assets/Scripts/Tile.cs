using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	public static bool lastTileX;
    public GameObject xObj;
    public GameObject oObj;

    void Start () 
	{
		gameObject.tag = "isInactive";
	}

    void OnMouseDown()
    {
        Vector3 piecePos= new Vector3(transform.position.x, transform.position.y + .1f, transform.position.z);
		if (gameObject.tag == "isInactive") 
		{
			if (lastTileX)
			{
				gameObject.tag = "isOActive";
				lastTileX = false;
                Instantiate(oObj, piecePos, transform.rotation);
			} 
			else
			{
				gameObject.tag = "isXActive";
				lastTileX = true;
                Instantiate(xObj, piecePos, Quaternion.Euler(90,45,0));
            }
		}
    }
}
