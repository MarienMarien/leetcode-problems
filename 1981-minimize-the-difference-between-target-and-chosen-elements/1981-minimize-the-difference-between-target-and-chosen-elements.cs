public class Solution {
    public int MinimizeTheDifference(int[][] mat, int target) {
       var sums = new HashSet<int>();
        HashSet<int> rowSums;
        sums.Add(0);
        for (int i = 0; i < mat.Length; i++)
        {
            rowSums = new HashSet<int>();
            foreach (var s in sums)
            {
                for (int j = 0; j < mat[i].Length; ++j)
                    rowSums.Add(s + mat[i][j]);
            }

            // remova all greater then target except first one (closest to target)
            int minOver = Int32.MaxValue;
            foreach (var rS in rowSums)
            {
                if (rS >= target) minOver = Math.Min(minOver, rS);
            }
            sums = new HashSet<int>();
            foreach (var rS in rowSums)
            {
                if (rS <= minOver) sums.Add(rS);
            }
        }
        int minDiff = Int32.MaxValue;
        foreach (var s in sums)
        {
            int currDiff = Math.Abs(s - target);
            minDiff = Math.Min(currDiff, minDiff);
        }
        return minDiff;
    }
}