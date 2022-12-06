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
    public int CountNodes(TreeNode root) {
        if (root == null)
            return 0;
        return CountSubtree(root, 0);
    }

    private int CountSubtree(TreeNode node, int nodesCount)
    {
        if (node == null)
            return nodesCount;
        return CountSubtree(node.left, nodesCount) + CountSubtree(node.right, nodesCount) + 1;
    }
}