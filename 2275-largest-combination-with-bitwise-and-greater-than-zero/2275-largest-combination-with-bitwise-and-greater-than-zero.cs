public class Solution {
    public int LargestCombination(int[] candidates) {
        var counting = new int[24];
        foreach (var c in candidates)
        {
            var curr = c;
            var countingId = 0;
            while (curr > 0) {
                counting[countingId] += curr & 1;
                curr >>= 1;
                countingId++;
            }
        }

        return counting.Max();
    }
}