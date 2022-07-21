public class Solution {
    public int UniquePathsWithObstacles(int[][] obstacleGrid) {
        var rows = obstacleGrid.Length;
        var cols = obstacleGrid[0].Length;
        if (obstacleGrid[rows - 1][cols - 1] == 1)
            return 0;
        for (var row = 0; row < rows; row++) { 
            for(var col = 0; col < cols; col++)
            {
                if (obstacleGrid[row][col] == 1) {
                    obstacleGrid[row][col] = -1;
                    continue;
                }
                if (row == 0) {
                    obstacleGrid[row][col] = col > 0 && obstacleGrid[row][col - 1] < 0 ? -1 : 1;
                    continue;
                }
                if (col == 0) {
                    obstacleGrid[row][col] = row > 0 && obstacleGrid[row - 1][col] < 0 ? -1 : 1;
                    continue;
                }
                var top = obstacleGrid[row - 1][col] < 0 ? 0 : obstacleGrid[row - 1][col];
                var left = obstacleGrid[row][col - 1] < 0 ? 0 : obstacleGrid[row][col - 1];
                obstacleGrid[row][col] = top + left;
            }
        }
        return obstacleGrid[rows - 1][cols - 1] < 0 ? 0 : obstacleGrid[rows - 1][cols - 1];
    }
}