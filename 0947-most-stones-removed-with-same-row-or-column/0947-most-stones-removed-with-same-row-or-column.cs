public class Solution {
    public int RemoveStones(int[][] stones) {
        var stonesCount = stones.Length;
        var rowMap = new Dictionary<int, int>();
        var colMap = new Dictionary<int, int>();
        var uf = new UnionFind(stonesCount);

        for (var s = 0; s < stonesCount; s++)
        {
            var row = stones[s][0];
            var col = stones[s][1];
            if(!rowMap.TryAdd(row, s))
            {
                uf.Union(s, rowMap[row]);
            }

            if (!colMap.TryAdd(col, s))
            {
                uf.Union(s, colMap[col]);
            }
        }

        var removed = 0;
        for (var s = 0; s < stonesCount; s++)
        {
            var parentS = uf.Find(s);
            if (parentS != s)
                removed++;
        }

        return removed;
    }

    public class UnionFind
    {
        private int[] _parents;
        private int _n;

        public UnionFind(int n)
        {
            _n = n;
            _parents = new int[n];
            for (var i = 0; i < n; i++)
            {
                _parents[i] = i;
            }
        }

        public int Find(int a)
        {
            if (_parents[a] != a)
                _parents[a] = Find(_parents[a]);
            return _parents[a];
        }

        public void Union(int a, int b)
        {
            var parentA = Find(a);
            var parentB = Find(b);
            if (parentA != parentB)
            {
                if (parentA == a)
                    _parents[parentA] = parentB;
                else
                    _parents[parentB] = parentA;
            }
        }
    }
}