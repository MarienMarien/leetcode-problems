/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public IList<IList<int>> FindLeaves(TreeNode root) {
     var res = new Dictionary<int, IList<int>>();
        DFS(root, res);
        return res.Values.ToList();
    }

    private static int DFS(TreeNode root, Dictionary<int, IList<int>> res)
    {
        if (root == null)
            return -1;
        var leftTreeLvl = DFS(root.left, res);
        var rightTreeLvl = DFS(root.right, res);

        var leavesLevel = Math.Max(leftTreeLvl, rightTreeLvl) + 1;
        if (!res.ContainsKey(leavesLevel))
            res.Add(leavesLevel, new List<int>());
        res[leavesLevel].Add(root.val);
        return leavesLevel;
    }
}