public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        var uf = new UnionFind(n);
        foreach(var e in edges)
        {
            if(!uf.Union(e[0], e[1]))
                return false;
        }

        var rootFound = false;
        for(var node = 0; node < n; node++)
        {
            if(node != uf.Find(node))
                continue;
            if(rootFound)
                return false;
            rootFound = true;
        }

        return true;
    }

    class UnionFind
    {
        private int[] _parents;
        private int[] _ranks;
        public UnionFind(int n)
        {
            _ranks = new int[n];
            _parents = new int[n];
            for(var i = 0; i < n; i++)
            {
                _parents[i] = i;
            }
        }

        public int Find(int x)
        {
            if(x != _parents[x])
                _parents[x] = Find(_parents[x]);
            return _parents[x];
        }

        public bool Union(int a, int b)
        {
            var parentA = Find(a);
            var parentB = Find(b);

            if(parentA == parentB)
                return false;
            if(_ranks[parentA] > _ranks[parentB])
            {
                _parents[parentB] = parentA;
                return true;
            } 

            if(_ranks[parentA] == _ranks[parentB])
                _ranks[parentA]++;
            _parents[parentA] = parentB;

            return true;
        }
    }
}