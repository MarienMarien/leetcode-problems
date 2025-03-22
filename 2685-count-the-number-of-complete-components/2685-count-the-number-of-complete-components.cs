public class Solution {
    public int CountCompleteComponents(int n, int[][] edges) {
        var uf = new UnionFind(n);
        foreach(var e in edges)
        {
            uf.Union(e[0], e[1]);
        }
        var groupRoots = uf.GetGroupRoots();
        var completeCompCount = 0;
        Console.WriteLine($"grRoots: {groupRoots.Count}");
        foreach(var gr in groupRoots)
        {
            Console.WriteLine($"gr: {gr}");
            if(uf.IsComplete(gr))
                completeCompCount++;
        }

        return completeCompCount;
    }

    class UnionFind
    {
        private ISet<int> _groupRoots;
        private int[] _parent;
        private int[] _size; 
        private int[] _edgesCount;

        public UnionFind(int n)
        {
            _groupRoots = new HashSet<int>();
            _parent = new int[n];
            _size = new int[n];
            for(var i= 0; i < n; i++)
            {
                _parent[i] = i;
                _groupRoots.Add(i);
                _size[i] = 1;
            }
            _edgesCount = new int[n];
        }

        public int Find(int x)
        {
            if(_parent[x] != x)
            {
                _parent[x] = Find(_parent[x]);
            }
            return _parent[x];
        }

        public void Union(int a, int b)
        {
            var parentA = Find(a);
            var parentB = Find(b);

            if(parentA == parentB)
            {
                _edgesCount[parentA] += 1;
                return;
            }
        
            _groupRoots.Remove(parentB);
            _parent[parentB] = parentA;
            _size[parentA] += _size[parentB];
            _edgesCount[parentA] += _edgesCount[parentB] + 1;
        }

        public ISet<int> GetGroupRoots()
        {
            return _groupRoots;
        }

        public bool IsComplete(int n)
        {
            var expectedEdgesCount = (_size[n] * (_size[n] - 1)) / 2;
            return _edgesCount[n] == expectedEdgesCount;
        }
    }
}