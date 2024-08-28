public class Solution {
    private int[][] _direction =
    {
        [0, 1],
        [0, -1],
        [1, 0],
        [-1, 0]
    };
    public int CountSubIslands(int[][] grid1, int[][] grid2)
    {
        var subIslandsCount = 0;
        for (var row = 0; row < grid2.Length; row++)
        {
            for (var col = 0; col < grid2[0].Length; col++)
            {
                if (grid2[row][col] == 1)
                {
                    var isSubIsland = CheckSubIsland(grid1, grid2, row, col, true);
                    if (isSubIsland)
                    {
                        subIslandsCount++;
                    }
                }
            }
        }

        return subIslandsCount;
    }

    private bool CheckSubIsland(int[][] grid1, int[][] grid2, int row, int col, bool isSubIsland)
    {
        if (row < 0 || row >= grid2.Length || col < 0 || col >= grid2[0].Length || grid2[row][col] != 1)
            return isSubIsland;
        if (grid1[row][col] != 1) {
            isSubIsland = false;
        }
        grid2[row][col] = 2;

        foreach (var d in _direction)
        {
            isSubIsland = CheckSubIsland(grid1, grid2, row + d[0], col + d[1], isSubIsland);
        }

        return isSubIsland;
    }
}