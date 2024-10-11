public class Solution {
    public int SmallestChair(int[][] times, int targetFriend) {
        var ids = Enumerable.Range(0, times.Length).ToArray();
        Array.Sort(times, ids, Comparer<int[]>.Create((x, y) =>
        {
            return x[0].CompareTo(y[0]);
        }));

        var pq = new PriorityQueue<(int chair, int endTime), int>();
        var freechairs = new PriorityQueue<int, int>();
        var chair = 0;
        for(var i = 0; i < times.Length; i++) {
            while (pq.Count > 0 && times[i][0] >= pq.Peek().endTime)
            {
                var freedChair = pq.Dequeue().chair;
                freechairs.Enqueue(freedChair, freedChair);
            }

            var friendChair = chair;
            if (freechairs.Count > 0)
            {
                friendChair = freechairs.Dequeue();
            } else {
                chair++;
            }

            if (ids[i] == targetFriend)
            {
                return friendChair;
            }

            pq.Enqueue((friendChair, times[i][1]), times[i][1]);
        }

        return 0;
    }
}