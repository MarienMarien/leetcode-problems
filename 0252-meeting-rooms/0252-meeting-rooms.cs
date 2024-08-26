public class Solution {
    public bool CanAttendMeetings(int[][] intervals) {
        Array.Sort(intervals, Comparer<int[]>.Create((x, y) =>
        {
            if (x[0] == y[0])
                return y[1] - x[1];
            return x[0] - y[0];
        }));

        var start = -1;
        var end = -1;

        for (var i = 0; i < intervals.Length; i++)
        {
            if (IsOverlap(start, end, intervals[i]))
            {
                return false;
            }
            start = intervals[i][0];
            end = intervals[i][1];
        }
        return true;
    }

    private bool IsOverlap(int start, int end, int[] ints)
    {
        return (ints[1] <= end && ints[1] > start) || (ints[0] >= start && ints[0] < end);
    }
}