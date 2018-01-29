using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
--- Logic for rows ---
n = number of columns and rows
i always starts on top row

   Horizontal: i = (i + 1)
   Vertical: i = (i + n)
   diagRightToLeft: i = (i + (n - 1))  
   diagLeftToRight: i = (i + (n + 1))

- Each equation must be done 'n' amount of times 
- For the diagnal integers, we need to ensure that first iteration begins at rightmost or leftmost spot of grid
-----------------------
All of this assumes that the number of rows and columns (n) are the exact same so it may not hit every use-case,
but frankly, they should be the same number for a regular game (i.e. 3 x 3 and NOT 3 x 4 or something similar). 
With that assumption, implementing these equations into functions should make the game scalable.
 */
public class Example : MonoBehaviour
{
    public int gridNum;
    public GameObject[,] grid;
    public int numActiveTilesNeeded;

    void Start()
    {
        grid = new GameObject[gridNum, gridNum];
    }

    /* Will add functions for vertical, diagLeft and diagRight rows later */
    void OnMouseDown()
    {
        bool isHorizontalRow = horizRowMade(grid);

        if (isHorizontalRow)
        {
            Debug.Log("Tic-tac-toe, " + numActiveTilesNeeded + " in a row!");
        }
    }

    /* For finding a horizontal row, from the equation above, we can 
	simply iterate through the multi-dimensional array sequentially, 
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
