public class Solution {
    public int CountNegatives(int[][] grid) {
        var count = 0;
        var row = 0;
        var col = grid[0].Length - 1;
        var rowCount = grid.Length;
        while (row < rowCount && col >= 0) {
            if (grid[row][col] < 0)
            {
                count += rowCount - row;
                col--;
            }
            else {
                row++;
            }
        }
        return count;
    }
}