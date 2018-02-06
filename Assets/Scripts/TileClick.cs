using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileClick : MonoBehaviour {

    void OnMouseDown()
    {
        gameObject.SetActive(true);
		Debug.Log("Tile activated! = " + gameObject.activeSelf);
    }
}
