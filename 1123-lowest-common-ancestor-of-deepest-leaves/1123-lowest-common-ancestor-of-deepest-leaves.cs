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
    public TreeNode LcaDeepestLeaves(TreeNode root) {
        return GetLca(root).lca;
    }

    private (TreeNode lca, int depth) GetLca(TreeNode node)
    {
        if(node == null)
            return (null, 0);

        var left = GetLca(node.left);
        var right = GetLca(node.right);

        if(left.depth > right.depth)
            return (left.lca, left.depth + 1);
        if(left.depth < right.depth)
            return (right.lca, right.depth + 1);
        return (node, left.depth + 1);
    }

}