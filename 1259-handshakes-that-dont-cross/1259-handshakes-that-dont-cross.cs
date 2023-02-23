public class Solution {
    public int NumberOfWays(int numPeople)
    {
        const int mod = 1000000007;
        var dp = new long[numPeople / 2 + 1];
        dp[0] = 1;
        for (var i = 1; i <= numPeople / 2; i++)
        {
            for (var j = 0; j < i; j++)
            {
                dp[i] += dp[j] * dp[i - j - 1] % mod;
                dp[i] %= mod;
            }
        }
        return (int)dp[numPeople / 2];
    }
}