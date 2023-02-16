public class Solution {
    public int MinCost(int[] startPos, int[] homePos, int[] rowCosts, int[] colCosts) {
        if (startPos[0] == homePos[0] && startPos[1] == homePos[1])
            return 0;
        var minRow = Math.Min(startPos[0], homePos[0]);
        var maxRow = Math.Max(startPos[0], homePos[0]);
        var minCol = Math.Min(startPos[1], homePos[1]);
        var maxCol = Math.Max(startPos[1], homePos[1]);
        var res = 0;
        for (var row = minRow; row <= maxRow; row++) {
            res += rowCosts[row];
        }
        for (var col = minCol; col <= maxCol; col++) {
            res += colCosts[col];
        }
        return res - rowCosts[startPos[0]] - colCosts[startPos[1]];
    }
}