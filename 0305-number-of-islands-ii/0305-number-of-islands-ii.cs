public class Solution {
    public IList<int> NumIslands2(int m, int n, int[][] positions)
    {
        var ans = new List<int>();
        var uf = new UnionFind();
        var x = new int[] { -1, 1, 0, 0 };
        var y = new int[] { 0, 0, -1, 1 };
        foreach (var p in positions) {
            var newLand = p[0] * n + p[1];
            uf.AddLand(newLand);
            for (var i = 0; i < x.Length; i++) {
                var neighX = p[0] + x[i];
                var neighY = p[1] + y[i];
                if (neighX < 0 || neighX >= m || neighY < 0 || neighY >= n)
                    continue;
                uf.Union(newLand, neighX * n + neighY);
            }
            ans.Add(uf.GetCount());
        }
        return ans;
    }

    class UnionFind {
        private Dictionary<int, int> _parent;
        private int count;
        public UnionFind()
        {
            _parent = new Dictionary<int, int>();
        }

        public int Find(int a) {
            if (!_parent.ContainsKey(a))
                return -1;
            if (_parent[a] != a)
                _parent[a] = Find(_parent[a]);
            return _parent[a];
        }

        public void Union(int a, int b) {
            var parentA = Find(a);
            var parentB = Find(b);
            if (parentA == -1 || parentB == -1 || parentA == parentB)
                return;
            _parent[parentA] = parentB;
            count--;
        }

        public void AddLand(int a) {
            if (!_parent.ContainsKey(a)) {
                _parent[a] = a;
                count++;
            }
        }

        public int GetCount() {
            return count;
        }
    }
}