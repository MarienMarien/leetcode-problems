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
    public bool HasPathSum(TreeNode root, int targetSum) {
        return root == null ? false : HasPathSum(root, targetSum, 0);
    }

    private static bool HasPathSum(TreeNode root, int targetSum, int currSum)
    {
        if (root == null)
            return false;
        currSum += root.val;
        if (root.left == null && root.right == null)
            return currSum == targetSum;
        var hasSum = HasPathSum(root.left, targetSum, currSum);
        if(!hasSum)
            hasSum = HasPathSum(root.right, targetSum, currSum);
        return hasSum;
    }
}