public class Solution {
    public bool CanAttendMeetings(int[][] intervals) {
       var ans = true;
        if (intervals == null || intervals.Length == 0)
            return ans;
        intervals = intervals.OrderBy(x => x[0]).ToArray();
        var intervalStart = intervals[0][0];
        var intervalEnd = intervals[0][1];
        for (var i = 1; i < intervals.Length; i++) {
            if (intervalStart <= intervals[i][0] && intervals[i][0] < intervalEnd)
                return false;
            if (intervals[i][0] < intervalEnd && intervalEnd <= intervals[i][1])
                return false;
            if (intervalStart < intervals[i][0])
            {
                intervalStart = intervals[i][0];
                intervalEnd = intervals[i][1];
            }
        }

        return ans;
    }
}