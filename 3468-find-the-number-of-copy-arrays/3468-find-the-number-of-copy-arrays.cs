public class Solution {
    public int CountArrays(int[] original, int[][] bounds) {
        var countArrays = 0;
        var lowerBound = bounds[0][0];
        var upperBound = bounds[0][1];

        for (var i = 1; i < original.Length; i++)
        {
            var diff = original[i] - original[i - 1];
            lowerBound += diff;
            upperBound += diff;
            lowerBound = Math.Max(lowerBound, bounds[i][0]);
            upperBound = Math.Min(upperBound, bounds[i][1]);
            if (upperBound < lowerBound)
                return 0;
            countArrays = Math.Abs(upperBound - lowerBound + 1);
        }

        return countArrays;
    }
}