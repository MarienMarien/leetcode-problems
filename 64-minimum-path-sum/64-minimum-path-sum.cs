public class Solution {
    public int MinPathSum(int[][] grid) {
        var rowsCnt = grid.Length - 1;
        var colsCnt = grid[0].Length - 1;
        for (var row = grid.Length - 1; row >= 0; row--)
        {
            for (var col = grid[0].Length - 1; col >= 0; col--)
            {
                if (row == rowsCnt && col == colsCnt)
                    continue;
                if (row == rowsCnt)
                {
                    grid[row][col] += grid[row][col + 1];
                    continue;
                }
                if (col == colsCnt)
                {
                    grid[row][col] += grid[row + 1][col];
                    continue;
                }
                grid[row][col] += Math.Min(grid[row][col + 1], grid[row + 1][col]);
            }
        }
        return grid[0][0];
    }
}