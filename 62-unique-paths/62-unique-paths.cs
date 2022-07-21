public class Solution {
    public int UniquePaths(int m, int n) {
        var field = new int[m,n];
        for (var row = 0; row < m; row++) {
            for (var col = 0; col < n; col++) {
                if (row == 0)
                {
                    field[row, col] = 1;
                    continue;
                }
                if (col == 0) {
                    field[row, col] = 1;
                    continue;
                }
                field[row, col] = field[row - 1, col] + field[row, col - 1];
            }
        }
        return field[m - 1, n - 1];
    }
}