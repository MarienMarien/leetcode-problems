public class Solution {
    private ISet<int> _cycle;
    private IList<int> _path;
    public int[] FindRedundantConnection(int[][] edges) {
        _cycle = new HashSet<int>();
        _path =new List<int>();
        var graph = new Dictionary<int, ISet<int>>();
        foreach(var e in edges)
        {
            if(!graph.TryAdd(e[0], new HashSet<int>{e[1]}))
                graph[e[0]].Add(e[1]);
            if(!graph.TryAdd(e[1], new HashSet<int>{e[0]}))
                graph[e[1]].Add(e[0]);
        }
        FindCycle(graph, 1, -1);

        for(var i = edges.Length - 1; i >= 0; i--)
        {
            if(_cycle.Contains(edges[i][0]) && _cycle.Contains(edges[i][1]))
                return edges[i];
        }

        return null;
    }

    private bool FindCycle(IDictionary<int, ISet<int>> graph, int node, int parentNode)
    {
        if( _cycle.Contains(node)){
            for(var i = 0; i < _path.Count; i++)
            {
                if(_path[i] == node)
                    break;
                _cycle.Remove(_path[i]);
            }
            return true;
        }

        _cycle.Add(node);
        _path.Add(node);
        foreach(var adj in graph[node])
        {
            if(adj == parentNode)
                continue;
            if(FindCycle(graph, adj, node))
            {
                return true;
            }
        }
        _cycle.Remove(node);
        _path.RemoveAt(_path.Count - 1);
        
        return false;
    }
}