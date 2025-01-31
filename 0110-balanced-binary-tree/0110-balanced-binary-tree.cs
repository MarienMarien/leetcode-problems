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
        return IsTreeBalanced(root).isBalanced;
    }

    private (bool isBalanced, int height) IsTreeBalanced(TreeNode node)
    {
        if(node == null)
            return (true, 0);

        var left = IsTreeBalanced(node.left);
        var right = IsTreeBalanced(node.right);
        var isBalanced = left.isBalanced && right.isBalanced && Math.Abs(left.height - right.height) < 2;
        var height = Math.Max(left.height, right.height) + 1;
        return (isBalanced, height);
    }
}