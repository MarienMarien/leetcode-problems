public class Solution {
    public int MaxCount(int m, int n, int[][] ops) {
        var minCol = m;
        var minRow = n;
        foreach (var op in ops) {
            minCol = Math.Min(minCol, op[0]);
            minRow = Math.Min(minRow, op[1]);
        }
        return minCol * minRow;
    }
}