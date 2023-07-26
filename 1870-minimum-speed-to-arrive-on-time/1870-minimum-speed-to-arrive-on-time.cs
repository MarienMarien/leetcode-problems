public class Solution {
    public int MinSpeedOnTime(int[] dist, double hour)
    {
        if (hour < dist.Length - 1)
            return -1;
        var left = 1;
        var right = 10000000;
        var minSpeed = -1;
        while (left <= right) {
            var mid = Math.Ceiling((double)(right + left) / 2);
            var timeAtMidSpeed = CountTime(dist, mid);
            if (timeAtMidSpeed <= hour)
            {
                minSpeed = (int)mid;
                right = (int)mid - 1;
            }
            else {
                left = (int)mid + 1;
            }
        }
        return minSpeed;
    }

    private double CountTime(int[] dist, double mid)
    {
        var time = 0d;
        var lastId = dist.Length - 1;
        for (var i = 0; i < dist.Length; i++) {
            time += i == lastId ? dist[i] / mid : Math.Ceiling(dist[i] / mid);
        }
        return time;
    }
}