public class Solution {
    public bool PossibleBipartition(int n, int[][] dislikes) {
        var uf = new UnionFind(n);
        var map = new Dictionary<int, int>();
        foreach (var d in dislikes) { 
            var a = d[0] - 1;
            var b = d[1] - 1;
            if (uf.Find(a) == uf.Find(b))
                return false;
            if (map.ContainsKey(a))
                uf.Union(map[a], b);
            else
                map.Add(a, b);
            if (map.ContainsKey(b))
                uf.Union(map[b], a);
            else
                map.Add(b, a);
        }
        return true;
    }

    private class UnionFind {
        private int[] _parent;
        private int[] _rank;
        public UnionFind(int n)
        {
           _parent = new int[n];
            for (var i = 0; i < n; i++) {
                _parent[i] = i;
            }
            _rank = new int[n];
        }

        public int Find(int n) {
            if (_parent[n] != n)
                _parent[n] = Find(_parent[n]);
            return _parent[n];
        }
        public void Union(int a, int b) {
            var groupA = Find(a);
            var groupB = Find(b);
            if (groupA == groupB)
                return;
            if (_rank[groupA] > _rank[groupB])
            {
                _parent[groupB] = groupA;
            }
            else if (_rank[groupA] < _rank[groupB])
            {
                _parent[groupA] = groupB;
            }
            else {
                _rank[groupB]++;
                _parent[groupA] = groupB;
            }
        }
    }
}