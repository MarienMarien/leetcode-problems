public class Solution {
    public bool EquationsPossible(string[] equations) {
        var uf = new UnionFind();
        foreach(var eq in equations)
        {
            if(eq[1] == '!')
                continue;
            var var1 = eq[0] - 'a';
            var var2 = eq[3] - 'a';
            uf.Union(var1, var2);
        }

        foreach(var eq in equations)
        {
            if(eq[1] == '=')
                continue;
            var var1 = eq[0] - 'a';
            var var2 = eq[3] - 'a';
            if(uf.Find(var1) == uf.Find(var2))
                return false;
        }
        return true;
    }

    class UnionFind
    {
        private int[] _parents;
        public UnionFind()
        {
            _parents = new int[26];
            for(var i = 0; i < 26; i++)
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

        public void Union(int a, int b)
        {
            var parentA = Find(a);
            var parentB = Find(b);

            if(parentA == parentB)
                return ;
            _parents[parentA] = parentB;
        }
    }
}