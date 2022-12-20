public class Solution {
    public bool ValidPath(int n, int[][] edges, int source, int destination) {
        var uf = new UnionFind(n);
        foreach (var e in edges) {
            uf.Union(e[0], e[1]);
        }
        var sParent = uf.Find(source);
        var dParent = uf.Find(destination);
        return sParent == dParent;
    }

    private class UnionFind {
        private int[] _parent;
        private int[] _rank;

        public UnionFind(int n)
        {
            _parent = new int[n];
            _rank = new int[n];
            while (--n >= 0) {
                _parent[n] = n;
            }
        }

        public int Find(int node) {
            if (_parent[node] != node)
                _parent[node] = Find(_parent[node]);
            return _parent[node];
        }

        public bool Union(int n1, int n2) {
            var parentn1 = Find(n1);
            var parentn2 = Find(n2);
            if (parentn1 == parentn2)
                return false;
            if (_rank[parentn1] > _rank[parentn2])
            {
                _parent[parentn2] = parentn1;
            }
            else if (_rank[parentn1] < _rank[parentn2])
            {
                _parent[parentn1] = parentn2;
            }
            else {
                _rank[parentn2]++;
                _parent[parentn1] = parentn2;
            }
            return true;
        }
    }
}