public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        var graph = new Dictionary<int, ISet<int>>();
        foreach(var e in edges)
        {
            if(!graph.TryAdd(e[0], new HashSet<int> { e[1] }))
                graph[e[0]].Add(e[1]);
            if(!graph.TryAdd(e[1], new HashSet<int> { e[0] }))
                graph[e[1]].Add(e[0]);
        }

        var visited = new HashSet<int>() { 0 };
        var q = new Queue<int>();
        q.Enqueue(0);
        while(q.Count > 0)
        {
            var curr = q.Dequeue();
            if(!graph.ContainsKey(curr))
                continue;
            foreach(var adj in graph[curr])
            {
                if(visited.Contains(adj))
                    return false;
                q.Enqueue(adj);
                graph[curr].Remove(adj);
                graph[adj].Remove(curr);
                visited.Add(adj);
            }
        }
        return visited.Count == n;
    }
}