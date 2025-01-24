public class Solution {
    private ISet<int> _visited;
    private ISet<int> _safeNodes;
    private ISet<int> _unsafeNodes;
    public IList<int> EventualSafeNodes(int[][] graph)
    {
        _visited = new HashSet<int>();
        _safeNodes = new HashSet<int>();
        _unsafeNodes = new HashSet<int>();
        var n = graph.Length;

        for (var i = 0; i < n; i++)
        {
            CheckIfSafe(graph, i);
        }

        return _safeNodes.Order().ToList();
    }

    private bool CheckIfSafe(int[][] graph, int currNode)
    {
        if (_unsafeNodes.Contains(currNode) || _visited.Contains(currNode))
        {
            _visited.ToList().ForEach( x => _unsafeNodes.Add(x));
            return false;
        }

        if (_safeNodes.Contains(currNode))
            return true;

        _visited.Add(currNode);
        
        var isSafe = true;
        foreach (var node in graph[currNode])
        {
            isSafe &= CheckIfSafe(graph, node);
        }

        if (isSafe)
        {
            _safeNodes.Add(currNode);
        }
        _visited.Remove(currNode);

        return isSafe;
    }
}