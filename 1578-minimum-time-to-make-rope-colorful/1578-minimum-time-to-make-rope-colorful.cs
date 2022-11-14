public class Solution {
    public int MinCost(string colors, int[] neededTime) {
        var sum = neededTime[0];
        var max = neededTime[0];
        var totalTime = 0;
        for (var i = 1; i < colors.Length; i++) {
            if (colors[i] == colors[i - 1])
            {
                sum += neededTime[i];
                max = Math.Max(max, neededTime[i]);
            }
            else {
                totalTime += sum - max;
                max = neededTime[i];
                sum = neededTime[i];
            }
        }
        totalTime += sum - max;
        return totalTime;
    }
}