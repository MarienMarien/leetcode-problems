public class Solution {
    public int MinCostClimbingStairs(int[] cost) {
        if (cost.Length < 1)
            return 0;
        var stairCosts = new int[cost.Length + 1];
        stairCosts[0] = cost[0];
        stairCosts[1] = cost.Length > 1 ? cost[1] : 0;
        for (var i = 2; i < stairCosts.Length; i++) {
            var currCost = i < cost.Length ? cost[i] : stairCosts[i];
            stairCosts[i] = Math.Min(stairCosts[i - 1] + currCost, stairCosts[i - 2] + currCost);
        }
        return stairCosts[stairCosts.Length - 1];
    }
}