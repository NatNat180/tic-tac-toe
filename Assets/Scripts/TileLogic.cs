using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileLogic : MonoBehaviour {

	public Collider north;
	public Collider northEast;
	public Collider east;
	public Collider southEast;
	public Collider south;
	public Collider southWest;
	public Collider west;
	public Collider northWest;
	List<string> collisionList;
	bool collisionDetected;

	void Start () 
	{
		collisionList = new List<string>();
		collisionDetected = false;
	}

	void OnCollisionEnter(Collider collider)
	{
		collisionList.Add(collider.name);
		collisionDetected = true;
	}
	
	void Update () 
	{
		if(collisionDetected)
		{
			if((collisionList.Contains(north.name) && collisionList.Contains(south.name)) ||
			(collisionList.Contains(west.name) && collisionList.Contains(east.name)) ||
			(collisionList.Contains(northWest.name) && collisionList.Contains(southEast.name)) ||
			(collisionList.Contains(northEast.name) && collisionList.Contains(southWest.name)))
			{
				Debug.Log("Tic-Tac-Toe, three in a row!");
			}

			collisionDetected = false;
		}
	}
}
