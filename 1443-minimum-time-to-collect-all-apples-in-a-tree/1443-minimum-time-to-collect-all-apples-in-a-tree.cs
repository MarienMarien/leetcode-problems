public class Solution {
    public int MinTime(int n, int[][] edges, IList<bool> hasApple) {
        var applesCount = 0;
        foreach (var apple in hasApple) {
            if (apple)
                applesCount++;
        }
        if (applesCount == 0)
            return 0;
        var tree = new Dictionary<int, IList<int>>();
        foreach (var e in edges) {
            tree.TryAdd(e[0], new List<int>());
            tree[e[0]].Add(e[1]);
            tree.TryAdd(e[1], new List<int>());
            tree[e[1]].Add(e[0]);
        }
        return Dfs(0, -1, tree, hasApple);
    }

    private int Dfs(int curr, int parent, Dictionary<int, IList<int>> tree, IList<bool> hasApple) {
        int totalTime = 0;
        int subTreeTime = 0;
        foreach (var node in tree[curr]) {
            if (node == parent)
                continue;
            subTreeTime = Dfs(node, curr, tree, hasApple);
            if (subTreeTime > 0 || hasApple[node])
                totalTime += subTreeTime + 2;
        }
        return totalTime;
    }
}