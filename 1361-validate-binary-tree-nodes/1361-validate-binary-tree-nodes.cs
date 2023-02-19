public class Solution {
    private int[] _parent;
    private int[] _connectionsCount;
    public bool ValidateBinaryTreeNodes(int n, int[] leftChild, int[] rightChild)
    {
        _parent = new int[n];
        _connectionsCount = new int[n];
        for (var i = 0; i < n; i++) {
            _parent[i] = i;
            _connectionsCount[i] = 1;
        }
        for (var i = 0; i < n; i++) {
            if (leftChild[i] != -1) {
                if (!Union(i, leftChild[i]))
                    return false;
            }
            if (rightChild[i] != -1)
            {
                if (!Union(i, rightChild[i]))
                    return false;
            }
        }
        for (var i = 0; i < n; i++) {
            if (_connectionsCount[i] == n)
                return true;
        }
        return false;
    }

    private bool Union(int a, int b)
    {
        var parentA = Find(a);
        var parentB = Find(b);
        if (parentA == parentB || parentB != b)
            return false;
        _parent[parentB] = parentA;
        _connectionsCount[parentA] += _connectionsCount[parentB];
        return true;
    }

    private int Find(int n)
    {
        while (n != _parent[n])
            n = _parent[n];
        return n;
    }
}