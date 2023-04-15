public class Solution {
    public int MaxValueOfCoins(IList<IList<int>> piles, int k) {
        var dp = new int[piles.Count + 1, k + 1];
        for (var i = 1; i <= piles.Count; i++) {
            for (var coins = 0; coins <= k; coins++) {
                var currSum = 0;
                for (var currCoins = 0; currCoins <= Math.Min(piles[i - 1].Count, coins); currCoins++) {
                    if (currCoins > 0) {
                        currSum += piles[i - 1][currCoins - 1];
                    }
                    dp[i, coins] = Math.Max(dp[i,coins], dp[i - 1,coins - currCoins] + currSum);
                }
            }
        }
        return dp[piles.Count, k];
    }
}