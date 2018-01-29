using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour 
{
	public int gridNum;
	public GameObject[,] grid;
	public int numActiveTilesNeeded;

	void Start () 
	{
		grid = new GameObject[gridNum, gridNum];
	}
	
	/* Will add functions for vertical, diagLeft and diagRight rows later */
	void OnMouseDown () 
	{
		bool isHorizontalRow = horizRowMade(grid);

		if (isHorizontalRow)
		{
			Debug.Log("Tic-tac-toe, " + numActiveTilesNeeded + " in a row!");
		}
	}

	/* For finding a horizontal row, we only need to find (n +/- 1) * n.
	Therefore, we can simply iterate through the multi-dim array sequentially, 
	and count if all objects within a given row (i) are active. */
	bool horizRowMade(GameObject[,] grid)
	{
		for (int i = 0; i < grid.Length; i++)
		{
			int activeTiles = 0;	

			for (int j = 0; j < grid.GetLength(i); j++)
			{
				if (grid[i, j].activeSelf)
				{
					activeTiles += 1;
					
					if (activeTiles >= numActiveTilesNeeded) { return true; }
				}
			}
		}

		return false;
	}
}
