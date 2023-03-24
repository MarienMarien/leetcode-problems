public class Solution {
    private IDictionary<int, ISet<int[]>> _map;
    private int _changesCount;
    public int MinReorder(int n, int[][] connections)
    {
        _map = new Dictionary<int, ISet<int[]>>();
        foreach (var c in connections) {
            if (!_map.ContainsKey(c[0])) {
                _map.Add(c[0], new HashSet<int[]>());
            }
            _map[c[0]].Add(c);
            if (!_map.ContainsKey(c[1]))
            {
                _map.Add(c[1], new HashSet<int[]>());
            }
            _map[c[1]].Add(c);
        }
        CountChanges(0);
        return _changesCount;
    }

    private void CountChanges(int city)
    {
        var set = _map[city];
        foreach (var c in set) {
            _map[c[0]].Remove(c);
            _map[c[1]].Remove(c);
            var nextCity = c[0];
            if (city == c[0])
            {
                _changesCount++;
                nextCity = c[1];
            }
            CountChanges(nextCity);
        }
    }
}