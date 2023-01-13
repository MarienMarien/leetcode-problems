public class Solution {
    private int longestPath;
    public int LongestPath(int[] parent, string s)
    {
        longestPath = 1;
        var tree = new Dictionary<int, IList<int>>();
        for (var i = 0; i < parent.Length; i++) {
            tree.TryAdd(parent[i], new List<int>());
            tree[parent[i]].Add(i);
        }
        Dfs(0, tree, s);
        return longestPath;
    }

    private int Dfs(int curr, Dictionary<int, IList<int>> tree, string s) {
        if (!tree.ContainsKey(curr))
            return 1;
        var longest = 0;
        var longest2 = 0;
        foreach (var n in tree[curr]) {
            var longestForSubtree = Dfs(n, tree, s);
            if (s[curr] == s[n])
                continue;
            if (longestForSubtree > longest)
            {
                longest2 = longest;
                longest = longestForSubtree;
            }
            else if (longestForSubtree > longest2)
                longest2 = longestForSubtree;
        }
        longestPath = Math.Max(longestPath, longest + longest2 + 1);
        return longest + 1;
    }
}