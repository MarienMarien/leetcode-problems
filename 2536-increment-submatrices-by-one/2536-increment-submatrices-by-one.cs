public class Solution {
    public int[][] RangeAddQueries(int n, int[][] queries) {
        var mat = new int[n][];
        for (var r = 0; r < n; r++)
            mat[r] = new int[n];
        foreach (var q in queries) {
            for (var row = q[0]; row <= q[2]; row++) {
                for (var col = q[1]; col <= q[3]; col++)
                {
                    mat[row][col]++;
                }
            }
        }
        return mat;
    }
}