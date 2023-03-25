public class Solution {
    public long CountPairs(int n, int[][] edges)
    {
        var uf = new UnionFind(n);
        foreach (var e in edges) {
            uf.Union(e[0], e[1]);
        }
        var parentGroups = new Dictionary<int, long>();
        for (var g = 0; g < n; g++) {
            var parent = uf.Find(g);
            if(!parentGroups.TryAdd(parent, 1))
                parentGroups[parent]++;
        }
        long sum = 0;
        long squareSum = 0;
        if (parentGroups.Count > 1) {
            foreach (var pg in parentGroups)
            {
                sum += pg.Value;
                squareSum += pg.Value * pg.Value;
            }
        }
        return ((sum * sum) - squareSum) / 2;
    }

    class UnionFind {
        private int[] _parent;
        public UnionFind(int size)
        {
            _parent = new int[size];
            for (var i = 0; i < size; i++) {
                _parent[i] = i;
            }
        }

        public int Find(int n) {
            if (_parent[n] != n)
                _parent[n] = Find(_parent[n]);
            return _parent[n];
        }

        public void Union(int a, int b) {
            var parentA = Find(a);
            var parentB = Find(b);
            if (parentA != parentB)
                _parent[parentB] = parentA;
        }
    }
}