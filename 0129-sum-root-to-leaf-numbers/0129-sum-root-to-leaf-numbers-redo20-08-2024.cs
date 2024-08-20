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
    public int SumNumbers(TreeNode root) {
        return Sum(root, 0, 0);
    }

    private int Sum(TreeNode node, int currSum, int totalSum)
    {
        if (node == null)
            return 0;

        currSum *= 10;
        currSum += node.val;

        if (node.left == null && node.right == null)
        {
            totalSum += currSum;
            return totalSum;
        }

        totalSum += Sum(node.left, currSum, totalSum) + Sum(node.right, currSum, totalSum);

        return totalSum;
    }
}