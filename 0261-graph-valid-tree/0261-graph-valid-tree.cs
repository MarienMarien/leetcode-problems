public class Solution {
    public bool ValidTree(int n, int[][] edges) {
        if (edges == null || edges.Length == 0)
            return n == 1 ? true : false;

        var map = new Dictionary<int, HashSet<int>>();
        foreach (var e in edges)
        {
            if (!map.TryAdd(e[0], new HashSet<int>() { e[1] }))
            {
                map[e[0]].Add(e[1]);
            }

            if (!map.TryAdd(e[1], new HashSet<int>() { e[0] }))
            {
                map[e[1]].Add(e[0]);
            }
        }

        if (map.Count != n)
            return false;

        var q = new Queue<(int node, int parent)>();
        q.Enqueue((0, -1));
        var visited = new HashSet<int>() { 0 };

        while (q.Count > 0)
        {
            var curr = q.Dequeue();

            foreach (var e in map[curr.node])
            {
                if (visited.Contains(e) && e != curr.parent)
                {
                    return false;
                }
                if (e != curr.parent)
                {
                    q.Enqueue((e, curr.node));
                    visited.Add(e);
                }
            }
        }

        return visited.Count == n;
    }
}