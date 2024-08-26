public class Solution {
    public int MinMeetingRooms(int[][] intervals) {
        var overlappingMeetings = 1;

        Array.Sort(intervals, Comparer<int[]>.Create((x, y) =>
        {
            if (x[0] == y[0])
                return x[1] - y[1];
            return x[0] - y[0];
        }));

        var meetingInProgress = new PriorityQueue<int, int>();
        meetingInProgress.Enqueue(intervals[0][1], intervals[0][1]);

        for (var i = 1; i < intervals.Length; i++)
        {
            var currRoomEndTime = meetingInProgress.Peek();
            if (currRoomEndTime <= intervals[i][0])
            {
                meetingInProgress.Dequeue();
            }
            meetingInProgress.Enqueue(intervals[i][1], intervals[i][1]);
            overlappingMeetings = Math.Max(overlappingMeetings, meetingInProgress.Count);
        }

        return overlappingMeetings;
    }
}