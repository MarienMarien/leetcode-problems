public class Solution {
    private LinkedList<int> _traverse;
    private ISet<int> _seen;
    private ISet<int> _cycleNodes;
    public int[] DistanceToCycle(int n, int[][] edges)
    {
        _traverse = new LinkedList<int>();
        _seen = new HashSet<int>();
        _cycleNodes = new HashSet<int>();
        var graph = new Dictionary<int, ISet<int>>();
        foreach (var e in edges)
        {
            if (!graph.TryAdd(e[0], new HashSet<int> { e[1] }))
                graph[e[0]].Add(e[1]);
            if (!graph.TryAdd(e[1], new HashSet<int> { e[0] }))
                graph[e[1]].Add(e[0]);
        }

        CycleFound(graph, 0, -1);

        var distances = new int[n];

        foreach (var startNode in _cycleNodes)
        {
            var q = new Queue<(int node, int parent)>();
            q.Enqueue((startNode, -1));
            while (q.Count > 0)
            {
                var currNode = q.Dequeue();
                var distance = distances[currNode.node] + 1;
                foreach (var adj in graph[currNode.node])
                {
                    if (_cycleNodes.Contains(adj) || adj == currNode.parent)
                        continue;
                    distances[adj] = distance;
                    q.Enqueue((adj, currNode.node));
                }
            }
        }

        return distances;
    }

    private bool CycleFound(Dictionary<int, ISet<int>> graph, int n, int parent)
    {
        var found = false;
        _traverse.AddLast(n);
        _seen.Add(n);

        foreach (var e in graph[n])
        {
            if (e == parent)
                continue;
            if (_seen.Contains(e))
            {
                found = true;
                while (_traverse.Count > 0 && _traverse.Last.Value != e)
                {
                    _cycleNodes.Add(_traverse.Last.Value);
                    _traverse.RemoveLast();
                }
                _cycleNodes.Add(e);
                break;
            }

            if (found = CycleFound(graph, e, n))
                break;
        }
        if(_traverse.Count > 0 && !found)
            _traverse.RemoveLast();

        return found;
    }
}