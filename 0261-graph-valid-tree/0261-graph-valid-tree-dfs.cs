public class Solution {
    private ISet<int> _visited;
    public bool ValidTree(int n, int[][] edges)
    {
        _visited = new HashSet<int>();
        var graph = new Dictionary<int, ISet<int>>();
        foreach (var e in edges)
        {
            if (!graph.TryAdd(e[0], new HashSet<int> { e[1] }))
                graph[e[0]].Add(e[1]);
            if (!graph.TryAdd(e[1], new HashSet<int> { e[0] }))
                graph[e[1]].Add(e[0]);
        }
        return !HasCycle(graph, 0, -1) && _visited.Count == n;
    }

    private bool HasCycle(Dictionary<int, ISet<int>> graph, int node, int parent)
    {
        if (_visited.Contains(node))
            return true;
        _visited.Add(node);
        if(graph.ContainsKey(node))
        {
            foreach (var adj in graph[node])
            {
                if (adj == parent)
                    continue;
                if (HasCycle(graph, adj, node))
                    return true;
            }
        }
        return false;
    }
}