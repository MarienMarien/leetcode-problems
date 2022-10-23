public class Solution {
    public int MinMeetingRooms(int[][] intervals) {
        if(intervals == null || intervals.Length == 0)
            return 0;
        intervals = intervals.OrderBy(x => x[0]).ToArray();
        var pQueue = new PriorityQueue<int, int>(intervals.Length);
        var priority = Int32.MaxValue;
        pQueue.Enqueue(intervals[0][1], intervals[0][1]);
        for (var i = 1; i < intervals.Length; i++) {
            var minRoom = pQueue.Peek();
            // room is free
            if (minRoom <= intervals[i][0]) {
                pQueue.Dequeue();
            }
            pQueue.Enqueue(intervals[i][1], intervals[i][1]);
        }

        return pQueue.Count;
    }
}