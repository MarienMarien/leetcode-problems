public class Solution {
    private int _componentCount;
    public int MaxKDivisibleComponents(int n, int[][] edges, int[] values, int k) {
        if(n == 1)
            return 1;
        var adjList = new Dictionary<int, ISet<int>>();
        foreach (var e in edges)
        {
            if (!adjList.TryAdd(e[0], new HashSet<int> { e[1] }))
            {
                adjList[e[0]].Add(e[1]);
            }
            if (!adjList.TryAdd(e[1], new HashSet<int> { e[0] }))
            {
                adjList[e[1]].Add(e[0]);
            }
        }

        Dfs(0, -1, adjList, values, k);

        return _componentCount;
    }

    private int Dfs(int currentNode, int parentNode, IDictionary<int, ISet<int>> adjList, int[] nodeValues, int k)
    {
        var sum = 0;
        foreach (var neighborNode in adjList[currentNode])
        {
            if (neighborNode != parentNode)
            {
                sum += Dfs(neighborNode, currentNode, adjList, nodeValues, k);
                sum %= k;
            }
        }

        sum += nodeValues[currentNode];
        sum %= k;

        if (sum == 0)
        {
            _componentCount++;
        }

        return sum;
    }
}