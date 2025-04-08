public class Solution {
    public int CountComponents(int n, int[][] edges) {
        var uf = new UnionFind(n);
        foreach(var e in edges)
        {
            uf.Union(e[0], e[1]);
        }

        var componentCount = 0;
        for(var node = 0; node < n; node++)
        {
            if(node == uf.Find(node))
                componentCount++;
        }

        return componentCount;
    }

    class UnionFind
    {
        private int[] _parents;
        private int[] _ranks;
        public UnionFind(int n)
        {
            _ranks = new int[n];
            _parents = new int[n];
            for(var i = 0 ; i < n; i++)
            {
                _parents[i] = i;
            }
        }

        public int Find(int x)
        {
            if(_parents[x] != x)
                _parents[x] = Find(_parents[x]);
            return _parents[x];
        }

        public void Union(int a, int b)
        {
            var parentA = Find(a);
            var parentB = Find(b);
            if(parentA == parentB)
                return;
            if(_ranks[parentA] > _ranks[parentB])
            {
                _parents[parentB] = parentA;
                return;
            }
            _parents[parentA] = parentB;
            if(_ranks[parentA] == _ranks[parentB])
                _ranks[parentB]++;
        }
    }
}