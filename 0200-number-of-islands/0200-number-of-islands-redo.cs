public class Solution {
    public int NumIslands(char[][] grid) {
        var islandCount = 0;

        for(var row = 0; row < grid.Length; row++)
        {
            for(var col = 0; col < grid[0].Length; col++)
            {
                if(grid[row][col] == '1')
                {
                    MarkIsland(grid, row, col);
                    islandCount++;
                }
            }
        }

        return islandCount;
    }

    private void MarkIsland(char[][] grid, int row, int col)
    {
        if(row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length || grid[row][col] != '1')
            return;
        grid[row][col] = '2';
        MarkIsland(grid, row, col + 1);
        MarkIsland(grid, row + 1, col);
        MarkIsland(grid, row, col - 1);
        MarkIsland(grid, row - 1, col);
    }
}