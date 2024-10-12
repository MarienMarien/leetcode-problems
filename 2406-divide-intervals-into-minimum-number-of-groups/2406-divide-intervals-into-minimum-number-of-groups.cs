public class Solution {
    public int MinGroups(int[][] intervals) {
        var intervalEvents = new (int time, int takenRoom)[intervals.Length * 2];
        var eventId = 0;
        foreach (var i in intervals)
        {
            intervalEvents[eventId++] = (i[0], 1);
            intervalEvents[eventId++] = (i[1] + 1, -1);
        }

        Array.Sort(intervalEvents, Comparer<(int time, int roomTaken)>.Create((x, y) => {
            if(x.time == y.time)
                return x.roomTaken - y.roomTaken;
            return x.time - y.time;
        }));

        var currEventsCount = 0;
        var maxSimultaniousEvents = 0;

        foreach (var ie in intervalEvents)
        {
            currEventsCount += ie.takenRoom;
            maxSimultaniousEvents = Math.Max(maxSimultaniousEvents, currEventsCount);
        }

        return maxSimultaniousEvents;
    }
}