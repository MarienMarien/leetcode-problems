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
    public int SumOfLeftLeaves(TreeNode root) {
        return CountSum(root);
    }

    private int CountSum(TreeNode root)
    {
        if (root == null)
            return 0;
        if (root.left != null && IsLeaf(root.left))
            return root.left.val + CountSum(root.right);
        return CountSum(root.left) + CountSum(root.right);
    }

    private bool IsLeaf(TreeNode node)
    {
        return node.left == null && node.right == null;
    }
}