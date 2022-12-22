public class Solution {
    public int ConnectSticks(int[] sticks) {
        if (sticks.Length == 1)
            return 0;
        var pq = new PriorityQueue<int, int>();
        foreach (var s in sticks) {
            pq.Enqueue(s, s);
        }
        var totalCost = 0;
        while (pq.Count > 0) {
            var a = pq.Dequeue();
            var isNotLast = pq.TryDequeue(out int b, out _);
            var sum = a + b;
            if(isNotLast){
                pq.Enqueue(sum, sum);
                totalCost += sum;
            }
        }
        
        return totalCost;
    }
}