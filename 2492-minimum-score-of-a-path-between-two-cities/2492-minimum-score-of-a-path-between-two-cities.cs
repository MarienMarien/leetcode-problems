public class Solution {
    private IDictionary<int, IDictionary<int, int>> _map;
    private ISet<int> _visited;
    private int _min;
    public int MinScore(int n, int[][] roads)
    {
        _map= new Dictionary<int, IDictionary<int,int>>();
        _visited= new HashSet<int>();
        _min = Int32.MaxValue;
        foreach (var r in roads) {
            _map.TryAdd(r[0], new Dictionary<int, int>());
            _map[r[0]].Add(r[1], r[2]);
            _map.TryAdd(r[1], new Dictionary<int, int>());
            _map[r[1]].Add(r[0], r[2]);
        }
        FindMin(1);
        return _visited.Contains(n) ? _min : 0;
    }

    private void FindMin(int node)
    {
        _visited.Add(node);
        foreach (var road in _map[node]) {
            _min = Math.Min(_min, road.Value);
            if (_visited.Contains(road.Key))
                continue;
            FindMin(road.Key);
        }
    }
}