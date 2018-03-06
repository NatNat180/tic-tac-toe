using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardLogic : MonoBehaviour
{
    public int gridNum;
    public GameObject[,] grid;
    public int numActiveTilesNeeded;
    public GameObject gridtile;
    public float border;
    public string winMessage;
    public Text winText;

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
        // bool isHorizontalRow = horizRowMade(grid);
        // bool isVerticalRow = vertRowMade(grid);
        // bool isTopLeftToBottomRightRow = topLeftToBottomRightRowMade(grid);
        // bool isTopRightToBottomLeftRow = topRightToBottomLeftRowMade(grid);

        if (rowMade(grid) /*isHorizontalRow || isVerticalRow
            || isTopLeftToBottomRightRow || isTopRightToBottomLeftRow*/
           )
        {
            if (Tile.lastTileX == true)
            {
                Debug.Log("X wins!!");
                winMessage = ("X Wins!");
                winText.text = winMessage;

            }
            if (Tile.lastTileX == false)
            {
                Debug.Log("O wins!!");
                winMessage = ("O Wins!!");
                winText.text = winMessage;
            }

            // Debug.Log(" Tic-tac-toe, " + numActiveTilesNeeded + " in a row!"+ Tile.lastTileX);
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
                }else{activeXTiles = 0;}
                if (grid[i, j].tag == "isOActive")
                {
                    activeOTiles += 1;
                }else{activeOTiles = 0;}
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
                } else if (grid[j, i].tag == "isInactive") { activeXTiles = 0; }
                if (grid[j, i].tag == "isOActive")
                {
                    activeOTiles += 1;
                } else if (grid[j, i].tag == "isInactive") { activeOTiles = 0; }
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

    bool rowMade(GameObject[,] grid)
    {
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j].tag == "isXActive" || grid[i, j].tag == "isOActive")
                {
                    int activeX = grid[i, j].tag == "isXActive" ? 1 : 0;
                    int activeO = grid[i, j].tag == "isOActive" ? 1 : 0;
                    if (horizMade(grid, i, j, activeX, activeO) || vertRowMade(grid, i, j, activeX, activeO)
                    || topRightToBottomLeftRowMade(grid, i, j, activeX, activeO))
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    bool horizMade(GameObject[,] grid, int firstCoordinate, int startingPoint, int activeX, int activeO)
    {    
        int activeXTiles = activeX; 
        int activeOTiles = activeO;

        // check forward
        for (int i = startingPoint + 1; i < grid.GetLength(0); i++) 
        {
            if (grid[firstCoordinate, i].tag == "isXActive" && activeXTiles >= 1)
            {
                activeXTiles += 1;
            } 
            else if (grid[firstCoordinate, i].tag == "isOActive" && activeOTiles >= 1)
            {
                activeOTiles += 1;
            }
            else { break; }
        }

        // check backward
        for (int i = startingPoint - 1; i >= 0; i--)
        {
            if (grid[firstCoordinate, i].tag == "isXActive" && activeXTiles >= 1)
            {
                activeXTiles += 1;
            } 
            else if (grid[firstCoordinate, i].tag == "isOActive" && activeOTiles >= 1)
            {
                activeOTiles += 1;
            }
            else { break; }
        }
        if (activeXTiles >= numActiveTilesNeeded || activeOTiles >= numActiveTilesNeeded) { return true; }

        return false;
    }

    bool vertRowMade(GameObject[,] grid, int firstCoordinate, int startingPoint, int activeX, int activeO)
    {
        int activeXTiles = activeX; 
        int activeOTiles = activeO; 

        // check forward
        for (int i = firstCoordinate + 1; i < grid.GetLength(0); i++)
        {
            if (grid[i, startingPoint].tag == "isXActive" && activeXTiles >= 1)
            {
                activeXTiles += 1;
            }
            else if (grid[i, startingPoint].tag == "isOActive" && activeOTiles >= 1)
            {
                activeOTiles += 1;
            }
            else { break; }
        }

        // check backward
        for (int i = firstCoordinate - 1; i >= 0; i--)
        {
            if (grid[i, startingPoint].tag == "isXActive" && activeXTiles >= 1)
            {
                activeXTiles += 1;
            }
            else if (grid[i, startingPoint].tag == "isOActive" && activeOTiles >= 1)
            {
                activeOTiles += 1;
            }
            else { break; }
        }
        if (activeXTiles >= numActiveTilesNeeded || activeOTiles >= numActiveTilesNeeded) { return true; }

        return false;
    }

    bool topRightToBottomLeftRowMade (GameObject[,] grid, int firstCoordinate, int startingPoint, int activeX, int activeO)
    {
        int activeXTiles = activeX; 
        int activeOTiles = activeO;
        int firstCoord = firstCoordinate;
        int secondCoord = startingPoint;

        //check forward
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            firstCoord = firstCoord + 1;
            secondCoord = secondCoord - 1;
            
            if ((firstCoord >= 0 && firstCoord <= grid.GetLength(0)) 
            && (secondCoord >= 0 && secondCoord <= grid.GetLength(0)))
            {
                if (grid[firstCoord, startingPoint].tag == "isXActive" && activeXTiles >= 1)
                {
                    Debug.Log("X at " + firstCoord + ", " + secondCoord + " is active!");
                    activeXTiles += 1;
                }
                else if (grid[firstCoord, startingPoint].tag == "isOActive" && activeOTiles >= 1)
                {
                    activeOTiles += 1;
                }
                else { break; }
            }            
        }

        //check backward
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            firstCoord = firstCoord - 1;
            secondCoord = secondCoord + 1;
            
            if ((firstCoord >= 0 && firstCoord <= grid.GetLength(0)) 
            && (secondCoord >=0 && secondCoord <= grid.GetLength(0)))
            {
                if (grid[firstCoord, startingPoint].tag == "isXActive" && activeXTiles >= 1)
                {
                    Debug.Log("X at " + firstCoord + ", " + secondCoord + " is active!");
                    activeXTiles += 1;
                }
                else if (grid[firstCoord, startingPoint].tag == "isOActive" && activeOTiles >= 1)
                {
                    activeOTiles += 1;
                }
                else { break; }
            }
        }
        Debug.Log("Active tiles = " + activeXTiles);
        if (activeXTiles >= numActiveTilesNeeded || activeOTiles >= numActiveTilesNeeded) { return true; }

        return false;
    }
}