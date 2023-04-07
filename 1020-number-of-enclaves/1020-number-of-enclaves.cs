public class Solution {
    public int NumEnclaves(int[][] grid)
    {
        if(grid.Length < 3 || grid[0].Length < 3)
            return 0;
        var onesCount = 0;
        var test = 0;
        for (var row = 0; row < grid.Length; row += grid.Length - 1) {
            for (var col = 0; col < grid[0].Length; col++){
                if (grid[row][col] == 1) {
                    test += Dfs(grid, row, col);
                }
            }
        }
        for (var col = 0; col < grid[0].Length; col += grid[0].Length - 1)
        {
            for (var row = 0; row < grid.Length; row++)
            {
                if (grid[row][col] == 1)
                {
                    test += Dfs(grid, row, col);
                }
            }
        }
        for (var row = 1; row < grid.Length - 1; row++)
        {
            for (var col = 1; col < grid[0].Length - 1; col++)
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