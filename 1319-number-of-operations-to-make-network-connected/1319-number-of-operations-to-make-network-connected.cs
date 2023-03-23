public class Solution {
    public int MakeConnected(int n, int[][] connections)
    {
        if (connections.Length < n - 1)
            return -1;
        var uf = new UnionFind(n);
        foreach (var c in connections) {
            uf.Union(c[0], c[1]);
        }
        var connectionsNeeded = -1;// exclude very first node
        for (var c = 0; c < n; c++) {
            var parent = uf.Find(c);
            if (parent == c)
                connectionsNeeded++;
        }
        return connectionsNeeded;
    }

    public class UnionFind {
        private int[] _parent;

        public UnionFind(int n)
        {
            _parent = new int[n];
            for (var i = 0; i < n; i++) {
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
            if(parentA != parentB)
                _parent[parentB] = parentA;
        }

    }
}