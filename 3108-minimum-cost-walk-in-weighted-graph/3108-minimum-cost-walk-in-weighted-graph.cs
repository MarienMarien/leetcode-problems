public class Solution {
    public int[] MinimumCost(int n, int[][] edges, int[][] query)
    {
        var uf = new UnionFind(n);
        foreach (var e in edges)
        {
            var a = e[0];
            var b = e[1];
            var cost = e[2];
            uf.Union(a, b, cost);
        }

        var answer = new int[query.Length];
        for (var i = 0; i < query.Length; i++)
        {
            var a = query[i][0];
            var b = query[i][1];
            var parentA = uf.Find(a);
            var parentB = uf.Find(b);
            if (parentA != parentB)
            {
                answer[i] = -1;
                continue;
            }
            answer[i] = uf.GetCost(parentA);
        }

        return answer;
    }

    public class UnionFind
    {
        private int[] _parents;
        private IDictionary<int, int> _parentCost;

        public UnionFind(int n)
        {
            _parentCost = new Dictionary<int, int>();
            _parents = new int[n];
            for (var i = 0; i < n; i++)
            {
                _parents[i] = i;
            }
        }

        public int Find(int x)
        {
            if (_parents[x] != x)
            {
                _parents[x] = Find(_parents[x]);
            }

            return _parents[x];
        }

        public void Union(int a, int b, int cost)
        {
            var parentA = Find(a);
            var parentB = Find(b);

            if (parentA != parentB)
            {
                _parents[parentB] = parentA;
                if (_parentCost.ContainsKey(parentB))
                    cost &= _parentCost[parentB];
            }

            if (!_parentCost.TryAdd(parentA, cost))
                _parentCost[parentA] &= cost;
        }

        public int GetCost(int x)
        {
            return _parentCost.ContainsKey(x) ? _parentCost[x] : -1;
        }
    }
}