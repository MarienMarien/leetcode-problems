public class Solution {
    public int MincostTickets(int[] days, int[] costs) {
        var lastDay = days[^1];
        var dp = new int[lastDay + 1];
        foreach(var d in days)
            dp[d] = 1;
        for (var i = 1; i <= lastDay; i++) {
            if (dp[i] == 1)
            {
                dp[i] = Math.Min(dp[i-1] + costs[0], dp[Math.Max(i-7,0)] + costs[1]);
                dp[i] = Math.Min(dp[i], dp[Math.Max(i-30, 0)] + costs[2]);
            } else
                dp[i] = dp[i - 1];
        }
        return dp[lastDay];
    }
}