/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */

public class Solution {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        return p.val > q.val ? GetLowestCommonAncestor(root, q, p) : GetLowestCommonAncestor(root, p, q);
    }

    private static TreeNode GetLowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
    {
        if (root == null)
            return null;
        if (root.val >= p.val && root.val <= q.val)
            return root;
        if (q.val < root.val)
            return GetLowestCommonAncestor(root.left, p, q);
        else
            return GetLowestCommonAncestor(root.right, p, q);
    }
}