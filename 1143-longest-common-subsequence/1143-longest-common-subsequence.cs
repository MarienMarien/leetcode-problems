public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        var m = text1.Length;
        var n = text2.Length;
        var dp = new int[m + 1,n + 1];
        for (var row = m - 1; row >= 0; row--) {
            for (var col = n - 1; col >= 0; col--) {
                if (text1[row] == text2[col]) {
                    dp[row, col] = dp[row + 1, col + 1] + 1;
                }
                else {
                    dp[row, col] = Math.Max(dp[row + 1, col], dp[row, col + 1]);
                }
            }
        }
        return dp[0, 0];
    }
}