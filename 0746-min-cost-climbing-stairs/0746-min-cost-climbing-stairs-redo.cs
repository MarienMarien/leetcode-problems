public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        var step1Cost = 0;
        var step2Cost = 0;
        for(var i = 2; i < cost.Length + 1; i++)
        {
            var tmp = step1Cost;
            step1Cost = Math.Min(step1Cost + cost[i - 1], step2Cost + cost[i - 2]);
            step2Cost = tmp;
        }
        return step1Cost;
    }
}