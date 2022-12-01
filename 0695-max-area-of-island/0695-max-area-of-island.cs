public class Solution {
    public int MaxAreaOfIsland(int[][] grid) {
        var area = 0;
        for (var row = 0; row < grid.Length; row++) {
            for (var col = 0; col < grid[0].Length; col++) {
                if (grid[row][col] == 1) {
                    area = Math.Max(area, GetIslandArea(grid, row, col));
                }
            }
        }

        return area;
    }

    private static int GetIslandArea(int[][] grid, int row, int col)
    {
        if (row < 0 || row >= grid.Length || col < 0 || col >= grid[0].Length || grid[row][col] == 0)
            return 0;
        grid[row][col] = 0;
        var area = GetIslandArea(grid, row, col + 1);
        area += GetIslandArea(grid, row + 1, col);
        area += GetIslandArea(grid, row, col - 1);
        area += GetIslandArea(grid, row - 1, col);
        return area + 1;
    }
}