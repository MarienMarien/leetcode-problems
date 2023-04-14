public class Solution {
    public int LongestPalindromeSubseq(string s) {
        var len = s.Length;
        var dp = new int[len, len];
        for (int j = 0; j < len; j++)
        {
            dp[j, j] = 1;
            for (var i = j - 1; i >= 0; i--)
            {
                if (s[i] == s[j])
                    dp[i, j] = dp[i + 1, j - 1] + 2;
                else
                    dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
            }
        }

        return dp[0, len - 1];
    }
}