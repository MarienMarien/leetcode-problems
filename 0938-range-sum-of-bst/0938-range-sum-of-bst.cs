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
    public int RangeSumBST(TreeNode root, int low, int high) {
        return CalculateSum(root, low, high);
    }
    
    private int CalculateSum(TreeNode root, int low, int high) { 
        if (root == null)
            return 0;
        var currentValue = root.val >= low && root.val <= high ? root.val : 0;
        return CalculateSum(root.left, low, high) + CalculateSum(root.right, low, high) + currentValue;
    }
}