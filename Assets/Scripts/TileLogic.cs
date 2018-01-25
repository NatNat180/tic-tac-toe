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
        foreach (GameObject direction in allDirections)
        {
            direction.SetActive(true);
        }
        Debug.Log("Tile activated!");

        bool horizontalRowFound = isRowAttained(west, east);
        bool verticalRowFound = isRowAttained(north, south);
        bool diagRightRowFound = isRowAttained(southWest, northEast);
        bool diagLeftRowFound = isRowAttained(northWest, southEast);

        if (horizontalRowFound || verticalRowFound || diagRightRowFound || diagLeftRowFound)
        {
            Debug.Log("Tic-tac-toe, " + numConnectionsNeeded + " in a row!");
        }
    }

    bool isRowAttained(Collider direction1, Collider direction2)
    {
        if (direction1 && direction2)
        {
            connections[direction1.tag] += 2;
        }
        else if (direction1 || direction2)
        {
            connections[direction1.tag] += 1;
        }

        if (connections[direction1.tag] >= numConnectionsNeeded)
        {
            return true;
        }

        return false;
    }

}
