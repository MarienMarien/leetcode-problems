public class Solution {
    public int MinMeetingRooms(int[][] intervals) {
        var minMeetingRooms = 0;
        if (intervals == null || intervals.Length == 0)
            return minMeetingRooms;
        minMeetingRooms++;
        var starts = new int[intervals.Length];
        var ends = new int[intervals.Length];
        for (var i = 0; i < intervals.Length; i++) {
            starts[i] = intervals[i][0];
            ends[i] = intervals[i][1];
        }
        Array.Sort(starts);
        Array.Sort(ends);
        var start = 1;
        var end = 0;
        while(start < intervals.Length) {
            if (starts[start] >= ends[end])
            {
                end++;
            }
            else {
                minMeetingRooms++;
            }
            start++;
        }

        return minMeetingRooms;
    }
}