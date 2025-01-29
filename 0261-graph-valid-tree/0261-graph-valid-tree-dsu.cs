public class Solution {
    private int[] _links;
    private int[] _ranks;

    public bool ValidTree(int n, int[][] edges)
    {
        _links = new int[n];
        _ranks = new int[n];

        for (var i = 0; i < n; i++)
            _links[i] = i;
        foreach (var e in edges)
        {
            if (!Union(e[0], e[1]))
                return false;
        }

        return IsAllConnected();
    }

    private bool IsAllConnected()
    {
        var found = false;
        for (var i = 0; i < _links.Length; i++)
        {
            if (_links[i] != i)
                continue;
            if (found)
                return false;
            found = true;
        }
        return true;
    }

    private bool Union(int a, int b)
    {
        var parentA = Find(a);
        var parentB = Find(b);
        if (parentA == parentB)
            return false;
        if (_ranks[parentA] > _ranks[parentB])
        {
            _links[parentB] = parentA;
        }
        else {
            if (_ranks[parentA] == _ranks[parentB])
                _ranks[parentA]++;
            _links[parentA] = parentB;
        }

        return true;
    }

    private int Find(int x)
    {
        if (_links[x] != x)
            _links[x] = Find(_links[x]);
        return _links[x];
    }
}