public class Solution {
    public int MinCost(string colors, int[] neededTime) {
        var minCost = 0;
        var i = 0;

        while (i < colors.Length)
        {
            if (i > 0 && colors[i] == colors[i - 1])
            {
                var totalTimeToRemColor = neededTime[i - 1];
                var longestToRem = neededTime[i - 1];
                while (i < colors.Length && colors[i] == colors[i - 1])
                {
                    totalTimeToRemColor += neededTime[i];
                    longestToRem = Math.Max(longestToRem, neededTime[i]);
                    i++;
                }
                minCost += totalTimeToRemColor - longestToRem;
            }
            i++;
        }

        return minCost;
    }
}