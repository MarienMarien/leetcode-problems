public class Solution {
    public int NumberOfGoodPaths(int[] vals, int[][] edges) {
        var tree = new Dictionary<int, IList<int>>();
        foreach (var e in edges) {
            tree.TryAdd(e[0], new List<int>());
            tree[e[0]].Add(e[1]);
            tree.TryAdd(e[1], new List<int>());
            tree[e[1]].Add(e[0]);
        }
        var valuesToNodes = new SortedDictionary<int, IList<int>>();
        for (var i = 0; i < vals.Length; i++) {
            valuesToNodes.TryAdd(vals[i], new List<int>());
            valuesToNodes[vals[i]].Add(i);
        }
        var goodPathsCount = 0;
        var uf = new UnionFind(vals.Length);
        foreach (var entry in valuesToNodes) { 
            foreach(var node in entry.Value) {
                if (!tree.ContainsKey(node))
                    continue;
                foreach (var neighbor in tree[node]) {
                    if (vals[node] >= vals[neighbor])
                        uf.Union(node, neighbor);
                }
            }
            var group = new Dictionary<int, int>();
            foreach (var node in entry.Value) {
                var groupKey = uf.Find(node);
                var groupVal = 1 + (group.ContainsKey(groupKey) ? group[groupKey] : 0);
                group[groupKey] = groupVal;
            }
            foreach (var g in group) {
                goodPathsCount += g.Value * (g.Value + 1) / 2;
            }
        }

        return goodPathsCount;
    }

     private class UnionFind {
        private int[] parent;
        private int[] rank;
        public UnionFind(int n)
        {
            parent = new int[n];
            for (var i = 0; i < n; i++)
                    parent[i] = i;
            rank = new int[n];
        }

        public int Find(int n) {
            if (parent[n] != n)
                parent[n] = Find(parent[n]);
            return parent[n];
        }

        public void Union(int x, int y) {
            var parentX = Find(x);
            var parentY = Find(y);
            if (parentX == parentY)
                return;
            if (rank[parentX] < rank[parentY])
                parent[parentX] = parentY;
            else if (rank[parentX] > rank[parentY])
                parent[parentY] = parentX;
            else {
                parent[parentY] = parentX;
                rank[parentX]++;
            }
        }
    }
}