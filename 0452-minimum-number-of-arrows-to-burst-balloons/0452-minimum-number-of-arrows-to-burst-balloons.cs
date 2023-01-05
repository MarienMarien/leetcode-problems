public class Solution {
    public int FindMinArrowShots(int[][] points) {
        if (points.Length == 0)
            return 0;
        Array.Sort(points, Comparer<int[]>.Create((x, y) => { return x[1] != y[1] ? x[1].CompareTo(y[1]) : x[0].CompareTo(y[0]); }));
        var endId = 0;
        var arrowsCount = 1;
        for (var i = 1; i < points.Length; i++) {
            if (points[i][0] > points[endId][1]) {
                arrowsCount++;
                endId = i;
            }
        }
        return arrowsCount;
    }
}