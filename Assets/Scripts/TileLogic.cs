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
		horizontal();
		vertical();
		diagRight();
		diagLeft();
		
		if(horizontal().Equals(true) || vertical().Equals(true) ||
		   diagRight().Equals(true) || diagLeft().Equals(true))
		{
			Debug.Log("Tic-tac-toe, " + numConnectionsNeeded + " in a row!");
		}
	}

	bool horizontal()
	{
		if(west || east) 
		{ 
			connections["horizontal"] += 1; 
		}

		if(connections["horizontal"] >= numConnectionsNeeded)
		{
			return true;
		}

		return false;
	}

	bool vertical()
	{
		if(north || south) 
		{ 
			connections["vertical"] += 1; 
		}

		if(connections["vertical"] >= numConnectionsNeeded)
		{
			return true;
		}

		return false;
	}

	bool diagRight()
	{
		if(southWest || northEast) 
		{ 
			connections["diagRight"] += 1; 
		}

		if(connections["diagRight"] >= numConnectionsNeeded)
		{
			return true;
		}

		return false;
	}

	bool diagLeft()
	{
		if(northWest || southEast) 
		{ 
			connections["diagLeft"] += 1; 
		}

		if(connections["diagLeft"] >= numConnectionsNeeded)
		{
			return true;
		}

		return false;
	}
}
