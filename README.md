# Tic-Tac-Toe
#### Unity Project by Nathan Argall & Andrew Jeannett

### Logic for rows
The logic assumes that the number of rows and columns will be the exact same, so it may not hit every use-case. 
With that assumption however, we wanted to give the user 2 options, each of which added an extra layer of complexity:

1. the option to scale the tic tac toe grid as large or small as desired
2. the option to determine how many tiles in a row would be needed to win a game

Our approach in tackling the logic for finding 'x' in a row, given these two rules, was a brute-force one. Whenever a user clicks on a tile, that tile is considered active. From that point forward, using the rules for each specific row detailed below, the game finds which tiles are active both in "front" and "behind" the most recently clicked tile (all tiles previously clicked on with the same type 'X' or 'O' are considered active as well). If the game finds the number of active tiles it needs for a win, the game is over.

## Horizontal Rows
For finding a horizontal row, we can 
simply iterate through the multi-dimensional array sequentially from the first active tile, 
and count if all objects within a given row (i) are active both backwards and forwards.

### Example (checking forward): 
Assuming grid[0,0] was selected for the given multi-dimensional array: {{1,2,3},{4,5,6},{7,8,9}}, 
- the 0th index of i = {1,2,3}
- the 0th index of that index = 1

- the 0th index of i = {1,2,3}
- the 1st index of that index = 2

- the 0th index of i = {1,2,3}
- the 2nd index of that index = 3 

Thus the result would be {{[1],[2],[3]}, {4,5,6}, {7,8,9}}, 
resembling a horizontal row from left to right if drawn in a grid:

- [1] [2] [3]
- 4 5 6
- 7 8 9

## Vertical Rows
Finding vertical rows ends up being just about the same logic, 
only we swap the indexes of the array for checking an active tile.

### Example (checking forward): 
Assuming grid[0,0] was selected for the given multi-dimensional array: {{1,2,3},{4,5,6},{7,8,9}}
- the 0th index of i = {1,2,3}
- the 0th index of that index = 1

- the 1st index of i = {4,5,6}
- the 0th index of that index = 4

- the 2nd index of i = {7,8,9}
- the 0th index of that index = 7 

Thus the result would be {{[1],2,3}, {[4],5,6}, {[7],8,9}}, 
resembling a vertical row from top to bottom if drawn in a grid:

- [1] 2 3
- [4] 5 6
- [7] 8 9

## Top-left to Bottom-right rows
For finding a row from top-left to bottom-right, we create a loop 
that iterates through the whole array, and check the matching index of each index
for active tiles.
    
### Example: 
for the given multi-dimensional array: {{1,2,3},{4,5,6},{7,8,9}}, 
- the 0th index of the outer-loop = {1,2,3}
- the 0th index of that index = 1

- the 1st index of the outer-loop = {4,5,6}
- the 1st index of that index = 5

- the 2nd index of the outer-loop = {7,8,9}
- the 2nd index of that index = 9 

Thus the result would be {{[1],2,3}, {4,[5],6}, {7,8,[9]}}, 
resembling a diagonal row from top to bottom if drawn in a grid:

- [1] 2 3
- 4 [5] 6
- 7 8 [9]

## Top-right to Bottom-left rows
For finding a row from top-right to bottom-left, a little extra work must be done...
First, we'll use a loop to iterate through the full length of the grid.
For each iteration, we want to work -backwards- starting from the last index of each iteration.
    
### Example: 
for the given multi-dimensional array: {{1,2,3},{4,5,6},{7,8,9}}, 
    
We initialize nextIndex as (arrayLength - 1), which equals 2
    
- the 0th index of the outer-loop = {1,2,3}
- the nextIndex (2) of that index = 3
- nextIndex = nextIndex - 1 = 1

- the 1st index of the outer-loop = {4,5,6}
- the nextIndex (1) of that index = 5
- nextIndex = nextIndex - 1 = 0

- the 2nd index of the outer-loop = {7,8,9}
- the nextIndex (0) of that index = 7

Thus the result would be {{1,2,[3]}, {4,[5],6}, {[7],8,9}}, 
resembling a diagonal row from top to bottom if drawn in a grid:

- 1 2 [3]
- 4 [5] 6
- [7] 8 9
