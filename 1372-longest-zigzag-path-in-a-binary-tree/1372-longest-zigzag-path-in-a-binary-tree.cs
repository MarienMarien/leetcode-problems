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
    private int _longestPath;
    public int LongestZigZag(TreeNode root)
    {
        Dfs(root, 0, false);
        Dfs(root, 0, true);
        return _longestPath;
    }

    private void Dfs(TreeNode node, int steps, bool goLeft)
    {
        if (node == null)
            return;
        _longestPath = Math.Max(_longestPath, steps);
        if (goLeft)
        {
            Dfs(node.left, steps + 1, false);
            Dfs(node.right, 1, true);
        }
        else {
            Dfs(node.left, 1, false);
            Dfs(node.right, steps + 1, true);
        }
    }
}