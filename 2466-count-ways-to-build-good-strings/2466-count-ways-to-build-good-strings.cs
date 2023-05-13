public class Solution {
    public int CountGoodStrings(int low, int high, int zero, int one) {
        const int mod = 1_000_000_007;
        int[] dp = new int[high + 1];
        dp[0] = 1;
        for (int len = 1; len <= high; len++) {
            if (len >= zero)
                dp[len] = (dp[len] + dp[len - zero]) % mod;
            if (len >= one)
                dp[len] = (dp[len] + dp[len - one]) % mod;
        }
        int ans = 0;
        for (int len = low; len <= high; len++) { 
            ans += dp[len];
            ans %= mod;
        }
        return ans;
    }
}