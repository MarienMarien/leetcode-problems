public class Solution {
    public int[] ResultsArray(int[][] queries, int k) {
        var pq = new PriorityQueue<int, int>(Comparer<int>.Create((x, y) => y - x));
        var res = new int[queries.Length];

        for(var i = 0; i < queries.Length; i++)
        { 
            var dist = Math.Abs(queries[i][0]) + Math.Abs(queries[i][1]);
            pq.Enqueue(dist, dist);
            if (pq.Count > k)
                pq.Dequeue();
            res[i] = pq.Count < k ? -1 : pq.Peek();
        }

        return res;
    }
}