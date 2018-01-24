using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLogic : MonoBehaviour {

	Dictionary<string, int> connections;
	public int numConnectionsNeeded;
	public Collider north;
	public Collider northEast;
	public Collider east;
	public Collider southEast;
	public Collider south;
	public Collider southWest;
	public Collider west;
	public Collider northWest;
	
	void Start () 
	{
		connections.Add("horizontal", 0);
		connections.Add("vertical", 0);
		connections.Add("diagRight", 0);
		connections.Add("diagLeft", 0);
	}

	void OnMouseDown()
	{
		bool horizontalRow = rowAttained(west, east);
		bool verticalRow = rowAttained(north, south);
		bool diagRightRow = rowAttained(southWest, northEast);
		bool diagLeftRow = rowAttained(northWest, southEast);
		
		if(horizontalRow || verticalRow || diagRightRow || diagLeftRow)
		{
			Debug.Log("Tic-tac-toe, " + numConnectionsNeeded + " in a row!");
		}
	}

	bool rowAttained(Collider direction1, Collider direction2)
	{
		if(direction1 && direction2)
		{
			connections[direction1.tag] += 2;
		} 
		else if(direction1 || direction2)
		{
			connections[direction1.tag] += 1;
		}

		if(connections[direction1.tag] >= numConnectionsNeeded)
		{
			return true;
		}

		return false;
	}

}
