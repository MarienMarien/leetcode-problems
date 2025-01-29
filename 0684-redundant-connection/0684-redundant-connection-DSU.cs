public class Solution {
    private int[] _links;
    private int[] _ranks;
    public int[] FindRedundantConnection(int[][] edges)
    {
        var n = edges.Length;
        _links = new int[n];
        for (var i = 0; i < n; i++)
        {
            _links[i] = i;
        }

        foreach (var e in edges)
        {
            if (!Union(e[0] - 1, e[1] - 1))
                return e;
        }

        return null;
    }

    private bool Union(int a, int b)
    {
        var parentA = Find(a);
        var parentB = Find(b);
        if (parentA == parentB)
            return false;

        _links[parentA] = parentB;
        return true;
    }

    private int Find(int x)
    {
        if (_links[x] != x)
            _links[x] = Find(_links[x]);
        return _links[x];
    }
}