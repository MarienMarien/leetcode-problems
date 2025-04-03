public class Solution {
    public int NumDistinct(string s, string t) {
        var m = t.Length + 1;
        var n = s.Length + 1;
        var dp = new int[m, n];
        var lastRow = t.Length - 1;
        for(var col = n - 1; col > 0; col--)
        {
            if(s[col - 1] == t[lastRow])
                dp[m - 1, col] = 1;
        }

        for(var row = lastRow; row >= 0; row--)
        {
            for(var col = n - 2; col >= 0; col--)
            {
                if(t[row] != s[col])
                {
                    dp[row,col] = dp[row, col + 1];
                    continue;
                }
                dp[row, col] = dp[row + 1, col + 1] + dp[row, col + 1];
            }
        }
        return dp[0,0];
    }
}