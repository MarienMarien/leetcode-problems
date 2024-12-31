public class Solution {
    public int MincostTickets(int[] days, int[] costs) {
        var lastDay = days[^1];
        var dp = new int[lastDay + 1];
        foreach (var d in days)
            dp[d] = 1;

        for (var day = 1; day <= lastDay; day++)
        {
            if (dp[day] != 1)
            {
                dp[day] = dp[day - 1];
                continue;
            }

            dp[day] = Math.Min(
                Math.Min(dp[day - 1] + costs[0], 
                    dp[Math.Max(day - 7, 0)] + costs[1]),
                dp[Math.Max(day - 30, 0)] + costs[2]);
        }

        return dp[^1];
    }
}