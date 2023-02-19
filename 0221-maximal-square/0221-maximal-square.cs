public class Solution {
    public int MaximalSquare(char[][] matrix) {
        var m = matrix.Length;
        var n = matrix[0].Length;
        var dp = new int[m,n];
        var maxSide = 0;
        for(var row = 0; row < m; row++){
            for(var col = 0; col < n; col++){
                if(row == 0 || col == 0 || matrix[row][col] == '0'){
                    dp[row,col] = matrix[row][col] - '0';
                } else {
                    dp[row,col] = Math.Min(dp[row,col - 1], Math.Min(dp[row-1,col-1], dp[row-1,col])) + 1;
                }
                maxSide = Math.Max(maxSide, dp[row,col]);
            }
        }
        return maxSide * maxSide;
    }
}