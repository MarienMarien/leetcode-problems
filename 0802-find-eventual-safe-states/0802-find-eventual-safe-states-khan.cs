public class Solution {
    public IList<int> EventualSafeNodes(int[][] graph) {
        var n = graph.Length;
        var indegree = new int[n];
        var reverseNodeMap = new Dictionary<int, ISet<int>>();
        for (var outdeg = 0; outdeg < n; outdeg++)
        {
            foreach (var node in graph[outdeg])
            {
                if (!reverseNodeMap.TryAdd(node, new HashSet<int> { outdeg }))
                    reverseNodeMap[node].Add(outdeg);
                indegree[outdeg]++;
            }
        }

        var q = new Queue<int>();
        for (var i = 0; i < n; i++)
        {
            if (indegree[i] == 0)
                q.Enqueue(i);
        }

        var isSafe = new bool[n];
        while (q.Count > 0)
        {
            var node = q.Dequeue();
            isSafe[node] = true;
            if(reverseNodeMap.ContainsKey(node))
                foreach (var adj in reverseNodeMap[node])
                {
                    indegree[adj]--;
                    if (indegree[adj] == 0)
                        q.Enqueue(adj);
                }
        }

        var safeNodes = new List<int>();
        for (var node = 0; node < n; node++)
        {
            if (isSafe[node])
                safeNodes.Add(node);
        }

        return safeNodes;   
    }
}