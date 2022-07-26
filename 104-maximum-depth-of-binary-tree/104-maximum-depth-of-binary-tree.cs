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
    public int MaxDepth(TreeNode root) {
    return GetMaxDepth(root, 0, 0);
    }

    private int GetMaxDepth(TreeNode root, int maxDepth, int currDepth)
    {
        if (root != null)
            currDepth++;
        else {
            maxDepth = Math.Max(maxDepth, currDepth);
            return maxDepth;
        }
        return Math.Max(GetMaxDepth(root.left, maxDepth, currDepth), GetMaxDepth(root.right, maxDepth, currDepth));
    }
}