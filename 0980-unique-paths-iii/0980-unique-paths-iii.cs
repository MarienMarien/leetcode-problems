public class Solution {
    private int _emptyCount;
    private int _pathsCount;
    private const int _passed = -2;
    private static int[][] _step = new int[][] { new int[] { 0, 1 }, new int[] { 0, -1 }, new int[] { -1, 0 }, new int[] { 1, 0 } }; 
    public int UniquePathsIII(int[][] grid) {
        var startRow = 0;
        var startCol = 0;
        for (var row = 0; row < grid.Length; row++) {
            for (var col = 0; col < grid[0].Length; col++) {
                if (grid[row][col] == 0)
                {
                    _emptyCount++;
                    continue;
                }
                if (grid[row][col] == 1) {
                    startRow = row;
                    startCol = col;
                }
            }
        }
        CountPathsDfs(grid, startRow, startCol, 0);
        return _pathsCount;
    }
    private void CountPathsDfs(int[][] grid, int currRow, int currCol, int empty)
    {
        if (currRow < 0 || currRow >= grid.Length || currCol < 0 || currCol >= grid[0].Length || grid[currRow][currCol] < 0)
            return;
        if (grid[currRow][currCol] == 2)
        {
            if(empty == _emptyCount + 1)
                _pathsCount++;
            return;
        }
        var prevCellValue = grid[currRow][currCol];
        grid[currRow][currCol] = _passed;
        for (var i = 0; i < _step.Length; i++)
        {
            CountPathsDfs(grid, currRow + _step[i][0], currCol + _step[i][1], empty + 1);
        }
        grid[currRow][currCol] = prevCellValue;
    }
}