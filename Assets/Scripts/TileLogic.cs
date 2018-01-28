using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLogic : MonoBehaviour
{

    public static Dictionary<string, int> connections;
    public int numConnectionsNeeded;
    public Collider north;
    public Collider northEast;
    public Collider east;
    public Collider southEast;
    public Collider south;
    public Collider southWest;
    public Collider west;
    public Collider northWest;
    GameObject[] allDirections;

    void Start()
    {
        allDirections = new GameObject[] { north.gameObject, northEast.gameObject, 
		east.gameObject, southEast.gameObject, south.gameObject, southWest.gameObject, 
		west.gameObject, northWest.gameObject };
        foreach (GameObject direction in allDirections)
        {
            direction.SetActive(false);
        }

        connections = new Dictionary<string, int>();
        connections.Add("horizontal", 0);
        connections.Add("vertical", 0);
        connections.Add("diagRight", 0);
        connections.Add("diagLeft", 0);
    }

    void OnMouseDown()
    {
        // establishing num tiles to print upon win
        int numTiles = numConnectionsNeeded + 1;

        /* setting parent object to inactive to avoid inner collisions 
        - child objects can still be active even if parent object is not */
        gameObject.SetActive(false);

        foreach (GameObject direction in allDirections)
        {
            direction.SetActive(true);
        }
        Debug.Log("Tile activated!");

        bool rowFound = isRowAttained(connections);

        if (rowFound)
        {
            Debug.Log("Tic-tac-toe, " + numTiles + " in a row!");
        }
    }

    bool isRowAttained(Dictionary<string, int> directions)
    {
        
        foreach (KeyValuePair <string, int> direction in directions)
        {
            if (direction.Value >= numConnectionsNeeded)
            {
                Debug.Log(direction.Value + " row found!");
                return true;
            }
        }

        return false;
    }

}
