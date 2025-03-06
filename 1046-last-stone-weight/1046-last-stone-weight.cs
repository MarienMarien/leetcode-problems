public class Solution {
    public int LastStoneWeight(int[] stones) {
        var pq = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));
        foreach(var s in stones)
        {
            pq.Enqueue(s, s);
        }

        while(pq.Count > 1)
        {
            var n1 = pq.Dequeue();
            var n2 = pq.Dequeue();
            var diff = Math.Abs(n1 - n2);
            if(diff > 0)
                pq.Enqueue(diff, diff);
        }

        return pq.Count == 1 ? pq.Dequeue() : 0;
    }
}