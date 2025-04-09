public class Solution {
    public int EarliestAcq(int[][] logs, int n) {
        Array.Sort(logs, Comparer<int[]>.Create((x, y) => x[0] - y[0]));
        var uf = new UnionFind(n);
        foreach(var l in logs)
        {
            var time = l[0];
            var friend1 = l[1];
            var friend2 = l[2];
            uf.Union(friend1, friend2);
            if(uf.GetGroupSize(friend1) == n || uf.GetGroupSize(friend2) == n)
                return time;
        }

        return -1;
    }

    class UnionFind
    {
        private int[] _parents;
        private int[] _size;
        private int[] _ranks;

        public UnionFind(int n)
        {
            _size = new int[n];
            _ranks = new int[n];
            _parents = new int[n];
            for(var i = 0; i < n; i++)
            {
                _parents[i] = i;
                _size[i] = 1;
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
                _size[parentA] += _size[parentB];
                return;
            }
            _parents[parentA] = parentB;
            _size[parentB] += _size[parentA];
            if(_ranks[parentA] == _ranks[parentB])
                _ranks[parentB] += 1;
        }

        public int GetGroupSize(int x)
        {
            var parentX = Find(x);
            return _size[parentX];
        }
    }
}