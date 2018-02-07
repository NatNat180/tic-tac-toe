using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardLogic : MonoBehaviour
{
    public int gridNum;
    public GameObject[,] grid;
    public int numActiveTilesNeeded;
    public GameObject gridtile;
    public float border;

    void Start()
    {
        grid = new GameObject[gridNum, gridNum];
        for (int p = 0; p < gridNum; p++)
        {
            for (int i = 0; i < gridNum; i++)
            {
                Vector3 tilePos = new Vector3 (-gridNum / 2  + p, 0, -gridNum / 2  + i);                 
                GameObject tile = Instantiate(gridtile, tilePos, Quaternion.Euler(90, 0, 0));                 
                grid[p, i] = tile;                 
                tile.transform.localScale = Vector3.one * (1-border);
            }
        }

        Debug.Log(grid.Length + " tiles added!");
    }

    void Update()
    {
        bool isHorizontalRow = horizRowMade(grid);
        bool isVerticalRow = vertRowMade(grid);
        bool isTopLeftToBottomRightRow = topLeftToBottomRightRowMade(grid);
        bool isTopRightToBottomLeftRow = topRightToBottomLeftRowMade(grid);

        if (isHorizontalRow || isVerticalRow
            || isTopLeftToBottomRightRow || isTopRightToBottomLeftRow)
        {
            Debug.Log("Tic-tac-toe, " + numActiveTilesNeeded + " in a row!");
        }
    }

    bool horizRowMade(GameObject[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            int activeXTiles = 0; 
            int activeOTiles = 0; 
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j].tag == "isXActive")
                {
                    activeXTiles += 1;
                }
                if (grid[i, j].tag == "isOActive")
                {
                    activeOTiles += 1;
                }
            }
            if (activeXTiles >= numActiveTilesNeeded || activeOTiles >= numActiveTilesNeeded) { return true; }
        }

        return false;
    }

    bool vertRowMade(GameObject[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            int activeXTiles = 0; 
            int activeOTiles = 0; 
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[j, i].tag == "isXActive")
                {
                    activeXTiles += 1;
                }
                if (grid[j, i].tag == "isOActive")
                {
                    activeOTiles += 1;
                }
            }
            if (activeXTiles >= numActiveTilesNeeded || activeOTiles >= numActiveTilesNeeded) { return true; }
        }

        return false;
    }

    bool topLeftToBottomRightRowMade(GameObject[,] grid)
    {
        int activeXTiles = 0; 
        int activeOTiles = 0; 
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            if (grid[i, i].tag == "isXActive")
            {
                activeXTiles += 1;
            }
            if (grid[i, i].tag == "isOActive")
            {
                activeOTiles += 1;
            }
        }
        if (activeXTiles >= numActiveTilesNeeded || activeOTiles >= numActiveTilesNeeded) { return true; }

        return false;
    }

    bool topRightToBottomLeftRowMade(GameObject[,] grid)
    {
        int activeXTiles = 0; 
        int activeOTiles = 0; 
        int nextIndex = grid.GetLength(0) - 1;
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            if (grid[i, nextIndex].tag == "isXActive")
            {
                activeXTiles += 1;
            }
            if (grid[i, nextIndex].tag == "isOActive")
            {
                activeOTiles += 1;
            }
            nextIndex -= 1;
        }
        if (activeXTiles >= numActiveTilesNeeded || activeOTiles >= numActiveTilesNeeded) { return true; }

        return false;
    }
}
