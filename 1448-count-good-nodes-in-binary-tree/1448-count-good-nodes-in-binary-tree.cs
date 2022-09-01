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
    public int GoodNodes(TreeNode root) {
     return DFS(root, Int32.MinValue);
    }

    private int DFS(TreeNode root, int currMax)
    {
        if (root == null)
            return 0;
        var res = root.val >= currMax ? 1 : 0;
        currMax = Math.Max(currMax, root.val);
        res += DFS(root.left, currMax);
        res += DFS(root.right, currMax);
        return res;
    }
}