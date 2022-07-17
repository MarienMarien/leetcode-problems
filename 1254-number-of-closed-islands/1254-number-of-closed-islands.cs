public class Solution {
     private static int gridHeigh = 0;
        private static int gridLenght = 0;
        public int ClosedIsland(int[][] grid)
        {
            var isIsland = true;
            var islandCount = 0;
            gridHeigh = grid.Length;
            gridLenght = grid[0].Length;
            for (var i = 1; i < gridHeigh - 1; i++) {
                for (var j = 1; j < gridLenght - 1; j++) {
                    if (grid[i][j] == 0)
                    {
                        isIsland = HasIsland(grid, i, j, isIsland);
                        if (isIsland)
                            islandCount++;
                        isIsland = true;
                    }
                }
            }
            return islandCount;
        }

        private bool HasIsland(int[][] grid, int row, int col, bool isIsland)
        {
            if (grid[row][col] == 1)
                return true && isIsland;
            if (grid[row][col] == 2)
                return true && isIsland;
            if (grid[row][col] == 0)
                grid[row][col] = 2;
            if (row == 0 || row == gridHeigh - 1)
                return false;
            if (col == 0 || col == gridLenght - 1)
                return false;
            isIsland = HasIsland(grid, row + 1, col, isIsland);
            isIsland = HasIsland(grid, row - 1, col, isIsland);
            isIsland = HasIsland(grid, row, col + 1, isIsland);
            isIsland = HasIsland(grid, row, col - 1, isIsland);

            return isIsland;
        }
}