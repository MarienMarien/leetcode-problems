public class Solution {
    public int MaxPoints(int[][] points) {
        if (points.Length <= 2)
            return points.Length;
        var max = 0;
        for (var p1 = 0; p1 < points.Length; p1++) {
            var map = new Dictionary<double, int>();
            for (var p2 = 0; p2 < points.Length; p2++)
            {
                if (p1 == p2)
                    continue;
                var angle = Math.Atan2(points[p2][1] - points[p1][1], points[p2][0] - points[p1][0]);
                if (!map.TryAdd(angle, 2))
                    map[angle]++;
                max = Math.Max(max, map[angle]);
            }
        }
        return max;
    }
}