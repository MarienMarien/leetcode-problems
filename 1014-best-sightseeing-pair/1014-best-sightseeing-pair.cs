public class Solution {
    public int MaxScoreSightseeingPair(int[] values) {
        var maxI = values[0];
        var maxScore = 0;
        for(var i = 1; i < values.Length; i++)
        {
            var maxJ = values[i] - i;
            maxScore = Math.Max(maxScore, maxI + maxJ);
            maxI = Math.Max(maxI, values[i] + i);

        }

        return maxScore;
    }
}