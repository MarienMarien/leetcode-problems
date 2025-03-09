public class Solution {
    public bool CanAttendMeetings(int[][] intervals) {
        Array.Sort(intervals, Comparer<int[]>.Create((x, y) => {
            if(x[0] == y[0])
                return x[1] - y[1];
            return x[0] - y[0];
        }));
        var prevIntervalEnd = -1;
        foreach(var interval in intervals)
        {
            var currIntervalStart = interval[0];
            if(currIntervalStart < prevIntervalEnd)
                return false;
            prevIntervalEnd = interval[1];
        }

        return true;
    }
}