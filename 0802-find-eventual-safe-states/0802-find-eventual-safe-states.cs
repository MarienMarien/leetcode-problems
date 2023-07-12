public class Solution {
    private IDictionary<int, ISet<int>> _map;
    private IDictionary<int, bool> _isSafe;
    private ISet<int> _visited;
    public IList<int> EventualSafeNodes(int[][] graph)
    {
        _visited = new HashSet<int>();
        _isSafe = new Dictionary<int, bool>();
        _map = new Dictionary<int, ISet<int>>();
        for (var i = 0; i < graph.Length; i++) {
            _map.TryAdd(i, new HashSet<int>());
            foreach(var node in graph[i])
            {
                _map[i].Add(node);
            }
        }
        for (var node = 0; node < graph.Length; node++) {
            _isSafe[node] = FindIfSafe(node);
        }
        var res = new List<int>();
        foreach (var item in _isSafe) {
            if (item.Value)
                res.Add(item.Key);
        }
        return res.OrderBy(x => x).ToList();
    }

    private bool FindIfSafe(int curr)
    {
        if (_map[curr].Count == 0 || _isSafe.ContainsKey(curr) && (_isSafe[curr] == true)) {
            return true;
        }
        if (_visited.Contains(curr))
            return false;
        _visited.Add(curr);
        foreach(var node in _map[curr]) {
            _isSafe[node] = FindIfSafe(node);
            if (!_isSafe[node])
                return false;
        }
        return true;
    }
}