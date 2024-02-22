public class Solution {
    public int TreeDiameter(int[][] edges) {
        if (edges.Length < 3) {
            return edges.Length;
        }

        var tree = new Dictionary<int, IList<int>>();
        foreach (var e in edges)
        {
            tree.TryAdd(e[0], new List<int>());
            tree[e[0]].Add(e[1]);

            tree.TryAdd(e[1], new List<int>());
            tree[e[1]].Add(e[0]);
        }

        var start = -1;
        var q = new Queue<int>();
        q.Enqueue(0);
        var visited = new HashSet<int>();

        while (q.Count > 0) 
        {
            start = q.Dequeue();
            visited.Add(start);

            foreach (var node in tree[start]) {
                if (!visited.Contains(node))
                {
                    q.Enqueue(node);
                }
            }
        }

        visited = new HashSet<int>();
        q = new Queue<int>();
        q.Enqueue(start);
        var layerSize = 1;
        var diameter = -1;

        while (q.Count > 0) 
        {
            var curr = q.Dequeue();
            layerSize--;
            visited.Add(curr);

            foreach (var node in tree[curr]) {
                if (!visited.Contains(node))
                {
                    q.Enqueue(node);
                }
            }

            if (layerSize == 0) {
                diameter++;
                layerSize = q.Count;
            }
        }

        return diameter;
    }
}