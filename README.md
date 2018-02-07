# tic-tac-toe

### Logic for rows
n = number of columns and rows
i always starts on top row

   Horizontal: i = (i + 1)
   Vertical: i = (i + n)
   topRightToBottomLeft: i = (i + (n - 1))  
   topLeftToBottomRight: i = (i + (n + 1))

- Each equation must be done 'n' amount of times 
- For the diagnal integers, we need to ensure that first iteration begins at rightmost or leftmost spot of grid

All of this assumes that the number of rows and columns (n) are the exact same, so it may not hit every use-case. 
With that assumption however, implementing these equations into functions should make the game scalable.

## Horizontal Rows
For finding a horizontal row, from the equation above, we can 
simply iterate through the multi-dimensional array sequentially, 
and count if all objects within a given row (i) are active.

## Vertical Rows
Finding vertical rows ends up being just about the same logic, 
only we swap the indexes of the array for checking an active tile.

## Top-left to Bottom-right rows
For finding a row from top-left to bottom-right, we create a loop 
that iterates through the whole array, and check the matching index of each index
for active tiles.
    
Example: for the given multi-dimensional array: {{1,2,3},{4,5,6},{7,8,9}}, 
the 0th index of the outer-loop = {1,2,3}
the 0th index of that index = 1

the 1st index of the outer-loop = {4,5,6}
the 1st index of that index = 5

the 2nd index of the outer-loop = {7,8,9}
the 2nd index of that index = 9 

Thus the result would be {{[1],2,3}, {4,[5],6}, {7,8,[9]}}, 
resembling a diagonal row from top to bottom if drawn in a grid:

- [1] 2 3
- 4 [5] 6
- 7 8 [9]

## Top-right to Bottom-left rows
For finding a row from top-right to bottom-left, a little extra work must be done...
First, we'll use a loop to iterate through the full length of the grid.
For each iteration, we want to work -backwards- starting from the last index of each iteration.
    
Example: for the given multi-dimensional array: {{1,2,3},{4,5,6},{7,8,9}}, 
    
We initialize nextIndex as (arrayLength - 1), which equals 2
    
the 0th index of the outer-loop = {1,2,3}
the nextIndex (2) of that index = 3
nextIndex = nextIndex - 1 = 1

the 1st index of the outer-loop = {4,5,6}
the nextIndex (1) of that index = 5
nextIndex = nextIndex - 1 = 0

the 2nd index of the outer-loop = {7,8,9}
the nextIndex (0) of that index = 7

Thus the result would be {{1,2,[3]}, {4,[5],6}, {[7],8,9}}, 
resembling a diagonal row from top to bottom if drawn in a grid:

- 1 2 [3]
- 4 [5] 6
- [7] 8 9
