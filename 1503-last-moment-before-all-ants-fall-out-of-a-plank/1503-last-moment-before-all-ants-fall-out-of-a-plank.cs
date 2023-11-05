public class Solution {
    public int GetLastMoment(int n, int[] left, int[] right) {
        var minRight = right.Length != 0 ? right.Min() : n;
        var maxLeft = left.Length != 0 ? left.Max() : 0;
        return Math.Max(n - minRight, maxLeft);
    }
}