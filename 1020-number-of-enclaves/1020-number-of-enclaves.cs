public class Solution {
    public int NumEnclaves(int[][] grid)
    {
        if (grid.Length < 3 || grid[0].Length < 3)
            return 0;
        var onesCount = 0;
        var rows = grid.Length;
        var cols = grid[0].Length;
        for (var col = 0; col < cols; col++)
        {
            if (grid[0][col] == 1)
            {
                _ = Dfs(grid, 0, col);
            }
            if (grid[rows - 1][col] == 1)
            {
                _ = Dfs(grid, rows - 1, col);
            }
        }
        for (var row = 0; row < rows; row++)
        {
            if (grid[row][0] == 1)
            {
                _ = Dfs(grid, row, 0);
            }
            if (grid[row][cols - 1] == 1)
            {
                _ = Dfs(grid, row, cols - 1);
            }
        }
        for (var row = 1; row < rows - 1; row++)
        {
            for (var col = 1; col < cols - 1; col++)
            {
                if (grid[row][col] == 1)
                {
                    onesCount += Dfs(grid, row, col);
                }
            }
        }
        return onesCount;
    }

    private int Dfs(int[][] grid, int row, int col)
    {
        if(row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length || grid[row][col] == 0)
            return 0;
        grid[row][col] = 0;
        var count = 1;
        count += Dfs(grid, row, col + 1);
        count += Dfs(grid, row + 1, col);
        count += Dfs(grid, row, col - 1);
        count += Dfs(grid, row - 1, col);
        return count;
    }
}