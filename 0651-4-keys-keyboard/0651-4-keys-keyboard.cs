public class Solution {
    public int MaxA(int n) {
        var dp = new int[n + 1];
        for (var i = 0; i <= n; i++) {
            dp[i] = i;
        }
        for (var i = 0; i <= n - 3; i++) {
            for (var j = i + 3; j <= Math.Min(n, i + 6); j++)
            {
                dp[j] = Math.Max(dp[j], (j - i - 1) * dp[i]);
            }
        }
        return dp[n];
    }
}