public class Solution {
    public int MinDistance(string word1, string word2) {
        var m = word1.Length;
        var n = word2.Length;
        var dp = new int[m + 1, n + 1];
        for (var i = 0; i <= m; i++) {
            for (var j = 0; j <= n; j++) {
                if (i == 0)
                {
                    dp[i, j] = j;
                    continue;
                }
                if (j == 0) {
                    dp[i, j] = i;
                    continue;
                }

                if (word1[i - 1] == word2[j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1];
                }
                else
                {
                    dp[i, j] = 1+ Math.Min(dp[i - 1,j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1]));
                }
            }
        }
        return dp[m, n];
    }
}