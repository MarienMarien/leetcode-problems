public class Solution {
    public int[] ShortestAlternatingPaths(int n, int[][] redEdges, int[][] blueEdges) {
        var adj = new Dictionary<int, IList<(int toNode, int color)>>();
        foreach(var edge in redEdges) {
            adj.TryAdd(edge[0], new List<(int, int)>());
            adj[edge[0]].Add((edge[1], 0));
        }
        foreach (var edge in blueEdges)
        {
            adj.TryAdd(edge[0], new List<(int, int)>());
            adj[edge[0]].Add((edge[1], 1));
        }

        var ans = new int[n];
        Array.Fill(ans, -1);
        var visited = new bool[n,2];
        var q = new Queue<(int node, int steps, int prevColor)>();

        q.Enqueue((0, 0, -1));
        ans[0] = 0;
        visited[0, 0] = true;
        visited[0, 1] = true;
        
        while (q.Count > 0) {
            var curr = q.Dequeue();
            if (!adj.ContainsKey(curr.node))
                continue;
            foreach (var neigh in adj[curr.node]) {
                if (!visited[neigh.toNode, neigh.color] && neigh.color != curr.prevColor) {
                    if (ans[neigh.toNode] == -1)
                        ans[neigh.toNode] = curr.steps + 1;
                    visited[neigh.toNode, neigh.color] = true;
                    q.Enqueue((neigh.toNode, 1 + curr.steps, neigh.color));
                }
            }
        }
        return ans;
    }
}