public class Solution {
    public int LongestCommonSubsequence(string text1, string text2) {
        var m = text1.Length;
        var n = text2.Length;
        var dp = new int[m + 1, n + 1];
        for(var i = 1; i <= m; i++)
        {
            var t1Id = i - 1;
            for(var j = 1; j <= n; j++)
            {
                var t2Id = j - 1;
                if(text1[t1Id] == text2[t2Id])
                    dp[i, j] = dp[i - 1, j - 1] + 1;
                else
                {
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
                }
            }
        }
        return dp[m, n];
    }
}