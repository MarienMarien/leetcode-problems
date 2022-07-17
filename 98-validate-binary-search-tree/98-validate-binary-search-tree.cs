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
    public bool IsValidBST(TreeNode root) {
        if (root == null)
            return true;
        if (root.left == null && root.right == null)
            return true;
        return CheckValidity(root, null, null);
    }

    private bool CheckValidity(TreeNode node, int? min, int? max)
    {
        if (node == null)
            return true;
        if ((min != null && node.val <= min) || (max != null && node.val >= max))
            return false;
        return  CheckValidity(node.left, min, node.val) && CheckValidity(node.right, node.val, max);
    }
}