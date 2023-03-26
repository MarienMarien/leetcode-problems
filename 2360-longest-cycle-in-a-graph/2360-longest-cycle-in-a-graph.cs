public class Solution {
    public int LongestCycle(int[] edges)
    {
        int count = -1;
        var visited = new bool[edges.Length];
        for (var i = 0; i < edges.Length; i++) {
            if (!visited[i])
            {
                var dist = new Dictionary<int, int>
                {
                    { i, 1 }
                };
                var currNode = i;
                var nextNode = edges[currNode];
                while (nextNode != -1 && !visited[nextNode])
                {
                    visited[currNode] = true;
                    dist.TryAdd(nextNode, dist[currNode] + 1);
                    currNode = nextNode;
                    nextNode = edges[currNode];
                }
                if (dist.ContainsKey(nextNode)) {
                    count = Math.Max(count, dist[currNode] - dist[nextNode] + 1);
                }
            }
        }
        
        return count;
    }
}