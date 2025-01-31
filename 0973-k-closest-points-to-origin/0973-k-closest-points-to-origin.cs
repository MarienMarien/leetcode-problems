public class Solution {
    public int[][] KClosest(int[][] points, int k) {
        if(k == points.Length)
            return points;
        var pq = new PriorityQueue<int[], double>(Comparer<double>.Create((x, y) => y.CompareTo(x)));
        foreach(var p in points)
        {
            var distance = Math.Sqrt(p[0] * p[0] + p[1] * p[1]);
            pq.Enqueue(p, distance);
            if(pq.Count > k)
                pq.Dequeue();
        }

        var closestPoints = new int[k][];
        var i = 0;
        while(pq.Count > 0)
        {
            closestPoints[i] = pq.Dequeue();
            i++;
        }

        return closestPoints;
    }
}