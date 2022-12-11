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
    private int _max;
    public int MaxPathSum(TreeNode root)
    {
        if (root == null)
            return 0;
        _max = Int32.MinValue;
        CalculateMax(root);
        return _max;
    }

    private int CalculateMax(TreeNode root)
    {
        if (root == null)
            return 0;
        var leftMax = Math.Max(CalculateMax(root.left),0);
        var rightMax = Math.Max(CalculateMax(root.right), 0);
        _max = Math.Max(_max, leftMax + rightMax + root.val);
        return Math.Max(leftMax + root.val, rightMax + root.val);
    }
}