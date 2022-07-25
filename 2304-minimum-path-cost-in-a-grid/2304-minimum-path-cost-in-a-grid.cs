public class Solution {
    public int MinPathCost(int[][] grid, int[][] moveCost) {
        for (var row = grid.Length - 2; row >= 0; row--) {
            for (var col = 0; col < grid[0].Length; col++) {
                var prevRow = row + 1;
                var localMin = Int32.MaxValue;
                for (var prevCol = 0; prevCol < grid[0].Length; prevCol++) {
                    var gridVal = grid[row][col];
                    var valToCompare = grid[prevRow][prevCol] + moveCost[gridVal][prevCol];
                    localMin = Math.Min(localMin, valToCompare);
                }
                grid[row][col] += localMin;
            }
        }
        
        var res = Int32.MaxValue;
        for (var col = 0; col < grid[0].Length; col++) {
            res = Math.Min(res, grid[0][col]);
        }
        return res;
    }
}