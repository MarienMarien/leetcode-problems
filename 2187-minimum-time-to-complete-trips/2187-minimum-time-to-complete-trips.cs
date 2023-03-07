public class Solution {
    public long MinimumTime(int[] time, int totalTrips) {
        long minTime = Int32.MaxValue;
        foreach (var t in time) {
            minTime = Math.Min(minTime, t);
        }

        long start = 1;
        long end = minTime * totalTrips;
        while (start < end) {
            long mid = (end + start) / 2;
            if (IsEnough(mid, time, totalTrips))
            {
                end = mid;
            }
            else {
                start = mid + 1;
            }
        }
        return start;
    }

    private bool IsEnough(long mid, int[] time, int totalTrips)
    {
        long trips = 0;
        foreach (var t in time)
            trips += mid / t;
        return trips >= totalTrips;
    }
}