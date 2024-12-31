public class Solution {
    public int MinimumDiameterAfterMerge(int[][] edges1, int[][] edges2)
    {
        var tree1 = new Dictionary<int, ISet<int>>();
        foreach (var e in edges1)
        {
            if (!tree1.TryAdd(e[0], new HashSet<int> { e[1] }))
                tree1[e[0]].Add(e[1]);
            if (!tree1.TryAdd(e[1], new HashSet<int> { e[0] }))
                tree1[e[1]].Add(e[0]);
        }
        var tree2 = new Dictionary<int, ISet<int>>();
        foreach (var e in edges2)
        {
            if (!tree2.TryAdd(e[0], new HashSet<int> { e[1] }))
                tree2[e[0]].Add(e[1]);
            if (!tree2.TryAdd(e[1], new HashSet<int> { e[0] }))
                tree2[e[1]].Add(e[0]);
        }

        var tree1PathStartNode = GetFarthestNode(tree1);
        var tree1LongestPath = GetLongestPath(tree1, tree1PathStartNode);

        var tree2PathStartNode = GetFarthestNode(tree2);
        var tree2LongestPath = GetLongestPath(tree2, tree2PathStartNode);

        var t1Part = (tree1LongestPath + 1) / 2;
        var t2Part = (tree2LongestPath + 1) / 2;
        var combinedDiameter = t1Part + t2Part + 1;
        return Math.Max(Math.Max(tree1LongestPath, tree2LongestPath), combinedDiameter);
    }

    private int GetLongestPath(Dictionary<int, ISet<int>> tree, int startNode)
    {
        var q = new Queue<int>();
        q.Enqueue(startNode);
        var visited = new HashSet<int>();
        var level = 0;
        var levelSize = 1;
        visited.Add(startNode);
        while (q.Count > 0)
        {
            var currNode = q.Dequeue();
            
            levelSize--;
            if(tree.ContainsKey(currNode))
                foreach (var e in tree[currNode])
                {
                    if (!visited.Contains(e))
                    {
                        q.Enqueue(e);
                        visited.Add(e);
                    }
                }

            if (levelSize == 0)
            {
                level++;
                levelSize = q.Count;
            }
        }

        return level - 1;
    }

    private int GetFarthestNode(Dictionary<int, ISet<int>> tree)
    {
        var q = new Queue<int>();
        q.Enqueue(0);
        var visited = new HashSet<int>() { 0 };
        var currNode = 0;
        while (q.Count > 0)
        {
            currNode = q.Dequeue();
            
            if(tree.ContainsKey(currNode))
                foreach (var e in tree[currNode])
                {
                    if (!visited.Contains(e))
                    {
                        q.Enqueue(e);
                        visited.Add(e);
                    }
                }
        }

        return currNode;
    }
}