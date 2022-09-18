public class Solution {
    public int NumDecodings(string s) {
        if (s[0] == '0')
            return 0;
        var dp = new int[s.Length + 1];
        dp[0] = 1;
        dp[1] = 1;
        for (var i = 2; i < dp.Length; i++) {
            if (s[i - 1] != '0')
                dp[i] = dp[i - 1];
            if (s[i - 2] == '1' || (s[i - 2] == '2' && s[i - 1] < '7'))
                dp[i] += dp[i - 2];
        }
        return dp[dp.Length - 1];
    }
}