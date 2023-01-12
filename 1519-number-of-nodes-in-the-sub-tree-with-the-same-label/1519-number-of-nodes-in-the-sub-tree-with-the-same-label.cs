public class Solution {
    private int[] result;
    public int[] CountSubTrees(int n, int[][] edges, string labels)
    {
        result = new int[n];
        var tree = new Dictionary<int, IList<int>>();
        foreach (var e in edges) {
            tree.TryAdd(e[0], new List<int>());
            tree[e[0]].Add(e[1]);
            tree.TryAdd(e[1], new List<int>());
            tree[e[1]].Add(e[0]);
        }
        CountSubtreeLabels(0, -1, tree, labels);
        return result;
    }

    private int[] CountSubtreeLabels(int node, int parent, Dictionary<int, IList<int>> tree, string labels)
    {
        var nodeLabel = labels[node];
        var labelsCount = new int[26];
        if(tree.ContainsKey(node))
            foreach (var e in tree[node]) {
                if (e == parent)
                    continue;
                var curr = CountSubtreeLabels(e, node, tree, labels);
                for (var i = 0; i < labelsCount.Length; i++) {
                    labelsCount[i] += curr[i];
                }
            }
        result[node] = ++labelsCount[nodeLabel - 'a'];
        return labelsCount;
    }
}