public class Solution {
    public int LargestPathValue(string colors, int[][] edges)
    {
        var len = colors.Length;
        var adj = new Dictionary<int, IList<int>>();
        var indegree = new int[len];
        foreach (var e in edges) {
            if (!adj.TryAdd(e[0], new List<int>() { e[1] }))
                adj[e[0]].Add(e[1]);
            indegree[e[1]]++;
        }
        var count = new int[len, 26];
        var visited = new bool[len];
        var inStack = new bool[len];
        var ans = 0;
        for (var i = 0; i < len; i++) {
            ans = Math.Max(ans, Dfs(i, colors, adj, count, visited, inStack));
        }
        return ans == Int32.MaxValue ? -1 : ans;
    }

    private int Dfs(int node, string colors, Dictionary<int, IList<int>> adj, int[,] count, bool[] visited, bool[] inStack)
    {
        if (inStack[node]) {
            return Int32.MaxValue;
        }
        if (visited[node]) {
            return count[node,colors[node] - 'a'];
        }
        visited[node] = true;
        inStack[node] = true;
        if (adj.ContainsKey(node)) {
            foreach (var neigh in adj[node]) {
                if (Dfs(neigh, colors, adj, count, visited, inStack) == Int32.MaxValue) {
                    return Int32.MaxValue;
                }
                for (var i = 0; i < 26; i++)
                {
                    count[node,i] = Math.Max(count[node,i], count[neigh,i]);
                }
            }
        }
        count[node, colors[node] - 'a']++;
        inStack[node] = false;
        return count[node, colors[node] - 'a'];
    }
}