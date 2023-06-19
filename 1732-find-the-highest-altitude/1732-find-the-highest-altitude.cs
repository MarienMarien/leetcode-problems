public class Solution {
    public int LargestAltitude(int[] gain) {
        var max = 0;
        var prefSum = 0;
        foreach (var g in gain) {
            prefSum += g;
            max = Math.Max(max, prefSum);
        }
        return max;
    }
}