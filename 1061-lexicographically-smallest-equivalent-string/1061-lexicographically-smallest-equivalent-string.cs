public class Solution {
    public string SmallestEquivalentString(string s1, string s2, string baseStr)
    {
        var uf = new UnionFind(26);
        for (var i = 0; i < s1.Length; i++) {
            var parent1 = uf.Find(s1[i] - 'a');
            var parent2 = uf.Find(s2[i] - 'a');
            if (parent1 <= parent2)
            {
                uf.Union(parent2, parent1);
            }
            else { 
                uf.Union(parent1, parent2);
            }
        }
        var sb = new StringBuilder();
        foreach (var ch in baseStr) {
            var nextCh = uf.Find(ch - 'a');
            sb.Append((char)(nextCh + 'a'));
        }
        return sb.ToString();
    }

    class UnionFind {
        private int[] _parent;
        public UnionFind(int n)
        {
            _parent = new int[n];
            for (var i = 0; i < n; i++)
                _parent[i] = i;
        }

        public int Find(int n) {
            if (_parent[n] != n)
                _parent[n] = Find(_parent[n]);
            return _parent[n];
        }

        public void Union(int n1, int n2) {
            _parent[n1] = n2;
        }
    }
}