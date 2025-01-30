public class Solution {
    private IDictionary<int, ISet<int>> _adjList;
    private int[] _colors;
    public int MagnificentSets(int n, int[][] edges)
    {
        _adjList = new Dictionary<int, ISet<int>>();
        foreach (var edge in edges)
        {
            if (!_adjList.TryAdd(edge[0] - 1, new HashSet<int> { edge[1] - 1 }))
                _adjList[edge[0] - 1].Add(edge[1] - 1);

            if (!_adjList.TryAdd(edge[1] - 1, new HashSet<int> { edge[0] - 1 }))
                _adjList[edge[1] - 1].Add(edge[0] - 1);
        }

        _colors = new int[n];
        Array.Fill(_colors, -1);

        for (var node = 0; node < n; node++)
        {
            if (_colors[node] != -1) 
                continue;
            _colors[node] = 0;
            if (!IsBipartite(node)) 
                return -1;
        }

        var distances = new int[n];
        for (var node = 0; node < n; node++)
        {
            distances[node] = GetLongestShortestPath(node, n);
        }

        var maxNumberOfGroups = 0;
        var visited = new bool[n];
        for (var node = 0; node < n; node++)
        {
            if (visited[node]) 
                continue;
            maxNumberOfGroups += GetNumberOfGroupsForComponent(node, distances, visited);
        }

        return maxNumberOfGroups;
    }

    private bool IsBipartite(int node)
    {
        if(_adjList.ContainsKey(node))
        {
            foreach (var neighbor in _adjList[node])
            {
                if (_colors[neighbor] == _colors[node])
                    return false;

                if (_colors[neighbor] != -1) 
                    continue;

                _colors[neighbor] = (_colors[node] + 1) % 2;

                if (!IsBipartite(neighbor)) 
                    return false;
            }
        }
        return true;
    }

    private int GetLongestShortestPath(int srcNode, int n)
    {
        var nodesQueue = new Queue<int>();
        var visited = new bool[n];

        nodesQueue.Enqueue(srcNode);
        visited[srcNode] = true;
        var distance = 0;

        while (nodesQueue.Count > 0)
        {
            var numOfNodesInLayer = nodesQueue.Count;
            for (var i = 0; i < numOfNodesInLayer; i++)
            {
                var currentNode = nodesQueue.Dequeue();
                if(!_adjList.ContainsKey(currentNode))
                    continue;
                foreach (var neighbor in _adjList[currentNode])
                {
                    if (visited[neighbor]) 
                        continue;
                    visited[neighbor] = true;
                    nodesQueue.Enqueue(neighbor);
                }
            }
            distance++;
        }

        return distance;
    }

    private int GetNumberOfGroupsForComponent(int node, int[] distances, bool[] visited)
    {
        var maxNumberOfGroups = distances[node];
        visited[node] = true;

        if(_adjList.ContainsKey(node))
        {
            foreach (var neighbor in _adjList[node])
            {
                if (visited[neighbor]) continue;
                maxNumberOfGroups = Math.Max(maxNumberOfGroups,
                    GetNumberOfGroupsForComponent(neighbor, distances, visited)
                );
            }
        }
        return maxNumberOfGroups;
    }
}