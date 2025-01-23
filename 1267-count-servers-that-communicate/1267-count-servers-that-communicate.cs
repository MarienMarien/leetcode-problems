public class Solution {
    public int CountServers(int[][] grid) {
        var m = grid.Length;
        var n = grid[0].Length;
        var countsInRows = new int[n];
        var countsInCols = new int[m];
        var totalConnected = 0;
        for (var row = 0; row < m; row++)
        {
            for (var col = 0; col < n; col++)
            {
                if (grid[row][col] == 0)
                    continue;
                countsInRows[col]++;
                countsInCols[row]++;
            }
        }

        for (var row = 0; row < m; row++)
        {
            for (var col = 0; col < n; col++)
            {
                if (grid[row][col] == 1 && (countsInRows[col] > 1 || countsInCols[row] > 1))
                    totalConnected++;
            }
        }

        return totalConnected;  
    }
}