public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        var step1 = 0;
        var step2 = 0;
        for(var i = 2; i <= cost.Length; i++)
        {
            var tmp = step1;
            step1 = Math.Min(step1 + cost[i - 1], step2 + cost[i - 2]);
            step2 = tmp;
        }

        return step1;
    }
}