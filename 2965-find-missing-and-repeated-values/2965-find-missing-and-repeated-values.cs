public class Solution {
    public int[] FindMissingAndRepeatedValues(int[][] grid) {
        var answer = new int[2];
        var colsCount = grid[0].Length;
        for(var row = 0; row < grid.Length; row++)
        {
            for(var col = 0; col < grid[0].Length; col++)
            {
                var key = (Math.Abs(grid[row][col]) - 1);
                var keyRow = key / colsCount;
                var keyCol = key % colsCount;
                if(grid[keyRow][keyCol] < 0)
                {
                    answer[0] = key + 1;
                } else {
                    grid[keyRow][keyCol] = -grid[keyRow][keyCol];
                }
            }
        }

        var found = false;
        for(var row = 0; row < grid.Length; row++)
        {
            for(var col = 0; col < grid[0].Length; col++)
            {
                if(grid[row][col] > 0)
                {
                    answer[1] = row * colsCount + col + 1;
                    break;
                }
            }
            if(found)
                break;
        }

        return answer;
    }
}