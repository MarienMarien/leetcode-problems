public class Solution {
    private int _guardedCount;
    private int[][] _directions = new int[][] { [0, 1], [1, 0], [0, -1], [-1, 0] };

    public int CountUnguarded(int m, int n, int[][] guards, int[][] walls)
    {
        var grid = new int[m, n];
        foreach (var guard in guards)
        {
            grid[guard[0], guard[1]] = 2;
        }

        foreach (var wall in walls)
        {
            grid[wall[0], wall[1]] = 3;
        }
        _guardedCount = guards.Length + walls.Length;

        for (var row = 0; row < m; row++)
        {
            for (var col = 0; col < n; col++)
            {
                if (grid[row, col] == 2)
                {
                    grid[row, col] = 1;
                    MarkGuardedCells(grid, row, col);
                    grid[row, col] = 2;
                }
            }
        }

        return m * n - _guardedCount;
    }

    private void MarkGuardedCells(int[,] grid, int row, int col)
    {
        foreach (var dir in _directions)
        {
            var currRow = row;
            var currCol = col;
            while (currRow >= 0 && currRow < grid.GetLength(0) && currCol >= 0 && currCol < grid.GetLength(1))
            {
                if (grid[currRow, currCol] > 1)
                    break;
                if (grid[currRow, currCol] == 0)
                {
                    grid[currRow, currCol] = 1;
                    _guardedCount++;
                }
                currRow += dir[0];
                currCol += dir[1];
            }
        }
    }
}