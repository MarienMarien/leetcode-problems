public class Solution {
    public int IslandPerimeter(int[][] grid) {
        var perimeter = 0;
            for (var row = 0; row < grid.Length; row++)
            {
                for (var col = 0; col < grid[0].Length; col++)
                {
                    if (grid[row][col] == 1)
                    {
                        perimeter += 4;
                        if (row > 0 && grid[row - 1][col] == 1)
                            perimeter -= 2;
                        if (col > 0 && grid[row][col - 1] == 1)
                            perimeter -= 2;
                    }
                }
            }
            return perimeter;
    }
}