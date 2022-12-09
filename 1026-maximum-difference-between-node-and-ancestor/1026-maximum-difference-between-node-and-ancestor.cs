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
    public int MaxAncestorDiff(TreeNode root) {
        if(root == null)
            return 0;
        return GetMax(root, root.val, root.val);
    }

    private static int GetMax(TreeNode root, int min, int max)
    {
        if (root == null)
            return max - min;
        min = Math.Min(min, root.val);
        max = Math.Max(max, root.val);
        var left = GetMax(root.left, min, max);
        var right = GetMax(root.right, min, max);
        return Math.Max(left, right);
    }
}