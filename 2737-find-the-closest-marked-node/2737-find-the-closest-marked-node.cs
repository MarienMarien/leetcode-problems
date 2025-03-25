public class Solution {
    public int MinimumDistance(int n, IList<IList<int>> edges, int s, int[] marked) {
        var graph = new Dictionary<int, ISet<(int v, int w)>>();
        foreach(var e in edges)
        {
            if(!graph.ContainsKey(e[0]))
            {
                graph.Add(e[0], new HashSet<(int, int)>());
            }
            graph[e[0]].Add((e[1], e[2]));
        }
        var markedSet = new HashSet<int>(marked);
        var q = new PriorityQueue<(int node, int w), int>();
        q.Enqueue((s, 0), 0);
        var minDistance = int.MaxValue;
        var weight = new int[n];
        weight[s] = 0;
        while(q.Count > 0)
        {
            var curr = q.Dequeue();
            if(markedSet.Contains(curr.node))
            {
                return weight[curr.node];
            }
            if(!graph.ContainsKey(curr.node))
                continue;
            foreach(var adj in graph[curr.node])
            {
                var newW = curr.w + adj.w;
                if(weight[adj.v] == 0 || newW < weight[adj.v])
                {
                    weight[adj.v] = newW;
                    q.Enqueue((adj.v, newW), newW);
                }
            }
        }

        return -1;
    }
}