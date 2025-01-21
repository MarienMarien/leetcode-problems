public class Solution {
    public long GridGame(int[][] grid) {
        long row1Sum = 0;
        foreach(var el in grid[0])
            row1Sum += el;
        long row2Sum = 0;
        long robot2Gain = long.MaxValue;
        for (var i = 0; i < grid[0].Length; ++i)
        {
            row1Sum -= grid[0][i];
            robot2Gain = Math.Min(robot2Gain, Math.Max(row1Sum, row2Sum));
            row2Sum += grid[1][i];
        }

        return robot2Gain;
    }
}