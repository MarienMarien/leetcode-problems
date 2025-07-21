public class Solution {
    public int MaxEvents(int[][] events) {
        Array.Sort(events, Comparer<int[]>.Create((x, y) => x[0] == y[0] ? x[1] - y[1] : x[0] - y[0]));
        var canAttend = 0;

        var pq = new PriorityQueue<int, int>();
        var eventId = 0;
        var currDay = events[eventId][0];
        for(; currDay <= 100000; currDay++)
        {
            while(eventId < events.Length && events[eventId][0] == currDay)
            {
                pq.Enqueue(events[eventId][1], events[eventId][1]);
                eventId++;
            }
            while(pq.Count > 0 && pq.Peek() < currDay)
            {
                pq.Dequeue();
            }
            if(pq.Count > 0)
            {
                pq.Dequeue();
                canAttend += 1;
            }
            if(eventId >= events.Length && pq.Count == 0)
                break;
        }

        return canAttend;
    }
}