public class Solution {
    public int CoinChange(int[] coins, int amount) {
        if(amount == 0)
            return 0;
        int max = amount + 1;
        int[] dp = new int[amount + 1];
        Array.Fill(dp, max);
        dp[0] = 0;
        foreach(var c in coins) {
            for (int i = c; i <= amount; i++) {
                if (dp[i - c] + 1 < dp[i]) {
                    dp[i] = dp[i - c] + 1;
                }
            }
        }
        return dp[amount] == max ? -1 : dp[amount];
    }
}