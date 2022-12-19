public class Solution {
    public int EarliestAcq(int[][] logs, int n) {
        Array.Sort(logs, Comparer<int[]>.Create((x, y) => { return x[0] - y[0]; }));
        var groupCount = n;
        var uf = new UnionFind(n);
        foreach (var log in logs) {
            if (uf.Union(log[1], log[2])) {
                groupCount--;
            }
            if (groupCount == 1)
                return log[0];
        }
        return -1;
    }

    private class UnionFind { 
        private int[] _ranks;
        private int[] _groups;

        public UnionFind(int n)
        {
            _ranks = new int[n];
            _groups = new int[n];
            for (var i = 0; i < n; i++) {
                _groups[i] = i;
            }
        }

        public int Find(int person)
        {
            if (_groups[person] != person)
                _groups[person] = Find(_groups[person]);
            return _groups[person];
        }

        public bool Union(int p1, int p2)
        {
            var group1 = Find(p1);
            var group2 = Find(p2);
            var isUnited = false;
            if (group1 == group2)
                return isUnited;
            isUnited = true;
            if (_ranks[group1] > _ranks[group2])
                _groups[group2] = group1;
            else if (_ranks[group1] < _ranks[group2])
                _groups[group1] = group2;
            else {
                _groups[group1] = group2;
                _ranks[group2]++;
            }

            return isUnited;
        }
    }
}