public class Solution {
    public int MincostTickets(int[] days, int[] costs) {
        var lastTravelDay = days[^1];
        var dp = new int[lastTravelDay + 1];
        var dayId = 0;
        var cost1d = costs[0];
        var cost7d = costs[1];
        var cost30d = costs[2];
        for(var day = 1; day <= lastTravelDay; day++)
        {
            if(dayId < days.Length && day != days[dayId])
            {
                dp[day] = dp[day -1];
                continue;
            }
            dayId++;
            dp[day] = Math.Min(dp[day - 1] + cost1d, 
                Math.Min(dp[Math.Max(day - 7, 0)] + cost7d, dp[Math.Max(day - 30, 0)] + cost30d));
        }

        return dp[^1];
    }
}