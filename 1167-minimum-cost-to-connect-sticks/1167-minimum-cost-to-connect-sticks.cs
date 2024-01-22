public class Solution {
    public int ConnectSticks(int[] sticks) {
        var pq = new PriorityQueue<int, int>();
        foreach (var s in sticks)
            pq.Enqueue(s, s);

        var totalCost = 0;
        while (pq.Count > 1) {
            var first = pq.Dequeue();
            var second = pq.Dequeue();
            var sum = first + second;
            totalCost += sum;
            pq.Enqueue(sum, sum);
        }

        return totalCost;
    }
}