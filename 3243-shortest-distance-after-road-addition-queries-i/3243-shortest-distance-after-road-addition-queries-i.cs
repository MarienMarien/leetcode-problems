public class Solution {
    public int[] ShortestDistanceAfterQueries(int n, int[][] queries) {
        var graph = new Dictionary<int, ISet<int>>();
        for (var i = 0; i < n - 1; i++)
        {
            graph.Add(i, new HashSet<int> { i + 1 });
        }

        var shortestDistanceAfterQuery = new int[queries.Length];

        for(var i = 0; i < queries.Length; i++)
        {
            graph[queries[i][0]].Add(queries[i][1]);
            shortestDistanceAfterQuery[i] = GetShortestDistance(graph, n - 1);
        }

        return shortestDistanceAfterQuery;
    }

    private int GetShortestDistance(Dictionary<int, ISet<int>> graph, int targetCity)
    {
        var q = new Queue<int>();
        q.Enqueue(0);
        var currCity = 0;
        var distance = 0;
        var layerSize = 1;
        var visited = new HashSet<int>() { 0 };

        while (q.Count > 0)
        {
            layerSize--;
            currCity = q.Dequeue();

            foreach (var adj in graph[currCity])
            {
                if (adj == targetCity) 
                {
                    distance++;
                    return distance;
                }
                if(!visited.Contains(adj))
                {
                    q.Enqueue(adj);
                    visited.Add(adj);
                }
            }

            if (layerSize == 0)
            {
                distance++;
                layerSize = q.Count;
            }
        }

        return distance;
    }
}