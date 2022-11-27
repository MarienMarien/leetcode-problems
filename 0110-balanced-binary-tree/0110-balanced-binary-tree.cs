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
    public bool IsBalanced(TreeNode root) {
        if (root == null)
            return true;
        return Math.Abs(GetHeight(root.left, 0) - GetHeight(root.right, 0)) < 2 
            && IsBalanced(root.left)
            && IsBalanced(root.right);
    }

    private int GetHeight(TreeNode node, int currHeight)
    {
        if (node == null)
            return currHeight;
        currHeight++;
        return Math.Max(GetHeight(node.left, currHeight), GetHeight(node.right, currHeight));
    }
}