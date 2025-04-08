public class Solution {
    public int CountComponents(int n, int[][] edges) {
        var graph = new Dictionary<int, ISet<int>>();
        foreach(var e in edges)
        {
            if(!graph.TryAdd(e[0], new HashSet<int> {e[1]}))
                graph[e[0]].Add(e[1]);
            if(!graph.TryAdd(e[1], new HashSet<int> {e[0]}))
                graph[e[1]].Add(e[0]);
        }
        var visited = new HashSet<int>();
        var componentCount = 0;
        for(var node = 0; node < n; node++)
        {
            if(visited.Contains(node))
                continue;
            visited.Add(node);
            VisitComponent(graph, node, visited);
            componentCount++;
        }
        return componentCount;
    }

    private void VisitComponent(IDictionary<int, ISet<int>> graph, int node, ISet<int> visited)
    {
        var q = new Queue<int>();
        q.Enqueue(node);
        while(q.Count > 0)
        {
            var curr = q.Dequeue();
            if(!graph.ContainsKey(curr))
                continue;
            foreach(var adj in graph[curr])
            {
                if(visited.Contains(adj))
                    continue;
                visited.Add(adj);
                q.Enqueue(adj);
            }
        }
    }
}