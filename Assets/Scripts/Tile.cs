using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	

	void Start () 
	{
		gameObject.tag = "isInactive";
	}

    void OnMouseDown()
    {
        gameObject.tag = "isActive";
		Debug.Log("Tile activated! = " + gameObject.activeSelf);
    }
}
